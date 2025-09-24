using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingProject;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml.Linq;


namespace TrainingApp
{
	public partial class MainForm : Form
	{
		private Game MyGame;
		private int shownCount;
		private int maxCount = 1000;
		private int tickRate = 1000;
		private int counter;
		private int mouseButton = 0;
		private int PauseTimer;
		private Boolean breakTimerOn = true;
		private DateTime saveTime;
		private int StandbyCountdown = 0;
		[DllImport("user32.dll")]
		public static extern Int32 SwapMouseButton(Int32 bSwap);
		public MainForm()
		{
			try
			{
				MyGame = BinarySerialization.ReadFromBinaryFile<Game>("data\\TrainingProject.bin");
				//MyGame.fixTech();
			}
			catch
			{
				// if no file, start a new game
				MyGame = new Game(true);
			}
			counter = 1;
			if (MyGame.SafeTime < DateTime.Now)
			{
				MyGame.BreakTime = DateTime.Now.AddMinutes(55);
				MyGame.SafeTime = DateTime.Now.AddMinutes(20);
			}
			tickRate -= MyGame.getResearchDevLvl;
			MyGame.BreakTime = DateTime.Now.AddMinutes(5); // remove
			saveTime = DateTime.Now.AddHours(1);
			Application.EnableVisualStyles();
			InitializeComponent();
			mnuDisplayJackpot.Text = String.Format("J:{0:c0} L:{1:c0}", MyGame.CurrentJackpot - MyGame.MinWage, MyGame.MinWage);
			mnuComunityOutreach.Text = String.Format("Comunity: {0:P2}",MyGame.getArenaOutreach());
			MinJackpotLevel.Text = MyGame.MinWage.ToString();
			fastForwardToolStripMenuItem.Text = string.Format(" Fast Forward {0:n0}", MyGame.FastForwardCount);
			cboRepairPercent.SelectedItem = MyGame.repairPercent;
			if (MyGame.RobotPriority)
				mnuPriority.SelectedIndex = 1; // Robot Priority
			else
				mnuPriority.SelectedIndex = 0; // Equipment Priority
			cboSaveCredits.SelectedItem = MyGame.PurchaseUpgrade;
			txtMaxManagerHrs.Text = MyGame.maxManagerHours.ToString();
			MyGame.MainFormPanel = MainPannel;
			// set interval
			MyGame.interval(timer1);
			// add teams to the drop down list
			cbTeamSelect.Items.Add("Stats");
			foreach (Team eTeam in MyGame.GameTeams)
			{
				cbTeamSelect.Items.Add(eTeam.getName);
			}
			cbTeamSelect.SelectedIndex = 0;
			// select correct repair percentage, and saveCredits values
			if (MyGame.PurchaseUpgrade)
				cboSaveCredits.SelectedItem = "Yes";
			else
				cboSaveCredits.SelectedItem = "No";
			cboRepairPercent.SelectedItem = MyGame.repairPercent.ToString();
			update();
		}
		[FlagsAttribute]
		public enum EXECUTION_STATE : uint
		{
			ES_AWAYMODE_REQUIRED = 0x00000040,
			ES_CONTINUOUS = 0x80000000,
			ES_DISPLAY_REQUIRED = 0x00000002,
			ES_SYSTEM_REQUIRED = 0x00000001
			// Legacy flag, should not be used.
			// ES_USER_PRESENT = 0x00000004
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

		private void cbTeamSelect_Change(object sender, EventArgs e)
		{
			foreach (Control eControl in MainPannel.Controls)
			{
				eControl.Dispose();
			}
			MainPannel.Controls.Clear();
			MainPannel.Controls.Add(MyGame.showSelectedTeam(cbTeamSelect.SelectedIndex, true));
			shownCount = maxCount;
			if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getAvailableRobo > 0
					&& MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency > MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost
					&& MyGame.getGameCurrency > 0)
				btnAddRobo.Enabled = true;
			SendKeys.Send("{ESC}");
		}
		private void btnAddTeam_Click(object sender, EventArgs e)
		{
			string TeamName = MyGame.addTeam();
			if (TeamName.Length > 0)
				cbTeamSelect.Items.Add(TeamName);
			update();

		}

		private void btnAddRobo_Click(object sender, EventArgs e)
		{
			MyGame.addRobo(cbTeamSelect.SelectedIndex - 1);
			update();
		}

