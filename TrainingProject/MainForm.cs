using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
				MyGame = new Game();
			}
			InitializeComponent();
			cbTeamSelect.Items.Add("Game Stats");
			foreach (Team eTeam in MyGame.GameTeams)
			{
				cbTeamSelect.Items.Add(eTeam.getName);
			}
			cbTeamSelect.SelectedIndex = 0;
			update();
		}


		private void cbTeamSelect_Change(object sender, EventArgs e)
		{
			showSelectedTeam();
		}
		public void showSelectedTeam()
		{
			foreach (Control eControl in MainPannel.Controls)
			{
				eControl.Dispose();
			}
			MainPannel.Controls.Clear();
			if (cbTeamSelect.SelectedIndex > 0)
			{
				FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblTeamName = new Label { AutoSize = true, Text =     "Team Name:  " + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getName };
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency };
				Label lblScore = new Label { AutoSize = true, Text = "Score:      " + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getScore };
				Label lblRobots = new Label { AutoSize = true, Text = "Robots:     " + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].MyTeam.Count + "/" + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getMaxRobos + " (" + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost + ")" };
				Label lblDifficulty = new Label { AutoSize = true, Text =   "Difficulty: " + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getDifficulty };
				MainPannel.Controls.Add(lblTeamName);
				MainPannel.Controls.Add(lblTeamCurrency);
				MainPannel.Controls.Add(lblScore);
				MainPannel.Controls.Add(lblRobots);
				MainPannel.Controls.Add(lblDifficulty);
				for (int i = 0; i < MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].MyTeam.Count; i++)
				{
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].MyTeam[i].getName};
					Label Everything = new Label { AutoSize = true, Text = MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].MyTeam[i].ToString() };
					Button btnRebuild = new Button { AutoSize = true, Text = "Rebuild (" + MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].MyTeam[i].rebuildCost() + ")"};
					int index = i; // need to assign to a variable...? 
					btnRebuild.Click += new EventHandler((sender, e) => MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].Rebuild(index));
					MyPanel.Controls.Add(RoboName);
					MyPanel.Controls.Add(Everything); 
					MyPanel.Controls.Add(btnRebuild);
					TopLevelPanel.Controls.Add(MyPanel);
				}
				MainPannel.Controls.Add(TopLevelPanel);
			}
			else
			{
				Label lblTotalScore = new Label { AutoSize = true, Text = "Total Score: " + MyGame.getScore() };
				Label lblTeams = new Label { AutoSize = true,      Text = "Teams:       " + MyGame.GameTeams.Count + "/" + MyGame.getMaxTeams + " (" + MyGame.getTeamCost + ")" };
				Label lblCurrency = new Label { AutoSize = true, Text =   "Currency:    " + MyGame.getCurrency };
				Label lblArenaLvl = new Label { AutoSize = true, Text =   "Arena Level: " + MyGame.getArenaLvl + " (" + MyGame.getArenaLvlCost + ")"};
				FlowLayoutPanel Seating = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				foreach (ArenaSeating eSeating in MyGame.Seating)
				{
					Label lblArenaSeating = new Label { AutoSize = true, Text = "  Level: " + eSeating.Level + " Price " + eSeating.Price + " Seats " + eSeating.Amount};
					Seating.Controls.Add(lblArenaSeating);
				}
				Label lblShopLvl = new Label { AutoSize = true, Text =    "Shop:       " + MyGame.getShopLvl };
				Label lblMonsterDen = new Label { AutoSize = true, Text = "Monster Den:" + MyGame.getMonsterDenLvl + " (" + MyGame.getMonsterDenLvlCost + ")   +" + MyGame.getMonsterDenBonus };
				Label lblFightLog = new Label { AutoSize = true, Text =   Environment.NewLine + "Fight Log:   " + MyGame.getFightLog };
				MainPannel.Controls.Add(lblTotalScore);
				MainPannel.Controls.Add(lblTeams);
				MainPannel.Controls.Add(lblCurrency);
				MainPannel.Controls.Add(lblArenaLvl);
				MainPannel.Controls.Add(Seating);
				MainPannel.Controls.Add(lblShopLvl);
				MainPannel.Controls.Add(lblMonsterDen);
				MainPannel.Controls.Add(lblFightLog);
			}
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
            MyGame.startFight();
        }
		/***********************
         * * Ensure you can only add a team or robot when they are not on max
         * *
         * *******************/
		private void timer1_Tick(object sender, EventArgs e)
		{
			update();
			timer1.Interval++;
		}
		public void update()
		{
			MyGame.getScore();
            Boolean addTeam = false;
			Boolean addRobo = false;
			Boolean arenaLvl = false;
			Boolean monsterLvl = false;
			if (MyGame.getAvailableTeams > 0 && MyGame.getCurrency > MyGame.getTeamCost)
            {
                addTeam = true;
            }
            if (cbTeamSelect.SelectedIndex > 0 && MyGame.GameTeams[cbTeamSelect.SelectedIndex-1].getAvailableRobo > 0 
					&& MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getCurrency > MyGame.GameTeams[cbTeamSelect.SelectedIndex - 1].getRoboCost)
            {
                addRobo = true;
			}
			if (MyGame.getCurrency >= MyGame.getArenaLvlCost)
			{
				arenaLvl = true;
			}
			if (MyGame.getCurrency >= MyGame.getMonsterDenLvlCost)
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
				try
				{
					foreach (Control eControl in MainPannel.Controls)
					{
						eControl.Dispose();
					}
					MainPannel.Controls.Clear();
					MainPannel.Controls.Add(MyGame.continueFight(timer1.Interval));
				}
				catch (System.ComponentModel.Win32Exception)
				{ }
            }
			else
			{
				if (MyGame.Repair())
				{
					btnFight.BackColor = Color.White;
				}
				else
				{
					btnFight.BackColor = Color.Yellow;
				}
				// five percent chance to start a new fight 
				if (MyGame.RndVal.Next(100) > 95) { MyGame.startFight(); }
				else { showSelectedTeam(); }
			}
			try
			{
				if (MyGame.RndVal.Next(100) > 10)
				{
					BinarySerialization.WriteToBinaryFile<Game>("TrainingProject.bin", MyGame);
				}
				else
				{
					BinarySerialization.WriteToBinaryFile<Game>(DateTime.Now.ToString("yyyyMMdd") + "TrainingProject.bin", MyGame);
				}
			}
			catch { }
		}

		private void btnInterval_Click(object sender, EventArgs e)
		{
			if (timer1.Interval > 90000)
			{
				timer1.Interval = 1500;
			}
			else
			{
				timer1.Interval = 100000;
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
				return (T)binaryFormatter.Deserialize(stream);
			}
		}
	}
}
