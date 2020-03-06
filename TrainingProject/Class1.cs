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
		[JsonIgnore]
		public static readonly Random RndVal = new Random();
		[JsonIgnore]
		public static string Globalmessage;
		[JsonProperty]
		public static int ResearchDevRebuild;
		[JsonIgnore]
		private string WarningLog;
		//public Random RndVal = new Random();
		[JsonIgnore]
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
		[JsonIgnore]
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
		[JsonIgnore]
		public static string strike = "Strike.jpg";
		[JsonIgnore]
		public static string pound = "Pound.jpg";
		[JsonIgnore]
		public static string scratch = "Pound.jpg"; // 
		[JsonIgnore]
		public static string shrapnel = "Shrapnel.png";
		[JsonIgnore]
		public static string slash = "Pound.jpg"; // 
		[JsonIgnore]
		public static string Electrode = "Electrode.png"; //
		[JsonIgnore]
		public static string elements = "Pound.jpg"; // 
		[JsonIgnore]
		public static string Laser = "Laser.png"; // 
		[JsonIgnore]
		public static string corosion = "Pound.jpg"; // 
		[JsonIgnore]
		public static string hurt = "Hurt.png";
		[JsonIgnore]
		public static string KO = "KO.jpg";
		[JsonIgnore]
		public static string miss = "dodge.png";
		[JsonIgnore]
		public static string blocked = "block.png";
		[JsonIgnore]
		public static string field = "ForceField.png"; // 
		[JsonIgnore]
		public static Skill[] AllSkills = {
			new Skill("Attack", "Enemy", 100, "Single attack", 0, strike, '*'),
			new Skill("Pound", "Enemy", 110, "Single attack", 2, pound, '#'),
			new Skill("Shrapnel", "Enemy", 20, "Multiple attack", 3, shrapnel, '%'),
			new Skill("Electrode", "Enemy", 110, "Single tech", 2, Electrode, '@'),
			new Skill("Laser", "Enemy", 20, "Multiple tech", 3, Laser, '^')
		};
		public static Skill[] MonsterSkills = {
			new Skill("Attack", "Enemy", 100, "Single attack", 0, strike, '*'),
			new Skill("Scratch", "Enemy", 110, "Single attack", 2, scratch, '#'),
			new Skill("Slash", "Enemy", 20, "Multiple attack", 3, slash, '%'),
			new Skill("Elements", "Enemy", 110, "Single tech", 2, elements, '@'),
			new Skill("Corosion", "Enemy", 20, "Multiple tech", 3, corosion, '^')
		};
		[JsonIgnore]
		public string[] name1 = { "Green", "Blue", "Yellow", "Orange", "Black", "Pink", "Great", "Strong", "Cunning" };
		[JsonIgnore]
		public string[] name2 = { "Sharks", "Octopuses", "Birds", "Foxes", "Wolfs", "Lions", "Rinos", };
		[JsonIgnore]
		public string[] name3 = { "Blades", "Arrows", "Staffs", "Sparks", "Factory", "Snipers", "Calvary" };
		[JsonIgnore]
		public string[] RoboName = { "Bolt", "Tinker", "Hammer", "Golem", "Droid", "Tank", "Gunner", "Blaster", "Bot" };
		[JsonIgnore]
		public string[] MonsterName = { "Devil", "Alien", "Slither", "Blob", "Bat", "Titan", "Chomp", "Element", "HandEye" };
		[JsonIgnore]
		public string[] BossName = { "Great", "Estemed", "Grand", "Large", "Strong", "Fast"};
		public string getWarningLog
		{
			set
			{
				if (WarningLog == null) WarningLog = "";
				if (WarningLog.Length > 1000)
					WarningLog = value + WarningLog.Substring(0, 500);
				else
					WarningLog = value + WarningLog;
			}
			get { return WarningLog; }
		}
		public void clearWarnings()
		{
			WarningLog = "";
		}
		public int SkipFour(int value)
		{
			if (value.ToString().Substring(0, 1) == "4")
			{
				value += (int)Math.Pow(10, value.ToString().Length - 1);
			}
			return value;
		}
		public int roundValue(int value)
		{
			int power = (int)Math.Pow(10, value.ToString().Length - 1);
			return (int)Math.Round((double)(value) / power) * power;
		}
		public int upgradeValue(int value, double factor)
		{
			int retval = value;
			int amt = RndVal.Next(1, (int)((value * factor) >= 1 ? (value * factor) : 1));
			int power = (int)Math.Pow(10, value.ToString().Length - 1);
			if (Math.Round((double)(amt + value) / power) * power > value)
				retval = (int)Math.Round((double)(amt + value) / power) * power;
			else
				retval = (amt + value);
			return retval;
		}
		public static string ToRoman(int number)
		{
			if (number < 1) return string.Empty;
			if (number >= 10000) return "A" + ToRoman(number - 10000);
			if (number >= 9000) return "MA" + ToRoman(number - 9000);
			if (number >= 5000) return "W" + ToRoman(number - 5000);
			if (number >= 4000) return "MW" + ToRoman(number - 4000);
			if (number >= 1000) return "M" + ToRoman(number - 1000);
			if (number >= 900) return "CM" + ToRoman(number - 900);
			if (number >= 500) return "D" + ToRoman(number - 500);
			if (number >= 400) return "CD" + ToRoman(number - 400);
			if (number >= 100) return "C" + ToRoman(number - 100);
			if (number >= 90) return "XC" + ToRoman(number - 90);
			if (number >= 50) return "L" + ToRoman(number - 50);
			if (number >= 40) return "XL" + ToRoman(number - 40);
			if (number >= 10) return "X" + ToRoman(number - 10);
			if (number >= 9) return "IX" + ToRoman(number - 9);
			if (number >= 5) return "V" + ToRoman(number - 5);
			if (number >= 4) return "IV" + ToRoman(number - 4);
			if (number >= 1) return "I" + ToRoman(number - 1);
			throw new ArgumentOutOfRangeException("something bad happened");
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
		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrtuvwxyz0123456789-_|";
			String tmp = new string(Enumerable.Repeat(chars, 1).Select(s => s[RndVal.Next(36)]).ToArray());
			tmp += new string(Enumerable.Repeat(chars, length-1).Select(s => s[RndVal.Next(s.Length)]).ToArray());
			return tmp;
		}
	}
    [Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Game : Common
	{
		[NonSerialized][JsonIgnore]
		public System.Windows.Forms.FlowLayoutPanel MainFormPanel;
		[JsonProperty]
		public IList<Team> GameTeams;
		[JsonProperty]
		public IList<ArenaSeating> Seating;
		public IList<ArenaSeating> CurrentSeating;
		[JsonProperty]
		public IList<Equipment> storeEquipment;
		public IList<Team> GameTeam1;
		public IList<Team> GameTeam2;
		public List<KeyValuePair<String, DateTime>> countdown;
		public Team MonsterOutbreak;
		public Team Bosses;
		private int findMonster;
		private int Numeral;
		private int maxNumeral;
		public int fightPercent;
		public int fightPercentMax;
		private int fightCount;
		public int ArenaOpponent1;
		public int ArenaOpponent2;
		public int ManagerHrs;
		public int ManagerCost;
		public int CurrentInterval;
		public int MaxInterval;
		public int FightBreak;
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
		[JsonIgnore]
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
		public int MonsterDenLvl;
		[JsonProperty]
		private int MonsterDenLvlCost;
		[JsonProperty]
		private int MonsterDenLvlMaint;
		[JsonProperty]
		private int MonsterDenBonus;
		[JsonProperty]
		public int MonsterDenRepairs;
		[JsonProperty]
		private int ResearchDevLvl;
		[JsonProperty]
		private int ResearchDevLvlCost;
		[JsonProperty]
		private int ResearchDevMaint;
		[JsonProperty]
		private int BossLvl;
		[JsonProperty]
		private int BossCount;
		[JsonProperty]
		private int BossDifficulty;
		[JsonProperty]
		private int BossReward;
		[JsonProperty]
		private int ResearchDevHealValue;
		[JsonProperty]
		private int ResearchDevHealBays;
		[JsonProperty]
		private int ResearchDevHealCost;
		public int roundCount;
		public bool bossFight;
		public int WinCount;
		public int getMonsterDenBonus
		{
			get { return MonsterDenBonus; }
			set { MonsterDenBonus = value; }
		}
		public int getMonsterDenLvlCost
		{
			get { return MonsterDenLvlCost; }
			set { MonsterDenLvlCost = value; }
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
			set { MonsterDenLvl = value; }
		}
		public int getMonsterDenLvlMaint
		{
			get { return MonsterDenLvlMaint; }
			set { MonsterDenLvlMaint = value; }
		}
		public int getMaxTeams
		{
			get { return MaxTeams; }
			set { MaxTeams = value; }
		}
		public int getTeamCost
		{
			get { return TeamCost; }
			set { TeamCost = value; }
		}
		public int getGoalGameScore
		{
			get { return GoalGameScore; }
			set { GoalGameScore = value; }
		}
		public int getGameCurrency
		{
			set
			{
				if (value - GameCurrency > 0)
					GameCurrencyLog += value - GameCurrency;
				GameCurrency = value;
			}
			get { return GameCurrency; }
		}

		public int getGameCurrencyLog
		{
			get { return GameCurrencyLog; }
		}
		public int getArenaLvl
		{
			get { return ArenaLvl; }
			set { ArenaLvl = value; }
		}
		public int getArenaLvlCost
		{
			get { return ArenaLvlCost; }
			set { ArenaLvlCost = value; }
		}
		public int getArenaLvlMaint
		{
			get { return ArenaLvlMaint; }
			set { ArenaLvlMaint = value; }
		}
		public int getShopLvl
		{
			get { return ShopLvl; }
			set { ShopLvl = value; }
		}
		public int getShopLvlCost
		{
			get { return ShopLvlCost; }
			set { ShopLvlCost = value; }
		}
		public int getShopLvlMaint
		{
			get { return ShopLvlMaint; }
			set { ShopLvlMaint = value; }
		}
		public int getShopStock
		{
			get { return ShopStock; }
			set { ShopStock = value; }
		}
		public int getShopStockCost
		{
			get { return ShopStockCost; }
			set { ShopStockCost = value; }
		}
		public int getShopMaxStat
		{
			get { return ShopMaxStat; }
			set { ShopMaxStat = value; }
		}
		public int getShopMaxDurability
		{
			get { return ShopMaxDurability; }
			set { ShopMaxDurability = value; }
		}
		public int getShopUpgradeValue
		{
			get { return ShopUpgradeValue; }
			set { ShopUpgradeValue = value; }
		}
		public int getResearchDevLvl
		{
			get { return ResearchDevLvl; }
			set { ResearchDevLvl = value; }
		}
		public int getResearchDevLvlCost
		{
			get { return ResearchDevLvlCost; }
			set { ResearchDevLvlCost = value; }
		}
		public int getResearchDevMaint
		{
			get { return ResearchDevMaint; }
			set { ResearchDevMaint = value; }
		}
		public int getResearchDevHealValue
		{
			get { return ResearchDevHealValue; }
			set { ResearchDevHealValue = value; }
		}
		public int getResearchDevHealBays
		{
			get { return ResearchDevHealBays; }
			set { ResearchDevHealBays = value; }
		}
		public int getResearchDevHealCost
		{
			get { return ResearchDevHealCost; }
			set { ResearchDevHealCost = value; }
		}
		public string getFightLog
		{
			set
			{
				if (FightLog.Length > 10000)
					FightLog = value + FightLog.Substring(0, 2500);
				else
					FightLog = value + FightLog;
			}
			get { return FightLog; }
		}
		public int getAvailableTeams
		{
			get { return MaxTeams - GameTeams.Count; }
			set { MaxTeams = value; }
		}
		public int getNumeral
		{
			get { return Numeral; }
			set
			{
				if (Numeral > maxNumeral)
				{
					Numeral = 1;
					maxNumeral += (int)(maxNumeral * .1);
				}
				else
					Numeral = value;
			}
		}
		public Game(int pGoalGameScore, int pMaxTeams, int pTeamCost, int pGameCurrency, int pArenaLvl, int pArenaLvlCost, int pArenaLvlMaint, int pMonsterDenLvl, int pMonsterDenLvlCost, int pMonsterDenLvlMaint, 
			int pMonsterDenBonus, int pMonsterDenRepair, int pShopLvl, int pShopLvlCost, int pShopLvlMaint, int pShopStock, int pShopStockCost, int pShopMaxStat, int pShopMaxDurability, int pShopUpgradeValue, int pResearchDevLvl, 
			int pResearchDevLvlCost , int pResearchDevMaint, int pResearchDevHealValue, int pResearchDevHealBays, int pResearchDevHealCost, int pResearchDevRebuild, int pBossLvl, int pBossCount, int pBossDifficulty,  int pBossReward)
		{
			GameTeams = new List<Team> { };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(1,1,1,findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 10, 10);
			findMonster = 50;
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
			MonsterDenRepairs = pMonsterDenRepair;
			ResearchDevLvl = pResearchDevLvl;
			ResearchDevLvlCost = pResearchDevLvlCost;
			ResearchDevMaint = pResearchDevMaint;
			ResearchDevHealValue = pResearchDevHealValue;
			ResearchDevHealBays = pResearchDevHealBays;
			ResearchDevHealCost = pResearchDevHealCost;
			ResearchDevRebuild = pResearchDevRebuild;
			BossLvl = pBossLvl;
			BossCount = pBossCount;
			BossDifficulty = pBossDifficulty;
			BossReward = pBossReward;
			ManagerHrs = 0;
			ManagerCost = 100;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			ArenaOpponent1 = 0;
			ArenaOpponent2 = 0;
			getNumeral = 1;
			maxNumeral = 1000;
			Globalmessage = "";
			FightBreak = 80;
			roundCount = 0;
			bossFight = false;
			getWarningLog = "";
			fightPercent = 95;
			fightPercentMax = 100;
			fightCount = 0;
		}
		public Game(bool isNew)
        {
            GameTeams = new List<Team> { new Team(1), new Team(1) };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { new ArenaSeating(1, 1, 50) };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(1, 1, 1, findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 10, 10);
			findMonster = 50;
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
			MonsterDenRepairs = 100;
			ResearchDevLvl = 1;
			ResearchDevLvlCost = 100;
			ResearchDevMaint = 1;
			ResearchDevHealValue = 2;
			ResearchDevHealBays = 1;
			ResearchDevHealCost = 1;
			ResearchDevRebuild = 1000;
			ManagerHrs = 0;
			ManagerCost = 100;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			ArenaOpponent1 = 0;
			ArenaOpponent2 = 0;
			getNumeral = 1;
			maxNumeral = 1000;
			Globalmessage = "";
			FightBreak = 80;
			roundCount = 0;
			BossLvl = 10;
			BossCount = 1;
			BossDifficulty = 10;
			BossReward = 1000;
			bossFight = false;
			getWarningLog = "";
			fightPercent = 95;
			fightPercentMax = 100;
			fightCount = 0;
		}
		public bool ShouldSerializeMainFormPanel()
		{
			// don't serialize the MainFormPanel
			return false;
		}

		public void fixTech()
		{
			foreach (Team eTeam in GameTeams) { eTeam.fixTech(); }
		}

		public void resetShowDefeated()
		{
			foreach (Team eTeam in GameTeams) { eTeam.shownDefeated = false; }
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
			ArenaLvlMaint = ArenaLvlCost / 5;
			ArenaLvl++;
			ArenaLvlCost *= 2;
			ArenaLvlCost = SkipFour(ArenaLvlCost);
			foreach (ArenaSeating eSeating in Seating)
			{
				eSeating.Amount = upgradeValue(eSeating.Amount, .5);
				eSeating.Price++;
			}
			// 20% chance to add a new level of seating
			if (RndVal.Next(1000) < ((ArenaLvl * 50) - (Seating.Count * 125))) { Seating.Add(new ArenaSeating(Seating.Count + 1, Seating[Seating.Count - 1].Price * 2, 5)); }
		}
		public string bossLevelUp()
		{
			string retVal = "";
			getGameCurrency += BossReward;
			Jackpot = 0;
			BossLvl = upgradeValue(BossLvl, .75);
			BossCount++;
			BossDifficulty = upgradeValue(BossDifficulty, .5);
			retVal = getFightLog = String.Format("\nArena destroyed boss monsters! ({1:n0}) @ {0}", DateTime.Now.ToString(), BossReward);
			BossReward = BossLvl * BossDifficulty * BossCount * 10;
			Bosses = new Team(BossCount, BossDifficulty, BossLvl);
			return retVal;
		}
		public string bossLevelReset()
		{
			string retVal = "";
			BossLvl = upgradeValue(BossLvl/2, .75);
			BossDifficulty = upgradeValue(BossDifficulty/2, .5);
			BossReward = BossLvl * BossDifficulty * BossCount * 10;
			retVal = getFightLog = String.Format("\nboss monsters difficulty down! ({0:n0})", BossReward);
			Bosses = new Team(BossCount, BossDifficulty, BossLvl);
			return retVal;
		}
		public void bossBonusUp()
		{
			BossReward = upgradeValue(BossReward,.1);
		}
		public void MonsterDenLevelUp()
		{
			getGameCurrency -= MonsterDenLvlCost;
			MonsterDenLvlMaint = MonsterDenLvlCost / 5;
			MonsterDenLvl++;
			MonsterDenLvlCost *= 2;
			MonsterDenLvlCost = SkipFour(MonsterDenLvlCost);
			MonsterDenBonus = upgradeValue(MonsterDenBonus, .5);
			MonsterDenRepairs = upgradeValue(MonsterDenRepairs, 1);
		}
		public void ShopLevelUp()
		{
			getGameCurrency -= ShopLvlCost;
			ShopLvlMaint = ShopLvlCost / 5;
			ShopLvl++;
			ShopLvlCost *= 2;
			ShopLvlCost = SkipFour(ShopLvlCost);
			ShopStock ++;
			ShopMaxDurability = upgradeValue(ShopMaxDurability, .5);
			ShopMaxStat = upgradeValue(ShopMaxStat, .5);
			ShopUpgradeValue++;
			ShopStockCost = ((ShopMaxStat * 10) + ShopMaxDurability) / 2;
		}
		public void AddStock()
		{
			// Add new equipent to stock
			while (ShopStock > storeEquipment.Count && getGameCurrency >= ShopStockCost)
			{
				getGameCurrency -= ShopStockCost;
				storeEquipment.Add(new Equipment(AddArmour(), RndVal.Next(5,ShopMaxStat), RndVal.Next(100, ShopMaxDurability),RndVal));
			}
		}

		public bool AddArmour()
		{
			int wCount = 0;
			int aCount = 0;
			foreach (Equipment eWeapons in storeEquipment)
			{
				if (eWeapons.eType == "Weapon") { wCount++; }
				if (eWeapons.eType == "Armour") { aCount++; }
			}
			//randomized if counts are the same
			if (RndVal.Next(100) > 50)
				return (wCount <= aCount);
			else
				return (wCount < aCount);
		}

		public void ResearchDevLevelUp()
		{
			getGameCurrency -= ResearchDevLvlCost;
			ResearchDevMaint = ResearchDevLvlCost / 5;
			ResearchDevLvl++;
			ResearchDevLvlCost *= 2;
			ResearchDevLvlCost = SkipFour(ResearchDevLvlCost);
			ResearchDevHealCost++;
			ResearchDevHealValue = upgradeValue(ResearchDevHealValue, 1);
			ResearchDevRebuild = upgradeValue(ResearchDevRebuild, 1);
			// 5% chance to add a new healing bay #update
			int chance = 950;
			// 20% if there is not one room for every four teams
			if (getMaxTeams / 4 > ResearchDevHealBays)
				chance = 800;
			if (RndVal.Next(1000) > chance) { ResearchDevHealBays++; }
		}
		public void AddManagerHours()
		{
			// only add Manager hours if there is less than one hour to safe time
			if ((SafeTime - DateTime.Now).TotalHours < 1)
			{
				while (getGameCurrency > ManagerCost)
				{
					getGameCurrency -= ManagerCost;
					ManagerHrs++;
					ManagerCost *= 2;
					ManagerCost = SkipFour(ManagerCost);
				}
			}
		}
		public string addTeam()
        {
			string TeamName = "";
			if (getGameCurrency > TeamCost)
			{
				// calculate cost
				getGameCurrency -= TeamCost;
				TeamCost *= 2;
				TeamCost = SkipFour(TeamCost);
				Team tmp = new Team(RndVal.Next(GameTeams.Count, GameTeams.Count * 3));
				TeamName = tmp.getName;
				GameTeams.Add(tmp);
			}
			else
			{
				getGameCurrency += MaxTeams * getArenaLvl * 1000;
				MaxTeams--;
				GoalGameScore /= 2;
			}
			// Rebuild team with top score
			Team rebuild = new Team(1);
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.getScore > rebuild.getScore)
					rebuild = eTeam;
			}
			// Add analysis points for score 
			int roboIndex = rebuild.MyTeam.Count - 1;
			while (rebuild.getScore > 0)
			{
				Robot robo = rebuild.MyTeam[roboIndex--];
				int score = RndVal.Next(1, (int)(rebuild.getScore > robo.getAnalysisLeft() ? robo.getAnalysisLeft() : rebuild.getScore));
				if (roboIndex < 0)
					roboIndex = rebuild.MyTeam.Count - 1;
				robo.getCurrentAnalysis += score;
				rebuild.getScore -= score;
				if (robo.getAnalysisLeft() <= 0)
				{
					robo.levelUp(RndVal);
					rebuild.getTeamLog = (string.Format(" {0} reached level {1}", robo.getName, robo.getLevel));
				}
			}
			rebuild.getDifficulty = 0;
			rebuild.Win++;
			int winGoal = rebuild.Win;
			for (int i = 0; i < rebuild.MyTeam.Count; i++)
				rebuild.Rebuild(i, false);
			foreach (Team eTeam in GameTeams)
			{
				eTeam.getScore = 0;
				if (eTeam.Win < winGoal)
				{
					int iWinnings = getArenaLvl * 1000 * (winGoal + 1);
					foreach (Robot eRobo in eTeam.MyTeam)
						eRobo.rebuildBonus++;
					getFightLog = eTeam.getTeamLog = string.Format("\n*!* {0} won {1:n0} credits during reset!", eTeam.getName, iWinnings);
					eTeam.getCurrency += iWinnings;
				}
			}
			PurchaseUgrade = false;
			return TeamName;
		}
		public void addRobo(int Team)
		{
			addRobo(GameTeams[Team]);
		}

		public void addRobo(Team Team)
		{
			Team.getCurrency -= Team.getRoboCost;
			Team.getRoboCost *= 2;
			Team.getRoboCost = SkipFour(Team.getRoboCost);
			Robot tmp = new Robot(1,Team.setName("robot"), RndVal.Next(8), false);
            Team.MyTeam.Add(tmp);
        }
        public int getScore()
        {
            int iTmpScore = 0;
            for (int i = 0; i < GameTeams.Count; i++) { iTmpScore += GameTeams[i].getScore; }
			if (iTmpScore >= GoalGameScore)
			{
				MaxTeams++;
				GoalGameScore *= 2;
				GoalGameScore = SkipFour(GoalGameScore);
			}
			return iTmpScore;
		}
		public int getScoreLog()
		{
			int iTmpScore = 0;
			for (int i = 0; i < GameTeams.Count; i++) { iTmpScore += GameTeams[i].getScoreLog; }
			return iTmpScore;
		}
		public Boolean Repair()
		{
			Boolean fullHP = true;
			Team[] teamHeal = new Team[ResearchDevHealBays];
			for (int i = 0; i < teamHeal.Length; i++)
				teamHeal[i] = GameTeams[RndVal.Next(GameTeams.Count)];
			foreach (Team eTeam in GameTeams)
			{
				Boolean tmpFullHP = true;
				if (!isFighting(eTeam.getName) && !isFighting("arena"))
				{
					if (!Array.Exists(teamHeal, element => element.Equals(eTeam)))  //!eTeam.Equals(GameTeams[teamHeal]))
						tmpFullHP = eTeam.healRobos(0, 1);
					else
						tmpFullHP = eTeam.healRobos(ResearchDevHealCost, ResearchDevHealValue);
					if (tmpFullHP == false)
						fullHP = false;
				}
			}
			MonsterOutbreak.healRobos(0, 1);
			Bosses.healRobos(0, 1);
			return fullHP;
		}
		public bool isFighting(string teamName)
		{
			bool isFighting = false;
			if (GameTeam1 != null)
			{
				foreach (Team eTeam in GameTeam1)
					if (eTeam.getName.Equals(teamName))
						isFighting = true;
				foreach (Team eTeam in GameTeam2)
					if (eTeam.getName.Equals(teamName))
						isFighting = true;
			}
			return isFighting;
		}
		public void startMonsterOutbreak(int cost)
		{
			fighting = true;
			GameTeam1.Add(new Team(0,0,0,0,0,0,0,"Arena",false));
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam)
					GameTeam1[GameTeam1.Count-1].MyTeam.Add(eRobo);
			}
			GameTeam1[GameTeam1.Count - 1].MyTeam.Sort();
			GameTeam2.Add(new Team(0,0,0,0,0,0,0,"Monster Outbreak",false));
			for (int i = 0; i < MonsterOutbreak.MyTeam.Count;)
			{
				if (RndVal.Next(100) < findMonster) 
				{
					GameTeam2[GameTeam2.Count - 1].MyTeam.Add(MonsterOutbreak.MyTeam[i]);
					MonsterOutbreak.MyTeam.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
			Jackpot += cost;
			getFightLog = Environment.NewLine + "--- Monster Outbreak! @ " + DateTime.Now.ToString();
		}
		public void startBossFight()
		{
			fighting = true;
			bossFight = false;
			GameTeam1.Add(new Team(0,0,0,0,0,0,0,"Arena",false));
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam)
					GameTeam1[GameTeam1.Count - 1].MyTeam.Add(eRobo);
			}
			GameTeam1[GameTeam1.Count - 1].MyTeam.Sort();
			GameTeam2.Add(Bosses);
			Jackpot = BossReward;
			getFightLog = Environment.NewLine + " Boss Fight! @ " + DateTime.Now.ToString();
		}
		public void sortSkills()
		{
			foreach (Team eTeam in GameTeam1)
				foreach (Robot eRobot in eTeam.MyTeam)
					eRobot.sortSkills();
			foreach (Team eTeam in GameTeam2)
				foreach (Robot eRobot in eTeam.MyTeam)
					eRobot.sortSkills();
		}
		public int monsterFight()
		{
			int Team1Score = 99999999;
			int TeamIndex = -1;
			int tmpScore = 0;
			for (int i = 0; i < GameTeams.Count; i++)
			{
				tmpScore = GameTeams[i].getScore * (GameTeams[i].Win + 1);
				// if new score is lower than previous
				if ((Team1Score > tmpScore || (Team1Score == tmpScore && RndVal.Next(100) > 50))
					&& !isFighting(GameTeams[i].getName))
				{
					TeamIndex = i;
					Team1Score = tmpScore;
				}
			}
			return TeamIndex;
		}
		public void incrementArenaOpponent()
		{
			if (ArenaOpponent2 >= GameTeams.Count) { ArenaOpponent2 = 0; ArenaOpponent1++; }
			if (ArenaOpponent1 >= GameTeams.Count) { ArenaOpponent1 = 0; }
		}
		public void startFight()
        {
			if (bossFight && !fighting)
			{
				startBossFight();
			}
			else
			{
				fighting = true;
				int Team1Index = 0;
				int Team2Index = GameTeams.Count - 1;
				int PotScore = 0;
				// usually fight other teams. 
				if (GameTeam1.Count == 0)
				{
					WinCount = 0;
					incrementArenaOpponent();
					if (ArenaOpponent1 == ArenaOpponent2)
					{
						if (ArenaOpponent1 != 0)
						{
							ArenaOpponent2++;
							incrementArenaOpponent();
						}
					}
					if (ArenaOpponent1 == 0 && ArenaOpponent1 == ArenaOpponent2)
						Team1Index = Team2Index = monsterFight();
					else
					{
						Team1Index = ArenaOpponent1;
						Team2Index = ArenaOpponent2;
					}
					ArenaOpponent2++;
					if (fightCount >= MaxTeams / 2)
						fightPercent++;
					else
						fightPercent--;
					if (fightPercent >= fightPercentMax)
						fightPercentMax++;
					fightCount = 0;
				}
				else
				{
					fightCount++;
					// monster fight
					Team1Index = Team2Index = monsterFight();
					// if index is still -1 no available teams exit function
					if (Team1Index == -1) return;
				}
				GameTeam1.Add(GameTeams[Team1Index]);
				PotScore = GameTeam1[GameTeam1.Count - 1].getScore;

				if (Team1Index == Team2Index)
				{
					// only if main fight is a monster fight
					if (GameTeam1.Count == 1)
					{
						// 10% chance to Lower difficulty
						if (RndVal.Next(100) > 90 && GameTeam1[0].getDifficulty > GameTeam1[0].MyTeam[GameTeam1[0].MyTeam.Count - 1].getLevel)
						{
							GameTeam1[0].getDifficulty = RndVal.Next(GameTeam1[0].MyTeam[GameTeam1[0].MyTeam.Count-1].getLevel , GameTeam1[0].MyTeam[0].getLevel);
						}
						GameTeam1[0].healRobos(0, 999999);
					}
					// Monster team... 
					GameTeam2.Add(new Team(GameTeam1[GameTeam1.Count - 1].getMaxRobos, GameTeam1[GameTeam1.Count - 1].getDifficulty, getMonsterDenLvl, findMonster, ref MonsterOutbreak));
				}
				else
				{
					// Robo Team
					GameTeam2.Add(GameTeams[Team2Index]);
					PotScore += GameTeam2[GameTeam2.Count - 1].getScore;
				}
				if (GameTeam1.Count == 1)
					PotScore += getMonsterDenBonus;
				string msg = Environment.NewLine + "     Attendance: ";
				int tmpMonsterDenBonus = getMonsterDenBonus;
				int tmpTotalScore = PotScore;
				if (GameTeam1.Count == 1)
				{
					CurrentSeating = new List<ArenaSeating> {  };
					// reset seating
					foreach (ArenaSeating eSeating in Seating)
					{
						CurrentSeating.Add(new ArenaSeating(eSeating.Level, eSeating.Price, eSeating.Amount));
					}
				}
				// Get money for the pot
				int tmp = 0;
				foreach (ArenaSeating eSeating in CurrentSeating)
				{
					int min = (tmpMonsterDenBonus <= eSeating.Amount / 2 ? tmpMonsterDenBonus : eSeating.Amount / 2);
					int max = (tmpTotalScore > eSeating.Amount ? eSeating.Amount : tmpTotalScore);
					if (GameTeam1.Count > 1)
					{
						min = 0;
						max = (tmpTotalScore > eSeating.Amount ? eSeating.Amount : tmpTotalScore);
					}
					if (max < min)
						max = min;
					int NumSeats = RndVal.Next(min, max+1);
					tmpMonsterDenBonus -= NumSeats;
					tmpTotalScore -= NumSeats;
					if (tmpMonsterDenBonus < 0) tmpMonsterDenBonus = 0;
					msg += string.Format(" {0}({1:n0}/{2:n0}) ", eSeating.Level , NumSeats, max);
					tmp += eSeating.Price * NumSeats;
					eSeating.Amount -= NumSeats;
				}
				// Monster fighter teams get 10% of jackpot
				if (GameTeam1.Count > 1)
				{
					int MonsterFighter = (int)(tmp * 0.1);
					GameTeam1[GameTeam1.Count - 1].getCurrency += MonsterFighter;
					tmp -= MonsterFighter;
					msg += string.Format(" ${0:n0} MF:${1:n0}", tmp, MonsterFighter);
				}
				else
				{
					msg += string.Format(" ${0:n0}", tmp);
				}
				Jackpot += tmp;
				string spacer = "";
				if (GameTeam1.Count > 1)
					spacer = "  ";
				msg = string.Format("\n{0}{1} VS {2} @ {3}{4}" , spacer , GameTeam1[GameTeam1.Count - 1].getName, GameTeam2[GameTeam2.Count - 1].getName, DateTime.Now.ToString(), msg);
				if (GameTeam1.Count == 1)
					msg += String.Format("\n{0}/{1} {2:n2}%\n", fightPercent.ToString(), fightPercentMax.ToString(), ((double)(fightPercentMax - fightPercent) / fightPercentMax * 100));
				getFightLog = msg;
				sortSkills();
				GameTeam1[GameTeam1.Count - 1].clean();
				GameTeam2[GameTeam2.Count - 1].clean();
			}
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
			Label Name = new Label { AutoSize = true, Width = 50, Text = eRobo.getName.PadRight(6).Substring(0,6)};
			Robo.Controls.Add(Name);
			PictureBox RoboPic = new PictureBox { Image = Image.FromFile(eRobo.getImage), Width = 50, Height = 50, SizeMode = PictureBoxSizeMode.StretchImage };
			Robo.Controls.Add(RoboPic);
			AlsProgressBar HP = new AlsProgressBar(Brushes.Green) { Maximum = eRobo.getTHealth(), Value = eRobo.HP, Width = 50, Height = 6 };
			Robo.Controls.Add(HP);
			AlsProgressBar MP = new AlsProgressBar(Brushes.Blue) { Maximum = eRobo.getTEnergy(), Value = eRobo.MP, Width = 50, Height = 6 };
			Robo.Controls.Add(MP);
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
			Label lblBlank = new Label { AutoSize = true, Text = Environment.NewLine + Environment.NewLine };
			HeaderPanel.Controls.Add(lblBlank);
			ProgressBar Progress = new ProgressBar { Maximum = MaxInterval, Value = CurrentInterval, Minimum = 1000, Width = 200, Height = 10 };
			HeaderPanel.Controls.Add(Progress);
			Label lblTime = new Label { AutoSize = true, Text = String.Format("Time: {0} ({1}) [{2}] -> {3:n0} ({4:n1}) - {5:n0}", DateTime.Now.ToString("HH:mm"), SafeTime.ToString("HH:mm"), BreakTime.ToString("HH:mm"), (DateTime.Today.AddHours(16) - DateTime.Now).TotalMinutes, (DateTime.Today.AddHours(16) - DateTime.Now).TotalHours, roundCount) };
			HeaderPanel.Controls.Add(lblTime);
			return HeaderPanel;
		}
		public int getMaxLength(string[] strValues)
		{
			int maxLen = 0;
			foreach (string eValue in strValues)
				if (maxLen < eValue.Length)
					maxLen = eValue.Length;
			return maxLen;
		}
		public FlowLayoutPanel showSelectedTeam(int TeamSelect, bool showAll)
		{
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			if (TeamSelect > 0)
			{
				FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblTeamName = new Label { AutoSize = true, Text = "Team Name:  " + GameTeams[TeamSelect - 1].getName };
				lblTeamName.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].rename(InputBox("Enter Name ", "Enter Name")));
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getCurrency) };
				Label lblScore = new Label { AutoSize = true, Text = "Score:      " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getScore) + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getGoalScore) + ")" };
				Label lblWin = new Label { AutoSize = true, Text = String.Format("Winns:      {0:n0}", GameTeams[TeamSelect - 1].Win) };
				Label lblRobots = new Label { AutoSize = true, Text = "Robots:     " + GameTeams[TeamSelect - 1].MyTeam.Count + "/" + GameTeams[TeamSelect - 1].getMaxRobos + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getRoboCost) + ")" };
				Label lblDifficulty = new Label { AutoSize = true, Text =     "Difficulty: " + GameTeams[TeamSelect - 1].getDifficulty };
				Label lblAutomatic = new Label { AutoSize = true, Text = "Automated:  " + GameTeams[TeamSelect - 1].Automated };
				lblAutomatic.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].changeAutomated());
				MainPanel.Controls.Add(lblTeamName);
				MainPanel.Controls.Add(lblTeamCurrency);
				MainPanel.Controls.Add(lblScore);
				MainPanel.Controls.Add(lblWin);
				MainPanel.Controls.Add(lblRobots);
				MainPanel.Controls.Add(lblDifficulty);
				MainPanel.Controls.Add(lblAutomatic);
				int index = 0;
				foreach (Robot eRobo in GameTeams[TeamSelect - 1].MyTeam)
				{
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
					RoboName.Click += new EventHandler((sender, e) => eRobo.rename(InputBox("Enter Name ", "Enter Name")));
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					Button btnRebuild = new Button { AutoSize = true, Text = "Rebuild (" + String.Format("{0:n0}", eRobo.rebuildCost()) + ")" };
					int innerIndex = index++;
					btnRebuild.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].Rebuild(innerIndex, true));
					MyPanel.Controls.Add(RoboName);
					MyPanel.Controls.Add(Everything);
					MyPanel.Controls.Add(btnRebuild);
					TopLevelPanel.Controls.Add(MyPanel);
				}
				MainPanel.Controls.Add(TopLevelPanel);
				Label lblTeamLog = new Label { AutoSize = true, Text = Environment.NewLine + "Team Log:   " + Environment.NewLine + GameTeams[TeamSelect - 1].getTeamLog };
				MainPanel.Controls.Add(lblTeamLog);
			}
			else
			{
				int[] Length =
					{ getMaxLength(new string[] { string.Format("{0:n0}", getScore()), string.Format("{0:n0}/{1:n0}",GameTeams.Count, getMaxTeams), string.Format("{0:n0}", getGameCurrency), string.Format("{0:n0}", getArenaLvl),string.Format("{0:n0}", getShopLvl), string.Format("{0:n0}", getResearchDevLvl), string.Format("{0:n0}", getMonsterDenLvl), string.Format("{0:n0}", BossCount), string.Format("{0:n0}", ManagerHrs) })
					, getMaxLength(new string[] { string.Format("{0:n0}", getArenaLvlCost), string.Format("{0:n0}", getShopLvlCost), string.Format("{0:n0}", getResearchDevLvlCost), string.Format("{0:n0}", getMonsterDenLvlCost) })
				};
				Label lblTotalScore = new Label { AutoSize = true, Text = String.Format("Total Score: {0,-" + Length[0] + ":n0} *{1:n0}", getScore(), getGoalGameScore) };
				MainPanel.Controls.Add(lblTotalScore);
				Label lblTeams = new Label { AutoSize = true, Text =	  String.Format("Teams:       {0,-" + Length[0] + ":n0} +{1:n0}", string.Format("{0:n0}/{1:n0}",GameTeams.Count, getMaxTeams), getTeamCost)};
				MainPanel.Controls.Add(lblTeams);
				Label lblCurrency = new Label { AutoSize = true, Text =   String.Format("Currency:    {0,-" + Length[0] + ":n0} ({1:n0})", getGameCurrency, getGameCurrencyLog) };
				MainPanel.Controls.Add(lblCurrency);
				Label lblArenaLvl = new Label { AutoSize = true, Text =   String.Format("Arena:       {0,-" + Length[0] + "} +{1,-" + Length[1] + ":n0} -{2:n0}", getArenaLvl, getArenaLvlCost, getArenaLvlMaint) };
				MainPanel.Controls.Add(lblArenaLvl);
				FlowLayoutPanel pnlSeating = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				int index = 0;
				foreach (ArenaSeating eSeating in Seating)
				{
					if (showAll || index <= 2)
					{
						string ending = "";
						if (index == 2 && !showAll && Seating.Count > 3) ending = "...";
						Label lblArenaSeating = new Label { AutoSize = true, Text = String.Format("  Level:{3} Price:{0:n0} Seats:{1:n0}{2}\n", eSeating.Price, eSeating.Amount, ending, eSeating.Level) };
						pnlSeating.Controls.Add(lblArenaSeating);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlSeating);
				Label lblShopLvl = new Label { AutoSize = true, Text = String.Format("Shop:        {0,-" + Length[0] + "} +{1,-" + Length[1] + ":n0} -{2:n0}", getShopLvl, getShopLvlCost, getShopLvlMaint) };
				MainPanel.Controls.Add(lblShopLvl);
				FlowLayoutPanel pnlEquipment = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				Label lblShopStock = new Label { AutoSize = true, Text = String.Format(" Max Stock:{4}/{0} Dur:{1:n0} sta+{2:n0} Cost:{3:n0} up:{5:n0} ", getShopStock, getShopMaxDurability, getShopMaxStat, getShopStockCost, storeEquipment.Count, getShopUpgradeValue) };
				pnlEquipment.Controls.Add(lblShopStock);
				index = 0;
				foreach (Equipment eEquipment in storeEquipment)
				{
					if (showAll || index <= 2)
					{
						string ending = "";
						if (index == 2 && !showAll && storeEquipment.Count > 3) ending = "...";
						Label lblEquipment = new Label { AutoSize = true, Text = "  " + eEquipment.ToString() + ending + Environment.NewLine };
						pnlEquipment.Controls.Add(lblEquipment);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlEquipment);
				Label lblResearchLvl = new Label { AutoSize = true, Text = String.Format("Research:    {0,-" + Length[0] + "} +{1,-" + Length[1] + ":n0} -{2:n0}\n    Heal:{3:n0} Cost:{4:n0} Bays:{5:n0} Rebuild:-{6:n0}", getResearchDevLvl, getResearchDevLvlCost, getResearchDevMaint, getResearchDevHealValue, getResearchDevHealCost, getResearchDevHealBays, ResearchDevRebuild) };
				MainPanel.Controls.Add(lblResearchLvl);
				Label lblMonsterDen = new Label { AutoSize = true, Text = String.Format("Monster Den: {0,-" + Length[0] + "} +{1,-" + Length[1] + ":n0} -{2:n0}\n    In Den:{3:n0} bonus:{4:n0} Repair:-{5:n0}", MonsterDenLvl, getMonsterDenLvlCost, getMonsterDenLvlMaint, MonsterOutbreak.MyTeam.Count, MonsterDenBonus, MonsterDenRepairs) };
				lblMonsterDen.Click += new EventHandler((sender, e) => displayMonsters("Monster Outbreak"));
				MainPanel.Controls.Add(lblMonsterDen);
				Label lblBossMonsters = new Label { AutoSize = true, Text = String.Format("BossMonsters:{0,-" + Length[0] + ":n0} ${1:n0}", BossCount, BossReward) };
				lblBossMonsters.Click += new EventHandler((sender, e) => displayMonsters("Boss Monsters"));
				MainPanel.Controls.Add(lblBossMonsters);
				Label lblManager = new Label { AutoSize = true, Text = String.Format("Manager:     {0,-" + Length[0] + ":n0} +{1:n0}", ManagerHrs, ManagerCost) };
				lblManager.Click += new EventHandler((sender, e) => AddManagerHours());
				MainPanel.Controls.Add(lblManager);
				if (getWarningLog.Length > 0)
				{
					Label lblWarningLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Bold, GraphicsUnit.Pixel), Text = Environment.NewLine + "Warnings:" + getWarningLog };
					lblWarningLog.Click += new EventHandler((sender, e) => clearWarnings());
					MainPanel.Controls.Add(lblWarningLog);
				}
				Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + getFightLog };
				MainPanel.Controls.Add(lblFightLog);
			}
			return MainPanel;
		}
		public void displayMonsters(string type)
		{
			Team displayTeam = MonsterOutbreak;
			if (type.Equals("Boss Monsters"))
				displayTeam = Bosses;
			foreach (Robot eRobot in displayTeam.MyTeam)
				eRobot.sortSkills();
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
			Label lblTeamName = new Label { AutoSize = true, Text = Environment.NewLine + Environment.NewLine + "Team Name:  " + displayTeam.getName };
			Label lblRobots = new Label { AutoSize = true, Text =   "Monsters:   " + displayTeam.MyTeam.Count };
			MainPanel.Controls.Add(lblTeamName);
			MainPanel.Controls.Add(lblRobots);
			foreach (Robot eRobo in displayTeam.MyTeam)
			{
				FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
				Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
				MyPanel.Controls.Add(RoboName);
				MyPanel.Controls.Add(Everything);
				TopLevelPanel.Controls.Add(MyPanel);
			}
			MainPanel.Controls.Add(TopLevelPanel);
			if (MainFormPanel != null)
			{
				foreach (Control eControl in MainFormPanel.Controls)
				{
					eControl.Dispose();
				}
				MainFormPanel.Controls.Clear();
				MainFormPanel.Controls.Add(MainPanel);
			}
		}
		public int[] maxNameLength(bool tmpFighting)
		{
			int[] maxLength = 
				{ 10 // Name 
				, 1 // Level
				, 1 // LevelLog
				, 1 // Annalysis
				, 1 // MP
				, 1 // HP
			};
			if (tmpFighting)
			{
				foreach (Team eTeam in GameTeam1)
					foreach (Robot eRobo in eTeam.MyTeam)
						maxLength = checkLength(maxLength, eRobo);
				foreach (Team eTeam in GameTeam2)
					foreach (Robot eRobo in eTeam.MyTeam)
						maxLength = checkLength(maxLength, eRobo);
			}
			else
			{
				foreach (Team eTeam in GameTeams)
					foreach (Robot eRobo in eTeam.MyTeam)
						maxLength = checkLength(maxLength, eRobo);
			}
			return maxLength;
		}
		public int[] checkLength(int[] maxLength, Robot eRobo)
		{
			// Name
			if (eRobo.getName.Length > maxLength[0])
				maxLength[0] = eRobo.getName.Length;
			// Level
			if (string.Format("{0:n0}", eRobo.getLevel).Length > maxLength[1])
				maxLength[1] = string.Format("{0:n0}", eRobo.getLevel).Length;
			// LevelLog
			if (string.Format("{0:n0}", eRobo.getLevelLog).Length > maxLength[2])
				maxLength[2] = string.Format("{0:n0}", eRobo.getLevelLog).Length;
			// Annalysis
			if (string.Format("{0:n0}", eRobo.getAnalysisLeft()).Length > maxLength[3])
				maxLength[3] = string.Format("{0:n0}", eRobo.getAnalysisLeft()).Length;
			// MP
			if (string.Format("{0:n0}", eRobo.MP).Length > maxLength[4])
				maxLength[4] = string.Format("{0:n0}", eRobo.MP).Length;
			// HP
			if (string.Format("{0:n0}", eRobo.HP).Length > maxLength[5])
				maxLength[5] = string.Format("{0:n0}", eRobo.HP).Length;
			return maxLength;
		}
		public FlowLayoutPanel showCountdown()
		{
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			/*List<KeyValuePair<String, DateTime>> countdown = new List<KeyValuePair<String, DateTime>>();
			countdown.Add(new KeyValuePair<string, DateTime>("Carilee", new DateTime(DateTime.Today.Year, 3, 3)));
			countdown.Add(new KeyValuePair<string, DateTime>("Mac", new DateTime(DateTime.Today.Year, 3, 11)));
			countdown.Add(new KeyValuePair<string, DateTime>("Easter", new DateTime(DateTime.Today.Year, 04, 12)));
			countdown.Add(new KeyValuePair<string, DateTime>("Al", new DateTime(DateTime.Today.Year, 4, 14)));
			countdown.Add(new KeyValuePair<string, DateTime>("Aiden", new DateTime(DateTime.Today.Year, 4, 24)));
			countdown.Add(new KeyValuePair<string, DateTime>("Oakley", new DateTime(DateTime.Today.Year, 7, 7)));
			countdown.Add(new KeyValuePair<string, DateTime>("Bren", new DateTime(DateTime.Today.Year, 12, 11)));
			countdown.Add(new KeyValuePair<string, DateTime>("Christmas", new DateTime(DateTime.Today.Year, 12, 25)));*/
				List<KeyValuePair<String, DateTime>> beforeToday = new List<KeyValuePair<String, DateTime>>();
			string Countdown = "";
			foreach (KeyValuePair<String, DateTime> eDate in countdown)
			{
				if (eDate.Value < DateTime.Today)
					beforeToday.Add(new KeyValuePair<string, DateTime>(eDate.Key, new DateTime(DateTime.Today.Year + 1, eDate.Value.Month, eDate.Value.Day)));
				else
					Countdown += String.Format("{0} {1:n0} days\n", eDate.Key.PadRight(10), (eDate.Value - DateTime.Today).TotalDays);
			}
			foreach (KeyValuePair<String, DateTime> eDate in beforeToday)
				Countdown += String.Format("{0} {1:n0} days\n", eDate.Key.PadRight(10), (eDate.Value - DateTime.Today).TotalDays);
			Label lblCountdown = new Label { AutoSize = true, Text = "Countdown" + Environment.NewLine + Countdown };
			MainPanel.Controls.Add(lblCountdown);
			return MainPanel;
		}
		public FlowLayoutPanel continueFight(bool display)
        {
			roundCount++;
			if (Globalmessage == null)
				Globalmessage = "";
			if (Globalmessage.Length > 0)
			{
				getFightLog = Globalmessage;
				Globalmessage = "";
			}
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			Label lblTeamName = new Label { AutoSize = true, Text = "Fight (" + showInterval() + ")" };
			MainPanel.Controls.Add(lblTeamName);
			for (int i = 0; i < GameTeam1.Count; i++)
			{
				if (GameTeam1[i].getNumRobos(true) > 0 && GameTeam2[i].getNumRobos(true) > 0)
				{
					getNext(i);
					if (display)
					{
						if (auto)
						{
							if (i == 0)
							{
								Label lblGameStats = new Label { AutoSize = true, Text = String.Format("C:{0:n0}({1:n0}) TS:{2:n0}({3:n0}) J:{4:n0}", getGameCurrency, GameCurrencyLog, getScore(), getScoreLog(), Jackpot) };
								MainPanel.Controls.Add(lblGameStats);
							}
							Color background = Color.Transparent;
							if (i % 2 == 1)
								background = Color.LightGray;
							Label lblTeam1stats = new Label { AutoSize = true,BackColor = background , Text = GameTeam1[i].getTeamStats(maxNameLength(true)) };
							int tmpI = i;
							lblTeam1stats.Click += new EventHandler((sender, e) => GameTeam1[tmpI].Rebuild(true));
							MainPanel.Controls.Add(lblTeam1stats);
							Label lblTeam2stats = new Label { AutoSize = true, BackColor = background, Text = GameTeam2[i].getTeamStats(maxNameLength(true)) };
							lblTeam2stats.Click += new EventHandler((sender, e) => GameTeam2[tmpI].Rebuild(true));
							MainPanel.Controls.Add(lblTeam2stats);
						}
						else
						{
							FlowLayoutPanel Team1 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
							FlowLayoutPanel Team2 = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.LeftToRight };
							foreach (Robot eRobo in GameTeam2[i].MyTeam)
							{
								if (eRobo.getKO < 10)
								{
									Team2.Controls.Add(getCharacterInfo(eRobo));
								}
							}
							Label lblGameStats = new Label { AutoSize = true, Text = String.Format("C:{0:n0}({1:n0}) TS:{2:n0}({3:n0}) J:{4:n0}", getGameCurrency, GameCurrencyLog, getScore(), getScoreLog(), Jackpot) };
							MainPanel.Controls.Add(lblGameStats);
							Label lblVS2 = new Label { AutoSize = true, Text = GameTeam2[i].getName + " C:" + String.Format("{0:n0}", GameTeam2[i].getCurrency) + " S:" + String.Format("{0:n0}", GameTeam2[i].getScore) + " D:" + String.Format("{0:n0}", GameTeam2[i].getDifficulty) };
							MainPanel.Controls.Add(lblVS2);
							MainPanel.Controls.Add(Team2);
							foreach (Robot eRobo in GameTeam1[i].MyTeam)
							{
								if (eRobo.getKO < 10)
								{
									Team1.Controls.Add(getCharacterInfo(eRobo));
								}
							}
							Label lblVS1 = new Label { AutoSize = true, Text = GameTeam1[i].getName + " C:" + String.Format("{0:n0}", GameTeam1[i].getCurrency) + " S:" + String.Format("{0:n0}", GameTeam1[i].getScore) + " D:" + String.Format("{0:n0}", GameTeam1[i].getDifficulty) };
							MainPanel.Controls.Add(lblVS1);
							MainPanel.Controls.Add(Team1);
						}
					}
				}
				else
				{
					if (GameTeam1[i].getName.Equals("Arena"))
					{
						Label lblWinner = new Label { AutoSize = true };
						if (GameTeam1[i].getNumRobos(false) > 0)
						{
							if (GameTeam2[i].getName.Equals("Monster Outbreak"))
							{
								// more new monsters
								findMonster += 5;
								lblWinner.Text = getFightLog = Environment.NewLine + "+++ Arena suppressed the Monster outbreak" + String.Format("({0})", findMonster) + " @ " + DateTime.Now.ToString();
							}
							// Boss Fight
							else
							{
								lblWinner.Text = bossLevelUp();
							}
						}
						else
						{
							if (GameTeam2[i].getName.Equals("Monster Outbreak"))
							{
								// fewer new monsters
								findMonster -= 5;
								getGameCurrency -= Jackpot;
								GameCurrencyLog -= Jackpot;
								lblWinner.Text = getFightLog = Environment.NewLine + "--- Arena suffered damages from Monster outbreak -" + String.Format("{0:n0} ({1}%)", Jackpot, findMonster) + " @ " + DateTime.Now.ToString();
							}
							else
							{
								string tmp = getFightLog = Environment.NewLine + "Arena suffered a loss against the boss monsters! @ " + DateTime.Now.ToString();
								if (GameTeam2[i].getNumRobos(false) < GameTeam2[i].MyTeam.Count)
									bossBonusUp();
								else if (RndVal.Next(100) > 95)
									tmp += bossLevelReset();
								lblWinner.Text = tmp;
							}
						}
						GameTeam1.Clear();
						GameTeam2.Clear();
						Jackpot = 0;
						MainPanel.Controls.Add(lblWinner);
						fighting = false;
					}
					else
					{
						bool newMonster = false;
						if (i == 0)
						{
							string msg = "";
							Label lblWinner = new Label { AutoSize = true };
							if (GameTeam1[i].getNumRobos(false) > 0)
							{
								FightBreak -= 5;
								lblWinner.Text = GameTeam1[i].getName + " wins!";
								int tmp = (int)(Jackpot * .4);
								GameTeam1[i].getCurrency += tmp;
								Jackpot -= tmp;
								msg += " " + String.Format("{0:n0}", tmp);
								// increase difficulty if monster
								if (GameTeam2[i].isMonster)
								{
									WinCount++;
									GameTeam1[i].getDifficulty++;
									getFightLog = Environment.NewLine + GameTeam1[i].getName + " Won against " + GameTeam2[i].getName + msg;
									// fight next difficulty
									Team tmpTeam = new Team(GameTeam1[i].getMaxRobos, GameTeam1[i].getDifficulty, getMonsterDenLvl, findMonster, ref MonsterOutbreak);
									addMonsters(GameTeam2[i]);
									GameTeam2[i] = tmpTeam;
									getFightLog = Environment.NewLine + GameTeam1[i].getName + " VS " + GameTeam2[i].getName + " @ " + DateTime.Now.ToString();
									GameTeam1[i].healRobos(0, 1);
									equip(GameTeam1[i], true);
									newMonster = true;
								}
								else
								{
									// increase score if another team and score's are within 20%
									GameTeam1[i].getScore++;
									// pay team 2 25%;
									tmp = (int)(Jackpot * .25);
									GameTeam2[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += " (" + String.Format("{0:n0}", tmp) + ")";
								}
								msg = GameTeam1[i].getName + " Won against " + GameTeam2[i].getName + msg;
							}
							else
							{
								FightBreak = 95;
								lblWinner.Text = GameTeam2[i].getName + " winns!";
								GameTeam2[i].getScore++;
								// decrease difficulty if monster won
								if (GameTeam2[i].isMonster)
								{
									// pay loosing team
									int tmp = (int)(Jackpot * .25);
									GameTeam1[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += String.Format(" ({0:n0}) Win:{1}", tmp, WinCount);
									// if GameTeam1 has a lower difficulty it's lowest character level send a warning
									if (WinCount == 0 && GameTeam1[i].getDifficulty < GameTeam1[i].MyTeam[GameTeam1[i].MyTeam.Count - 1].getLevel && GameTeam1[i].getDifficulty > 0)
										getWarningLog = String.Format("\n--- {0} has failed to advance past min level!", GameTeam1[i].getName);
								}
								else
								{
									// team won they get 40%
									int tmp = (int)(Jackpot * .4);
									GameTeam2[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += " " + String.Format("{0:n0}", tmp);
									// team lost gets 25%
									tmp = (int)(Jackpot * .25);
									GameTeam1[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += " (" + String.Format("{0:n0}", tmp) + ")";
								}
								msg = GameTeam2[i].getName + " Won against " + GameTeam1[i].getName + msg;
							}
							MainPanel.Controls.Add(lblWinner);
							if (!newMonster)
							{
								getGameCurrency += Jackpot;
								getFightLog = Environment.NewLine + msg + Environment.NewLine + "     Arena made " + String.Format("{0:n0}", Jackpot) + " @ " + DateTime.Now.ToString();
								Jackpot = 0;
								fighting = false;
							}
						}
						// Don't remove team if new monster selected
						if (!newMonster)
						{
							if (i > 0)
							{
								addMonsters(GameTeam2[i]);
								GameTeam1.RemoveAt(i);
								GameTeam2.RemoveAt(i);
								// decrement i so it stays at the same value. 
								i--;
							}
							else
							{
								// add all monsters to Monster Outbreak
								foreach (Team eTeam in GameTeam2)
								{
									addMonsters(eTeam);
								}
								GameTeam1.Clear();
								GameTeam2.Clear();
								buildingMaintenance();
							}
						}
					}
				}
				// last team add extra details
				if (i == GameTeam1.Count - 1 && !GameTeam1[0].getName.Equals("Arena"))
				{
					// Add a space
					MainPanel.Controls.Add(new Label { AutoSize = true, Text = "" });
					foreach (Team eTeam in GameTeams)
					{
						if (!isFighting(eTeam.getName))
						{
							Label lblTeamstats = new Label { AutoSize = true, Text = eTeam.getTeamStats(maxNameLength(false)) };
							lblTeamstats.Click += new EventHandler((sender, e) => eTeam.Rebuild(true));
							MainPanel.Controls.Add(lblTeamstats);
						}
					}
					if (getWarningLog.Length > 0)
					{
						Label lblWarningLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Bold, GraphicsUnit.Pixel), Text = Environment.NewLine + "Warnings:" + getWarningLog };
						lblWarningLog.Click += new EventHandler((sender, e) => clearWarnings());
						MainPanel.Controls.Add(lblWarningLog);
					}
					Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + Environment.NewLine + getFightLog };
					MainPanel.Controls.Add(lblFightLog);
				}
			}
			return MainPanel;
		}

		public void addMonsters(Team MonsterTeam)
		{
			if (MonsterTeam.isMonster)
			{
				foreach (Robot eMonster in MonsterTeam.MyTeam)
				{
					// ensure monster is not already added to Monster Outbreak
					bool exists = false;
					foreach (Robot eMonsterOutbreak in MonsterOutbreak.MyTeam)
						if (eMonster.getName.Equals(eMonsterOutbreak.getName))
							exists = true;
					// Randomly add monster to Monster Outbreak
					if ((RndVal.Next(100) < findMonster || eMonster.bMonster) && !exists)
					{
						if (!eMonster.bMonster)
						{
							eMonster.getName += " " + ToRoman(getNumeral++);
							eMonster.bMonster = true;
						}
						for (int i = 100; i < RndVal.Next(findMonster); i += 100)
							MonsterOutbreak.MyTeam.Add(eMonster.DupeMonster());
						MonsterOutbreak.MyTeam.Add(eMonster);
					}
				}
			}
		}

		public void equip()
		{
			equip(GameTeams[RndVal.Next(GameTeams.Count)], false);
		}
		public void equip(Team eTeam, bool checkFight)
		{
			//GameTeams[team]
			Robot shopper;
			if (!isFighting(eTeam.getName) || checkFight)
			{
				shopper = eTeam.MyTeam[RndVal.Next(0, eTeam.MyTeam.Count)];
				bool bAutomated = eTeam.Automated;
				// Automated teams automatically build new robots and rebuild robots
				if (bAutomated)
				{
					// Add Robot
					if (eTeam.getCurrency >= eTeam.getRoboCost && eTeam.getAvailableRobo > 0)
					{
						addRobo(eTeam);
						eTeam.getTeamLog = getFightLog = Environment.NewLine + "+++ " + eTeam.getName + " built a new robot ";
					}
					// Rebuild Robot
					for (int i = 0; i < eTeam.MyTeam.Count; i++)
					{
						if (eTeam.getCurrency >= eTeam.MyTeam[i].rebuildCost() && eTeam.MyTeam[i].rebuildCost() > 100)
						{
							int tmp = eTeam.Rebuild(i, true);
							if (eTeam.MyTeam[i].getLevel == 1)
								eTeam.getTeamLog = getFightLog = getWarningLog = Environment.NewLine + "+++ " + eTeam.getName + " : " + eTeam.MyTeam[i].getName + " has been rebuilt! @ " + DateTime.Now.ToString();
							else 
								eTeam.getTeamLog = getFightLog = getWarningLog = string.Format("\n--- {0} : {1} failed the rebuild (+{2} Analysis) @ {3}", eTeam.getName, eTeam.MyTeam[i].getName, tmp, DateTime.Now.ToString());
						}
					}
				}
				// if has equipment repair / upgrade it
				if (shopper.getEquipWeapon != null)
				{
					// Repair
					if (eTeam.getCurrency > (shopper.getEquipWeapon.ePrice / 10)
						&& shopper.getEquipWeapon.eDurability < shopper.getEquipWeapon.eMaxDurability * repairPercent)
					{
						int orig = shopper.getEquipWeapon.eDurability;
						shopper.getEquipWeapon.eDurability = shopper.getEquipWeapon.eMaxDurability = (int)(shopper.getEquipWeapon.eMaxDurability * .9);
						eTeam.getCurrency -= (shopper.getEquipWeapon.ePrice / 10);
						// Arena makes 10%
						getGameCurrency += (shopper.getEquipWeapon.ePrice / 100);
						getFightLog = Environment.NewLine + "### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", shopper.getEquipWeapon.ePrice / 10, shopper.getEquipWeapon.eName) + Environment.NewLine + "  " + shopper.getEquipWeapon.ToString(orig);
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipWeapon.ePrice / 10) + shopper.getEquipWeapon.eName;
					}
					// upgrade
					if (eTeam.getCurrency > shopper.getEquipWeapon.eUpgradeCost && (PurchaseUgrade || bAutomated) && shopper.getEquipWeapon.eMaxDurability > 50)
					{
						int tmpUpgrade = (shopper.getEquipWeapon.eUpgradeCost);
						eTeam.getCurrency -= tmpUpgrade;
						// Arena makes 10%
						getGameCurrency += (tmpUpgrade) / 10;
						shopper.getEquipWeapon.upgrade(getShopUpgradeValue, RndVal);
						getFightLog = Environment.NewLine + "+++ " + eTeam.getName + ":" + shopper.getName + " Upgraded " + String.Format("{1} ({0:n0}) ", tmpUpgrade, shopper.getEquipWeapon.eName, shopper.getEquipWeapon.eUpgradeCost) + Environment.NewLine + "  " + shopper.getEquipWeapon.ToString();
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + shopper.getEquipWeapon.eName;
					}
				}
				else
				{
					// buy
					int index = 0;
					foreach (Equipment eEquip in storeEquipment)
					{
						if (eTeam.getCurrency > eEquip.ePrice && eEquip.eType == "Weapon" && (PurchaseUgrade || bAutomated))
						{
							eTeam.getCurrency -= eEquip.ePrice;
							getGameCurrency += eEquip.ePrice;
							shopper.getEquipWeapon = eEquip;
							storeEquipment.RemoveAt(index);
							getFightLog = Environment.NewLine + "$$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", eEquip.ePrice, eEquip.eName) + Environment.NewLine + "  " + eEquip.ToString();
							eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " purchased " + String.Format("({0:n0}) ", eEquip.ePrice) + eEquip.eName;
							break;
						}
						index++;
					}
				}
				if (shopper.getEquipArmour != null)
				{
					// Repair 
					if (eTeam.getCurrency > (shopper.getEquipArmour.ePrice / 10)
						&& shopper.getEquipArmour.eDurability < shopper.getEquipArmour.eMaxDurability * repairPercent)
					{
						int orig = shopper.getEquipArmour.eDurability;
						shopper.getEquipArmour.eDurability = shopper.getEquipArmour.eMaxDurability = (int)(shopper.getEquipArmour.eMaxDurability * .9);
						eTeam.getCurrency -= (shopper.getEquipArmour.ePrice / 10);
						// Arena makes 10%
						getGameCurrency += (shopper.getEquipArmour.ePrice / 100);
						getFightLog = Environment.NewLine + "### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", shopper.getEquipArmour.ePrice / 10, shopper.getEquipArmour.eName) + Environment.NewLine + "  " + shopper.getEquipArmour.ToString(orig);
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipArmour.ePrice / 10) + shopper.getEquipArmour.eName;
					}
					// upgrade
					if (eTeam.getCurrency > shopper.getEquipArmour.eUpgradeCost && (PurchaseUgrade || bAutomated) && shopper.getEquipArmour.eMaxDurability > 50)
					{
						int tmpUpgrade = (shopper.getEquipArmour.eUpgradeCost);
						eTeam.getCurrency -= tmpUpgrade;
						// Arena makes 10%
						getGameCurrency += (tmpUpgrade) / 10;
						shopper.getEquipArmour.upgrade(getShopUpgradeValue, RndVal);
						getFightLog = Environment.NewLine + "+++ " + eTeam.getName + ":" + shopper.getName + " Upgraded " + String.Format("{1} ({0:n0}) ", tmpUpgrade, shopper.getEquipArmour.eName, shopper.getEquipArmour.eUpgradeCost) + Environment.NewLine + "  " + shopper.getEquipArmour.ToString();
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + shopper.getEquipArmour.eName;
					}
				}
				else
				{
					// buy
					int index = 0;
					foreach (Equipment eEquip in storeEquipment)
					{
						if (eTeam.getCurrency > eEquip.ePrice && eEquip.eType == "Armour" && (PurchaseUgrade || bAutomated))
						{
							eTeam.getCurrency -= eEquip.ePrice;
							getGameCurrency += eEquip.ePrice;
							shopper.getEquipArmour = eEquip;
							storeEquipment.RemoveAt(index);
							getFightLog = Environment.NewLine + "$$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", eEquip.ePrice, eEquip.eName) + Environment.NewLine + "  " + eEquip.ToString();
							eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " purchased " + String.Format("({0:n0}) ", eEquip.ePrice) + eEquip.eName;
							break;
						}
						index++;
					}
				}
			}
		}
		public void buildingMaintenance()
		{
			int MaintCost = 0;

			switch (RndVal.Next(100))
			{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					if (ArenaLvlMaint > 0)
					{
						// Arena Maintenance
						MaintCost = roundValue(RndVal.Next(ArenaLvlMaint));
						ArenaLvlMaint -= (int)((double)ArenaLvlMaint * 0.01);
						getGameCurrency -= MaintCost;
						GameCurrencyLog -= MaintCost;
						getFightLog = Environment.NewLine + "*** Arena maintenance cost " + String.Format("{0:n0}", MaintCost);
					}
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					if (MonsterDenLvlMaint > 0)
					{
						// Monster Den Maintenance
						MaintCost = roundValue(RndVal.Next(MonsterDenLvlMaint));
						MonsterDenLvlMaint -= (int)((double)MonsterDenLvlMaint * 0.01);
						getGameCurrency -= MaintCost;
						GameCurrencyLog -= MaintCost;
						getFightLog = Environment.NewLine + "*** Monster den maintenance cost " + String.Format("{0:n0}", MaintCost);
					}
					break;
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
					if (ShopLvlMaint > 0)
					{
						// Shop Maintenance
						MaintCost = roundValue(RndVal.Next(ShopLvlMaint));
						ShopLvlMaint -= (int)((double)ShopLvlMaint * 0.01);
						getGameCurrency -= MaintCost;
						GameCurrencyLog -= MaintCost;
						getFightLog = Environment.NewLine + "*** Shop maintenance cost " + String.Format("{0:n0}", MaintCost) ;
					}
					break;
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
					if (ResearchDevMaint > 0)
					{
						// Research and Development Maintenance
						MaintCost = roundValue(RndVal.Next(ResearchDevMaint));
						ResearchDevMaint -= (int)((double)ResearchDevMaint * 0.01);
						getGameCurrency -= MaintCost;
						GameCurrencyLog -= MaintCost;
						getFightLog = Environment.NewLine + "*** Research and Development maintenance cost " + String.Format("{0:n0}", MaintCost);
					}
					break;
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
					// Tax
					MaintCost = roundValue((int)((ArenaLvlMaint-- * 0.1) + (MonsterDenLvlMaint-- * 0.1) + (ShopLvlMaint-- * 0.1) + (ResearchDevMaint-- * 0.1)));
					getGameCurrency -= MaintCost;
					GameCurrencyLog -= MaintCost;
					getFightLog = Environment.NewLine + "*** Taxes cost " + String.Format("{0:n0}", MaintCost );
					break;
				case 50:
					// Monster outbreak
					MaintCost = roundValue((int)((ArenaLvlMaint--) + (MonsterDenLvlMaint--) + (ShopLvlMaint--) + (ResearchDevMaint--) - MonsterDenRepairs));
					startMonsterOutbreak(MaintCost);
					break;
				case 95:
					if (ShopStock > storeEquipment.Count && getGameCurrency <= 0)
					{
						getFightLog = Environment.NewLine + "!!! Free stock ";
						storeEquipment.Add(new Equipment(AddArmour(), RndVal.Next(5, ShopMaxStat), RndVal.Next(100, ShopMaxDurability), RndVal));
					}
					break;
				case 99:
					int team = RndVal.Next(GameTeams.Count + 1);
					// sponsored the arena
					if (team == GameTeams.Count)
					{
						MaintCost += MaxTeams * getArenaLvl * 1000;
						getGameCurrency += MaintCost;
						getFightLog = Environment.NewLine + "!!! Arena Received a sponsor! +" + String.Format("{0:n0}", MaintCost);
					}
					// sponsored a team
					else
					{
						MaintCost += getArenaLvl * 1000 * (GameTeams[team].Win + 1);
						GameTeams[team].getCurrency += MaintCost;
						getFightLog = Environment.NewLine + "!!! " + GameTeams[team].getName + " Received a sponsor! +" + String.Format("{0:n0}", MaintCost) ;
					}
					break;
			}
		}

        public void getNext(int index)
        {
			// get robo that is attacking
			Robot Attacker = GameTeam1[index].MyTeam[0];
			int maxSpeed = 0;
			int team = 1;
			foreach  (Robot eRobot in GameTeam1[index].MyTeam)
			{
				if ((eRobot.getCurrentSpeed > maxSpeed || (eRobot.getCurrentSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					Attacker = eRobot;
					maxSpeed = eRobot.getCurrentSpeed;
				}
			}
			foreach (Robot eRobot in GameTeam2[index].MyTeam)
			{
				if ((eRobot.getCurrentSpeed > maxSpeed || (eRobot.getCurrentSpeed == maxSpeed && RndVal.Next(1000) > 500))
					&& eRobot.HP > 0)
				{
					team = 2;
					Attacker = eRobot;
					maxSpeed = eRobot.getCurrentSpeed;
				}
			}
			// if all characters have zero for current speed, reset speed
			if (maxSpeed == 0)
			{
				// all characters speed is zero set speed
				foreach (Robot eRobot in GameTeam1[index].MyTeam)
					eRobot.getCurrentSpeed = RndVal.Next(1, eRobot.getSpeed);
				foreach (Robot eRobot in GameTeam2[index].MyTeam)
					eRobot.getCurrentSpeed = RndVal.Next(1, eRobot.getSpeed);
			}
			else
			{
				Attacker.turnOver();
				if (team == 2)
					Attack(Attacker, GameTeam2[index], GameTeam1[index]);
				else
					Attack(Attacker, GameTeam1[index], GameTeam2[index]);
			}
		}

        public void Attack(Robot attacker, Team attackers, Team defenders)
        {
			Robot defender = new Robot(1, "test", 1, false);
			Skill currSkill = AllSkills[0];
			bool breakLoop = false;
			// Loop through attackers strategies
			foreach ( Strategy currStrategy in  attacker.RoboStrategy)
			{
				if (currStrategy.StrategicSkill.cost <= attacker.MP)
				{
					if (currStrategy.StrategicSkill.target == "Enemy")
					{
						if (currStrategy.StrategicSkill.type == "Single attack" || currStrategy.StrategicSkill.type == "Single tech")
						{
							// check if conditions are met to use skill
							switch (currStrategy.FieldCondition)
							{
								case "Num Enemies":
									if (currStrategy.Condition == "Greater than")
									{
										if (defenders.getNumRobos(false) > currStrategy.ConditionValue)
										{
											defender = getDefender(attacker, defenders, currStrategy);
											currSkill = currStrategy.StrategicSkill;
											breakLoop = true;
										}
									}
									break;
							}
						}
						else if (currStrategy.StrategicSkill.type == "Multiple attack" || currStrategy.StrategicSkill.type == "Multiple tech")
						{
							// check if conditions are met to use skill
							switch (currStrategy.FieldCondition)
							{
								case "Num Enemies":
									if (currStrategy.Condition == "Greater than")
									{
										if (defenders.getNumRobos(false) > currStrategy.ConditionValue)
										{
											breakLoop = true;
											currSkill = currStrategy.StrategicSkill;
										}
									}
									break;
							}
						}
					}
				}
				if (breakLoop)
					break;
			}
			attacker.setStrike(currSkill);
			attacker.MP -= currSkill.cost;
			// if defender has not been set we are attacking multiple
			if (defender.getName.Equals("test"))
			{
				foreach (Robot eDefender in defenders.MyTeam)
				{
					if (eDefender.HP > 0 && RndVal.Next(attacker.getLevel) <= RndVal.Next(eDefender.getLevel))
					{
						eDefender.damage(attacker, currSkill);
					}
				}
			}
			// attacking a single enemy
			else
				defender.damage(attacker, currSkill);
			if (defender.RobotLog.Length > 0)
			{
				defenders.getTeamLog = defender.RobotLog;
				defender.RobotLog = "";
			}
			if (attacker.RobotLog.Length > 0)
			{
				attackers.getTeamLog = attacker.RobotLog;
				attacker.RobotLog = "";
			}
		}
		public Robot getDefender(Robot attacker, Team defenders, Strategy currStrategy)
		{
			Robot defender = new Robot(1, "test", 1, false);
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
								{
									defender = eDefender;
								}
							}
						}
						if (currStrategy.Focus == "Highest")
						{
							if (defender.HP < eDefender.HP || defender.getName == "test")
							{
								if (eDefender.HP > 0)
								{
									defender = eDefender;
								}
							}
						}
						break;
					case "Level":
						if (currStrategy.Focus == "Current")
						{
							if ((eDefender.getLevel >= attacker.getLevel && (eDefender.getLevel < defender.getLevel || defender.getLevel < attacker.getLevel)) || defender.getName == "test")
							{
								if (eDefender.HP > 0)
								{
									defender = eDefender;
								}
							}
						}
						break;
				}
			}
			return defender;
		}
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Team : Common
    {
		[JsonProperty]
		public List<Robot> MyTeam;
		[JsonProperty]
		private int Score;
		private int ScoreLog;
		[JsonProperty]
		public int Win;
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
		[JsonProperty]
		public Boolean Automated;
		[JsonIgnore]
		private string TeamLog;
		public bool shownDefeated;

		public int getAvailableRobo
		{
			get { return MaxRobo - MyTeam.Count; }
			set { MaxRobo = value; }
		}
		public int getScore
		{
			get { return Score; }
			set
			{
				ScoreLog += value - Score;
				Score = value;
				if (Score >= GoalScore)
				{
					GoalScore *= 2;
					GoalScore = SkipFour(GoalScore);
					MaxRobo++;
				}
			}
		}
		public int getScoreLog
		{
			get { return ScoreLog; }
			set { ScoreLog = value; }
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
				if (value - Currency > 0)
					CurrencyLog += value - Currency;
				Currency = value;
			}
			get { return Currency; }
		}
		public int getDifficulty
		{
			set
			{
				DifficultyLog += value - Difficulty;
				Difficulty = value;
			}
			get { return Difficulty; }
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
		public List<Robot> getRobo
		{
			get { return MyTeam; }
			set { MyTeam = value; }
		}

		public Team(int pScore, int pGoalScore, int pWin, int pCurrency, int pDifficulty, int pMaxRobo, int pRoboCost, string pTeamName, bool pAutomated)
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
			TeamLog = "";
			Automated = pAutomated;
			Win = pWin;
			shownDefeated = false;
		}

		public Team(int baseStats)
        {
            MyTeam = new List<Robot> { new Robot(baseStats,setName("robot"), RndVal.Next(8), false) };
            Score = 0;
			Difficulty = 1;
            GoalScore = 20;
            MaxRobo = 1;
			RoboCost = 100;
			isMonster = false;
			TeamLog = "";
			Automated = true;
			Win = 0;
			TeamName = name1[RndVal.Next(name1.Length)] + " " + name3[RndVal.Next(name3.Length)];
			shownDefeated = false;
		}
		public Team(int numMonsters, int Difficulty, int MonsterLvl)
		{
			MyTeam = new List<Robot> { };
			for (int i = 0; i < numMonsters; i++)
			{
				int Monster = RndVal.Next(numMonsters);
				MyTeam.Add(new Robot(Difficulty, setName("boss", Monster), Monster, true));
				// Add equipment
				MyTeam[i].getEquipWeapon = new Equipment(true, MonsterLvl, 10000, RndVal);
				MyTeam[i].getEquipArmour = new Equipment(false, MonsterLvl, 10000, RndVal);
				for (int ii = 1; ii < MonsterLvl; ii++)
				{
					MyTeam[i].levelUp(RndVal);
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
			TeamLog = "";
			Win = 0;
			TeamName = BossName[RndVal.Next(BossName.Length)] + " " + name2[RndVal.Next(name2.Length)];
			Automated = false;
			shownDefeated = false;
		}
		public Team(int numMonsters, int Difficulty, int MonsterLvl, int findMonster, ref Team MonsterOutbreak)
		{
			if (Difficulty < 1)
				Difficulty = 1;
			MyTeam = new List<Robot> { };
			int minLvl = Difficulty - (numMonsters / 2) > 0 ? Difficulty - (numMonsters/2) : 1;
			int maxLvl = Difficulty + (numMonsters / 2);
			for (int i = 0; i < numMonsters; i++)
			{
				int Monster = RndVal.Next(MonsterLvl);
				Robot tmpMon = new Robot((Difficulty / 5), setName("monster", Monster), Monster, true);
				int index = -1;
				if (MonsterOutbreak != null)
				{
					for (int ii = 0; ii < MonsterOutbreak.MyTeam.Count; ii++)
					{
						if (MonsterOutbreak.MyTeam[ii].getLevel <= maxLvl && MonsterOutbreak.MyTeam[ii].getLevel >= minLvl && (index == -1 || RndVal.Next(100) > 75))
						{
							tmpMon = MonsterOutbreak.MyTeam[ii];
							index = ii;
						}
					}
				}
				MyTeam.Add(tmpMon);
				if (index >= 0)
					MonsterOutbreak.MyTeam.RemoveAt(index);
				else
				{
					// Add equipment
					MyTeam[i].getEquipWeapon = new Equipment(true, RndVal.Next(1, Difficulty), RndVal.Next(100, numMonsters * 100), RndVal);
					MyTeam[i].getEquipArmour = new Equipment(false, RndVal.Next(1, Difficulty), RndVal.Next(100, numMonsters * 100), RndVal);
					int tmp = RndVal.Next(minLvl, maxLvl);
					for (int ii = 1; ii < tmp; ii++)
					{
						MyTeam[i].levelUp(RndVal);
						MyTeam[i].HP = MyTeam[i].getTHealth();
						MyTeam[i].MP = MyTeam[i].getTEnergy();
					}
				}
			}
			MyTeam.Sort();
			resetLogs();
			Score = 0;
			GoalScore = 0;
			MaxRobo = 0;
			RoboCost = 0;
			isMonster = true;
			TeamLog = "";
			TeamName = name1[RndVal.Next(name1.Length)] + " " + name2[RndVal.Next(name2.Length)];
			Automated = false;
			shownDefeated = false;
		}
		[JsonIgnore]
		public string getTeamLog
		{
			set
			{
				if (!value.Contains("test"))
				{
					if (TeamLog.Length > 5000)
						TeamLog = value + TeamLog.Substring(0, 1500);
					else
						TeamLog = value + TeamLog;
				}
			}
			get { return TeamLog; }
		}
		public void clean()
		{
			foreach (Robot eRobot in MyTeam)
				eRobot.clean();
		}
		public void changeAutomated()
		{
			Automated = !Automated;
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

		public string getTeamStats(int[] PadRight)
		{
			string strStats = "";
			// If this team is not in Team1 or Team1 list
			string strBuild = "";
			int counter = 0;
			int maxRobos = 50;
			if (getName.Equals("Arena") || getName.Equals("Monster Outbreak")) maxRobos = 10;
			if (getAvailableRobo > 0) strBuild = "!";
			strStats = String.Format("{0} C:{1:n0}({2:n0}) W:{8:n0} S:{3:n0}{4}({5:n0}) D:{6:n0}({7:n0})",getName.PadRight(15).Substring(0,15), Currency, CurrencyLog, Score, strBuild, ScoreLog, Difficulty, DifficultyLog, Win);
			foreach (Robot eRobo in MyTeam)
			{
				if (counter < maxRobos)
				{
					strStats += eRobo.getRoboStats(PadRight, getCurrency);
					if (eRobo.getKO <= 3) counter++;
				}
				else
				{
					eRobo.getRoboStats(PadRight, getCurrency);
					if (eRobo.getKO <= 3)
					{
						if (counter == maxRobos)
							strStats += Environment.NewLine + "->";
						if (counter % 5 == 0)
							strStats += " ";
						strStats += ".";
						counter++;
					}

				}
			}
			return strStats;
		}
				
		public void fixTech()
		{
			foreach (Robot eRobo in MyTeam) eRobo.fixTech();
		}
		public void Rebuild(bool pay)
		{
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].rebuildCost() > 100)
					Rebuild(MyTeam[i], pay);
			}
		}
		public void Rebuild(Robot robo, bool pay)
		{
			int robotIndex = 0;
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].getName.Equals(robo.getName))
				{
					robotIndex = i;
				}
			}
			Rebuild(robotIndex, pay);
		}
		public int Rebuild(int robo, bool pay)
		{
			int bonusAnalysis = 0;
			if (!pay || MyTeam[robo].rebuildCost() <= getCurrency)
			{
				if (pay)
				{
					getCurrency -= MyTeam[robo].rebuildCost();
					MyTeam[robo].RebuildPercent++;
					MyTeam[robo].rebuildBonus = 0;
				}
				if (!pay || MyTeam[robo].RebuildPercent > RndVal.Next(100))
				{
					// current base stats or level / 5 which ever is higher
					int baseStats = (MyTeam[robo].getLevel / 5 <= 0 ? 1 : MyTeam[robo].getLevel / 5);
					string strName = MyTeam[robo].getName;
					if (MyTeam[robo].getDexterity + MyTeam[robo].getStrength + MyTeam[robo].getAgility + MyTeam[robo].getTech + MyTeam[robo].getAccuracy > baseStats)
						baseStats = MyTeam[robo].getDexterity + MyTeam[robo].getStrength + MyTeam[robo].getAgility + MyTeam[robo].getTech + MyTeam[robo].getAccuracy;
					MyTeam[robo] = new Robot(baseStats, setName("robot"), RndVal.Next(8), false);
					MyTeam[robo].getName = strName;
				}
				else
				{
					bonusAnalysis = RndVal.Next((int)MyTeam[robo].RebuildPercent * 10);
					MyTeam[robo].getCurrentAnalysis += bonusAnalysis;
				}
			}
			return bonusAnalysis;
		}
		public int getNumRobos(bool pShowDefeated)
		{
			int num = 0;
			if (pShowDefeated && shownDefeated)
			{
				num = 1;
				shownDefeated = true;
			}
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
					CurrencyLog -= cost;
					robo.HP += value;
                    robo.MP += value;
                    robo.getKO = 0;
                }
                else if (robo.MP < robo.getTEnergy())
                    robo.MP++;
				if (robo.HP < robo.getTHealth()) { fullHP = false; }
				// level up
				if (robo.getAnalysisLeft() <= 0)
				{
					robo.levelUp(RndVal);
					if (robo.RobotLog.Length > 0 && !robo.name1.Equals("test"))
					{
						getTeamLog = robo.RobotLog;
						robo.RobotLog = "";
					}
				}
			}
			MyTeam.Sort();
			return fullHP;
		}
		public string setName(string Robo)
		{
			return setName(Robo, 0);
		}
		
		public string setName(String type, int MonsterLevel)
        {
            string name = "";
            if (type.Equals("robot"))
            {
				if (RndVal.Next(100) > 10)
					name = (RoboName[RndVal.Next(RoboName.Length)] + RandomString(4));
				else
					name = RandomString(10);
			}
			else if (type.Equals("monster"))
			{
				name = (MonsterName[MonsterLevel]);
			}
			else if (type.Equals("boss"))
			{
				name = (BossName[RndVal.Next(BossName.Length)]) + " " + (MonsterName[MonsterLevel]);
			}
			return name;
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Robot : Common, IComparable<Robot>
	{
		[JsonProperty]
		public List<Skill> ListSkills;
		[JsonProperty]
		public List<Strategy> RoboStrategy;
		[JsonProperty]
		private Equipment EquipWeapon;
		[JsonProperty]
		private Equipment EquipArmour;
		[JsonProperty]
		private string RobotName;
		public string tmpMessage;
		public int dmg;
		public bool crit;
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
		public int rebuildBonus;
		[JsonProperty]
		private int Analysis;
		[JsonProperty]
		private int CurrentAnalysis;
		[JsonProperty]
		public int RebuildPercent;
		private int AnalysisLog;
		public string RobotLog;
		public char cSkill = ' ';
		public bool bMonster = false;
		public bool bIsMonster = false;
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
			get { return CurrentSpeed; }
			set { CurrentSpeed = value; }
		}
		public int getLevel
		{
			get { return Level; }
			set { Level = value; }
		}
		public int getLevelLog
		{
			get { return LevelLog; }
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
			RobotLog = "";
			Image = pImage;
			ListSkills = new List<Skill> {};
			RoboStrategy = new List<Strategy> {};
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
			crit = false;
			dmg = 0;
			RebuildPercent = 10;
		}
		public Robot(bool isNew) : this(1, "test", 1, true) { }
		public Robot(string strName, int RoboImage, Boolean isMonster) : this(10, strName, RoboImage, isMonster) { }
		// New Robot object
		public Robot(int iBasePoints, string strName, int imageIndex, Boolean isMonster)
		{
			ListSkills = new List<Skill> { AllSkills[0].getSkill() };
			int RandomValue = 0;
			getName = strName;
			Analysis = 95;
			CurrentAnalysis = 0;
			Level = 0;
			message = "";
			RobotLog = "";
			if (isMonster)
			{
				Image = MonsterImages[imageIndex];
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Highest", "HP") };
				bIsMonster = true;
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
			levelUp(RndVal);
			CurrentHealth = getTHealth();
			CurrentEnergy = getTEnergy();
			crit = false;
			dmg = 0;
			RebuildPercent = 10;
		}

		public Robot DupeMonster()
		{
			return new Robot(MonsterName[RndVal.Next(MonsterName.Length)], Dexterity, Strength, Agility, Tech, Accuracy, Health, Energy, Armour, Damage, Hit, MentalStrength, MentalDefense, Image, Speed, Level, Analysis, 0);
		}
		public void clean()
		{
			message = "";
			tmpImage = "";
			crit = false;
			dmg = 0;
		}
		public void sortSkills()
		{
			if (getTMentalStrength() > getTDamage())
				RoboStrategy.Sort(delegate (Strategy cStrategy, Strategy cStrategy2)
				{
					int result = cStrategy.StrategicSkill.type.Contains("attack").CompareTo(cStrategy2.StrategicSkill.type.Contains("attack"));
					if (result == 0 || cStrategy2.StrategicSkill.cost == 0)
						result = cStrategy.StrategicSkill.cost.CompareTo(cStrategy2.StrategicSkill.cost) * -1;
					return result;
				});
			else
				RoboStrategy.Sort();
		}
		public int CompareTo(Robot robo)
		{
			return this.getLevel.CompareTo(robo.getLevel)*-1;
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
			if (HP > getTHealth()) HP = getTHealth();
			if (MP > getTEnergy()) MP = getTEnergy();
		}

		public void resetLog()
		{
			LevelLog = 0;
			AnalysisLog = 0;
		}

		public string getRoboStats(int[] PadRight, int teamCurrency)
		{
			char cRebuild = ' ';
			string strStats = "";
			string strMsg = "";
			if (HP == 0)
			{
				getKO++;
			}
			if (rebuildCost() > 100 && !bIsMonster)
				if (rebuildCost() > teamCurrency)
					cRebuild = '|';
				else
					cRebuild = '+';
			if (dmg > 0)
			{
				strMsg = " " + dmg.ToString() + " dmg";
				if (crit) strMsg += "!";
				dmg = 0;
				crit = false;
			}
			if (getKO <= 3)
				strStats = string.Format("\n{0}{1}{2} L:{3}({4}) A:{5} MP:{6} HP:{7}{8} ",cRebuild, cSkill, 
					getName.PadRight(PadRight[0]),
					String.Format("{0:n0}", getLevel).PadLeft(PadRight[1]),
					String.Format("{0:n0}", LevelLog).PadLeft(PadRight[2]),
					String.Format("{0:n0}", getAnalysisLeft()).PadLeft(PadRight[3]),
					String.Format("{0:n0}", MP).PadLeft(PadRight[4]), 
					String.Format("{0:n0}", HP).PadLeft(PadRight[5]), 
					strMsg);

			cSkill = ' ';
			return strStats;
		}
		public int rebuildCost()
		{
			int cost = 100;
			// if base stats will go up add cost
			if (Level / 5 > (Dexterity + Strength + Agility + Tech + Accuracy) )
			{
				cost = 100 * (int)Math.Pow(2,(Level / 5) / (rebuildBonus + 1)) - ResearchDevRebuild;
				if (cost <= 100) cost = 101;
			}
			return roundValue(cost);
		}
		
        public void setStrike(Skill usedSkill)
        {
            tmpImage = usedSkill.img;
			cSkill = usedSkill.sChar;
		}
		public void setHurt()
		{
			tmpImage = hurt;
		}
		public void setBlock()
		{
			tmpImage = blocked;
		}
		public void setField()
		{
			tmpImage = field;
		}
		public void setMiss()
		{
			tmpImage = miss;
		}
		
		public long getAnalysisLeft()
		{
			int retval = Analysis - CurrentAnalysis;
			if (retval < 0) retval = 0;
			return retval;
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
		public void levelUp(Random tmp)
		{
			LevelLog++;
			Level++;
			Analysis += 5;
			AnalysisLog = 0;
			CurrentAnalysis = 0;
			Health += Dexterity + Strength + Agility;
			Energy += Tech + Accuracy;
			Armour += Dexterity;
			Damage += Strength;
			Hit += Accuracy;
			Speed += Agility;
			MentalStrength += Tech;
			MentalDefense += Tech;
			RobotLog = Environment.NewLine + getName + " reached level " + getLevel;
			if (Level % 3 != 0 && ListSkills.Count >= 1) // new skills every 3 levels
			{
				Skill upSkill = ListSkills[tmp.Next(ListSkills.Count)];
				if (upSkill.cost == 0)
					upSkill.strength++;
				// others add ten percent but also add an extra cost if they can afford it. 
				else if (upSkill.cost < Energy)
				{
					upSkill.strength += 10;
					upSkill.cost += (upSkill.cost / 10 > 1 ? upSkill.cost / 10 : 1);
				}
			}
			else
			{
				bool found = false;
				Skill upSkill = AllSkills[tmp.Next(AllSkills.Length)];
				foreach (Skill eSkill in ListSkills)
				{
					if (eSkill.name.Equals(upSkill.name))
					{
						// attack just add one percent
						if (eSkill.cost == 0)
							eSkill.strength++;
						// others add ten percent but also add an extra cost if they can afford it. 
						else if (eSkill.cost < Energy)
						{
							eSkill.strength += 10;
							eSkill.cost += (eSkill.cost / 10 > 1 ? eSkill.cost / 10 : 1);
						}
						found = true;
					}
				}
				if (!found)
				{
					ListSkills.Add(upSkill.getSkill());
					if (upSkill.type.Equals("Single attack") || upSkill.type.Equals("Single tech"))
					{
						if (!bIsMonster)
							RoboStrategy.Add(new Strategy(ListSkills[ListSkills.Count - 1], "Num Enemies", "Greater than", 0, "Current", "Level"));
						else
							RoboStrategy.Add(new Strategy(ListSkills[ListSkills.Count - 1], "Num Enemies", "Greater than", 0, "Highest", "HP"));
					}
					else
						RoboStrategy.Add(new Strategy(ListSkills[ListSkills.Count - 1], "Num Enemies", "Greater than", 3, "Current", "Level"));

					sortSkills();
				}
			}
		}

		public void damage(Robot attacker, Skill currSkill)
		{
			bool critical = RndVal.Next(100) > 95;
			// If agility greater than hit attacker missed
			if (RndVal.Next(getTSpeed()) > RndVal.Next(attacker.getTHit()) && !critical)
			{
				setMiss();
			}
			// if armour greater than hit attack is blocked
			else if (RndVal.Next(getTArmour()) > RndVal.Next(attacker.getTHit()) && !critical
				&& (currSkill.type.Equals("Single attack") || currSkill.type.Equals("Multiple attack")))
			{
				setBlock();
			}
			// if tech defense greater than tech attack attack is blocked
			else if (RndVal.Next(getTMentalDefense()) > RndVal.Next(attacker.getTHit()) && !critical
				&& (currSkill.type.Equals("Single tech") || currSkill.type.Equals("Multiple tech")))
			{
				setField();
			}
			// damaged
			else
			{
				setHurt();
				int minDmg = 0;
				int maxDmg = 0;
				string strCrit = "";
				if (currSkill.type.Equals("Single attack") || currSkill.type.Equals("Multiple attack"))
				{
					if (critical)
					{
						minDmg = maxDmg = attacker.getTDamage();
						crit = true;
						strCrit = "!";
					}
					else
					{
						minDmg = 1;
						maxDmg = attacker.getTDamage();
					}
				}
				else
				{
					if (critical)
					{
						minDmg = maxDmg = attacker.getTMentalStrength();
						crit = true;
						strCrit = "!";
					}
					else
					{
						minDmg = 1;
						maxDmg = attacker.getTMentalStrength();
					}
				}
				int tmpDmg = (int)((double)RndVal.Next(minDmg, maxDmg) * ((double)currSkill.strength / 100.0));
				if (tmpDmg < 1) tmpDmg = 1;
				HP -= tmpDmg;
				dmg += tmpDmg;
				message += " " + tmpDmg.ToString() + " dmg" + strCrit;
				// don't bring down durability all the time for multiple tech and multiple attack
				if (currSkill.type.Equals("Single attack") || currSkill.type.Equals("Single tech") || RndVal.Next(100) > 70)
				{
					if (EquipArmour != null)
					{
						EquipArmour.eDurability--;
						if (EquipArmour.eDurability == 0)
						{
							message += Environment.NewLine + EquipArmour.eName + " broke!";
							RobotLog = Environment.NewLine + getName + " " + EquipArmour.eName + " broke!";
							if (!bIsMonster)
							{
								Globalmessage = string.Format("\n--- {0} {1} broke! ({2:n0})", getName, EquipArmour.eName, EquipArmour.eMaxDurability);
								if (EquipArmour.eMaxDurability > 100)
									getWarningLog = string.Format("\n--- {0} {1} broke! ({2:n0}) @ {3}", getName, EquipArmour.eName, EquipArmour.eMaxDurability, DateTime.Now.ToString());
							}
							EquipArmour = null;
							if (HP > getTHealth()) HP = getTHealth();
							if (MP > getTEnergy()) MP = getTEnergy();
						}
					}
					if (attacker.EquipWeapon != null)
					{
						attacker.EquipWeapon.eDurability--;
						if (attacker.EquipWeapon.eDurability == 0)
						{
							attacker.message += attacker.EquipWeapon.eName + " broke!";
							attacker.RobotLog = Environment.NewLine + attacker.getName + " " + attacker.EquipWeapon.eName + " broke!";
							if (!attacker.bIsMonster)
							{
								Globalmessage = string.Format("\n--- {0} {1} broke! ({2:n0})", attacker.getName, attacker.EquipWeapon.eName, attacker.EquipWeapon.eMaxDurability);
								if (attacker.EquipWeapon.eMaxDurability > 100)
									getWarningLog = (string.Format("\n--- {0} {1} broke! ({2:n0}) @ {3}", attacker.getName, attacker.EquipWeapon.eName, attacker.EquipWeapon.eMaxDurability, DateTime.Now.ToString()));
							}
							attacker.EquipWeapon = null;
							if (attacker.HP > attacker.getTHealth()) attacker.HP = attacker.getTHealth();
							if (attacker.MP > attacker.getTEnergy()) attacker.MP = attacker.getTEnergy();
						}
					}
					// get experience if attackers level is not higher
					if (attacker.getLevel <= getLevel )
					{
						attacker.getCurrentAnalysis += getLevel - attacker.getLevel + 1;
						if (HP == 0) { attacker.getCurrentAnalysis += 10; }
					}
					// if attacker is higher level, get less exp
					else if (RndVal.Next(100) > 80)
					{
						attacker.getCurrentAnalysis++;
					}
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
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n", EquipWeapon.eDurability, EquipWeapon.eMaxDurability, EquipWeapon.eName, EquipWeapon.eUpgrade);
				wHealth = EquipWeapon.eHealth;
				wEnergy = EquipWeapon.eEnergy;
				wArmour = EquipWeapon.eArmour;
				wDamage = EquipWeapon.eDamage;
				wHit = EquipWeapon.eHit;
				wSpeed = EquipWeapon.eSpeed;
				wMentalStr = EquipWeapon.eMentalStrength;
				wMentalDef = EquipWeapon.eMentalDefense;
			}
			else
				tmp += "<Unequiped>" + Environment.NewLine;
			if (EquipArmour != null)
			{
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n", EquipArmour.eDurability, EquipArmour.eMaxDurability, EquipArmour.eName, EquipArmour.eUpgrade);
				aHealth = EquipArmour.eHealth;
				aEnergy = EquipArmour.eEnergy;
				aArmour = EquipArmour.eArmour;
				aDamage = EquipArmour.eDamage;
				aHit = EquipArmour.eHit;
				aSpeed = EquipArmour.eSpeed;
				aMentalStr = EquipArmour.eMentalStrength;
				aMentalDef = EquipArmour.eMentalDefense;
			}
			else
				tmp += "<Unequiped>" + Environment.NewLine;
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
			tmp += ("Rebuild %: " + String.Format("{0:n0}", RebuildPercent) + Environment.NewLine);
			foreach (Strategy eStrategy in RoboStrategy)
			{
				tmp += (String.Format("{0} ({2:n0}-{1:n0}%) {3}", eStrategy.StrategicSkill.name, eStrategy.StrategicSkill.strength, eStrategy.StrategicSkill.cost, eStrategy.StrategicSkill.sChar) + Environment.NewLine);
			}
			return tmp;
        }
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Skill
	{
		[JsonProperty]
		public string name;
		[JsonProperty]
		public string target; // Enemy or Ally
		[JsonProperty]
		public int strength; // int representing amount of damage / healing 
		[JsonProperty]
		public string type; // damage single, or damage multiple
		[JsonProperty]
		public int cost; // energy cost
		[JsonProperty]
		public string img;
		[JsonProperty]
		public char sChar;
		public Skill() { }
        public Skill(string skillName, string skillTarget, int skillStrength, string skilltype, int pCost, string image, char pSChar)
        {
            name = skillName;
            target = skillTarget;
            strength = skillStrength;
            type = skilltype;
			cost = pCost;
			img = image;
			sChar = pSChar;
        }
		public Skill getSkill()
		{
			return new Skill(name, target, strength, type, cost, img, sChar);
		}
	}
	[Serializable]
	[JsonObject(MemberSerialization.OptIn)]
	class Strategy : IComparable<Strategy>
	{
		[JsonProperty]
		public Skill StrategicSkill; //skill to be used
		[JsonProperty]
		public string FieldCondition; // HP, MP, number of target
		[JsonProperty]
		public string Condition; // > or <
		[JsonProperty]
		public int ConditionValue; // a percentage or value
		[JsonProperty]
		public string Focus; // Lowest or Highest
		[JsonProperty]
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
		public int CompareTo(Strategy cStrategy)
		{
			int result = this.StrategicSkill.type.Contains("tech").CompareTo(cStrategy.StrategicSkill.type.Contains("tech"));
			if (result == 0 || cStrategy.StrategicSkill.cost == 0 || this.StrategicSkill.cost == 0)
				result = this.StrategicSkill.cost.CompareTo(cStrategy.StrategicSkill.cost) * -1;
			return result;
		}
		public int CompareToTech(Strategy cStrategy, Strategy cStrategy2)
		{
			int result = cStrategy.StrategicSkill.type.Contains("attack").CompareTo(cStrategy2.StrategicSkill.type.Contains("attack"));
			if (result == 0 || cStrategy2.StrategicSkill.cost == 0 || cStrategy.StrategicSkill.cost == 0)
				result = cStrategy.StrategicSkill.cost.CompareTo(cStrategy2.StrategicSkill.cost) * -1;
			return result;
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
		[JsonProperty]
		public string eType = "";
		[JsonProperty]
		public string eName = "";
		[JsonProperty]
		public int eUpgrade = 0;
		[JsonProperty]
		public int eHealth = 0;
		[JsonProperty]
		public int eEnergy = 0;
		[JsonProperty]
		public int eArmour = 0;
		[JsonProperty]
		public int eDamage = 0;
		[JsonProperty]
		public int eHit = 0;
		[JsonProperty]
		public int eMentalStrength = 0;
		[JsonProperty]
		public int eMentalDefense = 0;
		[JsonProperty]
		public int eSpeed = 0;
		[JsonProperty]
		public int ePrice = 0;
		[JsonProperty]
		public int eDurability = 0;
		[JsonProperty]
		public int eMaxDurability = 0;
		[JsonProperty]
		public int eUpgradeCost = 0;
		public Equipment(bool addWeapon, int value, int durability, Random RndVal)
		{
			int Type = 0;
			if (addWeapon)
				Type = RndVal.Next(1, 5);
			else
				Type = RndVal.Next(5, 9);
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
		public Equipment(string pType, string pName, int pHealth, int pEnergy, int pArmour, int pDamage, int pHit, int pMentalStrength, int pMentalDefense, int pSpeed, int pPrice, int pDurability, int pMaxDurability, int pUpgradeCost, int pUpgrade)
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
			eUpgrade = pUpgrade;
		}
		public void upgrade(int value, Random RndVal)
		{
			int Type = RndVal.Next(1, 9);
			eMaxDurability += value;
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
			eUpgrade++;
			eUpgradeCost = upgradeValue(eUpgradeCost, 1);
		}
		public string ToString(int originalDur = 0)
		{
			string retval = (eName + "+" + eUpgrade).PadRight(12);
			if (originalDur > 0)
				retval += String.Format(" Dur:{0:n0}->{1:n0}", originalDur, eDurability);
			else
				retval += String.Format(" Dur:{0:n0}", eDurability);
			if (eHealth > 0)			{ retval += String.Format(" Hea+{0:n0}", eHealth); }
			if (eEnergy > 0)			{ retval += String.Format(" Enr+{0:n0}", eEnergy); }
			if (eDamage > 0)			{ retval += String.Format(" Dam+{0:n0}", eDamage); }
			if (eHit > 0)				{ retval += String.Format(" Hit+{0:n0}", eHit); }
			if (eArmour > 0)			{ retval += String.Format(" Acl+{0:n0}", eArmour); }
			if (eMentalStrength > 0)	{ retval += String.Format(" Mst+{0:n0}", eMentalStrength); }
			if (eMentalDefense > 0)		{ retval += String.Format(" Mdf+{0:n0}", eMentalDefense); }
			if (eSpeed > 0)				{ retval += String.Format(" Spd+{0:n0}", eSpeed); }
			retval += String.Format(" Price:{0:n0}", ePrice);
			return retval;
		}
	}
	public class AlsProgressBar : ProgressBar
	{
		Brush barColour;
		public AlsProgressBar(Brush myBarColour)
		{
			this.SetStyle(ControlStyles.UserPaint, true);
			barColour = myBarColour;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Rectangle rec = e.ClipRectangle;

			rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
			if (ProgressBarRenderer.IsSupported)
				ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
			rec.Height = rec.Height - 4;
			e.Graphics.FillRectangle(barColour, 2, 2, rec.Width, rec.Height);
		}
	}
}
