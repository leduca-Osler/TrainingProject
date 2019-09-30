using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using Newtonsoft.Json;

namespace TrainingProject
{
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Common
	{
		public static readonly Random RndVal = new Random();
		//public Random RndVal = new Random();
		public string[] RoboImages = {
			"Robo1.jpg",
			"Robo2.jpg",
			"Robo3.jpg",
			"Robo4.jpg",
			"Robo5.jpg",
			"Robo6.jpg",
			"Robo7.jpg",
			"Robo8.jpg",
			"Robo9.jpg",
		};
		public string[] MonsterImages = {
			"Monster1.png",
			"Monster2.png",
			"Monster3.png",
			"Monster4.png",
			"Monster5.png",
			"Monster6.png",
			"Monster7.png",
			"Monster8.png",
			"Monster9.png",
		};
		public string strike = "Strike.jpg";
		public string hurt = "Hurt.png";
		public string KO = "KO.jpg";
		public string miss = "dodge.png";
		public string blocked = "block.png";
		public string[] name1 = { "Green", "Blue", "Yellow", "Orange", "Black", "Pink", "Great", "Strong", "Cunning" };
		public string[] name2 = { "Sharks", "Octopuses", "Birds", "Foxes", "Wolfs", "Lions", "Rinos", };
		public string[] name3 = { "Blades", "Arrows", "Staffs", "Sparks", "Factory", "Snipers", "Calvary" };
		public string[] RoboName = { "Bolt", "Tink", "Hmr", "Golm", "Droi", "Trs", "Gun", "Rep", "Bot" };
		public string[] MonsterName = { "Devil", "Alien", "Slither", "Blob", "Bat", "Titan", "Chomp", "Element", "HandEye" };
		public int roundValues(int value)
		{
			if (value.ToString().Substring(0, 1) == "4")
			{
				value += (int)Math.Pow(10, value.ToString().Length - 1);
			}
			return value;
		}
		public Common() { }

		public static string InputBox(string title, string promptText)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();
			Button buttonCancel = new Button();

			form.Text = title;
			label.Text = promptText;

			buttonOk.Text = "OK";
			buttonCancel.Text = "Cancel";
			buttonOk.DialogResult = DialogResult.OK;
			buttonCancel.DialogResult = DialogResult.Cancel;

			label.SetBounds(9, 20, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);
			buttonCancel.SetBounds(309, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;
			form.CancelButton = buttonCancel;

			DialogResult dialogResult = form.ShowDialog();
			return textBox.Text;
		}
	}
    [Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Game : Common
	{
		[JsonProperty]
		public IList<Team> GameTeams;
		[JsonProperty]
		public IList<ArenaSeating> Seating;
		[JsonProperty]
		public IList<Equipment> storeEquipment;
		public Team GameTeam1;
        public Team GameTeam2;
		public int MonsterCount;
		public int RoboCount;
		public int CurrentInterval;
		public int MaxInterval;
		public DateTime SafeTime;
		public DateTime BreakTime;
		public double repairPercent;
		public bool PurchaseUgrade;
		[JsonProperty]
		private int GoalGameScore;
		[JsonProperty]
		private int MaxTeams;
		[JsonProperty]
		private int TeamCost;
		private int Jackpot; // holds the credits to be divied out after a fight
		[JsonProperty]
		private int GameCurrency;
		private int GameCurrencyLog;
        private Boolean fighting;
		private Boolean auto;
		private string FightLog;
		[JsonProperty]
		private int ShopLvl;
		[JsonProperty]
		private int ShopLvlCost;
		[JsonProperty]
		private int ShopLvlMaint;
		[JsonProperty]
		private int ShopStock;
		[JsonProperty]
		private int ShopStockCost;
		[JsonProperty]
		private int ShopMaxStat;
		[JsonProperty]
		private int ShopMaxDurability;
		[JsonProperty]
		private int ShopUpgradeValue;
		[JsonProperty]
		private int ArenaLvl;
		[JsonProperty]
		private int ArenaLvlCost;
		[JsonProperty]
		private int ArenaLvlMaint;
		[JsonProperty]
		private int MonsterDenLvl;
		[JsonProperty]
		private int MonsterDenLvlCost;
		[JsonProperty]
		private int MonsterDenLvlMaint;
		[JsonProperty]
		private int MonsterDenBonus;
		[JsonProperty]
		private int ResearchDevLvl;
		[JsonProperty]
		private int ResearchDevLvlCost;
		[JsonProperty]
		private int ResearchDevMaint;
		[JsonProperty]
		private int ResearchDevHealValue;
		[JsonProperty]
		private int ResearchDevHealCost;

		[JsonProperty]
		public int getMonsterDenBonus
		{
			get { return MonsterDenBonus; }
			set { MonsterDenBonus = value; }
		}
		[JsonProperty]
		public int getMonsterDenLvlCost
		{
			get { return MonsterDenLvlCost; }
			set { MonsterDenLvlCost = value; }
		}
		[JsonProperty]
		public int getMonsterDenLvl
		{
			get
			{
				if (MonsterDenLvl > 8)
				{
					return 8; // Max number of Monster images
				}
				return MonsterDenLvl;
			}
			set { MonsterDenLvl = value; }
		}
		[JsonProperty]
		public int getMonsterDenLvlMaint
		{
			get { return MonsterDenLvlMaint; }
			set { MonsterDenLvlMaint = value; }
		}
		[JsonProperty]
		public int getMaxTeams
		{
			get { return MaxTeams; }
			set { MaxTeams = value; }
		}
		[JsonProperty]
		public int getTeamCost
		{
			get { return TeamCost; }
			set { TeamCost = value; }
		}
		[JsonProperty]
		public int getGoalGameScore
		{
			get { return GoalGameScore; }
			set { GoalGameScore = value; }
		}
		[JsonProperty]
		public int getGameCurrency
		{
			set
			{
				GameCurrencyLog += value - GameCurrency;
				GameCurrency = value;
			}
			get { return GameCurrency; }
		}
		[JsonProperty]
		public int getArenaLvl
		{
			get { return ArenaLvl; }
			set { ArenaLvl = value; }
		}
		[JsonProperty]
		public int getArenaLvlCost
		{
			get { return ArenaLvlCost; }
			set { ArenaLvlCost = value; }
		}
		[JsonProperty]
		public int getArenaLvlMaint
		{
			get { return ArenaLvlMaint; }
			set { ArenaLvlMaint = value; }
		}
		[JsonProperty]
		public int getShopLvl
		{
			get { return ShopLvl; }
			set { ShopLvl = value; }
		}
		[JsonProperty]
		public int getShopLvlCost
		{
			get { return ShopLvlCost; }
			set { ShopLvlCost = value; }
		}
		[JsonProperty]
		public int getShopLvlMaint
		{
			get { return ShopLvlMaint; }
			set { ShopLvlMaint = value; }
		}
		[JsonProperty]
		public int getShopStock
		{
			get { return ShopStock; }
			set { ShopStock = value; }
		}
		[JsonProperty]
		public int getShopStockCost
		{
			get { return ShopStockCost; }
			set { ShopStockCost = value; }
		}
		[JsonProperty]
		public int getShopMaxStat
		{
			get { return ShopMaxStat; }
			set { ShopMaxStat = value; }
		}
		[JsonProperty]
		public int getShopMaxDurability
		{
			get { return ShopMaxDurability; }
			set { ShopMaxDurability = value; }
		}
		[JsonProperty]
		public int getShopUpgradeValue
		{
			get { return ShopUpgradeValue; }
			set { ShopUpgradeValue = value; }
		}
		[JsonProperty]
		public int getResearchDevLvl
		{
			get { return ResearchDevLvl; }
			set { ResearchDevLvl = value; }
		}
		[JsonProperty]
		public int getResearchDevLvlCost
		{
			get { return ResearchDevLvlCost; }
			set { ResearchDevLvlCost = value; }
		}
		[JsonProperty]
		public int getResearchDevMaint
		{
			get { return ResearchDevMaint; }
			set { ResearchDevMaint = value; }
		}
		[JsonProperty]
		public int getResearchDevHealValue
		{
			get { return ResearchDevHealValue; }
			set { ResearchDevHealValue = value; }
		}
		[JsonProperty]
		public int getResearchDevHealCost
		{
			get { return ResearchDevHealCost; }
			set { ResearchDevHealCost = value; }
		}
		[JsonProperty]
		public string getFightLog
		{
			set
			{
				if (FightLog.Length > 5000)
					FightLog = value + FightLog.Substring(1, 1500);
				else
					FightLog = value + FightLog;
			}
			get { return FightLog; }
		}
		[JsonProperty]
		public int getAvailableTeams
		{
			get { return MaxTeams - GameTeams.Count; }
			set { MaxTeams = value; }
		}
		public Game(int pGoalGameScore, int pMaxTeams, int pTeamCost, int pGameCurrency, int pArenaLvl, int pArenaLvlCost, int pArenaLvlMaint, int pMonsterDenLvl, int pMonsterDenLvlCost, int pMonsterDenLvlMaint, 
			int pMonsterDenBonus, int pShopLvl, int pShopLvlCost, int pShopLvlMaint, int pShopStock, int pShopStockCost, int pShopMaxStat, int pShopMaxDurability, int pShopUpgradeValue, int pResearchDevLvl, 
			int pResearchDevLvlCost , int pResearchDevMaint, int pResearchDevHealValue, int pResearchDevHealCost)
		{
			GameTeams = new List<Team> { };
			Seating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			GoalGameScore = pGoalGameScore;
			MaxTeams = pMaxTeams;
			TeamCost = pTeamCost;
			GameCurrency = pGameCurrency;
			fighting = false;
			auto = false;
			FightLog = "";
			ShopLvl = pShopLvl;
			ShopLvlCost = pShopLvlCost;
			ShopLvlMaint = pShopLvlMaint;
			ShopStock = pShopStock;
			ShopStockCost = pShopStockCost;
			ShopMaxStat = pShopMaxStat;
			ShopMaxDurability = pShopMaxDurability;
			ShopUpgradeValue = pShopUpgradeValue;
			repairPercent = .5;
			PurchaseUgrade = false;
			ArenaLvl = pArenaLvl;
			ArenaLvlCost = pArenaLvlCost;
			ArenaLvlMaint = pArenaLvlMaint;
			MonsterDenLvl = pMonsterDenLvl;
			MonsterDenLvlCost = pMonsterDenLvlCost;
			MonsterDenLvlMaint = pMonsterDenLvlMaint;
			MonsterDenBonus = pMonsterDenBonus;
			ResearchDevLvl = pResearchDevLvl;
			ResearchDevLvlCost = pResearchDevLvlCost;
			ResearchDevMaint = pResearchDevMaint;
			ResearchDevHealValue = pResearchDevHealValue;
			ResearchDevHealCost = pResearchDevHealCost;
			MonsterCount = 0;
			RoboCount = 0;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
		}
		public Game(bool isNew)
        {
            GameTeams = new List<Team> { new Team(true), new Team(true) };
			Seating = new List<ArenaSeating> { new ArenaSeating(1, 1, 50) };
			storeEquipment = new List<Equipment> { };
			GameCurrency = 0;
            GoalGameScore = 100;
            MaxTeams = 2;
			TeamCost = 500;
			fighting = false;
			auto = false;
			FightLog = "";
			ShopLvl = 1;
			ShopLvlCost = 100;
			ShopLvlMaint = 1;
			ShopStock = 1;
			ShopStockCost = 120;
			ShopMaxStat = 5;
			ShopMaxDurability = 100;
			ShopUpgradeValue = 1;
			repairPercent = .5;
			PurchaseUgrade = false;
			ArenaLvl = 1;
			ArenaLvlCost = 100;
			ArenaLvlMaint = 1;
			MonsterDenLvl = 1;
			MonsterDenLvlCost = 100;
			MonsterDenLvlMaint = 1;
			MonsterDenBonus = 10;
			ResearchDevLvl = 1;
			ResearchDevLvlCost = 100;
			ResearchDevMaint = 1;
			ResearchDevHealValue = 2;
			ResearchDevHealCost = 1;
			MonsterCount = 0;
			RoboCount = 0;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
		}
		
		public void fixTech()
		{
			foreach (Team eTeam in GameTeams) { eTeam.fixTech(); }
		}

		public void setAuto()
		{
			auto = !auto;
		}

		public void resetAuto()
		{
			// reset log files
			GameCurrencyLog = 0;
			foreach (Team eTeam in GameTeams)
			{
				eTeam.resetLogs();
			}
		}

		public void interval(Timer Timer1)
		{
			CurrentInterval++;
			if (CurrentInterval > MaxInterval)
			{
				CurrentInterval = 1000;
				MaxInterval++;
			}
			Timer1.Interval = CurrentInterval;
		}

		public void arenaLevelUp()
		{
			getGameCurrency -= ArenaLvlCost;
			ArenaLvlMaint = ArenaLvlCost;
			ArenaLvl++;
			ArenaLvlCost *= 2;
			ArenaLvlCost = roundValues(ArenaLvlCost);
			foreach (ArenaSeating eSeating in Seating)
			{
				eSeating.Amount += RndVal.Next(1, eSeating.Amount);
				eSeating.Price++;
			}
			// 10% chance to add a new level of seating
			if (RndVal.Next(1000) > 900) { Seating.Add(new ArenaSeating(Seating.Count + 1, Seating[Seating.Count - 1].Price * 2, 1)); }
		}
		public void MonsterDenLevelUp()
		{
			getGameCurrency -= MonsterDenLvlCost;
			MonsterDenLvlMaint = MonsterDenLvlCost;
			MonsterDenLvl++;
			MonsterDenLvlCost *= 2;
			MonsterDenLvlCost = roundValues(MonsterDenLvlCost);
			MonsterDenBonus += RndVal.Next(1, (int)(MonsterDenBonus * .5));
		}
		public void ShopLevelUp()
		{
			getGameCurrency -= ShopLvlCost;
			ShopLvlMaint = ShopLvlCost;
			ShopLvl++;
			ShopLvlCost *= 2;
			ShopLvlCost = roundValues(ShopLvlCost);
			ShopStock ++;
			ShopMaxDurability += RndVal.Next(1, (int)((ShopMaxDurability * .5) >= 1 ? (ShopMaxDurability * .5) : 1));
			ShopMaxStat += RndVal.Next(1, (int)((ShopMaxStat * .5) >= 1 ? (ShopMaxStat * .5) : 1));
			ShopUpgradeValue++;
			ShopStockCost = ((ShopMaxStat * 10) + ShopMaxDurability) / 2;
		}
		public void AddStock()
		{
			// Add new equipent to stock
			while (ShopStock > storeEquipment.Count && getGameCurrency >= ShopStockCost)
			{
				getGameCurrency -= ShopStockCost;
				storeEquipment.Add(new Equipment(RndVal.Next(5,ShopMaxStat), RndVal.Next(100, ShopMaxDurability)));
			}
		}

		public void ResearchDevLevelUp()
		{
			getGameCurrency -= ResearchDevLvlCost;
			ResearchDevMaint = ResearchDevLvlCost;
			ResearchDevLvl++;
			ResearchDevLvlCost *= 2;
			ResearchDevLvlCost = roundValues(ResearchDevLvlCost);
			ResearchDevHealCost++;
			ResearchDevHealValue += RndVal.Next(1, ResearchDevHealValue);
		}
		public string addTeam()
        {
			// calculate cost
			getGameCurrency -= TeamCost;
			TeamCost *= 2;
			TeamCost = roundValues(TeamCost);
			Team tmp = new Team(true);
            GameTeams.Add(tmp);
			// Rebuild team with top score
			Team rebuild = new Team(true);
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.getScore > rebuild.getScore)
					rebuild = eTeam;
			}
			rebuild.getScore = 0;
			rebuild.getCurrency = 0;
			rebuild.getDifficulty = 0;
			for (int i = 0; i < rebuild.MyTeam.Count; i++)
				rebuild.Rebuild(i);
            return tmp.getName;
        }
        public void addRobo(int Team)
        {
			GameTeams[Team].getCurrency -= GameTeams[Team].getRoboCost;
			GameTeams[Team].getRoboCost *= 2;
			GameTeams[Team].getRoboCost = roundValues(GameTeams[Team].getRoboCost);
			Robot tmp = new Robot(1,GameTeams[Team].setName(true), RndVal.Next(8), false);
            GameTeams[Team].MyTeam.Add(tmp);
        }
        public int getScore()
        {
            int iTmpScore = 0;
            for (int i = 0; i < GameTeams.Count; i++) { iTmpScore += GameTeams[i].getScore; }
			if (iTmpScore >= GoalGameScore)
			{
				MaxTeams++;
				GoalGameScore *= 2;
				GoalGameScore = roundValues(GoalGameScore);
			}
			return iTmpScore;
		}
		public Boolean Repair()
		{
			Boolean fullHP = true;
			foreach (Team eTeam in GameTeams)
			{
				Boolean tmpFullHP = true;
				if (!PurchaseUgrade)
					tmpFullHP = eTeam.healRobos(0, 1);
				else
					tmpFullHP = eTeam.healRobos(ResearchDevHealCost, ResearchDevHealValue);
				if (tmpFullHP == false)
				{
					fullHP = false;
				}
			}
			return fullHP;
		}
        public void startFight()
        {
            fighting = true;
            int Team1Index = 0;
            int Team2Index = GameTeams.Count - 1;
			int PotScore = 0;
			// 50% chance to fight teams. 
			if (RndVal.Next(1000) > 500)
			{
				// robot fight
				Team1Index = RndVal.Next(1,GameTeams.Count);
				Team2Index = RndVal.Next(1,GameTeams.Count);
			}
			else
			{
				// monster fight
				int Team1Score = RndVal.Next(GameTeams[0].getScore);
				int tmpScore = 0;
				for (int i = 1; i < GameTeams.Count; i++)
				{
					tmpScore = RndVal.Next(GameTeams[i].getScore);
					// if new score is lower than previous
					if (Team1Score > tmpScore)
					{
						Team1Index = i;
						Team2Index = i;
						Team1Score = tmpScore;
					}
				}
			}
			GameTeam1 = GameTeams[Team1Index];
			PotScore = GameTeam1.getScore;

            if (Team1Index == Team2Index)
            {
                // Monster team... 
                GameTeam2 = new Team(GameTeam1.getMaxRobos,GameTeam1.getDifficulty, getMonsterDenLvl);
            }
            else
            {
                // Robo Team
                GameTeam2 = GameTeams[Team2Index];
				PotScore += GameTeam2.getScore;
			}
			PotScore += MonsterDenBonus;
			string msg = "     Attendance: " + Environment.NewLine;
			// Get money for the pot
			foreach (ArenaSeating eSeating in Seating)
			{
				int NumSeats = RndVal.Next(1, PotScore > eSeating.Amount ? eSeating.Amount : PotScore);
				msg += "        Level " + eSeating.Level + " " + NumSeats + " seats " + Environment.NewLine;
				Jackpot += eSeating.Price * NumSeats;
			}
			getFightLog = GameTeam1.getName + " VS " + GameTeam2.getName + " @ " + DateTime.Now.ToString() + Environment.NewLine + msg + Environment.NewLine;
		}
		public Boolean isFighting()
		{
			return fighting;
		}
		public Boolean isAuto()
		{
			return auto;
		}

