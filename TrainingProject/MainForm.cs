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
			Application.EnableVisualStyles();
			InitializeComponent();
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
			MainPannel.Controls.Add(MyGame.showSelectedTeam(cbTeamSelect.SelectedIndex));
			shownCount = maxCount;
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
			if (DateTime.Now > MyGame.BreakTime)
				btnAutomatic.BackColor = Color.Purple;
			else if (MyGame.getGameCurrency >= MyGame.ManagerCost)
				btnAutomatic.BackColor = Color.Gold;
			else
				btnAutomatic.BackColor = Color.White;
			if (MyGame.SafeTime > DateTime.Now)
			{
				update();
				MyGame.interval(timer1);
			}
			else
			{
				timer1.Enabled = false;
				btnAutomatic.BackColor = Color.Red;
			}
		}
		public void update()
		{
			Boolean addTeam = false;
			Boolean addRobo = false;
			Boolean arenaLvl = false;
			Boolean monsterLvl = false;
			Boolean shopLvl = false;
			Boolean shopRestock = false;
			Color shopColour = Color.White;
			Boolean researchLvl = false;
			if (MyGame.getAvailableTeams > 0)
			{
				addTeam = true;
			}
			if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getAvailableRobo > 0
					&& MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency > MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost)
			{
				addRobo = true;
			}
			if (MyGame.getGameCurrency >= MyGame.getArenaLvlCost)
			{
				arenaLvl = true;
			}
			if (MyGame.getGameCurrency >= MyGame.getMonsterDenLvlCost)
			{
				monsterLvl = true;
			}
			// enough money to upgrade or re-stock
			if (MyGame.getGameCurrency >= MyGame.getShopStockCost && MyGame.getShopStock > MyGame.storeEquipment.Count)
			{
				shopRestock = true;
				shopColour = Color.Green;
			}
			if (MyGame.getGameCurrency >= MyGame.getShopLvlCost)
			{
				shopLvl = true;
				shopColour = Color.Blue;
			}
			if (MyGame.getGameCurrency >= MyGame.getResearchDevLvlCost)
			{
				researchLvl = true;
			}

			btnAddTeam.Enabled = addTeam;
			btnAddRobo.Enabled = addRobo;
			btnArenaLvl.Enabled = arenaLvl;
			btnMonsterDen.Enabled = monsterLvl;
			btnShop.Enabled = shopLvl || shopRestock;
			btnShop.BackColor = shopColour;
			mnuShopLevelUp.Enabled = shopLvl;
			mnuRestockShop.Enabled = shopRestock;
			btnResearchDev.Enabled = researchLvl;
			mnuLongBattle.Text = "Long Battle (" + MyGame.ManagerHrs + ")";
			// if fight is active
			if (MyGame.isFighting())
			{
				btnFight.BackColor = Color.Red;
				if (shownCount++ > (MyGame.GameTeam1.getNumRobos() + MyGame.GameTeam2.getNumRobos()) / 2 || !MyGame.isAuto())
				{
					foreach (Control eControl in MainPannel.Controls)
					{
						eControl.Dispose();
					}
					MainPannel.Controls.Clear();
					MainPannel.Controls.Add(MyGame.continueFight(true));
					shownCount = 0;
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
				// Repair robots who fought
				if (MyGame.Repair())
				{
					btnFight.BackColor = Color.White;
				}
				else
				{
					btnFight.BackColor = Color.Yellow;
				}
				// five percent chance to start a new fight 
				if (Game.RndVal.Next(100) > 90)
				{
					MyGame.startFight();
					shownCount = maxCount;
				}
				else
				{
					MyGame.equip();
					if (shownCount++ > 5)
					{
						foreach (Control eControl in MainPannel.Controls)
						{
							eControl.Dispose();
						}
						MainPannel.Controls.Clear();
						MainPannel.Controls.Add(MyGame.showSelectedTeam(cbTeamSelect.SelectedIndex));
						shownCount = 0;
					}
				}
			}
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
			catch { }
			MainPannel.AutoScrollPosition = new Point(0, 0);
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
			//var JSON = new JavaScriptSerializer().Serialize(MyGame);
			var JSON = JsonConvert.SerializeObject(MyGame, Formatting.Indented);
			System.IO.File.WriteAllText("data\\" + DateTime.Now.ToString("yyyyMMdd") + "_" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + "_TrainingProject.JSON", JSON);
		}
		public void ReadJSON()
		{
			OpenFileDialog Open = new OpenFileDialog();
			Open.ShowDialog();
			using (StreamReader file = File.OpenText(Open.FileName))
			{
				JsonSerializer serializer = new JsonSerializer();
				JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(file));
				int jGoalGameScore = json["GoalGameScore"] != null ? (int)json["GoalGameScore"] : 20;
				int jMaxTeams = json["MaxTeams"] != null ? (int)json["MaxTeams"] : 2;
				int jTeamCost = json["TeamCost"] != null ? (int)json["TeamCost"] : 500;
				int jGameCurrency = json["GameCurrency"] != null ? (int)json["GameCurrency"] : 0;
				int jArenaLvl = json["ArenaLvl"] != null ? (int)json["ArenaLvl"] : 1;
				int jArenaLvlCost = json["ArenaLvlCost"] != null ? (int)json["ArenaLvlCost"] : 100;
				int jArenaMaint = json["ArenaLvlMaint"] != null ? (int)json["ArenaLvlMaint"] : 1;
				int jMonsterDenLvl = json["MonsterDenLvl"] != null ? (int)json["MonsterDenLvl"] : 1;
				int jMonsterDenLvlCost = json["MonsterDenLvlCost"] != null ? (int)json["MonsterDenLvlCost"] : 100;
				int jMonsterDenMaint = json["MonsterDenLvlMaint"] != null ? (int)json["MonsterDenLvlMaint"] : 1;
				int jMonsterDenBonus = json["MonsterDenBonus"] != null ? (int)json["MonsterDenBonus"] : 10;
				int jShopLvl = json["ShopLvl"] != null ? (int)json["ShopLvl"] : 1;
				int jShopLvlCost = json["ShopLvlCost"] != null ? (int)json["ShopLvlCost"] : 100;
				int jShopMaint = json["ShopLvlMaint"] != null ? (int)json["ShopLvlMaint"] : 1;
				int jShopStock = json["ShopStock"] != null ? (int)json["ShopStock"] : 1;
				int jShopStockCost = json["ShopStockCost"] != null ? (int)json["ShopStockCost"] : 12;
				int jShopMaxStat = json["ShopMaxStat"] != null ? (int)json["ShopMaxStat"] : 5;
				int jShopMaxDur = json["ShopMaxDurability"] != null ? (int)json["ShopMaxDurability"] : 100;
				int jShopUpValue = json["ShopUpgradeValue"] != null ? (int)json["ShopUpgradeValue"] : 1;
				int jResearchDevLvl = json["ResearchDevLvl"] != null ? (int)json["ResearchDevLvl"] : 1;
				int jResearchDevLvlCost = json["ResearchDevLvlCost"] != null ? (int)json["ResearchDevLvlCost"] : 100;
				int jResearchDevMaint = json["ResearchDevMaint"] != null ? (int)json["ResearchDevMaint"] : 1;
				int jResearchDevHealValue = json["ResearchDevHealValue"] != null ? (int)json["ResearchDevHealValue"] : 2;
				int jResearchDevHealCost = json["ResearchDevHealCost"] != null ? (int)json["ResearchDevHealCost"] : 1;
				// Parse json and assign to MyGame
				MyGame = new Game(jGoalGameScore, jMaxTeams, jTeamCost, jGameCurrency, jArenaLvl, jArenaLvlCost, jArenaMaint, jMonsterDenLvl, jMonsterDenLvlCost, jMonsterDenMaint, jMonsterDenBonus,
					jShopLvl, jShopLvlCost, jShopMaint, jShopStock, jShopStockCost, jShopMaxStat, jShopMaxDur, jShopUpValue, jResearchDevLvl, jResearchDevLvlCost, jResearchDevMaint, jResearchDevHealValue,
					jResearchDevHealCost);
				for (int seatingIndex = 0; seatingIndex < json["Seating"].Count(); seatingIndex++)
				{
					MyGame.Seating.Add(new ArenaSeating((int)json["Seating"][seatingIndex]["Level"], (int)json["Seating"][seatingIndex]["Price"], (int)json["Seating"][seatingIndex]["Amount"]));
				}
				for (int StoreStockIndex = 0; StoreStockIndex < json["storeEquipment"].Count(); StoreStockIndex++)
				{
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
					MyGame.storeEquipment.Add(
						new Equipment(jStoreEquipType, jStoreEquipName, jStoreEquipHealth, jStoreEquipEnergy, jStoreEquipArmour, jStoreEquipDamage,
							   jStoreEquipHit, jStoreEquipMStr, jStoreEquipMDef, jStoreEquipSpeed, jStoreEquipPrice, jStoreEquipDur, jStoreEquipMDur,
							   jStoreEquipUCost)
					);
				}
				for (int GameTeamIndex = 0; GameTeamIndex < json["GameTeams"].Count(); GameTeamIndex++)
				{
					MyGame.GameTeams.Add(
						new Team((int)json["GameTeams"][GameTeamIndex]["Score"], (int)json["GameTeams"][GameTeamIndex]["GoalScore"], (int)json["GameTeams"][GameTeamIndex]["Currency"],
							(int)json["GameTeams"][GameTeamIndex]["Difficulty"], (int)json["GameTeams"][GameTeamIndex]["MaxRobo"], (int)json["GameTeams"][GameTeamIndex]["RoboCost"],
							(string)json["GameTeams"][GameTeamIndex]["TeamName"])
					);
					for (int RobotIndex = 0; RobotIndex < json["GameTeams"][GameTeamIndex]["MyTeam"].Count(); RobotIndex++)
					{
						MyGame.GameTeams[GameTeamIndex].MyTeam.Add(
							new Robot((string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RobotName"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Dexterity"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Strength"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Agility"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Tech"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Accuracy"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Health"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Energy"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Armour"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Damage"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Hit"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalStrength"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["MentalDefense"], (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Image"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Speed"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Level"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["Analysis"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["CurrentAnalysis"])
						);
						int jWeaonCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"].Count() : 0;
						if (jWeaonCount > 0)
						{
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
							int jWeaponPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["ePrice"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["ePrice"] : 0;
							int jWeaponDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eDurability"] : 0;
							int jWeaponMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eMaxDurability"] : 0;
							int jWeaponUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipWeapon"]["eUpgradeCost"] : 0;
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipWeapon = new Equipment(jWeaponType, jWeaponName, jWeaponHealth, jWeaponEnergy, jWeaponArmour,
								jWeaponDamage, jWeaponHit, jWeaponMStr, jWeaponMDef, jWeaponSpeed, jWeaponPrice, jWeaponDur, jWeaponMDur, jWeaponUCost);
						}
						int jArmourCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"].Count() : 0;
						if (jArmourCount > 0)
						{
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
							int jArmourPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["ePrice"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["ePrice"] : 0;
							int jArmourDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eDurability"] : 0;
							int jArmourMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eMaxDurability"] : 0;
							int jArmourUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["EquipArmour"]["eUpgradeCost"] : 0;
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipArmour = new Equipment(jArmourType, jArmourName, jArmourHealth, jArmourEnergy, jArmourArmour,
								jArmourDamage, jArmourHit, jArmourMStr, jArmourMDef, jArmourSpeed, jArmourPrice, jArmourDur, jArmourMDur, jArmourUCost);
						}
						int jSkillCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"].Count() : 0;
						if (jSkillCount > 0)
						{
							for (int SkillIndex = 0; SkillIndex < jSkillCount; SkillIndex++)
							{
								// get skill values
								string jSkillName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["name"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["name"] : "";
								string jSkillTarget = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["target"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["target"] : "";
								int jSkillStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["strength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["strength"] : 0;
								string jSkillType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["type"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["type"] : "";
								int jSKillCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["cost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["cost"] : 0;
								string jSkillImg = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["img"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["ListSkills"][SkillIndex]["img"] : "";
								// add skill
								MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].ListSkills.Add(new Skill(jSkillName, jSkillTarget, jSkillStr, jSkillType, jSKillCost, jSkillImg));
								// Get Strategy values
								string jStratFieldCond = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["FieldCondition"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["FieldCondition"] : "";
								string jStratCond = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Condition"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Condition"] : "";
								int jStratCondValue = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["ConditionValue"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["ConditionValue"] : 0;
								string jStratFocus = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Focus"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Focus"] : "";
								string jStratField = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Field"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["RoboStrategy"][SkillIndex]["Field"] : "";
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
				if (DateTime.Now > MyGame.BreakTime)
					MyGame.BreakTime = DateTime.Now.AddMinutes(55);
			}
			Random rnd = new Random();
			if (MyGame.getGameCurrency < 0 && rnd.Next(1000) > 900)
				MyGame.ManagerHrs++;
		}

		private void levelUpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MyGame.ShopLevelUp();
			update();
		}

		private void btnShop_ButtonClick(object sender, EventArgs e)
		{
			if (MyGame.getGameCurrency > MyGame.getShopLvlCost)
			{
				MyGame.ShopLevelUp();
			}
			else if (MyGame.getGameCurrency > MyGame.getShopStockCost)
			{
				MyGame.AddStock();
			}
			update();
		}

		private void btnAutomatic_ButtonClick(object sender, EventArgs e)
		{
			pause();
		}

		private void mnuShowStats_Click(object sender, EventArgs e)
		{
			MyGame.setAuto();
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
				MyGame.ManagerCost = 100;
			}
			update();
		}

		private void mnuLunch_Click(object sender, EventArgs e)
		{
			if (MyGame.ManagerHrs > 0)
			{
				MyGame.SafeTime = DateTime.Now.AddHours(1);
				MyGame.ManagerHrs--;
				MyGame.ManagerCost /= 2;
			}
			update();
		}

		private void mnuWork_Click(object sender, EventArgs e)
		{
			MyGame.SafeTime = DateTime.Now.AddMinutes(20);
		}

		private void btnPurchaseManager_Click(object sender, EventArgs e)
		{
			MyGame.AddManagerHours();
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
