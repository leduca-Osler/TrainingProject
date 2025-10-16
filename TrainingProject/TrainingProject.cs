using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TrainingProject
{
	[Serializable]
	class Common
	{
		public static readonly Random RndVal = new Random();
		public static string WarningLog;
		public static string FightLog;
		public static string WinLog;
		public static string ImagePath = "Resources\\";
		public string[] RoboImages = {
			"Robo1.jpg",
			"Robo2.jpg",
			"Robo3.jpg",
			"Robo4.jpg",
			"Robo5.jpg",
			"Robo6.jpg",
			"Robo7.jpg",
			"Robo8.jpg",
			"Robo9.jpg"
		};
		public string[] MonsterImages = {
			"Monster1.png", "Monster2.png", "Monster3.png", "Monster4.png", "Monster5.png", "Monster6.png", "Monster7.png", "Monster8.png", "Monster9.png", // Rank 1
			"Monster1.png", "Monster2.png", "Monster3.png", "Monster4.png", "Monster5.png", "Monster6.png", "Monster7.png", "Monster8.png", "Monster9.png", // Rank 2
			"Monster1.png", "Monster2.png", "Monster3.png", "Monster4.png", "Monster5.png", "Monster6.png", "Monster7.png", "Monster8.png", "Monster9.png", // Rank 3
			"Monster1.png", "Monster2.png", "Monster3.png", "Monster4.png", "Monster5.png", "Monster6.png", "Monster7.png", "Monster8.png", "Monster9.png", // Rank 4
			"Monster1.png", "Monster2.png", "Monster3.png", "Monster4.png", "Monster5.png", "Monster6.png", "Monster7.png", "Monster8.png", "Monster9.png" // Rank 6
		};
		public string[] MonsterName = {
			"Devil 1", "Alien 1", "Slither 1", "Blob 1", "Bat 1", "Titan 1", "Chomp 1", "Element 1", "HandEye 1", // Rank 1
			"Devil 2", "Alien 2", "Slither 2", "Blob 2", "Bat 2", "Titan 2", "Chomp 2", "Element 2", "HandEye 2", // Rank 2
			"Devil 3", "Alien 3", "Slither 3", "Blob 3", "Bat 3", "Titan 3", "Chomp 3", "Element 3", "HandEye 3", // Rank 3
			"Devil 4", "Alien 4", "Slither 4", "Blob 4", "Bat 4", "Titan 4", "Chomp 4", "Element 4", "HandEye 4", // Rank 4
			"Devil 5", "Alien 5", "Slither 5", "Blob 5", "Bat 5", "Titan 5", "Chomp 5", "Element 5", "HandEye 5", // Rank 5
			"Devil 6", "Alien 6", "Slither 6", "Blob 6", "Bat 6", "Titan 6", "Chomp 6", "Element 6", "HandEye 6" // Rank 6
		};
		public string[] ConcessionName = { "Hotdog", "Hamburger", "Pretzel", "Donut", "Juice", "Coffee", "Boba", "Taco", "Ice Cream" };
		public static string strike = "Strike.jpg";
		public static string pound = "Pound.jpg";
		public static string scratch = "Pound.jpg"; 
		public static string shrapnel = "Shrapnel.png";
		public static string slash = "Pound.jpg"; 
		public static string Electrode = "Electrode.png"; //
		public static string elements = "Pound.jpg"; // 
		public static string Laser = "Laser.png"; // 
		public static string corosion = "Pound.jpg"; 
		public static string hurt = "Hurt.png";
		public static string KO = "KO.jpg";
		public static string miss = "dodge.png";
		public static string blocked = "block.png";
		public static string field = "ForceField.png"; // 
		public static Skill[] AllSkills = {
			new Skill("Attack", "Enemy", 0, "Single attack", 0, ImagePath + strike, '*'),
			new Skill("Pound", "Enemy", 10, "Single attack", 2, ImagePath + pound, '#'),
			new Skill("Shrapnel", "Enemy", 1, "Multiple attack", 3, ImagePath + shrapnel, '%'),
			new Skill("Electrode", "Enemy", 10, "Single tech", 2, ImagePath + Electrode, '@'),
			new Skill("Laser", "Enemy", 1, "Multiple tech", 3, ImagePath + Laser, '^')
		};
		public static Skill[] MonsterSkills = {
			new Skill("Attack", "Enemy", 0, "Single attack", 0, ImagePath + strike, '*'),
			new Skill("Scratch", "Enemy", 10, "Single attack", 2, ImagePath + scratch, '#'),
			new Skill("Slash", "Enemy", 1, "Multiple attack", 3, ImagePath + slash, '%'),
			new Skill("Elements", "Enemy", 10, "Single tech", 2, ImagePath + elements, '@'),
			new Skill("Corosion", "Enemy", 1, "Multiple tech", 3, ImagePath + corosion, '^')
		};
		public string[] name1 = {
				"Ageless", "Blue", "Chilly", "Dashing", "Electric", "Famous", "Great", "Huge", "Irate",
				"Jesting","Keen", "Lethal", "Malefic", "Nasty", "Orange", "Pink", "Quirky", "Resourceful", "Strong", "Thorny",
				"Ugly", "Vast", "Wise", "Xanthic", "Yellow", "Zoic", "Bald", "Beaut", "Chubby", "Clean",
				"Dazzling", "Drab", "Elegant", "Fancy", "Fit", "Flabby", "Glam", "Gorg", "Handsome", "Long", "Magnif",
				"Muscular", "Plain", "Plump", "Quaint", "Scruffy", "Shapely", "Short", "Skinny", "Stocky", "Ugly", "Unkempt",
				"Unsightly", "Ashy", "Black", "Blue", "Gray", "Green", "Icy", "Lemon", "Mango","Orange", "Purple", "Red","Salmon",
				"White","Yellow","Alive","Better","Careful","Clever","Dead","Easy","Famous","Gifted","Hallowed","Helpful","Important",
				"Mealy","Mushy","Odd","Poor","Powerful","Rich","Shy","Tender","Vast","Wrong",
				"Agreeable","Ambitious","Brave","Calm","Delightful","Eager","Faithful","Gentle","Happy","Jolly","Kind",
				"Lively","Nice","Obedient","Polite","Proud","Silly","Thankful","Victorious","Witty","Wonderful","Zealous","Angry",
				"Bewildered","Clumsy","Fierce","Grumpy","Helpless","Itchy","Jealous","Lazy","Mysterious",
				"Nervous","Obnoxious","Panicky","Pitiful","Repulsive","Scary","Thoughtless","Uptight","Worried","Broad","Chubby","Crooked",
				"Curved","Deep","Flat","High","Hollow","Low","Narrow","Refined","Round","Shallow","Skinny","Square","Steep","Straight",
				"Wide"};
		public string[] name2 = { "Sharks", "Octopuses", "Birds", "Foxes", "Wolfs", "Lions", "Rinos", "Tigers", "Hyenas", "Vulturs" };
		public string[] name3 = { "Blade", "Arrow", "Spark", "Factory", "Sniper", "Calvary", "Spear", "War Cythe", "Nunchuku", "Riffle", "Pistol", "War Hammer", "Battle Axe", "Bludgeon", "Club", "Flail", "Mace", "Morning Star", "Quarterstaff", "Dagger", "Falchion", "Estoc", "Katana", "Longsword", "Rapier", "Saber", "Shortsword", "Glaive", "Halberd", "Lance", "Partisan", "Pike", "Voulge", "Longbow", "Recurve Bow", "Crossbow", "Musket", "Chakram", "Kunai", "Shuriken"};
		public string[] RoboName = { "Cyborg", "Repair", "Guard", "Golem", "Droid", "Tank", "Gundam", "ATV", "Concept" };
		public string[] BossName = { "Great", "Estemed", "Grand", "Large", "Strong", "Fast", "Tyrant"};
		public string getWinLog
		{
			set
			{
				if (WinLog == null) WinLog = "";
				WinLog = value;
			}
			get
			{
				if (WinLog == null) WinLog = "";
				return WinLog;
			}
		}
		public string getWarningLog
		{
			set
			{
				if (WarningLog == null) WarningLog = "";
				if (WarningLog.Length > 5000)
					WarningLog = value + WarningLog.Substring(0, 4900);
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
					FightLog = value + FightLog.Substring(0, 9900);
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
		public void clearWinns()
		{
			WinLog = "";
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
		public long roundValue(double value, int digit = 2)
		{
			long power = (long)Math.Pow(10, value.ToString().Length - digit);
			long returnValue = (long)Math.Round((double)(value) / power) * power;
			if (returnValue.ToString().Substring(0, 1).Equals("8") && digit == 1)
			{
				power = (long)Math.Pow(10, value.ToString().Length);
				returnValue = (long)Math.Round((double)(value) / power) * power;
			}
			return returnValue;
		}

		public long roundValue(long value, int digit = 2)
		{
			long power = (long)Math.Pow(10, value.ToString().Length - digit);
			long returnValue = (long)Math.Round((double)(value) / power) * power;
			if (returnValue.ToString().Substring(0, 1).Equals("8") && digit == 1)
			{
				power = (long)Math.Pow(10, value.ToString().Length);
				returnValue = (long)Math.Round((double)(value) / power) * power;
			}
			return returnValue;
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
		public static string ToAlphaNumeric(int number)
		{
			if (number < 0) return string.Empty;
			if (number >= 1296) return returnAlphaChar(number / 1296) + ToAlphaNumeric(number - ((int)(number / 1296) * 1296));
			if (number >= 36) return returnAlphaChar(number / 36) + ToAlphaNumeric(number - ((int)(number / 36) * 36));
			else return returnAlphaChar(number);
			throw new ArgumentOutOfRangeException("something bad happened");
		}
		public static string returnAlphaChar(int number)
		{
			string retval = number.ToString();
			switch (number)
			{
				case 10:
					retval = "A"; break;
				case 11:
					retval = "B"; break;
				case 12:
					retval = "C"; break;
				case 13:
					retval = "D"; break;
				case 14:
					retval = "E"; break;
				case 15:
					retval = "F"; break;
				case 16:
					retval = "G"; break;
				case 17:
					retval = "H"; break;
				case 18:
					retval = "I"; break;
				case 19:
					retval = "J"; break;
				case 20:
					retval = "K"; break;
				case 21:
					retval = "L"; break;
				case 22:
					retval = "M"; break;
				case 23:
					retval = "N"; break;
				case 24:
					retval = "O"; break;
				case 25:
					retval = "P"; break;
				case 26:
					retval = "Q"; break;
				case 27:
					retval = "R"; break;
				case 28:
					retval = "S"; break;
				case 29:
					retval = "T"; break;
				case 30:
					retval = "U"; break;
				case 31:
					retval = "V"; break;
				case 32:
					retval = "W"; break;
				case 33:
					retval = "X"; break;
				case 34:
					retval = "Y"; break;
				case 35:
					retval = "Z"; break;
			}
			return retval;
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
	class Game : Common
	{
		[NonSerialized]
		public System.Windows.Forms.FlowLayoutPanel MainFormPanel;
		public List<Team> GameTeams;
		public IList<ArenaSeating> Seating;
		public IList<ArenaSeating> CurrentSeating;
		public IList<int> seatingAvailable;
		public List<Equipment> storeEquipment;
		public IList<Team> GameTeam1;
		public IList<Team> GameTeam2;
		public IList<Concession> ConcessionStands;
		public List<KeyValuePair<String, DateTime>> countdown;
		public Team MonsterOutbreak;
		public Team Bosses;
		public string fightLogSave;
		public string warningLogSave;
		public string winLogSave;
		private int RoboNumeral;
		private int maxRoboNumeral;
		private char RoboNumeralChar;
		private int findMonster;
		private int Numeral;
		private int maxNumeral;
		private char NumeralChar;
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
		public int ExtraInterval;
		public int ExtraIntervalPercent;
		public int MaxExtraIntervalPercent;
		public int MaxInterval;
		public int FightBreak;
		public int FightBreakCount;
		public DateTime SafeTime;
		public DateTime BreakTime;
		public DateTime DisplayTime;
		public double repairPercent;
		public int maxManagerHours;
		public bool PurchaseUpgrade;
		public string debugMsg;
		private int GoalGameScore;
		private int MaxRobo;
		private long LifetimeGameScore;
		private long GoalLifetimeGameScore;
		private long LifetimeTeams;
		private long GoalLifetimeTeams;
		private long LifetimeRevenue;
		private long GoalLifetimeRevenue;
		private long LifetimeEquipmentForged;
		private long GoalLifetimeEquipmentForged;
		private int GoalGameScoreBase;
		private int GoalGameScoreBaseIncrement = 100;
		public int gameDifficulty;
		private int MaxTeams;
		private long TeamCost;
		private long TeamCostBase;
		private long TeamCostBaseIncrement = 1000;
		private long Jackpot; // holds the credits to be divied out after a fight
		private long GameCurrency;
		public long GameCurrencyLogMaint;
		public long GameCurrencyLogUp;
		public long GameCurrencyLogMisc;
		private Boolean fighting;
		private Boolean auto;
		private int ShopLvl;
		private long ShopLvlCost;
		public long MainLvlCostBase;
		public long MainLvlCostBaseIncrement = 1000;
		private long ShopLvlMaint;
		private long ShopLvlMaintCondition;
		private int ShopStock;
		private int ShopBays;
		private long ShopStockCost;
		private int ShopMaxStat;
		private int ShopMaxDurability;
		private int ShopUpgradeValue;
		private int ArenaLvl;
		private long ArenaLvlCost;
		private long ArenaLvlMaint;
		private long ArenaLvlMaintCondition;
		private long ArenaComunityReach;
		private int ConcessionLvl;
		private long ConcessionLvlCost;
		private long ConcessionLvlMaint;
		private long ConcessionLvlMaintCondition;
		private double ConcessionMarkup;
		public int MonsterDenLvl;
		private long MonsterDenLvlCost;
		private long MonsterDenLvlMaint;
		private long MonsterDenLvlMaintCondition;
		private int MonsterDenBonus;
		public long MonsterDenRepairs;
		public long MonsterDenRepairsBase;
		public long MonsterDenRepairsBaseIncrement = 100;
		private int ResearchDevLvl;
		private long ResearchDevLvlCost;
		private long ResearchDevMaint;
		private long ResearchDevLvlMaintCondition;
		private int ResearchDevHealValue;
		private int ResearchDevHealValueSum;
		public int ResearchDevHealValueBase;
		public int ResearchDevHealValueBaseIncrement = 1;
		private int ResearchDevHealBays;
		public long ResearchDevRebuild;
		public long ResearchDevRebuildBase;
		public long ResearchDevRebuildBaseIncrement = 25;
		private int BossLvl;
		public long BossLvlBase;
		public long BossLvlBaseIncrement = 5;
		private int BossCount;
		private int BossDifficulty;
		public int BossDifficultyBase;
		public int BossDifficultyBaseIncrement = 2;
		public int CurrentJackpot;
		public int CurrentJackpotLvl;
		public int MinWage;
		public int CurrentJackpotBase;
		public int CurrentJackpotBaseIncrement;
		public long MaxJackpot;
		public Boolean JackpotUpDown;
		public int JackpotMovement;
		public Boolean StartForge;
		public Boolean StartRestock;
		public Boolean RobotPriority;
		public Boolean paused;
		private long BossReward;
		public int roundCount;
		public bool bossFight;
		public bool GameDifficultyFight;
		public bool GameDifficultyFightPaused;
		public int WinCount;
		public int FastForwardCount;
		public bool FastForward;
		public long totalRev;
		public int totalRevCount;
		public int DiffLosses;
		public int bossLosses;
		public int NeedAdvertising; 
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
			if (MonsterDenLvl > MonsterImages.Length)
			{
				return MonsterImages.Length - 1; // Max number of Monster images
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
			get { return MonsterDenLvlMaint - MonsterDenRepairs; }
			set { MonsterDenLvlMaint = value; }
		}
		public long getMonsterDenLvlMaintCondition
		{
			get { return 100 - MonsterDenLvlMaintCondition; }
			set { MonsterDenLvlMaintCondition = value; }
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
		public long getConcessionLvlCost
		{
			get { return ConcessionLvlCost; }
			set { ConcessionLvlCost = value; }
		}
		public long getArenaLvlMaint
		{
			get { return ArenaLvlMaint - MonsterDenRepairs; }
			set { ArenaLvlMaint = value; }
		}
		public long getArenaLvlMaintCondition
		{
			get { return 100 - ArenaLvlMaintCondition; }
			set { ArenaLvlMaintCondition = value; }
		}
		public long getConcessionLvlMaint
		{
			get { return ConcessionLvlMaint - MonsterDenRepairs; }
			set { ConcessionLvlMaint = value; }
		}
		public long getConcessionLvlMaintCondition
		{
			get { return 100 - ConcessionLvlMaintCondition; }
			set { ConcessionLvlMaintCondition = value; }
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
			get { return ShopLvlMaint - MonsterDenRepairs; }
			set { ShopLvlMaint = value; }
		}
		public long getShopLvlMaintCondition
		{
			get { return 100 - ShopLvlMaintCondition; }
			set { ShopLvlMaintCondition = value; }
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
			get { return ResearchDevMaint - MonsterDenRepairs; }
			set { ResearchDevMaint = value; }
		}
		public long getResearchDevLvlMaintCondition
		{
			get { return 100 - ResearchDevLvlMaintCondition; }
			set { ResearchDevLvlMaintCondition = value; }
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
				return MaxTeams - GameTeams.Count;
			}
			set { MaxTeams = value; }
		}
		public double getConcessionStock
		{
			get
			{
				long MaxStock = 0, CurrentStock = 0;
				if (ConcessionStands != null)
				{
					foreach (Concession eConcession in ConcessionStands)
					{
						MaxStock += eConcession.MaxStock;
						CurrentStock += eConcession.CurrentStock;
					}
				}
				return ((double)CurrentStock / (double)MaxStock);
			}
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
					if (NumeralChar.Equals('.')) 
						NumeralChar = ':';
					else
						NumeralChar = '.';
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
					if (RoboNumeralChar.Equals('.'))
						RoboNumeralChar = ':';
					else
						RoboNumeralChar = '.';
				}
				else
					RoboNumeral = value;
			}
		}
		public Game(int pGoalGameScore, int pGoalGameScoreBase, int pMaxTeams, int pMaxRobo, long pTeamCost, long pTeamCostBase, long pGameCurrency, int pArenaLvl, long pArenaLvlCost,
			long pArenaLvlCostBase, long pArenaLvlMaint, long pArenaComunityReach, int pMonsterDenLvl, long pMonsterDenLvlCost, long pMonsterDenLvlCostBase, long pMonsterDenLvlMaint,
			int pMonsterDenBonus, long pMonsterDenRepair, long pMonsterDenRepairBase, int pShopLvl, long pShopLvlCost, long pShopLvlCostBase, long pShopLvlMaint,
			int pShopStock, long pShopStockCost, int pShopMaxStat, int pShopMaxDurability, int pShopUpgradeValue, int pResearchDevLvl,
			long pResearchDevLvlCost, long pResearchDevLvlCostBase, long pResearchDevMaint, int pResearchDevHealValue, int pResearchDevHealValueBase, int pResearchDevHealBays,
			long pResearchDevRebuild, long pResearchDevRebuildBase, int pBossLvl, int pBossLvlBase, int pBossCount, int pBossDifficulty, int pBossDifficultyBase, long pBossReward,
			int pGameDifficult, long pLifetimeGameScore, long pGoalLifetimeGameScore, long pLifetimeTeams, long pGoalLifetimeTeams,
			long pLifetimeEquipmentForged, long pGoalLifetimeEquipmentForged, long pLifetimeRevenue, long pGoalLifetimeRevenue)
		{
			getRoboNumeral = 1;
			maxRoboNumeral = 1000;
			RoboNumeralChar = '.';
			NumeralChar = '.';
			GameTeams = new List<Team> { };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(0, 1, findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 4, 5);
			findMonster = 50;
			GoalGameScore = pGoalGameScore;
			GoalGameScoreBase = pGoalGameScoreBase;
			MaxTeams = pMaxTeams;
			MaxRobo = pMaxRobo;
			TeamCost = pTeamCost;
			TeamCostBase = pTeamCostBase;
			GameCurrency = pGameCurrency;
			CurrentJackpot = 3;
			MaxJackpot = 0;
			CurrentJackpotLvl = 1;
			MinWage = 1;
			CurrentJackpotBase = 1;
			CurrentJackpotBaseIncrement = 1;
			fighting = false;
			auto = true;
			ShopLvl = pShopLvl;
			ShopLvlCost = pShopLvlCost;
			MainLvlCostBase = pShopLvlCostBase;
			ShopLvlMaint = pShopLvlMaint;
			ShopStock = pShopStock;
			ShopStockCost = pShopStockCost;
			ShopMaxStat = pShopMaxStat;
			ShopMaxDurability = pShopMaxDurability;
			ShopUpgradeValue = pShopUpgradeValue;
			repairPercent = .5;
			maxManagerHours = 10;
			PurchaseUpgrade = false;
			ArenaLvl = pArenaLvl;
			ArenaLvlCost = pArenaLvlCost;
			ArenaLvlMaint = pArenaLvlMaint;
			ArenaComunityReach = pArenaComunityReach;
			MonsterDenLvl = pMonsterDenLvl;
			MonsterDenLvlCost = pMonsterDenLvlCost;
			MonsterDenLvlMaint = pMonsterDenLvlMaint;
			MonsterDenBonus = pMonsterDenBonus;
			MonsterDenRepairs = pMonsterDenRepair;
			MonsterDenRepairsBase = pMonsterDenRepairBase;
			ResearchDevLvl = pResearchDevLvl;
			ResearchDevLvlCost = pResearchDevLvlCost;
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
			LifetimeGameScore = pLifetimeGameScore;
			GoalLifetimeGameScore = pGoalLifetimeGameScore;
			LifetimeTeams = pLifetimeTeams;
			GoalLifetimeTeams = pGoalLifetimeTeams;
			LifetimeEquipmentForged = pLifetimeEquipmentForged;
			GoalLifetimeEquipmentForged = pGoalLifetimeEquipmentForged;
			LifetimeRevenue = pLifetimeRevenue;
			GoalLifetimeRevenue = pGoalLifetimeRevenue;
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
			FightBreak = 7;
			roundCount = 0;
			bossFight = false;
			GameDifficultyFight = false;
			getWarningLog = "";
			getFightLog = "";
			getWinLog = "";
			fightPercent = 95;
			fightPercentMax = 100;
			fightCount = 0;
			FastForwardCount = 0;
		}
		public Game(bool isNew)
		{
			getRoboNumeral = 1;
			maxRoboNumeral = 1000;
			RoboNumeralChar = '.';
			NumeralChar = '.';
			GameTeams = new List<Team> { new Team(0, this), new Team(0, this) };
			GameTeam1 = new List<Team> { };
			GameTeam2 = new List<Team> { };
			Seating = new List<ArenaSeating> { new ArenaSeating(1, 1, 50, 25) };
			ConcessionStands = new List<Concession> { new Concession(.1,10) };
			CurrentSeating = new List<ArenaSeating> { };
			storeEquipment = new List<Equipment> { };
			MonsterOutbreak = new Team(0, 1, findMonster, ref MonsterOutbreak);
			MonsterOutbreak.getName = "Monster Outbreak";
			countdown = new List<KeyValuePair<String, DateTime>>();
			Bosses = new Team(1, 4, 5);
			CurrentJackpot = 3;
			MaxJackpot = 0;
			CurrentJackpotLvl = 1;
			MinWage = 1;
			CurrentJackpotBase = 1;
			CurrentJackpotBaseIncrement = 1;
			findMonster = 50;
			GameCurrency = 0;
			GoalGameScore = 200;
			GoalGameScoreBase = GoalGameScoreBaseIncrement;
			MaxTeams = 2;
			MaxRobo = 1;
			TeamCost = 2000;
			TeamCostBase = TeamCostBaseIncrement;
			fighting = false;
			auto = true;
			getFightLog = "";
			ShopLvl = 1;
			ShopLvlCost = 2000;
			MainLvlCostBase = MainLvlCostBaseIncrement;
			ShopLvlMaint = 1;
			ShopStock = 1;
			ShopBays = 1;
			ShopStockCost = 100;
			ShopMaxStat = 5;
			ShopMaxDurability = 100;
			ShopUpgradeValue = 1;
			repairPercent = .5;
			maxManagerHours = 10;
			PurchaseUpgrade = false;
			ArenaLvl = 1;
			ArenaLvlCost = 2000;
			ArenaLvlMaint = 1;
			ArenaComunityReach = 2000;
			ConcessionLvl = 1;
			ConcessionLvlCost = 2000;
			ConcessionLvlMaint = 1;
			ConcessionMarkup = 0.2; // twenty percent markup
			MonsterDenLvl = 1;
			MonsterDenLvlCost = 2000;
			MonsterDenLvlMaint = 1;
			MonsterDenBonus = 5;
			MonsterDenRepairs = 200;
			MonsterDenRepairsBase = MonsterDenRepairsBaseIncrement;
			ResearchDevLvl = 1;
			ResearchDevLvlCost = 2000;
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
			LifetimeGameScore = 0;
			GoalLifetimeGameScore = 1000;
			LifetimeTeams = 0;
			GoalLifetimeTeams = 10;
			LifetimeEquipmentForged = 0;
			GoalLifetimeEquipmentForged = 100;
			LifetimeRevenue = 0;
			GoalLifetimeRevenue = 10000;
			BreakTime = DateTime.Now.AddMinutes(55);
			SafeTime = DateTime.Now.AddMinutes(20);
			// Timer
			CurrentInterval = 1000;
			MaxInterval = 1000;
			ArenaOpponent1 = 0;
			ArenaOpponent2 = 0;
			getNumeral = 1;
			maxNumeral = 1000;
			FightBreak = 7;
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
			getWinLog = "";
			fightPercent = 95;
			fightPercentMax = 100;
			fightCount = 0;
			FastForwardCount = 0;
		}
		public void addLifetimeScore()
		{
			LifetimeGameScore++;
			if (GoalLifetimeGameScore == 0) GoalLifetimeGameScore = 1000;
			if (LifetimeGameScore >= GoalLifetimeGameScore)
			{
				getGameCurrency += GoalLifetimeGameScore * 10;
				getWarningLog = getFightLog = string.Format ("\n!*!*! Reached new Lifetime Game Score! {0:n0} awarded {1:c0}", GoalLifetimeGameScore, GoalLifetimeGameScore * 10);
				GoalLifetimeGameScore = roundValue(GoalLifetimeGameScore * 2, 1);
				MaxRobo++;
				UpdateMaxRobo();
			}
		}
		public void UpdateMaxRobo()
		{
			foreach (Team eTeam in GameTeams)
			{
				eTeam.getMaxRobos = MaxRobo;
			}
		}
		public void addLifetimeTeam()
		{
			LifetimeTeams++;
			if (GoalLifetimeTeams == 0) GoalLifetimeTeams = 10;
			if (LifetimeTeams >= GoalLifetimeTeams)
			{
				getGameCurrency += GoalLifetimeTeams * 10000;
				getWarningLog = getFightLog = string.Format("\n!*!*! Reached new Lifetime Teams created! {0:n0} awarded {1:c0}", GoalLifetimeTeams, GoalLifetimeTeams * 10000);
				GoalLifetimeTeams = roundValue(GoalLifetimeTeams * 2, 1);
			}
			UpdateMaxRobo();
		}
		public void addLifetimeRevenue(long revenue)
		{
			LifetimeRevenue += revenue;
			if (GoalLifetimeRevenue == 0) GoalLifetimeRevenue = 10000;
			if (LifetimeRevenue >= GoalLifetimeRevenue)
			{
				getGameCurrency += GoalLifetimeRevenue / 10;
				getWarningLog = getFightLog = string.Format("\n!*!*! Reached new Lifetime revenue! {0:c0} awarded {1:c0}", GoalLifetimeRevenue, GoalLifetimeRevenue / 10);
				GoalLifetimeRevenue = roundValue(GoalLifetimeRevenue * 2, 1);
			}
		}
		public void addLifetimeEquipmentForged()
		{
			LifetimeEquipmentForged++;
			if (GoalLifetimeEquipmentForged == 0) GoalLifetimeEquipmentForged = 100;
			if (LifetimeEquipmentForged >= GoalLifetimeEquipmentForged)
			{
				getGameCurrency += GoalLifetimeEquipmentForged * 100;
				getWarningLog = getFightLog = string.Format("\n!*!*! Reached new Equipment Forged! {0:n0} awarded {1:c0}", GoalLifetimeEquipmentForged, GoalLifetimeEquipmentForged * 100);
				GoalLifetimeEquipmentForged = roundValue(GoalLifetimeEquipmentForged * 2, 1);
			}
		}
		public bool ShouldSerializeMainFormPanel()
		{
			// don't serialize the MainFormPanel
			return false;
		}
		public string setRoboName()
		{
			return setRoboName(RndVal.Next(8));
		}
		public string setRoboName(int index)
		{
			string name = "";
			int NameType = RndVal.Next(100);
			if (NameType < 15)
				name = string.Format("{0}{2}{1}", RoboName[index], ToRoman(getRoboNumeral++), RoboNumeralChar); // Roman Numeral
			else if (NameType < 25)
				name = string.Format("{0}{2}{1:N0}", RoboName[index], getRoboNumeral++, RoboNumeralChar); // base 10
			else if (NameType < 35)
				name = string.Format("{0}{2}#{1:X}", RoboName[index], getRoboNumeral++, RoboNumeralChar); // Hex
			else if (NameType < 50)
				name = string.Format("{0}{2}~{1}", RoboName[index], ToAlphaNumeric(getRoboNumeral++), RoboNumeralChar); // Alphanumberic
			else 
				name = string.Format("{1} {0}", RoboName[index], name1[RndVal.Next(name1.Length)]); // Alphanumberic
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
			debugMsg = "";
			// ConcessionStands.Add(new Concession(ConcessionMarkup));
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

		public void resetAll()
		{
			resetAuto();
			clearWarnings();
		}

		public void interval(Timer Timer1)
		{
			if (ExtraIntervalPercent == 0)
			{
				if (MaxExtraIntervalPercent == 0) MaxExtraIntervalPercent = 10;
				else MaxExtraIntervalPercent += 10;
				ExtraIntervalPercent = MaxExtraIntervalPercent;
			}
			if (ExtraInterval > 0 && RndVal.Next(MaxExtraIntervalPercent) < ExtraIntervalPercent)
			{
				ExtraInterval--;
				// if Extra Intervals have been used up before we reach 1 second reduce the chance the extra round will be used. 
				if (ExtraInterval == 0 && 
					(CurrentInterval <= 1000 || RndVal.Next(MaxInterval) < CurrentInterval)) 
					ExtraIntervalPercent--;
			}
			else CurrentInterval++;
			if (CurrentInterval > MaxInterval)
			{
				CurrentInterval = 2000 - MaxInterval;
				if (CurrentInterval < 1)
				{
					// if Extra Intervals were not all used, reset to 100%
					if (ExtraInterval > 0)
					{
						MaxExtraIntervalPercent += 10;
						ExtraIntervalPercent = MaxExtraIntervalPercent;
					}
					ExtraInterval = Math.Abs(CurrentInterval);
					CurrentInterval = 1;
				}
				MaxInterval++;
				GameTeams.Sort();
			}
			else Timer1.Interval = CurrentInterval;
			if (CurrentInterval % 1000 == 0) GameTeams.Sort();
		}

		public void lowestLevelUp()
		{
			IList<string> levelUpList;
			levelUpList = new List<string> { };
			// find lowest level
			long lowestLvl = getArenaLvlCost;
			if (getShopLvlCost < lowestLvl) lowestLvl = getShopLvlCost;
			if (getResearchDevLvlCost < lowestLvl) lowestLvl = getResearchDevLvlCost;
			if (getMonsterDenLvlCost < lowestLvl) lowestLvl = getMonsterDenLvlCost;
			if (getConcessionLvlCost < lowestLvl) lowestLvl = getConcessionLvlCost;
			// Add all utilities that are the lowest level
			if (getArenaLvlCost == lowestLvl) levelUpList.Add("Arena");
			if (getShopLvlCost == lowestLvl) levelUpList.Add("Shop");
			if (getResearchDevLvlCost == lowestLvl) levelUpList.Add("RD");
			if (getMonsterDenLvlCost == lowestLvl) levelUpList.Add("Den");
			if (ConcessionLvlCost == lowestLvl) levelUpList.Add("Conc");
			// randomly choose one of the lowest level utilities
			string choise = levelUpList[RndVal.Next(levelUpList.Count)];
			// level up
			if (choise == "Arena" && getGameCurrency >= getArenaLvlCost) arenaLevelUp();
			if (choise == "Shop" && getGameCurrency >= getShopLvlCost) ShopLevelUp();
			if (choise == "RD" && getGameCurrency >= getResearchDevLvlCost) ResearchDevLevelUp();
			if (choise == "Den" && getGameCurrency >= getMonsterDenLvlCost) MonsterDenLevelUp();
			if (choise == "Conc" && getGameCurrency >= ConcessionLvlCost) ConcessionLevelUp();
		}
		public void arenaComunityOutreach(int recursions)
		{
			for (int i = 0; i < recursions; i++)
			{ arenaComunityOutreach(); }
		}
		public void arenaComunityOutreach()
		{
			int tmp = RndVal.Next(100);
			if (tmp > 90)
			{
				ArenaComunityReach = roundValue(ArenaComunityReach, RndVal.Next((int)(ArenaLvlCost*25)), "up");
				getWarningLog = getFightLog = string.Format("\n++ Huge comunity outreach up to {0:P2}", getArenaOutreach());
			}
			else
			{
				ArenaComunityReach = roundValue(ArenaComunityReach, RndVal.Next((int)(ArenaLvlCost*2)), "up");
				getWarningLog = getFightLog = string.Format("\n++ comunity outreach up to {0:P2}", getArenaOutreach());
			}
		}
		public void arenaLevelUp()
		{
			string msg = "\nArena upgraded!";
			getGameCurrency -= ArenaLvlCost;
			GameCurrencyLogUp -= ArenaLvlCost;
			ArenaLvlMaint += ArenaLvlCost/2;
			ArenaLvl++;
			ArenaLvlCost = roundValue(ArenaLvlCost, MainLvlCostBase, "up");
			ArenaComunityReach = roundValue(ArenaComunityReach, MainLvlCostBase, "up");
			MainLvlCostBase += MainLvlCostBaseIncrement;
			int lastPrice = 0;
			int totalLev = 0;
			foreach (ArenaSeating eSeating in Seating)
			{
				int lstAmt = eSeating.Amount;
				eSeating.Amount = (int)roundValue(eSeating.Amount, eSeating.AmountBase, "up");
				eSeating.AmountBase += 10;
				if (eSeating.Amount > 5000) eSeating.Amount = 5000;
				// increase price every 5 levels
				if (eSeating.Level % 5 == 0)
				{
					eSeating.Price++;
					msg += string.Format("\n  level {0} price up 1", eSeating.Level);
				}
				// only display amount if it increased. 
				if (eSeating.Amount > lstAmt) msg += string.Format("\n  level {0} seating up {1:n0}", eSeating.Level, eSeating.Amount - lstAmt);
				lastPrice = eSeating.Price;
				totalLev += eSeating.Level;
			}
			// add a new level of seating every 7 levels
			if (ArenaLvl % 7 == 0)
			{
				Seating.Add(new ArenaSeating(Seating.Count + 1, Seating[Seating.Count - 1].Price + Seating.Count, 20, 10));
				msg += string.Format("\n  Added level {0} seating", Seating.Count);
			}
			// reset maintenance condition
			ArenaLvlMaintCondition = 120;
			getFightLog = getWarningLog = msg; 
		}

		public void ConcessionLevelUp()
		{
			string msg = "\nConcession upgraded!";
			getGameCurrency -= ConcessionLvlCost;
			GameCurrencyLogUp -= ConcessionLvlCost;
			ConcessionLvlMaint += ConcessionLvlCost / 2;
			ConcessionLvl++;
			ConcessionLvlCost = roundValue(ConcessionLvlCost, MainLvlCostBase, "up");
			MainLvlCostBase += MainLvlCostBaseIncrement;
			if (ConcessionMarkup < .98 && RndVal.Next(100) > 90) ConcessionMarkup += .01; // increase markup by 1 percent 
			foreach (Concession eConcession in ConcessionStands)
			{
				eConcession.ConcessionLevelUp(ConcessionMarkup, ConcessionLvl * 10);
			}
			// continue here
			// add a new concession stand every 6 levels
			if (ConcessionLvl % 6 == 0)
			{
				ConcessionStands.Add(new Concession(ConcessionMarkup, ConcessionLvl * 10));
				msg += string.Format("\n  Added {0} concession stand", ConcessionStands[ConcessionStands.Count-1].name);
			}
			// reset maintenance condition
			ConcessionLvlMaintCondition = 120;
			getFightLog = getWarningLog = msg;

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
			int tmpDifficulty = BossDifficulty;
			do
			{
				Robot tmpBoss = new Robot(tmpDifficulty, setName("boss", Monster), Monster, true);
				// Level up
				for (int ii = 1; ii < BossLvl; ii++)
				{
					tmpBoss.levelUp(RndVal, true);
					tmpBoss.HP = tmpBoss.getTHealth();
					tmpBoss.MP = tmpBoss.getTEnergy();
				}
				Bosses.MyTeam.Add(tmpBoss);
				tmpDifficulty = (tmpDifficulty - 20);
			} while (tmpDifficulty >= 1);
			// Add equipment
			for (int i = 0; i < BossCount; i++)
			{
				Bosses.MyTeam[i].getEquipWeapon = new Equipment(true, BossLvl + Bosses.MyTeam[i].type, 10000, RndVal, true);
				Bosses.MyTeam[i].getEquipArmour = new Equipment(false, BossLvl + Bosses.MyTeam[i].type, 10000, RndVal, true);
			}
			Bosses.resetLogs();
			return retVal;
		}
		public string bossLevelDown()
		{
			string retVal = "";
			BossLvl = BossLvl--;
			BossCount--;
			BossDifficulty--;
			retVal = getFightLog = String.Format("\nBoss Level Decreased ({0}) ", DateTime.Now.ToString());
			BossReward = BossLvl * BossDifficulty * BossCount * getArenaLvl;
			// Remove random boss Robot / monster
			Bosses.MyTeam.RemoveAt(RndVal.Next(Bosses.MyTeam.Count));
			Bosses.resetLogs();
			return retVal;
		}
		public void MonsterDenLevelUp()
		{
			string msg = "\nMonster Den upgraded!";
			long tmpMonsterDenBonus = MonsterDenBonus;
			long tmpMonsterDenRepairs = MonsterDenRepairs;
			getGameCurrency -= MonsterDenLvlCost;
			GameCurrencyLogUp -= MonsterDenLvlCost;
			MonsterDenLvlMaint += MonsterDenLvlCost / 2;
			MonsterDenLvl++;
			MonsterDenLvlCost = roundValue(MonsterDenLvlCost, MainLvlCostBase, "up");
			MainLvlCostBase += MainLvlCostBaseIncrement;
			// keep monster den bonus around 10% of max seating
			long totalSeating = 0;
			foreach (ArenaSeating eSeating in Seating) { totalSeating += eSeating.Amount; }
			if (MonsterDenBonus > totalSeating/10) MonsterDenBonus += RndVal.Next(MonsterDenLvl);
			else MonsterDenBonus += RndVal.Next((int)totalSeating / 10);
			MonsterDenRepairs = roundValue(MonsterDenRepairs, MonsterDenRepairsBase, "up");
			MonsterDenRepairsBase += MonsterDenRepairsBaseIncrement;
			msg += string.Format("\n  Bonus +{0:n0} Repairs +{1:n0}", MonsterDenBonus - tmpMonsterDenBonus, MonsterDenRepairs - tmpMonsterDenRepairs);
			// reset maintenance condition
			MonsterDenLvlMaintCondition = 120;
			getFightLog = getWarningLog = msg;
		}
		public void ShopLevelUp()
		{
			string msg = "\nShop upgraded!";
			getGameCurrency -= ShopLvlCost;
			GameCurrencyLogUp -= ShopLvlCost;
			ShopLvlMaint += ShopLvlCost / 2;
			ShopLvl++;
			ShopLvlCost = roundValue(ShopLvlCost, MainLvlCostBase, "up");
			MainLvlCostBase += MainLvlCostBaseIncrement;
			// every 4 levels increase max stock
			if (ShopLvl % 4 == 0)
			{
				ShopStock++;
				msg += string.Format("\n  Stock +1");
			}
			// every 10 levels increase shop bays
			if (ShopLvl % 10 == 0)
			{
				ShopBays++;
				msg += string.Format("\n  Bays +1");
			}
			int tmpDurability = ShopMaxDurability;
			int tmpStat = ShopMaxStat;
			ShopMaxDurability = roundValue(ShopMaxDurability, 10, "up");
			ShopMaxStat = roundValue(ShopMaxStat, 2, "up");
			ShopUpgradeValue++;
			ShopStockCost = ((ShopMaxStat * 10) + ShopMaxDurability) / 3;
			msg += string.Format("\n  Durability +{0:n0} Stats +{1:n0} Upgrade +1", ShopMaxDurability - tmpDurability, ShopMaxStat - tmpStat);
			// reset maintenance condition
			ShopLvlMaintCondition = 120;
			getFightLog = getWarningLog = msg;
		}
		public void AddStock()
		{
			StartForge = true;
		}
		public void AddConcession()
		{
			StartRestock = true;
		}
		public void ForgeEquipment()
		{
			// Add new equipent to stock
			if (ShopStock > storeEquipment.Count && getGameCurrency >= ShopStockCost)
			{
				getGameCurrency -= ShopStockCost;
				GameCurrencyLogMisc -= ShopStockCost;
				addLifetimeRevenue(ShopStockCost * -1);
				Equipment tmp = new Equipment(AddArmour(), RndVal.Next(5, ShopMaxStat), RndVal.Next(100, ShopMaxDurability), RndVal, false, 100);
				int upgradeVal = 1;
				int equipmentLevel = RndVal.Next(ShopLvl);
				while (upgradeVal < equipmentLevel && getGameCurrency > ShopStockCost)
				{
					getGameCurrency -= ShopStockCost;
					GameCurrencyLogMisc -= ShopStockCost;
					tmp.ePrice = roundValue(tmp.ePrice, tmp.eUpgradeCost, "up"); 
					tmp.upgrade(ShopUpgradeValue, RndVal);
					upgradeVal++;
				}
				storeEquipment.Add(tmp);
				storeEquipment.Sort();
				addLifetimeEquipmentForged();
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
			string msg = "\nResearch and Development upgraded!";
			long tmpResearchDevHealValue = ResearchDevHealValue;
			long tmpResearchDevRebuild = ResearchDevRebuild;
			getGameCurrency -= ResearchDevLvlCost;
			GameCurrencyLogUp -= ResearchDevLvlCost;
			ResearchDevMaint += ResearchDevLvlCost / 2;
			ResearchDevLvl++;
			ResearchDevLvlCost = roundValue(ResearchDevLvlCost, MainLvlCostBase, "up");
			MainLvlCostBase += MainLvlCostBaseIncrement;
			ResearchDevHealValue = roundValue(ResearchDevHealValue, ResearchDevHealValueBase, "up");
			ResearchDevHealValueBase += ResearchDevHealValueBaseIncrement;
			ResearchDevRebuild = roundValue(ResearchDevRebuild, ResearchDevRebuildBase, "up");
			ResearchDevRebuildBase += ResearchDevRebuildBaseIncrement;
			msg += string.Format("\n  Heal +{0:n0} Rebuild +{1:n0}", ResearchDevHealValue - tmpResearchDevHealValue, ResearchDevRebuild - tmpResearchDevRebuild);
			// chance to add a new healing bay
			if (RndVal.Next(ResearchDevLvl + MaxRobo) > (ResearchDevHealBays))
			{
				ResearchDevHealBays++;
				msg += string.Format("\n  Heal Bays +1");
			}
			// reset maintenance condition
			ResearchDevLvlMaintCondition = 120;
			getFightLog = getWarningLog = msg;
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
				Team tmp = new Team(GameTeams.Count, this);
				TeamName = tmp.getName;
				GameTeams.Add(tmp);
				getWarningLog = getFightLog = tmp.getTeamLog = string.Format("\n!*!*! new team {0} was added!", tmp.getName);
			}
			addLifetimeTeam();
			return TeamName;
		}
		public void resetPartialScore()
		{
			// team with top score has chance to loose robots
			Team rebuild = new Team(1, 1, 1);
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.getScore > rebuild.getScore)
					rebuild = eTeam;
			}
			rebuild.getDifficulty = 0;
			rebuild.Win++;
			getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n\n!*!*! {0} won with top score!", rebuild.getName);
			int winGoal = rebuild.Win;
			int scouted = rebuild.Win * 25;
			int bonusScore = rebuild.getScore / GameTeams.Count;
			IList<int> scoutingTeams = new List<int> { };
			// Ensure at least one team is in the list
			scoutingTeams.Add(GameTeams.Count-1);
			// team indexes for scouting
			for (int i = GameTeams.Count-1; i >= 0; i--)
			{
				for (int j = i; j < GameTeams.Count; j++)
				{ 
					// More wins the team has lowers their chance of scouting another team.
					if (RndVal.Next(100) > GameTeams[j].Win && !GameTeams[j].getName.Equals(rebuild.getName)) scoutingTeams.Add(j); 
				}
			}
			for (int i = 0; i < rebuild.MyTeam.Count; i++)
			{
				if (RndVal.Next(100) < scouted && rebuild.MyTeam.Count > 1)
				{
					Team scoutingTeam = GameTeams[scoutingTeams[RndVal.Next(scoutingTeams.Count)]];
					string strScouter = " another arena";
					// if scouting team is not the team they are already part of
					if (!scoutingTeam.getName.Equals(rebuild.getName))
					{
						scoutingTeam.MyTeam.Add(rebuild.MyTeam[i]);
						strScouter = scoutingTeam.getName;
					}
					getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n!*!*! {0} has been scouted by {1}!", rebuild.MyTeam[i].getName, strScouter);
					rebuild.MyTeam.RemoveAt(i);
					scouted -=  15;
				}
				// if there is only one robot in the team rebuild team add a new robot to the scouting team
				if (rebuild.MyTeam.Count == 1 && RndVal.Next(100) < scouted)
				{
					Team scoutingTeam = GameTeams[scoutingTeams[RndVal.Next(scoutingTeams.Count)]];
					// add new robot
					int roboType = RndVal.Next(RoboName.Length);
					Robot tmp = new Robot(0, setRoboName(roboType), roboType, false);
					scoutingTeam.MyTeam.Add(tmp);
					getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n!*!*! {0} received a bonus robot!", scoutingTeam.getName);
					scouted -= 15;
				}
			}
			rebuild.HealScore = 0;
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.Win < winGoal)
				{
					long iWinnings = getArenaLvl * 1000 * (winGoal + 1);
					foreach (Robot eRobo in eTeam.MyTeam)
						eRobo.rebuildBonus++;
					const string Format = "\n*!* {0} won {1:n0} credits during partial reset!";
					getWarningLog = getFightLog = eTeam.getTeamLog = string.Format(format: Format, eTeam.getName, iWinnings);
					eTeam.getCurrency += iWinnings;
				}
			}
			// reset jackpot
			CurrentJackpot = 0;
			IncreaseJackpot();
		}
		public void resetScore()
		{
			// team with top score has chance to loose robots
			Team rebuild = new Team(1,1,1);
			foreach (Team eTeam in GameTeams)
			{
				if (eTeam.getScore > rebuild.getScore)
					rebuild = eTeam;
			}
			rebuild.getDifficulty = 0;
			rebuild.Win++;
			getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n\n!*!*! {0} won with top score!", rebuild.getName);
			int winGoal = rebuild.Win;
			int scouted = rebuild.Win * 25;
			int bonusScore = rebuild.getScore / GameTeams.Count;
			IList<int> scoutingTeams = new List<int> { };
			// teams for scouting
			for (int i = 0; i < GameTeams.Count; i++)
			{
				for (int j = 0; j <= i; j++)
				{
					// More wins the team has lowers their chance of scouting another team.
					if (RndVal.Next(100) > GameTeams[j].Win && !GameTeams[j].getName.Equals(rebuild.getName)) scoutingTeams.Add(j);
				}
			}
			for (int i = 0; i < rebuild.MyTeam.Count; i++)
			{
				if (RndVal.Next(100) < scouted && rebuild.MyTeam.Count > 1)
				{
					Team scoutingTeam = GameTeams[scoutingTeams[RndVal.Next(scoutingTeams.Count)]];
					string strScouter = " another arena";
					if (!scoutingTeam.getName.Equals(rebuild.getName))
					{
						scoutingTeam.MyTeam.Add(rebuild.MyTeam[i]);
						strScouter = scoutingTeam.getName;
					}
					getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n!*!*! {0} has been scouted by {1}!", rebuild.MyTeam[i].getName, strScouter);
					rebuild.MyTeam.RemoveAt(i);
					scouted -= 15;
				}
				// if there is only one robot in the team rebuild team add a new robot to the scouting team
				if (rebuild.MyTeam.Count == 1 && RndVal.Next(100) < scouted)
				{
					Team scoutingTeam = GameTeams[scoutingTeams[RndVal.Next(scoutingTeams.Count)]];
					// add new robot
					int roboType = RndVal.Next(RoboName.Length);
					Robot tmp = new Robot(0, setRoboName(roboType), roboType, false);
					scoutingTeam.MyTeam.Add(tmp);
					getWarningLog = getFightLog = rebuild.getTeamLog = string.Format("\n!*!*! {0} received a bonus robot!", scoutingTeam.getName);
					scouted -= 15;
				}
			}
			foreach (Team eTeam in GameTeams)
			{
				eTeam.getScore = 0;
				eTeam.HealScore = 0;
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
			JackpotMovement = -10;
			IncreaseJackpot(); 
		}
		public void addRobo(int Team) { addRobo(GameTeams[Team], this); }

		public void addRobo(Team Team, Game Game)
		{
			Team.getCurrency -= Team.getRoboCost;
			Team.getRoboCost = roundValue(Team.getRoboCost, Team.getRoboCostBase, "up");
			Team.getRoboCostBase += Team.RoboCostBaseIncrement;
			int roboType = RndVal.Next(RoboName.Length);
			Robot tmp = new Robot(0,Game.setRoboName(roboType), roboType, false);
			getWarningLog = getFightLog = string.Format("\n{0} added new robot {1}", Team.getName, tmp.getName);
            Team.MyTeam.Add(tmp);
			Team.AddRobotCreated();
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
			// Loop through the teams in a random order
			foreach (int index in Enumerable.Range(0, GameTeams.Count).OrderBy(x => RndVal.Next()))
			{
				Boolean tmpFullHP = true;
				if (!isFighting(GameTeams[index].getName) && !isFighting("arena"))
				{
					int pay = 0;
					tmpFullHP = GameTeams[index].healRobos(ref beds, ref pay, ResearchDevHealValue);
					getGameCurrency += pay;
					ResearchDevHealValueSum += pay;
					addLifetimeRevenue(pay);
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
			int tmpFindMonster = 10;
			if (findMonster > 10) tmpFindMonster = RndVal.Next(findMonster - 10, findMonster + 10);
			else tmpFindMonster = RndVal.Next(1, findMonster + 10);
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
			FastForward = false;
			fighting = true;
			GameTeam1.Add(new Team(0, 0, 0, 0, 0, 0, 0, 0, 0, "Arena", false));
			GameTeam1[GameTeam1.Count - 1].isMonster = true;
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam)
				{
					GameTeam1[GameTeam1.Count - 1].MyTeam.Add(eRobo);
				}
				GameTeam1[GameTeam1.Count - 1].resetSpeed();
			}
			GameTeam1[GameTeam1.Count - 1].MyTeam.Sort();
			if (bossFight)
			{
				bossFight = false;
				foreach (Robot eBoss in Bosses.MyTeam)
					eBoss.getCurrentSpeed = RndVal.Next(1, eBoss.getTSpeed());
				GameTeam2.Add(Bosses);
				Jackpot = BossReward;
				getWarningLog = getFightLog = Environment.NewLine + " Boss Fight! ";
				// Pause Game
				PauseForBoss();
				GameDifficultyFightPaused = true;
			}
			// Game difficulty fight
			else
			{
				GameDifficultyFight = false;
				Team Monsters = new Team(gameDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak);
				Monsters.getName = "Game Diff " + gameDifficulty.ToString();
				GameTeam2.Add(Monsters);
				Jackpot = gameDifficulty * getArenaLvl * 1000;
				getWarningLog = getFightLog = Environment.NewLine + " Game Difficulty Fight! ";
				// Pause Game
				PauseForBoss();
				GameDifficultyFightPaused = true;
			}
		}
		public void PauseForBoss()
		{
			// recover unused hours
			int hrs = (int)(SafeTime - DateTime.Now).TotalHours;
			while (hrs > 0)
			{
				ManagerHrs++;
				ManagerCost = roundValue(ManagerCost, ManagerCostBase, "up");
				ManagerCostBase = ManagerCostBase + ManagerCostBaseIncrement;
				hrs--;
			}
			SafeTime = DateTime.Now;
			BreakTime = DateTime.Now;
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
			if (RndVal.Next(100) > 75 && allowRandom)
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
				if (((tmpTeam.getDifficulty - 1) * 4) + 1 > tmpTeam.MyTeam[tmpTeam.MyTeam.Count - 1].getLevel && RndVal.Next(100) > 99)
				{
					tmpTeam.getDifficulty--;
					getFightLog = String.Format("\n!!! {0} difficulty decreased!", tmpTeam.getName);
				}
			}
			return TeamIndex;
		}
		public void incrementArenaOpponent()
		{
			ArenaOpponent1 = RndVal.Next(GameTeams.Count);
			ArenaOpponent2 = RndVal.Next(GameTeams.Count);
		}
		public long MaxMaintenance()
		{
			// return highest maintenance value
			long max = Math.Max(ArenaLvlMaint, ShopLvlMaint);
			max = Math.Max(ResearchDevMaint, max);
			max = Math.Max(MonsterDenLvlMaint, max);
			max = Math.Max(ConcessionLvlMaint, max);
			return max;
		}
		public void startFight()
        {
			// Save logs
			fightLogSave = FightLog;
			warningLogSave = WarningLog;
			winLogSave = WinLog;
			DisplayTime = DateTime.Now;
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
					// combined Forge and restock so we will not miss out on restocking equipment or sock while the other is still restocking. 
					if (StartForge)
					{
						// forge new equipment
						if (ShopStock > storeEquipment.Count) ForgeEquipment();
						else StartForge = false;
					}
					if (StartRestock)
					{ 
						// restock concessions
						StartRestock = false;
						foreach (Concession eConcession in ConcessionStands)
						{
							if (eConcession.CurrentStock == 0 && eConcession.RestockCost < getGameCurrency)
							{
								long tmpCost = eConcession.restock(getGameCurrency);
								getGameCurrency -= tmpCost;
								// subtract cost from revenue
								addLifetimeRevenue(tmpCost * -1);
								getFightLog = string.Format("\n    -$ {0} Restock: {1:c0}", eConcession.name, tmpCost);
								StartRestock = true;
							}
						}
					}
					WinCount = 0;
					incrementArenaOpponent();
					if (RndVal.Next(100) > 90)
					{
						if (JackpotUpDown)
                        {
							IncreaseJackpot();
                        }
						else if (CurrentJackpot/2 == MinWage && getGameCurrency > 0)
						{
							JackpotMovement++;
							IncreaseJackpot();
						}
						else if ((getGameCurrency < MaxMaintenance()))
                        {
							JackpotMovement--;
							IncreaseJackpot();
						}
					}
					CheckMinJackpot();
					if (ArenaOpponent1 == ArenaOpponent2)
					{
						Team1Index = Team2Index = ArenaOpponent1;
						//Team1Index = Team2Index = monsterFight(true);
						Team tmpTeam = GameTeams[Team1Index];
						if (((tmpTeam.getDifficulty - 1) * 4) + 1 > tmpTeam.MyTeam[tmpTeam.MyTeam.Count - 1].getLevel && RndVal.Next(100) > 95)
						{
							tmpTeam.getDifficulty--;
							getFightLog = String.Format("\n!!! {0} difficulty decreased!", tmpTeam.getName);
						}
					}
					else
					{
						Team1Index = ArenaOpponent1;
						Team2Index = ArenaOpponent2;
					}
					// Keep the number of consecutive battles around 3
					if (getGameCurrency > 0)
					{
						// increase fight percent to have fewer fights
						if (fightCount > 3)
							fightPercent++;
						// decrease to have more fights
						else
							fightPercent--;
						// Ensure max value is not too small
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
				GameTeams[Team1Index].resetSpeed();
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
					// reset speed for monsters
					foreach (Robot eMonster in MonsterOutbreak.MyTeam)
						eMonster.getCurrentSpeed = RndVal.Next(1, eMonster.getTSpeed());
					// Monster team... 
					GameTeam2.Add(new Team(GameTeam1[GameTeam1.Count - 1].getDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak));
				}
				else
				{
					// Robo Team
					GameTeams[Team2Index].resetSpeed();
					GameTeam2.Add(GameTeams[Team2Index]);
					PotScore += GameTeam2[GameTeam2.Count - 1].getScore;
				}
				string msg = "";
				int tmpMonsterDenBonus = getMonsterDenBonus;
				if (getGameCurrency <= 0) tmpMonsterDenBonus = 0;
				if (GameTeam1.Count == 1) PotScore += tmpMonsterDenBonus;
				// small chance to reduce the outreach percentage 
				if (RndVal.Next(1000) < ArenaLvl) ArenaComunityReach = roundValue(ArenaComunityReach, (MainLvlCostBase / 100), "down");
				int tmpTotalScore = (int)(PotScore * getArenaOutreach());
				int availableSeating = 0;
				if (tmpTotalScore < 0) tmpTotalScore = 0;
				if (GameTeam1.Count == 1)
				{
					CurrentSeating = new List<ArenaSeating> { };
					seatingAvailable = new List<int> { };
					// reset seating
					foreach (ArenaSeating eSeating in Seating)
					{
						CurrentSeating.Add(new ArenaSeating(eSeating.Level, eSeating.Price, eSeating.Amount, eSeating.AmountBase));
						for (int i = 0; i < eSeating.Level; i++)
						{ seatingAvailable.Add(i); }
						availableSeating += eSeating.Amount;
					}
				}
				// randomize each attendee
				int attendees = 0;
				// smaller percentage chance to fill attendees by the available seating instead of the current score
				if (RndVal.Next(100) > 90) attendees = RndVal.Next(availableSeating);
                else attendees = RndVal.Next(tmpTotalScore);
				int unseated = 0;
				// loop through all attendees to see which seating level they are assigned too. 
				for (int i = 0; i < attendees; i++)
				{
					int seatingLevel = 0;
					// choose which level of seating to put this attendee. 
					if (seatingAvailable.Count > 0) seatingLevel = seatingAvailable[RndVal.Next(seatingAvailable.Count)];
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
				if (GameTeam1.Count > 1)
				{
					// If no seats available 75% chance to  remove the teams that were added and exit function, unless total score is less than 10 or fighting a monster team
					 if (attendees == unseated && tmpTotalScore > 10 && !GameTeam2[0].isMonster && RndVal.Next(100) > 25)
					{
						GameTeam1.RemoveAt(GameTeam1.Count - 1);
						GameTeam2.RemoveAt(GameTeam2.Count - 1);
						return;
					}
				}
				// concession sales
				long tmpSales = 0;
				int tmpPurchasers = attendees - unseated;
				bool displayEach = false;
				if (roundCount < 20) displayEach = true;
				foreach (Concession eConcession in ConcessionStands)
				{
					tmpSales += eConcession.purchase(ref tmpPurchasers,displayEach);
				}
				if (!displayEach && tmpSales > 0 ) getFightLog = string.Format("\n    +$ Concession Sales: {0:c0}", tmpSales);
                getGameCurrency += tmpSales;
				addLifetimeRevenue(tmpSales);
				// total attendance
				int countChars = 10 + tmpTotalScore.ToString().Length;
				msg += displaySeating("\n    Attd", attendees - unseated, -2, ref countChars);
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
					GameCurrency -= MinWage;
					GameCurrencyLogMisc -= MinWage;
					GameTeam1[GameTeam1.Count - 1].getCurrency += MinWage;
					msg += displaySeating("G", tmp, -1, ref countChars);
					msg += displaySeating("MG", MinWage, -1, ref countChars);
					int thisRev = tmp - MinWage;
					msg += displaySeating("R", thisRev, -1, ref countChars);
					addLifetimeRevenue(thisRev);
					totalRev += thisRev;
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
					int thisRev = tmp - CurrentJackpot;
					msg += displaySeating("R", thisRev, -1, ref countChars);
					addLifetimeRevenue(thisRev);
					totalRev += thisRev;
					msg += String.Format("\n        Attendance: {0:P2}\n", (getArenaOutreach())); 
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
			// Current Interval
			int tmpInterval = CurrentInterval;
			double Minutes = 0;
			// Seconds
			if (tmpInterval > 1000)
			{
				Minutes = ((double)tmpInterval / 1000);
				retval += string.Format("{0:0.###}s/", Minutes);
			}
			else
			{
				retval += string.Format("{0:n0}ms/", tmpInterval);
			}
			// Max Interval
			tmpInterval = MaxInterval;
			// Seconds
			if (tmpInterval > 1000)
			{
				Minutes = ((double)tmpInterval / 1000);
				retval += string.Format("{0:0.###}s", Minutes);
			}
			else
			{
				retval += string.Format("{0:n0}ms", tmpInterval);
			}
			return retval;
		}

		public FlowLayoutPanel showHeader()
		{
			FlowLayoutPanel HeaderPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			Label lblBlank = new Label { AutoSize = true, Text = Environment.NewLine + Environment.NewLine };
			HeaderPanel.Controls.Add(lblBlank);
			Brush myColour = Brushes.Black;
			if (CurrentInterval < 1000) myColour = Brushes.Gray;
			else if (CurrentInterval < 2000) myColour = Brushes.White;
			else if (CurrentInterval < 3000) myColour = Brushes.Yellow;
			else if (CurrentInterval < 4000) myColour = Brushes.Green;
			else if (CurrentInterval < 5000) myColour = Brushes.Blue;
			else if (CurrentInterval < 6000) myColour = Brushes.Red;
			//AlsProgressBar Progress = new AlsProgressBar(myColour) { Maximum = MaxInterval, Value = CurrentInterval, Minimum = 1, Width = 450, Height = 10 };
			AlsProgressBar Progress = new AlsProgressBar(myColour) { Maximum = MaxInterval, Value = CurrentInterval, Minimum = 1, Width = MainFormPanel.Width-40, Height = 10 };
			HeaderPanel.Controls.Add(Progress);
			string SafeFormat = "HH:mm";
			if (SafeTime.Day > DateTime.Now.Day) SafeFormat = "MM-dd HH:mm";
			Label lblTime = new Label { AutoSize = true, Text = String.Format("Time: {0} Safe: {1} Break: {2} Rmng Min:{3:n0} Hrs:{4:n1} - Rnds:{5:n0} Ex:{6:n0} {7:p1} {10}", DateTime.Now.ToString("HH:mm"), SafeTime.ToString(SafeFormat), BreakTime.ToString("HH:mm"), (DateTime.Today.AddHours(16) - DateTime.Now).TotalMinutes, (DateTime.Today.AddHours(16) - DateTime.Now).TotalHours, roundCount, ExtraInterval, ((double)ExtraIntervalPercent/(double)MaxExtraIntervalPercent), ExtraIntervalPercent, MaxExtraIntervalPercent, debugMsg) };
			HeaderPanel.Controls.Add(lblTime);
			//debugMsg = "";
			return HeaderPanel;
		}
		public double getArenaOutreach()
		{
			return ((double)ArenaComunityReach / (double)ArenaLvlCost);
		}
		public FlowLayoutPanel showSelectedTeam(int TeamSelect, bool showAll)
		{
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			if (TeamSelect > 0)
			{
				FlowLayoutPanel TopLevelPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblNextNumeral	= new Label { AutoSize = true, Text = String.Format("Next Numbr:{3}{0}/{3}{1:n0}/{3}#{1:X}/{3}`{2}", ToRoman(getRoboNumeral), getRoboNumeral, ToAlphaNumeric(getRoboNumeral), RoboNumeralChar) };
				Label lblTeamName		= new Label { AutoSize = true, Text = String.Format("\nTeam Name:  {0}", GameTeams[TeamSelect - 1].getName) };
				//Label lblTeamName = new Label { AutoSize = true, Text = "Team Name:  " + GameTeams[TeamSelect - 1].getName };
				lblTeamName.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].rename(InputBox("Enter Name ", "Enter Name")));
				Label lblTeamCurrency = new Label { AutoSize = true, Text = "Currency:   " + String.Format("{0:c0}", GameTeams[TeamSelect - 1].getCurrency) };
				Label lblScore = new Label { AutoSize = true, Text = "Score:      " + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getScore) + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getGoalScore) + ")" };
				Label lblWin = new Label { AutoSize = true, Text = String.Format("Winns:      {0:n0}", GameTeams[TeamSelect - 1].Win) };
				Label lblRobots = new Label { AutoSize = true, Text = "Robots:     " + GameTeams[TeamSelect - 1].MyTeam.Count + "/" + GameTeams[TeamSelect - 1].getMaxRobos + " (" + String.Format("{0:n0}", GameTeams[TeamSelect - 1].getRoboCost) + ")" };
				Label lblRunes = new Label { AutoSize = true, Text = "Runes:     " + GameTeams[TeamSelect - 1].getRunes() };
				Label lblDifficulty = new Label { AutoSize = true, Text =     "Difficulty: " + GameTeams[TeamSelect - 1].getDifficulty };
				string strAutomated = "";
				if (GameTeams[TeamSelect - 1].Automated) strAutomated = "Automated Upgrade";
				else if (GameTeams[TeamSelect - 1].Manual_Equipment) strAutomated = "Manual Upgrade Equipment";
				else strAutomated = "Manual Upgrade Robot";
				Label lblAutomatic = new Label { AutoSize = true, Text = strAutomated };
				lblAutomatic.Click += new EventHandler((sender, e) => GameTeams[TeamSelect - 1].changeAutomated());
				int index = 0;
				int TotalPower = 0;
				foreach (Robot eRobo in GameTeams[TeamSelect - 1].MyTeam)
				{
					TotalPower += eRobo.getTotalPower();
					FlowLayoutPanel MyPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
					Label RoboName = new Label { AutoSize = true, Text = eRobo.getName };
					RoboName.Click += new EventHandler((sender, e) => eRobo.rename(InputBox("Enter Name ", "Enter Name")));
					Label Everything = new Label { AutoSize = true, Text = eRobo.ToString() };
					long ActualRebuildCost = eRobo.rebuildCost(ResearchDevRebuild, GameTeams[TeamSelect - 1].Runes);
					long ProposedRebuildCost = eRobo.rebuildCost(ResearchDevRebuild, GameTeams[TeamSelect - 1].Runes, true);
					string strFormat = "Rebuild {0:c0}";
					if (ActualRebuildCost == 100) strFormat = "Reset $100";
					string strFormatFullRebuildCost = "{3:c0} - {0:c0} ({1:n0}%) b{2:n0}";
					int stats = (eRobo.getBaseStats());
					if (GameTeams[TeamSelect - 1].Runes.Count < (stats / 2)) GameTeams[TeamSelect - 1].addRune((int)(stats / 2) * 10);
					int tmpRunes = 0;
					if (GameTeams[TeamSelect - 1].Runes.Count > stats / 2) tmpRunes = GameTeams[TeamSelect - 1].Runes[stats / 2];
					Button btnRebuild = new Button { AutoSize = true, Text = String.Format(strFormat, ActualRebuildCost) };
					Label rebuildCost = new Label { AutoSize = true, Text = String.Format(strFormatFullRebuildCost, (eRobo.RoboRebuildCost - ProposedRebuildCost), tmpRunes, eRobo.rebuildBonus, eRobo.RoboRebuildCost) };
					int innerIndex = index++;
					MyPanel.Controls.Add(RoboName);
					MyPanel.Controls.Add(Everything);
					MyPanel.Controls.Add(btnRebuild);
					MyPanel.Controls.Add(rebuildCost);
					TopLevelPanel.Controls.Add(MyPanel);
                }
                Label lblTotalPower = new Label { AutoSize = true, Text = String.Format("TotalPower: {0:n0}",TotalPower)};
                MainPanel.Controls.Add(lblNextNumeral);
                MainPanel.Controls.Add(lblTeamName);
                MainPanel.Controls.Add(lblTeamCurrency);
                MainPanel.Controls.Add(lblScore);
                MainPanel.Controls.Add(lblWin);
                MainPanel.Controls.Add(lblRobots);
                MainPanel.Controls.Add(lblRunes);
                MainPanel.Controls.Add(lblDifficulty);
                MainPanel.Controls.Add(lblTotalPower);
                MainPanel.Controls.Add(lblAutomatic);
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
				Label lblTotalScore = new Label { AutoSize = true, Text = String.Format("Total Score: {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\*#,###}", getScore(), getGoalGameScore, RobotPriority) };
				MainPanel.Controls.Add(lblTotalScore);
				Label lblTeams = new Label { AutoSize = true, Text =	  String.Format("Teams:       {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\+#,###}", string.Format("{0:n0}/{1:n0}",GameTeams.Count, getMaxTeams), getTeamCost)};
				MainPanel.Controls.Add(lblTeams);
				//Label lblCurrency = new Label { AutoSize = true, Text =   String.Format("{0,-13}{1," + RowOneLength[0] + ":c0} \n{2,-13}{3," + RowOneLength[0] + ":c0}\n{4,-13}{5," + RowOneLength[0] + ":c0}\n{6,-13}{7," + RowOneLength[0] + ":c0}\n{8,-13}{9," + RowOneLength[0] + ":c0}", "Currency:",getGameCurrency, "   Misc ",  GameCurrencyLogMisc, "   Maint -", 0 - GameCurrencyLogMaint, "   Upgr  -", 0 - GameCurrencyLogUp, "   Total =", GameCurrencyLogMisc + GameCurrencyLogMaint + GameCurrencyLogUp) };
				Label lblCurrency = new Label { AutoSize = true, Text =   String.Format("{0,-13}{1," + RowOneLength[0] + ":c0}", "Currency:",getGameCurrency)};
				MainPanel.Controls.Add(lblCurrency);
				Label lblArenaLvl = new Label { AutoSize = true, Text =   String.Format("Arena:       {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###} {3}%", getArenaLvl, getArenaLvlCost, getArenaLvlMaint, getArenaLvlMaintCondition) };
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
				long potentialEarnings = 0;
				long totalSeating = 0;
				foreach (ArenaSeating eSeating in Seating)
				{
					if (showAll || index <= 2)
					{
						string ending = "";
						if (index == 2 && !showAll && Seating.Count > 3) ending = "...";
						Label lblArenaSeating = new Label { AutoSize = true, Text = String.Format("    Level:{3," + RowThreeLength[0] + "} Price:{0," + RowThreeLength[1] + ":c0} Seats:{1," + RowThreeLength[2] + ":n0}{2}\n", eSeating.Price, eSeating.Amount, ending, eSeating.Level) };
						pnlSeating.Controls.Add(lblArenaSeating);
						potentialEarnings += (eSeating.Price * eSeating.Amount);
						totalSeating += eSeating.Amount;
						index++;
					}
				}
				Label lblPotentialEarnings = new Label { AutoSize = true, Text = String.Format("    Earning Potenial:{0," + RowThreeLength[1] + ":c0} Seats:{1," + RowThreeLength[1] + ":n0}", potentialEarnings, totalSeating) };
				pnlSeating.Controls.Add(lblPotentialEarnings);
				MainPanel.Controls.Add(pnlSeating);
				Label lblShopLvl = new Label { AutoSize = true, Text = String.Format("Shop:        {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###} {3}%", getShopLvl, getShopLvlCost, getShopLvlMaint, getShopLvlMaintCondition) };
				MainPanel.Controls.Add(lblShopLvl);
				FlowLayoutPanel pnlEquipment = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				Label lblShopStock = new Label
				{
					AutoSize = true,
					Text = String.Format("  {0,-10}{1," + RowTwoLength[0] + "} {2,-6}{3," + RowTwoLength[1] + ":n0} {4,-7}{5," + RowTwoLength[2] + ":n0} {6,-5}{7," + RowTwoLength[3] + ":n0} {8,-4}{9," + RowTwoLength[4] + ":n0} {10,-4} {11:n0}",
																						"Max Stock", string.Format("{0}/{1}", storeEquipment.Count, getShopStock),
																						"Dur", getShopMaxDurability, "Stat", getShopMaxStat, "Cost", getShopStockCost, "Up", getShopUpgradeValue, "Bays", ShopBays)
				};
				pnlEquipment.Controls.Add(lblShopStock);
				RowThreeLength = new int[] { 8, 3, 1, 3 };
				foreach (Equipment eEquipment in storeEquipment)
				{
					if (string.Format("{0}", eEquipment.eName + "+" + eEquipment.eUpgrade).Length > RowThreeLength[0]) RowThreeLength[0] = string.Format("{0}", eEquipment.eName + "+" + eEquipment.eUpgrade).Length;
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
						string tmp = string.Format("{0,-" + RowThreeLength[0] + "}", eEquipment.eName + "+" + eEquipment.eUpgrade);
						tmp += String.Format(" Dur {0," + RowThreeLength[1] + ":n0} {1}", eEquipment.eDurability, eEquipment.eType);
						if (eEquipment.eHealth > 0 && showAll) { tmp += String.Format(" Hea{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eHealth); }
						if (eEquipment.eEnergy > 0 && showAll) { tmp += String.Format(" Enr{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eEnergy); }
						if (eEquipment.eDamage > 0 && showAll) { tmp += String.Format(" Dam{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eDamage); }
						if (eEquipment.eHit > 0 && showAll) { tmp += String.Format(" Hit{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eHit); }
						if (eEquipment.eArmour > 0 && showAll) { tmp += String.Format(" Acl{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eArmour); }
						if (eEquipment.eMentalStrength > 0 && showAll) { tmp += String.Format(" Mst{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eMentalStrength); }
						if (eEquipment.eMentalDefense > 0 && showAll) { tmp += String.Format(" Mdf{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eMentalDefense); }
						if (eEquipment.eSpeed > 0 && showAll) { tmp += String.Format(" Spd{0," + RowThreeLength[2] + ":\\+#,###}", eEquipment.eSpeed); }
						tmp += String.Format(" Price {0," + RowThreeLength[3] + ":n0}", eEquipment.ePrice);
						Label lblEquipment = new Label { AutoSize = true, Text = string.Format("    {0}{1}\n", tmp, ending) };
						pnlEquipment.Controls.Add(lblEquipment);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlEquipment);
				// Concession Stands
				Label lblConcessionLvl = new Label { AutoSize = true, Text = String.Format("Concession:  {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###} {3}% \n  Markup: {4:p0} Stock:{5:p0}", ConcessionLvl, ConcessionLvlCost, getConcessionLvlMaint, getConcessionLvlMaintCondition, ConcessionMarkup, getConcessionStock) };
				MainPanel.Controls.Add(lblConcessionLvl);
				FlowLayoutPanel pnlStands = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true };
				RowThreeLength = new int[] { 8, 1, 2, 1, 1, 1, 1 };
				foreach (Concession eConcession in ConcessionStands)
				{
					long Revenu = (eConcession.MaxStock * eConcession.SalePrice) - eConcession.RestockCost;
					if (string.Format("{0}", eConcession.name).Length > RowThreeLength[0]) RowThreeLength[0] = string.Format("{0}", eConcession.name).Length;
					if (string.Format("{0:n0}", eConcession.CurrentStock).Length > RowThreeLength[1]) RowThreeLength[1] = string.Format("{0:n0}", eConcession.CurrentStock).Length;
					if (string.Format("{0:n0}", eConcession.MaxStock).Length > RowThreeLength[2]) RowThreeLength[2] = string.Format("{0:n0}", eConcession.MaxStock).Length;
					if (string.Format("{0:c0}", eConcession.SalePrice).Length > RowThreeLength[3]) RowThreeLength[3] = string.Format("{0:c0}", eConcession.SalePrice).Length;
                    if (string.Format("{0:c0}", eConcession.RestockCost).Length > RowThreeLength[4]) RowThreeLength[4] = string.Format("{0:c0}", eConcession.RestockCost).Length;
                    if (string.Format("{0:c0}", Revenu).Length > RowThreeLength[5]) RowThreeLength[5] = string.Format("{0:c0}", Revenu).Length;
                    if (string.Format("{0:n0}", eConcession.Demand).Length > RowThreeLength[6]) RowThreeLength[6] = string.Format("{0:n0}", eConcession.Demand).Length;
				}
				index = 0;
				foreach (Concession eConcession in ConcessionStands)
				{
					if (showAll || index <= 2)
                    {
                        long Revenu = (eConcession.MaxStock * eConcession.SalePrice) - eConcession.RestockCost;
                        string ending = "";
						if (index == 2 && !showAll && storeEquipment.Count > 3) ending = "...";
						string tmp = string.Format("{0,-" + RowThreeLength[0] + "} {1," + RowThreeLength[1] + ":n0}/{2," + RowThreeLength[2] + ":n0} S:{3," + RowThreeLength[3] + ":c0} F:{4," + RowThreeLength[4] + ":c0} R:{5," + RowThreeLength[5] + ":c0} D:{6," + RowThreeLength[6] + ":n0}", eConcession.name, eConcession.CurrentStock, eConcession.MaxStock, eConcession.SalePrice, eConcession.RestockCost, Revenu, eConcession.Demand);
						Label lblStand = new Label { AutoSize = true, Text = string.Format("    {0}{1}\n", tmp, ending) };
						pnlStands.Controls.Add(lblStand);
						index++;
					}
				}
				MainPanel.Controls.Add(pnlStands);
				// Research
				Label lblResearchLvl = new Label { AutoSize = true, Text = String.Format("Research:    {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###} {9}%\n  {3,-10}{4," + RowTwoLength[0] + "} {5,-6}{6," + RowTwoLength[1] + ":n0} {7,-7}{8," + RowTwoLength[2] + ":n0}", getResearchDevLvl, getResearchDevLvlCost, getResearchDevMaint, "Heal", getResearchDevHealValue, "Bay", getResearchDevHealBays, "Rbld", ResearchDevRebuild, getResearchDevLvlMaintCondition) };
				MainPanel.Controls.Add(lblResearchLvl);
				// Monster Den
				Label lblMonsterDen = new Label { AutoSize = true, Text = String.Format("Monster Den: {0," + RowOneLength[0] + "} {1," + RowOneLength[1] + ":\\+#,###} {2," + RowOneLength[2] + ":\\-#,###;\\!#,###} {9}%\n  {3,-10}{4," + RowTwoLength[0] + "} {5,-6}{6," + RowTwoLength[1] + ":n0} {7,-7}{8," + RowTwoLength[2] + ":n0}", MonsterDenLvl, getMonsterDenLvlCost, getMonsterDenLvlMaint, "In Den", MonsterOutbreak.MyTeam.Count, "Bonus", MonsterDenBonus, "Repair", MonsterDenRepairs, getMonsterDenLvlMaintCondition) };
				lblMonsterDen.Click += new EventHandler((sender, e) => displayMonsters("Monster Outbreak"));
				MainPanel.Controls.Add(lblMonsterDen);
				// Boss Monsters
				Label lblBossMonsters = new Label { AutoSize = true, Text = String.Format("BossMonsters:{0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":c0}", BossCount, BossReward) };
				lblBossMonsters.Click += new EventHandler((sender, e) => displayMonsters("Boss Monsters"));
				MainPanel.Controls.Add(lblBossMonsters); 
				// Manager
				Label lblManager = new Label { AutoSize = true, Text = String.Format("Manager:     {0," + RowOneLength[0] + ":n0} {1," + RowOneLength[1] + ":\\+#,###}", ManagerHrs, ManagerCost) };
				lblManager.Click += new EventHandler((sender, e) => AddManagerHours());
				MainPanel.Controls.Add(lblManager);
				Label lblResetPercent = new Label { AutoSize = true, Text = String.Format("Lower Percent: Boss-{0}% Diff-{1}%",bossLosses, DiffLosses) };
				lblResetPercent.Click += new EventHandler((sender, e) => displayAchievements());
				MainPanel.Controls.Add(lblResetPercent);
				Label lblAchievments = new Label { AutoSize = true, Text = String.Format("Achievments") };
				lblAchievments.Click += new EventHandler((sender, e) => displayAchievements());
				MainPanel.Controls.Add(lblAchievments);
				if (getWarningLog.Length > 0)
				{
					Label lblWarningLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Bold, GraphicsUnit.Pixel), Text = Environment.NewLine + "Warnings:" + getWarningLog };
					lblWarningLog.Click += new EventHandler((sender, e) => clearWarnings());
					MainPanel.Controls.Add(lblWarningLog);
				}
				if (getWinLog.Length > 0)
				{
					Label lblWinLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Underline, GraphicsUnit.Pixel), Text = Environment.NewLine + getWinLog };
					lblWinLog.Click += new EventHandler((sender, e) => clearWinns());
					MainPanel.Controls.Add(lblWinLog);
				}
				Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + getFightLog };
				MainPanel.Controls.Add(lblFightLog);
			}
			return MainPanel;
		}
		public void displayAchievements()
		{ 
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			int[] RowOneLength =
					{ getMaxLength(new string[] { string.Format("{0:n0}", LifetimeGameScore),     string.Format("{0:n0}", LifetimeTeams),     string.Format("{0:n0}", LifetimeRevenue),     string.Format("{0:n0}", LifetimeEquipmentForged) })
					, getMaxLength(new string[] { string.Format("{0:n0}", GoalLifetimeGameScore), string.Format("{0:n0}", GoalLifetimeTeams), string.Format("{0:n0}", GoalLifetimeRevenue), string.Format("{0:n0}", GoalLifetimeEquipmentForged) })
				};
			int[] TeamHeadingRowLength = { 0, 0 };
			int[] TeamRowLength = { 0, 0 };
			foreach (Team eTeam in GameTeams)
			{
				int tmp = getMaxLength(new string[] { string.Format("{0:n0}", eTeam.LifetimeRobotsCreated),			string.Format("{0:n0}", eTeam.LifetimeRobotsRebuilt),		string.Format("{0:n0}", eTeam.LifetimeEquipmentPurchased), string.Format("{0:n0}",		eTeam.LifetimeEquipmentUpgraded) });
				int tmpGoal = getMaxLength(new string[] { string.Format("{0:n0}", eTeam.GoalLifetimeRobotsCreated), string.Format("{0:n0}", eTeam.GoalLifetimeRobotsRebuilt),	string.Format("{0:n0}", eTeam.GoalLifetimeEquipmentPurchased), string.Format("{0:n0}",	eTeam.GoalLifetimeEquipmentUpgraded) });
				if (TeamHeadingRowLength[0] < tmp) TeamHeadingRowLength[0] = tmp;
				if (TeamHeadingRowLength[1] < tmp) TeamHeadingRowLength[1] = tmpGoal;
				for (int i = 0; i < 9; i++)
				{
					if (TeamRowLength[0] < string.Format("{0:n0}", eTeam.RobotDestroyed[i]).Length) TeamRowLength[0] = string.Format("{0:n0}", eTeam.RobotDestroyed[i]).Length;
					if (TeamRowLength[1] < string.Format("{0:n0}", eTeam.RobotDestroyedGoal[i]).Length) TeamRowLength[1] = string.Format("{0:n0}", eTeam.RobotDestroyedGoal[i]).Length;
				}
				for (int i = 0; i < eTeam.MonsterDestroyed.Length; i++)
				{
					if (TeamRowLength[0] < string.Format("{0:n0}", eTeam.MonsterDestroyed[i]).Length) TeamRowLength[0] = string.Format("{0:n0}", eTeam.MonsterDestroyed[i]).Length;
					if (TeamRowLength[1] < string.Format("{0:n0}", eTeam.MonsterDestroyedGoal[i]).Length) TeamRowLength[1] = string.Format("{0:n0}", eTeam.MonsterDestroyedGoal[i]).Length;
				}
			}
			Label lblHeading = new Label { AutoSize = true, Text = String.Format("\n\nAchievements:") };
			MainPanel.Controls.Add(lblHeading);
			Label lblLifetimeRevenue = new Label { AutoSize = true, Text = String.Format("{0,-24} {1," + RowOneLength[0] + ":n0}/{2," + RowOneLength[1] + ":n0}", "Revenue Aquired", LifetimeRevenue, GoalLifetimeRevenue) };
			MainPanel.Controls.Add(lblLifetimeRevenue);
			Label lblLifetimeGameScore = new Label { AutoSize = true, Text = String.Format("{0,-24} {1," + RowOneLength[0] + ":n0}/{2," + RowOneLength[1] + ":n0}", "Game Score", LifetimeGameScore, GoalLifetimeGameScore) };
			MainPanel.Controls.Add(lblLifetimeGameScore);
			Label lblLifetimeEquipmentForged = new Label { AutoSize = true, Text = String.Format("{0,-24} {1," + RowOneLength[0] + ":n0}/{2," + RowOneLength[1] + ":n0}", "Equipment Forged", LifetimeEquipmentForged, GoalLifetimeEquipmentForged) };
			MainPanel.Controls.Add(lblLifetimeEquipmentForged);
			Label lblLifetimeTeams = new Label { AutoSize = true, Text = String.Format("{0,-24} {1," + RowOneLength[0] + ":n0}/{2," + RowOneLength[1] + ":n0}",     "Teams Created", LifetimeTeams, GoalLifetimeTeams) };
			MainPanel.Controls.Add(lblLifetimeTeams);

			// Add for each team
			foreach (Team eTeam in GameTeams)
			{
				int TotalRobos = 0;
				int totalMonsters = 0;
				FlowLayoutPanel TeamPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblTeamInfo = new Label { AutoSize = true, Text = String.Format("\n{0,-20}", eTeam.getName) };
				MainPanel.Controls.Add(lblTeamInfo);
				Label lblRobotCreated = new Label { AutoSize = true, Text = String.Format("  {0,-20} {1," + TeamHeadingRowLength[0] + ":n0}/{2," + TeamHeadingRowLength[1] + ":n0}", "Robots Created", eTeam.LifetimeRobotsCreated, eTeam.GoalLifetimeRobotsCreated) };
				TeamPanel.Controls.Add(lblRobotCreated);
				Label lblRobotRebuilt = new Label { AutoSize = true, Text = String.Format("  {0,-20} {1," + TeamHeadingRowLength[0] + ":n0}/{2," + TeamHeadingRowLength[1] + ":n0}", "Robots Rebuilt", eTeam.LifetimeRobotsRebuilt, eTeam.GoalLifetimeRobotsRebuilt) };
				TeamPanel.Controls.Add(lblRobotRebuilt);
				Label lblEquipmentPurchased = new Label { AutoSize = true, Text = String.Format("  {0,-20} {1," + TeamHeadingRowLength[0] + ":n0}/{2," + TeamHeadingRowLength[1] + ":n0}", "Equipment Purchased", eTeam.LifetimeEquipmentPurchased, eTeam.GoalLifetimeEquipmentPurchased) };
				TeamPanel.Controls.Add(lblEquipmentPurchased);
				//Label lblEquipmentUpgraded = new Label { AutoSize = true, Text = String.Format("  {0,-20} {1," + TeamHeadingRowLength[0] + ":n0}/{2," + TeamHeadingRowLength[1] + ":n0}", "Equipment Upgraded", eTeam.LifetimeEquipmentUpgraded, eTeam.GoalLifetimeEquipmentUpgraded) };
				//TeamPanel.Controls.Add(lblEquipmentUpgraded);
				FlowLayoutPanel RobotPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				int space = 12 + TeamRowLength[0] + TeamRowLength[1];
				Label lblRobotList = new Label { AutoSize = true, Text = String.Format("  {0,-" + space + "}", "Robots Dest.") };
				RobotPanel.Controls.Add(lblRobotList);
				int[] tmpRobotsDestroyed = (int[])eTeam.RobotDestroyed.Clone();
				int[] tmpRobotsDestroyedKey = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8};
				Array.Sort(tmpRobotsDestroyed, tmpRobotsDestroyedKey);
				for (int i = 0; i < 9; i++)
				{
					TotalRobos += eTeam.RobotDestroyed[tmpRobotsDestroyedKey[i]];
					string tmp = RoboName[tmpRobotsDestroyedKey[i]];
					int tmp2 = eTeam.RobotDestroyed[tmpRobotsDestroyedKey[i]];
					tmp2 = eTeam.RobotDestroyedGoal[tmpRobotsDestroyedKey[i]];
					Label lblRobot = new Label { AutoSize = true, Text = String.Format("  {0,-10} {1," + TeamRowLength[0] + ":n0}/{2," + TeamRowLength[1] + ":n0}", 
																						RoboName[tmpRobotsDestroyedKey[i]], 
																						eTeam.RobotDestroyed[tmpRobotsDestroyedKey[i]], 
																						eTeam.RobotDestroyedGoal[tmpRobotsDestroyedKey[i]]) };
					RobotPanel.Controls.Add(lblRobot);
				}
				Label lblTotalRobots = new Label { AutoSize = true, Text = String.Format("  {0,-10} {1," + (TeamRowLength[0] + TeamRowLength[1] +  1) + ":n0}", "Total Robo", TotalRobos) };
				RobotPanel.Controls.Add(lblTotalRobots);
				FlowLayoutPanel MonsterPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };
				Label lblMonsterList = new Label { AutoSize = true, Text = String.Format("  {0,-" + space + "}", "Monsters Dest.") };
				MonsterPanel.Controls.Add(lblMonsterList);
				int[] tmpMonstersDestroyed = (int[])eTeam.MonsterDestroyed.Clone();
				int[] tmpMonstersDestroyedKey = new int[eTeam.MonsterDestroyed.Length];
				for (int i = 0; i < eTeam.MonsterDestroyed.Length; i++) { tmpMonstersDestroyedKey[i] = i; }
				Array.Sort(tmpMonstersDestroyed, tmpMonstersDestroyedKey);
				for (int i = 0; i < eTeam.MonsterDestroyed.Length; i++)
				{
					totalMonsters += eTeam.MonsterDestroyed[tmpMonstersDestroyedKey[i]];
					Label lblMonster = new Label { AutoSize = true, Text = String.Format("  {0,-10} {1," + TeamRowLength[0] + ":n0}/{2," + TeamRowLength[1] + ":n0}", MonsterName[tmpMonstersDestroyedKey[i]], eTeam.MonsterDestroyed[tmpMonstersDestroyedKey[i]], eTeam.MonsterDestroyedGoal[tmpMonstersDestroyedKey[i]]) };
					MonsterPanel.Controls.Add(lblMonster);
				}
				Label lblTotalMonsters = new Label { AutoSize = true, Text = String.Format("  {0,-10} {1," + (TeamRowLength[0] + TeamRowLength[1] + 1) + ":n0}", "Total Mon", totalMonsters) };
				MonsterPanel.Controls.Add(lblTotalMonsters);
				MainPanel.Controls.Add(TeamPanel);
				MainPanel.Controls.Add(RobotPanel);
				MainPanel.Controls.Add(MonsterPanel);
			}

			// FlowLayoutPanel TeamPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.LeftToRight, AutoSize = true };

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
			Label lblTeamName = new Label { AutoSize = true, Text = String.Format("\n\nTeam Name:  {0}       {1:c0}  ({2}-{3})\nNext Numbr:{7}{4}/{7}{5:n0}/{7}#{5:X}/{7}`{6}", displayTeam.getName,displayTeam.getCurrency,type, StartingCount, ToRoman(getNumeral), getNumeral, ToAlphaNumeric(getNumeral), NumeralChar) };
			Label lblRobots = new Label { AutoSize = true, Text = "Monsters:   " + displayTeam.MyTeam.Count };
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
		public int[] maxNameLength(bool tmpFighting, bool includeKO = false)
		{
			int[] maxLength = 
				{ 10 // Name 
				, 1 // Level
				, 1 // LevelLog
				, 1 // Annalysis
				, 1 // Speed
				, 1 // MP
				, 1 // HP
				, 12 // ShortName
				, 1 // Rank
			};
			if (tmpFighting)
			{
				foreach (Team eTeam in GameTeam1)
					foreach (Robot eRobo in eTeam.MyTeam)
						if (eRobo.getKO <= 3 || includeKO)
							maxLength = checkLength(maxLength, eRobo);
				foreach (Team eTeam in GameTeam2)
					foreach (Robot eRobo in eTeam.MyTeam)
						if (eRobo.getKO <= 3 || includeKO)
							maxLength = checkLength(maxLength, eRobo);
			}
			else
			{
				foreach (Team eTeam in GameTeams)
					foreach (Robot eRobo in eTeam.MyTeam)
						if (eRobo.getKO <= 3 || includeKO)
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
			// Speed
			if (string.Format("{0:n0}", eRobo.getCurrentSpeed).Length > maxLength[4])
				maxLength[4] = string.Format("{0:n0}", eRobo.getCurrentSpeed).Length;
			// MP
			if (string.Format("{0:n0}", eRobo.MP).Length > maxLength[5])
				maxLength[5] = string.Format("{0:n0}", eRobo.MP).Length;
			// HP
			if (string.Format("{0:n0}", eRobo.HP).Length > maxLength[6])
				maxLength[6] = string.Format("{0:n0}", eRobo.HP).Length;
			// Rank
			if (string.Format("{0:n0}", eRobo.getBaseStats()).Length > maxLength[8])
				maxLength[8] = string.Format("{0:n0}", eRobo.getBaseStats()).Length;
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
		public FlowLayoutPanel continueFight(bool display)
		{
			// restore fight log if blank.
			if (FightLog == null || FightLog.Length == 0)
			{
				getFightLog = fightLogSave; 
				getWarningLog = warningLogSave;
				getWinLog = winLogSave;
			}
			roundCount++;
			FlowLayoutPanel MainPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
			MainPanel.Controls.Add(showHeader());
			// Flags to display to user
			String strFlags = "";
			if ((SafeTime - DateTime.Now).TotalHours > 1) strFlags += " (Long Battle)";
			if (bossFight) strFlags += " Boss Fight!";
			if (GameDifficultyFight) strFlags += " Difficulty Fight!";
			if (StartForge) strFlags += " Forge Equipment!";
			if (StartRestock) strFlags += " Restock Concession!";
			if (JackpotUpDown)
			{
				char strOperand = '+';
				if (JackpotMovement < 0)	strOperand = '-';
				strFlags += " Jackpot " + strOperand + JackpotMovement.ToString() + "!";
			}
			if (FastForward) strFlags += string.Format(" Fast Forward {0:n0}!", FastForwardCount);
			if (getGameCurrency < MaxMaintenance()) strFlags += " !Maintenance NSF!";
			Label lblTeamName = new Label { AutoSize = true, Text = "Fight " + showInterval() + strFlags };
			MainPanel.Controls.Add(lblTeamName);
			int KOCount = 3;
			int[] maxTeamLengths = new int[7];
			foreach (Team eTeam in GameTeams)
			{
				if (maxTeamLengths[0] < string.Format("{0:n0}", eTeam.getScore).Length)	maxTeamLengths[0] = string.Format("{0:n0}", eTeam.getScore).Length;
				if (maxTeamLengths[1] < string.Format("{0:n0}", eTeam.getScoreLog).Length) maxTeamLengths[1] = string.Format("{0:n0}", eTeam.getScoreLog).Length;
				if (maxTeamLengths[2] < string.Format("{0:c0}", eTeam.getCurrency).Length) maxTeamLengths[2] = string.Format("{0:c0}", eTeam.getCurrency).Length;
				if (maxTeamLengths[3] < string.Format("{0:c0}", eTeam.CurrencyLog).Length) maxTeamLengths[3] = string.Format("{0:c0}", eTeam.CurrencyLog).Length;
				if (maxTeamLengths[4] < string.Format("{0:n0}", eTeam.Win).Length) maxTeamLengths[4] = string.Format("{0:n0}", eTeam.Win).Length;
				if (maxTeamLengths[5] < string.Format("{0:n0}", eTeam.getDifficulty).Length) maxTeamLengths[5] = string.Format("{0:n0}", eTeam.getDifficulty).Length;
				if (maxTeamLengths[6] < string.Format("{0:n0}", eTeam.DifficultyLog).Length) maxTeamLengths[6] = string.Format("{0:n0}", eTeam.DifficultyLog).Length;
			}
			for (int i = 0; i < GameTeam1.Count; i++)
			{
				if (GameTeam1[i].getNumRobos(true, KOCount) > 0 && GameTeam2[i].getNumRobos(true, KOCount) > 0)
				{
					getNext(i);
					bool includeKO = roundCount < 20;
					if (display)
					{
						char goalScore = ' ';
						// Display if teams will leave the arena
						if (getScore() > (getGoalGameScore / 3) && getGameCurrency < 0) goalScore = '!';
						string strFormat = "TP:{1:n0}{7} {0:c0} D:{3:n0} J:{4:n0} L:{5:n0}";
						if (roundCount < 20 && GameTeam1[0].getName != "Arena" && !GameTeam2[0].isMonster)
							strFormat = "TP:{1:n0}{7}->{2:n0} {0:c0} D:{3:n0} J:{4:n0} L:{5:n0}";
						else if (roundCount < 20 && GameTeam1[0].getName == "Arena")
							strFormat = "TP:{1:n0}{7}->{2:n0} {0:c0} D:{3:n0} J:{6:n0}";
						else if (GameTeam1[0].getName == "Arena")
							strFormat = "TP:{1:n0}{7} {0:c0} D:{3:n0} J:{6:n0}";
						else if (GameTeam2[0].isMonster)
							strFormat = "TP:{1:n0}{7} {0:c0} D:{3:n0} J:{4:n0}"; // Monster fight, only show winning jackpot
						if (auto)
						{
							if (i == 0)
							{
								Label lblGameStats = new Label { AutoSize = true, Text = String.Format(strFormat, getGameCurrency, getScore(), getScoreLog(), gameDifficulty, Jackpot - MinWage, MinWage, Jackpot, goalScore) };
								MainPanel.Controls.Add(lblGameStats);
							}
							Color background = Color.Transparent;
							if (i % 2 == 1)
								background = Color.LightGray;
							Label lblTeam1stats = new Label { AutoSize = true, BackColor = background, Text = GameTeam1[i].getTeamStats(maxNameLength(true, includeKO), maxTeamLengths, ResearchDevRebuild, KOCount, this, roundCount, true) };
							int tmpI = i;
							MainPanel.Controls.Add(lblTeam1stats);
							Label lblTeam2stats = new Label { AutoSize = true, BackColor = background, Text = GameTeam2[i].getTeamStats(maxNameLength(true, includeKO), maxTeamLengths, ResearchDevRebuild, KOCount, this, roundCount, true) };
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
							Label lblGameStats = new Label { AutoSize = true, Text = String.Format(strFormat, getGameCurrency, getScore(), getScoreLog(), gameDifficulty, Jackpot - MinWage, MinWage, Jackpot, goalScore) };
							if (GameTeam1[0].getName == "Arena") lblGameStats = new Label { AutoSize = true, Text = String.Format("TP:{1:n0}({2:n0}) {0:c0} D:{3:n0} J:{4:n0} ", getGameCurrency, getScore(), getScoreLog(), gameDifficulty, Jackpot) };
							MainPanel.Controls.Add(lblGameStats);
							Label lblVS2 = new Label { AutoSize = true, Text = String.Format("{0} P:{1:n0} {2:c0} D:{3:n0}",GameTeam2[i].getName,GameTeam2[i].getScore,GameTeam2[i].getCurrency, GameTeam2[i].getDifficulty) };
							MainPanel.Controls.Add(lblVS2);
							MainPanel.Controls.Add(Team2);
							foreach (Robot eRobo in GameTeam1[i].MyTeam)
							{
								if (eRobo.getKO < 10)
								{
									Team1.Controls.Add(getCharacterInfo(eRobo));
								}
							}
							Label lblVS1 = new Label { AutoSize = true, Text = String.Format("{0} P:{1:n0} {2:c0} D:{3:n0}", GameTeam1[i].getName, GameTeam1[i].getScore, GameTeam1[i].getCurrency, GameTeam1[i].getDifficulty) };
							MainPanel.Controls.Add(lblVS1);
							MainPanel.Controls.Add(Team1);
						}
					}
					else
					{
						if (DateTime.Now > BreakTime)
						{
							GameTeam1[i].getTeamStats(maxNameLength(true, includeKO), maxTeamLengths, ResearchDevRebuild, KOCount, this);
							GameTeam2[i].getTeamStats(maxNameLength(true, includeKO), maxTeamLengths, ResearchDevRebuild, KOCount, this);
						}
					}
				}
				else
				{
					// if total score is a multiple of 100 reset logs. 
					if (getScore() % 100 == 0) resetAuto();

					if (GameTeam1[i].getName.Equals("Arena"))
					{
						// reset skill chars
						resetSkillChars();
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
								getWarningLog = lblWinner.Text = getFightLog = Environment.NewLine + " +++ Arena defeated monsters difficulty increased ";
								Jackpot = 0;
								resetPartialScore();
								GameTeam1[0].healRobos(false);
								equip(GameTeam1[0], true);
							}
							// Boss Fight
							else
							{
								lblWinner.Text = getWarningLog = bossLevelUp();
								MaxTeams++;
								GoalGameScore = (int)roundValue(GoalGameScore, (100 * gameDifficulty), "up");
								if (getScore() >= GoalGameScore)	resetScore();
								else								resetPartialScore();
							}
						}
						else
						{
							if (GameTeam2[i].getName.Equals("Monster Outbreak"))
							{
								lblWinner.Text = getWarningLog = getFightLog = Environment.NewLine + "--- Arena suffered damages from Monster outbreak -" + String.Format("{0:n0} ({1}%)", Jackpot, findMonster) ;
								// reset findMonster
								findMonster = 5;
								getGameCurrency -= Jackpot;
								GameCurrencyLogMaint -= Jackpot;
							}
							else if (GameTeam2[i].getName.Equals("Game Diff " + gameDifficulty.ToString()))
							{
								Jackpot = 0;
								getWarningLog = lblWinner.Text = getFightLog = Environment.NewLine + "--- Arena lost to monsters ";
								// Decrease difficulty after many losses
								if (RndVal.Next(100) < DiffLosses++)
								{
									gameDifficulty = RndVal.Next(gameDifficulty);
									getWarningLog = lblWinner.Text = getFightLog = Environment.NewLine + "--- Difficulty decreased ";
									DiffLosses = 0;
								}
							}
							else
							{
								string tmp = getWarningLog = getFightLog = Environment.NewLine + "Arena suffered a loss against the boss monsters! ";
								lblWinner.Text = tmp;
								// Decrease boss level after many losses
								if (RndVal.Next(100) < bossLosses++)
								{
									getWarningLog = lblWinner.Text = getFightLog = bossLevelDown();
									bossLosses = 0;
								}
								if (getScore() >= GoalGameScore)
								{
									GoalGameScore = (int)roundValue(GoalGameScore, (10 * gameDifficulty), "up");
									resetScore();
								}
							}
						}
						GameTeam1.Clear();
						GameTeam2.Clear();
						Jackpot = 0;
						getWinLog = lblWinner.Text;
						MainPanel.Controls.Add(lblWinner);
						fighting = false;
					}
					else
					{
						bool newMonster = false;
						if (i == 0)
						{
							// Reset Skills char
							resetSkillChars();
							string msg = "";
							Label lblWinner = new Label { AutoSize = true };
							if (GameTeam1[i].getNumRobos(false) > 0)
							{
								FightBreakCount = 0;
								lblWinner.Text = GameTeam1[i].getName + " wins!";
								long tmp = (long)(Jackpot - MinWage );
								GameTeam1[i].getCurrency += tmp;
								Jackpot -= tmp;
								// msg += " " + String.Format("{0:n0}", tmp);
								// increase difficulty if monster
								if (GameTeam2[i].isMonster)
								{
									WinCount++;
									// increase difficulty if not greater than monsterDenLvl
									if (GameTeam1[i].getDifficulty < MonsterDenLvl)
									{
										GameTeam1[i].getDifficulty++; 
										// fight next difficulty
										Jackpot += MinWage;
										getGameCurrency -= MinWage;
										totalRev -= MinWage;
										Team tmpTeam = new Team(GameTeam1[i].getDifficulty, getMonsterDenLvlImage(), findMonster, ref MonsterOutbreak);
										addMonsters(GameTeam2[i]);
										GameTeam2[i] = tmpTeam;
										msg = string.Format("{0} VS {1} R:({2:n0}) {3}", GameTeam1[i].getName, GameTeam2[i].getName, MinWage, msg);
										GameTeam1[i].healRobos(false);
										GameTeam1[i].resetSpeed();
										equip(GameTeam1[i], true);
										newMonster = true;
									}
									else
									{
										// calculate Seating available
										int SeatsAvaial = 0;
										foreach (ArenaSeating eSeating in CurrentSeating) { SeatsAvaial += eSeating.Amount - eSeating.Attendees; }
										msg = string.Format("\n{0} Won against {1} TR:--->{2:c0}<--- {3}\n    Seating Available:{4:n0}", GameTeam1[i].getName, GameTeam2[i].getName, totalRev, msg, SeatsAvaial);
										if (SeatsAvaial > 0)
											NeedAdvertising++;
										else
											NeedAdvertising = 0;
									}
								}
								else
								{
									// increase score 
									GameTeam1[i].getScore++;
									addLifetimeScore();
									// Try boss fight 
									if (getScore() >= GoalGameScore && !GameTeam2[0].getName.Equals("Game Diff " + gameDifficulty.ToString())) 
										bossFight = true;
									// pay team 2 remaining;
									GameTeam2[i].getCurrency += Jackpot;
									// calculate Seating available
									int SeatsAvaial = 0;
									foreach (ArenaSeating eSeating in CurrentSeating) { SeatsAvaial += eSeating.Amount - eSeating.Attendees; }
									msg = string.Format("\n{0} Won against {1} TR:--->{2:c0}<--- {3}\n    Seating Available:{4:n0}", GameTeam1[i].getName, GameTeam2[i].getName, totalRev, msg, SeatsAvaial);
									Jackpot = 0;
									if (SeatsAvaial > 0)
										NeedAdvertising++;
									else
										NeedAdvertising = 0;
								}
							}
							else
							{
								FightBreakCount = 0;
								lblWinner.Text = GameTeam2[i].getName + " winns!";
								GameTeam2[i].getScore++;
								// Try boss fight 
								if  (getScore() >= GoalGameScore && !GameTeam2[0].getName.Equals("Arena")) bossFight = true;
								// if winning team has a lower score than loosing team, steal one point. 
								if (GameTeam1[i].getScore > GameTeam2[i].getScore && !GameTeam2[i].isMonster)
								{
									GameTeam1[i].getScore--;
									GameTeam2[i].getScore++;
								}
								// monster won
								if (GameTeam2[i].isMonster)
								{
									// Arena recoups costs
									long tmp = (long)(Jackpot - MinWage);
									getGameCurrency += tmp;
									GameTeam1[i].getCurrency += MinWage;
									Jackpot = 0;
									// calculate Seating available
									int SeatsAvaial = 0;
									foreach (ArenaSeating eSeating in CurrentSeating) { SeatsAvaial += eSeating.Amount - eSeating.Attendees; }
									msg = string.Format("\n{1} Won against {0} TR:--->{2:c0}<--- Win:{3:n0} {4}\n    Seating Available:{5:n0}", GameTeam1[i].getName, GameTeam2[i].getName, totalRev, WinCount, msg, SeatsAvaial);
									if (SeatsAvaial > 0)
										NeedAdvertising++;
									else
										NeedAdvertising = 0;
									//msg += String.Format("\n Win:{0}", WinCount);
									int lastRobo = GameTeam1[i].MyTeam.Count - 1;
									// if team looses against difficulty where highest level is lower than the lowest level of robot on team, low chance to add new robo to the team. 
									if (GameTeam1[i].getDifficulty * 5 < GameTeam1[i].MyTeam[lastRobo].getLevel && GameTeam1[i].getScore < GameTeam1[0].getScore / 4)
									{
										long lProffitSharing = 0;
										if (getGameCurrency > 0)
										{
											lProffitSharing = getGameCurrency / (GameTeam1[i].Win + 2);
											getGameCurrency -= lProffitSharing;
										}
										foreach (Team eTeam in GameTeams)
										{
											int factor = 10 - eTeam.Win;
											if (factor <= 0) factor = 1;
											if (eTeam.getCurrency > 0 && !eTeam.getName.Equals(GameTeam1[i].getName))
											{
												lProffitSharing += eTeam.getCurrency / factor;
												eTeam.getCurrency -= eTeam.getCurrency / factor;
											}
										}
										GameTeam1[i].getCurrency += lProffitSharing;
										if (WinCount == 0) GameTeam1[i].getDifficulty = 1;
										getFightLog = getWarningLog = string.Format("\n!*!* {0} received proffit sharing! {1:c0}", GameTeam1[i].getName, lProffitSharing);
									}
								}
								else
								{
									// team won 
									addLifetimeScore();
									long tmp = (long)(Jackpot - MinWage);
									GameTeam2[i].getCurrency += tmp;
									Jackpot -= tmp;
									// team lost gets remaining
									GameTeam1[i].getCurrency += Jackpot;
									// calculate Seating available
									int SeatsAvaial = 0;
									foreach (ArenaSeating eSeating in CurrentSeating) { SeatsAvaial += eSeating.Amount - eSeating.Attendees; }
									msg = string.Format("\n{1} Won against {0} TR:--->{2:c0}<--- {3}\n    Seating Available:{4:n0}", GameTeam1[i].getName, GameTeam2[i].getName, totalRev, msg, SeatsAvaial);
									Jackpot = 0;
									if (SeatsAvaial > 0)
										NeedAdvertising++;
									else
										NeedAdvertising = 0;
								}
							}
							getFightLog = Environment.NewLine + msg;
							getWinLog = lblWinner.Text;
							MainPanel.Controls.Add(lblWinner);
							if (!newMonster)
							{
								Jackpot = 0;
								fighting = false;
								// keep track of how many times totalRevenue is less than zero in a row
								if (totalRev < 0) { totalRevCount++; }
								else { totalRevCount = 0; }
								// reset total revenue
								totalRev = 0;
								// if total revenue is less than zero 3 or more times decrease the minWage given to loosing team
								if (totalRevCount >= 3 && GameCurrency < 0)
								{
									MinWage--;
									if (MinWage < 3) MinWage = 3;
								}
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
								if (getScore() % 100 == 0 && !GameTeam2[0].isMonster) employeePayroll();
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
						{
							Label lblTeamstats = new Label { AutoSize = true, Text = eTeam.getTeamStats(maxNameLength(false, roundCount < 20), maxTeamLengths, ResearchDevRebuild, KOCount, this, roundCount, false, false) };
							MainPanel.Controls.Add(lblTeamstats);
						}
					}
					if (getWarningLog.Length > 0)
					{
						Label lblWarningLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Bold, GraphicsUnit.Pixel), Text = Environment.NewLine + "Warnings:" + getWarningLog };
						lblWarningLog.Click += new EventHandler((sender, e) => clearWarnings());
						MainPanel.Controls.Add(lblWarningLog);
					}
					if (getWinLog.Length > 0)
					{
						Label lblWinLog = new Label { AutoSize = true, Font = new Font(new FontFamily("Courier New"), 12, FontStyle.Underline, GraphicsUnit.Pixel), Text = Environment.NewLine + getWinLog };
						lblWinLog.Click += new EventHandler((sender, e) => clearWarnings());
						MainPanel.Controls.Add(lblWinLog);
					}
					Label lblFightLog = new Label { AutoSize = true, Text = Environment.NewLine + "Fight Log:" + Environment.NewLine + getFightLog };
					MainPanel.Controls.Add(lblFightLog);
				}
			}
			return MainPanel;
		}

		public void resetSkillChars()
		{
			foreach (Team eTeam in GameTeams)
			{
				foreach (Robot eRobo in eTeam.MyTeam) eRobo.cSkill = ' ';
			}
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
							if (type < 15)
								eMonster.getName += NumeralChar + ToRoman(getNumeral++);
							else if (type < 25)
								eMonster.getName += string.Format("{0}{1:N0}", NumeralChar, getNumeral++);
							else if (type < 35)
								eMonster.getName += string.Format("{0}#{1:X}", NumeralChar, getNumeral++);
							else if (type < 50)
								eMonster.getName += NumeralChar + "~" + ToAlphaNumeric(getNumeral++);
							else
								eMonster.getName = string.Format("{0} {1}", name1[RndVal.Next(name1.Length)], eMonster.getName);
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
			for (int i = 0; i < ShopBays; i++)
			{
				equip(GameTeams[RndVal.Next(GameTeams.Count)], false);
			}
		}
		public int IncreaseJackpot()
		{
			if (JackpotMovement > 0)
			{
				CurrentJackpotLvl++;
				CurrentJackpot = roundValue(CurrentJackpot, RndVal.Next(1, CurrentJackpotBase), "up");
				CurrentJackpotBase += CurrentJackpotBaseIncrement;
				JackpotMovement--;
			}
			if (JackpotMovement < 0)
			{
				if (CurrentJackpot > (MinWage * 2))
				{
					CurrentJackpotLvl--;
					CurrentJackpot = roundValue(CurrentJackpot, RndVal.Next(CurrentJackpotBase), "down");
					CurrentJackpotBase -= CurrentJackpotBaseIncrement;
					JackpotMovement++;
				}
				else
				{ JackpotMovement = 0; }
			}
			if (JackpotMovement == 0) JackpotUpDown = false;
			return CurrentJackpot;
		}
		public void CheckMinJackpot()
		{
			// current Jackpot reset to min level
			if (CurrentJackpotLvl < 1 || CurrentJackpot < 1 || CurrentJackpotBase < 1)
			{
				CurrentJackpot = 3;
				CurrentJackpotLvl = 1;
				CurrentJackpotBase = 1;
			}
			while (CurrentJackpot < (MinWage * 2))
			{
				JackpotMovement++;
				IncreaseJackpot();
			}
		}
		public void equip(Team eTeam, bool checkFight)
		{
			Robot shopper;
			Robot monster;
			if (GameTeam1 == null || GameTeam1.Count == 0 || checkFight)
			{
				shopper = eTeam.MyTeam[RndVal.Next(0, eTeam.MyTeam.Count)];
				bool bAutomated = eTeam.Automated;
				bool bManualEquipment = eTeam.Manual_Equipment;
				// Automated teams automatically build new robots and rebuild robots
				if ( PurchaseUpgrade || bAutomated )
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
								getGameCurrency += eTeam.Rebuild(i, true, this);
							}
						}
					}
				}

				// buy highest level weapon you can afford
				Equipment purchase = new Equipment(true, 1, 1, RndVal);
				purchase.ePrice = 0;
				if (shopper.getEquipWeapon != null)
				{
					purchase = shopper.getEquipWeapon;
				}
				foreach (Equipment eEquip in storeEquipment.ToList())
				{
					if (eTeam.getCurrency > eEquip.ePrice && (purchase.eUpgrade < eEquip.eUpgrade || purchase.ePrice == 0)
						&& eEquip.eType == "Weapon"
						&& ((PurchaseUpgrade && !RobotPriority)
								|| bAutomated
								|| ((!bAutomated && bManualEquipment) || shopper.getEquipWeapon is null)))
					{
						purchase = eEquip;
					}
                    // get rid of stale merchandice that isn't selling
                    staleMerchandice(eEquip);
                }
				// purchase weapon if team has the money and it is not the weapon they already have equipped
				if (eTeam.getCurrency > purchase.ePrice && purchase.ePrice > 0
					&& (shopper.getEquipWeapon is null || (shopper.getEquipWeapon != null && purchase.eUpgrade > shopper.getEquipWeapon.eUpgrade))
					&& (shopper.getEquipWeapon is null || !shopper.getEquipWeapon.Equals(purchase)))
				{
					string msg = "";
					if (shopper.getEquipWeapon != null)
						msg = string.Format("\n     replacing {0}",shopper.getEquipWeapon.getName());
					eTeam.getCurrency -= purchase.ePrice;
					GameCurrency += purchase.ePrice;
					GameCurrencyLogMisc += purchase.ePrice;
					addLifetimeRevenue(purchase.ePrice);
					// ensure durability is at max 
					purchase.eDurability = purchase.eMaxDurability;
                    shopper.getEquipWeapon = purchase;
					eTeam.AddEquipmentPurchased();
					storeEquipment.Remove(purchase);
					msg = Environment.NewLine + " $$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", purchase.ePrice, purchase.eName) + Environment.NewLine + "   " + purchase.ToString() + msg;
					eTeam.getTeamLog = getFightLog = msg;
					if (!eTeam.Automated) getWarningLog = msg;
				}
				// repair weapon if not null
				if (shopper.getEquipWeapon != null)
				{
					int orig = shopper.getEquipWeapon.eDurability;
					if (eTeam.getCurrency > (shopper.getEquipWeapon.ePrice / 10)
						&& shopper.getEquipWeapon.eDurability < shopper.getEquipWeapon.eMaxDurability * repairPercent 
						&& shopper.getEquipWeapon.eMaxDurability > 20)
					{
						shopper.getEquipWeapon.eDurability = shopper.getEquipWeapon.eMaxDurability = (int)(shopper.getEquipWeapon.eMaxDurability * .9);
						eTeam.getCurrency -= 25;
						getGameCurrency += 25;
						addLifetimeRevenue(25);
						eTeam.getTeamLog = getFightLog = Environment.NewLine + " ### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", 25, shopper.getEquipWeapon.eName) + Environment.NewLine + "   " + shopper.getEquipWeapon.ToString(orig);
					}
				}
				// buy highest level armour you can afford
				purchase = new Equipment(false, 1, 1, RndVal);
				purchase.ePrice = 0;
				if (shopper.getEquipArmour != null)
				{
					purchase = shopper.getEquipArmour;
				}
				foreach (Equipment eEquip in storeEquipment.ToList())
				{
					if (eTeam.getCurrency > eEquip.ePrice && (purchase.eUpgrade < eEquip.eUpgrade || purchase.ePrice == 0)
						&& eEquip.eType == "Armour"
						&& ((PurchaseUpgrade && !RobotPriority)
								|| bAutomated
								|| ((!bAutomated && bManualEquipment) || shopper.getEquipArmour is null)))
					{
						purchase = eEquip;
                    }
                    // get rid of stale merchandice that isn't selling
                    staleMerchandice(eEquip);
                }
				// purchase weapon if team has the money and it is not the weapon they already have equipped
				if (eTeam.getCurrency > purchase.ePrice && purchase.ePrice > 0
					&& (shopper.getEquipArmour is null || (shopper.getEquipArmour != null && purchase.eUpgrade > shopper.getEquipArmour.eUpgrade))
					&& (shopper.getEquipArmour is null || !shopper.getEquipArmour.Equals(purchase)))
				{
					string msg = "";
					if (shopper.getEquipArmour != null)
						msg = string.Format("\n      replacing {0}", shopper.getEquipArmour.getName());
					eTeam.getCurrency -= purchase.ePrice;
					GameCurrency += purchase.ePrice;
					GameCurrencyLogMisc += purchase.ePrice;
					addLifetimeRevenue(purchase.ePrice);
					// ensure durability is at max
                    purchase.eDurability = purchase.eMaxDurability;
                    shopper.getEquipArmour = purchase;
					eTeam.AddEquipmentPurchased();
					storeEquipment.Remove(purchase);
					msg = Environment.NewLine + " $$$ " + eTeam.getName + ":" + shopper.getName + " purchased " + String.Format("{1} ({0:n0}) ", purchase.ePrice, purchase.eName) + Environment.NewLine + "   " + purchase.ToString() + msg;
					eTeam.getTeamLog = getFightLog = msg;
					if (!eTeam.Automated) getWarningLog = msg;
				}
				// Repair armour if not null
				if (shopper.getEquipArmour != null)
				{
					int orig = shopper.getEquipArmour.eDurability;
					// Repair 
					if (eTeam.getCurrency > (shopper.getEquipArmour.ePrice / 10)
						&& shopper.getEquipArmour.eDurability < shopper.getEquipArmour.eMaxDurability * repairPercent
						&& shopper.getEquipArmour.eMaxDurability > 20)
					{
						shopper.getEquipArmour.eDurability = shopper.getEquipArmour.eMaxDurability = (int)(shopper.getEquipArmour.eMaxDurability * .9);
						eTeam.getCurrency -= 25;
                        getGameCurrency += 25;
                        addLifetimeRevenue(25);
                        eTeam.getTeamLog = getFightLog = Environment.NewLine + " ### " + eTeam.getName + ":" + shopper.getName + " Repaired " + String.Format("{1} ({0:n0}) ", 25, shopper.getEquipArmour.eName) + Environment.NewLine + "   " + shopper.getEquipArmour.ToString(orig);
					}
				}
				
				// Rebuild Monster
				if (MonsterOutbreak.MyTeam.Count > 0 && SafeTime >= DateTime.Now && !paused && checkFight)
				{
					monster = MonsterOutbreak.MyTeam[RndVal.Next(0, MonsterOutbreak.MyTeam.Count)];
					if ((monster.rebuildCost(ResearchDevRebuild, eTeam.Runes) > 100) && RndVal.Next(1000) < MonsterDenLvl)
						MonsterOutbreak.Rebuild(monster, false, this);
					// Repair Monster Weapon
					if (monster.getEquipWeapon != null)
					{
						if (RndVal.Next(1000 + (monster.getEquipWeapon.eUpgrade * 1000)) < MonsterDenLvl)
						{
							string strUpgrade = monster.getEquipWeapon.upgrade(monster.getLevel + monster.type, RndVal);
							getFightLog = string.Format("\n [M] Monsert:{0} claws strengthened {1}", monster.getName, strUpgrade);
						}
						else if (monster.getEquipWeapon.eDurability < monster.getEquipWeapon.eMaxDurability * .5 )
						{
							int orig = monster.getEquipWeapon.eDurability;
							monster.getEquipWeapon.eDurability = monster.getEquipWeapon.eMaxDurability = (int)(monster.getEquipWeapon.eMaxDurability * .9);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " claws healed " + Environment.NewLine + "  " + monster.getEquipWeapon.ToString(orig);
						}
					}
					else
					{
						// Add Weapon
						Equipment tmp = new Equipment(true, RndVal.Next(1, monster.getLevel + monster.type), RndVal.Next(100, (monster.getLevel + 100)), RndVal);
						tmp.eName = "Claw";
						monster.getEquipWeapon = tmp;
						getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " regrew claw" + Environment.NewLine + "  " + tmp.ToString();
					}
					// Repair Monster Armour
					if (monster.getEquipArmour != null)
					{
						if (RndVal.Next(1000 + (monster.getEquipWeapon.eUpgrade * 1000)) < MonsterDenLvl)
						{
							string strUpgrade = monster.getEquipArmour.upgrade(monster.getLevel + monster.type, RndVal);
							getFightLog = string.Format("\n [M] Monster:{0} hide strengthened {1}", monster.getName, strUpgrade);
						}
						else if (monster.getEquipArmour.eDurability < monster.getEquipArmour.eMaxDurability * .5)
						{
							int orig = monster.getEquipArmour.eDurability;
							monster.getEquipArmour.eDurability = monster.getEquipArmour.eMaxDurability = (int)(monster.getEquipArmour.eMaxDurability * .9);
							getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " hide healed " + Environment.NewLine + "  " + monster.getEquipArmour.ToString(orig);
						}
					}
					else
					{
						// Add Armour
						Equipment tmp = new Equipment(false, RndVal.Next(1, monster.getLevel + monster.type), RndVal.Next(100, (monster.getLevel + 100)), RndVal);
						tmp.eName = "Hide";
						monster.getEquipArmour = tmp;
						getFightLog = Environment.NewLine + " [M] Monster:" + monster.getName + " regrew hide" + Environment.NewLine + "  " + tmp.ToString();
					}

				}
			}
		}
		public void staleMerchandice(Equipment eEquip)
		{
			// don't wear out the equipment too fast.
			if (RndVal.Next(1000) > 998)
			{
				if (--eEquip.eDurability <= 0)
                {
					getWarningLog = getFightLog = string.Format("\n *!*! {0} did not sell and was taken off the shelf",eEquip.getName());
                    storeEquipment.Remove(eEquip);
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
			// return random value
			return retVal + RndVal.Next((int)value);
		}
		public void employeePayroll()
		{
			long MaintCost = 0;
			long employees = 0;
			// Pay employees
			for (int i = 0; i < Seating.Count; i++)
			{
				MaintCost += (Seating[i].Amount / 25) * (Seating[i].Level * 10);
				employees += Seating[i].Amount / 25;
			}
			getGameCurrency -= MaintCost;
			GameCurrencyLogMaint -= MaintCost;
			getFightLog = string.Format("\n\n$!! Payroll processed - cost {0:c0} employees {1:n0}", MaintCost, employees);
			// If divisible by 10000 start boss Fight
			if		(getScore() % 10000 == 0) bossFight = true;
			// If divisible by 1000 start difficulty Fight
			else if (getScore() % 1000 == 0 || (GoalGameScore < 1000 && getScore() != GoalGameScore)) GameDifficultyFight = true;
		}
		public void buildingMaintenance()
		{
			long MaintCost = 0;
			string strMessage = "";
			long maintValue = RndVal.Next(200);
			// if arena is in debt, none of the benefits are available (Monster den bonus, Equipment upgrades, Repair bay, etc) so no maintenance required.
			if (getGameCurrency <= 0)
				maintValue = RndVal.Next(60, 260);
			// maintValue = 43; //test 
			switch (maintValue)
			{
				case 1:
					if (RndVal.Next(100) > ArenaLvlMaintCondition)
					{
						// Arena Maintenance
						if (ArenaLvlMaint > 0)
							MaintCost += roundValue(getArenaLvlMaint);
						else
						{
							MaintCost += Math.Abs(getArenaLvlMaint);
							if (MaintCost > longRandom(getArenaLvlCost) && getArenaLvlCost > MainLvlCostBase)
							{
								getArenaLvlCost = roundValue(getArenaLvlCost, MainLvlCostBase, "down");
								if (getArenaLvlCost < MainLvlCostBase)
								{
									getArenaLvlCost = MainLvlCostBase;
									MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
								}
								getArenaLvlMaint = getArenaLvlCost / 2;
								getWarningLog = getFightLog = String.Format("\n*** Arena Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getArenaLvlCost, MaintCost, getArenaLvlMaint);
							}
						}
						getArenaLvlMaint = roundValue(ArenaLvlMaint, (int)((double)MaintCost * 0.1), "down");
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						getFightLog = Environment.NewLine + "*** Arena: !boiler replaced - cost " + String.Format("{0:c0}/{1:c0}", MaintCost, getArenaLvlMaint);
						// reset maintenance condition
						ArenaLvlMaintCondition = 95;
					}
					else
					{
						// increase chance for maintenance to be required
						ArenaLvlMaintCondition -= 10;
					}
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
					if (RndVal.Next(100) > ShopLvlMaintCondition)
					{
						// Shop Maintenance
						if (getShopLvlMaint > 0)
							MaintCost = roundValue(getShopLvlMaint);
						else
						{
							MaintCost = Math.Abs(getShopLvlMaint);
							// if maintenace is more than half the cost to upgrade / rebuild
							if (MaintCost > longRandom(getShopLvlCost) && getShopLvlCost > MainLvlCostBase)
							{
								getShopLvlCost = roundValue(getShopLvlCost, MainLvlCostBase, "down");
								if (getShopLvlCost < MainLvlCostBase)
								{
									getShopLvlCost = MainLvlCostBase;
									MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
								}
								getShopLvlMaint = getShopLvlCost / 2;
								getWarningLog = getFightLog = String.Format("\n*** Shop Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getShopLvlCost, MaintCost, getShopLvlMaint);
							}
						}
						getShopLvlMaint = roundValue(ShopLvlMaint, (int)((double)MaintCost * 0.1), "down");
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						getFightLog = Environment.NewLine + "*** Shop: !forge replaced - cost " + string.Format("{0:c0}/{1:c0}", MaintCost, getShopLvlMaint);
						// reset maintenance condition
						ShopLvlMaintCondition = 95;
					}
					else
					{
						// increase chance for maintenance to be required
						ShopLvlMaintCondition -= 10;
					}
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
						if (MaintCost > longRandom(getShopLvlCost) && getShopLvlCost > MainLvlCostBase)
						{
							getShopLvlCost = roundValue(getShopLvlCost, MainLvlCostBase, "down");
							if (getShopLvlCost < MainLvlCostBase)
							{
								getShopLvlCost = MainLvlCostBase;
								MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
							}
							getShopLvlMaint = getShopLvlCost / 2;
							getWarningLog = getFightLog = String.Format("\n*** Shop Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getShopLvlCost, MaintCost, getShopLvlMaint);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getShopLvlMaint = roundValue(ShopLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Shop: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getShopLvlMaint);
					ShopLvlMaintCondition--;
					break;
				case 21:
					if (RndVal.Next(100) > ResearchDevLvlMaintCondition)
					{
						// Research and Development Maintenance
						if (ResearchDevMaint > 0)
							MaintCost = roundValue((getResearchDevMaint));
						else
						{
							MaintCost = Math.Abs(getResearchDevMaint);
							if (MaintCost > longRandom(getResearchDevLvlCost) && getResearchDevLvlCost > MainLvlCostBase)
							{
								getResearchDevLvlCost = roundValue(getResearchDevLvlCost, MainLvlCostBase, "down");
								if (getResearchDevLvlCost < MainLvlCostBase)
								{
									getResearchDevLvlCost = MainLvlCostBase;
									MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
								}
								ResearchDevMaint = getResearchDevLvlCost / 2;
								getWarningLog = getFightLog = String.Format("\n*** R and D Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getResearchDevLvlCost, MaintCost, getResearchDevMaint);
							}
						}
						getResearchDevMaint = roundValue(ResearchDevMaint, (int)((double)MaintCost * 0.1), "down");
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						getFightLog = Environment.NewLine + "*** R&&D: !experiment explosion - cost " + String.Format("{0:n0}/{1:c0}", MaintCost, getResearchDevMaint);
						// reset maintenance condition
						ResearchDevLvlMaintCondition = 95;						
					}
					else
					{
						// increase chance for maintenance to be required
						ResearchDevLvlMaintCondition -= 10;
					}
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
						if (MaintCost > longRandom(getResearchDevLvlCost) && getResearchDevLvlCost > MainLvlCostBase)
						{
							getResearchDevLvlCost = roundValue(getResearchDevLvlCost, MainLvlCostBase, "down");
							if (getResearchDevLvlCost < MainLvlCostBase)
							{
								getResearchDevLvlCost = MainLvlCostBase;
								MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
							}
							ResearchDevMaint = getResearchDevLvlCost / 2;
							getWarningLog = getFightLog = String.Format("\n*** R&&D Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getResearchDevLvlCost, MaintCost, getResearchDevMaint);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getResearchDevMaint = roundValue(ResearchDevMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** R&&D: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getResearchDevMaint);
					// increase chance for maintenance to be required
					ResearchDevLvlMaintCondition--;
					break;
				case 31:
					// Monster Den high Maintenance 
					if (getMonsterDenLvlMaint > 0) MaintCost += ((getMonsterDenLvlMaint) / 10);
					else MaintCost += Math.Abs((getMonsterDenLvlMaint) / 10);
					if (strMessage.Length == 0) strMessage = "!!Major Outbreak";
					goto case 32;
				case 32:
					if (RndVal.Next(100) > MonsterDenLvlMaintCondition)
					{
						// Monster Den Maintenance
						if (MonsterDenLvlMaint > 0)
							MaintCost += (getMonsterDenLvlMaint);
						else
						{
							MaintCost += Math.Abs(MonsterDenLvlMaint);
							if (MaintCost > longRandom(MonsterDenLvlCost) && MonsterDenLvlCost > MainLvlCostBase)
							{
								getMonsterDenLvlCost = roundValue(getMonsterDenLvlCost, MainLvlCostBase, "down");
								if (getMonsterDenLvlCost < MainLvlCostBase)
								{
									getMonsterDenLvlCost = MainLvlCostBase;
									MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
								}
								MonsterDenLvlMaint = getMonsterDenLvlCost / 2;
								getWarningLog = getFightLog = String.Format("\n*** Monster Den: !Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getMonsterDenLvlCost, MaintCost, getMonsterDenLvlMaint);
							}
						}
						// split value in two
						long monsterOutbreakCost = roundValue(longRandom(MaintCost));
						startMonsterOutbreak(monsterOutbreakCost);
						MaintCost = roundValue(MaintCost - monsterOutbreakCost);
						getMonsterDenLvlMaint = roundValue(MonsterDenLvlMaint, (int)((double)MaintCost * 0.15), "down");
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						if (strMessage.Length == 0) strMessage = "!Outbreak";
						getFightLog = String.Format("\nMonster Den: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getMonsterDenLvlMaint);
						// reset maintenance condition
						MonsterDenLvlMaintCondition = 95;
					}
					else
					{
						// increase chance for maintenance to be required
						MonsterDenLvlMaintCondition -= 10;
					}
					break;
				case 33:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "contagion breakout";
					goto case 34;
				case 34:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "keeper injury";
					goto case 35;
				case 35:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "broken cage";
					goto case 36;
				case 36:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
					goto case 37;
				case 37:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "feeding";
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
					goto case 40;
				case 40:
					if (getMonsterDenLvlMaint > 0) MaintCost += (getMonsterDenLvlMaint / 100);
					else MaintCost += Math.Abs(getMonsterDenLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 210;

				case 43:
					// Arena armour Sponsor 
					if (RndVal.Next(100) < GameTeams.Count)
					{
						int iteam = RndVal.Next(100);
						if (iteam < GameTeams.Count)
						{
							int iRobo = RndVal.Next(GameTeams[iteam].MyTeam.Count);
							// forge new equipment
							Equipment tmp = new Equipment(false, RndVal.Next(5, ShopMaxStat), RndVal.Next(100, ShopMaxDurability), RndVal, false, 100);
							int upgradeVal = 1;
							int equipmentLevel = ShopLvl + 1;
							while (upgradeVal < equipmentLevel && getGameCurrency > ShopStockCost)
							{
								tmp.ePrice = roundValue(tmp.ePrice, tmp.eUpgradeCost, "up");
								tmp.upgrade(ShopUpgradeValue, RndVal, true);
								upgradeVal++;
							}
							GameTeams[iteam].MyTeam[iRobo].getEquipArmour = tmp;
							getWarningLog = String.Format("\n!!! {0} Received a sponsor! {1} received a {2}", GameTeams[iteam].getName, GameTeams[iteam].MyTeam[iRobo].getName, GameTeams[iteam].MyTeam[iRobo].getEquipArmour.ToString());
						}
					}
					break;

				case 44:
					// Arena Weapon Sponsor 
					if (RndVal.Next(100) < GameTeams.Count)
					{
						int iteam = RndVal.Next(100);
						if (iteam < GameTeams.Count)
						{
							int iRobo = RndVal.Next(GameTeams[iteam].MyTeam.Count);
							// forge new equipment
							Equipment tmp = new Equipment(true, RndVal.Next(5, ShopMaxStat), RndVal.Next(100, ShopMaxDurability), RndVal, false, 100);
							int upgradeVal = 1;
							int equipmentLevel = ShopLvl + 1;
							while (upgradeVal < equipmentLevel && getGameCurrency > ShopStockCost)
							{
								tmp.ePrice = roundValue(tmp.ePrice, tmp.eUpgradeCost, "up");
								tmp.upgrade(ShopUpgradeValue, RndVal, true);
								upgradeVal++;
							}
							GameTeams[iteam].MyTeam[iRobo].getEquipWeapon = tmp;
							getWarningLog = String.Format("\n!!! {0} Received a sponsor! {1} received a {2}", GameTeams[iteam].getName, GameTeams[iteam].MyTeam[iRobo].getName, GameTeams[iteam].MyTeam[iRobo].getEquipWeapon.ToString());
						}
					}
					break;
				case 45:
					if (ArenaLvl < 50)
					{
						// Arena Sponsor 
						if (RndVal.Next(100) < GameTeams.Count)
						{
							MaintCost += roundValue(RndVal.Next(gameDifficulty * BossCount * getArenaLvl * 1000));
							getGameCurrency += MaintCost;
							GameCurrencyLogMisc += MaintCost;
							getWarningLog = Environment.NewLine + "!!! Arena Received a sponsor! +" + String.Format("{0:n0}", MaintCost);
						}
					}
					break;
				case 46:
					MaintCost += RndVal.Next(gameDifficulty * 100);
					goto case 47;
				case 47:
					MaintCost += RndVal.Next(gameDifficulty * 75);
					goto case 48;
				case 48:
					MaintCost += RndVal.Next(gameDifficulty * 50);  
					goto case 49;
				case 49:
					MaintCost += RndVal.Next(gameDifficulty * 25);
					if (!FastForward && FastForwardCount < 100000)
					{
						FastForwardCount = (int)roundValue(FastForwardCount, MaintCost, "up");
						getWarningLog = String.Format("\n!!! Fast Forward increased! +{0:n0} T:{1:n0}", MaintCost, FastForwardCount);
					}
					break;
				// Concession Stands
				case 50:
					if (RndVal.Next(100) > ConcessionLvlMaintCondition)
					{
						// Concession Maintenance
						if (getConcessionLvlMaint > 0)
							MaintCost += (getConcessionLvlMaint);
						else
						{
							MaintCost += Math.Abs(getConcessionLvlMaint);
							if (MaintCost > longRandom(ConcessionLvlCost) && ConcessionLvlCost > MainLvlCostBase)
							{
								ConcessionLvlCost = roundValue(ConcessionLvlCost, MainLvlCostBase, "down");
								if (ConcessionLvlCost < MainLvlCostBase)
								{
									ConcessionLvlCost = MainLvlCostBase;
									MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
								}
								getConcessionLvlMaint = ConcessionLvlCost / 2;
								getWarningLog = getFightLog = String.Format("\n*** Concession Stands: !Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", ConcessionLvlCost, MaintCost, ConcessionLvlMaint);
							}
						}
						// continue here
						getConcessionLvlMaint = roundValue(ConcessionLvlMaint, (int)((double)MaintCost * 0.1), "down");
						getGameCurrency -= MaintCost;
						GameCurrencyLogMaint -= MaintCost;
						if (strMessage.Length == 0) strMessage = "!Health Inspector";
						getFightLog = String.Format("\nConcession Stand: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, ConcessionLvlMaint);
						// reset maintenance condition
						ConcessionLvlMaintCondition = 95;
					}
					else
					{
						// increase chance for maintenance to be required
						ConcessionLvlMaintCondition -= 10;
					}
					break;
				case 51:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "repair kiosk";
					goto case 52;
				case 52:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "ecoli";
					goto case 53;
				case 53:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "expired inventory";
					goto case 54;
				case 54:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "restock kitchen";
					goto case 55;
				case 55:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "restock front counter";
					goto case 56;
				case 56:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "rpdate menu";
					goto case 57;
				case 57:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 58;
				case 58:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 232;

				case 61:
				case 62:
				case 63:
				case 64:
				case 65:
					// Tax
					long tmpMaint = (long)((ArenaLvlMaint * 0.1) + (MonsterDenLvlMaint * 0.1) + (ShopLvlMaint * 0.1) + (ResearchDevMaint * 0.1) + (ConcessionLvlMaint * 0.1));
					ArenaLvlMaint -=		RndVal.Next((int)(MainLvlCostBase / 100));
					MonsterDenLvlMaint -=	RndVal.Next((int)(MainLvlCostBase / 100));
					ShopLvlMaint -=			RndVal.Next((int)(MainLvlCostBase / 100));
					ResearchDevMaint -=		RndVal.Next((int)(MainLvlCostBase / 100));
					ConcessionLvlMaint -=	RndVal.Next((int)(MainLvlCostBase / 100));
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
				case 100:
					ArenaComunityReach = roundValue(ArenaComunityReach, (RndVal.Next((int)MainLvlCostBase) / 5), "down");
					if ((SafeTime - DateTime.Now).TotalHours <= 1) getWarningLog = Environment.NewLine + "% Arena Comunity Outreach disaster! Attendance down to " + String.Format("{0:p2}", getArenaOutreach());
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
						if (MaintCost > longRandom(getArenaLvlCost) && getArenaLvlCost > MainLvlCostBase)
						{
							getArenaLvlCost = roundValue(getArenaLvlCost, MainLvlCostBase, "down");
							if (getArenaLvlCost < MainLvlCostBase)
							{
								getArenaLvlCost = MainLvlCostBase / 3;
								MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
							}
							getArenaLvlMaint = getArenaLvlCost;
							getWarningLog = getFightLog = String.Format("\n*** Arena Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", getArenaLvlCost, MaintCost, getArenaLvlMaint);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getArenaLvlMaint = roundValue(ArenaLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Arena: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getArenaLvlMaint);
					// Increase chance for maintenance to be required
					ArenaLvlMaintCondition--;
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
						if (MaintCost > longRandom(MonsterDenLvlCost) && MonsterDenLvlCost > MainLvlCostBase)
						{
							MonsterDenLvlCost = roundValue(MonsterDenLvlCost, MainLvlCostBase, "down");
							if (MonsterDenLvlCost < MainLvlCostBase)
							{
								MonsterDenLvlCost = MainLvlCostBase;
								MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
							}
							MonsterDenLvlMaint = MonsterDenLvlCost / 2;
							getWarningLog = getFightLog = String.Format("\n*** Monster Den Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", MonsterDenLvlCost, MaintCost, getMonsterDenLvlMaint);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getMonsterDenLvlMaint = roundValue(MonsterDenLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Monster Den: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getMonsterDenLvlMaint);
					// Increase chance for maintenance to be required
					MonsterDenLvlMaintCondition--;
					break;
				case 211:
					if (getArenaOutreach() < 0.05)
					{
						MaintCost += (MainLvlCostBase / 3);
						goto case 212;
					}
					break;
				case 212:
					if (getArenaOutreach() < 0.1)
					{
						MaintCost += (MainLvlCostBase / 4);
						goto case 213;
					}
					break;
				case 213:
					if (getArenaOutreach() < 0.15)
					{
						MaintCost += (MainLvlCostBase / 5);
						goto case 214;
					}
					break;
				case 214:
					if (getArenaOutreach() < 0.2)
					{
						MaintCost += (MainLvlCostBase / 6);
						goto case 215;
					}
					break;
				case 215:
					if (getArenaOutreach() < 0.25)
					{
						MaintCost += (MainLvlCostBase / 6);
						goto case 216;
					}
					break;
				case 216:
					if (getArenaOutreach() < 0.3)
					{
						MaintCost += (MainLvlCostBase / 7);
						goto case 217;
					}
					break;
				case 217:
					if (getArenaOutreach() < 0.35)
					{
						MaintCost += (MainLvlCostBase / 7);
						goto case 218;
					}
					break;
				case 218:
					if (getArenaOutreach() < 0.4)
					{
						MaintCost += (MainLvlCostBase / 8);
						goto case 219;
					}
					break;
				case 219:
					if (getArenaOutreach() < 0.45)
					{
						MaintCost += (MainLvlCostBase / 8);
						goto case 220;
					}
					break;
				case 220:
					if (getArenaOutreach() < 0.5)
					{
						MaintCost += (MainLvlCostBase / 9);
						goto case 221;
					}
					break;
				case 221:
					if (getArenaOutreach() < 0.55)
					{
						MaintCost += (MainLvlCostBase / 9);
						goto case 222;
					}
					break;
				case 222:
					if (getArenaOutreach() < 0.6)
					{
						MaintCost += (MainLvlCostBase / 10);
						goto case 223;
					}
					break;
				case 223:
					if (getArenaOutreach() < 0.65)
					{
						MaintCost += (MainLvlCostBase / 10);
						goto case 224;
					}
					break;
				case 224:
					if (getArenaOutreach() < 0.7)
					{
						MaintCost += (MainLvlCostBase / 10);
						goto case 225;
					}
					break;
				case 225:
					if (getArenaOutreach() < 0.75)
					{
						MaintCost += (MainLvlCostBase / 10);
						ArenaComunityReach = roundValue(ArenaComunityReach, MaintCost, "up");
					}
					if ((SafeTime - DateTime.Now).TotalHours <= 1) getWarningLog = Environment.NewLine + "% Arena did comunity outreach: Attendance " + String.Format("{0:p2}!", getArenaOutreach());
					break;

				// concession stands
				case 230:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 200);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 231;
				case 231:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 200);
					else MaintCost += Math.Abs(getConcessionLvlMaint / 100);
					if (strMessage.Length == 0) strMessage = "cleaning";
					goto case 232;
				case 232:
					if (getConcessionLvlMaint > 0) MaintCost += (getConcessionLvlMaint / 100);
					else
					{
						MaintCost += Math.Abs(getConcessionLvlMaint / 100);
						if (MaintCost > longRandom(getConcessionLvlMaint) && getConcessionLvlMaint > MainLvlCostBase)
						{
							getConcessionLvlMaint = roundValue(getConcessionLvlMaint, MainLvlCostBase, "down");
							if (getConcessionLvlMaint < MainLvlCostBase)
							{
								getConcessionLvlMaint = MainLvlCostBase;
								MainLvlCostBase = (long)(MainLvlCostBase * 0.9);
							}
							getConcessionLvlMaint = getConcessionLvlMaint / 2;
							getWarningLog = getFightLog = String.Format("\n*** Concession Stand Rebuilt +{0:c0} Maint:{1:c0}/{2:c0}", MonsterDenLvlCost, MaintCost, getMonsterDenLvlMaint);
						}
					}
					if (strMessage.Length == 0) strMessage = "cleaning";
					MaintCost = roundValue(MaintCost);
					getConcessionLvlMaint = roundValue(ConcessionLvlMaint, (int)((double)MaintCost * 0.01), "down");
					getGameCurrency -= MaintCost;
					GameCurrencyLogMaint -= MaintCost;
					getFightLog = String.Format("\n*** Concession Stand: {0} - cost {1:c0}/{2:c0}", strMessage, MaintCost, getConcessionLvlMaint);
					// Increase chance for maintenance to be required
					ConcessionLvlMaintCondition--;
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
					eRobot.getCurrentSpeed = RndVal.Next(1, eRobot.getTSpeed());
				foreach (Robot eRobot in GameTeam2[index].MyTeam)
					eRobot.getCurrentSpeed = RndVal.Next(1, eRobot.getTSpeed());
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
						eDefender.damage(attacker, currSkill, attackers);
						if (eDefender.HP <= 0) attackers.addRune(eDefender.getLevel);
					}
				}
			}
			// attacking a single enemy
			else
			{
				defender.damage(attacker, currSkill, attackers);
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
	class Team : Common, IComparable<Team>
	{
		
		public List<Robot> MyTeam;
		
		public int[] RobotDestroyed;
		
		public int[] RobotDestroyedGoal;
		
		public int[] MonsterDestroyed;
		
		public int[] MonsterDestroyedGoal;
		
		public int LifetimeRobotsCreated;
		
		public int GoalLifetimeRobotsCreated;
		
		public int LifetimeRobotsRebuilt;
		
		public int GoalLifetimeRobotsRebuilt;
		
		public int LifetimeEquipmentPurchased;
		
		public int GoalLifetimeEquipmentPurchased;
		
		public int LifetimeEquipmentUpgraded;
		
		public int GoalLifetimeEquipmentUpgraded;
		
		public List<int> Runes;
		
		private int Score;
		private int ScoreLog;
		
		public int Win;
		
		private int GoalScore;
		
		private int GoalScoreBase;
		public int GoalScoreBaseIncrement = 25;
		
		private long Currency;
		public long CurrencyLog;
		
		private int Difficulty;
		public int DifficultyLog;
		
		private int MaxRobo;
		
		private long RoboCost;
		
		private long RoboCostBase;
		public long RoboCostBaseIncrement = 100;
		
		private string TeamName;
		public Boolean isMonster;
		
		public Boolean Automated;
		public Boolean Manual_Equipment;
		
		private string TeamLog;
		public bool shownDefeated;
		public int HealScore;

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
						string strMsg = "";
						string strDelim = "";
						for (int i = 0; i < MyTeam.Count; i++)
						{
							for (int j = 0; j < 5; j++)
							{
								addRune((int)(MyTeam[i].getRankLvl()), true);
							}
							strMsg += strDelim + (int)(MyTeam[i].getBaseStats() / 2);
							strDelim = ",";
						}
						getWarningLog = getFightLog = getTeamLog = String.Format("\n@{0} Score goal reached ({1:n0}) - Runes awarded to Rank(s): {2}! ", getName, GoalScore, strMsg);
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

		public Team(int pScore, int pGoalScore, int pGoalScoreBase, int pWin, long pCurrency, int pDifficulty, int pMaxRobo,
			long pRoboCost, long pRoboCostBase, string pTeamName, bool pAutomated, int[] pRobotDestroyed, int[] pRobotDestroyedGoal, 
			int[] pMonsterDestroyed, int[] pMonsterDestroyedGoal, int pLifetimeRobotsCreated, int pGoalLifetimeRobotsCreated,
			int pLifetimeRobotsRebuilt, int pGoalLifetimeRobotsRebuilt, int pLifetimeEquipmentPurchased, int pGoalLifetimeEquipmentPurchased,
			int pLifetimeEquipmentUpgraded, int pGoalLifetimeEquipmentUpgraded)
		{
			MyTeam = new List<Robot> { };
			Runes = new List<int> { 0 };
			RobotDestroyed = pRobotDestroyed;
			RobotDestroyedGoal = pRobotDestroyedGoal;
			MonsterDestroyed = pMonsterDestroyed;
			MonsterDestroyedGoal = pMonsterDestroyedGoal;
			LifetimeRobotsCreated = pLifetimeRobotsCreated;
			GoalLifetimeRobotsCreated = pGoalLifetimeRobotsCreated;
			LifetimeRobotsRebuilt = pLifetimeRobotsRebuilt;
			GoalLifetimeRobotsRebuilt = pGoalLifetimeRobotsRebuilt;
			LifetimeEquipmentPurchased = pLifetimeEquipmentPurchased;
			GoalLifetimeEquipmentPurchased = pGoalLifetimeEquipmentPurchased;
			LifetimeEquipmentUpgraded = pLifetimeEquipmentUpgraded;
			GoalLifetimeEquipmentUpgraded = pGoalLifetimeEquipmentUpgraded;
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

		public Team(int pScore, int pGoalScore, int pGoalScoreBase, int pWin, long pCurrency, int pDifficulty, int pMaxRobo,
			long pRoboCost, long pRoboCostBase, string pTeamName, bool pAutomated) : this (pScore, pGoalScore, pGoalScoreBase, pWin, pCurrency, pDifficulty, pMaxRobo, pRoboCost, pRoboCostBase, pTeamName, pAutomated,
				new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100 },
				new int[] { 0 }, new int[] { 100 }, 0, 10, 0, 10, 0, 100, 0, 100) {}

		public Team(int baseStats, Game myGame)
        {
			int type = RndVal.Next(8);
			MyTeam = new List<Robot> { new Robot(baseStats, myGame.setRoboName(type), type, false) };
			Runes = new List<int> { 0 };
			RobotDestroyed = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			RobotDestroyedGoal = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100 };
			MonsterDestroyed = new int[] { 0 };
			MonsterDestroyedGoal = new int[] { 100 };
			LifetimeRobotsCreated = 0;
			GoalLifetimeRobotsCreated = 10;
			LifetimeRobotsRebuilt = 0;
			GoalLifetimeRobotsRebuilt = 10;
			LifetimeEquipmentPurchased = 0;
			GoalLifetimeEquipmentPurchased = 100;
			LifetimeEquipmentUpgraded = 0;
			GoalLifetimeEquipmentUpgraded = 100;
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
			Manual_Equipment = true;
			Win = 0;
			TeamName = name1[RndVal.Next(name1.Length)] + " " + name3[RndVal.Next(name3.Length)];
			shownDefeated = false;
		}
		// Boss Monsters
		public Team(int numMonsters, int Difficulty, int MonsterLvl)
		{
			MyTeam = new List<Robot> { };
			Runes = new List<int> { 0 };
			RobotDestroyed = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			RobotDestroyedGoal = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100 };
			MonsterDestroyed = new int[] { 0 };
			MonsterDestroyedGoal = new int[] { 100 };
			LifetimeRobotsCreated = 0;
			GoalLifetimeRobotsCreated = 10;
			LifetimeRobotsRebuilt = 0;
			GoalLifetimeRobotsRebuilt = 10;
			LifetimeEquipmentPurchased = 0;
			GoalLifetimeEquipmentPurchased = 100;
			LifetimeEquipmentUpgraded = 0;
			GoalLifetimeEquipmentUpgraded = 100;
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
			Manual_Equipment = false;
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
			RobotDestroyed = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
			RobotDestroyedGoal = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100 };
			MonsterDestroyed = new int[] { 0 };
			MonsterDestroyedGoal = new int[] { 100 };
			LifetimeRobotsCreated = 0;
			GoalLifetimeRobotsCreated = 10;
			LifetimeRobotsRebuilt = 0;
			GoalLifetimeRobotsRebuilt = 10;
			LifetimeEquipmentPurchased = 0;
			GoalLifetimeEquipmentPurchased = 100;
			LifetimeEquipmentUpgraded = 0;
			GoalLifetimeEquipmentUpgraded = 100;
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
						if (MonsterOutbreak.MyTeam[ii].getLevel <= maxLvl && MonsterOutbreak.MyTeam[ii].getLevel >= minLvl && MonsterOutbreak.MyTeam[ii].HP > 0 )
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
						MyTeam[i].getCurrentSpeed = RndVal.Next(1, MyTeam[i].getTSpeed());
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
			TeamName = string.Format("M_{0} {1}",name1[RndVal.Next(name1.Length)], name2[RndVal.Next(name2.Length)]);
			Automated = true;
			Manual_Equipment = false;
			shownDefeated = false;
		}
		public void resetSpeed()
		{
			foreach (Robot eRobo in MyTeam)
				eRobo.getCurrentSpeed = RndVal.Next(1, eRobo.getTSpeed());
		}
		public void AddRobotDestroyed(int type, bool isMonster)
		{
			if (isMonster)
			{
				if (MonsterDestroyed == null)
				{
					MonsterDestroyed = new int[1];
					MonsterDestroyedGoal = new int[1];
				}
				if (MonsterDestroyed.Length <= type)
				{
					int[] tmp = new int[type+1];
					int[] Goaltmp = new int[type+1];
					for (int i = 0; i < type; i++)
					{
						if (i < MonsterDestroyed.Length)
						{
							tmp[i] = MonsterDestroyed[i];
							Goaltmp[i] = MonsterDestroyedGoal[i];
						}
					}
					MonsterDestroyed = tmp;
					MonsterDestroyedGoal = Goaltmp;
				}
				MonsterDestroyed[type]++;
				if (MonsterDestroyedGoal[type] == 0) MonsterDestroyedGoal[type] = 100;
				if (MonsterDestroyed[type] >= MonsterDestroyedGoal[type])
				{
					getCurrency += MonsterDestroyedGoal[type] * (25 * (type+1));
					string MSG = string.Format("\n!*!*! {3} Destroyed {0:n0} {1}s   {2:c0}", MonsterDestroyedGoal[type], MonsterName[type], MonsterDestroyedGoal[type] * (25 * (type + 1)), getName);
					if (!Automated) getWarningLog = MSG;
					getTeamLog = getFightLog = MSG;
					MonsterDestroyedGoal[type] = (int)roundValue(MonsterDestroyedGoal[type] * 2, 1);
				}
			}
			else
			{
				if (RobotDestroyed == null)
				{
					RobotDestroyed = new int[1];
					RobotDestroyedGoal = new int[1];
				}
				//if (RobotDestroyed.Length <= type)
				//{
				//	int[] tmp = new int[type+1];
				//	int[] Goaltmp = new int[type+1];
				//	for (int i = 0; i < type; i++)
				//	{
				//		if (i < RobotDestroyed.Length)
				//		{
				//			tmp[i] = RobotDestroyed[i];
				//			Goaltmp[i] = RobotDestroyedGoal[i];
				//		}
				//	}
				//	RobotDestroyed = tmp;
				//	RobotDestroyedGoal = Goaltmp;
				//}
				RobotDestroyed[type]++;
				if (RobotDestroyedGoal[type] == 0) RobotDestroyedGoal[type] = 100;
				if (RobotDestroyed[type] >= RobotDestroyedGoal[type])
				{
					getCurrency += RobotDestroyedGoal[type] * (100);
					string MSG = string.Format("\n!*!*! {3} Destroyed {0:n0} {1}s   {2:c0}", RobotDestroyedGoal[type], RoboName[type], RobotDestroyedGoal[type] * (100), getName);
					if (!Automated) getWarningLog = MSG;
					getTeamLog = getFightLog = MSG;
					RobotDestroyedGoal[type] = (int)roundValue(RobotDestroyedGoal[type] * 2, 1);
				}
			}
		}
		public void AddRobotCreated()
		{
			LifetimeRobotsCreated++;
			if (GoalLifetimeRobotsCreated == 0) GoalLifetimeRobotsCreated = 10;
			if (LifetimeRobotsCreated >= GoalLifetimeRobotsCreated)
			{
				getCurrency += GoalLifetimeRobotsCreated * 10000;
				string msg = string.Format("\n!*!*! {2} created {0:n0} robots and was awarded {1:c0}", GoalLifetimeRobotsCreated, GoalLifetimeRobotsCreated * 10000, getName);
				if (!Automated) getWarningLog = msg;
				getTeamLog = getFightLog = msg; 
				GoalLifetimeRobotsCreated = (int)roundValue(GoalLifetimeRobotsCreated * 2, 1);
			}
		}
		public void AddRobotRebuilt()
		{
			LifetimeRobotsRebuilt++;
			if (GoalLifetimeRobotsRebuilt == 0) GoalLifetimeRobotsRebuilt = 10;
			if (LifetimeRobotsRebuilt >= GoalLifetimeRobotsRebuilt)
			{
				getCurrency += GoalLifetimeRobotsRebuilt * 10000;
				string msg = string.Format("\n!*!*! {2} rebuilt {0:n0} robots and was awarded {1:c0}", GoalLifetimeRobotsRebuilt, GoalLifetimeRobotsRebuilt * 10000, getName);
				if (!Automated) getWarningLog = msg;
				getTeamLog = getFightLog = msg;
				GoalLifetimeRobotsRebuilt = (int)roundValue(GoalLifetimeRobotsRebuilt * 2, 1);
			}
		}
		public void AddEquipmentPurchased()
		{
			LifetimeEquipmentPurchased++;
			if (GoalLifetimeEquipmentPurchased == 0) GoalLifetimeEquipmentPurchased = 100;
			if (LifetimeEquipmentPurchased >= GoalLifetimeEquipmentPurchased)
			{
				getCurrency += GoalLifetimeEquipmentPurchased * 1000;
				string msg = string.Format("\n!*!*! {2} purchased {0:n0} pieces of equipment and was awarded {1:c0}", GoalLifetimeEquipmentPurchased, GoalLifetimeEquipmentPurchased * 1000, getName);
				if (!Automated) getWarningLog = msg;
				getTeamLog = getFightLog = msg;
				GoalLifetimeEquipmentPurchased = (int)roundValue(GoalLifetimeEquipmentPurchased * 2, 1);
			}
		}
		public void AddEquipmentUpgraded()
		{
			LifetimeEquipmentUpgraded++;
			if (GoalLifetimeEquipmentUpgraded == 0) GoalLifetimeEquipmentUpgraded = 100;
			if (LifetimeEquipmentUpgraded >= GoalLifetimeEquipmentUpgraded)
			{
				getCurrency += GoalLifetimeEquipmentUpgraded * 1000;
				string msg = string.Format("\n!*!*! {2} upgraded {0:n0} pieces of equipment and was awarded {1:c0}", GoalLifetimeEquipmentUpgraded, GoalLifetimeEquipmentUpgraded * 1000, getName);
				if (!Automated) getWarningLog = msg;
				getTeamLog = getFightLog = msg;
				GoalLifetimeEquipmentUpgraded = (int)roundValue(GoalLifetimeEquipmentUpgraded *2, 1); 
			}
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
						Runes[index] = 0;
						addRune(level + 10, true);
						if (RndVal.Next(100) > 90) // 10% chance to add bonus Rebuild
						{
							// Add bonus rebuild
							Robot tmpRobot = MyTeam[RndVal.Next(MyTeam.Count)];
							tmpRobot.rebuildBonus++;
							getFightLog = String.Format("\n ^@^{0}-{1} received a bonus rebuild! ", getName, tmpRobot.getName);
						}
					}
					else
					{
						getFightLog = String.Format("\n   ^^^{0} received a rank {1} rune! ({2:n0})", getName, index, Runes[index], DateTime.Now.ToString());
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
		
		public string getTeamLog
		{
			set
			{
				if (!value.Contains("test"))
				{
					if (TeamLog.Length > 5000)
						TeamLog = value + TeamLog.Substring(0, 4900);
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
			// Automated
			if (Automated) Automated = !Automated;
			// Not automated
			else
			{
				// if not automated and equipment is prioitized, automate the upgrades
				if (Manual_Equipment)  Automated = !Automated;
				// cycle prioritization
				Manual_Equipment = !Manual_Equipment;
			}
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

		public string getTeamStats(int[] PadRight, int[] maxLength, long rebuildSavings, int KOCount, Game myGame, int roundCount = 0, Boolean showAll = false, Boolean ClearDmg = true)
		{
			string strStats = ""; 
			// If this team is not in Team1 or Team1 list
			string strBuild = " ";
			int counter = 0;
			int shownCounter = 0;
			int startCounter = 0;
			int maxRobos = 50;
			int aliveCount = 0;
			int HPCount = 0;
			if (getName.Equals("Arena") || getName.Equals("Monster Outbreak") || getName.Contains("Game Diff"))
			{
				int maxStartCounter = MyTeam.Count - 15;
				if (maxStartCounter < 0) maxStartCounter = 0;
				startCounter = RndVal.Next(maxStartCounter);
				if (MyTeam[startCounter].getKO > KOCount) startCounter = 0;
				maxRobos = 15 + startCounter;
			}
			else if (roundCount > 0 && !showAll)
				maxRobos = (20) - roundCount;
			if (getAvailableRobo > 0)
				strBuild = "!";
			string strFormat = "{0} P:{3," + maxLength[0] + ":n0}{4} {1," + maxLength[2] + ":c0} W:{8," + maxLength[4] + ":n0} D:{6," + maxLength[5] + ":n0} {9," + maxLength[4] + ":p0}";
			if (roundCount < 20) strFormat = "{0} P:{3," + maxLength[0] + ":n0}{4}->{5," + maxLength[1] + ":n0} {1," + maxLength[2] + ":c0}->{2," + maxLength[3] + ":c0} W:{8," + maxLength[4] + ":n0} D:{6," + maxLength[5] + ":n0}->{7," + maxLength[6] + ":n0} {9," + maxLength[4] + ":p0}";
			strStats = String.Format(strFormat, getName.PadRight(18).Substring(0,18), Currency, CurrencyLog, Score, strBuild, ScoreLog, Difficulty, DifficultyLog, Win, getHealthPercent());
			foreach (Robot eRobo in MyTeam)
			{
				// Add different robots...  
				if (counter < maxRobos && counter >= startCounter)
				{
					strStats += eRobo.getRoboStats(PadRight, myGame, this, rebuildSavings, Runes, roundCount, ClearDmg);
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
					eRobo.getRoboStats(PadRight, myGame, this, rebuildSavings, Runes, roundCount, ClearDmg);
					if (eRobo.getKO == 0)
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
				if (eRobo.HP > 0) HPCount++;
			}
			int Spacing = shownCounter + shownCounter / 5;
			if (Spacing == 0) Spacing = 35;
			else if (shownCounter % 5 == 0) Spacing--;
			strStats += String.Format("{0," + (40-(Spacing)) + ":n0}", string.Format("{0:n0}/{1:n0}", HPCount, MyTeam.Count));
			return strStats;
		}
				
		public void fixTech()
		{
			foreach (Robot eRobo in MyTeam) eRobo.fixTech();
		}
		public long Rebuild(bool pay, Game myGame)
		{
			long cost = 0;
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].rebuildCost(myGame.ResearchDevRebuild,Runes) >= 200)
					cost += Rebuild(MyTeam[i], pay, myGame);
			}
			return cost;
		}
		public long Rebuild(Robot robo, bool pay, Game myGame)
		{
			int robotIndex = 0;
			for (int i = 0; i < MyTeam.Count; i++)
			{
				if (MyTeam[i].getName.Equals(robo.getName))
				{
					robotIndex = i;
				}
			}
			return Rebuild(robotIndex, pay, myGame);
		}
		public long Rebuild(int robo, bool pay, Game myGame)
		{
			long Cost = 0;
			int bonusAnalysis = 0;
			if (!pay || MyTeam[robo].rebuildCost(myGame.ResearchDevRebuild,Runes) <= getCurrency)
			{
				if (pay)
				{
					Cost = MyTeam[robo].rebuildCost(myGame.ResearchDevRebuild, Runes);
					if (MyTeam[robo].rebuildBonus > 0)
						MyTeam[robo].rebuildBonus--;
				}
				MyTeam[robo].RebuildPercent++;
				// current base stats
				int baseStats = MyTeam[robo].getBaseStats();
				int baseIncreased = 0;
				// only increase base stats if level is high enough
				if (baseStats < MyTeam[robo].getLevel / 5)
				{
					int MultiRank = 100 + myGame.getResearchDevLvl;
					do 
					{
						baseStats++;
						MultiRank -= 5;
					}
					while (RndVal.Next(MultiRank) > 100);
					baseIncreased = baseStats - MyTeam[robo].getBaseStats();
				}
				string strName = MyTeam[robo].getName;
				bool bIsMonsterTmp = MyTeam[robo].bIsMonster;
				bool btmpMonster = MyTeam[robo].bMonster;
				Equipment weapon = MyTeam[robo].getEquipWeapon;
				Equipment armour = MyTeam[robo].getEquipArmour;
				int type = MyTeam[robo].type;
				int runesUsed = getRunes(MyTeam[robo].getBaseStats(), true);
				if (MyTeam[robo].RebuildPercent + runesUsed > RndVal.Next(100))
				{
                    MyTeam[robo] = new Robot(baseStats, "temp", type , false);
					MyTeam[robo].getName = strName;
					MyTeam[robo].bIsMonster = bIsMonsterTmp;
					MyTeam[robo].bMonster = btmpMonster;
					MyTeam[robo].getEquipWeapon = weapon;
					MyTeam[robo].getEquipArmour = armour;
					if (!MyTeam[robo].bIsMonster)
					{
						string strFormat = "\n +++ {0}:{1} has been rebuilt! Rank {2:n1} (+{3}B/{4}R)";
						if (Cost > 0) strFormat += " ic:{6:c0}";
						getTeamLog = getFightLog = getWarningLog = string.Format(strFormat, getName, MyTeam[robo].getName, (MyTeam[robo].getBaseStats() / 2.0), baseIncreased, runesUsed, DateTime.Now.ToString(), Cost);
						AddRobotRebuilt();
					}
					else
					{
						string strFormat = "\n [M] {0}:{1} has ranked up! Rank {2:n1} (+{3}B) ";
						getFightLog = string.Format(strFormat, getName, MyTeam[robo].getName, (MyTeam[robo].getBaseStats() / 2.0), baseIncreased, DateTime.Now.ToString());
					}
				}
				else
				{
					bonusAnalysis = RndVal.Next((int)MyTeam[robo].RebuildPercent * 10);
					MyTeam[robo].getCurrentAnalysis += bonusAnalysis;
					if (!MyTeam[robo].bIsMonster)
					{
						// refund 75% of the cost of the upgrade. 
						Cost = Cost / 4;
						string strFormat = "\n--- {0}:{1} failed the rebuild (+{2}A/{3}R)";
						if (Cost > 0) strFormat += " ic:{5:c0}";
						getTeamLog = getFightLog = string.Format(strFormat, getName, MyTeam[robo].getName, bonusAnalysis, runesUsed, DateTime.Now.ToString(), Cost);
						MyTeam[robo].RebuildPercent += runesUsed;
					}
					else
					{
						string strFormat = "\n [M] {0}:{1} failed to ranked up... Rank (+{2}A)";
						getFightLog = string.Format(strFormat, getName, MyTeam[robo].getName, bonusAnalysis, DateTime.Now.ToString());
					}
                }
			}
			// pay for the upgrade
			getCurrency -= Cost;
			return Cost;
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
		public double getHealthPercent()
		{
			double MaxHP = 0;
			double CurrentHP = 0;
			foreach (Robot robo in MyTeam)
			{
				MaxHP += robo.getTHealth();
				CurrentHP += robo.HP;
			}
			return CurrentHP / MaxHP;
		}
		public Boolean healRobos(bool isBoss)
		{
			int beds = 0;
			int pay = 0;
			int value = 0;
			if (MyTeam.Count > 0) value = MyTeam[RndVal.Next(MyTeam.Count)].getTHealth();
			return healRobos(ref beds, ref pay, value, isBoss);
		}
		public Boolean healRobos(ref int beds, ref int pay, int value, bool isBoss = false)
		{
			Boolean fullHP = true;
			Boolean bedUsed = false;
			int cost = 0;
			// Randomly loop through the robot indexes in the MyTeam array
			foreach (int robo in Enumerable.Range(0, MyTeam.Count).OrderBy(x => RndVal.Next()))
			{
				if (MyTeam[robo].HP < MyTeam[robo].getTHealth())
                {
					if (getCurrency < cost || beds == 0 || bedUsed || (MyTeam[robo].getTHealth() - MyTeam[robo].HP) < (value / 2))
					{
						cost = 0;
						value = 1;
					}
					else
					{
						if (getScore >= HealScore)
						{ 
							cost = MyTeam[robo].getBaseStats();
							HealScore = getScore + 1;
						}
						beds--;
						bedUsed = true;
					}
					// Pay for repair
					pay += cost;
					getCurrency -= cost;
					CurrencyLog -= cost;
					// ensure at least one Health is recovered
					if (value == 0) value = 1;
					MyTeam[robo].HP += value;
					MyTeam[robo].MP += value;
					// Reset KO counter
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
	
	class Robot : Common, IComparable<Robot>
	{
		
		public List<Skill> ListSkills;
		
		public List<Strategy> RoboStrategy;
		
		private Equipment EquipWeapon;
		
		private Equipment EquipArmour;
		
		private string RobotName;
		public string tmpMessage;
		public int dmg;
		public bool crit;
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
		
		public int type;
		
		private int Speed;
		private int CurrentSpeed;
		
		private int Level;
		private int LevelLog;
		
		public int rebuildBonus;
		
		private int Analysis;
		
		private int CurrentAnalysis;
		
		public int RebuildPercent;
		
		public long RoboRebuildCost;
		private int AnalysisLog;
		public string RobotLog;
		public char cSkill = ' ';
		public bool bMonster = false;
		public bool bIsMonster = false;
		public String getNameRank(Boolean includeName = true)
		{
			double rank = getBaseStats() / 2.0;
			string tmpName = "";
			if (includeName) tmpName = RobotName; 
			return String.Format("{0}_{1}",tmpName, rank);
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

		public int getRankLvl()
		{
			return (int)((getBaseStats() / 2) * 10);
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
				if ( !tmp.Substring(0,3).Equals(ImagePath.Substring(0,3)) )
				{
					tmp = ImagePath + tmp;
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
				if (HP > 0)	return CurrentSpeed;
				else		return 0;
			}
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
			string pImage, int pType, int pSpeed, int pLevel, int pAnalysis, int pCurrentAnalysis, long pRebuildCost)
		{
			getName = pRobotName;
			Analysis = pAnalysis;
			CurrentAnalysis = pCurrentAnalysis;
			Level = pLevel;
			message = "";
			RobotLog = "";
			Image = pImage;
			type = pType;
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
			type = imageIndex;
			if (isMonster)
			{
				Image = ImagePath + MonsterImages[imageIndex];
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Highest", "HP") };
				bIsMonster = true;
				RoboRebuildCost = 0;
				iBasePoints += imageIndex;
			}
			else
			{
				Image = ImagePath + RoboImages[imageIndex];
				RoboStrategy = new List<Strategy> { new Strategy(ListSkills[0], "Num Enemies", "Greater than", 0, "Current", "Level") };
				RoboRebuildCost = 2000;
				long RoboRebuildCostBase = 1000;
				for (int i = 0; iBasePoints > i; i++)
				{
					RoboRebuildCost = roundValue(RoboRebuildCost, RoboRebuildCostBase, "up");
					RoboRebuildCostBase += 1000;
					if (i % 5 == 0) RoboRebuildCostBase *= 2;
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
				RandomValue = RndVal.Next(1,7);
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
					case 6:
						switch (type)
						{
							case 0:
								Agility++;
								break;
							case 1:
								Tech++;
								break;
							case 2:
								Strength++;
								break;
							case 3:
								Dexterity++;
								break;
							case 4:
								Agility++;
								break;
							case 5:
								Dexterity++;
								break;
							case 6:
								Accuracy++;
								break;
							case 7:
								Accuracy++;
								break;
							case 8:
								Tech++;
								break;
						}
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
			Robot tmp = new Robot("." + MonsterName[type], Dexterity, Strength, Agility, Tech, Accuracy, Health, Energy, Armour, Damage, Hit, MentalStrength, MentalDefense, Image, type, Speed, Level, Analysis, 0, 0);
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
		{
			
		}

		public void resetLog()
		{
			LevelLog = 0;
			AnalysisLog = 0;
		}

		public string getRoboStats(int[] PadRight, Game myGame, Team myTeam, long rebuildSavings, List<int> Runes, int roundCount, Boolean ClearDmg = true)
		{
			char cRebuild = ' ';
			string strStats = "";
			string strMsg = "";
			string strFormat = "";
			if (HP == 0 && ClearDmg)
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
				if (ClearDmg) dmg = 0;
				crit = false;
			}
			int shortLength = 12;
			if (getName.Length < 12) shortLength = getName.Length;
			if (getKO <= 3) strFormat = "\n{0}{1}{3} L:{4} R:{10} A:{6} S:{7} M:{8} H:{9}{11} ";
			if (roundCount < 20) strFormat = "\n{0}{1}{2} L:{4}->{5} R:{10} A:{6} S:{7} M:{8} H:{9}{11} ";
			strStats = string.Format(strFormat, cRebuild, cSkill,
				getName.PadRight(PadRight[0]), getName.Substring(0, shortLength).PadRight(PadRight[7]),
				String.Format("{0:n0}", getLevel).PadLeft(PadRight[1]),
				String.Format("{0:n0}", LevelLog).PadLeft(PadRight[2]),
				String.Format("{0:n0}", getAnalysisLeft()).PadLeft(PadRight[3]),
				String.Format("{0:n0}", getCurrentSpeed).PadLeft(PadRight[4]),
				String.Format("{0:n0}", MP).PadLeft(PadRight[5]), 
				String.Format("{0:n0}", HP).PadLeft(PadRight[6]),
				String.Format("{0:n0}", getBaseStats()/2.0).PadLeft(PadRight[8]),
				strMsg);

			if (ClearDmg) cSkill = ' ';
			return strStats;
		}
		public double rebuildSavings(List<int> runes)
		{
			int percent = 100;
			int stats = (Dexterity + Strength + Agility + Tech + Accuracy);
			if (runes.Count > stats / 2) percent -= runes[stats / 2];
			return percent/100.0;
		}
		public long rebuildCost(long ResearchDevRebuild, List<int> runes, bool proposedCost = false)
		{
			long cost = 100;
			int stats = (Dexterity + Strength + Agility + Tech + Accuracy);
			// if base stats will go up add cost
			if (Level / 5 > stats || proposedCost)
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
				CurrentSpeed = RndVal.Next(0, (CurrentSpeed-1));
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

		public void damage(Robot attacker, Skill currSkill, Team ATeam)
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
				if (currSkill.type.Equals("Single attack") || currSkill.type.Equals("Single tech") || RndVal.Next(100) > 50)
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
						if (HP == 0) attacker.getCurrentAnalysis += 10; 
					}
					// if attacker is higher level, get less exp
					else if (RndVal.Next(attacker.getLevel) < getLevel)
						attacker.getCurrentAnalysis++;
					// if robot / monster is defeated addTo achievement vars. 
					if (HP == 0) ATeam.AddRobotDestroyed(type, bIsMonster);
				}
			}
		}
		public int getMaxLevel() { return (Dexterity + Strength + Agility + Tech + Accuracy + 1) * 5; }
		public int getTotalPower()
		{
			return (getTHealth() / 3) + (getTEnergy() / 2) + getTArmour() + getTDamage() + getTHit() + getTSpeed() + getTMentalStrength() + getTMentalDefense();
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
					, getMaxLength( new string[] { String.Format("{0:n0}", getHealth), String.Format("{0:n0}", getEnergy), String.Format("{0:n0}", getArmour), String.Format("{0:n0}", getDamage), String.Format("{0:n0}", getHit), String.Format("{0:n0}", getSpeed), String.Format("{0:n0}", getMentalStrength), String.Format("{0:n0}", getMentalDefense) } )
					, getMaxLength( new string[] { String.Format("{0:n0}", wHealth), String.Format("{0:n0}", wEnergy), String.Format("{0:n0}", wArmour), String.Format("{0:n0}", wDamage), String.Format("{0:n0}", wHit), String.Format("{0:n0}", wSpeed), String.Format("{0:n0}", wMentalStr), String.Format("{0:n0}", wMentalDef) } )
					, getMaxLength( new string[] { String.Format("{0:n0}", aHealth), String.Format("{0:n0}", aEnergy), String.Format("{0:n0}", aArmour), String.Format("{0:n0}", aDamage), String.Format("{0:n0}", aHit), String.Format("{0:n0}", aSpeed), String.Format("{0:n0}", aMentalStr), String.Format("{0:n0}", aMentalDef) } )
				};
			tmp += ("*Base Stats*\n");
			tmp += string.Format("{0,-10}{1}/{2}\n", "Level", Level, getMaxLevel());
			string strType;
			if (bIsMonster) strType = MonsterName[type];
			else strType = RoboName[type];
			tmp += string.Format("{0,-10}{1}\n", "type", strType);
			tmp += string.Format("{0,-10}{1}\n", "Rank", (Dexterity + Strength + Agility + Tech + Accuracy) / 2.0);
			tmp += string.Format("{0,-10}{1}\n", "Dexterity", Dexterity);
			tmp += string.Format("{0,-10}{1}\n", "Strength", Strength);
			tmp += string.Format("{0,-10}{1}\n", "Agility", Agility);
			tmp += string.Format("{0,-10}{1}\n", "Tech", Tech);
			tmp += string.Format("{0,-10}{1}\n", "Accuracy", Accuracy);
			tmp += ("*Elevated Stats*\n");
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0}\n", "T.Power", getTotalPower());
			tmp += string.Format("{0,-10}{1," + (cPadding[0]) + ":n0}/{2," + (cPadding[1]) + ":n0} {3," + cPadding[2] + ":n0}+{4," + cPadding[3] + ":n0}\n", "Health", HP, getTHealth(), getHealth, aHealth);
			tmp += string.Format("{0,-10}{1," + (cPadding[0]) + ":n0}/{2," + (cPadding[1]) + ":n0} {3," + cPadding[2] + ":n0}+{4," + cPadding[3] + ":n0}\n", "Energy", MP, getTEnergy(), getEnergy, aEnergy);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "Armour", getTArmour(), getArmour, aArmour);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "MentalDef", getTMentalDefense(), getMentalDefense, aMentalDef);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "Damage", getTDamage(), getDamage, wDamage);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "MentalStr", getTMentalStrength(), getMentalStrength, wMentalStr);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "Hit", getTHit(), getHit, wHit);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0} {2," + cPadding[2] + ":n0}+{3," + cPadding[3] + ":n0}\n", "Speed", getTSpeed(), getSpeed, wSpeed);
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0}\n", "Analysis", getAnalysisLeft());
			tmp += string.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + ":n0}\n", "Rebuild %", RebuildPercent);
			tmp += "-----\n";
			foreach (Strategy eStrategy in RoboStrategy)
			{
				tmp += (String.Format("{0,-10}{1," + (cPadding[0] + cPadding[1] + 1) + "} {2,-" + (sPadding+1) + ":n0}+{3:n0}\n", eStrategy.StrategicSkill.name, eStrategy.StrategicSkill.sChar, eStrategy.StrategicSkill.cost, eStrategy.StrategicSkill.strength));
			}
			if (EquipWeapon != null)
			{
				//tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n  {4:c0}\n", EquipWeapon.eDurability, EquipWeapon.eMaxDurability, EquipWeapon.eName, EquipWeapon.eUpgrade, EquipWeapon.eUpgradeCost);
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n", EquipWeapon.eDurability, EquipWeapon.eMaxDurability, EquipWeapon.eName, EquipWeapon.eUpgrade);
			}
			else
				tmp += "<Unequiped>\n";
			if (EquipArmour != null)
			{
				//tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n  {4:c0}\n", EquipArmour.eDurability, EquipArmour.eMaxDurability, EquipArmour.eName, EquipArmour.eUpgrade, getEquipArmour.eUpgradeCost);
				tmp += String.Format("{2}+{3} (Dur:{0:n0}/{1:n0})\n", EquipArmour.eDurability, EquipArmour.eMaxDurability, EquipArmour.eName, EquipArmour.eUpgrade);
			}
			else
				tmp += "<Unequiped>\n";
			return tmp;
        }
	}
	[Serializable]
	
	class Skill
	{
		
		public string name;
		
		public string target; // Enemy or Ally
		
		public int strength; // int representing amount of damage / healing 
		
		public string type; // damage single, or damage multiple
		
		public int cost; // energy cost
		
		public string img;
		
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
	
	class Strategy : IComparable<Strategy>
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
	class ArenaSeating
	{
		
		public int Level; // Seating Level
		
		public int Price; // Cost of customers for seat
		
		public int Amount; // Number of seats
		
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
	class Concession : Common
	{
		public string name;
		public int MaxStock; // Max concession Items it can stock
		public int CurrentStock; // Current stock
		public int SalePrice; // price per item
		public long RestockCost; // Cost to re-stock the items
		public int Demand; // demand for people to buy these items 100 would mean 1 in 100 people will order
		Random rndVal = new Random(); // declare random variable
		public Concession(double markup, int stock) 
		{
			name = ConcessionName[rndVal.Next(ConcessionName.Length)];
			MaxStock = CurrentStock = stock;
			SalePrice = 1;
			RestockCost = (int)(SalePrice * MaxStock * (1 - markup));
			Demand = 100;
		}

		public void ConcessionLevelUp(double markup, int StockIncreaseMax)
		{
			MaxStock = roundValue(MaxStock, RndVal.Next(1,StockIncreaseMax), "up"); ;
			SalePrice++;
			CurrentStock = MaxStock;
			RestockCost = (int)(SalePrice * MaxStock * (1 - markup));
			if (rndVal.Next(100) > 90) Demand--;
		}

		public long purchase(ref int Customers, bool displayEach)
		{
			// Random number of sales
			int Sales = rndVal.Next(Customers / Demand);
			Customers -= Sales;
			// random chance to sell one item
			if (Sales == 0 && CurrentStock > 0 && rndVal.Next(100) > 80) { Sales = 1; }
			if (Sales > 0 && CurrentStock > 0)
			{
				if (Sales > CurrentStock) { Sales = CurrentStock; }
				CurrentStock -= Sales;
				if (displayEach) getFightLog = string.Format("\n    +$ {0} Sales: {1:n0} @ {2:c0} = {3:c0}", name, Sales, SalePrice, Sales * SalePrice);
				return Sales * SalePrice;
			}
			else { return 0; }
		}
		public long restock(long currency)
		{
			if (RestockCost > currency)
				return 0;
			else
			{
				CurrentStock = MaxStock;
				// 1 percent chance to add extra stock
				if (RndVal.Next(100) >= 99)
				{
					MaxStock++;
					RestockCost += SalePrice;
					getWarningLog = getFightLog = string.Format("\n    +++ Concession Stand {0} reorgnized +1 stock: {1:n0}", name, MaxStock);
				}
				return RestockCost;
			}
		}
		public int CompareTo(Concession CompConcession)
		{
			return this.SalePrice.CompareTo(CompConcession.SalePrice);
		}
	}
	[Serializable]
	class Equipment : Common, IComparable<Equipment>
	{
		
		public string eType = "";
		
		public string eName = "";
		
		public int eUpgrade = 0;
		
		public int eHealth = 0;
		
		public int eEnergy = 0;
		
		public int eArmour = 0;
		
		public int eDamage = 0;
		
		public int eHit = 0;
		
		public int eMentalStrength = 0;
		
		public int eMentalDefense = 0;
		
		public int eSpeed = 0;
		
		public long ePrice = 0;
		
		public int eDurability = 0;
		
		public int eMaxDurability = 0;
		
		public long eUpgradeCost = 0;
		
		public long eUpgradeCostBase = 0;
		
		public long eUpgradeCostBaseIncrement = 0;
		public Equipment(bool addWeapon, int value, int durability, Random RndVal, Boolean isBoss = false, int upgradeCost = 100)
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
					eName = "Bat-Ram";
					eSpeed = value * 3;
					break;
				case 5:
					eType = "Armour";
					eName = "Plate";
					eArmour = value;
					break;
				case 6:
					eType = "Armour";
					eName = "Leather";
					eMentalDefense = value;
					break;
				case 7:
					eType = "Armour";
					eName = "Hide";
					eHealth = value;
					break;
				case 8:
					eType = "Armour";
					eName = "F-Field";
					eEnergy = value * 2;
					break;
			}
			eMaxDurability = eDurability = durability;
			ePrice = (value * 10) + durability;
			eUpgradeCost = eUpgradeCostBase = upgradeCost;
			eUpgradeCostBaseIncrement = 75;
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
		public string upgrade(int value, Random RndVal, bool max = false)
		{
			int Type = 0; 
			if (eType == "Weapon") Type = RndVal.Next(1, 5);
			if (eType == "Armour") Type = RndVal.Next(5, 9);
			string strUpgrade = "";
			long tmpDurability = eDurability,
				tmpUpgradeCost = eUpgradeCost;

            if (!max) value = RndVal.Next(1, value);
            eMaxDurability += value;
			eDurability = eMaxDurability;
			switch (Type)
			{
			
				case 1:
					eDamage += value;
					strUpgrade = string.Format(" Damage+{0:n0}", value);
					break;
				case 2:
					eHit += value;
					strUpgrade = string.Format(" Hit+{0:n0}", value);
					break;
				case 3:
					eMentalStrength += value;
					strUpgrade = string.Format(" Mental Str+{0:n0}", value);
					break;	
				case 4:
					eSpeed += value;
					strUpgrade = string.Format(" Speed+{0:n0}", value);
					break;
				case 5:
					eHealth += value * 3;
					strUpgrade = string.Format(" Health+{0:n0}", value * 3);
					break;
				case 6:
					eEnergy += value * 2;
					strUpgrade = string.Format(" Energy+{0:n0}", value * 2);
					break;
				case 7:
					eArmour += value;
					strUpgrade = string.Format(" Armour+{0:n0}", value);
					break;
				case 8:
					eMentalDefense += value;
					strUpgrade = string.Format(" Mental Def+{0:n0} ", value);
					break;
			}
			eUpgrade++;
			eUpgradeCost = roundValue(eUpgradeCost, eUpgradeCostBase, "up");
			// if (eUpgrade % 5 == 0) eUpgradeCostBase *= 2;
			// else
			eUpgradeCostBase += eUpgradeCostBaseIncrement;
			return String.Format("{0}+{1:n0} ({5:c0}) Dur:{2:n0}->{3:n0} {4}", eName, eUpgrade, tmpDurability, eDurability, strUpgrade, tmpUpgradeCost);
		}
		public string getName()
		{
			return (eName + "+" + eUpgrade).PadRight(12);
		}
		public string ToString(int originalDur = 0)
		{
			string retval = (eName + "+" + eUpgrade).PadRight(12);
			if (originalDur > 0)
				retval += String.Format(" Dur:{0:n0}->{1:n0}", originalDur, eDurability);
			else
				retval += String.Format(" Dur:{0:n0} T:{1}", eDurability, eType);
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
		public int CompareTo(Equipment CompEquipment)
		{
			return this.eUpgrade.CompareTo(CompEquipment.eUpgrade);
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
