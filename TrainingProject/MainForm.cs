using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingProject;

namespace TrainingApp
{
	public partial class MainForm : Form
	{
		private Game MyGame;
		private int shownCount;
		private int maxCount = 1000;
		private int tickRate = 1000;
		private int counter;
		private Boolean breakTimerOn = true;
		private DateTime saveTime;
		public MainForm()
		{
			try
			{
				MyGame = BinarySerialization.ReadFromBinaryFile<Game>("data\\TrainingProject.bin");
				MyGame.fixTech();
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
			MyGame.BreakTime = DateTime.Now.AddMinutes(5); // remove
			saveTime = DateTime.Now.AddHours(1);
			Application.EnableVisualStyles();
			InitializeComponent();
			mnuDisplayJackpot.Text = MyGame.CurrentJackpot.ToString();
			MinJackpotLevel.Text = MyGame.MinJackpotLvl.ToString();
			cboRepairPercent.SelectedItem = MyGame.repairPercent;
			cboSaveCredits.SelectedItem = MyGame.PurchaseUgrade;
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
			if (MyGame.PurchaseUgrade)
				cboSaveCredits.SelectedItem = "Yes";
			else
				cboSaveCredits.SelectedItem = "No";
			cboRepairPercent.SelectedItem = MyGame.repairPercent.ToString();
			update();
		}
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
				int hrs = (int)(MyGame.SafeTime - DateTime.Now).TotalHours;
				if (Game.RndVal.Next(MyGame.ManagerHrs) < 1 && hrs < 1)
				{
					MyGame.ManagerHrs++;
					MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "up");
				}
				MyGame.startFight();
				update();
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
				MyGame.interval(timer1);
				#if DEBUG
					timer1.Interval = 50; //speed up for testing
				#endif
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
			Image addTeamImage = new Bitmap(@"AddTeam.png");
			Boolean addRobo = false;
			Boolean arenaLvl = false;
			Boolean monsterLvl = false;
			Boolean shopLvl = false;
			Boolean shopRestock = false;
			Color shopColour = Color.White;
			Boolean researchLvl = false;
			if (MyGame.getAvailableTeams > 0 && MyGame.getTeamCost < MyGame.getGameCurrency)
				addTeam = true;
			if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getAvailableRobo > 0
					&& MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency > MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost)
				addRobo = true;
			if (MyGame.getGameCurrency >= MyGame.getArenaLvlCost)
				arenaLvl = true;
			if (MyGame.getGameCurrency >= MyGame.getMonsterDenLvlCost)
				monsterLvl = true;
			// enough money to upgrade or re-stock
			if (MyGame.getGameCurrency >= MyGame.getShopStockCost && MyGame.getShopStock > MyGame.storeEquipment.Count)
			{
				shopRestock = true;
				shopColour = Color.Green;
			}
			if (MyGame.getGameCurrency >= MyGame.getShopLvlCost)
			{
				shopLvl = true;
			}
			if (MyGame.getGameCurrency >= MyGame.getResearchDevLvlCost)
				researchLvl = true;