		public FlowLayoutPanel getCharacterInfo(Robot eRobo)
		{
			FlowLayoutPanel Robo = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			Label level = new Label { AutoSize = true, Width = 50, Text = eRobo.getLevel.ToString() };
			Robo.Controls.Add(level);
			Label Name = new Label { AutoSize = true, Width = 50, Text = eRobo.getName };
			Robo.Controls.Add(Name);
			PictureBox RoboPic = new PictureBox { Image = Image.FromFile(eRobo.getImage), Width = 50, Height = 50, SizeMode = PictureBoxSizeMode.StretchImage };
			Robo.Controls.Add(RoboPic);
			ProgressBar HP = new ProgressBar { Maximum = eRobo.getTHealth(), Value = eRobo.HP, Width = 50, Height = 5 };
			Robo.Controls.Add(HP);
			Label spd = new Label { AutoSize = true, Text = eRobo.message };
			Robo.Controls.Add(spd);
			return Robo;
		}

		public string showInterval()
		{
			string retval = "";
			int tmpInterval = CurrentInterval;
			int Minutes = 0;
			// Seconds
			if (tmpInterval > 1000)
			{
				Minutes = (int)(tmpInterval / 1000);
				tmpInterval -= Minutes * 1000;
				retval += Minutes + "s ";
			}
			retval += tmpInterval + "ms";
			return retval;
		}

