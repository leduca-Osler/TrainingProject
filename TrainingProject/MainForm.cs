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
				MyGame = BinarySerialization.ReadFromBinaryFile<Game>("TrainingProject.bin");
				//MyGame.fixTech();
			}
			catch
			{
				// if no file, start a new game
				MyGame = new Game(true);
			}
			InitializeComponent();
			MyGame.interval(timer1);
			cbTeamSelect.Items.Add("Stats");
			foreach (Team eTeam in MyGame.GameTeams)
			{
				cbTeamSelect.Items.Add(eTeam.getName);
			}
			cbTeamSelect.SelectedIndex = 0;
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
				btnInterval.BackColor = Color.Red;
			}
		}
		public void update()
		{
            Boolean addTeam = false;
			Boolean addRobo = false;
			Boolean arenaLvl = false;
			Boolean monsterLvl = false;
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
			btnAddTeam.Enabled = addTeam;
            btnAddRobo.Enabled = addRobo;
			btnArenaLvl.Enabled = arenaLvl;
			btnMonsterDen.Enabled = monsterLvl;
			// if fight is active
			if (MyGame.isFighting())
            {

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
					MyGame.buildingMaintenance();
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
					BinarySerialization.WriteToBinaryFile<Game>("TrainingProject.bin", MyGame);
				}
				else
				{
					WriteJSON();
				}
			}
			catch { }
			MainPannel.AutoScrollPosition = new Point(0, 0);
		}

		private void btnInterval_Click(object sender, EventArgs e)
		{
			if (timer1.Enabled)
			{
				timer1.Enabled = false;
				btnInterval.BackColor = Color.Red;
			}
			else
			{
				timer1.Enabled = true;
				btnInterval.BackColor = Color.White;
				if (DateTime.Now > MyGame.SafeTime)
					MyGame.SafeTime = DateTime.Now.AddSeconds(Game.RndVal.Next(900, MyGame.MaxInterval));
			}
		}

		private void btnArenaLvl_Click(object sender, EventArgs e)
		{
			MyGame.arenaLevelUp();
		}

		private void btnMonsterDen_Click(object sender, EventArgs e)
		{
			MyGame.MonsterDenLevelUp();
		}

		private void btnAutomatic_Click(object sender, EventArgs e)
		{
		}

		private void btnResetAutoStats_Click(object sender, EventArgs e)
		{
		}

		private void btnAutomatic_MouseDown(object sender, MouseEventArgs e)
		{
			isShown = false;
			if (e.Clicks == 2)
				MyGame.resetAuto();
			else
				MyGame.setAuto();
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
			System.IO.File.WriteAllText(DateTime.Now.ToString("yyyyMMdd") + "TrainingProject.JSON", JSON);
		}
		public void ReadJSON()
		{
			OpenFileDialog Open = new OpenFileDialog();
			Open.ShowDialog();
			using (StreamReader file = File.OpenText(Open.FileName))
			{
				JsonSerializer serializer = new JsonSerializer();
				JObject json = (JObject)JToken.ReadFrom(new JsonTextReader(file));
				// Parse json and assign to MyGame
				MyGame = new Game((int)json["getGoalGameScore"], (int)json["getMaxTeams"], (int)json["getTeamCost"], (int)json["getGameCurrency"], (int)json["getArenaLvl"], (int)json["getArenaLvlCost"], 
					(int)json["getArenaLvlMaint"], (int)json["getMonsterDenLvl"], (int)json["getMonsterDenLvlCost"], (int)json["getMonsterDenLvlMaint"], (int)json["getMonsterDenBonus"]);
				for (int seatingIndex = 0; seatingIndex < json["Seating"].Count(); seatingIndex++)
				{
					MyGame.Seating.Add(new ArenaSeating((int)json["Seating"][seatingIndex]["Level"], (int)json["Seating"][seatingIndex]["Price"], (int)json["Seating"][seatingIndex]["Amount"]));
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