		private void btnFight_Click(object sender, EventArgs e)
		{
			if (!MyGame.isFighting())
			{
				shownCount = maxCount;
				addManagerHrs();
				MyGame.startFight();
				update();
			}
		}
		private void addManagerHrs()
		{
			int hrs = (int)(MyGame.SafeTime - DateTime.Now).TotalHours;
			if (Game.RndVal.Next(MyGame.ManagerHrs+10) < 1 && hrs < 1)
			{
				MyGame.ManagerHrs++;
				MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "up");
			}
		}
		/***********************
         * * Ensure you can only add a team or robot when they are not on max
         * *
         * *******************/
		private void timer1_Tick(object sender, EventArgs e)
		{
			setColour();
			if (MyGame.SafeTime > DateTime.Now)
			{
				update();
				if (MyGame.FastForward && !MyGame.isFighting()) timer1.Interval = 50;
				else MyGame.interval(timer1);
				#if DEBUG
					timer1.Interval = 50; //speed up for testing
				#endif
				// Make sure the computer doesn't go to sleep
				//SetThreadExecutionState( EXECUTION_STATE.ES_CONTINUOUS);
			}
			else
			{
				timer1.Enabled = false;
				btnAutomatic.BackColor = Color.Red;
			}
			cbTeamSelect.Focus();
		}
		public void update()
		{
			Boolean addTeam = false;
			// background image
			Image addTeamImage = new Bitmap(@"Resources\AddTeam.png");
			Boolean addRobo = false;
			Boolean buildLvl = false;
			Boolean shopRestock = false;
			Boolean ComunityOutreach = false;
			Color shopColour = Color.White;
			Color advertColour = Color.White;
			if (MyGame.getAvailableTeams > 0 && MyGame.getTeamCost < MyGame.getGameCurrency) 
																						addTeam = true;
			if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getAvailableRobo > 0
					&& MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency > MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost) 
																						addRobo = true;
			// if you have enough money to upgrade Arena, Shop, Research, Monster Den, or Concession
			if (MyGame.getGameCurrency >= MyGame.getArenaLvlCost ||
					MyGame.getGameCurrency >= MyGame.getShopLvlCost ||
					MyGame.getGameCurrency >= MyGame.getResearchDevLvlCost ||
					MyGame.getGameCurrency >= MyGame.getMonsterDenLvlCost ||
					MyGame.getGameCurrency >= MyGame.getConcessionLvlCost)				buildLvl = true;
			if (MyGame.getGameCurrency >= MyGame.getArenaLvlCost)						ComunityOutreach = true;
			if (MyGame.StartForge || MyGame.StartRestock)								shopColour = Color.Aquamarine;
			// enough money to upgrade or re-stock
			if (!MyGame.StartForge && MyGame.getGameCurrency >= MyGame.getShopStockCost && MyGame.getShopStock > MyGame.storeEquipment.Count) 
			{
				shopRestock = true;
				shopColour = Color.Green;
			}
			else if (!MyGame.StartRestock && MyGame.getGameCurrency > 0 && MyGame.getConcessionStock == 0)
			{
				shopRestock = true;
				shopColour = Color.LawnGreen;
			}
			// if seats available 3 battles in a row we need advertising
			if (MyGame.NeedAdvertising > 3)
			{
				advertColour = Color.Magenta;
			}

