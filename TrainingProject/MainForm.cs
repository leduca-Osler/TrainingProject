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
		private bool isShown;
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
			InitializeComponent();
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
			isShown = true;
		}
        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            cbTeamSelect.Items.Add(MyGame.addTeam());
			update();
        }

        private void btnAddRobo_Click(object sender, EventArgs e)
        {
            MyGame.addRobo(cbTeamSelect.SelectedIndex-1);
			update();
        }

        private void btnFight_Click(object sender, EventArgs e)
		{
			if (!MyGame.isFighting())
			{
				isShown = false;
				MyGame.startFight();
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
			if (MyGame.getAvailableTeams > 0 && MyGame.getGameCurrency > MyGame.getTeamCost)
            {
                addTeam = true;
            }
            if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex-1].getAvailableRobo > 0 
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
			// check if we have enough money to buy manager time
			if (MyGame.getGameCurrency >= MyGame.ManagerCost)
			{
				btnAutomatic.BackColor = Color.Gold;
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
			// if fight is active
			if (MyGame.isFighting())
            {
				btnFight.BackColor = Color.Red;
				if (!isShown || Game.RndVal.Next(100) > 90 || !MyGame.isAuto())
				{
					foreach (Control eControl in MainPannel.Controls)
					{
						eControl.Dispose();
					}
					MainPannel.Controls.Clear();
					MainPannel.Controls.Add(MyGame.continueFight());
					isShown = true;
				}
				else
				{
					MyGame.continueFight();
				}
				if (!MyGame.isFighting())
					isShown = false;
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
				if (Game.RndVal.Next(100) > 95)
				{
					MyGame.startFight();
					isShown = false;
				}
				else
				{
					MyGame.equip();
					if (!isShown || Game.RndVal.Next(100) > 90)
					{
						foreach (Control eControl in MainPannel.Controls)
						{
							eControl.Dispose();
						}
						MainPannel.Controls.Clear();
						MainPannel.Controls.Add(MyGame.showSelectedTeam(cbTeamSelect.SelectedIndex));
						isShown = true;
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
			var JSON = new JavaScriptSerializer().Serialize(MyGame);
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
				int jGoalGameScore = json["getGoalGameScore"] != null ? (int)json["getGoalGameScore"] : 20;
				int jMaxTeams = json["getMaxTeams"] != null ? (int)json["getMaxTeams"] : 2;
				int jTeamCost = json["getTeamCost"] != null ? (int)json["getTeamCost"] : 500;
				int jGameCurrency = json["getGameCurrency"] != null ? (int)json["getGameCurrency"] : 0;
				int jArenaLvl = json["getArenaLvl"] != null ? (int)json["getArenaLvl"] : 1;
				int jArenaLvlCost = json["getArenaLvlCost"] != null ? (int)json["getArenaLvlCost"] : 100;
				int jArenaMaint = json["getArenaLvlMaint"] != null ? (int)json["getArenaLvlMaint"] : 1;
				int jMonsterDenLvl = json["getMonsterDenLvl"] != null ? (int)json["getMonsterDenLvl"] : 1;
				int jMonsterDenLvlCost = json["getMonsterDenLvlCost"] != null ? (int)json["getMonsterDenLvlCost"]: 100;
				int jMonsterDenMaint = json["getMonsterDenLvlMaint"] != null ? (int)json["getMonsterDenLvlMaint"] : 1;
				int jMonsterDenBonus = json["getMonsterDenBonus"] != null ? (int)json["getMonsterDenBonus"] : 10;
				int jShopLvl = json["getShopLvl"] != null ? (int)json["getShopLvl"] : 1;
				int jShopLvlCost = json["getShopLvlCost"] != null ? (int)json["getShopLvlCost"] : 100;
				int jShopMaint = json["getShopLvlMaint"] != null ? (int)json["getShopLvlMaint"] : 1;
				int jShopStock = json["getShopStock"] != null ? (int)json["getShopStock"] : 1;
				int jShopStockCost = json["getShopStockCost"] != null ? (int)json["getShopStockCost"] : 12;
				int jShopMaxStat = json["getShopMaxStat"] != null ? (int)json["getShopMaxStat"] : 5;
				int jShopMaxDur = json["getShopMaxDurability"] != null ? (int)json["getShopMaxDurability"] : 100;
				int jShopUpValue = json["getShopUpgradeValue"] != null ? (int)json["getShopUpgradeValue"] : 1;
				int jResearchDevLvl = json["getResearchDevLvl"] != null ? (int)json["getResearchDevLvl"] : 1;
				int jResearchDevLvlCost = json["getResearchDevLvlCost"] != null ? (int)json["getResearchDevLvlCost"] : 100;
				int jResearchDevMaint = json["getResearchDevMaint"] != null ? (int)json["getResearchDevMaint"] : 1;
				int jResearchDevHealValue = json["getResearchDevHealValue"] != null ? (int)json["getResearchDevHealValue"] : 2;
				int jResearchDevHealCost =  json["getResearchDevHealCost"] != null ? (int)json["getResearchDevHealCost"] : 1;
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
					int jStoreEquipPrice =  json["storeEquipment"][StoreStockIndex]["ePrice"] != null ? (int)json["storeEquipment"][StoreStockIndex]["ePrice"] : 0;
					int jStoreEquipDur = json["storeEquipment"][StoreStockIndex]["eDurability"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eDurability"] : 0;
					int jStoreEquipMDur = json["storeEquipment"][StoreStockIndex]["eMaxDurability"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eMaxDurability"] : 0;
					int jStoreEquipUCost = json["storeEquipment"][StoreStockIndex]["eUpgradeCost"] != null ? (int)json["storeEquipment"][StoreStockIndex]["eUpgradeCost"] : 0;
					MyGame.storeEquipment.Add(
						new Equipment(jStoreEquipType, jStoreEquipName,jStoreEquipHealth, jStoreEquipEnergy, jStoreEquipArmour, jStoreEquipDamage, 
							   jStoreEquipHit, jStoreEquipMStr, jStoreEquipMDef, jStoreEquipSpeed, jStoreEquipPrice, jStoreEquipDur,jStoreEquipMDur,
							   jStoreEquipUCost )
					);
				}
				for (int GameTeamIndex = 0; GameTeamIndex < json["GameTeams"].Count(); GameTeamIndex++)
				{
					MyGame.GameTeams.Add(
						new Team((int)json["GameTeams"][GameTeamIndex]["getScore"], (int)json["GameTeams"][GameTeamIndex]["getGoalScore"], (int)json["GameTeams"][GameTeamIndex]["getCurrency"], 
							(int)json["GameTeams"][GameTeamIndex]["getDifficulty"], (int)json["GameTeams"][GameTeamIndex]["getMaxRobos"], (int)json["GameTeams"][GameTeamIndex]["getRoboCost"], 
							(string)json["GameTeams"][GameTeamIndex]["getName"])
					);
					for (int RobotIndex = 0; RobotIndex < json["GameTeams"][GameTeamIndex]["MyTeam"].Count(); RobotIndex++)
					{
						MyGame.GameTeams[GameTeamIndex].MyTeam.Add(
							new Robot((string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getName"],(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getDexterity"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getStrength"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getAgility"], 
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getTech"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getAccuracy"], 
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getHealth"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEnergy"], 
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getArmour"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getDamage"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getHit"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getMentalStrength"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getMentalDefense"], (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getRobotImage"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getSpeed"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getLevel"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getAnalysis"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getCurrentAnalysis"])
						);
						int jWeaonCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"].Count() : 0;
						if (jWeaonCount > 0)
						{
							string jWeaponType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eType"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eType"] : "";
							string jWeaponName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eName"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eName"] : "";
							int jWeaponHealth = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eHealth"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eHealth"] : 0;
							int jWeaponEnergy = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eEnergy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eEnergy"] : 0;
							int jWeaponArmour = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eArmour"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eArmour"] : 0;
							int jWeaponDamage = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDamage"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDamage"] : 0;
							int jWeaponHit = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eHit"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eHit"] : 0;
							int jWeaponMStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalStrength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalStrength"] : 0;
							int jWeaponMDef = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalDefense"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalDefense"] : 0;
							int jWeaponSpeed = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eSpeed"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eSpeed"] : 0;
							int jWeaponPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["ePrice"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["ePrice"] : 0;
							int jWeaponDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDurability"] : 0;
							int jWeaponMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMaxDurability"] : 0;
							int jWeaponUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eUpgradeCost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eUpgradeCost"] : 0;
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipWeapon = new Equipment(jWeaponType, jWeaponName, jWeaponHealth, jWeaponEnergy, jWeaponArmour, 
								jWeaponDamage, jWeaponHit, jWeaponMStr, jWeaponMDef, jWeaponSpeed, jWeaponPrice, jWeaponDur, jWeaponMDur, jWeaponUCost);
						}
						int jArmourCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"].Count() : 0;
						if (jArmourCount > 0)
						{
							string jArmourType = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eType"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eType"] : "";
							string jArmourName = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eName"] != null ? (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eName"] : "";
							int jArmourHealth = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eHealth"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eHealth"] : 0;
							int jArmourEnergy = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eEnergy"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eEnergy"] : 0;
							int jArmourArmour = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eArmour"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eArmour"] : 0;
							int jArmourDamage = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDamage"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDamage"] : 0;
							int jArmourHit = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eHit"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eHit"] : 0;
							int jArmourMStr = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalStrength"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalStrength"] : 0;
							int jArmourMDef = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalDefense"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalDefense"] : 0;
							int jArmourSpeed = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eSpeed"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eSpeed"] : 0;
							int jArmourPrice = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["ePrice"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["ePrice"] : 0;
							int jArmourDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDurability"] : 0;
							int jArmourMDur = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMaxDurability"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMaxDurability"] : 0;
							int jArmourUCost = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eUpgradeCost"] != null ? (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eUpgradeCost"] : 0;
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipArmour = new Equipment(jArmourType, jArmourName, jArmourHealth, jArmourEnergy, jArmourArmour,
								jArmourDamage, jArmourHit, jArmourMStr, jArmourMDef, jArmourSpeed, jArmourPrice, jArmourDur, jArmourMDur, jArmourUCost);
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
