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
		private static string WarningLog;
		private static string FightLog;
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
			new Skill("Attack", "Enemy", 0, "Single attack", 0, strike, '*'),
			new Skill("Pound", "Enemy", 10, "Single attack", 2, pound, '#'),
			new Skill("Shrapnel", "Enemy", 1, "Multiple attack", 3, shrapnel, '%'),
			new Skill("Electrode", "Enemy", 10, "Single tech", 2, Electrode, '@'),
			new Skill("Laser", "Enemy", 1, "Multiple tech", 3, Laser, '^')
		};
		public static Skill[] MonsterSkills = {
			new Skill("Attack", "Enemy", 0, "Single attack", 0, strike, '*'),
			new Skill("Scratch", "Enemy", 10, "Single attack", 2, scratch, '#'),
			new Skill("Slash", "Enemy", 1, "Multiple attack", 3, slash, '%'),
			new Skill("Elements", "Enemy", 10, "Single tech", 2, elements, '@'),
			new Skill("Corosion", "Enemy", 1, "Multiple tech", 3, corosion, '^')
		};
		[JsonIgnore]
		public string[] name1 = { "Green", "Blue", "Yellow", "Orange", "Black", "Pink", "Great", "Strong", "Cunning", "Dashing", "Chivalrous", "Wise", "Brilliant", "Resourceful"};
		[JsonIgnore]
		public string[] name2 = { "Sharks", "Octopuses", "Birds", "Foxes", "Wolfs", "Lions", "Rinos", "Tigers", "Hyenas", "Vulturs" };
		[JsonIgnore]
		public string[] name3 = { "Blades", "Arrows", "Staffs", "Sparks", "Factory", "Snipers", "Calvary", "Spears", "Cythes", "Nunchuku" };
		[JsonIgnore]
		public string[] RoboName = { "Bolt", "Tinker", "Hammer", "Golem", "Droid", "Tank", "Gunner", "Blaster", "Bot", "iRobo", "gRobo", "mRobo" };
		[JsonIgnore]
		public string[] MonsterName = { "Devil", "Alien", "Slither", "Blob", "Bat", "Titan", "Chomp", "Element", "HandEye" };
		[JsonIgnore]
		public string[] BossName = { "Great", "Estemed", "Grand", "Large", "Strong", "Fast", "Tyrant"};
		public string getWarningLog
		{
			set
			{
				if (WarningLog == null) WarningLog = "";
				if (WarningLog.Length > 5000)
					WarningLog = value + WarningLog.Substring(0, 4000);
				else
					WarningLog = value + WarningLog;
			}
			get
			{
				if (WarningLog == null) WarningLog = "";
				return WarningLog;
			}
		}
		public string getFightLog
		{
			set
			{
				if (FightLog == null) FightLog = "";
				if (FightLog.Length > 10000)
					FightLog = value + FightLog.Substring(0, 2500);
				else
					FightLog = value + FightLog;
			}
			get
			{
				if (FightLog == null) FightLog = "";
				return FightLog;
			}
		}
		public void clearWarnings()
		{
			WarningLog = "";
		}
		public int SkipFour(int value) { return (int)SkipFour((long)value); }
		public long SkipFour(long value)
		{
			if (value.ToString().Substring(0, 1) == "4")
			{
				value += (long)Math.Pow(10, value.ToString().Length - 1);
			}
			return value;
		}

		public string setName(string Robo)
		{
			return setName(Robo, 0);
		}
		public string setName(String type, int MonsterLevel)
		{
			string name = "";
			if (type.Equals("monster"))
			{
				name = (MonsterName[MonsterLevel]);
			}
			else if (type.Equals("boss"))
			{
				name = (BossName[RndVal.Next(BossName.Length)]) + " " + (MonsterName[MonsterLevel]);
			}
			return name;
		}
		public int roundValue(int OriginalValue, int factor, String direction)
		{
			return (int)roundValue((long)OriginalValue, (long)factor, direction);
		}
		public long roundValue(long OriginalValue, long @base, String direction)
		{
			// up
			long retVal = (long)(OriginalValue + @base);
			if (roundValue(retVal) > OriginalValue) retVal = roundValue(retVal);
			// down
			if (direction == "down")
			{
				retVal = (long)(OriginalValue - @base);
				if (roundValue(retVal) < OriginalValue) retVal = roundValue(retVal);
			}
			return retVal;
		}
		public long roundValue(double value)
		{
			long power = (long)Math.Pow(10, value.ToString().Length - 2);
			return (long)Math.Round((double)(value) / power) * power;
		}
		public int getMaxLength(string[] strValues)
		{
			int maxLen = 0;
			foreach (string eValue in strValues)
				if (maxLen < eValue.Length)
					maxLen = eValue.Length;
			return maxLen;
		}
		public static string ToRoman(int number)
		{
			if (number < 1) return string.Empty;
			if (number >= 10000) return "_X" + ToRoman(number - 10000);
			if (number >= 9000) return "M_X" + ToRoman(number - 9000);
			if (number >= 5000) return "_V" + ToRoman(number - 5000);
			if (number >= 4000) return "M_V" + ToRoman(number - 4000);
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
		public List<Team> GameTeams;
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
		private int RoboNumeral;
		private int maxRoboNumeral;
		private int findMonster;
		private int Numeral;
		private int maxNumeral;
		public int fightPercent;
		public int fightPercentMax;
		private int fightCount;
		public int ArenaOpponent1;
		public int ArenaOpponent2;
		public int ManagerHrs;
		public long ManagerCost;
		public long ManagerCostBase;
		public long ManagerCostBaseIncrement;
		public int CurrentInterval;
		public int MaxInterval;
		public int FightBreak;
		public DateTime SafeTime;
		public DateTime BreakTime;
		public double repairPercent;
		public int maxManagerHours;
		public bool PurchaseUgrade;
		[JsonProperty]
		private int GoalGameScore;
		[JsonProperty]
		private int GoalGameScoreBase;
		private int GoalGameScoreBaseIncrement = 100;
		[JsonProperty]
		public int gameDifficulty;
		[JsonProperty]
		private int MaxTeams;
		[JsonProperty]
		private long TeamCost;
		[JsonProperty]
		private long TeamCostBase;
		private long TeamCostBaseIncrement = 1000;
		private long Jackpot; // holds the credits to be divied out after a fight
		[JsonProperty]
		private long GameCurrency;
		public long GameCurrencyLogMaint;
		public long GameCurrencyLogUp;
		public long GameCurrencyLogMisc;
		private Boolean fighting;
		private Boolean auto;
		[JsonProperty]
		private int ShopLvl;
		[JsonProperty]
		private long ShopLvlCost;
		[JsonProperty]
		public long ShopLvlCostBase;
		public long ShopLvlCostBaseIncrement = 1000;
		[JsonProperty]
		private long ShopLvlMaint;
		[JsonProperty]
		private int ShopStock;
		[JsonProperty]
		private long ShopStockCost;
		[JsonProperty]
		private int ShopMaxStat;
		[JsonProperty]
		private int ShopMaxDurability;
		[JsonProperty]
		private int ShopUpgradeValue;
		[JsonProperty]
		private int ArenaLvl;
		[JsonProperty]
		private long ArenaLvlCost;
		[JsonProperty]
		public long ArenaLvlCostBase;
		public long ArenaLvlCostBaseIncrement = 1000;
		[JsonProperty]
		private long ArenaLvlMaint;
		[JsonProperty]
		public int MonsterDenLvl;
		[JsonProperty]
		private long MonsterDenLvlCost;
		[JsonProperty]
		public long MonsterDenLvlCostBase;
		public long MonsterDenLvlCostBaseIncrement = 1000;
		[JsonProperty]
		private long MonsterDenLvlMaint;
		[JsonProperty]
		private int MonsterDenBonus;
		[JsonProperty]
		public long MonsterDenRepairs;
		[JsonProperty]
		public long MonsterDenRepairsBase;
		public long MonsterDenRepairsBaseIncrement = 100;
		[JsonProperty]
		private int ResearchDevLvl;
		[JsonProperty]
		private long ResearchDevLvlCost;
		[JsonProperty]
		public long ResearchDevLvlCostBase;
		public long ResearchDevLvlCostBaseIncrement = 1000;
		[JsonProperty]
		private long ResearchDevMaint;
		[JsonProperty]
		private int ResearchDevHealValue;
		private int ResearchDevHealValueSum;
		[JsonProperty]
		public int ResearchDevHealValueBase;
		public int ResearchDevHealValueBaseIncrement = 1;
		[JsonProperty]
		private int ResearchDevHealBays;
		[JsonProperty]
		public long ResearchDevRebuild;
		[JsonProperty]
		public long ResearchDevRebuildBase;
		public long ResearchDevRebuildBaseIncrement = 25;
		[JsonProperty]
		private int BossLvl;
		[JsonProperty]
		public long BossLvlBase;
		public long BossLvlBaseIncrement = 5;
		[JsonProperty]
		private int BossCount;
		[JsonProperty]
		private int BossDifficulty;
		[JsonProperty]
		public int BossDifficultyBase;
		public int BossDifficultyBaseIncrement = 2;
		[JsonProperty]
		public int CurrentJackpot;
		public int CurrentJackpotLvl;
		public int MinJackpot;
		public int CurrentJackpotBase;
		public int CurrentJackpotBaseIncrement;
		public long MaxJackpot;
		public Boolean JackpotUp;
		public Boolean JackpotUpTen;
		public Boolean JackpotDown;
		public Boolean JackpotDownTen;
		private long BossReward;
		public int roundCount;
		public bool bossFight;
		public bool GameDifficultyFight;
		public int WinCount;
		public int getMonsterDenBonus
		{
			get { return MonsterDenBonus; }
			set { MonsterDenBonus = value; }
		}
		public long getMonsterDenLvlCost
		{
			get { return MonsterDenLvlCost; }
			set { MonsterDenLvlCost = value; }
		}
		public int getMonsterDenLvlImage()
		{
			if (MonsterDenLvl > 8)
			{
				return 8; // Max number of Monster images
			}
			return MonsterDenLvl;
		}
		public int getMonsterDenLvl
		{
			get
			{ return MonsterDenLvl; }
			set { MonsterDenLvl = value; }
		}
		public long getMonsterDenLvlMaint
		{
			get { return MonsterDenLvlMaint; }
			set { MonsterDenLvlMaint = value; }
		}
		public int getMaxTeams
		{
			get { return MaxTeams; }
			set { MaxTeams = value; }
		}
		public long getTeamCost
		{
			get { return TeamCost; }
			set { TeamCost = value; }
		}
		public int getGoalGameScore
		{
			get { return GoalGameScore; }
			set { GoalGameScore = value; }
		}
		public long getGameCurrency
		{
			set { GameCurrency = value; }
			get { return GameCurrency; }
		}
		
		public int getArenaLvl
		{
			get { return ArenaLvl; }
			set { ArenaLvl = value; }
		}
		public long getArenaLvlCost
		{
			get { return ArenaLvlCost; }
			set { ArenaLvlCost = value; }
		}
		public long getArenaLvlMaint
		{
			get { return ArenaLvlMaint; }
			set { ArenaLvlMaint = value; }
		}
		public int getShopLvl
		{
			get { return ShopLvl; }
			set { ShopLvl = value; }
		}
		public long getShopLvlCost
		{
			get { return ShopLvlCost; }
			set { ShopLvlCost = value; }
		}
		public long getShopLvlMaint
		{
			get { return ShopLvlMaint; }
			set { ShopLvlMaint = value; }
		}
		public int getShopStock
		{
			get { return ShopStock; }
			set { ShopStock = value; }
		}
		public long getShopStockCost
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
		public long getResearchDevLvlCost
		{
			get { return ResearchDevLvlCost; }
			set { ResearchDevLvlCost = value; }
		}
		public long getResearchDevMaint
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
		public int getAvailableTeams
		{
			get
			{
				if (getScore() > GoalGameScore) resetScore();
				return MaxTeams - GameTeams.Count;
			}
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
		public int getRoboNumeral
		{
			get { return RoboNumeral; }
			set
			{
				if (RoboNumeral > maxRoboNumeral)
				{
					RoboNumeral = 1;
					maxRoboNumeral += (int)(maxRoboNumeral * .1);
				}
				else
					RoboNumeral = value;
			}
		}
		public Game(int pGoalGameScore, int pGoalGameScoreBase, int pMaxTeams, long pTeamCost, long pTeamCostBase, long pGameCurrency, int pArenaLvl, long pArenaLvlCost, 
			long pArenaLvlCostBase, long pArenaLvlMaint, int pMonsterDenLvl, long pMonsterDenLvlCost, long pMonsterDenLvlCostBase, long pMonsterDenLvlMaint, 
			int pMonsterDenBonus, long pMonsterDenRepair, long pMonsterDenRepairBase, int pShopLvl, long pShopLvlCost, long pShopLvlCostBase, long pShopLvlMaint, 
			int pShopStock, long pShopStockCost, int pShopMaxStat, int pShopMaxDurability, int pShopUpgradeValue, int pResearchDevLvl,
			long pResearchDevLvlCost, long pResearchDevLvlCostBase, long pResearchDevMaint, int pResearchDevHealValue, int pResearchDevHealValueBase, int pResearchDevHealBays, 
			long pResearchDevRebuild, long pResearchDevRebuildBase, int pBossLvl, int pBossLvlBase, int pBossCount, int pBossDifficulty, int pBossDifficultyBase, long pBossReward,
			int pGameDifficult)
		{
			getRoboNumeral = 1;
			maxRoboNumeral = 1000;
			GameTeams = new List<Team> { };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(0,1,findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 4, 5);
			findMonster = 50;
			GoalGameScore = pGoalGameScore;
			GoalGameScoreBase = pGoalGameScoreBase;
			MaxTeams = pMaxTeams;
			TeamCost = pTeamCost;
			TeamCostBase = pTeamCostBase;
			GameCurrency = pGameCurrency;
			CurrentJackpot = 3;
			MaxJackpot = 0;
			CurrentJackpotLvl = 1;
			MinJackpot = 3;
			CurrentJackpotBase = 1;
			CurrentJackpotBaseIncrement = 1;
			fighting = false;
			auto = true;
			ShopLvl = pShopLvl;
			ShopLvlCost = pShopLvlCost;
			ShopLvlCostBase = pShopLvlCostBase;
			ShopLvlMaint = pShopLvlMaint;
			ShopStock = pShopStock;
			ShopStockCost = pShopStockCost;
			ShopMaxStat = pShopMaxStat;
			ShopMaxDurability = pShopMaxDurability;
			ShopUpgradeValue = pShopUpgradeValue;
			repairPercent = .5;
			maxManagerHours = 10;
			PurchaseUgrade = false;
			ArenaLvl = pArenaLvl;
			ArenaLvlCost = pArenaLvlCost;
			ArenaLvlCostBase = pArenaLvlCostBase;
			ArenaLvlMaint = pArenaLvlMaint;
			MonsterDenLvl = pMonsterDenLvl;
			MonsterDenLvlCost = pMonsterDenLvlCost;
			MonsterDenLvlMaint = pMonsterDenLvlMaint;
			MonsterDenBonus = pMonsterDenBonus;
			MonsterDenRepairs = pMonsterDenRepair;
			MonsterDenRepairsBase = pMonsterDenRepairBase;
			ResearchDevLvl = pResearchDevLvl;
			ResearchDevLvlCost = pResearchDevLvlCost;
			ResearchDevLvlCostBase = pResearchDevLvlCostBase;
			ResearchDevMaint = pResearchDevMaint;
			ResearchDevHealValue = pResearchDevHealValue;
			ResearchDevHealValueSum = 0;
			ResearchDevHealValueBase = pResearchDevHealValueBase;
			ResearchDevHealBays = pResearchDevHealBays;
			ResearchDevRebuild = pResearchDevRebuild;
			ResearchDevRebuildBase = pResearchDevRebuildBase;
			gameDifficulty = pGameDifficult;
			BossLvl = pBossLvl;
			BossLvlBase = pBossLvlBase;
			BossCount = pBossCount;
			BossDifficulty = pBossDifficulty;
			BossDifficultyBase = pBossDifficultyBase;
			BossReward = pBossReward;
			ManagerHrs = 0;
			ManagerCost = 2000;
			ManagerCostBase = ManagerCostBaseIncrement = 1000;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			ArenaOpponent1 = 0;
			ArenaOpponent2 = 0;
			getNumeral = 1;
			maxNumeral = 1000;
			FightBreak = 80;
			roundCount = 0;
			bossFight = false;
			GameDifficultyFight = false;
			getWarningLog = "";
			getFightLog = "";
			fightPercent = 95;
			fightPercentMax = 100;
			fightCount = 0;
		}
		public Game(bool isNew)
		{
			getRoboNumeral = 1;
			maxRoboNumeral = 1000;
			GameTeams = new List<Team> { new Team(0, this), new Team(0,this) };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { new ArenaSeating(1, 1, 50, 5) };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(0, 1, findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 4, 5);
			CurrentJackpot = 3;
			MaxJackpot = 0;
			CurrentJackpotLvl = 1; 
			MinJackpot = 3;
			CurrentJackpotBase = 1;
			CurrentJackpotBaseIncrement = 1;
			findMonster = 50;
			GameCurrency = 0;
			GoalGameScore = 200;
			GoalGameScoreBase = GoalGameScoreBaseIncrement;
			MaxTeams = 2;
			TeamCost = 2000;
			TeamCostBase = TeamCostBaseIncrement;
			fighting = false;
			auto = true;
			getFightLog = "";
			ShopLvl = 1;
			ShopLvlCost = 2000;
			ShopLvlCostBase = ShopLvlCostBaseIncrement;
			ShopLvlMaint = 1;
			ShopStock = 1;
			ShopStockCost = 100;
			ShopMaxStat = 5;
			ShopMaxDurability = 100;
			ShopUpgradeValue = 1;
			repairPercent = .5;
			maxManagerHours = 10;
			PurchaseUgrade = false;
			ArenaLvl = 1;
			ArenaLvlCost = 2000;
			ArenaLvlCostBase = ArenaLvlCostBaseIncrement;
			ArenaLvlMaint = 1;
			MonsterDenLvl = 1;
			MonsterDenLvlCost = 2000;
			MonsterDenLvlCostBase = MonsterDenLvlCostBaseIncrement;
			MonsterDenLvlMaint = 1;
			MonsterDenBonus = 5;
			MonsterDenRepairs = 200;
			MonsterDenRepairsBase = MonsterDenRepairsBaseIncrement;
			ResearchDevLvl = 1;
			ResearchDevLvlCost = 2000;
			ResearchDevLvlCostBase = ResearchDevLvlCostBaseIncrement;
			ResearchDevMaint = 1;
			ResearchDevHealValue = 2;
			ResearchDevHealValueSum = 0;
			ResearchDevHealValueBase = ResearchDevHealValueBaseIncrement;
			ResearchDevHealBays = 1;
			ResearchDevRebuild = 50;
			ResearchDevRebuildBase = ResearchDevRebuildBaseIncrement;
			gameDifficulty = 1;
			ManagerHrs = 0;
			ManagerCost = 2000;
			ManagerCostBase = ManagerCostBaseIncrement = 1000;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			ArenaOpponent1 = 0;
			ArenaOpponent2 = 0;
			getNumeral = 1;
			maxNumeral = 1000;
			FightBreak = 80;
			roundCount = 0;
			BossLvl = 5;
			BossLvlBase = BossLvlBaseIncrement;
			BossCount = 1;
			BossDifficulty = 4;
			BossDifficultyBase = BossDifficultyBaseIncrement;
			BossReward = 1000;
			bossFight = false;
			GameDifficultyFight = false;
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
		public string setRoboName()
		{
			string name = "";
			int RoboType = RndVal.Next(100);
			if (RoboType < 40)
				name = string.Format("{0} {1}", RoboName[RndVal.Next(RoboName.Length)], ToRoman(getRoboNumeral++));
			else if (RoboType < 70)
				name = string.Format("{0} #{1:X}", RoboName[RndVal.Next(RoboName.Length)], getRoboNumeral++);
			else
				name = string.Format("{0} {1:N0}", RoboName[RndVal.Next(RoboName.Length)], getRoboNumeral++);
			return name;
		}
		public int maxWins()
		{
			int retVal = 0;
			foreach (Team eTeam in GameTeams)
				if (retVal < eTeam.Win)
					retVal = eTeam.Win;
			return retVal;
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
			GameCurrencyLogMaint = 0;
			GameCurrencyLogUp = 0;
			GameCurrencyLogMisc = 0;
			foreach (Team eTeam in GameTeams) { eTeam.resetLogs(); }
		}

		public void interval(Timer Timer1)
		{
			if (GameTeam1.Count > 0 && GameTeam1[0].Automated && GameTeam2[0].Automated)
				Timer1.Interval = 1000 / getMaxTeams;
			else
			{
				CurrentInterval++;
				if (CurrentInterval > MaxInterval)
				{
					CurrentInterval = 1000;
					MaxInterval++;
					GameTeams.Sort();
				}
				Timer1.Interval = CurrentInterval;
			}
		}

		public void lowestLevelUp()
		{
			IList<string> levelUpList;
			levelUpList = new List<string> { };
			// find lowest level
			int lowestLvl = getArenaLvl;
			if (getShopLvl < lowestLvl) lowestLvl = getShopLvl;
			if (getResearchDevLvl < lowestLvl) lowestLvl = getResearchDevLvl;
			if (getMonsterDenLvl < lowestLvl) lowestLvl = getMonsterDenLvl;
			// Add all utilities that are the lowest level
			if (getArenaLvl == lowestLvl) levelUpList.Add("Arena");
			if (getShopLvl == lowestLvl) levelUpList.Add("Shop");
			if (getResearchDevLvl == lowestLvl) levelUpList.Add("RD");
			if (getMonsterDenLvl == lowestLvl) levelUpList.Add("Den");
			// randomly choose one of the lowest level utilities
			string choise = levelUpList[RndVal.Next(levelUpList.Count)];
			// level up
			if (choise == "Arena" && getGameCurrency >= getArenaLvlCost) arenaLevelUp();
			if (choise == "Shop" && getGameCurrency >= getShopLvlCost) ShopLevelUp();
			if (choise == "RD" && getGameCurrency >= getResearchDevLvlCost) ResearchDevLevelUp();
			if (choise == "Den" && getGameCurrency >= getMonsterDenLvlCost) MonsterDenLevelUp();
		}
		public void arenaLevelUp()
		{
			getFightLog = getWarningLog = "\nArena upgraded!";
			getGameCurrency -= ArenaLvlCost;
			GameCurrencyLogUp -= ArenaLvlCost;
			ArenaLvlMaint += ArenaLvlCost/2;
			ArenaLvl++;
			ArenaLvlCost = roundValue(ArenaLvlCost, ArenaLvlCostBase, "up");
			ArenaLvlCostBase += ArenaLvlCostBaseIncrement;
			int lastPrice = Seating[0].Price;
			foreach (ArenaSeating eSeating in Seating)
			{
				eSeating.Amount = (int)roundValue(eSeating.Amount, eSeating.AmountBase, "up");
				eSeating.AmountBase++;
				if (eSeating.Amount > 5000) eSeating.Amount = 5000;
				if (RndVal.Next(100) > 98 || lastPrice > eSeating.Price) eSeating.Price++;
				lastPrice = eSeating.Price;
			}
			// chance to add a new level of seating
			if (RndVal.Next(100) > (85 - ArenaLvl + (Seating.Count* 5))) Seating.Add(new ArenaSeating(Seating.Count + 1, Seating[Seating.Count-1].Price + Seating.Count, 5, 1)); 
		}
		public string bossLevelUp()
		{
			string retVal = "";
			GameCurrency += BossReward;
			GameCurrencyLogMisc += BossReward;
			BossLvl = (int)roundValue(BossLvl, BossLvlBase, "up");
			BossLvlBase += BossLvlBaseIncrement;
			BossCount++;
			BossDifficulty = (int)roundValue(BossDifficulty, BossDifficultyBase, "up");
			BossDifficultyBase += BossDifficultyBaseIncrement;
			retVal = getFightLog = String.Format("\nArena destroyed boss monsters! ({1:n0}) ", DateTime.Now.ToString(), BossReward);
			BossReward = BossLvl * BossDifficulty * BossCount * getArenaLvl;
			int Monster = RndVal.Next(BossCount);
			Bosses.MyTeam.Add(new Robot(BossDifficulty, setName("boss", Monster), Monster, true));
			// Add equipment
			for (int i = 0; i < BossCount; i++)
			{
				Bosses.MyTeam[i].getEquipWeapon = new Equipment(true, BossLvl, 10000, RndVal, true);
				Bosses.MyTeam[i].getEquipArmour = new Equipment(false, BossLvl, 10000, RndVal, true);
			}
			for (int ii = 1; ii < BossLvl; ii++)
			{
				Bosses.MyTeam[BossCount - 1].levelUp(RndVal, true);
				Bosses.MyTeam[BossCount - 1].HP = Bosses.MyTeam[BossCount - 1].getTHealth();
				Bosses.MyTeam[BossCount - 1].MP = Bosses.MyTeam[BossCount - 1].getTEnergy();
			}
			Bosses.resetLogs();
			return retVal;
		}
		public void MonsterDenLevelUp()
		{
			getFightLog = getWarningLog = "\nMonster Den upgraded!";
			getGameCurrency -= MonsterDenLvlCost;
			GameCurrencyLogUp -= MonsterDenLvlCost;
			MonsterDenLvlMaint += MonsterDenLvlCost / 2;
			MonsterDenLvl++;
			MonsterDenLvlCost = roundValue(MonsterDenLvlCost, MonsterDenLvlCostBase, "up");
			MonsterDenLvlCostBase += MonsterDenLvlCostBaseIncrement;
			MonsterDenBonus += RndVal.Next(MonsterDenLvl);
			MonsterDenRepairs = roundValue(MonsterDenRepairs, MonsterDenRepairsBase, "up");
			MonsterDenRepairsBase += MonsterDenRepairsBaseIncrement;
		}
		public void ShopLevelUp()
		{
			getFightLog = getWarningLog = "\nShop upgraded!";
			getGameCurrency -= ShopLvlCost;
			GameCurrencyLogUp -= ShopLvlCost;
			ShopLvlMaint += ShopLvlCost / 2;
			ShopLvl++;
			ShopLvlCost = roundValue(ShopLvlCost, ShopLvlCostBase, "up");
			ShopLvlCostBase += ShopLvlCostBaseIncrement;
			if (RndVal.Next(100) > 90) ShopStock++;
			ShopMaxDurability = roundValue(ShopMaxDurability, 10, "up");
			ShopMaxStat = roundValue(ShopMaxStat, 2, "up");
			ShopUpgradeValue++;
			ShopStockCost = ((ShopMaxStat * 10) + ShopMaxDurability) / 3;
		}
		public void AddStock()
		{
			// Add new equipent to stock
			while (ShopStock > storeEquipment.Count && getGameCurrency >= ShopStockCost)
			{
				getGameCurrency -= ShopStockCost;
				GameCurrencyLogMisc -= ShopStockCost;
				storeEquipment.Add(new Equipment(AddArmour(), RndVal.Next(5,ShopMaxStat), RndVal.Next(100, ShopMaxDurability),RndVal,false,ShopUpgradeValue*100));
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
			getFightLog = getWarningLog = "\nResearch and Development upgraded!";
			getGameCurrency -= ResearchDevLvlCost;
			GameCurrencyLogUp -= ResearchDevLvlCost;
			ResearchDevMaint += ResearchDevLvlCost / 2;
			ResearchDevLvl++;
			ResearchDevLvlCost = roundValue(ResearchDevLvlCost, ResearchDevLvlCostBase, "up");
			ResearchDevLvlCostBase += ResearchDevLvlCostBaseIncrement;
			ResearchDevHealValue = roundValue(ResearchDevHealValue, ResearchDevHealValueBase, "up");
			ResearchDevHealValueBase += ResearchDevHealValueBaseIncrement;
			ResearchDevRebuild = roundValue(ResearchDevRebuild, ResearchDevRebuildBase, "up");
			ResearchDevRebuildBase += ResearchDevRebuildBaseIncrement;
			// chance to add a new healing baynic
			if (RndVal.Next(100 + GameTeams.Count) > (95 + ResearchDevHealBays)) ResearchDevHealBays++;
		}
		public void AddManagerHours()
		{
			// only add Manager hours if there is less than one hour to safe time
			if ((SafeTime - DateTime.Now).TotalHours < 1)
			{
				while (getGameCurrency > ManagerCost && ManagerHrs < maxManagerHours)
				{
					getGameCurrency -= ManagerCost;
					GameCurrencyLogMisc -= ManagerCost;
					ManagerHrs++;
					ManagerCost = roundValue(ManagerCost, ManagerCostBase, "up");
					ManagerCostBase += ManagerCostBaseIncrement;
				}
				ManagerCostBaseIncrement++;
			}
		}
		public string addTeam()
		{
			string TeamName = "";
			while (GameTeams.Count < MaxTeams)
			{
				// calculate cost
				getGameCurrency -= TeamCost;
				GameCurrencyLogUp -= TeamCost;
				TeamCost = roundValue(TeamCost, TeamCostBase, "up");
				TeamCostBase += TeamCostBaseIncrement;
				Team tmp = new Team(RndVal.Next(GameTeams.Count, GameTeams.Count * 3), this);
				TeamName = tmp.getName;
				GameTeams.Add(tmp);
				getWarningLog = getFightLog = tmp.getTeamLog = string.Format("\n!*!*! new team {0} was added!", tmp.getName);
			}
			return TeamName;
		}
		public void resetScore()
		{
			getGameCurrency += MaxTeams * getArenaLvl * 1000;
			GameCurrencyLogMisc += TeamCost;
			// team with top score has 50% chance to loose robots
			Team rebuild = new Team(1,1,1);
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.getScore > rebuild.getScore)
					rebuild = eTeam;
			}
			rebuild.getDifficulty = 0;
			rebuild.Win++;
			getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n\n!*!*! {0} won with top score!\n", rebuild.getName);
			int winGoal = rebuild.Win;
			int scouted = rebuild.Win * 10;
			for (int i = 0; i < rebuild.MyTeam.Count; i++)
			{
				if (RndVal.Next(100) < scouted && rebuild.MyTeam.Count > 1)
				{
					getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n!*!*! {0} has been scouted by another team!\n", rebuild.MyTeam[i].getName);
					rebuild.MyTeam.RemoveAt(i);
					scouted--;
				}
			}
			foreach (Team eTeam in GameTeams)
			{
				eTeam.getScore = 0;
				if (eTeam.Win < winGoal)
				{
					long iWinnings = getArenaLvl * 1000 * (winGoal + 1);
					foreach (Robot eRobo in eTeam.MyTeam)
						eRobo.rebuildBonus++;
                    const string Format = "\n*!* {0} won {1:n0} credits during reset!";
					getWarningLog = getFightLog = eTeam.getTeamLog = string.Format(format: Format, eTeam.getName, iWinnings);
					eTeam.getCurrency += iWinnings;
				}
			}
			// reset jackpot
			CurrentJackpot = 0;
			DecreaseJackpot();
			PurchaseUgrade = false;
		}
		public void addRobo(int Team) { addRobo(GameTeams[Team], this); }

		public void addRobo(Team Team, Game Game)
		{
			Team.getCurrency -= Team.getRoboCost;
			Team.getRoboCost = roundValue(Team.getRoboCost, Team.getRoboCostBase, "up");
			Team.getRoboCostBase += Team.RoboCostBaseIncrement;
			Robot tmp = new Robot(0,Game.setRoboName(), RndVal.Next(8), false);
            Team.MyTeam.Add(tmp);
        }
        public int getScore()
        {
            int iTmpScore = 0;
            for (int i = 0; i < GameTeams.Count; i++) { iTmpScore += GameTeams[i].getScore; }
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
			int beds = ResearchDevHealBays;
			if (getGameCurrency <= 0) beds = 0;
			for (int index = GameTeams.Count-1; index >= 0; index--) // Team eTeam in GameTeams)
			{
				Boolean tmpFullHP = true;
				if (!isFighting(GameTeams[index].getName) && !isFighting("arena"))
				{
					int pay = 0;
					tmpFullHP = GameTeams[index].healRobos(ref beds, ref pay, ResearchDevHealValue);
					getGameCurrency += pay;
					ResearchDevHealValueSum += pay;
					if (tmpFullHP == false)
						fullHP = false;
				}
			}
			MonsterOutbreak.healRobos(true); 
			Bosses.healRobos(true);
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
		public void startMonsterOutbreak(long cost)
		{
			fighting = true;
			GameTeam1.Add(new Team(0,0,0,0,0,0,0,0,0,"Arena",false));
			GameTeam1[GameTeam1.Count - 1].isMonster = true;
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam)
					GameTeam1[GameTeam1.Count-1].MyTeam.Add(eRobo);
			}
			GameTeam1[GameTeam1.Count - 1].MyTeam.Sort();
			GameTeam2.Add(new Team(0,0,0,0,0,0,0,0,0,"Monster Outbreak",false));
			GameTeam2[GameTeam2.Count - 1].isMonster = true;
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
			Jackpot = cost;
			getFightLog = Environment.NewLine + "--- Monster Outbreak! ";
		}
		public void startBossFight()
		{
			fighting = true;
			GameTeam1.Add(new Team(0, 0, 0, 0, 0, 0, 0, 0, 0, "Arena", false));
			GameTeam1[GameTeam1.Count - 1].isMonster = true;
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam)
					GameTeam1[GameTeam1.Count - 1].MyTeam.Add(eRobo);
			}
			GameTeam1[GameTeam1.Count - 1].MyTeam.Sort();
			if (bossFight)
			{
				bossFight = false;
				GameTeam2.Add(Bosses);
				Jackpot = BossReward;
				getFightLog = Environment.NewLine + " Boss Fight! ";
			}
			// Game difficulty fight
			else
			{
				GameDifficultyFight = false;
				Team Monsters = new Team(gameDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak);
				Monsters.getName = "Game Diff " + gameDifficulty.ToString();
				GameTeam2.Add(Monsters);
				Jackpot = gameDifficulty * getArenaLvl * 1000;
				getFightLog = Environment.NewLine + " Game Difficulty Fight! ";
			}
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
		public int monsterFight(Boolean allowRandom)
		{
			int Team1Score = 99999999;
			int TeamIndex = -1;
			int tmpScore = 0;
			if (RndVal.Next(100) > 90 && allowRandom)
			{
				TeamIndex = RndVal.Next(GameTeams.Count);
			}
			else
			{
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
			}
			if (TeamIndex >= 0)
			{
				// if selected team's min level is lower than the lowest level of monster decrease diff
				Team tmpTeam = GameTeams[TeamIndex];
				if (((tmpTeam.getDifficulty - 1) * 4) + 1 > tmpTeam.MyTeam[tmpTeam.MyTeam.Count - 1].getLevel && RndVal.Next(100) > 95)
				{
					tmpTeam.getDifficulty--;
					getFightLog = String.Format("\n!!! {0} difficulty decreased!", tmpTeam.getName);
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
			if ((bossFight || GameDifficultyFight) && !fighting)
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
						if (JackpotUp)
                        {
							IncreaseJackpot();
							JackpotUp = false;
                        }
						else if (JackpotUpTen)
						{
							IncreaseJackpot(10);
							JackpotUpTen = false;
						}
						else if (JackpotDown)
						{
							DecreaseJackpot();
							JackpotDown = false;
						}
						else if (JackpotDownTen)
						{
							DecreaseJackpot(10);
							JackpotDownTen = false;
						}
						else if ((getGameCurrency < 0))
                        {
							DecreaseJackpot();
							MaxJackpot = getGameCurrency;
						}

						if (ArenaOpponent1 != 0)
						{
							ArenaOpponent2++;
							incrementArenaOpponent();
						}
					}
					if (ArenaOpponent1 == 0 && ArenaOpponent1 == ArenaOpponent2)
						Team1Index = Team2Index = monsterFight(true);
					else
					{
						Team1Index = ArenaOpponent1;
						Team2Index = ArenaOpponent2;
					}
					ArenaOpponent2++;
					if (getGameCurrency > 0)
					{
						if (fightCount >= 3)
							fightPercent++;
						else
							fightPercent--;
						if (fightPercent >= fightPercentMax)
							fightPercentMax++;
					}
					fightCount = 0;
				}
				else
				{
					fightCount++;
					// monster fight
					Team1Index = Team2Index = monsterFight(false);
					// if index is still -1 no available teams exit function
					if (Team1Index == -1 || getGameCurrency <= 0) return;
				}
				GameTeam1.Add(GameTeams[Team1Index]);
				PotScore = GameTeam1[GameTeam1.Count - 1].getScore;

				if (Team1Index == Team2Index)
				{
					// only if main fight is a monster fight
					if (GameTeam1.Count == 1)
					{
						// 10% chance to Lower difficulty
						if (RndVal.Next(100) > 90 && GameTeam1[0].getDifficulty * 5 > GameTeam1[0].MyTeam[GameTeam1[0].MyTeam.Count - 1].getLevel)
						{
							GameTeam1[0].getDifficulty = RndVal.Next(GameTeam1[0].MyTeam[GameTeam1[0].MyTeam.Count-1].getLevel/5 , GameTeam1[0].MyTeam[0].getLevel/5);
						}
						GameTeam1[0].healRobos(false);
					}
					// Monster team... 
					GameTeam2.Add(new Team(GameTeam1[GameTeam1.Count - 1].getDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak));
				}
				else
				{
					// Robo Team
					GameTeam2.Add(GameTeams[Team2Index]);
					PotScore += GameTeam2[GameTeam2.Count - 1].getScore;
				}
				string msg = "";
				int tmpMonsterDenBonus = getMonsterDenBonus;
				if (getGameCurrency <= 0) tmpMonsterDenBonus = 0;
				if (GameTeam1.Count == 1) PotScore += tmpMonsterDenBonus;
				int tmpTotalScore = PotScore;
				if (GameTeam1.Count == 1)
				{
					CurrentSeating = new List<ArenaSeating> {  };
					// reset seating
					foreach (ArenaSeating eSeating in Seating)
					{
						CurrentSeating.Add(new ArenaSeating(eSeating.Level, eSeating.Price, eSeating.Amount, eSeating.AmountBase));
					}
				}
				// randomize each attendee
				int attendees = RndVal.Next(tmpTotalScore);
				int unseated = 0;
				for (int i = 0; i < attendees; i++)
				{
					int seatingLevel = RndVal.Next(CurrentSeating.Count);
					bool seated = false;
					while (!seated)
					{
						if (CurrentSeating[seatingLevel].Attendees < CurrentSeating[seatingLevel].Amount)
						{
							CurrentSeating[seatingLevel].Attendees++;
							seated = true;
						}
						else seatingLevel--;
						if (seatingLevel == -1)
						{
							seated = true;
							unseated++;
						}
					}
				}
				// total attendance
				int countChars = 10 + tmpTotalScore.ToString().Length;
				msg += displaySeating("\n    Attd", attendees - unseated, -1, ref countChars);



				int tmp = 0;
				foreach (ArenaSeating eSeating in CurrentSeating)
				{
					int max = (tmpTotalScore > eSeating.Amount ? eSeating.Amount : tmpTotalScore);
					msg += displaySeating(eSeating.Level.ToString(), eSeating.Attendees, max, ref countChars);
					tmp += eSeating.Price * eSeating.Attendees;
					eSeating.Amount -= eSeating.Attendees;
					eSeating.Attendees = 0;
				}
				// Monster fighter teams get 10% of jackpot
				if (GameTeam1.Count > 1)
				{
					int MonsterFighter = (int)(CurrentJackpot * 0.1);
					GameCurrency -= MonsterFighter*2;
					GameCurrencyLogMisc -= MonsterFighter*2;
					GameTeam1[GameTeam1.Count - 1].getCurrency += MonsterFighter;
					MonsterOutbreak.getCurrency += MonsterFighter;
					msg += displaySeating("G", tmp, -1, ref countChars);
					msg += displaySeating("MG", MonsterFighter * 2, -1, ref countChars);
					msg += displaySeating("R", tmp - (MonsterFighter * 2), -1, ref countChars);
				}
				else
				{
					msg += displaySeating("G", tmp, -1, ref countChars);
				}
				if (GameTeam1.Count == 1)
				{
					Jackpot = CurrentJackpot;
					GameCurrency -= CurrentJackpot;
					GameCurrencyLogMisc -= CurrentJackpot;
				}
				GameCurrency += tmp;
				GameCurrencyLogMisc += tmp;
				string spacer = "";
				if (GameTeam1.Count > 1)
					spacer = "  ";
				msg = string.Format("\n{0}{1} VS {2} {3}" , spacer , GameTeam1[GameTeam1.Count - 1].getName, GameTeam2[GameTeam2.Count - 1].getName, msg);
				if (GameTeam1.Count == 1)
				{
					int tmpFightPerMax = fightPercentMax;
					if (GameTeam1 != null && GameTeam2 != null && GameTeam1.Count > 0 && GameTeam1[0].Automated && GameTeam2[0].Automated)
						tmpFightPerMax += GameTeams.Count;

					msg += displaySeating("J", CurrentJackpot, -1, ref countChars);
					msg += displaySeating("R", tmp - CurrentJackpot, -1, ref countChars);
					msg += String.Format("\n{0}/{1} {2:n2}%\n", fightPercent.ToString(), tmpFightPerMax.ToString(), ((double)(tmpFightPerMax - fightPercent) / tmpFightPerMax * 100));
					if (ResearchDevHealValueSum > 0)
					{
						// add message with income from repairs
						msg += String.Format("\n$$$ Repair Revenue: {0:c0}", ResearchDevHealValueSum);
						ResearchDevHealValueSum = 0;
					}
				}
				getFightLog = msg;
				sortSkills();
				GameTeam1[GameTeam1.Count - 1].clean();
				GameTeam2[GameTeam2.Count - 1].clean();
			}
		}
		
		public string displaySeating(string heading, int Value, int Max, ref int countChars)
		{
			string retMessage = "";
			// Add a new line for every 45 characters
			if (countChars > MainFormPanel.Width / 10)
			{
				countChars = 0;
				retMessage += "\n       ";
			}
			if (Max == -1) retMessage += string.Format("{0}:{1:c0} ", heading, Value);
			else if (Max == -2) retMessage += string.Format("{0}:{1:n0} ", heading, Value);
			else if (roundCount < 50) retMessage += string.Format("{0}:{1:n0}/{2:n0} ", heading, Value, Max);
			else if (Value > 0 && roundCount < 200) retMessage += string.Format("{0}:{1:n0} ", heading, Value);
			countChars += retMessage.Length;
			return retMessage;
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
			Label level = new Label { AutoSize = true, Width = 50, Text = eRobo.getLevel.ToString() + eRobo.getNameRank(false) };
			Robo.Controls.Add(level);
			Label Name = new Label { AutoSize = true, Width = 50, Text = eRobo.getName.PadRight(6).Substring(0,6)};
			Robo.Controls.Add(Name);
			PictureBox RoboPic = new PictureBox { Image = Image.FromFile(eRobo.getImage), Width = 50, Height = 50, SizeMode = PictureBoxSizeMode.StretchImage };
			Robo.Controls.Add(RoboPic);
			AlsProgressBar HP = new AlsProgressBar(Brushes.Green) { Maximum = eRobo.getTHealth(), Value = eRobo.HP, Width = 50, Height = 6 };
			Robo.Controls.Add(HP);
			AlsProgressBar MP = new AlsProgressBar(Brushes.Blue) { Maximum = eRobo.getTEnergy(), Value = eRobo.MP, Width = 50, Height = 6 };
			Robo.Controls.Add(MP);
			Brush myColour = Brushes.Chocolate;
			int tmpAnalysis = (int)eRobo.getAnalysisLeft();
			if (eRobo.getAnalysisLeft() == 0)
			{
				tmpAnalysis = (int)eRobo.getAnalysis;
				if (RndVal.Next(100) > 50) myColour = Brushes.LightGoldenrodYellow;
				else myColour = Brushes.Yellow;
			}
			AlsProgressBar XP = new AlsProgressBar(myColour) { Maximum = eRobo.getAnalysis, Value = tmpAnalysis, Width = 50, Height = 6 };
			Robo.Controls.Add(XP);
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
		public FlowLayoutPanel showSelectedTeam(int TeamSelect, bool showAll)
		{
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			if (TeamSelect > 0)
			{
				FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblTeamName = new Label { AutoSize = true, Text = "Team Name:  " + GameTeams[TeamSelect - 1].getName };
				lblTeamName.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].rename(InputBox("Enter Name ", "Enter Name")));
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + String.Format("{0:c0}", GameTeams[TeamSelect - 1].getCurrency) };
				Label lblScore = new Label { AutoSize = true, Text = "Score:      " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getScore) + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getGoalScore) + ")" };
				Label lblWin = new Label { AutoSize = true, Text = String.Format("Winns:      {0:n0}", GameTeams[TeamSelect - 1].Win) };
				Label lblRobots = new Label { AutoSize = true, Text = "Robots:     " + GameTeams[TeamSelect - 1].MyTeam.Count + "/" + GameTeams[TeamSelect - 1].getMaxRobos + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getRoboCost) + ")" };
				Label lblRunes = new Label { AutoSize = true, Text = "Runes:     " + GameTeams[TeamSelect - 1].getRunes() };
				Label lblDifficulty = new Label { AutoSize = true, Text =     "Difficulty: " + GameTeams[TeamSelect - 1].getDifficulty };
				Label lblAutomatic = new Label { AutoSize = true, Text =    "Automated:  " + GameTeams[TeamSelect - 1].Automated };
				Label lblPayForRepair = new Label { AutoSize = true, Text = "Pay For Rep:" + GameTeams[TeamSelect - 1].PayForRepairs };
				lblAutomatic.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].changeAutomated());
				lblPayForRepair.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].changePayForRepairs());
				MainPanel.Controls.Add(lblTeamName);
				MainPanel.Controls.Add(lblTeamCurrency);
				MainPanel.Controls.Add(lblScore);
				MainPanel.Controls.Add(lblWin);
				MainPanel.Controls.Add(lblRobots);
				MainPanel.Controls.Add(lblRunes);
				MainPanel.Controls.Add(lblDifficulty);
				MainPanel.Controls.Add(lblAutomatic);
				MainPanel.Controls.Add(lblPayForRepair);
				int index = 0;
				foreach (Robot eRobo in GameTeams[TeamSelect - 1].MyTeam)
				{
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
					RoboName.Click += new EventHandler((sender, e) => eRobo.rename(InputBox("Enter Name ", "Enter Name")));
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					Button btnRebuild = new Button { AutoSize = true, Text = String.Format("Rebuild ({0:n0} {1:p0})", eRobo.rebuildCost(ResearchDevRebuild, GameTeams[TeamSelect - 1].Runes), eRobo.rebuildSavings(GameTeams[TeamSelect - 1].Runes), eRobo.RoboRebuildCost) };
					int innerIndex = index++;
					if (getGameCurrency > 0)
						btnRebuild.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].Rebuild(innerIndex, true, this));
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
				int[] RowOneLength =
					{ getMaxLength(new string[] { string.Format("{0:n0}", getScore()), string.Format("{0:n0}/{1:n0}",GameTeams.Count, getMaxTeams), string.Format("{0:c0}", getGameCurrency),
						string.Format("{0:n0}", getArenaLvl),string.Format("{0:n0}", getShopLvl), string.Format("{0:n0}", getResearchDevLvl), string.Format("{0:n0}", getMonsterDenLvl),
						string.Format("{0:n0}", BossCount), string.Format("{0:n0}", ManagerHrs)})
					, getMaxLength(new string[] { string.Format("{0:\\-#,###}", getArenaLvlCost), string.Format("{0:\\-#,###}", getShopLvlCost), string.Format("{0:\\-#,###}", getResearchDevLvlCost), string.Format("{0:\\-#,###}", getMonsterDenLvlCost) })
					, getMaxLength(new string[] { string.Format("{0:\\-#,###}", getArenaLvlMaint), string.Format("{0:\\-#,###}", getShopLvlMaint), string.Format("{0:\\-#,###}", getResearchDevMaint), string.Format("{0:\\-#,###}", getMonsterDenLvlMaint) })
				};
				int[] RowTwoLength =
					{ getMaxLength(new string[] { string.Format("{0}/{1}", storeEquipment.Count, getShopStock), string.Format("{0:n0}", getResearchDevHealValue), string.Format("{0:n0}", MonsterOutbreak.MyTeam.Count) })
					, getMaxLength(new string[] { string.Format("{0:n0}", getShopMaxDurability), string.Format("{0:n0}", MonsterDenBonus), string.Format("{0:n0}", getResearchDevHealBays) })
					, getMaxLength(new string[] { string.Format("{0:n0}", getShopMaxStat) })
					, getMaxLength(new string[] { string.Format("{0:n0}", getShopStockCost) })
					, getMaxLength(new string[] { string.Format("{0:n0}", getShopUpgradeValue) })
				};
				Label lblTotalScore = new Label { AutoSize = true, Text = String.Format("Total Score: {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\*#,###}", getScore(), getGoalGameScore) };
				MainPanel.Controls.Add(lblTotalScore);
				Label lblTeams = new Label { AutoSize = true, Text =	  String.Format("Teams:       {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\+#,###}", string.Format("{0:n0}/{1:n0}",GameTeams.Count, getMaxTeams), getTeamCost)};
				MainPanel.Controls.Add(lblTeams);
				//Label lblCurrency = new Label { AutoSize = true, Text =   String.Format("{0,-13}{1," + RowOneLength[0] + ":c0} \n{2,-13}{3," + RowOneLength[0] + ":c0}\n{4,-13}{5," + RowOneLength[0] + ":c0}\n{6,-13}{7," + RowOneLength[0] + ":c0}\n{8,-13}{9," + RowOneLength[0] + ":c0}", "Currency:",getGameCurrency, "   Misc ",  GameCurrencyLogMisc, "   Maint -", 0 - GameCurrencyLogMaint, "   Upgr  -", 0 - GameCurrencyLogUp, "   Total =", GameCurrencyLogMisc + GameCurrencyLogMaint + GameCurrencyLogUp) };
				Label lblCurrency = new Label { AutoSize = true, Text =   String.Format("{0,-13}{1," + RowOneLength[0] + ":c0}", "Currency:",getGameCurrency)};
				MainPanel.Controls.Add(lblCurrency);
				Label lblArenaLvl = new Label { AutoSize = true, Text =   String.Format("Arena:       {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###}", getArenaLvl, getArenaLvlCost, getArenaLvlMaint) };
				MainPanel.Controls.Add(lblArenaLvl);
				FlowLayoutPanel pnlSeating = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				// get highest width for columns in seating.
				int[] RowThreeLength = { 1, 1, 1 };
				foreach (ArenaSeating eSeating in Seating)
				{
					if (string.Format("{0:n0}", eSeating.Level).Length > RowThreeLength[0]) RowThreeLength[0] = string.Format("{0:n0}", eSeating.Level).Length;
					if (string.Format("{0:n0}", eSeating.Price).Length > RowThreeLength[1]) RowThreeLength[1] = string.Format("{0:n0}", eSeating.Price).Length;
					if (string.Format("{0:n0}", eSeating.Amount).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:n0}", eSeating.Amount).Length;
				}
				int index = 0;
				foreach (ArenaSeating eSeating in Seating)
				{
					if (showAll || index <= 2)
					{
						string ending = "";
						if (index == 2 && !showAll && Seating.Count > 3) ending = "...";
						Label lblArenaSeating = new Label { AutoSize = true, Text = String.Format("    Level:{3," + RowThreeLength[0] + "} Price:{0," + RowThreeLength[1] + ":n0} Seats:{1," + RowThreeLength[2] + ":n0}{2}\n", eSeating.Price, eSeating.Amount, ending, eSeating.Level) };
						pnlSeating.Controls.Add(lblArenaSeating);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlSeating);
				Label lblShopLvl = new Label { AutoSize = true, Text = String.Format("Shop:        {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###}", getShopLvl, getShopLvlCost, getShopLvlMaint) };
				MainPanel.Controls.Add(lblShopLvl);
				FlowLayoutPanel pnlEquipment = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				Label lblShopStock = new Label { AutoSize = true, Text = String.Format("  {0,-10}{1," + RowTwoLength[0] + "} {2,-6}{3," + RowTwoLength[1] + ":n0} {4,-7}{5," + RowTwoLength[2] + ":n0} {6,-5}{7," + RowTwoLength[3] + ":n0} {8,-4}{9," + RowTwoLength[4] + ":n0}", "Max Stock",string.Format("{0}/{1}", storeEquipment.Count, getShopStock), "Dur", getShopMaxDurability, "Stat", getShopMaxStat, "Cost", getShopStockCost, "Up", getShopUpgradeValue) };
				pnlEquipment.Controls.Add(lblShopStock);
				RowThreeLength = new int[] { 8, 3, 1, 3 };
				foreach (Equipment eEquipment in storeEquipment)
				{
					if (eEquipment.eName.Length > RowThreeLength[0]) RowThreeLength[0] = eEquipment.eName.Length;
					if (string.Format("{0:n0}", eEquipment.eMaxDurability).Length > RowThreeLength[1]) RowThreeLength[1] = string.Format("{0:n0}", eEquipment.eMaxDurability).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eHealth).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eHealth).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eEnergy).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eEnergy).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eDamage).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eDamage).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eHit).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eHit).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eArmour).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eArmour).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eMentalStrength).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eMentalStrength).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eMentalDefense).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eMentalDefense).Length;
					if (string.Format("{0:\\+#,###}", eEquipment.eSpeed).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:\\+#,###}", eEquipment.eSpeed).Length;
					if (string.Format("{0:n0}", eEquipment.ePrice).Length > RowThreeLength[3]) RowThreeLength[3] = string.Format("{0:n0}", eEquipment.ePrice).Length;
				}
				index = 0;
				foreach (Equipment eEquipment in storeEquipment)
				{
					if (showAll || index <= 2)
					{
						string ending = "";
						if (index == 2 && !showAll && storeEquipment.Count > 3) ending = "...";
						string tmp = string.Format("{0,-" + RowThreeLength[0] + "}", eEquipment.eName);
						tmp += String.Format(" Dur {0," + RowThreeLength[1] + ":n0}", eEquipment.eDurability);
						if (eEquipment.eHealth > 0) { tmp += String.Format(" Hea{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eHealth); }
						if (eEquipment.eEnergy > 0) { tmp += String.Format(" Enr{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eEnergy); }
						if (eEquipment.eDamage > 0) { tmp += String.Format(" Dam{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eDamage); }
						if (eEquipment.eHit > 0) { tmp += String.Format(" Hit{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eHit); }
						if (eEquipment.eArmour > 0) { tmp += String.Format(" Acl{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eArmour); }
						if (eEquipment.eMentalStrength > 0) { tmp += String.Format(" Mst{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eMentalStrength); }
						if (eEquipment.eMentalDefense > 0) { tmp += String.Format(" Mdf{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eMentalDefense); }
						if (eEquipment.eSpeed > 0) { tmp += String.Format(" Spd{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eSpeed); }
						tmp += String.Format(" Price {0," + RowThreeLength[3] + ":n0}", eEquipment.ePrice);
						Label lblEquipment = new Label { AutoSize = true, Text = string.Format("    {0}{1}\n", tmp, ending) };
						pnlEquipment.Controls.Add(lblEquipment);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlEquipment);
				Label lblResearchLvl = new Label { AutoSize = true, Text = String.Format("Research:    {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###}\n  {3,-10}{4," + RowTwoLength[0] + "} {5,-6}{6," + RowTwoLength[1] + ":n0} {7,-7}{8," + RowTwoLength[2] + ":n0}", getResearchDevLvl, getResearchDevLvlCost, getResearchDevMaint, "Heal", getResearchDevHealValue, "Bay", getResearchDevHealBays, "Rbld", ResearchDevRebuild) };
				MainPanel.Controls.Add(lblResearchLvl);
				Label lblMonsterDen = new Label { AutoSize = true, Text = String.Format("Monster Den: {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###}\n  {3,-10}{4," + RowTwoLength[0] + "} {5,-6}{6," + RowTwoLength[1] + ":n0} {7,-7}{8," + RowTwoLength[2] + ":n0}", MonsterDenLvl, getMonsterDenLvlCost, getMonsterDenLvlMaint, "In Den", MonsterOutbreak.MyTeam.Count, "Bonus", MonsterDenBonus, "Repair", MonsterDenRepairs) };
				lblMonsterDen.Click += new EventHandler((sender, e) => displayMonsters("Monster Outbreak"));
				MainPanel.Controls.Add(lblMonsterDen);
				Label lblBossMonsters = new Label { AutoSize = true, Text = String.Format("BossMonsters:{0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":c0}", BossCount, BossReward) };
				lblBossMonsters.Click += new EventHandler((sender, e) => displayMonsters("Boss Monsters"));
				MainPanel.Controls.Add(lblBossMonsters);
				Label lblManager = new Label { AutoSize = true, Text = String.Format("Manager:     {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\+#,###}", ManagerHrs, ManagerCost) };
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
		public void displayMonsters(string type, int StartingCount = 0)
		{
			
			Team displayTeam = MonsterOutbreak;
			if (type.Equals("Boss Monsters"))
				displayTeam = Bosses;
			foreach (Robot eRobot in displayTeam.MyTeam)
				eRobot.sortSkills();
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
			FlowLayoutPanel MyMonsterPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
			FlowLayoutPanel MyButtonPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
			Label lblTeamName = new Label { AutoSize = true, Text = String.Format("\n\nTeam Name:  {0}       {1:c0}  ({2}-{3})", displayTeam.getName,displayTeam.getCurrency,type, StartingCount) };
			Label lblRobots = new Label { AutoSize = true, Text =   "Monsters:   " + displayTeam.MyTeam.Count };
			MainPanel.Controls.Add(lblTeamName);
			MainPanel.Controls.Add(lblRobots);
			int count = 0;
			int shown = 0;
			int button = 0;
			foreach (Robot eRobo in displayTeam.MyTeam)
			{
				if (count >= StartingCount && shown < 50)
				{
					FlowLayoutPanel MyIndividualMonsterPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					MyIndividualMonsterPanel.Controls.Add(RoboName);
					MyIndividualMonsterPanel.Controls.Add(Everything);
					MyMonsterPanel.Controls.Add(MyIndividualMonsterPanel);
					shown++;
				}
				if (button <= count)
				{
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					// Add button to show now 100 monsters
					Label btnNext = new Label { AutoSize = true, Text = String.Format("lvl<={0:n0}", eRobo.getLevel) };
					string tmpType = type;
					int tmpCount = count;
					btnNext.Click += new EventHandler((sender, e) => displayMonsters(tmpType, tmpCount));
					MyPanel.Controls.Add(btnNext);
					MyButtonPanel.Controls.Add(MyPanel);
					button = count + 49;
				}
				count++;
			}
			TopLevelPanel.Controls.Add(MyButtonPanel);
			TopLevelPanel.Controls.Add(MyMonsterPanel);
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
						if (eRobo.getKO <= 3)
							maxLength = checkLength(maxLength, eRobo);
				foreach (Team eTeam in GameTeam2)
					foreach (Robot eRobo in eTeam.MyTeam)
						if (eRobo.getKO <= 3)
							maxLength = checkLength(maxLength, eRobo);
			}
			else
			{
				foreach (Team eTeam in GameTeams)
					foreach (Robot eRobo in eTeam.MyTeam)
						if (eRobo.getKO <= 3)
							maxLength = checkLength(maxLength, eRobo);
			}
			return maxLength;
		}
		public int[] checkLength(int[] maxLength, Robot eRobo)
		{
			// Name
			if (eRobo.getNameRank().Length > maxLength[0])
				maxLength[0] = eRobo.getNameRank().Length;
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
		public int getMaxTeamsAutomated()
		{
			int myMax = 1;
			if (GameTeam1.Count > 0 && GameTeam1[0].Automated && GameTeam2[0].Automated)
				myMax = MaxTeams;
			return myMax;
		}
		public FlowLayoutPanel continueFight(bool display)
        {
			roundCount++;
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			String strFlags = "";
			if (bossFight) strFlags += " Boss Fight";
			if (GameDifficultyFight) strFlags += " Difficulty Fight";
			if (JackpotUp) strFlags += " Jackpot Up";
			if (JackpotUpTen) strFlags += " Jackpot Up 10";
			if (JackpotDown) strFlags += " Jackpot Down";
			if (JackpotDownTen) strFlags += " Jackpot Down 10";
			Label lblTeamName = new Label { AutoSize = true, Text = "Fight (" + showInterval() + ")" + strFlags };
			MainPanel.Controls.Add(lblTeamName);
			int KOCount = 3;
			if (GameTeam1.Count > 0 && GameTeam1[0].Automated && GameTeam2[0].Automated) KOCount = 0;
			for (int i = 0; i < GameTeam1.Count; i++)
			{
				if (GameTeam1[i].getNumRobos(true, KOCount) > 0 && GameTeam2[i].getNumRobos(true, KOCount) > 0)
				{
					getNext(i);
					if (display)
					{
						if (auto)
						{
							if (i == 0)
							{
								Label lblGameStats = new Label { AutoSize = true, Text = String.Format("C:{0:n0} TS:{1:n0}({2:n0}) D:{3:n0} J:{4:n0}", getGameCurrency, getScore(), getScoreLog(), gameDifficulty,Jackpot) };
								MainPanel.Controls.Add(lblGameStats);
							}
							Color background = Color.Transparent;
							if (i % 2 == 1)
								background = Color.LightGray;
							Label lblTeam1stats = new Label { AutoSize = true, BackColor = background, Text = GameTeam1[i].getTeamStats(maxNameLength(true), ResearchDevRebuild, KOCount, this) };
							int tmpI = i;
							/*if (getGameCurrency > 0)
								lblTeam1stats.Click += new EventHandler((sender, e) => GameTeam1[tmpI].Rebuild(true, this));*/
							MainPanel.Controls.Add(lblTeam1stats);
							Label lblTeam2stats = new Label { AutoSize = true, BackColor = background, Text = GameTeam2[i].getTeamStats(maxNameLength(true), ResearchDevRebuild, KOCount, this) };
							/*if (getGameCurrency > 0)
								lblTeam2stats.Click += new EventHandler((sender, e) => GameTeam2[tmpI].Rebuild(true, this));*/
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
							Label lblGameStats = new Label { AutoSize = true, Text = String.Format("C:{0:n0} TS:{1:n0}({2:n0}) D:{3:n0} J:{4:n0}", getGameCurrency, getScore(), getScoreLog(), gameDifficulty,Jackpot) };
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
					else
					{
						if (DateTime.Now > BreakTime)
						{
							GameTeam1[i].getTeamStats(maxNameLength(true), ResearchDevRebuild, KOCount, this);
							GameTeam2[i].getTeamStats(maxNameLength(true), ResearchDevRebuild, KOCount, this);
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
								lblWinner.Text = getFightLog = Environment.NewLine + " +++ Arena suppressed the Monster outbreak" + String.Format("({0})", findMonster);
								addMonsters(GameTeam2[0]);
							}
							else if (GameTeam2[i].getName.Equals("Game Diff " + gameDifficulty.ToString()))
							{
								gameDifficulty++;
								GameCurrency += Jackpot;
								GameCurrencyLogMisc += Jackpot;
								GoalGameScore = (int)roundValue(GoalGameScore, GoalGameScoreBase, "up");
								GoalGameScoreBase += GoalGameScoreBaseIncrement;
								Jackpot = 0;
								getWarningLog = lblWinner.Text = getFightLog = Environment.NewLine + " +++ Arena defeated monsters difficulty increased ";
								resetScore();
							}
							// Boss Fight
							else
							{
								lblWinner.Text = getWarningLog = bossLevelUp();
								MaxTeams++;
							}
						}
						else
						{
							if (GameTeam2[i].getName.Equals("Monster Outbreak"))
							{
								// fewer new monsters
								findMonster -= 5;
								if (findMonster < 5)
								{
									MonsterOutbreak = new Team(0, 1, findMonster, ref MonsterOutbreak);
									MonsterOutbreak.getName = "Monster Outbreak";
								}
								getGameCurrency -= Jackpot;
								GameCurrencyLogMaint -= Jackpot;
								lblWinner.Text = getFightLog = Environment.NewLine + "--- Arena suffered damages from Monster outbreak -" + String.Format("{0:n0} ({1}%)", Jackpot, findMonster) ;
								addMonsters(GameTeam2[0]);
							}
							else if (GameTeam2[i].getName.Equals("Game Diff " + gameDifficulty.ToString()))
							{
								Jackpot = 0;
								getWarningLog = lblWinner.Text = getFightLog = Environment.NewLine + "--- Arena lost to monsters ";
								GoalGameScore += RndVal.Next(GoalGameScoreBase);
								resetScore();
							}
							else
							{
								string tmp = getWarningLog = getFightLog = Environment.NewLine + "Arena suffered a loss against the boss monsters! ";
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
								long tmp = (long)(Jackpot * .7);
								GameTeam1[i].getCurrency += tmp;
								Jackpot -= tmp;
								msg += " " + String.Format("{0:n0}", tmp);
								// increase difficulty if monster
								if (GameTeam2[i].isMonster)
								{
									msg = Environment.NewLine + GameTeam1[i].getName + " Won against " + GameTeam2[i].getName + msg;
									WinCount++;
									GameTeam1[i].getDifficulty++;
									// fight next difficulty
									Team tmpTeam = new Team(GameTeam1[i].getDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak);
									addMonsters(GameTeam2[i]);
									GameTeam2[i] = tmpTeam;
									msg = GameTeam1[i].getName + " VS " + GameTeam2[i].getName + msg;
									GameTeam1[i].healRobos(false);
									equip(GameTeam1[i], true);
									newMonster = true;
								}
								else
								{
									// increase score 
									GameTeam1[i].getScore++;
									// Try difficulty fight 
									if (getScore() == GoalGameScore && !GameTeam2[0].getName.Equals("Game Diff " + gameDifficulty.ToString())) GameDifficultyFight = true;
									if (RndVal.Next(100) > 90)
									{
										GameTeam2[i].getScore--;
										GameTeam1[i].getScore++;
									}
									// pay team 2 remaining;
									GameTeam2[i].getCurrency += Jackpot;
									msg += " (" + String.Format("{0:n0}", Jackpot) + ")";
									Jackpot = 0;
									msg = Environment.NewLine + GameTeam1[i].getName + " Won against " + GameTeam2[i].getName + msg;
								}
							}
							else
							{
								FightBreak = 95;
								lblWinner.Text = GameTeam2[i].getName + " winns!";
								GameTeam2[i].getScore++;
								// Try difficulty fight 
								if (getScore() == GoalGameScore && !GameTeam2[0].getName.Equals("Game Diff " + gameDifficulty.ToString())) GameDifficultyFight = true;
								if (RndVal.Next(100) > 90)
								{
									GameTeam1[i].getScore--;
									GameTeam2[i].getScore++;
								}
								// monster won
								if (GameTeam2[i].isMonster)
								{
									// pay loosing team
									long tmp = (long)(Jackpot * .7);
									MonsterOutbreak.getCurrency += tmp;
									tmp = (int)(Jackpot - tmp);
									GameTeam1[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += String.Format(" ({0:n0}) Win:{1}", tmp, WinCount);
									int lastRobo = GameTeam1[i].MyTeam.Count - 1;
									// if team looses against difficulty where highest level is lower than the lowest level of robot on team, low chance to add new robo to the team. 
									if (GameTeam1[i].getDifficulty * 5 < GameTeam1[i].MyTeam[lastRobo].getLevel && GameTeam1[i].getAvailableRobo == 0 && RndVal.Next(100) > 75)
									{
										GameTeam1[i].getMaxRobos++;
										getFightLog = getWarningLog = string.Format("\n!*!* {0} added robot!", GameTeam1[i].getName);
									}
								}
								else
								{
									// team won they get 70%
									long tmp = (long)(Jackpot * .7);
									GameTeam2[i].getCurrency += tmp;
									Jackpot -= tmp;
									msg += " " + String.Format("{0:n0}", tmp);
									// team lost gets remaining
									GameTeam1[i].getCurrency += Jackpot;
									msg += " (" + String.Format("{0:n0}", Jackpot) + ")";
									Jackpot = 0;
								}
								msg = Environment.NewLine + GameTeam2[i].getName + " Won against " + GameTeam1[i].getName + msg;
							}
							getFightLog = Environment.NewLine + msg;
							MainPanel.Controls.Add(lblWinner);
							if (!newMonster)
							{
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
							Label lblTeamstats = new Label { AutoSize = true, Text = eTeam.getTeamStats(maxNameLength(false), ResearchDevRebuild, KOCount, this, roundCount) };
							if (getGameCurrency > 0)
								lblTeamstats.Click += new EventHandler((sender, e) => eTeam.Rebuild(true, this));
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
							int type = RndVal.Next(100);
							if (type < 60)
								eMonster.getName += " " + ToRoman(getNumeral++);
							else if (type < 90)
								eMonster.getName += string.Format(" #{0:X}", getNumeral++);
							else
								eMonster.getName += string.Format(" {0:N0}", getNumeral++);
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
		public int IncreaseJackpot(int recall)
		{
			int retVal = 0;
			for (int i = 0; i < recall; i++)
				retVal = IncreaseJackpot();
			return retVal;
		}
		public int IncreaseJackpot()
		{
			CurrentJackpotLvl++;
			CurrentJackpot = roundValue(CurrentJackpot, CurrentJackpotBase, "up");
			CurrentJackpotBase += CurrentJackpotBaseIncrement;
			return CurrentJackpot;
		}
		public int DecreaseJackpot(int recall)
		{
			int retVal = 0;
			for (int i = 0; i < recall; i++)
				retVal = DecreaseJackpot();
			return retVal;
		}
		public int DecreaseJackpot()
		{
			if (CurrentJackpot > MinJackpot)
			{
				CurrentJackpotLvl--;
				CurrentJackpot = roundValue(CurrentJackpot, CurrentJackpotBase, "down");
				CurrentJackpotBase -= CurrentJackpotBaseIncrement;
			}
			// current Jackpot reset to min level
			if (CurrentJackpotLvl < 1 || CurrentJackpot < 3)
            {
				CurrentJackpot = 3;
				CurrentJackpotLvl = 1;
				CurrentJackpotBase = 1;
				CurrentJackpotBaseIncrement = 1;
				while (CurrentJackpot < MinJackpot)
				{
					IncreaseJackpot();
				}
			}
			return CurrentJackpot;
		}
		public void equip(Team eTeam, bool checkFight)
		{
			Robot shopper;
			Robot monster;
			if (GameTeam1 == null || GameTeam1.Count == 0 || checkFight)
			{
				shopper = eTeam.MyTeam[RndVal.Next(0, eTeam.MyTeam.Count)];
				bool bAutomated = eTeam.Automated;
				// Automated teams automatically build new robots and rebuild robots
				if (PurchaseUgrade || bAutomated)
				{
					// Add Robot
					if (eTeam.getCurrency >= eTeam.getRoboCost && eTeam.getAvailableRobo > 0 && getGameCurrency > 0)
					{
						addRobo(eTeam, this);
						eTeam.getTeamLog = getFightLog = Environment.NewLine + " +++ " + eTeam.getName + " built a new robot ";
					}
					// Rebuild Robot
					for (int i = 0; i < eTeam.MyTeam.Count; i++)
					{
						if (eTeam.getCurrency >= eTeam.MyTeam[i].rebuildCost(ResearchDevRebuild, eTeam.Runes) 
							&& (eTeam.MyTeam[i].rebuildCost(ResearchDevRebuild,eTeam.Runes) > 100 || (eTeam.MyTeam[i].rebuildCost(ResearchDevRebuild,eTeam.Runes) != 100 && eTeam.MyTeam[i].rebuildBonus > 0))
							)
						{
							if (getGameCurrency > 0)
							{
								int runesUsed = eTeam.getRunes(eTeam.MyTeam[i].getBaseStats(), false);
								eTeam.Rebuild(i, true, this);
							}
						}
					}
				}
				// if has equipment repair / upgrade it
				if (shopper.getEquipWeapon != null)
				{
					// upgrade
					if (eTeam.getCurrency > shopper.getEquipWeapon.eUpgradeCost && (PurchaseUgrade || bAutomated || shopper.getEquipWeapon.eDurability < shopper.getEquipWeapon.eMaxDurability * repairPercent) && shopper.getEquipWeapon.eMaxDurability > 50 && getGameCurrency > 0)
					{
						long tmpUpgrade = (shopper.getEquipWeapon.eUpgradeCost);
						eTeam.getCurrency -= tmpUpgrade;
						GameCurrency += (int)(tmpUpgrade * 0.1);
						GameCurrencyLogMisc += (int)(tmpUpgrade * 0.1);
						shopper.getEquipWeapon.upgrade(getShopUpgradeValue, RndVal);
						getFightLog = Environment.NewLine + " +++ " + eTeam.getName + ":" + shopper.getName + " Upgraded " + String.Format("{1} ({0:n0}) ", tmpUpgrade, shopper.getEquipWeapon.eName, shopper.getEquipWeapon.eUpgradeCost) + Environment.NewLine + "   " + shopper.getEquipWeapon.ToString();
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + shopper.getEquipWeapon.eName;
					}
					// Repair
					if (eTeam.getCurrency > (shopper.getEquipWeapon.ePrice / 10)
						&& shopper.getEquipWeapon.eDurability < shopper.getEquipWeapon.eMaxDurability * repairPercent)
					{
						int orig = shopper.getEquipWeapon.eDurability;
						shopper.getEquipWeapon.eDurability = shopper.getEquipWeapon.eMaxDurability = (int)(shopper.getEquipWeapon.eMaxDurability * .9);
						eTeam.getCurrency -= (shopper.getEquipWeapon.ePrice / 10);
						getFightLog = Environment.NewLine + " ### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", shopper.getEquipWeapon.ePrice / 10, shopper.getEquipWeapon.eName) + Environment.NewLine + "   " + shopper.getEquipWeapon.ToString(orig);
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipWeapon.ePrice / 10) + shopper.getEquipWeapon.eName;
					}
				}
				else
				{
					// buy
					int index = 0;
					foreach (Equipment eEquip in storeEquipment)
					{
						if (eTeam.getCurrency > eEquip.ePrice && eEquip.eType == "Weapon" && (PurchaseUgrade || bAutomated) && getGameCurrency > 0)
						{
							eTeam.getCurrency -= eEquip.ePrice;
							GameCurrency += eEquip.ePrice;
							GameCurrencyLogMisc += eEquip.ePrice;
							shopper.getEquipWeapon = eEquip;
							storeEquipment.RemoveAt(index);
							getFightLog = Environment.NewLine + " $$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", eEquip.ePrice, eEquip.eName) + Environment.NewLine + "   " + eEquip.ToString();
							eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " purchased " + String.Format("({0:n0}) ", eEquip.ePrice) + eEquip.eName;
							break;
						}
						index++;
					}
				}
				if (shopper.getEquipArmour != null)
				{
					// upgrade
					if (eTeam.getCurrency > shopper.getEquipArmour.eUpgradeCost && (PurchaseUgrade || bAutomated || shopper.getEquipArmour.eDurability < shopper.getEquipArmour.eMaxDurability * repairPercent) && shopper.getEquipArmour.eMaxDurability > 50 && getGameCurrency > 0)
					{
						long tmpUpgrade = (shopper.getEquipArmour.eUpgradeCost);
						eTeam.getCurrency -= tmpUpgrade;
						GameCurrency += (int)(tmpUpgrade * 0.1);
						GameCurrencyLogMisc += (int)(tmpUpgrade * 0.1);
						shopper.getEquipArmour.upgrade(getShopUpgradeValue, RndVal);
						getFightLog = Environment.NewLine + " +++ " + eTeam.getName + ":" + shopper.getName + " Upgraded " + String.Format("{1} ({0:n0}) ", tmpUpgrade, shopper.getEquipArmour.eName, shopper.getEquipArmour.eUpgradeCost) + Environment.NewLine + "   " + shopper.getEquipArmour.ToString();
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Upgraded " + String.Format("({0:n0}) ", tmpUpgrade) + shopper.getEquipArmour.eName;
					}
					// Repair 
					if (eTeam.getCurrency > (shopper.getEquipArmour.ePrice / 10)
						&& shopper.getEquipArmour.eDurability < shopper.getEquipArmour.eMaxDurability * repairPercent)
					{
						int orig = shopper.getEquipArmour.eDurability;
						shopper.getEquipArmour.eDurability = shopper.getEquipArmour.eMaxDurability = (int)(shopper.getEquipArmour.eMaxDurability * .9);
						eTeam.getCurrency -= (shopper.getEquipArmour.ePrice / 10);
						getFightLog = Environment.NewLine + " ### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", shopper.getEquipArmour.ePrice / 10, shopper.getEquipArmour.eName) + Environment.NewLine + "   " + shopper.getEquipArmour.ToString(orig);
						eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " Repaired " + String.Format("({0:n0}) ", shopper.getEquipArmour.ePrice / 10) + shopper.getEquipArmour.eName;
					}
				}
				else
				{
					// buy
					int index = 0;
					foreach (Equipment eEquip in storeEquipment)
					{
						if (eTeam.getCurrency > eEquip.ePrice && eEquip.eType == "Armour" && (PurchaseUgrade || bAutomated) && getGameCurrency > 0)
						{
							eTeam.getCurrency -= eEquip.ePrice;
							GameCurrency += eEquip.ePrice;
							GameCurrencyLogMisc += eEquip.ePrice;
							shopper.getEquipArmour = eEquip;
							storeEquipment.RemoveAt(index);
							getFightLog = Environment.NewLine + " $$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", eEquip.ePrice, eEquip.eName) + Environment.NewLine + "   " + eEquip.ToString();
							eTeam.getTeamLog = Environment.NewLine + " " + shopper.getName + " purchased " + String.Format("({0:n0}) ", eEquip.ePrice) + eEquip.eName;
							break;
						}
						index++;
					}
				}
				// Rebuild Monster
				if (MonsterOutbreak.MyTeam.Count > 0)
				{
					monster = MonsterOutbreak.MyTeam[RndVal.Next(0, MonsterOutbreak.MyTeam.Count)];
					if (MonsterOutbreak.getCurrency >= monster.rebuildCost(ResearchDevRebuild, eTeam.Runes) && (monster.rebuildCost(ResearchDevRebuild, eTeam.Runes) > 100))
						MonsterOutbreak.Rebuild(monster, true, this);
					// Repair Monster Weapon
					if (monster.getEquipWeapon != null)
					{
						if (MonsterOutbreak.getCurrency > (monster.getEquipWeapon.eUpgradeCost)
								&& monster.getEquipWeapon.eDurability < monster.getEquipWeapon.eMaxDurability * repairPercent)
						{
							int orig = monster.getEquipWeapon.eDurability;
							MonsterOutbreak.getCurrency -= (monster.getEquipWeapon.eUpgradeCost / 10);
							monster.getEquipWeapon.upgrade(monster.getLevel, RndVal);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " claws strengthened " + Environment.NewLine + "  " + monster.getEquipWeapon.ToString(orig);
						}
						else if (MonsterOutbreak.getCurrency > (monster.getEquipWeapon.ePrice / 10)
								&& monster.getEquipWeapon.eDurability < monster.getEquipWeapon.eMaxDurability * repairPercent)
						{
							int orig = monster.getEquipWeapon.eDurability;
							monster.getEquipWeapon.eDurability = monster.getEquipWeapon.eMaxDurability = (int)(monster.getEquipWeapon.eMaxDurability * .9);
							MonsterOutbreak.getCurrency -= (monster.getEquipWeapon.ePrice / 10);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " claws healed " + Environment.NewLine + "  " + monster.getEquipWeapon.ToString(orig);
						}
					}
					else
					{
						// Add Weapon
						Equipment tmp = new Equipment(true, RndVal.Next(1, monster.getLevel), RndVal.Next(100, (monster.getLevel + 100)), RndVal);
						tmp.eName = "Claw";
						if (MonsterOutbreak.getCurrency > tmp.ePrice)
						{
							MonsterOutbreak.getCurrency -= tmp.ePrice;
							monster.getEquipWeapon = tmp;
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " regrew claw" + Environment.NewLine + "  " + tmp.ToString();
						}
					}
					// Repair Monster Armour
					if (monster.getEquipArmour != null)
					{
						if (MonsterOutbreak.getCurrency > (monster.getEquipArmour.eUpgradeCost)
								&& monster.getEquipArmour.eDurability < monster.getEquipArmour.eMaxDurability * repairPercent)
						{
							int orig = monster.getEquipArmour.eDurability;
							MonsterOutbreak.getCurrency -= (monster.getEquipArmour.eUpgradeCost);
							monster.getEquipArmour.upgrade(monster.getLevel, RndVal);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " hide strengthened " + Environment.NewLine + "  " + monster.getEquipArmour.ToString(orig);
						}
						else if (MonsterOutbreak.getCurrency > (monster.getEquipArmour.ePrice / 10)
								&& monster.getEquipArmour.eDurability < monster.getEquipArmour.eMaxDurability * repairPercent)
						{
							int orig = monster.getEquipArmour.eDurability;
							monster.getEquipArmour.eDurability = monster.getEquipArmour.eMaxDurability = (int)(monster.getEquipArmour.eMaxDurability * .9);
							MonsterOutbreak.getCurrency -= (monster.getEquipArmour.ePrice / 10);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " hide healed " + Environment.NewLine + "  " + monster.getEquipArmour.ToString(orig);
						}
					}
					else
					{
						// Add Armour
						Equipment tmp = new Equipment(false, RndVal.Next(1, monster.getLevel), RndVal.Next(100, (monster.getLevel + 100)), RndVal);
						tmp.eName = "Hide";
						if (MonsterOutbreak.getCurrency > tmp.ePrice)
						{
							MonsterOutbreak.getCurrency -= tmp.ePrice;
							monster.getEquipArmour = tmp;
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " regrew hide" + Environment.NewLine + "  " + tmp.ToString();
						}
					}

				}
			}
		}
		public long longRandom(long value)
		{
			long retVal = 0;
			if (value < 0) value = 0;
			while (value >= 2000000000)
			{
				retVal += RndVal.Next(2000000000);
				value -= 2000000000;
			}
			return retVal + RndVal.Next((int)value);
		}
		public void buildingMaintenance()
		{
			long MaintCost = 0;
			string strMessage = "";
			long maintValue = RndVal.Next(200);
			// if arena is in debt, none of the benefits are available (Monster den bonus, Equipment upgrades, Repair bay, etc) so no maintenance required.
			if (getGameCurrency <= 0)
				maintValue = RndVal.Next(50, 250);
			// maintValue = 31; //test Monster Outbreak
			switch (maintValue)
			{
				case 1:
					// Arena Maintenance
					if (ArenaLvlMaint > 0)
						MaintCost += roundValue(getArenaLvlMaint - MonsterDenRepairs);
					else
					{
						MaintCost += Math.Abs(getArenaLvlMaint);
						if (MaintCost > getArenaLvlCost / 2 && getArenaLvlCost > 1000)
						{
							getArenaLvlCost = roundValue(getArenaLvlCost, ArenaLvlCostBase, "down");
							getArenaLvlMaint = getArenaLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Arena Rebuilt +{0:c0} Maint:{1:c0}", getArenaLvlCost, MaintCost);
						}
					}
					getArenaLvlMaint = roundValue(getArenaLvlMaint, (int)((double)MaintCost * 0.1), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = Environment.NewLine + "*** Arena: !boiler replaced - cost " + String.Format("{0:n0}", MaintCost);
					break;
				case 2:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "roof leaked";
					goto case 3;
				case 3:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "health and safety ticket";
					goto case 4;
				case 4:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "vandalism";
					goto case 5;
				case 5:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "advertising";
					goto case 6;
				case 6:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "repair seating";
					goto case 7;
				case 7:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "painting";
					goto case 8;
				case 8:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 9;
				case 9:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 10;
				case 10:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 100);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 205;
				case 11:
					// Shop Maintenance
					if (getShopLvlMaint > 0)
						MaintCost = roundValue(getShopLvlMaint - MonsterDenRepairs);
					else
					{
						MaintCost = Math.Abs(getShopLvlMaint);
						// if maintenace is more than half the cost to upgrade / rebuild
						if (MaintCost > getShopLvlCost / 2 && getShopLvlCost > 1000)
						{
							getShopLvlCost = roundValue(getShopLvlCost, ShopLvlCostBase, "down");
							getShopLvlMaint = getShopLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Shop Rebuilt +{0:c0} Maint:{1:c0}", getShopLvlCost, MaintCost);
						}
					}
					getShopLvlMaint = roundValue(getShopLvlMaint, (int)((double)MaintCost * 0.1), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = Environment.NewLine + "*** Shop: !forge replaced - cost " + string.Format("{0:n0}", MaintCost);
					break;
				case 12:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "forge repaired";
					goto case 13;
				case 13:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "new sharpening stones";
					goto case 14;
				case 14:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "clean exhaust";
					goto case 15;
				case 15:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "shop supplies";
					goto case 16;
				case 16:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "restock wires";
					goto case 17;
				case 17:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "new display";
					goto case 18;
				case 18:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 19;
				case 19:
					if (getShopLvlMaint > 0) MaintCost += (getShopLvlMaint / 100);
					else MaintCost += Math.Abs(getShopLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 20;
				case 20:
					// Shop Maintenance
					if (ShopLvlMaint > 0)
						MaintCost += (getShopLvlMaint / 100);
					else
					{
						MaintCost += Math.Abs(getShopLvlMaint / 100);
						if (MaintCost > getShopLvlCost / 2 && getShopLvlCost > 1000)
						{
							getShopLvlCost = roundValue(getShopLvlCost, ShopLvlCostBase, "down");
							getShopLvlMaint = getShopLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Shop Rebuilt +{0:c0} Maint:{1:c0}", getShopLvlCost, MaintCost);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getShopLvlMaint = roundValue(getShopLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Shop: {0} - cost {1:c0}", strMessage, MaintCost);
					break;
				case 21:
					// Research and Development Maintenance
					if (ResearchDevMaint > 0)
						MaintCost = roundValue((getResearchDevMaint - MonsterDenRepairs));
					else
					{
						MaintCost = Math.Abs(getResearchDevMaint);
						if (MaintCost > getResearchDevLvlCost / 2 && getResearchDevLvlCost > 1000)
						{
							getResearchDevLvlCost = roundValue(getResearchDevLvlCost, ResearchDevLvlCostBase, "down");
							ResearchDevMaint = getResearchDevLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** R and D Rebuilt +{0:c0} Maint:{1:c0}", getResearchDevLvlCost, MaintCost);
						}
					}
					getResearchDevMaint = roundValue(getResearchDevMaint, (int)((double)MaintCost * 0.1), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = Environment.NewLine + "*** R&&D: !experiment explosion - cost " + String.Format("{0:n0}", MaintCost);
					break;
				case 22:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "investigation";
					goto case 23;
				case 23:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "contamination";
					goto case 24;
				case 24:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "injury";
					goto case 25;
				case 25:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "research supplies";
					goto case 26;
				case 26:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "employee training";
					goto case 27;
				case 27:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "escaped test subject";
					goto case 28;
				case 28:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 29;
				case 29:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else MaintCost += Math.Abs(ResearchDevMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 30;
				case 30:
					if (ResearchDevMaint > 0) MaintCost += (ResearchDevMaint / 100);
					else
					{
						MaintCost += Math.Abs(ResearchDevMaint / 100);
						if (MaintCost > getResearchDevLvlCost / 2 && getResearchDevLvlCost > 1000)
						{
							getResearchDevLvlCost = roundValue(getResearchDevLvlCost, ResearchDevLvlCostBase, "down");
							ResearchDevMaint = getResearchDevLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** R&&D Rebuilt +{0:c0} Maint:{1:c0}", getResearchDevLvlCost, MaintCost);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getResearchDevMaint = roundValue(getResearchDevMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** R&&D: {0} - cost {1:c0}", strMessage, MaintCost);
					break;
				case 31:
					// Monster Den Maintenance
					if (MonsterDenLvlMaint > 0)
						MaintCost = (getMonsterDenLvlMaint - MonsterDenRepairs);
					else
					{
						MaintCost = Math.Abs(MonsterDenLvlMaint);
						if (MaintCost > MonsterDenLvlCost / 2 && MonsterDenLvlCost > 1000)
						{
							getMonsterDenLvlCost = roundValue(getMonsterDenLvlCost, MonsterDenLvlCostBase, "down");
							MonsterDenLvlMaint = getMonsterDenLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Monster Den: !Rebuilt +{0:c0} Maint:{1:c0}", getMonsterDenLvlCost, MaintCost);
						}
					}
					// split value in two
					long monsterOutbreakCost = roundValue(longRandom(MaintCost));
					startMonsterOutbreak(monsterOutbreakCost);
					MaintCost = roundValue(MaintCost - monsterOutbreakCost);
					MonsterDenLvlMaint = roundValue(MonsterDenLvlMaint, (int)((double)MaintCost * 0.1), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = Environment.NewLine + "*** Monster Den: Outbreak - cost " + String.Format("{0:n0}", MaintCost);
					break;
				case 32:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "contagion breakout";
					goto case 33;
				case 33:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "keeper injury";
					goto case 34;
				case 34:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "broken cage";
					goto case 35;
				case 35:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
					goto case 36;
				case 36:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
					goto case 37;
				case 37:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 38;
				case 38:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 39;
				case 39:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 210;
				case 45:
					// Arena Sponsor 
					if (RndVal.Next(100) < GameTeams.Count)
					{
						MaintCost += roundValue(RndVal.Next(gameDifficulty * BossCount * getArenaLvl * 1000));
						getGameCurrency += MaintCost;
						GameCurrencyLogMisc += MaintCost;
						getWarningLog = Environment.NewLine + "!!! Arena Received a sponsor! +" + String.Format("{0:n0}", MaintCost);
					}
					break;
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
					// Tax
					long tmpMaint = (long)((ArenaLvlMaint-- * 0.1) + (MonsterDenLvlMaint-- * 0.1) + (ShopLvlMaint-- * 0.1) + (ResearchDevMaint-- * 0.1));
					if (tmpMaint > 0)
						MaintCost = roundValue(tmpMaint);
					else
						MaintCost = roundValue(tmpMaint * -1);
					if (getGameCurrency > 0 && tmpMaint > 0)
					{
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						getFightLog = Environment.NewLine + "*** Taxes cost " + String.Format("-{0:n0}", MaintCost);
					}
					else
					{
						getGameCurrency += MaintCost;
						GameCurrencyLogMaint += MaintCost; 
						getFightLog = Environment.NewLine + "*** Tax rebate " + String.Format("+{0:n0}", MaintCost);
					}
					break;
				case 99:
					int team = RndVal.Next(100);
					if (team < GameTeams.Count)
					{
						// sponsored a team
						MaintCost += roundValue(RndVal.Next(gameDifficulty * BossCount * getArenaLvl * 1000 * (GameTeams[team].Win + 1)));
						GameTeams[team].getCurrency += MaintCost;
						getWarningLog = Environment.NewLine + "!!! " + GameTeams[team].getName + " Received a sponsor! +" + String.Format("{0:n0}", MaintCost);
					}
					break;
				case 203:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 200);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 204;
				case 204:
					if (ArenaLvlMaint > 0) MaintCost += (getArenaLvlMaint / 200);
					else MaintCost += Math.Abs(getArenaLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 205;
				case 205:
					// Arena Maintenance
					if (ArenaLvlMaint > 0)
						MaintCost += (getArenaLvlMaint / 100);
					else
					{
						MaintCost += Math.Abs(getArenaLvlMaint / 100);
						if (MaintCost > getArenaLvlCost / 2 && getArenaLvlCost > 1000)
						{
							getArenaLvlCost = roundValue(getArenaLvlCost, ArenaLvlCostBase, "down");
							getArenaLvlMaint = getArenaLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Arena Rebuilt +{0:c0} Maint:{1:c0}", getArenaLvlCost, MaintCost);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getArenaLvlMaint = roundValue(getArenaLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Arena: {0} - cost {1:c0}", strMessage, MaintCost);
					break;

				case 208:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 200);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
					goto case 209;
				case 209:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 200);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
					goto case 210;
				case 210:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else
					{
						MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
						if (MaintCost > MonsterDenLvlCost / 2 && MonsterDenLvlCost > 1000)
						{
							MonsterDenLvlCost = roundValue(MonsterDenLvlCost, MonsterDenLvlCostBase, "down");
							MonsterDenLvlMaint = MonsterDenLvlCost / 10;
							getWarningLog = getFightLog = String.Format("\n*** Monster Den Rebuilt +{0:c0} Maint:{1:c0}", MonsterDenLvlCost, MaintCost);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getMonsterDenLvlMaint = roundValue(getMonsterDenLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Monster Den: {0} - cost {1:c0}", strMessage, MaintCost);
					break;
				case 249:
					int leavingTeam = RndVal.Next(2,(50+CurrentJackpotLvl));
					// team could leave if arena not doing well
					if (GameTeams.Count > leavingTeam && getScore() > (getGoalGameScore / 3))
					{
						getWarningLog = Environment.NewLine + "??? " + GameTeams[leavingTeam].getName + " has left the arena!";
						GameTeams.RemoveAt(leavingTeam);
						TeamCost = roundValue(TeamCost, TeamCostBase, "down");
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
			Robot defender = new Robot(0, "test", 1, false);
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
						if (eDefender.HP <= 0) attackers.addRune(eDefender.getLevel);
					}
				}
			}
			// attacking a single enemy
			else
			{
				defender.damage(attacker, currSkill);
				if (defender.HP <= 0) attackers.addRune(defender.getLevel);
			}
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
			Robot defender = new Robot(0, "test", 1, false);
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
	class Team : Common, IComparable<Team>
	{
		[JsonProperty]
		public List<Robot> MyTeam;
		[JsonProperty]
		public List<int> Runes;
		[JsonProperty]
		private int Score;
		private int ScoreLog;
		[JsonProperty]
		public int Win;
		[JsonProperty]
		private int GoalScore;
		[JsonProperty]
		private int GoalScoreBase;
		public int GoalScoreBaseIncrement = 25;
		[JsonProperty]
		private long Currency;
		private long CurrencyLog;
		[JsonProperty]
		private int Difficulty;
		private int DifficultyLog;
		[JsonProperty]
		private int MaxRobo;
		[JsonProperty]
		private long RoboCost;
		[JsonProperty]
		private long RoboCostBase;
		public long RoboCostBaseIncrement = 100;
		[JsonProperty]
		private string TeamName;
		public Boolean isMonster;
		[JsonProperty]
		public Boolean Automated;
		[JsonProperty]
		public Boolean PayForRepairs;
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
				if (value >= 0)
				{ 
					ScoreLog += value - Score;
					Score = value;
					if (Score >= GoalScore && !isMonster)
					{
						if (GoalScoreBase % 75 == 0)
						{
							MaxRobo++;
							getWarningLog = getFightLog = getTeamLog = String.Format("\n@{0} Score goal reached ({1:n0}) - Robot added! ", getName, GoalScore);
						}
						else if (GoalScoreBase % 50 == 0)
						{
							string strMsg = "";
							string strDelim = "";
							for (int i = 0; i < MyTeam.Count; i++)
							{
								for (int j = 0; j < 5; j++)
								{
									addRune((int)(MyTeam[i].getBaseStats() / 2), true);
								}
								strMsg += strDelim + (int)(MyTeam[i].getBaseStats() / 2);
								strDelim = ",";
							}
							getWarningLog = getFightLog = getTeamLog = String.Format("\n@{0} Score goal reached ({1:n0}) - Runes awarded to Rank(s): {2}! ", getName, GoalScore, strMsg);
						}
						else
						{
							getCurrency += GoalScore * getDifficulty;
							getWarningLog = getFightLog = getTeamLog = String.Format("\n@{0} Score goal reached ({1:n0}) - currency awarded {2:c0}! ", getName, GoalScore, GoalScore * getDifficulty);
						}
						roundValue(GoalScore, GoalScoreBase, "up");
						GoalScore += GoalScoreBase;
						GoalScoreBase += GoalScoreBaseIncrement;
					}
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
		public long getCurrency
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
		public long getRoboCost
		{
			get { return RoboCost; }
			set { RoboCost = value; }
		}
		public long getRoboCostBase
		{
			get { return RoboCostBase; }
			set { RoboCostBase = value; }
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

		public Team(int pScore, int pGoalScore, int pGoalScoreBase, int pWin, long pCurrency, int pDifficulty, int pMaxRobo, long pRoboCost, long pRoboCostBase, string pTeamName, bool pAutomated)
		{
			MyTeam = new List<Robot> { };
			Runes = new List<int> { 0 };
			Score = pScore;
			Currency = pCurrency;
			Difficulty = pDifficulty;
			GoalScore = pGoalScore;
			GoalScoreBase = pGoalScoreBase;
			MaxRobo = pMaxRobo;
			RoboCost = pRoboCost;
			RoboCostBase = pRoboCostBase;
			TeamName = pTeamName;
			isMonster = false;
			TeamName = pTeamName;
			TeamLog = "";
			Automated = pAutomated;
			Win = pWin;
			shownDefeated = false;
		}

		public Team(int baseStats, Game myGame)
        {
            MyTeam = new List<Robot> { new Robot(baseStats, myGame.setRoboName(), RndVal.Next(8), false) };
			Runes = new List<int> { 0 };
			Score = 0;
			Difficulty = 1;
            GoalScore = 25;
			GoalScoreBase = 25; 
			MaxRobo = 1;
			RoboCost = 200;
			RoboCostBase = 100;
			RoboCostBaseIncrement = 100;
			isMonster = false;
			TeamLog = "";
			Automated = true;
			PayForRepairs = true;
			Win = 0;
			TeamName = name1[RndVal.Next(name1.Length)] + " " + name3[RndVal.Next(name3.Length)];
			shownDefeated = false;
		}
		// Boss Monsters
		public Team(int numMonsters, int Difficulty, int MonsterLvl)
		{
			MyTeam = new List<Robot> { };
			Runes = new List<int> { 0 };
			for (int i = 0; i < numMonsters; i++)
			{
				int Monster = RndVal.Next(numMonsters);
				MyTeam.Add(new Robot(Difficulty, setName("boss", Monster), Monster, true));
				// Add equipment
				MyTeam[i].getEquipWeapon = new Equipment(true, MonsterLvl, 10000, RndVal, true);
				MyTeam[i].getEquipArmour = new Equipment(false, MonsterLvl, 10000, RndVal, true);
				for (int ii = 1; ii < MonsterLvl; ii++)
				{
					MyTeam[i].levelUp(RndVal, true);
					MyTeam[i].HP = MyTeam[i].getTHealth();
					MyTeam[i].MP = MyTeam[i].getTEnergy();
				}
			}
			resetLogs();
			Score = 0;
			GoalScore = 0;
			GoalScoreBase = 0;
			MaxRobo = 0;
			RoboCost = 0;
			RoboCostBase = 0;
			RoboCostBaseIncrement = 0;
			isMonster = true;
			TeamLog = "";
			Win = 0;
			TeamName = BossName[RndVal.Next(BossName.Length)] + " " + name2[RndVal.Next(name2.Length)];
			Automated = true;
			PayForRepairs = true;
			shownDefeated = false;
		}
		// Monster team
		public Team(int Difficulty, int MonsterLvl, int findMonster, ref Team MonsterOutbreak)
		{
			Double numMonsters = 1;
			int minLvl = 1;
			int maxLvl = 5;
			if (Difficulty < 0)
				Difficulty = 0;
			for (int i = 1; i < Difficulty; i++)
			{
				numMonsters += 0.5;
				minLvl += 4;
				maxLvl += 5;
			}
			MyTeam = new List<Robot> { };
			Runes = new List<int> { 0 };
			for (int i = 0; i < (int)(numMonsters); i++)
			{
				int Monster = RndVal.Next(MonsterLvl);
				List<Robot> tmpMon = new List<Robot> { };
				List<int> tmpindex = new List<int> { };
				tmpMon.Add( new Robot(Difficulty, setName("monster", Monster), Monster, true) );
				tmpindex.Add( -1);
				if (MonsterOutbreak != null)
				{
					for (int ii = 0; ii < MonsterOutbreak.MyTeam.Count; ii++)
					{
						if (MonsterOutbreak.MyTeam[ii].getLevel <= maxLvl && MonsterOutbreak.MyTeam[ii].getLevel >= minLvl )
						{
							tmpMon.Add(MonsterOutbreak.MyTeam[ii]);
							tmpindex.Add( ii);
						}
					}
				}
				int monster = RndVal.Next(tmpMon.Count);
				MyTeam.Add(tmpMon[monster]);
				if (tmpindex[monster] >= 0)
					MonsterOutbreak.MyTeam.RemoveAt(tmpindex[monster]);
				else
				{
					// Add equipment
					MyTeam[i].getEquipWeapon = new Equipment(true, RndVal.Next(1, maxLvl), RndVal.Next(100, (maxLvl + 100)), RndVal);
					MyTeam[i].getEquipWeapon.eName = "Claw";
					MyTeam[i].getEquipArmour = new Equipment(false, RndVal.Next(1, maxLvl), RndVal.Next(100, (maxLvl + 100)), RndVal);
					MyTeam[i].getEquipArmour.eName = "Hide";
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
			GoalScoreBase = 0;
			MaxRobo = 0;
			RoboCost = 0;
			RoboCostBase = 0;
			RoboCostBaseIncrement = 0;
			isMonster = true;
			TeamLog = "";
			TeamName = name1[RndVal.Next(name1.Length)] + " " + name2[RndVal.Next(name2.Length)];
			Automated = true;
			PayForRepairs = true;
			shownDefeated = false;
		}
		public string getRunes()
		{
			string retVal = "";
			if (Runes == null) Runes = new List<int> { 0 };
			for (int i = 0; i < Runes.Count; i++)
				retVal += string.Format(" {0}>{1}", i, Runes[i]);
			return retVal;
		}
		public int getRunes(int level, bool reset)
		{
			if (Runes == null) Runes = new List<int> { 0 };
			int runesCount = 0;
			int index = level / 2;
			if (Runes.Count > index)
			{
				runesCount = Runes[index];
				if (reset)
					Runes[index] = RndVal.Next(Runes[index]);
			}
			return runesCount;
		}
		public void addRune(int level, bool guaranteed = false)
		{
			if (Runes == null) Runes = new List<int> { 0 };
			int index = level / 10;
			while (Runes.Count <= index)
				Runes.Add(0);
			while (index >= 0 && !isMonster)
			{
				if (RndVal.Next(100) <= 1 || guaranteed)
				{
					Runes[index]++;
					// if we have 100 runes add to the next level
					if (Runes[index] >= 100)
					{
						Runes[index] = RndVal.Next(Runes[index]);
						addRune(level + 10, true);
					}
					else
					{
						getFightLog = String.Format("\n ^^^{0} received a rank {1} rune! ({2:n0})", getName, index, Runes[index], DateTime.Now.ToString());
					}
					index = -1;
				}
				else
					index--;
			}
		}
		public int CompareTo(Team team)
		{
			return this.getScore.CompareTo(team.getScore) * -1;
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
		public void changePayForRepairs()
		{
			PayForRepairs = !PayForRepairs;
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

		public string getTeamStats(int[] PadRight, long rebuildSavings, int KOCount, Game myGame, int roundCount = 0)
		{
			string strStats = ""; 
			// If this team is not in Team1 or Team1 list
			string strBuild = "";
			int counter = 0;
			int shownCounter = 0;
			int startCounter = 0;
			int maxRobos = 50;
			int aliveCount = 0;
			if (getName.Equals("Arena") || getName.Equals("Monster Outbreak") || getName.Contains("Game Diff"))
			{
				int maxStartCounter = MyTeam.Count - 10;
				if (maxStartCounter < 0) maxStartCounter = 0;
				startCounter = RndVal.Next(maxStartCounter);
				if (MyTeam[startCounter].getKO > KOCount) startCounter = 0;
				maxRobos = 10 + startCounter;
			}
			else if (roundCount > 0)
				maxRobos = (20) - roundCount;
			if (getAvailableRobo > 0)
				strBuild = "!";
			strStats = String.Format("{0} C:{1:n0}({2:n0}) W:{8:n0} S:{3:n0}{4}({5:n0}) D:{6:n0}({7:n0})",getName.PadRight(15).Substring(0,15), Currency, CurrencyLog, Score, strBuild, ScoreLog, Difficulty, DifficultyLog, Win);
			foreach (Robot eRobo in MyTeam)
			{
				// Add different robots...  
				if (counter < maxRobos && counter >= startCounter)
				{
					strStats += eRobo.getRoboStats(PadRight, myGame, this, rebuildSavings, Runes);
					if (eRobo.getKO <= KOCount)
					{
						counter++;
						aliveCount++;
					}
					shownCounter = 0;
				}
				else
				{
					char tmpSkill = '.';
					if (eRobo.cSkill != ' ') tmpSkill = eRobo.cSkill;
					eRobo.getRoboStats(PadRight, myGame, this, rebuildSavings, Runes);
					if (eRobo.getKO <= KOCount)
					{
						if (shownCounter == 0)
							strStats += Environment.NewLine + "->";
						if (shownCounter % 5 == 0)
							strStats += " ";
						strStats += tmpSkill;
						shownCounter++;
						aliveCount++;
					}
					counter++;

				}
			}
			if (aliveCount > 30) strStats += string.Format(" T:{0:n0}", aliveCount);
			return strStats;
		}
				
		public void fixTech()
		{
			foreach (Robot eRobo in MyTeam) eRobo.fixTech();
		}
		public void Rebuild(bool pay, Game myGame)
		{
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].rebuildCost(myGame.ResearchDevRebuild,Runes) >= 200)
					Rebuild(MyTeam[i], pay, myGame);
			}
		}
		public void Rebuild(Robot robo, bool pay, Game myGame)
		{
			int robotIndex = 0;
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].getName.Equals(robo.getName))
				{
					robotIndex = i;
				}
			}
			Rebuild(robotIndex, pay, myGame);
		}
		public int Rebuild(int robo, bool pay, Game myGame)
		{
			int bonusAnalysis = 0;
			if (!pay || MyTeam[robo].rebuildCost(myGame.ResearchDevRebuild,Runes) <= getCurrency)
			{
				long Cost = 0;
				if (pay)
				{
					Cost = MyTeam[robo].rebuildCost(myGame.ResearchDevRebuild, Runes);
					getCurrency -= Cost;
					MyTeam[robo].RebuildPercent++;
					if (MyTeam[robo].rebuildBonus > 0)
						MyTeam[robo].rebuildBonus--;
				}
				// current base stats
				int baseStats = MyTeam[robo].getBaseStats();
				int baseIncreased = 0;
				// only increase base stats if level is high enough
				if (baseStats < MyTeam[robo].getLevel / 5)
				{
					do
						baseStats++;
					while (RndVal.Next(100 + myGame.getResearchDevLvl) > 100);
					baseIncreased = baseStats - MyTeam[robo].getBaseStats();
				}
				string strName = MyTeam[robo].getName;
				bool bIsMonsterTmp = MyTeam[robo].bIsMonster;
				bool btmpMonster = MyTeam[robo].bMonster;
				Equipment weapon = MyTeam[robo].getEquipWeapon;
				Equipment armour = MyTeam[robo].getEquipArmour;
				int runesUsed = getRunes(MyTeam[robo].getBaseStats(), true);
				if (!pay || MyTeam[robo].RebuildPercent + runesUsed > RndVal.Next(100))
				{
					if (!pay) baseStats = baseStats / 2;
					MyTeam[robo] = new Robot(baseStats, "temp", RndVal.Next(8), false);
					MyTeam[robo].getName = strName;
					MyTeam[robo].bIsMonster = bIsMonsterTmp;
					MyTeam[robo].bMonster = btmpMonster;
					MyTeam[robo].getEquipWeapon = weapon;
					MyTeam[robo].getEquipArmour = armour;
					if (!MyTeam[robo].bIsMonster)
					{
						string strFormat = "\n +++ {0} : {1} has been rebuilt! Rank {2:n1} (+{3}B/{4}R)";
						if (Cost > 0) strFormat += " ic:{6:c0}";
						getTeamLog = getFightLog = getWarningLog = string.Format(strFormat, getName, MyTeam[robo].getName, (MyTeam[robo].getBaseStats() / 2.0), baseIncreased, runesUsed, DateTime.Now.ToString(), Cost);
					}
					else
					{
						string strFormat = "\n [M] {0} : {1} has ranked up! Rank {2:n1} (+{3}B) ";
						getFightLog = string.Format(strFormat, getName, MyTeam[robo].getName, (MyTeam[robo].getBaseStats() / 2.0), baseIncreased, DateTime.Now.ToString());
					}
				}
				else
				{
					bonusAnalysis = RndVal.Next((int)MyTeam[robo].RebuildPercent * 10);
					MyTeam[robo].getCurrentAnalysis += bonusAnalysis;
					if (!MyTeam[robo].bIsMonster)
					{
						string strFormat = "\n--- {0} : {1} failed the rebuild (+{2}A/{3}R)";
						if (Cost > 0) strFormat += " ic:{5:c0}";
						getTeamLog = getFightLog = getWarningLog = string.Format(strFormat, getName, MyTeam[robo].getName, bonusAnalysis, runesUsed, DateTime.Now.ToString(), Cost);
						MyTeam[robo].RebuildPercent += runesUsed;
					}
				}
			}
			return bonusAnalysis;
		}
		public int getNumRobos(bool pShowDefeated, int KOCount = 3)
		{
			int num = 0;
			foreach (Robot robo in MyTeam)
			{
				if (robo.HP > 0 || (pShowDefeated && robo.getKO <= KOCount))
					num++;
			}
			return num;
		}
		public Boolean healRobos(bool isBoss)
		{
			int beds = 0;
			int pay = 0;
			int value = MyTeam[RndVal.Next(MyTeam.Count)].getTHealth();
			return healRobos(ref beds, ref pay, value, isBoss);
		}
		public Boolean healRobos(ref int beds, ref int pay, int value, bool isBoss = false)
		{
			Boolean fullHP = true;
			Boolean bedUsed = false;
			for (int robo = MyTeam.Count-1; robo >= 0; robo--)
			{
				int cost = MyTeam[robo].getBaseStats() / 2;
				if (MyTeam[robo].HP < MyTeam[robo].getTHealth())
                {
                    if (getCurrency < cost || !PayForRepairs ||  beds == 0 || bedUsed || (MyTeam[robo].getTHealth() - MyTeam[robo].HP) < (value / 2))
					{
                        cost = 0;
                        value = RndVal.Next(value);
					}
					else
					{
						beds--;
						bedUsed = true;
					}
					pay = cost;
					getCurrency -= cost;
					CurrencyLog -= cost;
					MyTeam[robo].HP += value;
					MyTeam[robo].MP += value;
					MyTeam[robo].getKO = 0;
                }
                else if (MyTeam[robo].MP < MyTeam[robo].getTEnergy())
					MyTeam[robo].MP++;
				if (MyTeam[robo].HP < MyTeam[robo].getTHealth()) { fullHP = false; }
				// level up
				if (MyTeam[robo].getAnalysisLeft() <= 0)
				{
					MyTeam[robo].levelUp(RndVal, isBoss);
					if (MyTeam[robo].RobotLog.Length > 0 && !MyTeam[robo].name1.Equals("test"))
					{
						getTeamLog = MyTeam[robo].RobotLog;
						MyTeam[robo].RobotLog = "";
					}
				}
			}
			MyTeam.Sort();
			return fullHP;
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
		[JsonProperty]
		public long RoboRebuildCost;
		private int AnalysisLog;
		public string RobotLog;
		public char cSkill = ' ';
		public bool bMonster = false;
		public bool bIsMonster = false;
		public String getNameRank(Boolean includeName = true)
		{
			double rank = getBaseStats() / 2;
			string tmpName = "";
			if (includeName) tmpName = RobotName; 
			return String.Format("{0}.{1}",tmpName, rank);
		}
		public String getName
		{
			get 
			{
				if (RobotName.Length > 0) return RobotName;
				else return "[name]";
			}
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
		public int getBaseStats()
		{
			return (getDexterity + getStrength + getAgility + getTech + getAccuracy);
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
			string pImage, int pSpeed, int pLevel, int pAnalysis, int pCurrentAnalysis, long pRebuildCost)
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
			RebuildPercent = 0;
			RoboRebuildCost = pRebuildCost;
		}
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
				RoboRebuildCost = 0;
			}
			else
			{
				Image = RoboImages[imageIndex];
				//RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Lowest", "HP") };
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Current", "Level") };
				RoboRebuildCost = 2000;
				long RoboRebuildCostBase = 1000;
				for (int i = 0; iBasePoints > i; i++)
				{
					RoboRebuildCost = roundValue(RoboRebuildCost, RoboRebuildCostBase, "up");
					RoboRebuildCostBase += 1000;
				}
			}
			tmpImage = "";
			Dexterity = 0;
			Strength = 0;
			Agility = 0;
			Tech = 0;
			Accuracy = 0;
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
			Health = Dexterity + Strength + Agility + 1;
			Energy = Tech + Accuracy + 1;
			Armour = Dexterity + 1;
			Damage = Strength + 1;
			Hit = Accuracy + 1;
			Speed = Agility + 1;
			CurrentSpeed = 0;
			MentalStrength = Tech + 1;
			MentalDefense = Tech + 1;
			levelUp(RndVal);
			CurrentHealth = getTHealth();
			CurrentEnergy = getTEnergy();
			crit = false;
			dmg = 0;
			RebuildPercent = 0;			
		}

		public Robot DupeMonster()
		{
			Robot tmp = new Robot("." + MonsterName[RndVal.Next(MonsterName.Length)], Dexterity, Strength, Agility, Tech, Accuracy, Health, Energy, Armour, Damage, Hit, MentalStrength, MentalDefense, Image, Speed, Level, Analysis, 0, 0);
			foreach (Skill eSkill in ListSkills)
				tmp.ListSkills.Add(eSkill);
			foreach (Strategy eStrategy in RoboStrategy)
				tmp.RoboStrategy.Add(eStrategy);
			return tmp;
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
		{ }

		public void resetLog()
		{
			LevelLog = 0;
			AnalysisLog = 0;
		}

		public string getRoboStats(int[] PadRight, Game myGame, Team myTeam, long rebuildSavings, List<int> Runes)
		{
			char cRebuild = ' ';
			string strStats = "";
			string strMsg = "";
			if (HP == 0)
				getKO++;
			if (rebuildCost(rebuildSavings, Runes) != 100 && !bIsMonster)
			{
				if (rebuildCost(rebuildSavings, Runes) > myTeam.getCurrency)
					cRebuild = '|'; 
				else if (myGame.getGameCurrency > 0)
					cRebuild = '+';
				else
					cRebuild = '/';
			}
			if (dmg > 0)
			{
				strMsg = string.Format(" {0:n0} dmg", dmg);
				if (crit) strMsg += "!";
				dmg = 0;
				crit = false;
			}
			if (getKO <= 3)
				strStats = string.Format("\n{0}{1}{2} L:{3}({4}) A:{5} MP:{6} HP:{7}{8} ",cRebuild, cSkill, 
					getNameRank().PadRight(PadRight[0]),
					String.Format("{0:n0}", getLevel).PadLeft(PadRight[1]),
					String.Format("{0:n0}", LevelLog).PadLeft(PadRight[2]),
					String.Format("{0:n0}", getAnalysisLeft()).PadLeft(PadRight[3]),
					String.Format("{0:n0}", MP).PadLeft(PadRight[4]), 
					String.Format("{0:n0}", HP).PadLeft(PadRight[5]), 
					strMsg);

			cSkill = ' ';
			return strStats;
		}
		public double rebuildSavings(List<int> runes)
		{
			int percent = 100;
			int stats = (Dexterity + Strength + Agility + Tech + Accuracy);
			//getFightLog = string.Format("runes.Count {0} > stats {1}", runes.Count, stats);
			if (runes.Count > stats / 2) percent -= runes[stats / 2];
			return percent/100.0;
		}
		public long rebuildCost(long ResearchDevRebuild, List<int> runes)
		{
			long cost = 100;
			int stats = (Dexterity + Strength + Agility + Tech + Accuracy);
			// if base stats will go up add cost
			if (Level / 5 > stats )
			{
				if (rebuildBonus > 0)
					cost = 200;
				else
					cost = (int)((RoboRebuildCost - ResearchDevRebuild) * rebuildSavings(runes));
				if (cost <= 200) cost = 200;
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
		private void randomStat()
		{
			int tmp = RndVal.Next(8);
			switch (tmp)
			{
				case 0:
					Health++;
					break;
				case 1:
					Energy++;
					break;
				case 2:
					Armour++;
					break;
				case 3:
					Damage++;
					break;
				case 4:
					Hit++;
					break;
				case 5:
					Speed++;
					break;
				case 6:
					MentalStrength++;
					break;
				case 7:
					MentalDefense++;
					break;
			}
		}
		public void levelUp(Random tmp, bool isBoss = false)
		{
			LevelLog++;
			Level++;
			Analysis += 5;
			AnalysisLog = 0;
			CurrentAnalysis = 0;
			if (isBoss) Health += ((Dexterity + Strength + Agility) * 10);
			else Health += Dexterity + Strength + Agility;
			if (isBoss) Energy += (Tech * 10);
			else Energy += Tech;
			Armour += Dexterity;
			Damage += Strength;
			Hit += Accuracy;
			Speed += Agility;
			MentalStrength += Tech;
			MentalDefense += Tech; 
			randomStat();
			RobotLog = Environment.NewLine + getName + " reached level " + getLevel;
			if (Level % 3 != 0 && ListSkills.Count >= 1) // new skills every 3 levels
			{
				Skill upSkill = ListSkills[tmp.Next(ListSkills.Count)];
				if (upSkill.cost == 0)
					upSkill.strength++;
				// others add ten percent but also add an extra cost if they can afford it. 
				else if (upSkill.cost < Energy)
				{
					int cycle = 0;
					while (cycle < RndVal.Next(100) && upSkill.cost < Energy)
					{
						upSkill.strength += 10;
						upSkill.cost++;
						cycle += RndVal.Next(10);
					}
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
						int cycle = 0;
						while (cycle < RndVal.Next(100))
						{
							// attack just add one percent
							if (eSkill.cost == 0)
								eSkill.strength++;
							// others add ten percent but also add an extra cost if they can afford it. 
							else if (eSkill.cost < Energy)
							{
								eSkill.strength += 10;
								eSkill.cost++;
							}
							cycle += RndVal.Next(10);
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
				setMiss();
			// damaged
			else
			{
				int minDmg = 0;
				int maxDmg = 0;
				string strCrit = "";
				// if armour greater than hit attack is blocked
				if (RndVal.Next(getTArmour()) > RndVal.Next(attacker.getTHit()) && !critical
					&& (currSkill.type.Equals("Single attack") || currSkill.type.Equals("Multiple attack")))
				{
					setBlock();
					minDmg = 1;
					maxDmg = attacker.getTDamage() / 10;
					if (currSkill.type.Equals("Multiple attack"))
					{
						if (maxDmg > 10) maxDmg = maxDmg / 10;
						if (minDmg > 10) minDmg = minDmg / 10;
					}
				}
				// if tech defense greater than tech attack attack is blocked
				else if (RndVal.Next(getTMentalDefense()) > RndVal.Next(attacker.getTHit()) && !critical
					&& (currSkill.type.Equals("Single tech") || currSkill.type.Equals("Multiple tech")))
				{
					setField();
					minDmg = 1;
					maxDmg = attacker.getTMentalStrength() / 10;
					if (currSkill.type.Equals("Multiple tech"))
					{
						if (maxDmg > 10) maxDmg = maxDmg / 10;
						if (minDmg > 10) minDmg = minDmg / 10;
					}
				}
				else
				{
					setHurt();

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
						if (currSkill.type.Equals("Multiple attack"))
						{
							if (maxDmg > 10) maxDmg = maxDmg / 10;
							if (minDmg > 10) minDmg = minDmg / 10;
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
						if (currSkill.type.Equals("Multiple tech"))
						{
							if (maxDmg > 10) maxDmg = maxDmg / 10;
							if (minDmg > 10) minDmg = minDmg / 10;
						}
					}
				}
				if (minDmg > maxDmg) maxDmg = minDmg;
				int tmpDmg = (RndVal.Next(minDmg, maxDmg + currSkill.strength));
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
								getFightLog = string.Format("\n--- {0} {1} broke! ({2:n0})", getName, EquipArmour.eName, EquipArmour.eMaxDurability);
								if (EquipArmour.eMaxDurability > 100)
									getWarningLog = string.Format("\n--- {0} {1} broke! ({2:n0}) ", getName, EquipArmour.eName, EquipArmour.eMaxDurability, DateTime.Now.ToString());
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
								getFightLog = string.Format("\n--- {0} {1} broke! ({2:n0})", attacker.getName, attacker.EquipWeapon.eName, attacker.EquipWeapon.eMaxDurability);
								if (attacker.EquipWeapon.eMaxDurability > 100)
									getWarningLog = (string.Format("\n--- {0} {1} broke! ({2:n0}) ", attacker.getName, attacker.EquipWeapon.eName, attacker.EquipWeapon.eMaxDurability, DateTime.Now.ToString()));
							}
							attacker.EquipWeapon = null;
							if (attacker.HP > attacker.getTHealth()) attacker.HP = attacker.getTHealth();
							if (attacker.MP > attacker.getTEnergy()) attacker.MP = attacker.getTEnergy();
						}
					}
					// get experience if attackers level is not higher
					if (attacker.getLevel <= getLevel)
					{
						attacker.getCurrentAnalysis += getLevel - attacker.getLevel + 1;
						if (HP == 0) { attacker.getCurrentAnalysis += 10;}
					}
					// if attacker is higher level, get less exp
					else if (RndVal.Next(100) > 80)
						attacker.getCurrentAnalysis++;
				}
			}
		}
		public int getMaxLevel() { return (Dexterity + Strength + Agility + Tech + Accuracy + 1) * 5; }

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
			// Display Character info
			if (EquipWeapon != null)
			{
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
				aHealth = EquipArmour.eHealth;
				aEnergy = EquipArmour.eEnergy;
				aArmour = EquipArmour.eArmour;
				aDamage = EquipArmour.eDamage;
				aHit = EquipArmour.eHit;
				aSpeed = EquipArmour.eSpeed;
				aMentalStr = EquipArmour.eMentalStrength;
				aMentalDef = EquipArmour.eMentalDefense;
			}
			// get Padding Required
			int sPadding = 1;
			foreach (Strategy eStrategy in RoboStrategy)
			{
				if (sPadding < string.Format("{0:n0}", eStrategy.StrategicSkill.cost).Length)
					sPadding = string.Format("{0:n0}", eStrategy.StrategicSkill.cost).Length;
			}
			int[] cPadding = { getMaxLength( new string[] { String.Format("{0:n0}", HP), String.Format("{0:n0}", MP), String.Format("{0:n0}", getTArmour()), String.Format("{0:n0}", getTDamage()), String.Format("{0:n0}", getTHit()), String.Format("{0:n0}", getTSpeed()), String.Format("{0:n0}", getTMentalStrength()), String.Format("{0:n0}", getTMentalDefense()) })
					, getMaxLength( new string[] { String.Format("{0:n0}", getTHealth()), String.Format("{0:n0}", getTEnergy()) } )
					, getMaxLength( new string[] { String.Format("{0:n0}", Health), String.Format("{0:n0}", Energy), String.Format("{0:n0}", Armour), String.Format("{0:n0}", Damage), String.Format("{0:n0}", Hit), String.Format("{0:n0}", Speed), String.Format("{0:n0}", MentalStrength), String.Format("{0:n0}", MentalDefense) } )
					, getMaxLength( new string[] { String.Format("{0:n0}", wHealth), String.Format("{0:n0}", wEnergy), String.Format("{0:n0}", wArmour), String.Format("{0:n0}", wDamage), String.Format("{0:n0}", wHit), String.Format("{0:n0}", wSpeed), String.Format("{0:n0}", wMentalStr), String.Format("{0:n0}", wMentalDef) } )
					, getMaxLength( new string[] { String.Format("{0:n0}", aHealth), String.Format("{0:n0}", aEnergy), String.Format("{0:n0}", aArmour), String.Format("{0:n0}", aDamage), String.Format("{0:n0}", aHit), String.Format("{0:n0}", aSpeed), String.Format("{0:n0}", aMentalStr), String.Format("{0:n0}", aMentalDef) } )
				};
			tmp += ("*Base Stats*\n");
			tmp += string.Format("{0,-10}{1}/{2}\n", "Level", Level, getMaxLevel());
			tmp += string.Format("{0,-10}{1}\n", "Rank", (Dexterity + Strength + Agility + Tech + Accuracy) / 2.0);
			tmp += string.Format("{0,-10}{1}\n", "Dexterity", Dexterity);
			tmp += string.Format("{0,-10}{1}\n", "Strength", Strength);
			tmp += string.Format("{0,-10}{1}\n", "Agility", Agility);
			tmp += string.Format("{0,-10}{1}\n", "Tech", Tech);
			tmp += string.Format("{0,-10}{1}\n", "Accuracy", Accuracy);
			tmp += ("*Elevated Stats*\n");
			
			tmp += string.Format("{0,-10}{1," + (cPadding[0]) + ":n0}/{2," + (cPadding[1]) + ":n0} {3," + cPadding[2] + ":n0}+{4," + cPadding[3] + ":n0}+{5," + cPadding[4] + ":n0}\n", "Health", HP, getTHealth(), Health, wHealth, aHealth);
			tmp += string.Format("{0,-10}{1," + (cPadding[0]) + ":n0}/{2," + (cPadding[1]) + ":n0} {3," + cPadding[2] + ":n0}+{4," + cPadding[3] + ":n0}+{5," + cPadding[4] + ":n0}\n", "Energy", MP, getTEnergy(), Energy, wEnergy, aEnergy);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "Armour", getTArmour(), Armour, wArmour, aArmour);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "Damage", getTDamage(), Damage, wDamage, aDamage);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "Hit", getTHit(), Hit, wHit, aHit);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "Speed", getTSpeed(), Speed, wSpeed, aSpeed);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "MentalStr", getTMentalStrength(), MentalStrength, wMentalStr, aMentalStr);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}+{4," + cPadding[4] + ":n0}\n", "MentalDef", getTMentalDefense(), MentalDefense, wMentalDef, aMentalDef);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "}\n", "Analysis", getAnalysisLeft());
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "}\n", "Rebuild %", RebuildPercent);
			tmp += "-----\n";
			foreach (Strategy eStrategy in RoboStrategy)
			{
				tmp += (String.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2,-" + (sPadding+1) + ":n0}+{3:n0}\n", eStrategy.StrategicSkill.name, eStrategy.StrategicSkill.sChar, eStrategy.StrategicSkill.cost, eStrategy.StrategicSkill.strength));
			}
			if (EquipWeapon != null)
			{
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n  {4:c0}\n", EquipWeapon.eDurability, EquipWeapon.eMaxDurability, EquipWeapon.eName, EquipWeapon.eUpgrade, EquipWeapon.eUpgradeCost);
			}
			else
				tmp += "<Unequiped>\n";
			if (EquipArmour != null)
			{
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n  {4:c0}\n", EquipArmour.eDurability, EquipArmour.eMaxDurability, EquipArmour.eName, EquipArmour.eUpgrade, getEquipArmour.eUpgradeCost);
			}
			else
				tmp += "<Unequiped>\n";
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
		[JsonProperty]
		public int AmountBase; // Number of seats
		public int Attendees; 
		public ArenaSeating() { }
		public ArenaSeating(int pLevel, int pPrice, int pAmount, int pAmountBase)
		{
			Level = pLevel;
			Price = pPrice;
			Amount = pAmount;
			AmountBase = pAmountBase;
			Attendees = 0;
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
		public long ePrice = 0;
		[JsonProperty]
		public int eDurability = 0;
		[JsonProperty]
		public int eMaxDurability = 0;
		[JsonProperty]
		public long eUpgradeCost = 0;
		[JsonProperty]
		public long eUpgradeCostBase = 0;
		[JsonProperty]
		public long eUpgradeCostBaseIncrement = 0;
		public Equipment(bool addWeapon, int value, int durability, Random RndVal, Boolean isBoss = false, int upgradeCost = 10)
		{
			int Type = 0;
			if (addWeapon)
			{
				if (isBoss) Type = RndVal.Next(1, 4);
				else Type = RndVal.Next(1, 5);
			}
			else
			{
				if (isBoss) Type = RndVal.Next(5, 8);
				else Type = RndVal.Next(5, 9);
			}
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
			ePrice = (value * 10) + durability;
			eUpgradeCost = eUpgradeCostBase = upgradeCost;
			eUpgradeCostBaseIncrement = (int)(upgradeCost * 0.75);
		}
		public Equipment(string pType, string pName, int pHealth, int pEnergy, int pArmour, int pDamage, int pHit, int pMentalStrength, int pMentalDefense, int pSpeed, long pPrice, 
			int pDurability, int pMaxDurability, long pUpgradeCost, long pUpgradeCostBase, long pUpgradeCostBaseIncrement, int pUpgrade)
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
			eUpgradeCostBase = pUpgradeCostBase;
			eUpgradeCostBaseIncrement = pUpgradeCostBaseIncrement;
			eUpgrade = pUpgrade;
		}
		public void upgrade(int value, Random RndVal)
		{
			int Type = RndVal.Next(1, 9);
			eMaxDurability += value;
			eDurability = eMaxDurability;
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
			eUpgradeCost = roundValue(eUpgradeCost, eUpgradeCostBase, "up");
			eUpgradeCostBase += eUpgradeCostBaseIncrement;
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
