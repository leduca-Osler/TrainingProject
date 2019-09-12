using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;

namespace TrainingProject
{
	class Common
	{
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
		public int roundValues(int value)
		{
			if (value.ToString().Substring(0, 1) == "4")
			{
				value += (int)Math.Pow(10, value.ToString().Length - 1);
			}
			return value;
		}
	}
    [Serializable]
    class Game : Common
    {
        public Random RndVal = new Random();
        public IList<Team> GameTeams;
		public IList<ArenaSeating> Seating;
		public IList<Equipment> storeEquipment;
		public Team GameTeam1;
        public Team GameTeam2;
		public int MonsterCount;
		public int RoboCount;
		public int CurrentInterval;
		public int MaxInterval;
		public DateTime SafeTime;
		private int GoalScore;
        private int MaxTeams;
		private int TeamCost;
		private int Jackpot; // holds the credits to be divied out after a fight
		private int Currency;
		private int CurrencyLog;
        private Boolean fighting;
		private Boolean auto;
		private string FightLog;
		private int StoreLvl;
		private int StoreLvlCost;
		private int StoreLvlMaint;
		private int StoreStock;
		private int ArenaLvl;
		private int ArenaLvlCost;
		private int ArenaLvlMaint;
		private int MonsterDenLvl;
		private int MonsterDenLvlCost;
		private int MonsterDenLvlMaint;
		private int MonsterDenBonus;
		private int BlacksmithLvl;
		private int BlacksmithLvlCost;
		private int BlacksmithLvlMaint;
		private int ResearchDevLvl;
		private int ResearchDevCost;
		private int ResearchDevMaint;
		public string[] Weapons = { "Axe", "Blade", "Spear" };
		public string[] Armour = { "Iron", "Bronze", "Titanium" };
		// variables to determine if 
		private DateTime SedetaryTime;
		private bool Sedetary;

		public Game()
        {
            GameTeams = new List<Team> { new Team(RndVal), new Team(RndVal) };
			Seating = new List<ArenaSeating> { new ArenaSeating(1, 1, 50) };
            GoalScore = 100;
            MaxTeams = 2;
			TeamCost = 500;
			fighting = false;
			auto = false;
			FightLog = "";
			StoreLvl = 1;
			StoreLvlCost = 100;
			StoreLvlMaint = 1;
			StoreStock = 1;
			ArenaLvl = 1;
			ArenaLvlCost = 100;
			ArenaLvlMaint = 1;
			MonsterDenLvl = 1;
			MonsterDenLvlCost = 100;
			MonsterDenLvlMaint = 1;
			MonsterDenBonus = 1;
			BlacksmithLvl = 1;
			BlacksmithLvlCost = 100;
			BlacksmithLvlMaint = 1;
			ResearchDevLvl = 1;
			ResearchDevCost = 100;
			ResearchDevMaint = 1;
			MonsterCount = 0;
			RoboCount = 0;
			Sedetary = false;
			SedetaryTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			SafeTime = new DateTime();
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
			CurrencyLog = 0;
			foreach (Team eTeam in GameTeams)
			{
				eTeam.resetLogs();
			}
		}

		public void stretch()
		{
			Sedetary = false;
			SedetaryTime = DateTime.Now.AddMinutes(20);
		}

		public void interval(Timer Timer1)
		{
			// update sedetary time
			if (SedetaryTime < DateTime.Now)
			{
				Sedetary = true;
			}
			CurrentInterval++;
			if (CurrentInterval > MaxInterval)
			{
				CurrentInterval = 1000;
				MaxInterval++;
			}
			Timer1.Interval = CurrentInterval;
		}

		public int getMonsterDenBonus
		{
			get { return MonsterDenBonus; }
		}
		public int getMaxTeams
		{
			get { return MaxTeams; }
		}
		public int getMonsterDenLvlCost
		{
			get { return MonsterDenLvlCost; }
		}

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
		}
		public int getArenaLvlCost
		{
			get { return ArenaLvlCost; }
			set { ArenaLvlCost = value; }
		}

		public int getTeamCost
		{
			get { return TeamCost; }
			set { TeamCost = value; }
		}

