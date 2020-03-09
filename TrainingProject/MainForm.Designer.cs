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
			this.cbTeamSelect = new System.Windows.Forms.ToolStripComboBox();
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
			this.btnAutomatic = new System.Windows.Forms.ToolStripSplitButton();
			this.mnuAutobattle = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPurchaseManager = new System.Windows.Forms.ToolStripMenuItem();
			this.pauseResumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWork = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuLongBattle = new System.Windows.Forms.ToolStripMenuItem();
			this.cboRepairPercent = new System.Windows.Forms.ToolStripComboBox();
			this.cboSaveCredits = new System.Windows.Forms.ToolStripComboBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.MainPannel = new System.Windows.Forms.FlowLayoutPanel();
			this.BreakTimer = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExport,
            this.cbTeamSelect,
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
			this.toolStrip1.Size = new System.Drawing.Size(493, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnExport
			// 
			this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuImport,
            this.countdownToolStripMenuItem});
			this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
			this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(32, 22);
			this.btnExport.Text = "Export / Import";
			this.btnExport.ButtonClick += new System.EventHandler(this.btnExport_ButtonClick);
			// 
			// mnuExport
			// 
			this.mnuExport.Name = "mnuExport";
			this.mnuExport.Size = new System.Drawing.Size(137, 22);
			this.mnuExport.Text = "Export";
			this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
			// 
			// mnuImport
			// 
			this.mnuImport.Name = "mnuImport";
			this.mnuImport.Size = new System.Drawing.Size(137, 22);
			this.mnuImport.Text = "Import";
			this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
			// 
			// countdownToolStripMenuItem
			// 
			this.countdownToolStripMenuItem.Name = "countdownToolStripMenuItem";
			this.countdownToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.countdownToolStripMenuItem.Text = "Countdown";
			this.countdownToolStripMenuItem.Click += new System.EventHandler(this.countdownToolStripMenuItem_Click);
			// 
			// cbTeamSelect
			// 
			this.cbTeamSelect.Name = "cbTeamSelect";
			this.cbTeamSelect.Size = new System.Drawing.Size(140, 25);
			this.cbTeamSelect.DropDownClosed += new System.EventHandler(this.cbTeamSelect_Change);
			// 
			// btnAddTeam
			// 
			this.btnAddTeam.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddTeam.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTeam.Image")));
			this.btnAddTeam.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddTeam.Name = "btnAddTeam";
			this.btnAddTeam.Size = new System.Drawing.Size(23, 22);
			this.btnAddTeam.Text = "Add Team";
			this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
			// 
			// btnAddRobo
			// 
			this.btnAddRobo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAddRobo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRobo.Image")));
			this.btnAddRobo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddRobo.Name = "btnAddRobo";
			this.btnAddRobo.Size = new System.Drawing.Size(23, 22);
			this.btnAddRobo.Text = "Add Robo";
			this.btnAddRobo.Click += new System.EventHandler(this.btnAddRobo_Click);
			// 
			// btnArenaLvl
			// 
			this.btnArenaLvl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnArenaLvl.Image = ((System.Drawing.Image)(resources.GetObject("btnArenaLvl.Image")));
			this.btnArenaLvl.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnArenaLvl.Name = "btnArenaLvl";
			this.btnArenaLvl.Size = new System.Drawing.Size(23, 22);
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
			this.btnShop.Size = new System.Drawing.Size(32, 22);
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
			this.btnResearchDev.Size = new System.Drawing.Size(23, 22);
			this.btnResearchDev.Text = "Research and Development";
			this.btnResearchDev.Click += new System.EventHandler(this.btnResearchDev_Click);
			// 
			// btnMonsterDen
			// 
			this.btnMonsterDen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnMonsterDen.Image = ((System.Drawing.Image)(resources.GetObject("btnMonsterDen.Image")));
			this.btnMonsterDen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMonsterDen.Name = "btnMonsterDen";
			this.btnMonsterDen.Size = new System.Drawing.Size(23, 22);
			this.btnMonsterDen.Text = "Monster Den";
			this.btnMonsterDen.Click += new System.EventHandler(this.btnMonsterDen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnFight
			// 
			this.btnFight.BackColor = System.Drawing.SystemColors.Control;
			this.btnFight.BackgroundImage = global::TrainingProject.Properties.Resources.fight1;
			this.btnFight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnFight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFight.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBossFight});
			this.btnFight.Image = ((System.Drawing.Image)(resources.GetObject("btnFight.Image")));
			this.btnFight.ImageTransparentColor = System.Drawing.Color.White;
			this.btnFight.Name = "btnFight";
			this.btnFight.Size = new System.Drawing.Size(32, 22);
			this.btnFight.Text = "Fight";
			this.btnFight.Click += new System.EventHandler(this.btnFight_Click);
			// 
			// mnuBossFight
			// 
			this.mnuBossFight.Name = "mnuBossFight";
			this.mnuBossFight.Size = new System.Drawing.Size(98, 22);
			this.mnuBossFight.Text = "Boss";
			this.mnuBossFight.Click += new System.EventHandler(this.mnuBossFight_Click);
			// 
			// btnAutomatic
			// 
			this.btnAutomatic.BackgroundImage = global::TrainingProject.Properties.Resources.Auto;
			this.btnAutomatic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.btnAutomatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAutomatic.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAutobattle,
            this.btnPurchaseManager,
            this.pauseResumeToolStripMenuItem,
            this.mnuWork,
            this.mnuLongBattle,
            this.cboRepairPercent,
            this.cboSaveCredits});
			this.btnAutomatic.Image = global::TrainingProject.Properties.Resources.Auto;
			this.btnAutomatic.ImageTransparentColor = System.Drawing.Color.White;
			this.btnAutomatic.Name = "btnAutomatic";
			this.btnAutomatic.Size = new System.Drawing.Size(32, 22);
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
			// btnPurchaseManager
			// 
			this.btnPurchaseManager.Name = "btnPurchaseManager";
			this.btnPurchaseManager.Size = new System.Drawing.Size(181, 22);
			this.btnPurchaseManager.Text = "Purchase Manager";
			this.btnPurchaseManager.Click += new System.EventHandler(this.btnPurchaseManager_Click);
			// 
			// pauseResumeToolStripMenuItem
			// 
			this.pauseResumeToolStripMenuItem.Name = "pauseResumeToolStripMenuItem";
			this.pauseResumeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.pauseResumeToolStripMenuItem.Text = "Pause / Resume";
			this.pauseResumeToolStripMenuItem.Click += new System.EventHandler(this.pauseResumeToolStripMenuItem_Click);
			// 
			// mnuWork
			// 
			this.mnuWork.Name = "mnuWork";
			this.mnuWork.Size = new System.Drawing.Size(181, 22);
			this.mnuWork.Text = "Back to work";
			this.mnuWork.Click += new System.EventHandler(this.mnuWork_Click);
			// 
			// mnuLongBattle
			// 
			this.mnuLongBattle.Name = "mnuLongBattle";
			this.mnuLongBattle.Size = new System.Drawing.Size(181, 22);
			this.mnuLongBattle.Text = "Long Battle";
			this.mnuLongBattle.Click += new System.EventHandler(this.mnuLongBattle_Click);
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
			this.Name = "MainForm";
			this.Text = "Training Form";
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
		private System.Windows.Forms.ToolStripMenuItem mnuWork;
		private System.Windows.Forms.ToolStripMenuItem btnPurchaseManager;
		private System.Windows.Forms.Timer BreakTimer;
		private System.Windows.Forms.ToolStripSplitButton btnFight;
		private System.Windows.Forms.ToolStripMenuItem mnuBossFight;
		private System.Windows.Forms.ToolStripMenuItem countdownToolStripMenuItem;
	}
}

