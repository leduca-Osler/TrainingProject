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
			if (MyGame.SaveCredits)
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
			Boolean blacksmithLvl = false;
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
			/*if (MyGame.getGameCurrency >= MyGame.getBlacksmithLvlCost)
			{
				blacksmithLvl = true;
			}*/
			btnAddTeam.Enabled = addTeam;
            btnAddRobo.Enabled = addRobo;
			btnArenaLvl.Enabled = arenaLvl;
			btnMonsterDen.Enabled = monsterLvl;
			btnShop.Enabled = shopLvl || shopRestock;
			btnShop.BackColor = shopColour;
			mnuShopLevelUp.Enabled = shopLvl;
			mnuRestockShop.Enabled = shopRestock;
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
				int jMaxTeams = (int)json["getMaxTeams"];
				int jTeamCost = (int)json["getTeamCost"];
				int jGameCurrency = (int)json["getGameCurrency"];
				int jArenaLvl = (int)json["getArenaLvl"];
				int jArenaLvlCost = (int)json["getArenaLvlCost"];
				int jArenaMaint = (int)json["getArenaLvlMaint"];
				int jMonsterDenLvl = (int)json["getMonsterDenLvl"];
				int jMonsterDenLvlCost = (int)json["getMonsterDenLvlCost"];
				int jMonsterDenMaint = (int)json["getMonsterDenLvlMaint"];
				int jMonsterDenBonus = (int)json["getMonsterDenBonus"];
				int jShopLvl = json["getShopLvl"] != null ? (int)json["getShopLvl"] : 1;
				int jShopLvlCost = json["getShopLvlCost"] != null ? (int)json["getShopLvlCost"] : 100;
				int jShopMaint = json["getShopLvlMaint"] != null ? (int)json["getShopLvlMaint"] : 0;
				int jShopStock = json["getShopStock"] != null ? (int)json["getShopStock"] : 1;
				int jShopStockCost = json["getShopStockCost"] != null ? (int)json["getShopStockCost"] : 12;
				int jShopMaxStat = json["getShopMaxStat"] != null ? (int)json["getShopMaxStat"] : 5;
				int jShopMaxDur = json["getShopMaxDurability"] != null ? (int)json["getShopMaxDurability"] : 100;
				int jShopUpValue = json["getShopUpgradeValue"] != null ? (int)json["getShopUpgradeValue"] : 1;
				// Parse json and assign to MyGame
				MyGame = new Game(jGoalGameScore, jMaxTeams, jTeamCost, jGameCurrency, jArenaLvl, jArenaLvlCost, jArenaMaint, jMonsterDenLvl, jMonsterDenLvlCost, jMonsterDenMaint, jMonsterDenBonus,
					jShopLvl, jShopLvlCost, jShopMaint, jShopStock, jShopStockCost, jShopMaxStat, jShopMaxDur, jShopUpValue); 
				for (int seatingIndex = 0; seatingIndex < json["Seating"].Count(); seatingIndex++)
				{
					MyGame.Seating.Add(new ArenaSeating((int)json["Seating"][seatingIndex]["Level"], (int)json["Seating"][seatingIndex]["Price"], (int)json["Seating"][seatingIndex]["Amount"]));
				}
				for (int StoreStockIndex = 0; StoreStockIndex < json["storeEquipment"].Count(); StoreStockIndex++)
				{
					MyGame.storeEquipment.Add(
						new Equipment((string)json["storeEquipment"][StoreStockIndex]["eType"], (string)json["storeEquipment"][StoreStockIndex]["eName"],
							   (int)json["storeEquipment"][StoreStockIndex]["eArmour"], (int)json["storeEquipment"][StoreStockIndex]["eDamage"],
							   (int)json["storeEquipment"][StoreStockIndex]["eHit"], (int)json["storeEquipment"][StoreStockIndex]["eMentalStrength"],
							   (int)json["storeEquipment"][StoreStockIndex]["eMentalDefense"], (int)json["storeEquipment"][StoreStockIndex]["eSpeed"],
							   (int)json["storeEquipment"][StoreStockIndex]["ePrice"], (int)json["storeEquipment"][StoreStockIndex]["eDurability"],
							   (int)json["storeEquipment"][StoreStockIndex]["eMaxDurability"], (int)json["storeEquipment"][StoreStockIndex]["eUpgradeCost"]
						));
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
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipWeapon = new Equipment(
								(string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eType"], (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eName"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eArmour"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDamage"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eHit"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalStrength"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMentalDefense"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eSpeed"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["ePrice"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eDurability"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eMaxDurability"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipWeapon"]["eUpgradeCost"]);
						}
						int jArmourCount = json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"] != null ? json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"].Count() : 0;
						if (jArmourCount > 0)
						{
							MyGame.GameTeams[GameTeamIndex].MyTeam[RobotIndex].getEquipArmour = new Equipment(
								(string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eType"], (string)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eName"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eArmour"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDamage"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eHit"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalStrength"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMentalDefense"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eSpeed"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["ePrice"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eDurability"],
								(int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eMaxDurability"], (int)json["GameTeams"][GameTeamIndex]["MyTeam"][RobotIndex]["getEquipArmour"]["eUpgradeCost"]);
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
				if (DateTime.Now > MyGame.BreakTime)
					btnAutomatic.BackColor = Color.Purple;
				else
					btnAutomatic.BackColor = Color.Red;
			}
			else
			{
				timer1.Enabled = true;
				btnAutomatic.BackColor = Color.White;
				if (DateTime.Now > MyGame.SafeTime)
					MyGame.SafeTime = DateTime.Now.AddMinutes(20);
				if (DateTime.Now > MyGame.BreakTime)
					MyGame.BreakTime = DateTime.Now.AddMinutes(60);
			}
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
				MyGame.SaveCredits = true;
			else
				MyGame.SaveCredits = false;
		}

		private void cboRepairPercent_SelectedIndexChanged(object sender, EventArgs e)
		{
			MyGame.repairPercent = double.Parse(cboRepairPercent.Text);
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