			btnAddTeam.Enabled = addTeam;
			btnAddTeam.Image = addTeamImage;
			btnAddRobo.Enabled = addRobo;
			btnArenaLvl.Enabled = buildLvl;
			btnShop.Enabled = shopRestock;
			btnShop.BackColor = shopColour;
			mnuComunityOutreach.Enabled = ComunityOutreach;
			btnAdvertising.Enabled = ComunityOutreach;
			btnAdvertising.BackColor = advertColour;
			if ((MyGame.SafeTime - DateTime.Now).TotalHours >= 1)
				mnuLongBattle.Text = String.Format("Return to work");
			else
				mnuLongBattle.Text = String.Format("Long Battle {0}hrs \n{1:c0}", MyGame.ManagerHrs, MyGame.ManagerCost);
			fastForwardToolStripMenuItem.Text = string.Format(" Fast Forward {0:n0}", MyGame.FastForwardCount);
			// if fight is active
			if (MyGame.isFighting())
			{
				btnFight.BackColor = Color.Red;
				// If we are not fast forwarding, and it is time to display again
				if (!MyGame.FastForward && (DateTime.Now > MyGame.DisplayTime || !MyGame.isAuto() || MyGame.GameTeam1[0].shownDefeated) 
						&& (DateTime.Now < MyGame.BreakTime || !breakTimerOn))
				{
					//if (MyGame.GameTeam1.Count > 0) MyGame.debugMsg = "\n(" + DateTime.Now + " > " + MyGame.DisplayTime + " || " + !MyGame.isAuto() + " || " + !MyGame.FastForward + " || " + MyGame.GameTeam1[0].shownDefeated + ") && (" + DateTime.Now + " < " + MyGame.BreakTime + " || " + !breakTimerOn + ")";
					foreach (Control eControl in MainPannel.Controls)
						eControl.Dispose();
					MainPannel.Controls.Clear();
					FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
					MainPannel.Controls.Add(MyGame.continueFight(true));
					MyGame.DisplayTime = DateTime.Now.AddSeconds(5);
					MyGame.resetShowDefeated();
				}
				// fast forward or don't show the next round. 
				else
				{

					//if (MyGame.GameTeam1.Count > 0) MyGame.debugMsg = "\n" + MyGame.FastForwardCount.ToString("n0") + " > 0 && " + MyGame.GameTeam1.Count.ToString() + " > 0 && " + MyGame.GameTeam1[0].getHealthPercent().ToString("n2") + " >= .25 && " + MyGame.GameTeam2[0].getHealthPercent().ToString("n2") + " >= .25";
					if (MyGame.FastForward)
					{
						bool bContinue = true;
						while (MyGame.FastForwardCount > 0 && bContinue)
						{
							// Display every 5 seconds
							if (DateTime.Now > MyGame.DisplayTime)
							{ 
								// show the next round
								foreach (Control eControl in MainPannel.Controls)
									eControl.Dispose();
								MainPannel.Controls.Clear();
								FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
								MainPannel.Controls.Add(MyGame.continueFight(true));
								shownCount = 0;
								MyGame.resetShowDefeated();
								if (MyGame.FastForwardCount > 0 && MyGame.GameTeam1.Count > 0 && MyGame.GameTeam1[0].getHealthPercent() >= .1 && MyGame.GameTeam2[0].getHealthPercent() >= .1) MyGame.FastForwardCount--;
								else bContinue = false;
								MyGame.DisplayTime = DateTime.Now.AddSeconds(5);
							}
							// Not displaying
							else
							{
								MyGame.continueFight(false);
								if (MyGame.FastForwardCount > 0 && MyGame.GameTeam1.Count > 0 && MyGame.GameTeam1[0].getHealthPercent() >= .1 && MyGame.GameTeam2[0].getHealthPercent() >= .1) MyGame.FastForwardCount--;
								// if we run out of Fast Forwards or the health of one of the teams is below 5% stop fast forwarding
								else bContinue = false;
							}
						}
						if (MyGame.FastForwardCount <= 0) { MyGame.FastForward = false; MyGame.FastForwardCount = 0; }
					}
					else
					{
						Random rnd = new Random();
						do
						{	MyGame.continueFight(false); } while (rnd.Next(shownCount) < MyGame.GameTeams[0].getMaxRobos && MyGame.GameTeam1.Count > 0 && MyGame.GameTeam1[0].getHealthPercent() > .1 && MyGame.GameTeam2[0].getHealthPercent() > .1);
					}
				}
				if (!MyGame.isFighting())
					shownCount = maxCount;
			}
			else
			{
				// five percent chance to start a new fight 
				if (MyGame.FightBreakCount >= MyGame.FightBreak)
				{
					MyGame.startFight();
					shownCount = maxCount; 
					addManagerHrs();
				}
				else
				{
					MyGame.FightBreakCount++;
					if (shownCount++ > 5)
					{
						foreach (Control eControl in MainPannel.Controls)
						{
							eControl.Dispose();
						}
						MainPannel.Controls.Clear();
						MainPannel.Controls.Add(MyGame.showSelectedTeam(cbTeamSelect.SelectedIndex, false));
						shownCount = 0;
					}
				}
			}
			MainPannel.AutoScrollPosition = new Point(0, 0);
			mnuDisplayJackpot.Text = String.Format("J:{0:c0} L:{1:c0}", MyGame.CurrentJackpot - MyGame.MinWage, MyGame.MinWage );
			mnuComunityOutreach.Text = String.Format("Comunity: {0:P2}", MyGame.getArenaOutreach());
			MinJackpotLevel.Text = MyGame.MinWage.ToString();
			cboRepairPercent.SelectedItem = MyGame.repairPercent;
			if (MyGame.RobotPriority)
				mnuPriority.SelectedIndex = 1; // Robot Priority
			else
				mnuPriority.SelectedIndex = 0; // Equipment Priority
			cboSaveCredits.SelectedItem = MyGame.PurchaseUpgrade;
			txtMaxManagerHrs.Text = MyGame.maxManagerHours.ToString();
		}
		private double getNumRounds()
		{
			// only check the first teams in the list
			double total = 0;
			if (MyGame.GameTeam1.Count > 0)
			{
				// which team has the lowest number of robots
				total = Math.Min(MyGame.GameTeam1[0].getNumRobos(false), MyGame.GameTeam2[0].getNumRobos(false)) * MyGame.GameTeams[0].getMaxRobos;
			}
			// if (total > 20) total = 20;
			total = total / (MyGame.CurrentInterval / 1000.0);
			if (total == 0) total = 1;
			return total; 
		}
		private void btnArenaLvl_Click(object sender, EventArgs e)
		{
			MyGame.lowestLevelUp();
			update();
		}

		private void btnMonsterDen_Click(object sender, EventArgs e)
		{
			if (MyGame.getGameCurrency > MyGame.getShopStockCost && MyGame.getShopStock > MyGame.storeEquipment.Count)
			{
				MyGame.AddStock();
			}
			if (MyGame.ConcessionStands != null && MyGame.getGameCurrency > MyGame.ConcessionStands[0].RestockCost && MyGame.ConcessionStands[0].CurrentStock == 0)
			{
				MyGame.AddConcession();
			}
			update();
		}
		private void btnExport_ButtonClick(object sender, EventArgs e)
		{
		}
		private void mnuExport_Click(object sender, EventArgs e)
		{
		}

		private void mnuImport_Click(object sender, EventArgs e)
		{
		}

		private void mnuAutobattle_Click(object sender, EventArgs e)
		{
			pause();
			PauseTimer = 0;
			MyGame.GameDifficultyFightPaused = false;
		}

		private void mnuResetAuto_Click(object sender, EventArgs e)
		{
			MyGame.resetAuto();
		}

		private void pauseResumeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			pause();
		}

		private void pause()
		{
			saveGame();
			MyGame.roundCount = 0;
			if (DateTime.Now > MyGame.BreakTime)
			{
				MyGame.BreakTime = DateTime.Now.AddMinutes(55);
				MyGame.paused = false;
				timer1.Enabled = true;
				btnAutomatic.BackColor = Color.White;
				if (DateTime.Now > MyGame.SafeTime)
					MyGame.SafeTime = DateTime.Now.AddMinutes(20);
			}
			else if (timer1.Enabled)
			{
				MyGame.paused = true;
				timer1.Enabled = false;
				btnAutomatic.BackColor = Color.Red;
			}
			else
			{
				MyGame.paused = false;
				timer1.Enabled = true;
				btnAutomatic.BackColor = Color.White;
				if (DateTime.Now > MyGame.SafeTime)
					MyGame.SafeTime = DateTime.Now.AddMinutes(20);
			}
			Random rnd = new Random();
			if (MyGame.getGameCurrency < 0 && rnd.Next(1000) > 990)
			{
				MyGame.ManagerHrs++;
				MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "up");
			}
			StandbyCountdown = 0; // reset standby timer
		}
		private void levelUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.ShopLevelUp();
			update();
		}
		private void btnShop_ButtonClick(object sender, EventArgs e)
		{
			if (MyGame.getGameCurrency > MyGame.getShopStockCost && MyGame.getShopStock > MyGame.storeEquipment.Count)
			{
				MyGame.AddStock();
			}
			update();
		}

		private void btnAutomatic_ButtonClick(object sender, EventArgs e)
		{
			BreakTimer.Interval = 1000;
			tickRate = 1000 - MyGame.getResearchDevLvl;
			#if DEBUG
				BreakTimer.Interval = 50; ; //speed up for testing
			#endif
			pause();
			// Ensure we don't automatically pause again
			PauseTimer = 0;
			MyGame.GameDifficultyFightPaused = false;
			saveGame(true);
			cbTeamSelect.Items.Clear();
			cbTeamSelect.Items.Add("Stats");
			foreach (Team eTeam in MyGame.GameTeams)
			{
				cbTeamSelect.Items.Add(eTeam.getName);
			}
			cbTeamSelect.SelectedIndex = 0;
		}

		private void mnuShowStats_Click(object sender, EventArgs e)
		{
			MyGame.setAuto();
			foreach (Team eTeam in MyGame.GameTeam1)
				eTeam.clean();
			foreach (Team eTeam in MyGame.GameTeam2)
				eTeam.clean();
			update();
		}

		private void mnuRestockShop_Click(object sender, EventArgs e)
		{
			MyGame.AddStock();
			update();
		}

		private void cboSaveCredits_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cboSaveCredits.Text == "Yes")
				MyGame.PurchaseUpgrade = true;
			else
				MyGame.PurchaseUpgrade = false;
		}

		private void cboRepairPercent_SelectedIndexChanged(object sender, EventArgs e)
		{
			MyGame.repairPercent = double.Parse(cboRepairPercent.Text);
		}

		private void btnResearchDev_Click(object sender, EventArgs e)
		{
			MyGame.ResearchDevLevelUp();
			update();
		}

		private void mnuLongBattle_Click(object sender, EventArgs e)
		{

			// recover unused hours
			if ((MyGame.SafeTime - DateTime.Now).TotalHours >= 1)
			{
				returnToWork();
			}
			else if (MyGame.ManagerHrs > 0)
			{
				MyGame.SafeTime = DateTime.Now.AddHours(MyGame.ManagerHrs);
				MyGame.ManagerHrs = 0;
				MyGame.ManagerCost = MyGame.ManagerCostBaseIncrement;
				MyGame.ManagerCostBase = MyGame.ManagerCostBaseIncrement;
				MyGame.FastForward = false;
			}
			update();
		}

		private void mnuLunch_Click(object sender, EventArgs e)
		{
			if (MyGame.ManagerHrs > 0)
			{
				MyGame.SafeTime = DateTime.Now.AddHours(1);
				MyGame.ManagerHrs--;
				MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "down");
			}
			update();
		}

		private void mnuWork_Click(object sender, EventArgs e)
		{}

		private void returnToWork()
		{ 
			// recover unused hours
			//if ((MyGame.SafeTime - DateTime.Now).TotalHours >= 1)
			//{
				int hrs = (int)(MyGame.SafeTime - DateTime.Now).TotalHours;
				while (hrs > 0)
				{
					MyGame.ManagerHrs++;
					MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "up");
					MyGame.ManagerCostBase = MyGame.ManagerCostBase + MyGame.ManagerCostBaseIncrement;
					hrs--;
				}
			//}
			MyGame.SafeTime = DateTime.Now.AddMinutes(20);
			MyGame.BreakTime = DateTime.Now.AddMinutes(55);
		}

		private void btnPurchaseManager_Click(object sender, EventArgs e)
		{
			MyGame.AddManagerHours();
		}
		public void setColour()
		{
			int hrs = (int)(MyGame.SafeTime - DateTime.Now).TotalHours;
			if (DateTime.Now > MyGame.BreakTime && breakTimerOn)
				btnAutomatic.BackColor = Color.Purple;
			else if (MyGame.SafeTime <= DateTime.Now || !timer1.Enabled)
				btnAutomatic.BackColor = Color.Red;
			else if (MyGame.getGameCurrency >= MyGame.ManagerCost && MyGame.maxManagerHours > MyGame.ManagerHrs && hrs < 1)
				btnAutomatic.BackColor = Color.Gold;
			else
				btnAutomatic.BackColor = Color.White;
		}
		private void BreakTimer_Tick(object sender, EventArgs e)
		{
			setColour();
			if (MyGame.FastForward)
				BreakTimer.Interval = 5;
			else
				BreakTimer.Interval = tickRate;
			Random tmp = new Random();
			if (DateTime.Now > MyGame.BreakTime && breakTimerOn)
			{
				btnAutomatic.BackColor = Color.Purple;
				foreach (Control eControl in MainPannel.Controls)
				{
					eControl.Dispose();
				}
				MainPannel.Controls.Clear();
				MainPannel.Controls.Add(MyGame.showCountdown());
			}


			MyGame.equip();

			// don't heal if Arena fight is on
			if ((MyGame.GameTeam1.Count == 0 || !MyGame.GameTeam1[0].getName.Equals("Arena")))
			{
				Color tmpColour = Color.Yellow;
				if (MyGame.Repair())
					tmpColour = Color.White;
				if (MyGame.isFighting() && tmp.Next(MyGame.fightPercentMax) > MyGame.fightPercent) 
					MyGame.startFight();
				if (!MyGame.isFighting())
					btnFight.BackColor = tmpColour;
			}
			if (tmp.Next(100) > 90 && DateTime.Now > MyGame.SafeTime)
			{

#if DEBUG
				StandbyCountdown = 0; // do not suspend in debug mode
#endif
				if (StandbyCountdown++ > 250 && !MyGame.FastForward)
				{
					Application.SetSuspendState(PowerState.Suspend, true, false);// Standby
					StandbyCountdown = 0;
				}
			}
			// check if difficulty fight has begun and needs to be paused
			if (MyGame.GameDifficultyFightPaused)
			{
				// pause for 10000 cycles
				if (!MyGame.paused) { pause(); }
				PauseTimer++;
				// after 10000 cycles, continue
				if (PauseTimer > 15000) 
				{
					// Unpause
					pause();
					PauseTimer = 0;
					MyGame.GameDifficultyFightPaused = false;
				}
			}
			saveGame();
		}

		private void mnuBossFight_Click(object sender, EventArgs e)
		{
			MyGame.bossFight = true;
		}

		private void countdownToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}
		public void saveGame(bool saveNow)
		{
			saveTime = DateTime.Now.AddHours(-1);
		}
		public void saveGame()
		{
			if (saveTime < DateTime.Now)
			{
				saveTime = DateTime.Now.AddHours(1);
				try
				{
					BinarySerialization.WriteToBinaryFile<Game>("data\\TrainingProject.bin", MyGame);
					// 3% chance to create a separate daily save file
					if (Game.RndVal.Next(100) < 3)
					{
						string name = DateTime.Now.ToString("yyyyMMdd") + "_TrainingProject.bin";
						BinarySerialization.WriteToBinaryFile<Game>("data\\" + name, MyGame);
						this.Text = "Training Program - " + name;
					}
				}
				catch { MyGame.getWarningLog = "\nSave Failed!!!!"; }
			}
		}

		private void difficultyFightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.GameDifficultyFight = true;
		}

		private void txtMaxManagerHrs_TextChanged(object sender, EventArgs e)
		{
			int hrs = 10;
			if (int.TryParse(txtMaxManagerHrs.Text, out hrs))
				MyGame.maxManagerHours = hrs;
			else
				txtMaxManagerHrs.Text = MyGame.maxManagerHours.ToString();
		}

		private void increaseJackpotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotMovement++;
			MyGame.JackpotUpDown = true;
		}

        private void decreaseJackpotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotMovement--;
			MyGame.JackpotUpDown = true;
		}

        private void increaseJackpot10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotMovement += 10;
			MyGame.JackpotUpDown = true;
		}

		private void decreaseJackpot10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotMovement -= 10;
			MyGame.JackpotUpDown = true;
		}

		private void MinJackpotLevel_TextChanged(object sender, EventArgs e)
		{
			int lvl = 1;
			if (int.TryParse(MinJackpotLevel.Text, out lvl))
				MyGame.MinWage = lvl;
			else
				MinJackpotLevel.Text = MyGame.MinWage.ToString();
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (breakTimerOn)
			{
				BreakTimersOff.Text = "Break Timer Off";
				breakTimerOn = false;
			}
			else
			{
				BreakTimersOff.Text = "Break Timer On";
				breakTimerOn = true;
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			// Pause / resume
			if (e.KeyCode == Keys.Space) btnAutomatic.PerformButtonClick();
			// Fight
			else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Add || e.KeyCode == Keys.Z) btnFight.PerformClick();
			// Select Team
			else if (e.KeyCode == Keys.Q) cbTeamSelect.Focus();
			// Add Team
			else if (e.KeyCode == Keys.W) btnAddTeam.PerformClick();
			// Add Robo
			else if (e.KeyCode == Keys.E) btnAddRobo.PerformClick();
			// Shop restock
			else if (e.KeyCode == Keys.R) btnShop.PerformClick();
			/*
			// Arena
			else if (e.KeyCode == Keys.A) btnArenaLvl.PerformClick();
			// Shop
			else if (e.KeyCode == Keys.S) btnShop.PerformButtonClick();
			// R&D
			else if (e.KeyCode == Keys.D) btnResearchDev.PerformClick();
			// Den
			else if (e.KeyCode == Keys.F) btnMonsterDen.PerformClick();
			*/
			// Lowest Level
			else if (e.KeyCode == Keys.L) MyGame.lowestLevelUp();
			// Jackpot +
			else if (e.KeyCode == Keys.J) increaseJackpotToolStripMenuItem.PerformClick();
			// Jackpot +10
			else if (e.KeyCode == Keys.K) increaseJackpot10ToolStripMenuItem.PerformClick();
			// Clear Messages
			else if (e.KeyCode == Keys.C) MyGame.clearWarnings();
			else if (e.KeyCode == Keys.M) mouseButtons();
			// show message box with available shortcuts if not a windows special key
			else if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.OemBackslash)
				MessageBox.Show("Shortcuts " + e.KeyCode +
				"\nPause:               Space" +
				"\nFight:                Enter / +" +
				"\nTeam:                 Q" +
				"\nAdd Team:         W" +
				"\nAdd Robo:         E" +
				/*"\nArena Lvl:           A" +
				"\nShop Lvl:            S" +
				"\nR&D Lvl:             D" +
				"\nDen Lvl:              F" +*/
				"\nLowest Lvl:         L" +
				"\nrestock:            R" +
				"\nJackpot+:           J" +
				"\nJackpt+10:         K" +
				"\nClear Warning: C");
		}

		private void fastForwardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.FastForward = !MyGame.FastForward;
		}

		private void invest10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= MyGame.getArenaLvlCost;
			MyGame.arenaComunityOutreach();
		}

		private void mnuInvest10000_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= 10000;
			MyGame.arenaComunityOutreach(10);
		}

		private void mnuInvest100000_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= 100000;
			MyGame.arenaComunityOutreach(100);
		}

		private void mnuInvest1000000_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= 1000000;
			MyGame.arenaComunityOutreach(1000);
		}

		private void mnuPriority_Click(object sender, EventArgs e) { }

		private void mnuPriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (mnuPriority.SelectedIndex == 1) MyGame.RobotPriority = true;
			else MyGame.RobotPriority = false;
		}

		private void mnuComunityOutreach_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= MyGame.getArenaLvlCost;
			MyGame.arenaComunityOutreach();
		}

		private void fixToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.fixTech();
		}

		private void btnAdvertising_Click(object sender, EventArgs e)
		{
			MyGame.getGameCurrency -= MyGame.getArenaLvlCost;
			MyGame.arenaComunityOutreach();
		}

		private void toolStripLabel2_Click(object sender, EventArgs e)
		{
			mouseButtons();
		}
		public void mouseButtons()
		{
			SwapMouseButton(mouseButton++);
			lblMouse.Text = "Right";
			if (mouseButton > 1)
			{
				mouseButton = 0;
				lblMouse.Text = "Left";
			}
		}
	}
	public static class BinarySerialization
	{
		/// <summary>
		/// Writes the given object instance to a binary file.
		/// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
		/// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
		/// </summary>
		/// <typeparam name="T">The type of object being written to the XML file.</typeparam>
		/// <param name="filePath">The file path to write the object instance to.</param>
		/// <param name="objectToWrite">The object instance to write to the XML file.</param>
		/// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
		public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
		{
			using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}
		}

		/// <summary>
		/// Reads an object instance from a binary file.
		/// </summary>
		/// <typeparam name="T">The type of object to read from the XML.</typeparam>
		/// <param name="filePath">The file path to read the object instance from.</param>
		/// <returns>Returns a new instance of the object read from the binary file.</returns>
		public static T ReadFromBinaryFile<T>(string filePath)
		{
			using (Stream stream = File.Open(filePath, FileMode.Open))
			{
				var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				stream.Position = 0;
				return (T)binaryFormatter.Deserialize(stream);
			}
		}
	}
}