			btnAddTeam.Enabled = addTeam;
			btnAddTeam.Image = addTeamImage;
			btnAddRobo.Enabled = addRobo;
			btnArenaLvl.Enabled = arenaLvl;
			btnMonsterDen.Enabled = monsterLvl;
			btnShop.Enabled = shopLvl || shopRestock;
			btnShop.BackColor = shopColour;
			mnuShopLevelUp.Enabled = shopLvl;
			mnuRestockShop.Enabled = shopRestock;
			btnResearchDev.Enabled = researchLvl;
			mnuLongBattle.Text = String.Format("Long Battle {0}hrs \n{1:c0}", MyGame.ManagerHrs, MyGame.ManagerCost);
			// if fight is active
			if (MyGame.isFighting())
			{
				btnFight.BackColor = Color.Red;
				if ((shownCount++ >= (getNumRobos() * MyGame.getMaxTeamsAutomated()) / 2 || !MyGame.isAuto() || MyGame.GameTeam1[0].shownDefeated) && (DateTime.Now < MyGame.BreakTime || !breakTimerOn))
				{
					foreach (Control eControl in MainPannel.Controls)
						eControl.Dispose();
					MainPannel.Controls.Clear();
					MainPannel.Controls.Add(MyGame.continueFight(true));
					shownCount = 0;
					MyGame.resetShowDefeated();
				}
				else
				{
					MyGame.continueFight(false);
				}
				if (!MyGame.isFighting())
					shownCount = maxCount;
			}
			else
			{
				// five percent chance to start a new fight 
				if (Game.RndVal.Next(100) > MyGame.FightBreak)
				{
					MyGame.startFight();
					shownCount = maxCount;
				}
				else
				{
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
			mnuDisplayJackpot.Text = String.Format("Jackpot L:{0:n0}-{1:c0}",MyGame.CurrentJackpotLvl, MyGame.CurrentJackpot);
			MinJackpotLevel.Text = MyGame.MinJackpotLvl.ToString();
			cboRepairPercent.SelectedItem = MyGame.repairPercent;
			cboSaveCredits.SelectedItem = MyGame.PurchaseUgrade;
			txtMaxManagerHrs.Text = MyGame.maxManagerHours.ToString();
		}
		private int getNumRobos()
		{
			// only check the first teams in the list
			int total = 0;
			total += MyGame.GameTeam1[0].getNumRobos(false);
			total += MyGame.GameTeam2[0].getNumRobos(false);
			if (total > 20) total = 20;
			return total;
		}
		private void btnArenaLvl_Click(object sender, EventArgs e)
		{
			MyGame.arenaLevelUp();
			update();
		}

		private void btnMonsterDen_Click(object sender, EventArgs e)
		{
			MyGame.MonsterDenLevelUp();
			update();
		}

		private void btnExport_ButtonClick(object sender, EventArgs e)
		{
			WriteJSON();
		}

		private void mnuExport_Click(object sender, EventArgs e)
		{
			WriteJSON();
		}

		private void mnuImport_Click(object sender, EventArgs e)
		{
			ReadJSON();
		}
		public void WriteJSON()
		{
			var JSON = JsonConvert.SerializeObject(MyGame, Formatting.Indented);
			string name = counter.ToString() + "_TrainingProject.json";
			System.IO.File.WriteAllText("data\\" + name , JSON);
			this.Text = "Training Program - " + name;
			counter++;
		}
		public void ReadCountdownJSON()
		{
			using (StreamReader file = File.OpenText("data\\countdown.json"))
			{
				JsonSerializer serializer = new JsonSerializer();
				JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(file));
				MyGame.countdown = new List<KeyValuePair<String, DateTime>>();
				// get variables for the countdown
				for (int i = 0; i < json["countdown"].Count(); i++)
				{
					// get variables for seating
					string jKey = json["countdown"][i]["Key"] != null ? (string)json["countdown"][i]["Key"] : "NA";
					DateTime jValue = json["countdown"][i]["Value"] != null ? (DateTime)json["countdown"][i]["Value"] : new DateTime(DateTime.Today.Year, 1, 1);
					// add to seating list
					MyGame.countdown.Add(new KeyValuePair<string, DateTime>(jKey, new DateTime(DateTime.Today.Year, jValue.Month, jValue.Day)));
				}
			}
		}
		public void ReadJSON()
		{
			OpenFileDialog Open = new OpenFileDialog();
			Open.ShowDialog();
			using (StreamReader file = File.OpenText(Open.FileName))
			{
				JsonSerializer serializer = new JsonSerializer();
				JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(file));
				// get variables for the game
				int jGoalGameScore = json["GoalGameScore"] != null ? (int)json["GoalGameScore"] : 20;
				int jGoalGameScoreBase = json["GoalGameScoreBase"] != null ? (int)json["GoalGameScoreBase"] : 10;
				int jMaxTeams = json["MaxTeams"] != null ? (int)json["MaxTeams"] : 2;
				long jTeamCost = json["TeamCost"] != null ? (long)json["TeamCost"] : 2000;
				long jTeamCostBase = json["TeamCostBase"] != null ? (long)json["TeamCostBase"] : 1000;
				long jGameCurrency = json["GameCurrency"] != null ? (long)json["GameCurrency"] : 0;
				int jArenaLvl = json["ArenaLvl"] != null ? (int)json["ArenaLvl"] : 1;
				long jArenaLvlCost = json["ArenaLvlCost"] != null ? (long)json["ArenaLvlCost"] : 2000;
				long jArenaLvlCostBase = json["ArenaLvlCostBase"] != null ? (long)json["ArenaLvlCostBase"] : 1000;
				long jArenaMaint = json["ArenaLvlMaint"] != null ? (long)json["ArenaLvlMaint"] : 1;
				int jMonsterDenLvl = json["MonsterDenLvl"] != null ? (int)json["MonsterDenLvl"] : 1;
				long jMonsterDenLvlCost = json["MonsterDenLvlCost"] != null ? (long)json["MonsterDenLvlCost"] : 2000;
				long jMonsterDenLvlCostBase = json["MonsterDenLvlCostBase"] != null ? (long)json["MonsterDenLvlCostBase"] : 1000;
				long jMonsterDenMaint = json["MonsterDenLvlMaint"] != null ? (long)json["MonsterDenLvlMaint"] : 1;
				int jMonsterDenBonus = json["MonsterDenBonus"] != null ? (int)json["MonsterDenBonus"] : 20;
				int jMonsterDenRepair = json["MonsterDenRepair"] != null ? (int)json["MonsterDenRepair"] : 200;
				int jMonsterDenRepairBase = json["MonsterDenRepairBase"] != null ? (int)json["MonsterDenRepairBase"] : 100;
				int jShopLvl = json["ShopLvl"] != null ? (int)json["ShopLvl"] : 1;
				long jShopLvlCost = json["ShopLvlCost"] != null ? (long)json["ShopLvlCost"] : 2000;
				long jShopLvlCostBase = json["ShopLvlCostBase"] != null ? (long)json["ShopLvlCostBase"] : 1000;
				long jShopMaint = json["ShopLvlMaint"] != null ? (long)json["ShopLvlMaint"] : 1;
				int jShopStock = json["ShopStock"] != null ? (int)json["ShopStock"] : 1;
				int jShopStockCost = json["ShopStockCost"] != null ? (int)json["ShopStockCost"] : 12;
				int jShopMaxStat = json["ShopMaxStat"] != null ? (int)json["ShopMaxStat"] : 5;
				int jShopMaxDur = json["ShopMaxDurability"] != null ? (int)json["ShopMaxDurability"] : 100;
				int jShopUpValue = json["ShopUpgradeValue"] != null ? (int)json["ShopUpgradeValue"] : 1;
				int jResearchDevLvl = json["ResearchDevLvl"] != null ? (int)json["ResearchDevLvl"] : 1;
				long jResearchDevLvlCost = json["ResearchDevLvlCost"] != null ? (long)json["ResearchDevLvlCost"] : 2000;
				long jResearchDevLvlCostBase = json["ResearchDevLvlCostBase"] != null ? (long)json["ResearchDevLvlCostBase"] : 1000;
				long jResearchDevMaint = json["ResearchDevMaint"] != null ? (long)json["ResearchDevMaint"] : 1;
				int jResearchDevHealValue = json["ResearchDevHealValue"] != null ? (int)json["ResearchDevHealValue"] : 2;
				int jResearchDevHealValueBase = json["ResearchDevHealValueBase"] != null ? (int)json["ResearchDevHealValueBase"] : 1;
				int jResearchDevHealBays = json["ResearchDevHealBays"] != null ? (int)json["ResearchDevHealBays"] : 1;
				int jResearchDevHealCost = json["ResearchDevHealCost"] != null ? (int)json["ResearchDevHealCost"] : 1;
				long jResearchDevRebuild = json["ResearchDevRebuild"] != null ? (long)json["ResearchDevRebuild"] : 1000;
				long jResearchDevRebuildBase = json["ResearchDevRebuildBase"] != null ? (long)json["ResearchDevRebuildBase"] : 500;
				int jBossLvl = json["BossLvl"] != null ? (int)json["BossLvl"] : 5;
				int jBossLvlBase = json["BossLvlBase"] != null ? (int)json["BossLvlBase"] : 5;
				int jBossCount = json["BossCount"] != null ? (int)json["BossCount"] : 1;
				int jBossDifficulty = json["BossDifficulty"] != null ? (int)json["BossDifficulty"] : 4;
				int jBossDifficultyBase = json["BossDifficultyBase"] != null ? (int)json["BossDifficultyBase"] : 2;
				int jGameDifficulty = json["gameDifficulty"] != null ? (int)json["gameDifficulty"] : 1;
				int jBossReward = json["BossReward"] != null ? (int)json["BossReward"] : 1000;
				// Parse json and assign to MyGame
				MyGame = new Game(jGoalGameScore, jGoalGameScoreBase, jMaxTeams, jTeamCost, jTeamCostBase, jGameCurrency, jArenaLvl, jArenaLvlCost, jArenaLvlCostBase, jArenaMaint, 
					jMonsterDenLvl, jMonsterDenLvlCost, jMonsterDenLvlCostBase, jMonsterDenMaint, jMonsterDenBonus, jMonsterDenRepair, jMonsterDenRepairBase, 
					jShopLvl, jShopLvlCost, jShopLvlCostBase, jShopMaint, jShopStock, jShopStockCost, jShopMaxStat, jShopMaxDur, jShopUpValue, 
					jResearchDevLvl, jResearchDevLvlCost, jResearchDevLvlCostBase, jResearchDevMaint, jResearchDevHealValue, jResearchDevHealValueBase, jResearchDevHealBays, 
					jResearchDevHealCost, jResearchDevRebuild, jResearchDevRebuildBase, jBossLvl, jBossLvlBase, jBossCount, jBossDifficulty, jBossDifficultyBase, jBossReward, jGameDifficulty);
				for (int seatingIndex = 0; seatingIndex < json["Seating"].Count(); seatingIndex++)
				{
					// get variables for seating
					int jSeatingLevel = json["Seating"][seatingIndex]["Level"] != null ? (int)json["Seating"][seatingIndex]["Level"] : 1;
					int jSeatingPrice = json["Seating"][seatingIndex]["Price"] != null ? (int)json["Seating"][seatingIndex]["Price"] : 1;
					int jSeatingAmount = json["Seating"][seatingIndex]["Amount"] != null ? (int)json["Seating"][seatingIndex]["Amount"] : 5;
					int jSeatingAmountBase = json["Seating"][seatingIndex]["AmountBase"] != null ? (int)json["Seating"][seatingIndex]["AmountBase"] : 1;
					// add to seating list
					MyGame.Seating.Add(new ArenaSeating(jSeatingLevel, jSeatingPrice, jSeatingAmount, jSeatingAmountBase));
				}
				// Loop through stock
				for (int StoreStockIndex = 0; StoreStockIndex < json["storeEquipment"].Count(); StoreStockIndex++)
				{
					// get variables for Stock
					string jStoreEquipType = json["storeEquipment"][StoreStockIndex]["eType"] != null ? (string)json["storeEquipment"][StoreStockIndex]["eType"] : "";
					string jStoreEquipName = json["storeEquipment"][StoreStockIndex]["eName"] != null ? (string)json["storeEquipment"][StoreStockIndex]["eName"] : "";
					int jStoreEquipHealth = json["storeEquipment"][StoreStockIndex]["eHealth"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eHealth"] : 0;
					int jStoreEquipEnergy = json["storeEquipment"][StoreStockIndex]["eEnergy"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eEnergy"] : 0;
					int jStoreEquipArmour = json["storeEquipment"][StoreStockIndex]["eArmour"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eArmour"] : 0;
					int jStoreEquipDamage = json["storeEquipment"][StoreStockIndex]["eDamage"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eDamage"] : 0;
					int jStoreEquipHit = json["storeEquipment"][StoreStockIndex]["eHit"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eHit"] : 0;
					int jStoreEquipMStr = json["storeEquipment"][StoreStockIndex]["eMentalStrength"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eMentalStrength"] : 0;
					int jStoreEquipMDef = json["storeEquipment"][StoreStockIndex]["eMentalDefense"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eMentalDefense"] : 0;
					int jStoreEquipSpeed = json["storeEquipment"][StoreStockIndex]["eSpeed"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eSpeed"] : 0;
					int jStoreEquipPrice = json["storeEquipment"][StoreStockIndex]["ePrice"] != null ? (int)json["storeEquipment"][StoreStockIndex]["ePrice"] : 0;
					int jStoreEquipDur = json["storeEquipment"][StoreStockIndex]["eDurability"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eDurability"] : 0;
					int jStoreEquipMDur = json["storeEquipment"][StoreStockIndex]["eMaxDurability"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eMaxDurability"] : 0;
					int jStoreEquipUCost = json["storeEquipment"][StoreStockIndex]["eUpgradeCost"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eUpgradeCost"] : 0;
					int jStoreEquipUCostBase = json["storeEquipment"][StoreStockIndex]["eUpgradeCostBase"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eUpgradeCostBase"] : 0;
					int jStoreEquipUCostBaseIncrement = json["storeEquipment"][StoreStockIndex]["eUpgradeCostBaseIncrement"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eUpgradeCostBaseIncrement"] : 0;
					int jStoreEquipUpgrade = json["storeEquipment"][StoreStockIndex]["eUpgrade"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eUpgrade"] : 0;
					// add stock
					MyGame.storeEquipment.Add(
						new Equipment(jStoreEquipType, jStoreEquipName, jStoreEquipHealth, jStoreEquipEnergy, jStoreEquipArmour, jStoreEquipDamage,
							   jStoreEquipHit, jStoreEquipMStr, jStoreEquipMDef, jStoreEquipSpeed, jStoreEquipPrice, jStoreEquipDur, jStoreEquipMDur,
							   jStoreEquipUCost, jStoreEquipUCostBase, jStoreEquipUCostBaseIncrement, jStoreEquipUpgrade)
					);
				}
				// Loop through teams
				for (int GameTeamIndex = 0; GameTeamIndex < json["GameTeams"].Count(); GameTeamIndex++)
				{
					// get variables for Team
					int jTeamScore = json["GameTeams"][GameTeamIndex]["Score"] != null ? (int)json["GameTeams"][GameTeamIndex]["Score"] : 0;
					int jTeamGoalScore = json["GameTeams"][GameTeamIndex]["GoalScore"] != null ? (int)json["GameTeams"][GameTeamIndex]["GoalScore"] : 20;
					int jTeamGoalScoreBase = json["GameTeams"][GameTeamIndex]["GoalScoreBase"] != null ? (int)json["GameTeams"][GameTeamIndex]["GoalScoreBase"] : 5;
					int jTeamWin = json["GameTeams"][GameTeamIndex]["Win"] != null ? (int)json["GameTeams"][GameTeamIndex]["Win"] : 0;
					long jTeamCurrency = json["GameTeams"][GameTeamIndex]["Currency"] != null ? (long)json["GameTeams"][GameTeamIndex]["Currency"] : 0;
					int jTeamDiff = json["GameTeams"][GameTeamIndex]["Difficulty"] != null ? (int)json["GameTeams"][GameTeamIndex]["Difficulty"] : 0;
					int jTeamMaxRobot = json["GameTeams"][GameTeamIndex]["MaxRobo"] != null ? (int)json["GameTeams"][GameTeamIndex]["MaxRobo"] : 0;
					long jTeamRobotCost = json["GameTeams"][GameTeamIndex]["RoboCost"] != null ? (long)json["GameTeams"][GameTeamIndex]["RoboCost"] : 0;
					long jTeamRobotCostBase = json["GameTeams"][GameTeamIndex]["RoboCostBase"] != null ? (long)json["GameTeams"][GameTeamIndex]["RoboCostBase"] : 0;
					string jTeamName = json["GameTeams"][GameTeamIndex]["TeamName"] != null ? (string)json["GameTeams"][GameTeamIndex]["TeamName"] : "";
					bool jTeamAutomated = json["GameTeams"][GameTeamIndex]["Automated"] != null ? (bool)json["GameTeams"][GameTeamIndex]["Automated"] : false;
					// get variables for seating
					MyGame.GameTeams.Add(new Team(jTeamScore, jTeamGoalScore, jTeamGoalScoreBase, jTeamWin, jTeamCurrency, jTeamDiff, jTeamMaxRobot, jTeamRobotCost, jTeamRobotCostBase, 
						jTeamName, jTeamAutomated));
					// Loop through robots
					for (int RobotIndex = 0; RobotIndex < json["GameTeams"][GameTeamIndex]["MyTeam"].Count(); RobotIndex++)
					{
						// get variables for robot
						string jRoboName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RobotName"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RobotName"] : "";
						int jRoboDex = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Dexterity"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Dexterity"] : 1;
						int jRoboStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Strength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Strength"] : 1;
						int jRoboAgi = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Agility"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Agility"] : 1;
						int jRoboTec = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Tech"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Tech"] : 1;
						int jRoboAcc = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Accuracy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Accuracy"] : 1;
						int jRoboHea = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Health"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Health"] : 1;
						int jRoboEnr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Energy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Energy"] : 1;
						int jRoboArm = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Armour"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Armour"] : 1;
						int jRoboDam = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Damage"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Damage"] : 1;
						int jRoboHit = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Hit"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Hit"] : 1;
						int jRoboMstr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalStrength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalStrength"] : 1;
						int jRoboMDef = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalDefense"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalDefense"] : 1;
						string jRoboImg = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Image"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Image"] : "";
						int jRoboSpd = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Speed"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Speed"] : 1;
						int jRoboLvl = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Level"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Level"] : 1;
						int jRoboAnl = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Analysis"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Analysis"] : 100;
						int jRoboCurAnl = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["CurrentAnalysis"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["CurrentAnalysis"] : 0;
						int jRoboRebuildCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RebuildCost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RebuildCost"] : 0;
						// add robot
						MyGame.GameTeams[GameTeamIndex].MyTeam.Add(
							new Robot(jRoboName, jRoboDex, jRoboStr, jRoboAgi, jRoboTec, jRoboAcc, jRoboHea, jRoboEnr, jRoboArm, jRoboDam, jRoboHit, jRoboMstr, jRoboMDef, jRoboImg, jRoboSpd, jRoboLvl, 
										jRoboAnl, jRoboCurAnl, jRoboRebuildCost)
						);
						// if robot has a weapon
						int jWeaonCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"].Count() : 0;
						if (jWeaonCount > 0)
						{
							// get variables for weapon
							string jWeaponType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eType"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eType"] : "";
							string jWeaponName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eName"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eName"] : "";
							int jWeaponHealth = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eHealth"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eHealth"] : 0;
							int jWeaponEnergy = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eEnergy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eEnergy"] : 0;
							int jWeaponArmour = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eArmour"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eArmour"] : 0;
							int jWeaponDamage = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDamage"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDamage"] : 0;
							int jWeaponHit = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eHit"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eHit"] : 0;
							int jWeaponMStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMentalStrength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMentalStrength"] : 0;
							int jWeaponMDef = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMentalDefense"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMentalDefense"] : 0;
							int jWeaponSpeed = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eSpeed"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eSpeed"] : 0;
							long jWeaponPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["ePrice"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["ePrice"] : 0;
							int jWeaponDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDurability"] : 0;
							int jWeaponMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMaxDurability"] : 0;
							long jWeaponUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCost"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCost"] : 0;
							long jWeaponUCostBase = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCostBase"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCostBase"] : 0;
							long jWeaponUCostBaseIncrement = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCostBaseIncrement"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCostBaseIncrement"] : 0;
							int jWeaponUpgrade = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgrade"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgrade"] : 0;
							// add weapon
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipWeapon = new Equipment(jWeaponType, jWeaponName, jWeaponHealth, jWeaponEnergy, jWeaponArmour,
								jWeaponDamage, jWeaponHit, jWeaponMStr, jWeaponMDef, jWeaponSpeed, jWeaponPrice, jWeaponDur, jWeaponMDur, jWeaponUCost, jWeaponUCostBase, jWeaponUCostBaseIncrement, 
								jWeaponUpgrade);
						}
						// if robot has armour
						int jArmourCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"].Count() : 0;
						if (jArmourCount > 0)
						{
							// get variables for armour
							string jArmourType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eType"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eType"] : "";
							string jArmourName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eName"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eName"] : "";
							int jArmourHealth = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eHealth"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eHealth"] : 0;
							int jArmourEnergy = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eEnergy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eEnergy"] : 0;
							int jArmourArmour = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eArmour"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eArmour"] : 0;
							int jArmourDamage = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDamage"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDamage"] : 0;
							int jArmourHit = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eHit"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eHit"] : 0;
							int jArmourMStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMentalStrength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMentalStrength"] : 0;
							int jArmourMDef = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMentalDefense"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMentalDefense"] : 0;
							int jArmourSpeed = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eSpeed"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eSpeed"] : 0;
							long jArmourPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["ePrice"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["ePrice"] : 0;
							int jArmourDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDurability"] : 0;
							int jArmourMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMaxDurability"] : 0;
							long jArmourUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCost"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCost"] : 0;
							long jArmourUCostBase = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCostBase"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCostBase"] : 0;
							long jArmourUCostBaseIncrement = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCostBaseIncrement"] != null ? (long)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCostBaseIncrement"] : 0;
							int jArmourUpgrade = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgrade"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgrade"] : 0;
							// add armour
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipArmour = new Equipment(jArmourType, jArmourName, jArmourHealth, jArmourEnergy, jArmourArmour,
								jArmourDamage, jArmourHit, jArmourMStr, jArmourMDef, jArmourSpeed, jArmourPrice, jArmourDur, jArmourMDur, jArmourUCost, jArmourUCostBase, 
								jArmourUCostBaseIncrement, jArmourUpgrade);
						}
						int jStrategyCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"].Count() : 0;
						// if skills are present
						if (jStrategyCount > 0)
						{
							// loop through skills
							for (int StrategyIndex = 0; StrategyIndex < jStrategyCount; StrategyIndex++)
							{
								// get skill values
								string jSkillName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["name"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["name"] : "";
								string jSkillTarget = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["target"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["target"] : "";
								int jSkillStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["strength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["strength"] : 0;
								string jSkillType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["type"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["type"] : "";
								int jSKillCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["cost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["cost"] : 0;
								string jSkillImg = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["img"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["img"] : "";
								char jSkillSChar = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["sChar"] != null ? (char)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["StrategicSkill"]["sChar"] : '*';
								// add skill
								MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].ListSkills.Add(new Skill(jSkillName, jSkillTarget, jSkillStr, jSkillType, jSKillCost, jSkillImg, jSkillSChar));
								// Get Strategy values
								string jStratFieldCond = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["FieldCondition"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["FieldCondition"] : "";
								string jStratCond = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Condition"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Condition"] : "";
								int jStratCondValue = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["ConditionValue"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["ConditionValue"] : 0;
								string jStratFocus = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Focus"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Focus"] : "";
								string jStratField = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Field"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][StrategyIndex]["Field"] : "";
								// add skill
								MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].RoboStrategy.Add(new Strategy(MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].ListSkills[MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].ListSkills.Count - 1],
									jStratFieldCond, jStratCond, jStratCondValue, jStratFocus, jStratField));
							}
						}
					}
				}
			}
			cbTeamSelect.Items.Clear();
			cbTeamSelect.Items.Add("Stats");
			foreach (Team eTeam in MyGame.GameTeams)
			{
				cbTeamSelect.Items.Add(eTeam.getName);
			}
			cbTeamSelect.SelectedIndex = 0;
			update();
		}

		private void mnuAutobattle_Click(object sender, EventArgs e)
		{
			pause();
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
			MyGame.roundCount = 0;
			if (DateTime.Now > MyGame.BreakTime)
			{
				MyGame.BreakTime = DateTime.Now.AddMinutes(55);
				btnAutomatic.BackColor = Color.White;
			}
			if (timer1.Enabled)
			{
				timer1.Enabled = false;
				btnAutomatic.BackColor = Color.Red;
			}
			else
			{
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
			else if (MyGame.getGameCurrency > MyGame.getShopLvlCost)
			{
				MyGame.ShopLevelUp();
			}
			update();
		}

		private void btnAutomatic_ButtonClick(object sender, EventArgs e)
		{
			BreakTimer.Interval = 1000;
			tickRate = 1000;
			#if DEBUG
				BreakTimer.Interval = 50; ; //speed up for testing
			#endif
			pause();
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
				MyGame.PurchaseUgrade = true;
			else
				MyGame.PurchaseUgrade = false;
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
			if (MyGame.ManagerHrs > 0)
			{
				MyGame.SafeTime = DateTime.Now.AddHours(MyGame.ManagerHrs);
				MyGame.ManagerHrs = 0;
				MyGame.ManagerCost = MyGame.ManagerCostBaseIncrement;
				MyGame.ManagerCostBase = MyGame.ManagerCostBaseIncrement;
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
		{
			// recover unused hours
			if ((MyGame.SafeTime - DateTime.Now).TotalHours >= 1)
			{
				int hrs = (int)(MyGame.SafeTime - DateTime.Now).TotalHours;
				while (hrs > 0)
				{
					MyGame.ManagerHrs++;
					MyGame.ManagerCost = MyGame.roundValue(MyGame.ManagerCost, MyGame.ManagerCostBase, "up");
					MyGame.ManagerCostBase = MyGame.ManagerCostBase + MyGame.ManagerCostBaseIncrement;
					hrs--;
				}
			}
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
			int fightPercentOffset = 0;
			if (MyGame.GameTeam1 != null && MyGame.GameTeam2 != null && MyGame.GameTeam1.Count > 0 && MyGame.GameTeam1[0].Automated && MyGame.GameTeam2[0].Automated)
			{
				BreakTimer.Interval = tickRate / MyGame.GameTeams.Count;
				fightPercentOffset = MyGame.GameTeams.Count;
			}
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

			if (MyGame.SafeTime < DateTime.Now)
				MyGame.equip();

			// don't heal if Arena fight is on
			if ((MyGame.GameTeam1.Count == 0 || !MyGame.GameTeam1[0].getName.Equals("Arena")))
			{
				Color tmpColour = Color.Yellow;
				if (MyGame.Repair())
					tmpColour = Color.White;
				MyGame.equip();
				if (MyGame.isFighting() && tmp.Next(MyGame.fightPercentMax + fightPercentOffset) > MyGame.fightPercent) 
					MyGame.startFight();
				if (!MyGame.isFighting())
					btnFight.BackColor = tmpColour;
			}
			if (tmp.Next(100) > 90 && DateTime.Now > MyGame.SafeTime)
			{
				MyGame.continueFight(false);
				tickRate++;
			}
			saveGame();
		}

		private void mnuBossFight_Click(object sender, EventArgs e)
		{
			MyGame.bossFight = true;
		}

		private void countdownToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ReadCountdownJSON();
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
					if (Game.RndVal.Next(100) > 3)
					{
						BinarySerialization.WriteToBinaryFile<Game>("data\\TrainingProject.bin", MyGame);
					}
					else
					{
						WriteJSON();
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
			//mnuDisplayJackpot.Text = MyGame.IncreaseJackpot().ToString();
			MyGame.JackpotUp = true;
		}

        private void decreaseJackpotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//mnuDisplayJackpot.Text = MyGame.DecreaseJackpot().ToString();
			MyGame.JackpotDown = true;
		}

        private void increaseJackpot10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotUpTen = true;
		}

		private void decreaseJackpot10ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.JackpotDownTen = true;
		}

		private void MinJackpotLevel_TextChanged(object sender, EventArgs e)
		{
			int lvl = 1;
			if (int.TryParse(MinJackpotLevel.Text, out lvl))
				MyGame.MinJackpotLvl = lvl;
			else
				MinJackpotLevel.Text = MyGame.MinJackpotLvl.ToString();
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
			else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Add) btnFight.PerformClick();
			// Select Team
			else if (e.KeyCode == Keys.Q) cbTeamSelect.Focus();
			// Add Team
			else if (e.KeyCode == Keys.W) btnAddTeam.PerformClick();
			// Add Robo
			else if (e.KeyCode == Keys.E) btnAddRobo.PerformClick();
			// Arena
			else if (e.KeyCode == Keys.A) btnArenaLvl.PerformClick();
			// Shop
			else if (e.KeyCode == Keys.S) btnShop.PerformButtonClick();
			// Shop restock
			else if (e.KeyCode == Keys.R) mnuRestockShop.PerformClick();
			// R&D
			else if (e.KeyCode == Keys.D) btnResearchDev.PerformClick();
			// Den
			else if (e.KeyCode == Keys.F) btnMonsterDen.PerformClick();
			// Lowest Level
			else if (e.KeyCode == Keys.L) MyGame.lowestLevelUp();
			// Jackpot +
			else if (e.KeyCode == Keys.J) increaseJackpotToolStripMenuItem.PerformClick();
			// Jackpot +10
			else if (e.KeyCode == Keys.K) increaseJackpot10ToolStripMenuItem.PerformClick();
			// Clear Messages
			else if (e.KeyCode == Keys.C) MyGame.clearWarnings();
			// show message box with available shortcuts if not a windows special key
			else if (e.KeyCode == Keys.OemQuestion || e.KeyCode == Keys.OemBackslash)
				MessageBox.Show("Shortcuts " + e.KeyCode + 
				"\nPause:               Space" +
				"\nFight:                Enter / +" +
				"\nTeam:                 Q" +
				"\nAdd Team:         W" +
				"\nAdd Robo:         E" +
				"\nArena Lvl:           A" +
				"\nShop Lvl:            S" +
				"\nR&D Lvl:             D" +
				"\nDen Lvl:              F" +
				"\nLowest Lvl:         L" +
				"\nrestock:            R" +
				"\nJackpot+:           J" +
				"\nJackpt+10:         K" +
				"\nClear Warning: C");
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
