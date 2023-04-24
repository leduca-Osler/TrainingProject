namespace TrainingApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnExport = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuImport = new System.Windows.Forms.ToolStripMenuItem();
			this.countdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BreakTimersOff = new System.Windows.Forms.ToolStripMenuItem();
			this.fixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cbTeamSelect = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.btnAddTeam = new System.Windows.Forms.ToolStripButton();
			this.btnAddRobo = new System.Windows.Forms.ToolStripButton();
			this.btnArenaLvl = new System.Windows.Forms.ToolStripButton();
			this.btnShop = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuShopLevelUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRestockShop = new System.Windows.Forms.ToolStripMenuItem();
			this.btnResearchDev = new System.Windows.Forms.ToolStripButton();
			this.btnMonsterDen = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnFight = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuBossFight = new System.Windows.Forms.ToolStripMenuItem();
			this.difficultyFightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnAutomatic = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuAutobattle = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPurchaseManager = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuLongBattle = new System.Windows.Forms.ToolStripMenuItem();
			this.fastForwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.repairEquipAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cboRepairPercent = new System.Windows.Forms.ToolStripComboBox();
			this.purchaseUpgradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cboSaveCredits = new System.Windows.Forms.ToolStripComboBox();
			this.mnuPriority = new System.Windows.Forms.ToolStripComboBox();
			this.maxHoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.txtMaxManagerHrs = new System.Windows.Forms.ToolStripTextBox();
			this.mnuDisplayJackpot = new System.Windows.Forms.ToolStripMenuItem();
			this.increaseJackpotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.increaseJackpot10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decreaseJackpotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.decreaseJackpot10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MinJackpotLevel = new System.Windows.Forms.ToolStripTextBox();
			this.mnuComunityOutreach = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.MainPannel = new System.Windows.Forms.FlowLayoutPanel();
			this.BreakTimer = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.cbTeamSelect,
            this.toolStripLabel1,
            this.btnAddTeam,
            this.btnAddRobo,
            this.btnArenaLvl,
            this.btnShop,
            this.btnResearchDev,
            this.btnMonsterDen,
            this.toolStripSeparator1,
            this.btnFight,
            this.btnAutomatic});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(493, 27);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnExport
			// 
			this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuImport,
            this.countdownToolStripMenuItem,
            this.BreakTimersOff,
            this.fixToolStripMenuItem});
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(36, 24);
			this.btnExport.Text = "Export / Import";
			this.btnExport.ButtonClick += new System.EventHandler(this.btnExport_ButtonClick);
			// 
			// mnuExport
			// 
			this.mnuExport.Name = "mnuExport";
			this.mnuExport.Size = new System.Drawing.Size(155, 22);
			this.mnuExport.Text = "Export";
			this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
			// 
			// mnuImport
			// 
			this.mnuImport.Name = "mnuImport";
			this.mnuImport.Size = new System.Drawing.Size(155, 22);
			this.mnuImport.Text = "Import";
			this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
			// 
			// countdownToolStripMenuItem
			// 
			this.countdownToolStripMenuItem.Name = "countdownToolStripMenuItem";
			this.countdownToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.countdownToolStripMenuItem.Text = "Countdown";
			this.countdownToolStripMenuItem.Click += new System.EventHandler(this.countdownToolStripMenuItem_Click);
			// 
			// BreakTimersOff
			// 
			this.BreakTimersOff.Name = "BreakTimersOff";
			this.BreakTimersOff.Size = new System.Drawing.Size(155, 22);
			this.BreakTimersOff.Text = "Break Timer On";
			this.BreakTimersOff.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// fixToolStripMenuItem
			// 
			this.fixToolStripMenuItem.Name = "fixToolStripMenuItem";
			this.fixToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.fixToolStripMenuItem.Text = "Fix";
			this.fixToolStripMenuItem.Click += new System.EventHandler(this.fixToolStripMenuItem_Click);
			// 
			// cbTeamSelect
			// 
			this.cbTeamSelect.Name = "cbTeamSelect";
			this.cbTeamSelect.Size = new System.Drawing.Size(140, 27);
			this.cbTeamSelect.DropDownClosed += new System.EventHandler(this.cbTeamSelect_Change);
			this.cbTeamSelect.Leave += new System.EventHandler(this.cbTeamSelect_Change);
			this.cbTeamSelect.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(17, 24);
			this.toolStripLabel1.Text = "--";
			// 
			// btnAddTeam
			// 
			this.btnAddTeam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddTeam.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTeam.Image")));
			this.btnAddTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddTeam.Name = "btnAddTeam";
			this.btnAddTeam.Size = new System.Drawing.Size(24, 24);
			this.btnAddTeam.Text = "Add Team";
			this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
			// 
			// btnAddRobo
			// 
			this.btnAddRobo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddRobo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRobo.Image")));
			this.btnAddRobo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddRobo.Name = "btnAddRobo";
			this.btnAddRobo.Size = new System.Drawing.Size(24, 24);
			this.btnAddRobo.Text = "Add Robo";
			this.btnAddRobo.Click += new System.EventHandler(this.btnAddRobo_Click);
			// 
			// btnArenaLvl
			// 
			this.btnArenaLvl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnArenaLvl.Image = ((System.Drawing.Image)(resources.GetObject("btnArenaLvl.Image")));
			this.btnArenaLvl.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnArenaLvl.Name = "btnArenaLvl";
			this.btnArenaLvl.Size = new System.Drawing.Size(24, 24);
			this.btnArenaLvl.Text = "Arena Level";
			this.btnArenaLvl.Click += new System.EventHandler(this.btnArenaLvl_Click);
			// 
			// btnShop
			// 
			this.btnShop.BackColor = System.Drawing.SystemColors.Control;
			this.btnShop.BackgroundImage = global::TrainingProject.Properties.Resources.Shop1;
			this.btnShop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnShop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnShop.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShopLevelUp,
            this.mnuRestockShop});
			this.btnShop.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnShop.Image = global::TrainingProject.Properties.Resources.Shop1;
			this.btnShop.ImageTransparentColor = System.Drawing.Color.White;
			this.btnShop.Name = "btnShop";
			this.btnShop.Size = new System.Drawing.Size(36, 24);
			this.btnShop.Text = "Shop";
			this.btnShop.ButtonClick += new System.EventHandler(this.btnShop_ButtonClick);
			// 
			// mnuShopLevelUp
			// 
			this.mnuShopLevelUp.Name = "mnuShopLevelUp";
			this.mnuShopLevelUp.Size = new System.Drawing.Size(119, 22);
			this.mnuShopLevelUp.Text = "Level Up";
			this.mnuShopLevelUp.Click += new System.EventHandler(this.levelUpToolStripMenuItem_Click);
			// 
			// mnuRestockShop
			// 
			this.mnuRestockShop.Name = "mnuRestockShop";
			this.mnuRestockShop.Size = new System.Drawing.Size(119, 22);
			this.mnuRestockShop.Text = "Restock";
			this.mnuRestockShop.Click += new System.EventHandler(this.mnuRestockShop_Click);
			// 
			// btnResearchDev
			// 
			this.btnResearchDev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnResearchDev.Image = global::TrainingProject.Properties.Resources.Repair;
			this.btnResearchDev.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnResearchDev.Name = "btnResearchDev";
			this.btnResearchDev.Size = new System.Drawing.Size(24, 24);
			this.btnResearchDev.Text = "Research and Development";
			this.btnResearchDev.Click += new System.EventHandler(this.btnResearchDev_Click);
			// 
			// btnMonsterDen
			// 
			this.btnMonsterDen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnMonsterDen.Image = ((System.Drawing.Image)(resources.GetObject("btnMonsterDen.Image")));
			this.btnMonsterDen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMonsterDen.Name = "btnMonsterDen";
			this.btnMonsterDen.Size = new System.Drawing.Size(24, 24);
			this.btnMonsterDen.Text = "Monster Den";
			this.btnMonsterDen.Click += new System.EventHandler(this.btnMonsterDen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// btnFight
			// 
			this.btnFight.BackColor = System.Drawing.SystemColors.Control;
			this.btnFight.BackgroundImage = global::TrainingProject.Properties.Resources.fight1;
			this.btnFight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnFight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBossFight,
            this.difficultyFightToolStripMenuItem});
			this.btnFight.Image = ((System.Drawing.Image)(resources.GetObject("btnFight.Image")));
			this.btnFight.ImageTransparentColor = System.Drawing.Color.White;
			this.btnFight.Name = "btnFight";
			this.btnFight.Size = new System.Drawing.Size(36, 24);
			this.btnFight.Text = "Fight";
			this.btnFight.Click += new System.EventHandler(this.btnFight_Click);
			// 
			// mnuBossFight
			// 
			this.mnuBossFight.Enabled = false;
			this.mnuBossFight.Name = "mnuBossFight";
			this.mnuBossFight.Size = new System.Drawing.Size(152, 22);
			this.mnuBossFight.Text = "Boss";
			this.mnuBossFight.Visible = false;
			this.mnuBossFight.Click += new System.EventHandler(this.mnuBossFight_Click);
			// 
			// difficultyFightToolStripMenuItem
			// 
			this.difficultyFightToolStripMenuItem.Enabled = false;
			this.difficultyFightToolStripMenuItem.Name = "difficultyFightToolStripMenuItem";
			this.difficultyFightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.difficultyFightToolStripMenuItem.Text = "Difficulty Fight";
			this.difficultyFightToolStripMenuItem.Visible = false;
			this.difficultyFightToolStripMenuItem.Click += new System.EventHandler(this.difficultyFightToolStripMenuItem_Click);
			// 
			// btnAutomatic
			// 
			this.btnAutomatic.BackgroundImage = global::TrainingProject.Properties.Resources.Auto;
			this.btnAutomatic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnAutomatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAutomatic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAutobattle,
            this.pauseResumeToolStripMenuItem,
            this.btnPurchaseManager,
            this.mnuLongBattle,
            this.fastForwardToolStripMenuItem,
            this.repairEquipAtToolStripMenuItem,
            this.cboRepairPercent,
            this.purchaseUpgradeToolStripMenuItem,
            this.cboSaveCredits,
            this.mnuPriority,
            this.maxHoursToolStripMenuItem,
            this.txtMaxManagerHrs,
            this.mnuDisplayJackpot,
            this.mnuComunityOutreach});
			this.btnAutomatic.Image = global::TrainingProject.Properties.Resources.Auto;
			this.btnAutomatic.ImageTransparentColor = System.Drawing.Color.White;
			this.btnAutomatic.Name = "btnAutomatic";
			this.btnAutomatic.Size = new System.Drawing.Size(36, 24);
			this.btnAutomatic.Text = "Auto Battle";
			this.btnAutomatic.ButtonClick += new System.EventHandler(this.btnAutomatic_ButtonClick);
			// 
			// mnuAutobattle
			// 
			this.mnuAutobattle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.showToolStripMenuItem});
			this.mnuAutobattle.Name = "mnuAutobattle";
			this.mnuAutobattle.Size = new System.Drawing.Size(181, 22);
			this.mnuAutobattle.Text = "Stats";
			this.mnuAutobattle.Click += new System.EventHandler(this.mnuAutobattle_Click);
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.mnuResetAuto_Click);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.mnuShowStats_Click);
			// 
			// pauseResumeToolStripMenuItem
			// 
			this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
			this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.pauseResumeToolStripMenuItem.Text = "Pause / Resume";
			this.pauseResumeToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeToolStripMenuItem_Click);
			// 
			// btnPurchaseManager
			// 
			this.btnPurchaseManager.Name = "btnPurchaseManager";
			this.btnPurchaseManager.Size = new System.Drawing.Size(181, 22);
			this.btnPurchaseManager.Text = "Purchase Manager";
			this.btnPurchaseManager.Click += new System.EventHandler(this.btnPurchaseManager_Click);
			// 
			// mnuLongBattle
			// 
			this.mnuLongBattle.Name = "mnuLongBattle";
			this.mnuLongBattle.Size = new System.Drawing.Size(181, 22);
			this.mnuLongBattle.Text = "Long Battle";
			this.mnuLongBattle.Click += new System.EventHandler(this.mnuLongBattle_Click);
			// 
			// fastForwardToolStripMenuItem
			// 
			this.fastForwardToolStripMenuItem.Name = "fastForwardToolStripMenuItem";
			this.fastForwardToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.fastForwardToolStripMenuItem.Text = "Fast Forward";
			this.fastForwardToolStripMenuItem.Click += new System.EventHandler(this.fastForwardToolStripMenuItem_Click);
			// 
			// repairEquipAtToolStripMenuItem
			// 
			this.repairEquipAtToolStripMenuItem.Enabled = false;
			this.repairEquipAtToolStripMenuItem.Name = "repairEquipAtToolStripMenuItem";
			this.repairEquipAtToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.repairEquipAtToolStripMenuItem.Text = "Repair equip at %";
			// 
			// cboRepairPercent
			// 
			this.cboRepairPercent.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.3",
            "0.4",
            "0.5",
            "0.6",
            "0.7",
            "0.8",
            "0.9",
            "1"});
			this.cboRepairPercent.Name = "cboRepairPercent";
			this.cboRepairPercent.Size = new System.Drawing.Size(121, 23);
			this.cboRepairPercent.ToolTipText = "Durability Percent to repair equipment";
			this.cboRepairPercent.SelectedIndexChanged += new System.EventHandler(this.cboRepairPercent_SelectedIndexChanged);
			// 
			// purchaseUpgradeToolStripMenuItem
			// 
			this.purchaseUpgradeToolStripMenuItem.Enabled = false;
			this.purchaseUpgradeToolStripMenuItem.Name = "purchaseUpgradeToolStripMenuItem";
			this.purchaseUpgradeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.purchaseUpgradeToolStripMenuItem.Text = "Purchase / Upgrade";
			// 
			// cboSaveCredits
			// 
			this.cboSaveCredits.Items.AddRange(new object[] {
            "Yes",
            "No"});
			this.cboSaveCredits.Name = "cboSaveCredits";
			this.cboSaveCredits.Size = new System.Drawing.Size(121, 23);
			this.cboSaveCredits.ToolTipText = "Purchase / upgrade equipment";
			this.cboSaveCredits.SelectedIndexChanged += new System.EventHandler(this.cboSaveCredits_SelectedIndexChanged);
			// 
			// mnuPriority
			// 
			this.mnuPriority.Items.AddRange(new object[] {
            "Prioritize Equipment",
            "Prioritize Robot"});
			this.mnuPriority.Name = "mnuPriority";
			this.mnuPriority.Size = new System.Drawing.Size(121, 23);
			this.mnuPriority.SelectedIndexChanged += new System.EventHandler(this.mnuPriority_SelectedIndexChanged);
			this.mnuPriority.Click += new System.EventHandler(this.mnuPriority_Click);
			// 
			// maxHoursToolStripMenuItem
			// 
			this.maxHoursToolStripMenuItem.Enabled = false;
			this.maxHoursToolStripMenuItem.Name = "maxHoursToolStripMenuItem";
			this.maxHoursToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.maxHoursToolStripMenuItem.Text = "Max Hours";
			// 
			// txtMaxManagerHrs
			// 
			this.txtMaxManagerHrs.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.txtMaxManagerHrs.Name = "txtMaxManagerHrs";
			this.txtMaxManagerHrs.Size = new System.Drawing.Size(100, 23);
			this.txtMaxManagerHrs.Text = "10";
			this.txtMaxManagerHrs.TextChanged += new System.EventHandler(this.txtMaxManagerHrs_TextChanged);
			// 
			// mnuDisplayJackpot
			// 
			this.mnuDisplayJackpot.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.increaseJackpotToolStripMenuItem,
            this.increaseJackpot10ToolStripMenuItem,
            this.decreaseJackpotToolStripMenuItem,
            this.decreaseJackpot10ToolStripMenuItem,
            this.minLevelToolStripMenuItem,
            this.MinJackpotLevel});
			this.mnuDisplayJackpot.Name = "mnuDisplayJackpot";
			this.mnuDisplayJackpot.Size = new System.Drawing.Size(181, 22);
			this.mnuDisplayJackpot.Text = "3";
			// 
			// increaseJackpotToolStripMenuItem
			// 
			this.increaseJackpotToolStripMenuItem.Name = "increaseJackpotToolStripMenuItem";
			this.increaseJackpotToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.increaseJackpotToolStripMenuItem.Text = "Increase Jackpot";
			this.increaseJackpotToolStripMenuItem.Click += new System.EventHandler(this.increaseJackpotToolStripMenuItem_Click);
			// 
			// increaseJackpot10ToolStripMenuItem
			// 
			this.increaseJackpot10ToolStripMenuItem.Name = "increaseJackpot10ToolStripMenuItem";
			this.increaseJackpot10ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.increaseJackpot10ToolStripMenuItem.Text = "Increase Jackpot 10";
			this.increaseJackpot10ToolStripMenuItem.Click += new System.EventHandler(this.increaseJackpot10ToolStripMenuItem_Click);
			// 
			// decreaseJackpotToolStripMenuItem
			// 
			this.decreaseJackpotToolStripMenuItem.Name = "decreaseJackpotToolStripMenuItem";
			this.decreaseJackpotToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.decreaseJackpotToolStripMenuItem.Text = "Decrease Jackpot";
			this.decreaseJackpotToolStripMenuItem.Click += new System.EventHandler(this.decreaseJackpotToolStripMenuItem_Click);
			// 
			// decreaseJackpot10ToolStripMenuItem
			// 
			this.decreaseJackpot10ToolStripMenuItem.Name = "decreaseJackpot10ToolStripMenuItem";
			this.decreaseJackpot10ToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.decreaseJackpot10ToolStripMenuItem.Text = "Decrease Jackpot 10";
			this.decreaseJackpot10ToolStripMenuItem.Click += new System.EventHandler(this.decreaseJackpot10ToolStripMenuItem_Click);
			// 
			// minLevelToolStripMenuItem
			// 
			this.minLevelToolStripMenuItem.Enabled = false;
			this.minLevelToolStripMenuItem.Name = "minLevelToolStripMenuItem";
			this.minLevelToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.minLevelToolStripMenuItem.Text = "Min Value";
			// 
			// MinJackpotLevel
			// 
			this.MinJackpotLevel.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.MinJackpotLevel.Name = "MinJackpotLevel";
			this.MinJackpotLevel.Size = new System.Drawing.Size(100, 23);
			this.MinJackpotLevel.Text = "1";
			this.MinJackpotLevel.TextChanged += new System.EventHandler(this.MinJackpotLevel_TextChanged);
			// 
			// mnuComunityOutreach
			// 
			this.mnuComunityOutreach.Name = "mnuComunityOutreach";
			this.mnuComunityOutreach.Size = new System.Drawing.Size(181, 22);
			this.mnuComunityOutreach.Text = "Comunity Outreach";
			this.mnuComunityOutreach.Click += new System.EventHandler(this.mnuComunityOutreach_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainPannel
			// 
			this.MainPannel.AutoScroll = true;
			this.MainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPannel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.MainPannel.Location = new System.Drawing.Point(0, 0);
			this.MainPannel.Name = "MainPannel";
			this.MainPannel.Size = new System.Drawing.Size(493, 510);
			this.MainPannel.TabIndex = 2;
			this.MainPannel.WrapContents = false;
			// 
			// BreakTimer
			// 
			this.BreakTimer.Enabled = true;
			this.BreakTimer.Interval = 1000;
			this.BreakTimer.Tick += new System.EventHandler(this.BreakTimer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(493, 510);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.MainPannel);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Training Form";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddTeam;
        private System.Windows.Forms.ToolStripComboBox cbTeamSelect;
        private System.Windows.Forms.ToolStripButton btnAddRobo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel MainPannel;
		private System.Windows.Forms.ToolStripButton btnArenaLvl;
		private System.Windows.Forms.ToolStripButton btnMonsterDen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSplitButton btnShop;
		private System.Windows.Forms.ToolStripMenuItem mnuShopLevelUp;
		private System.Windows.Forms.ToolStripMenuItem mnuRestockShop;
		private System.Windows.Forms.ToolStripSplitButton btnExport;
		private System.Windows.Forms.ToolStripMenuItem mnuExport;
		private System.Windows.Forms.ToolStripMenuItem mnuImport;
		private System.Windows.Forms.ToolStripSplitButton btnAutomatic;
		private System.Windows.Forms.ToolStripMenuItem mnuAutobattle;
		private System.Windows.Forms.ToolStripMenuItem pauseResumeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripComboBox cboRepairPercent;
		private System.Windows.Forms.ToolStripComboBox cboSaveCredits;
		private System.Windows.Forms.ToolStripButton btnResearchDev;
		private System.Windows.Forms.ToolStripMenuItem mnuLongBattle;
		private System.Windows.Forms.ToolStripMenuItem btnPurchaseManager;
		private System.Windows.Forms.Timer BreakTimer;
		private System.Windows.Forms.ToolStripSplitButton btnFight;
		private System.Windows.Forms.ToolStripMenuItem mnuBossFight;
		private System.Windows.Forms.ToolStripMenuItem countdownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem difficultyFightToolStripMenuItem;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox txtMaxManagerHrs;
		private System.Windows.Forms.ToolStripMenuItem mnuDisplayJackpot;
		private System.Windows.Forms.ToolStripMenuItem increaseJackpotToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decreaseJackpotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseJackpot10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem decreaseJackpot10ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minLevelToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox MinJackpotLevel;
		private System.Windows.Forms.ToolStripMenuItem BreakTimersOff;
		private System.Windows.Forms.ToolStripMenuItem repairEquipAtToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem purchaseUpgradeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem maxHoursToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fastForwardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuComunityOutreach;
		private System.Windows.Forms.ToolStripComboBox mnuPriority;
		private System.Windows.Forms.ToolStripMenuItem fixToolStripMenuItem;
	}
}