		public FlowLayoutPanel showHeader()
		{
			FlowLayoutPanel HeaderPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			ProgressBar Progress = new ProgressBar { Maximum = MaxInterval, Value = CurrentInterval, Minimum = 1000, Width = 200, Height = 10 };
			HeaderPanel.Controls.Add(Progress);
			Label lblTime = new Label { AutoSize = true, Text = "Time:  " + DateTime.Now.ToString("HH:mm") + " (" + SafeTime.ToString("HH:mm") + ") (" + BreakTime.ToString("HH:mm") + ")" };
			HeaderPanel.Controls.Add(lblTime);
			return HeaderPanel;
		}
		public FlowLayoutPanel showSelectedTeam(int TeamSelect)
		{
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			if (TeamSelect > 0)
			{
				FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblTeamName = new Label { AutoSize = true, Text =     "Team Name:  " + GameTeams[TeamSelect - 1].getName };
				lblTeamName.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].rename( InputBox("Enter Name ", "Enter Name")));
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getCurrency) };
				Label lblScore = new Label { AutoSize = true, Text =        "Score:      " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getScore) + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getGoalScore) + ")"};
				Label lblRobots = new Label { AutoSize = true, Text =       "Robots:     " + GameTeams[TeamSelect - 1].MyTeam.Count + "/" + GameTeams[TeamSelect - 1].getMaxRobos + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getRoboCost) + ")" };
				Label lblDifficulty = new Label { AutoSize = true, Text =   "Difficulty: " +  GameTeams[TeamSelect - 1].getDifficulty };
				MainPanel.Controls.Add(lblTeamName);
				MainPanel.Controls.Add(lblTeamCurrency);
				MainPanel.Controls.Add(lblScore);
				MainPanel.Controls.Add(lblRobots);
				MainPanel.Controls.Add(lblDifficulty);
				int index = 0;
				foreach (Robot eRobo in GameTeams[TeamSelect-1].MyTeam)
				{
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
					RoboName.Click += new EventHandler((sender, e) => eRobo.rename(InputBox("Enter Name ", "Enter Name")));
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					Button btnRebuild = new Button { AutoSize = true, Text = "Rebuild (" + String.Format("{0:n0}", eRobo.rebuildCost()) + ")" };
					btnRebuild.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].Rebuild(index++));
					MyPanel.Controls.Add(RoboName);
					MyPanel.Controls.Add(Everything);
					MyPanel.Controls.Add(btnRebuild);
					TopLevelPanel.Controls.Add(MyPanel);
				}
				MainPanel.Controls.Add(TopLevelPanel);
			}
			else
			{
				Label lblTotalScore = new Label { AutoSize = true, Text = "Total Score: " + getScore() + " (" + String.Format("{0:n0}", getGoalGameScore) + ")" };
				MainPanel.Controls.Add(lblTotalScore);
				Label lblTeams = new Label { AutoSize = true, Text =	  "Teams:       " + GameTeams.Count + "/" + getMaxTeams + " (" + String.Format("{0:n0}", getTeamCost) + ")" };
				MainPanel.Controls.Add(lblTeams);
				Label lblCurrency = new Label { AutoSize = true, Text =   "Currency:    " + String.Format("{0:n0}", getGameCurrency) };
				MainPanel.Controls.Add(lblCurrency);
				Label lblArenaLvl = new Label { AutoSize = true, Text =   "Arena Level: " + getArenaLvl + " (" + String.Format("{0:n0}", getArenaLvlCost) + ")" };
				MainPanel.Controls.Add(lblArenaLvl);
				FlowLayoutPanel pnlSeating = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				foreach (ArenaSeating eSeating in Seating)
				{
					Label lblArenaSeating = new Label { AutoSize = true, Text = "  Level: " + eSeating.Level + " Price " + String.Format("{0:n0}", eSeating.Price) + " Seats " + 
						String.Format("{0:n0}", eSeating.Amount) + Environment.NewLine};
					pnlSeating.Controls.Add(lblArenaSeating);
				}
				MainPanel.Controls.Add(pnlSeating);
				Label lblShopLvl = new Label { AutoSize = true, Text = "Shop:        " + getShopLvl + " (" + String.Format("{0:n0}", getShopLvlCost) + ") Upgrade: " + getShopUpgradeValue };
				MainPanel.Controls.Add(lblShopLvl);
				FlowLayoutPanel pnlEquipment = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				Label lblShopStock = new Label { AutoSize = true, Text = "Max Stock: " + getShopStock + " Cost: " + String.Format("{0:n0}", getShopStockCost) + " stat:" + String.Format("{0:n0}", getShopMaxStat) + " Dur: " + String.Format("{0:n0}", getShopMaxDurability) };
				pnlEquipment.Controls.Add(lblShopStock);
				foreach (Equipment eEquipment in storeEquipment)
				{
					Label lblEquipment = new Label { AutoSize = true, Text = "  " + eEquipment.ToString() + Environment.NewLine };
					pnlEquipment.Controls.Add(lblEquipment);
				}
				MainPanel.Controls.Add(pnlEquipment);
				Label lblResearchLvl = new Label { AutoSize = true, Text = "Research Lvl:" + getResearchDevLvl + " (" + String.Format("{0:n0}", getResearchDevLvlCost) + ") Heal:" + getResearchDevHealValue + " Cost: " + String.Format("{0:n0}", getResearchDevHealCost) };
				MainPanel.Controls.Add(lblResearchLvl);
				Label lblMonsterDen = new Label { AutoSize = true, Text =  "Monster Den: " + getMonsterDenLvl + " (" + String.Format("{0:n0}", getMonsterDenLvlCost) + ")   +" + String.Format("{0:n0}", MonsterDenBonus) };
				MainPanel.Controls.Add(lblMonsterDen);
				Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + Environment.NewLine + getFightLog };
				MainPanel.Controls.Add(lblFightLog);
			}
			//isShown = true;
			return MainPanel;
		}
		public FlowLayoutPanel continueFight()
        {
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			Label lblTeamName = new Label { AutoSize = true, Text = "Fight (" + showInterval() + ")" };
			MainPanel.Controls.Add(lblTeamName);
			Label lblVS = new Label { AutoSize = true, Text = GameTeam1.getName + " VS " + GameTeam2.getName };
			MainPanel.Controls.Add(lblVS);
			if (GameTeam1.getNumRobos() > 0 && GameTeam2.getNumRobos() > 0)
			{
				getNext();
				if (auto)
				{
					Label lblGameStats = new Label { AutoSize = true, Text = "Currency: " + String.Format("{0:n0}", getGameCurrency) + " (" + String.Format("{0:n0}", GameCurrencyLog) + ") Total Score: " + String.Format("{0:n0}", getScore()) };
					MainPanel.Controls.Add(lblGameStats);
					Label lblTeam1stats = new Label { AutoSize = true, Text = GameTeam1.getTeamStats("", "") };
					MainPanel.Controls.Add(lblTeam1stats);
					Label lblTeam2stats = new Label { AutoSize = true, Text = GameTeam2.getTeamStats("", "") };
					MainPanel.Controls.Add(lblTeam2stats);
					// Add a space
					MainPanel.Controls.Add(new Label { AutoSize = true, Text = "" });
					foreach (Team eTeam in GameTeams)
					{
						Label lblTeamstats = new Label { AutoSize = true, Text = eTeam.getTeamStats(GameTeam1.getName, GameTeam2.getName) };
						MainPanel.Controls.Add(lblTeamstats);
					}
					Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + Environment.NewLine + getFightLog };
					MainPanel.Controls.Add(lblFightLog);
				}
				else
				{
					FlowLayoutPanel Team1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
					// add all the robos to team one flow
					foreach (Robot eRobo in GameTeam1.MyTeam)
					{
						if (eRobo.getKO < 10)
						{
							Team1.Controls.Add(getCharacterInfo(eRobo));
						}
					}
					FlowLayoutPanel Team2Panel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
					foreach (Robot eRobo in GameTeam2.MyTeam)
					{
						if (eRobo.getKO < 10)
						{
							Team2Panel.Controls.Add(getCharacterInfo(eRobo));
						}
					}
					MainPanel.Controls.Add(Team1);
					MainPanel.Controls.Add(Team2Panel);
				}
			}
			else
			{
				string msg = "";
				Label lblWinner = new Label { AutoSize = true };
				if (GameTeam1.getNumRobos() > 0)
				{
					lblWinner.Text = GameTeam1.getName + " wins!";
					int tmp = (int)(Jackpot * .4);
					GameTeam1.getCurrency += tmp;
					Jackpot -= tmp;
					msg += " " + String.Format("{0:n0}", tmp) ;
					// increase difficulty if monster
					if (GameTeam2.isMonster) { GameTeam1.getDifficulty++; }
					else
					{
						// increase score if another team and score's are within 20%
						GameTeam1.getScore++;
						// pay team 2 25%;
						tmp = (int)(Jackpot * .25);
						GameTeam2.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " (" + String.Format("{0:n0}", tmp) + ")";
					}
					msg = GameTeam1.getName + " Won against " + GameTeam2.getName + msg;
				}
				else
				{
					lblWinner.Text = GameTeam2.getName + " winns!";
					GameTeam2.getScore++;
					// decrease difficulty if monster won
					if (GameTeam2.isMonster)
					{
						GameTeam1.getDifficulty--;
						// pay loosing team 20%
						int tmp = (int)(Jackpot * .25);
						GameTeam1.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " (" + String.Format("{0:n0}", tmp) +")";
					}
					else
					{
						// team won they get 40%
						int tmp = (int)(Jackpot * .4);
						GameTeam2.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " " + String.Format("{0:n0}", tmp);
						// team lost gets 25%
						tmp = (int)(Jackpot * .25);
						GameTeam1.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " (" + String.Format("{0:n0}", tmp) + ")";
					}
					msg = GameTeam2.getName + " Won against " + GameTeam1.getName + msg ;
				}
				getGameCurrency += Jackpot;
				getFightLog = msg + Environment.NewLine + "     Arena made " + String.Format("{0:n0}", Jackpot) + " @ " + DateTime.Now.ToString() + Environment.NewLine;
				Jackpot = 0;
				MainPanel.Controls.Add(lblWinner);
				fighting = false;
				buildingMaintenance();
			}
			return MainPanel;
		}

		public void equip()
		{
			Robot shopper;
			// pick random robot
			int team = RndVal.Next(0, GameTeams.Count);
			shopper = GameTeams[team].MyTeam[RndVal.Next(0, GameTeams[team].MyTeam.Count)];
			// if has equipment repair / upgrade it
			if (shopper.getEquipWeapon != null)
			{
				// Repair
				if (GameTeams[team].getCurrency > (shopper.getEquipWeapon.ePrice / 10) 
					&&  shopper.getEquipWeapon.eDurability < shopper.getEquipWeapon.eMaxDurability * repairPercent)
				{
					shopper.getEquipWeapon.eDurability = shopper.getEquipWeapon.eMaxDurability = (int)(shopper.getEquipWeapon.eMaxDurability * .9);
					GameTeams[team].getCurrency -= (shopper.getEquipWeapon.ePrice / 10);
					getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipWeapon.ePrice / 10)  + Environment.NewLine + "  " + shopper.getEquipWeapon.ToString() + Environment.NewLine;
				}
				// upgrade
				if (GameTeams[team].getCurrency > shopper.getEquipWeapon.eUpgradeCost && PurchaseUgrade)
				{
					int tmpUpgrade = (shopper.getEquipWeapon.eUpgradeCost);
					GameTeams[team].getCurrency -= tmpUpgrade;
					shopper.getEquipWeapon.upgrade(getShopUpgradeValue);
					getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + Environment.NewLine + "  " + shopper.getEquipWeapon.ToString() + Environment.NewLine;
				}
			}
			else
			{
				// buy
				int index = 0;
				foreach (Equipment eEquip in storeEquipment)
				{
					if (GameTeams[team].getCurrency > eEquip.ePrice && eEquip.eType == "Weapon" && PurchaseUgrade)
					{
						GameTeams[team].getCurrency -= eEquip.ePrice;
						getGameCurrency += eEquip.ePrice;
						shopper.getEquipWeapon = eEquip;
						storeEquipment.RemoveAt(index);
						getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " purchased " + String.Format("({0:n0}) ", eEquip.ePrice) + Environment.NewLine + "  " + eEquip.ToString() + Environment.NewLine;
						break;
					}
					index++;
				}
			}
			if (shopper.getEquipArmour != null)
			{
				// Repair 
				if (GameTeams[team].getCurrency > (shopper.getEquipArmour.ePrice / 10)
					&& shopper.getEquipArmour.eDurability < shopper.getEquipArmour.eMaxDurability * repairPercent)
				{
					shopper.getEquipArmour.eDurability = shopper.getEquipArmour.eMaxDurability = (int)(shopper.getEquipArmour.eMaxDurability * .9);
					GameTeams[team].getCurrency -= (shopper.getEquipArmour.ePrice / 10);
					getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipArmour.ePrice / 10) + Environment.NewLine + "  " + shopper.getEquipArmour.ToString() + Environment.NewLine;
				}
				// upgrade
				if (GameTeams[team].getCurrency > shopper.getEquipArmour.eUpgradeCost && PurchaseUgrade)
				{
					int tmpUpgrade = (shopper.getEquipArmour.eUpgradeCost);
					GameTeams[team].getCurrency -= tmpUpgrade;
					shopper.getEquipArmour.upgrade(getShopUpgradeValue);
					getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + Environment.NewLine + "  " + shopper.getEquipArmour.ToString() + Environment.NewLine;
				}
			}
			else
			{
				// buy
				int index = 0;
				foreach (Equipment eEquip in storeEquipment)
				{
					if (GameTeams[team].getCurrency > eEquip.ePrice && eEquip.eType == "Armour" && PurchaseUgrade)
					{
						GameTeams[team].getCurrency -= eEquip.ePrice;
						getGameCurrency += eEquip.ePrice;
						shopper.getEquipArmour = eEquip;
						storeEquipment.RemoveAt(index);
						getFightLog = Environment.NewLine + "### " + GameTeams[team].getName + " " + shopper.getName + " purchased -" + String.Format("({0:n0}) ", eEquip.ePrice) + Environment.NewLine + "  " + eEquip.ToString() + Environment.NewLine;
						break;
					}
					index++;
				}
			}
		}
		public void buildingMaintenance()
		{
			int MaintCost = 0;

			switch (RndVal.Next(100))
			{
				case 2:
				case 3:
					if (ArenaLvlMaint > 0)
					{
						// Arena Maintenance
						MaintCost = RndVal.Next(ArenaLvlMaint--);
						getGameCurrency -= MaintCost;
						getFightLog = Environment.NewLine + "*** Arena maintenance cost " + String.Format("{0:n0}", MaintCost) + Environment.NewLine;
					}
					break;
				case 6:
				case 7:
					if (MonsterDenLvlMaint > 0)
					{
						// Monster Den Maintenance
						MaintCost = RndVal.Next(MonsterDenLvlMaint--);
						getGameCurrency -= MaintCost;
						getFightLog = Environment.NewLine + "*** Monster den maintenance cost " + String.Format("{0:n0}", MaintCost) + Environment.NewLine;
					}
					break;
				case 9:
				case 10:
					if (ShopLvlMaint > 0)
					{
						// Shop Maintenance
						MaintCost = RndVal.Next(ShopLvlMaint--);
						getGameCurrency -= MaintCost;
						getFightLog = Environment.NewLine + "*** Shop maintenance cost " + String.Format("{0:n0}", MaintCost) + Environment.NewLine;
					}
					break;

				case 12:
				case 13:
					if (ResearchDevMaint > 0)
					{
						// Research and Development Maintenance
						MaintCost = RndVal.Next(ResearchDevMaint--);
						getGameCurrency -= MaintCost;
						getFightLog = Environment.NewLine + "*** Research and Development maintenance cost " + String.Format("{0:n0}", MaintCost) + Environment.NewLine;
					}
					break;
				case 20:
				case 21:
					// Tax
					MaintCost = (int)((ArenaLvlMaint* 0.1) + (MonsterDenLvlMaint * 0.1) + (ShopLvlMaint * 0.1));
					getGameCurrency -= MaintCost;
					getFightLog = Environment.NewLine + "*** Taxes cost " + String.Format("{0:n0}", MaintCost )+ Environment.NewLine;
					break;
				case 95:
				case 96:
				case 97:
				case 98:
					if (ShopStock > storeEquipment.Count && getGameCurrency <= 0)
					{
						getFightLog = Environment.NewLine + "!!! Free stock " + Environment.NewLine;
						storeEquipment.Add(new Equipment(5, 100));
					}
					break;
				case 99:
					MaintCost += MaxTeams * getArenaLvl * 1000;
					getGameCurrency += MaintCost;
					getFightLog = Environment.NewLine + "*** Received a sponsor! +" + String.Format("{0:n0}", MaintCost) + Environment.NewLine;
					break;
			}
		}

        public void getNext()
        {
			// get robo that is attacking
			Robot Attacker = GameTeam1.MyTeam[0];
			int maxSpeed = 0;
			int team = 1;
			foreach  (Robot eRobot in GameTeam1.MyTeam)
			{
				if ((eRobot.getCurrentSpeed > maxSpeed || (eRobot.getCurrentSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					Attacker = eRobot;
					maxSpeed = eRobot.getCurrentSpeed;
				}
			}
			foreach (Robot eRobot in GameTeam2.MyTeam)
			{
				if ((eRobot.getCurrentSpeed > maxSpeed || (eRobot.getCurrentSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					team = 2;
					Attacker = eRobot;
					maxSpeed = eRobot.getCurrentSpeed;
				}
			}
			Attacker.setStrike();
			Attacker.turnOver();
			if (team == 2)
			{
				Attack(Attacker, GameTeam2, GameTeam1);
			}
			else
			{
				Attack(Attacker, GameTeam1, GameTeam2);
			}
		}

        public void Attack(Robot attacker, Team attackers, Team defenders)
        {
			Robot defender = new Robot(1, "test", 1, false);
			// Loop through attackers strategies
			foreach (Strategy currStrategy in  attacker.RoboStrategy)
			{
				if (currStrategy.StrategicSkill.target == "Enemy")
				{
					if (currStrategy.StrategicSkill.type == "Single attack")
					{
						// check if conditions are met to use skill
						switch (currStrategy.FieldCondition)
						{
							case "Num Enemies":
								if (currStrategy.Condition == "Greater than")
								{
									if (defenders.getNumRobos() > currStrategy.ConditionValue)
									{
										// loop through defenders
										foreach (Robot eDefender in defenders.MyTeam)
										{
											// decide which one is being attacked
											switch (currStrategy.Field)
											{
												case "HP":
													if (currStrategy.Focus == "Lowest")
													{
														if (defender.HP > eDefender.HP || defender.getName == "test")
														{
															if (eDefender.HP > 0)
																defender = eDefender;
														}
													}
													if (currStrategy.Focus == "Highest")
													{
														if (defender.HP < eDefender.HP || defender.getName == "test")
														{
															if (eDefender.HP > 0)
																defender = eDefender;
														}
													}
													break;
												case "Level":
													if (currStrategy.Focus == "Current")
													{
														if ((eDefender.getLevel >= attacker.getLevel && (eDefender.getLevel < defender.getLevel || defender.getLevel < attacker.getLevel)) || defender.getName == "test")
														{
															if (eDefender.HP > 0)
																defender = eDefender;
														}
													}
													break;
											}
										}
									}
								}
								break;
						}
					}
				}
			}
			defender.damage(attacker);
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Team : Common
    {
		[JsonProperty]
		public IList<Robot> MyTeam;
		[JsonProperty]
		private int Score;
		private int ScoreLog;
		[JsonProperty]
		private int GoalScore;
		[JsonProperty]
		private int Currency;
		private int CurrencyLog;
		[JsonProperty]
		private int Difficulty;
		private int DifficultyLog;
		[JsonProperty]
		private int MaxRobo;
		[JsonProperty]
		private int RoboCost;
		[JsonProperty]
		private string TeamName;
		public Boolean isMonster;
		
		public int getAvailableRobo
		{
			get
			{
				return MaxRobo - MyTeam.Count;
			}
			set { MaxRobo = value; }
		}
		public int getScore
		{
			get
			{
				return Score;
			}
			set
			{
				ScoreLog += value - Score;
				Score = value;
				if (Score >= GoalScore)
				{
					GoalScore *= 2;
					GoalScore = roundValues(GoalScore);
					MaxRobo++;
				}
			}
		}
		public int getGoalScore
		{
			get { return GoalScore; }
			set { GoalScore = value; }
		}
		public int getCurrency
		{
			set
			{
				CurrencyLog += value - Currency;
				Currency = value;
			}
			get
			{
				return Currency;
			}
		}
		public int getDifficulty
		{
			set
			{
				int tmp = value;
				if (tmp > 0)
					DifficultyLog += value - Difficulty;
				Difficulty = value;
			}
			get
			{
				return Difficulty;
			}
		}
		public int getMaxRobos
		{
			get { return MaxRobo; }
			set { MaxRobo = value; }
		}
		public int getRoboCost
		{
			get { return RoboCost; }
			set { RoboCost = value; }
		}
		public String getName
		{
			get { return TeamName; }
			set { TeamName = value; }
		}
		public IList<Robot> getRobo
		{
			get { return MyTeam; }
			set { MyTeam = value; }
		}

		public Team(int pScore, int pGoalScore, int pCurrency, int pDifficulty, int pMaxRobo, int pRoboCost, string pTeamName)
		{
			MyTeam = new List<Robot> { };
			Score = pScore;
			Currency = pCurrency;
			Difficulty = pDifficulty;
			GoalScore = pGoalScore;
			MaxRobo = pMaxRobo;
			RoboCost = pRoboCost;
			TeamName = pTeamName;
			isMonster = false;
			TeamName = pTeamName;
		}

		public Team(bool isNew)
        {
            MyTeam = new List<Robot> { new Robot(1,setName(true), RndVal.Next(8), false) };
            Score = 0;
			Difficulty = 1;
            GoalScore = 20;
            MaxRobo = 1;
			RoboCost = 100;
			isMonster = false;
            TeamName = name1[RndVal.Next(name1.Length)] + " " + name3[RndVal.Next(name3.Length)];
        }
        public Team(int numMonsters, int Difficulty, int MonsterLvl)
        {
			if (Difficulty < 1)
				Difficulty = 1;
            MyTeam = new List<Robot> { };
			for (int i = 0; i < numMonsters; i++)
			{
				int Monster = RndVal.Next(MonsterLvl); 
				MyTeam.Add(new Robot((Difficulty / 3),setName(false, Monster), Monster, true));
				int minLvl = Difficulty - i > 0 ? Difficulty - i : 1;
				int lvl = RndVal.Next((int)((minLvl)*0.8),minLvl);
				for (int ii = 1; ii < lvl; ii++)
				{
					MyTeam[i].levelUp();
					MyTeam[i].HP = MyTeam[i].getTHealth();
					MyTeam[i].MP = MyTeam[i].getTEnergy();
				}
			}
			resetLogs();
            Score = 0;
            GoalScore = 0;
            MaxRobo = 0;
			RoboCost = 0;
			isMonster = true;
            TeamName = name1[RndVal.Next(name1.Length)] + " " + name2[RndVal.Next(name2.Length)];
		}

		public void rename(string newName)
		{
			getName = newName;
		}

		public void resetLogs()
		{
			CurrencyLog = 0;
			DifficultyLog = 0;
			ScoreLog = 0;
			foreach (Robot eRobo in MyTeam) { eRobo.resetLog(); }
		}

		public string getTeamStats(string team1, string Team2)
		{
			string strStats = "";
			if (getName != team1 && getName != Team2)
			{
				strStats += getName.PadRight(10);
				strStats += " C: " + String.Format("{0:n0}", Currency) + " (" + String.Format("{0:n0}", CurrencyLog) + ")";
				strStats += " S: " + String.Format("{0:n0}", Score) + " (" + String.Format("{0:n0}", ScoreLog) + ")";
				strStats += " D: " + String.Format("{0:n0}", Difficulty) + " (" + String.Format("{0:n0}", DifficultyLog) + ")";
				foreach (Robot eRobo in MyTeam)
				{
					strStats += eRobo.getRoboStats();
				}
			}
			return strStats;
		}
				
		public void fixTech()
		{
			
		}
		public void Rebuild(int robo)
		{
			MyTeam[robo] = new Robot((MyTeam[robo].getLevel / 5 == 0 ? 1 : MyTeam[robo].getLevel / 5), setName(true), RndVal.Next(8), false);
		}
		public int getNumRobos()
		{
			int num = 0;
			foreach (Robot robo in MyTeam)
			{
				if (robo.HP > 0)
					num++;
			}
			return num;
		}
		public Boolean healRobos(int cost, int value)
		{
			
			Boolean fullHP = true;
			foreach (Robot robo in MyTeam)
			{
				if (robo.HP < robo.getTHealth())
				{
					while (getCurrency < cost && cost > 0)
					{
						cost--;
						value--;
					}
					getCurrency -= cost;
					robo.HP += value;
					robo.MP += value;
					robo.getKO = 0;
				}
				if (robo.HP < robo.getTHealth()) { fullHP = false; }
				// level up
				if (robo.getAnalysisLeft() <= 0) { robo.levelUp(); }
			}
			return fullHP;
		}
		public string setName(Boolean isRobo)
		{
			return setName(isRobo, 0);
		}
		
		public string setName(Boolean isRobo, int MonsterLevel)
        {
            string name = "";
            if (isRobo)
            {
                name = (RoboName[RndVal.Next(RoboName.Length)] + RndVal.Next(1000).ToString());
            }
            else
            {
                name = (MonsterName[MonsterLevel]);
            }
            return name;
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Robot : Common
	{
		public Skill[] ListSkills = {
			new Skill("Attack", "Enemy", 1, "Single attack")
		};
		public IList<Strategy> RoboStrategy;
		[JsonProperty]
		private Equipment EquipWeapon;
		[JsonProperty]
		private Equipment EquipArmour;
		[JsonProperty]
		private string RobotName;
		public string tmpMessage;
		// Base stats
		[JsonProperty]
		private int Dexterity;
		[JsonProperty]
		private int Strength;
		[JsonProperty]
		private int Agility;
		[JsonProperty]
		private int Tech;
		[JsonProperty]
		private int Accuracy;
		// elevated stats (based on level, base stats, and equipment)
		[JsonProperty]
		private int Health;
		private int CurrentHealth;
		private int CountKO;
		[JsonProperty]
		private int Energy;
        private int CurrentEnergy;
		[JsonProperty]
		private int Armour;
		[JsonProperty]
		private int Damage;
		[JsonProperty]
		private int Hit;
		[JsonProperty]
		private int MentalStrength;
		[JsonProperty]
		private int MentalDefense;
		[JsonProperty]
		private string Image;
        private string tmpImage;
		[JsonProperty]
		private int Speed;
		private int CurrentSpeed;
		[JsonProperty]
		private int Level;
		private int LevelLog;
		[JsonProperty]
		private int Analysis;
		[JsonProperty]
		private int CurrentAnalysis;
		private int AnalysisLog;
		public String getName
		{
			get { return RobotName; }
			set { RobotName = value; }
		}
		public int getDexterity
		{
			set { Dexterity = value; }
			get { return Dexterity; }
		}
		public int getStrength
		{
			set { Strength = value; }
			get { return Strength; }
		}
		public int getAgility
		{
			set { Agility = value; }
			get { return Agility; }
		}
		public int getTech
		{
			set { Tech = value; }
			get { return Tech; }
		}
		public int getAccuracy
		{
			set { Accuracy = value; }
			get { return Accuracy; }
		}
		public int getHealth
		{
			get { return Health; }
			set { Health = value; }
		}
		public int HP
		{
			get { return CurrentHealth; }
			set
			{
				if (value > getTHealth())
					CurrentHealth = getTHealth();
				else if (value <= 0)
					CurrentHealth = 0;
				else
					CurrentHealth = value;
			}
		}
		public int getEnergy
		{
			get { return Energy; }
			set { Energy = value; }
		}
		public int MP
		{
			get { return CurrentEnergy; }
			set
			{
				if (value > getTEnergy())
					CurrentEnergy = getTEnergy();
				else if (value < 0)
					CurrentEnergy = 0;
				else
					CurrentEnergy = value;
			}
		}
		public int getArmour
		{
			get { return Armour; }
			set { Armour = value; }
		}
		public int getDamage
		{
			get { return Damage; }
			set { Damage = value; }
		}
		public int getHit
		{
			get { return Hit; }
			set { Hit = value; }
		}
		public int getMentalStrength
		{
			get { return MentalStrength; }
			set { MentalStrength = value; }
		}
		public int getMentalDefense
		{
			get { return MentalDefense; }
			set { MentalDefense = value; }
		}
		public int getSpeed
		{
			get { return Speed; }
			set { Speed = value; }
		}
		public string getImage
		{
			get
			{
				string tmp = Image;
				if (HP == 0)
				{
					getKO++;
					tmp = KO;
				}
				else if (tmpImage.Length > 0)
				{
					tmp = tmpImage;
					tmpImage = "";
				}
				return tmp;
			}
			set { Image = value; }
		}
		public string getRobotImage
		{
			get { return Image; }
			set { Image = value; }
		}
		public int getCurrentSpeed
		{
			get
			{
				int tmp = CurrentSpeed;
				if (CurrentSpeed <= 0)
				{
					CurrentSpeed = RndVal.Next(1,getTSpeed() * 10);
				}
				return tmp;
			}
		}
		public int getLevel
		{
			get { return Level; }
			set { Level = value; }
		}
		public int getCurrentAnalysis
		{
			set
			{
				AnalysisLog += value - CurrentAnalysis;
				CurrentAnalysis = value;
			}
			get { return CurrentAnalysis; }
		}
		public int getAnalysis
		{
			get { return Analysis; }
			set { Analysis = value; }
		}
		public int getKO
		{
			set { CountKO = value; }
			get { return CountKO; }
		}
		public String message
		{
			get
			{
				string tmp = tmpMessage;
				tmpMessage = "";
				return tmp;
			}
			set { tmpMessage = value; }
		}
		public Equipment getEquipWeapon
		{
			get { return EquipWeapon; }
			set { EquipWeapon = value; }
		}
		public Equipment getEquipArmour
		{
			get { return EquipArmour; }
			set { EquipArmour = value; }
		}
		public Robot(string pRobotName, int pDexterity, int pStrength, int pAgility, int pTech, int pAccuracy, int pHealth, int pEnergy, int pArmour, int pDamage, int pHit, int pMentalStrength, int pMentalDefense, 
			string pImage, int pSpeed, int pLevel, int pAnalysis, int pCurrentAnalysis)
		{
			getName = pRobotName;
			Analysis = pAnalysis;
			CurrentAnalysis = pCurrentAnalysis;
			Level = pLevel;
			message = "";
			Image = pImage;
			RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Current", "Level") };
			tmpImage = "";
			Dexterity = pDexterity;
			Strength = pStrength;
			Agility = pAgility;
			Tech = pTech;
			Accuracy = pAccuracy;
			Health = pHealth;
			Energy = pEnergy;
			Armour = pArmour;
			Damage = pDamage;
			Hit = pHit;
			Speed = pSpeed;
			CurrentSpeed = 0;
			MentalStrength = pMentalStrength;
			MentalDefense = pMentalDefense;
			CurrentHealth = getTHealth();
			CurrentEnergy = getTEnergy();

		}
		public Robot(bool isNew) : this(1, "test", 1, true) { }
		public Robot(string strName, int RoboImage, Boolean isMonster) : this(10, strName, RoboImage, isMonster) { }
		// New Robot object
		public Robot(int iBasePoints, string strName, int imageIndex, Boolean isMonster)
		{
			int RandomValue = 0;
			getName = strName;
			Analysis = 90;
			CurrentAnalysis = 0;
			Level = 0;
			message = "";
			if (isMonster)
			{
				Image = MonsterImages[imageIndex];
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Highest", "HP") };
			}
			else
			{
				Image = RoboImages[imageIndex];
				//RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Lowest", "HP") };
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Current", "Level") };
			}
			tmpImage = "";
			Dexterity = 1;
			Strength = 1;
			Agility = 1;
			Tech = 1;
			Accuracy = 1;
			iBasePoints -= 5; // Already distributed five points. 
			for (int i = iBasePoints; i > 0; i--)
			{
				// Random 
				RandomValue = RndVal.Next(1,6);
				// Case statement to set values
				switch (RandomValue)
				{
					case 1:
						Dexterity++;
						break;
					case 2:
						Strength++;
						break;
					case 3:
						Agility++;
						break;
					case 4:
						Tech++;
						break;
					case 5:
						Accuracy++;
						break;
				}
			}
			// Set elevated stats based on base stats
			Health = Dexterity + Strength + Agility;
			Energy = Tech + Accuracy;
			Armour = Dexterity;
			Damage = Strength;
			Hit = Accuracy;
			Speed = Agility;
			CurrentSpeed = 0;
			MentalStrength = Tech;
			MentalDefense = Tech;
			levelUp();
			CurrentHealth = getTHealth();
			CurrentEnergy = getTEnergy();
		}


		public int getTHealth()
		{
			int retVal = Health;
			if (EquipArmour != null) { retVal += EquipArmour.eHealth; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eHealth; }
			return retVal;
		}
		public int getTEnergy()
		{
			int retVal = Energy;
			if (EquipArmour != null) { retVal += EquipArmour.eEnergy; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eEnergy; }
			return retVal;
		}
		public int getTArmour()
		{
			int retVal = Armour;
			if (EquipArmour != null) { retVal += EquipArmour.eArmour; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eArmour; }
			return retVal;
		}
		public int getTDamage()
		{
			int retVal = Damage;
			if (EquipArmour != null) { retVal += EquipArmour.eDamage; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eDamage; }
			return retVal;
		}
		public int getTHit()
		{
			int retVal = Hit;
			if (EquipArmour != null) { retVal += EquipArmour.eHit; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eHit; }
			return retVal;
		}
		public int getTMentalStrength()
		{
			int retVal = MentalStrength;
			if (EquipArmour != null) { retVal += EquipArmour.eMentalStrength; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eMentalStrength; }
			return retVal;
		}
		public int getTMentalDefense()
		{
			int retVal = MentalDefense;
			if (EquipArmour != null) { retVal += EquipArmour.eMentalDefense; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eMentalDefense; }
			return retVal;
		}
		public int getTSpeed()
		{
			int retVal = Speed;
			if (EquipArmour != null) { retVal += EquipArmour.eSpeed; }
			if (EquipWeapon != null) { retVal += EquipWeapon.eSpeed; }
			return retVal;
		}

		public void fixTech()
		{
			RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Current", "Level") };
		}

		public void resetLog()
		{
			LevelLog = 0;
			AnalysisLog = 0;
		}

		public string getRoboStats()
		{
			string strStats = Environment.NewLine + "   " + getName.PadRight(8) + " L:" + getLevel.ToString().PadLeft(2) + " (" + LevelLog + ")";
			strStats += " A: " + String.Format("{0:n0}", getAnalysisLeft()).PadLeft(3) + " (" + String.Format("{0:n0}", AnalysisLog).PadLeft(3) + ")";
			strStats += " HP: " + String.Format("{0:n0}", HP).PadLeft(3);
			return strStats;
		}
		public int rebuildCost()
		{
			int cost = 0;
			// if base stats will go up add cost
			if (Level / 5 > (Dexterity + Strength + Agility + Tech + Accuracy) )
			{
				cost = 100 * (int)Math.Pow(2,(Level / 5));
			}
			return cost;
		}
		
        public void setStrike()
        {
            tmpImage = strike;
		}
		public void setHurt()
		{
			tmpImage = hurt;
		}
		public void setBlock()
		{
			tmpImage = blocked;
		}
		public void setMiss()
		{
			tmpImage = miss;
		}
		
		public long getAnalysisLeft()
		{
				return (Analysis - CurrentAnalysis);
		}
		public void turnOver()
        {
			if (CurrentSpeed >= 1)
			{
				CurrentSpeed = RndVal.Next(0, (CurrentSpeed / 2));
			}
		}
		public void rename(string newName)
		{
			getName = newName;
		}
		public void levelUp()
		{
			LevelLog++;
			Level++;
			Analysis += RndVal.Next(10);
			CurrentAnalysis = 0;
			Health += Dexterity + Strength + Agility;
			Energy += Tech + Accuracy;
			Armour += Dexterity;
			Damage += Strength;
			Hit += Accuracy;
			Speed += Agility;
			MentalStrength += Tech;
			MentalDefense += Tech;
		}

		public void damage(Robot attacker)
		{
			// If agility greater than hit attacker missed
			if (RndVal.Next(getTSpeed()) > RndVal.Next(attacker.getTHit()))
			{
				setMiss();
			}
			// if armour greater than strength attack is blocked
			else if (RndVal.Next(getTArmour()) > RndVal.Next(attacker.getTHit()))
			{
				setBlock();
			}
			// damaged
			else
			{
				setHurt();
				int dmg = RndVal.Next(1, attacker.getTDamage());
				HP -= dmg;
				message = dmg.ToString() + " dmg!";
				if (EquipArmour != null)
				{
					EquipArmour.eDurability--;
					if (EquipArmour.eDurability == 0)
					{
						message += Environment.NewLine + EquipArmour.eName + " broke!";
						EquipArmour = null;
					}
				}
				if (attacker.EquipWeapon != null)
				{
					attacker.EquipWeapon.eDurability--;
					if (attacker.EquipWeapon.eDurability == 0)
					{
						attacker.message += attacker.EquipWeapon.eName + " broke!";
						attacker.EquipWeapon = null;
					}
				}
				// get experience if attackers level is not higher
				if (attacker.getLevel <= getLevel)
				{
					attacker.getCurrentAnalysis+= getLevel - attacker.getLevel + 1;
					if (HP == 0) { attacker.getCurrentAnalysis += 10; }
				}
				// if attacker is higher level, get less exp
				else if (RndVal.Next(100) > 80)
				{
					attacker.getCurrentAnalysis++;
				}
			}
		}
        public override string ToString()
        {
            string tmp = "";
			int wHealth = 0;
			int wEnergy = 0;
			int wArmour = 0;
			int wDamage = 0;
			int wHit = 0;
			int wSpeed = 0;
			int wMentalStr = 0;
			int wMentalDef = 0;
			int aArmour = 0;
			int aDamage = 0;
			int aHealth = 0;
			int aEnergy = 0;
			int aHit = 0;
			int aSpeed = 0;
			int aMentalStr = 0;
			int aMentalDef = 0;
			if (EquipWeapon != null)
			{
				tmp += (EquipWeapon.eName + String.Format(" (Dur:{0:n0}/{1:n0})", EquipWeapon.eDurability, EquipWeapon.eMaxDurability) + Environment.NewLine + 
					String.Format("+{0:n0}", EquipWeapon.eUpgradeCost) + Environment.NewLine);
				wHealth = EquipWeapon.eHealth;
				wEnergy = EquipWeapon.eEnergy;
				wArmour = EquipWeapon.eArmour;
				wDamage = EquipWeapon.eDamage;
				wHit = EquipWeapon.eHit;
				wSpeed = EquipWeapon.eSpeed;
				wMentalStr = EquipWeapon.eMentalStrength;
				wMentalDef = EquipWeapon.eMentalDefense;
			}
			if (EquipArmour != null)
			{
				tmp += (EquipArmour.eName + String.Format(" (Dur:{0:n0}/{1:n0})", EquipArmour.eDurability, EquipArmour.eMaxDurability) + Environment.NewLine
					+ String.Format("+{0:n0}", EquipArmour.eUpgradeCost) + Environment.NewLine);
				wHealth = EquipArmour.eHealth;
				wEnergy = EquipArmour.eEnergy;
				aArmour = EquipArmour.eArmour;
				aDamage = EquipArmour.eDamage;
				aHit = EquipArmour.eHit;
				aSpeed = EquipArmour.eSpeed;
				aMentalStr = EquipArmour.eMentalStrength;
				aMentalDef = EquipArmour.eMentalDefense;
			}
			tmp += ("*Base Stats*"						+ Environment.NewLine);
			tmp += ("Level:     " +	Level				+ Environment.NewLine);
			tmp += ("Dexterity: " + Dexterity			+ Environment.NewLine);
			tmp += ("Strength:  " + Strength            + Environment.NewLine);
            tmp += ("Agility:   " + Agility             + Environment.NewLine);
            tmp += ("Tech:      " + Tech				+ Environment.NewLine);
			tmp += ("Accuracy:  " + Accuracy			+ Environment.NewLine);
			tmp += ("*Elevated Stats*"					+ Environment.NewLine);
			tmp += ("Health:    " + String.Format("{0:n0}", HP) + "/" + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Health, wHealth, aHealth, getTHealth())   + Environment.NewLine);
            tmp += ("Energy:    " + String.Format("{0:n0}", MP) + "/" + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Energy, wEnergy, aEnergy, getTEnergy())   + Environment.NewLine);
            tmp += ("Armour:    " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Armour, wArmour, aArmour, getTArmour())						+ Environment.NewLine);
            tmp += ("Damage:    " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Damage, wDamage, aDamage, getTDamage() )						+ Environment.NewLine);
			tmp += ("Hit:       " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Hit, wHit, aHit, getTHit())									+ Environment.NewLine);
			tmp += ("Speed:     " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", Speed, wSpeed, aSpeed, getTSpeed())							+ Environment.NewLine);
			tmp += ("MentalStr: " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", MentalStrength, wMentalStr, aMentalStr, getTMentalStrength())  + Environment.NewLine);
			tmp += ("MentalDef: " + String.Format("{3:n0} {0:n0}+{1:n0}+{2:n0}", MentalDefense, wMentalDef, aMentalDef, getTMentalDefense())	+ Environment.NewLine);
			tmp += ("Analysis:  " + String.Format("{0:n0}", getAnalysisLeft()) + Environment.NewLine);
			return tmp;
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Skill
    {
        public string name;
        public string target; // Enemy or Ally
        public int strength; // int representing amount of damage / healing 
        public string type; // healing single, healing multiple, damage single, or damage multiple
		public int cost; // energy cost
		public Skill() { }
        public Skill(string skillName, string skillTarget, int skillStrength, string skilltype)
        {
            name = skillName;
            target = skillTarget;
            strength = skillStrength;
            type = skilltype;
			cost = 0;
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Strategy
	{
		public Skill StrategicSkill; //skill to be used
		public string FieldCondition; // HP, MP, number of target
		public string Condition; // > or <
		public int ConditionValue; // a percentage or value
		public string Focus; // Lowest or Highest
		public string Field; // HP, MP, Str, Spirit, Speed, etc
		public Strategy() { }
		public Strategy(Skill pSkill, string pFieldCondition, string pCondition, int pConditionValue, string pFocus, string pField)
		{
			StrategicSkill = pSkill;
			FieldCondition = pFieldCondition;
			Condition = pCondition;
			ConditionValue = pConditionValue;
			Focus = pFocus;
			Field = pField;
		}
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class ArenaSeating
	{
		[JsonProperty]
		public int Level; //Seating Level
		[JsonProperty]
		public int Price; // Cost of customers for seat
		[JsonProperty]
		public int Amount; // Number of seats
		public ArenaSeating() { }
		public ArenaSeating(int pLevel, int pPrice, int pAmount)
		{
			Level = pLevel;
			Price = pPrice;
			Amount = pAmount;
		}
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Equipment : Common
	{
		public string eType = "";
		public string eName = "";
		public int eHealth = 0;
		public int eEnergy = 0;
		public int eArmour = 0;
		public int eDamage = 0;
		public int eHit = 0;
		public int eMentalStrength = 0;
		public int eMentalDefense = 0;
		public int eSpeed = 0;
		public int ePrice = 0;
		public int eDurability = 0;
		public int eMaxDurability = 0;
		public int eUpgradeCost = 0;
		public Equipment(int value, int durability)
		{
			int Type = RndVal.Next(1, 9);
			switch (Type)
			{
				case 1:
					eType = "Weapon";
					eName = "Blade";
					eDamage = value;
					break;
				case 2:
					eType = "Weapon";
					eName = "Claws";
					eHit = value;
					break;
				case 3:
					eType = "Weapon";
					eName = "Rod";
					eMentalStrength = value;
					break;
				case 4:
					eType = "Weapon";
					eName = "Ramp";
					eHealth = value;
					break;
				case 5:
					eType = "Armour";
					eName = "Iron";
					eArmour = value;
					break;
				case 6:
					eType = "Armour";
					eName = "Leather";
					eSpeed = value;
					break;
				case 7:
					eType = "Armour";
					eName = "Lab Coat";
					eMentalDefense = value;
					break;
				case 8:
					eType = "Armour";
					eName = "Field";
					eEnergy = value;
					break;
			}
			eMaxDurability = eDurability = durability;
			eUpgradeCost = ePrice = (value * 10) + durability;
		}
		public Equipment(string pType, string pName, int pHealth, int pEnergy, int pArmour, int pDamage, int pHit, int pMentalStrength, int pMentalDefense, int pSpeed, int pPrice, int pDurability, int pMaxDurability, int pUpgradeCost)
		{
			eType = pType;
			eName = pName;
			eHealth = pHealth;
			eEnergy = pEnergy;
			eArmour = pArmour;
			eDamage = pDamage;
			eHit = pHit;
			eMentalStrength = pMentalStrength;
			eMentalDefense = pMentalDefense;
			eSpeed = pSpeed;
			ePrice = pPrice;
			eDurability = pDurability;
			eMaxDurability = pMaxDurability;
			eUpgradeCost = pUpgradeCost;
		}
		public void upgrade(int value)
		{
			int Type = RndVal.Next(1, 9);
			value = RndVal.Next(1, value);
			switch (Type)
			{
				case 1:
					eHealth += value;
					break;
				case 2:
					eEnergy += value;
					break;
				case 3:
					eDamage += value;
					break;
				case 4:
					eHit += value;
					break;
				case 5:
					eMentalStrength += value;
					break;
				case 6:
					eArmour += value;
					break;
				case 7:
					eSpeed += value;
					break;
				case 8:
					eMentalDefense += value;
					break;
			}
			eUpgradeCost += RndVal.Next(1, eUpgradeCost);
		}
		public override string ToString()
		{
			string retval = eName.PadRight(12);
			if (eHealth > 0)			{ retval += " HP+" + eHealth; }
			if (eEnergy > 0)			{ retval += " MP+" + eEnergy; }
			if (eDamage > 0)			{ retval += " dmg+" + eDamage; }
			if (eHit > 0)				{ retval += " hit+" + eHit; }
			if (eMentalStrength > 0)	{ retval += " mstr+" + eMentalStrength; }
			if (eArmour > 0)			{ retval += " ac+" + eArmour; }
			if (eSpeed > 0)				{ retval += " spd+" + eSpeed; }
			if (eMentalDefense > 0)		{ retval += " mdef+" + eMentalDefense; }
			retval += " Dur:" + eDurability;
			retval += " Price:" + ePrice;
			return retval;
		}
	}
}
