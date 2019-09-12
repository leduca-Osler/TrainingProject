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
				MyGame = new Game();
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
			isShown = false;
			MyGame.startFight();
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

				if (!isShown || MyGame.RndVal.Next(100) > 90 || !MyGame.isAuto())
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
				if (MyGame.RndVal.Next(100) > 95)
				{
					MyGame.startFight();
					isShown = false;
				}
				else
				{
					if (!isShown || MyGame.RndVal.Next(100) > 90)
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
				if (MyGame.RndVal.Next(100) > 3)
				{
					BinarySerialization.WriteToBinaryFile<Game>("TrainingProject.bin", MyGame);
				}
				else
				{
					BinarySerialization.WriteToBinaryFile<Game>("TrainingProject" + MyGame.RndVal.Next(5) + ".bin", MyGame);
				}
			}
			catch { }
			cbTeamSelect.Select();
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
					MyGame.SafeTime = DateTime.Now.AddSeconds(MyGame.RndVal.Next(300,MyGame.MaxInterval));
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