		public void arenaLevelUp()
		{
			getCurrency -= ArenaLvlCost;
			ArenaLvlMaint = ArenaLvlCost;
			ArenaLvl++;
			ArenaLvlCost *= RndVal.Next(10);
			ArenaLvlCost = (int)Math.Round((double)ArenaLvlCost, ArenaLvlCost.ToString().Length-1);
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
			getCurrency -= MonsterDenLvlCost;
			MonsterDenLvlMaint = MonsterDenLvlCost;
			MonsterDenLvl++;
			MonsterDenLvlCost *= 2;
			MonsterDenLvlCost = roundValues(MonsterDenLvlCost);
			MonsterDenBonus += RndVal.Next(1, MonsterDenBonus);
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
		public int getArenaLvl
		{
			get
			{
				return ArenaLvl;
			}
		}
		public int getShopLvl
		{
			get
			{
				return StoreLvl;
			}
		}

        public string addTeam()
        {
			// calculate cost
			getCurrency -= TeamCost;
			TeamCost *= 2;
			TeamCost = roundValues(TeamCost);
			Team tmp = new Team( RndVal );
            GameTeams.Add(tmp);
            return tmp.getName;
        }
        public void addRobo(int Team)
        {
			GameTeams[Team].getCurrency -= GameTeams[Team].getRoboCost;
			GameTeams[Team].getRoboCost *= 2;
			GameTeams[Team].getRoboCost = roundValues(GameTeams[Team].getRoboCost);
			Robot tmp = new Robot(1,GameTeams[Team].setName(true), RndVal.Next(8), RndVal, false);
            GameTeams[Team].MyTeam.Add(tmp);
        }
        public int getScore()
        {
            int iTmpScore = 0;
            for (int i = 0; i < GameTeams.Count; i++) { iTmpScore += GameTeams[i].getScore; }
			if (iTmpScore >= GoalScore)
			{
				MaxTeams++;
				GoalScore *= 2;
				GoalScore = roundValues(GoalScore);
			}
			return iTmpScore;
		}
		public int getGoalScore
		{
			get
			{
				return GoalScore;
			}
		}
		public string getFightLog
		{
			set
			{
				if (FightLog.Length > 5000)
					FightLog = value + FightLog.Substring(1,1500);
				else
					FightLog = value + FightLog;
			}
			get
			{
				return FightLog;
			}
		}
		public int getAvailableTeams
        {
            get
            {
                return MaxTeams - GameTeams.Count;
            }
        }
		public Boolean Repair()
		{
			Boolean fullHP = true;
			foreach (Team eTeam in GameTeams)
			{
				Boolean tmpFullHP = true;
				tmpFullHP = eTeam.healRobos();
				if (tmpFullHP == false)
				{
					fullHP = false;
					eTeam.getCurrency -= eTeam.MyTeam.Count;
				}
			}
			return fullHP;
		}
        public void startFight()
        {
            fighting = true;
            int Team1Index = 0;
            int Team2Index = GameTeams.Count - 1;
			int Team1Score = RndVal.Next(GameTeams[0].getScore);
			int Team2Score = RndVal.Next(GameTeams[0].getScore);
            int tmpScore = 0;
			int PotScore = 0;
			for (int i = 1; i < GameTeams.Count; i++)
            {
                tmpScore = RndVal.Next(GameTeams[i].getScore);
                // if new score is lower than previous
                if (Team1Score > tmpScore)
                {
                    Team1Index = i;
                    Team1Score = tmpScore;
                }
            }
            GameTeam1 = GameTeams[Team1Index];
			PotScore = GameTeam1.getScore;
            for (int i = GameTeams.Count-1; i >= 0; i--)
            {
                tmpScore = RndVal.Next(GameTeams[i].getScore);
                if (Team2Score > tmpScore)
                {
                    Team2Index = i;
                    Team2Score = tmpScore;
                }
            }
			if (MonsterCount > 3)
			{
				Team2Index = RndVal.Next(GameTeams.Count - 1);
				MonsterCount = 0;
			}
			if (RoboCount > 3)
			{
				Team2Index = Team1Index;
				RoboCount = 0;
			}
            if (Team1Index == Team2Index)
            {
				MonsterCount++;
                // Monster team... 
                GameTeam2 = new Team(RndVal,GameTeam1.getDifficulty, getMonsterDenLvl);
            }
            else
            {
				RoboCount++;
                // Robo Team
                GameTeam2 = GameTeams[Team2Index];
				PotScore += GameTeam2.getScore;
			}
			PotScore += getMonsterDenBonus;
			string msg = "     Attendance: ";
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
			ProgressBar HP = new ProgressBar { Maximum = eRobo.getHealth, Value = eRobo.HP, Width = 50, Height = 5 };
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
		private void btnStretch_Click(object sender, EventArgs e)
		{
			stretch();
		}

		public FlowLayoutPanel showHeader()
		{
			FlowLayoutPanel HeaderPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			if (Sedetary)
			{
				Button btnSedetary = new Button { Text = "Stretch" };
				btnSedetary.Click += new EventHandler(btnStretch_Click);
				HeaderPanel.Controls.Add(btnSedetary);
			}
			ProgressBar Progress = new ProgressBar { Maximum = MaxInterval, Value = CurrentInterval, Minimum = 1000, Width = 200, Height = 10 };
			HeaderPanel.Controls.Add(Progress);
			Label lblTime = new Label { AutoSize = true, Text = "Time:  " + DateTime.Now.ToString("HH:mm") + " (" + SafeTime.ToString("HH:mm") + ")"};
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
				Label lblTeamName = new Label { AutoSize = true, Text = "Team Name:  " + GameTeams[TeamSelect - 1].getName };
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + GameTeams[TeamSelect - 1].getCurrency };
				Label lblScore = new Label { AutoSize = true, Text = "Score:      " + GameTeams[TeamSelect - 1].getScore + " (" + GameTeams[TeamSelect - 1].getGoalScore + ")"};
				Label lblRobots = new Label { AutoSize = true, Text = "Robots:     " + GameTeams[TeamSelect - 1].MyTeam.Count + "/" + GameTeams[TeamSelect - 1].getMaxRobos + " (" + GameTeams[TeamSelect - 1].getRoboCost + ")" };
				Label lblDifficulty = new Label { AutoSize = true, Text = "Difficulty: " +  GameTeams[TeamSelect - 1].getDifficulty };
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
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					Button btnRebuild = new Button { AutoSize = true, Text = "Rebuild (" + eRobo.rebuildCost() + ")" };
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
				Label lblTotalScore = new Label { AutoSize = true, Text = "Total Score: " + getScore() };
				Label lblTeams = new Label { AutoSize = true, Text = "Teams:       " + GameTeams.Count + "/" + getMaxTeams + " (" + getTeamCost + ")" };
				Label lblCurrency = new Label { AutoSize = true, Text = "Currency:    " + getCurrency };
				Label lblArenaLvl = new Label { AutoSize = true, Text = "Arena Level: " + getArenaLvl + " (" + getArenaLvlCost + ")" };
				FlowLayoutPanel pnlSeating = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				foreach (ArenaSeating eSeating in Seating)
				{
					Label lblArenaSeating = new Label { AutoSize = true, Text = "  Level: " + eSeating.Level + " Price " + eSeating.Price + " Seats " + eSeating.Amount };
					pnlSeating.Controls.Add(lblArenaSeating);
				}
				Label lblShopLvl = new Label { AutoSize = true, Text = "Shop:       " + getShopLvl };
				Label lblMonsterDen = new Label { AutoSize = true, Text = "Monster Den:" + getMonsterDenLvl + " (" + getMonsterDenLvlCost + ")   +" + getMonsterDenBonus };
				Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + Environment.NewLine + getFightLog };
				MainPanel.Controls.Add(lblTotalScore);
				MainPanel.Controls.Add(lblTeams);
				MainPanel.Controls.Add(lblCurrency);
				MainPanel.Controls.Add(lblArenaLvl);
				MainPanel.Controls.Add(pnlSeating);
				MainPanel.Controls.Add(lblShopLvl);
				MainPanel.Controls.Add(lblMonsterDen);
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
					Label lblGameStats = new Label { AutoSize = true, Text = "Currency: " + getCurrency + " (" + CurrencyLog + ")" };
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
					msg += " " + tmp ;
					// increase difficulty if monster
					if (GameTeam2.isMonster) { GameTeam1.getDifficulty++; }
					else
					{
						// increase score if another team
						GameTeam1.getScore++;
						// pay team 2 25%;
						tmp = (int)(Jackpot * .25);
						GameTeam2.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " (" + tmp + ")";
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
						msg += " (" + tmp +")";
					}
					else
					{
						// team won they get 40%
						int tmp = (int)(Jackpot * .4);
						GameTeam2.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " " + tmp;
						// team lost gets 25%
						tmp = (int)(Jackpot * .25);
						GameTeam1.getCurrency += tmp;
						Jackpot -= tmp;
						msg += " (" + tmp + ")";
					}
					msg = GameTeam2.getName + " Won against " + GameTeam1.getName + msg ;
				}
				getCurrency += Jackpot;
				getFightLog = msg + Environment.NewLine + "     Arena made " + Jackpot + " @ " + DateTime.Now.ToString() + Environment.NewLine;
				buildingMaintenance();
				Jackpot = 0;
				MainPanel.Controls.Add(lblWinner);
				fighting = false;
				
			}
			return MainPanel;
		}

		public void buildingMaintenance()
		{
			int MaintCost = 0;
			switch (RndVal.Next(100))
			{
				case 1:
				case 2:
				case 3:
					// Arena Maintenance
					MaintCost = RndVal.Next(ArenaLvlMaint);
					getCurrency -= MaintCost;
					getFightLog = "Arena maintenance cost " + MaintCost + Environment.NewLine;
					break;
				case 6:
				case 7:
				case 8:
					// Monster Den Maintenance
					MaintCost = RndVal.Next(MonsterDenLvlMaint);
					getCurrency -= MaintCost;
					getFightLog = "Monster den maintenance cost " + MaintCost + Environment.NewLine;
					break;
				case 11:
				case 12:
				case 13:
					// Tax
					MaintCost = (int)((ArenaLvlMaint* 0.1)+(MonsterDenLvlMaint * 0.1));
					getCurrency -= MaintCost;
					getFightLog = "Taxes cost " + MaintCost + Environment.NewLine;
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
				if ((eRobot.getSpeed > maxSpeed || (eRobot.getSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					Attacker = eRobot;
					maxSpeed = eRobot.getSpeed;
				}
			}
			foreach (Robot eRobot in GameTeam2.MyTeam)
			{
				if ((eRobot.getSpeed > maxSpeed || (eRobot.getSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					team = 2;
					Attacker = eRobot;
					maxSpeed = eRobot.getSpeed;
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
			Robot defender = new Robot(1, "test", 1, RndVal, false);
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
	class Team : Common
    {
        public string[] name1 = { "Green", "Blue", "Yellow", "Orange", "Black", "Pink", "Great", "Strong", "Cunning"};
		public string[] name2 = { "Sharks", "Octopuses", "Birds", "Foxes", "Wolfs", "Lions", "Rinos", };
		public string[] name3 = { "Blades", "Arrows", "Staffs", "Sparks", "Factory", "Snipers", "Calvary" };
		public string[] RoboName = { "Bolt", "Tink", "Hmr", "Golm", "Droi", "Trs", "Gun", "Rep", "Bot" };
		public string[] MonsterName = { "Devil", "Alien", "Slither", "Blob", "Bat", "Titan", "Chomp","Element", "HandEye" };
        public Random RndVal;
        public IList<Robot> MyTeam;
		private int Score;
		private int ScoreLog;
		private int Currency;
		private int CurrencyLog;
		private int Difficulty;
		private int DifficultyLog;
		private int GoalScore;
		private int MaxRobo;
		private int RoboCost;
        private string TeamName;
		public Boolean isMonster; 

        public Team(Random tmpRandom)
        {
            RndVal = tmpRandom;
            MyTeam = new List<Robot> { new Robot(1,setName(true), RndVal.Next(8), RndVal, false) };
            Score = 0;
			Difficulty = 1;
            GoalScore = 20;
            MaxRobo = 1;
			RoboCost = 100;
			isMonster = false;
            TeamName = name1[RndVal.Next(name1.Length)] + " " + name3[RndVal.Next(name3.Length)];
        }
        public Team(Random tmpRandom, int Difficulty, int MonsterLvl)
        {
			if (Difficulty < 1)
				Difficulty = 1;
            RndVal = tmpRandom;
			int numMonsters = RndVal.Next(1, (Difficulty > 3 ? Difficulty/3 : 1));
            MyTeam = new List<Robot> { };
			for (int i = 0; i < numMonsters; i++)
			{
				int Monster = RndVal.Next(MonsterLvl); 
				MyTeam.Add(new Robot((Difficulty / 3),setName(false, Monster), Monster, RndVal, true));
				int lvl = RndVal.Next(Difficulty);
				for (int ii = 1; ii < lvl; ii++)
				{
					MyTeam[i].levelUp();
					MyTeam[i].HP = MyTeam[i].getHealth;
					MyTeam[i].MP = MyTeam[i].getEnergy;
				}
			}
            Score = 0;
            GoalScore = 0;
            MaxRobo = 0;
			RoboCost = 0;
			isMonster = true;
            TeamName = name1[RndVal.Next(name1.Length)] + " " + name2[RndVal.Next(name2.Length)];
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
				strStats += getName;
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

		public int getRoboCost
		{
			get { return RoboCost; }
			set { RoboCost = value; }
		}
		public int getMaxRobos
		{
			get { return MaxRobo; }
		}
		
		public void fixTech()
		{
			
		}
		public void Rebuild(int robo)
		{
			MyTeam[robo] = new Robot((MyTeam[robo].getLevel / 5 == 0 ? 1 : MyTeam[robo].getLevel / 5), setName(true), RndVal.Next(8), RndVal, false);
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
		public Boolean healRobos()
		{
			Boolean fullHP = true;
			foreach (Robot robo in MyTeam)
			{
				robo.HP ++;
				robo.MP ++;
				robo.getKO = 0;
				if (robo.getAnalysisLeft() <= 0) { robo.levelUp(); }
				if (robo.HP < robo.getHealth) { fullHP = false; }
			}
			return fullHP;
		}
		public String getName
		{
			get
			{
				return TeamName;
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
		public int getGoalScore
        {
            get
            {
                return GoalScore;
            }
        }
        public int getAvailableRobo
        {
            get
            {
                return MaxRobo - MyTeam.Count;
            }
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
	class Robot : Common
	{
		public Skill[] ListSkills = {
			new Skill("Attack", "Enemy", 1, "Single attack")
		};
		public IList<Strategy> RoboStrategy;
		private Equipment EquipWeapon;
		private Equipment EquipArmour;
		public Random RndVal;
        private string RoboName;
		public string tmpMessage; 
        // Base stats
        private int Dexterity;
        private int Strength;
        private int Agility;
        private int Tech;
        private int Accuracy;
        // elevated stats (based on level, base stats, and equipment)
        private int Health;
		private int CurrentHealth;
		private int CountKO;
		private int Energy;
        private int CurrentEnergy;
        private int Armour;
        private int Damage;
		private int Hit;
		private int MentalStrength;
        private int MentalDefense;
        private string Image;
        private string tmpImage;
        private int Speed;
		private int CurrentSpeed;
		private int Level;
		private int LevelLog;
		private int Analysis;
		private int CurrentAnalysis;
		private int AnalysisLog;

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
			string strStats = Environment.NewLine + "   " + getName + " L:" + getLevel + " (" + LevelLog + ")";
			strStats += " A: " + String.Format("{0:n0}", getAnalysisLeft()) + " (" + String.Format("{0:n0}", AnalysisLog) + ")";
			strStats += " HP: " + String.Format("{0:n0}", HP);
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
		public String getName
		{
			get
			{
				return RoboName;
			}
		}
		public int getKO
		{
			set
			{
				CountKO = value;
			}
			get
			{
				return CountKO;
			}
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
        }
        public int MP
        {
            get
            {
                return CurrentEnergy;
            }

            set
            {
                if (value > Energy)
                    CurrentEnergy = Energy;
                else if (value < 0)
                    CurrentEnergy = 0;
                else
                    CurrentEnergy = value;
            }
        }
        public int HP
        {
            get
            {
				return CurrentHealth;
            }

            set
            {
				if (value > Health)
					CurrentHealth = Health;
				else if (value <= 0)
					CurrentHealth = 0;
				else
					CurrentHealth = value;
            }
		}
		public int getHealth
		{
			get
			{
				return Health;
			}
		}
		public int getEnergy
		{
			get
			{
				return Energy;
			}
		}
		public int getLevel
		{
			get
			{
				return Level;
			}
		}
		public int getSpeed
		{
			get
			{
				int tmp = CurrentSpeed;
				if (CurrentSpeed <= 0)
				{
					CurrentSpeed = RndVal.Next(Speed * 10);
				}
				return tmp;
			}
		}
		public int getExperience
		{
			set
			{
				AnalysisLog += value - CurrentAnalysis;
				CurrentAnalysis = value;
			}
			get
			{
				return CurrentAnalysis;
			}
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
        // New Robot object
        public Robot(int iBasePoints, string strName, int imageIndex, Random tmpRandom, Boolean isMonster)
        {
            RndVal = tmpRandom;
            int RandomValue = 0;
            RoboName = strName;
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
                RandomValue = RndVal.Next(5);
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
            CurrentHealth = Health;
            CurrentEnergy = Energy;
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
			if (RndVal.Next(Speed) > RndVal.Next(attacker.Hit))
			{
				setMiss();
			}
			// if armour greater than strength attack is blocked
			else if (RndVal.Next(Armour) > RndVal.Next(attacker.Hit))
			{
				setBlock();
			}
			// damaged
			else
			{
				setHurt();
				int dmg = RndVal.Next(1, attacker.Damage);
				HP -= dmg;
				message = dmg.ToString() + " dmg!";
				// get experience if attackers level is not higher
				if (attacker.getLevel <= getLevel)
				{
					attacker.getExperience+= getLevel - attacker.getLevel + 1;
					if (HP == 0) { attacker.getExperience += 10; }
				}
				// if attacker is higher level, get less exp
				else if (RndVal.Next(100) > 80)
				{
					attacker.getExperience++;
				}
			}
		}
        public Robot(string strName, int RoboImage, Random tmpRand, Boolean isMonster) : this(10, strName, RoboImage, tmpRand, isMonster) { }
        public override string ToString()
        {
            string tmp = "";
			tmp += ("*Base Stats*"						+ Environment.NewLine);
			tmp += ("Level:     " + Level				+ Environment.NewLine);
			tmp += ("Dexterity: " + Dexterity			+ Environment.NewLine);
			tmp += ("Strength:  " + Strength            + Environment.NewLine);
            tmp += ("Agility:   " + Agility             + Environment.NewLine);
            tmp += ("Tech:      " + Tech              + Environment.NewLine);
			tmp += ("Accuracy:  " + Accuracy			+ Environment.NewLine);
			tmp += ("*Elevated Stats*"					+ Environment.NewLine);
			tmp += ("Health:    " + HP + "/" + Health   + Environment.NewLine);
            tmp += ("Energy:    " + MP + "/" + Energy   + Environment.NewLine);
            tmp += ("Armour:    " + Armour              + Environment.NewLine);
            tmp += ("Damage:    " + Damage              + Environment.NewLine);
			tmp += ("Hit:       " + Hit					+ Environment.NewLine);
			tmp += ("Speed:     " + Speed				+ Environment.NewLine);
			tmp += ("MentalStr: " + MentalStrength      + Environment.NewLine);
			tmp += ("MentalDef: " + MentalDefense		+ Environment.NewLine);
			tmp += ("Analysis:  " + getAnalysisLeft() + Environment.NewLine);
			return tmp;
        }
	}
	[Serializable]
	class Skill
    {
        public string name;
        public string target; // Enemy or Ally
        public int strength; // int representing amount of damage / healing 
        public string type; // healing single, healing multiple, damage single, or damage multiple
		public int cost; // energy cost
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
	class Strategy
	{
		public Skill StrategicSkill; //skill to be used
		public string FieldCondition; // HP, MP, number of target
		public string Condition; // > or <
		public int ConditionValue; // a percentage or value
		public string Focus; // Lowest or Highest
		public string Field; // HP, MP, Str, Spirit, Speed, etc
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
	class ArenaSeating
	{
		public int Level; //Seating Level
		public int Price; // Cost of customers for seat
		public int Amount; // Number of seats
		public ArenaSeating(int pLevel, int pPrice, int pAmount)
		{
			Level = pLevel;
			Price = pPrice;
			Amount = pAmount;
		}
	}
	[Serializable]
	class Equipment
	{
		private int Health;
		private int Energy;
		private int Armour;
		private int Damage;
		private int Hit;
		private int MentalStrength;
		private int MentalDefense;
		private int Speed;
	}
}
