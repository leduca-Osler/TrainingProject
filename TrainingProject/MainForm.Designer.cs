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
			this.cbTeamSelect = new System.Windows.Forms.ToolStripComboBox();
			this.btnAddTeam = new System.Windows.Forms.ToolStripButton();
			this.btnAddRobo = new System.Windows.Forms.ToolStripButton();
			this.btnArenaLvl = new System.Windows.Forms.ToolStripButton();
			this.btnMonsterDen = new System.Windows.Forms.ToolStripButton();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.levelUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnFight = new System.Windows.Forms.ToolStripButton();
			this.btnInterval = new System.Windows.Forms.ToolStripButton();
			this.btnAutomatic = new System.Windows.Forms.ToolStripButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.MainPannel = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btnMonsterDen,
            this.toolStripSplitButton1,
            this.toolStripSeparator1,
            this.btnFight,
            this.btnInterval,
            this.btnAutomatic});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(421, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnExport
			// 
			this.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExport,
            this.mnuImport});
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
			this.mnuExport.Size = new System.Drawing.Size(152, 22);
			this.mnuExport.Text = "Export";
			this.mnuExport.Click += new System.EventHandler(this.mnuExport_Click);
			// 
			// mnuImport
			// 
			this.mnuImport.Name = "mnuImport";
			this.mnuImport.Size = new System.Drawing.Size(152, 22);
			this.mnuImport.Text = "Import";
			this.mnuImport.Click += new System.EventHandler(this.mnuImport_Click);
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
			// toolStripSplitButton1
			// 
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelUpToolStripMenuItem,
            this.restockToolStripMenuItem});
			this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
			this.toolStripSplitButton1.Text = "Shop";
			// 
			// levelUpToolStripMenuItem
			// 
			this.levelUpToolStripMenuItem.Name = "levelUpToolStripMenuItem";
			this.levelUpToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.levelUpToolStripMenuItem.Text = "Level Up";
			// 
			// restockToolStripMenuItem
			// 
			this.restockToolStripMenuItem.Name = "restockToolStripMenuItem";
			this.restockToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.restockToolStripMenuItem.Text = "Restock";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnFight
			// 
			this.btnFight.BackColor = System.Drawing.Color.Transparent;
			this.btnFight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnFight.Image = ((System.Drawing.Image)(resources.GetObject("btnFight.Image")));
			this.btnFight.ImageTransparentColor = System.Drawing.Color.White;
			this.btnFight.Name = "btnFight";
			this.btnFight.Size = new System.Drawing.Size(23, 22);
			this.btnFight.Text = "Fight";
			this.btnFight.Click += new System.EventHandler(this.btnFight_Click);
			// 
			// btnInterval
			// 
			this.btnInterval.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnInterval.Image = ((System.Drawing.Image)(resources.GetObject("btnInterval.Image")));
			this.btnInterval.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnInterval.Name = "btnInterval";
			this.btnInterval.Size = new System.Drawing.Size(23, 22);
			this.btnInterval.Text = "toolStripButton1";
			this.btnInterval.Click += new System.EventHandler(this.btnInterval_Click);
			// 
			// btnAutomatic
			// 
			this.btnAutomatic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAutomatic.Image = ((System.Drawing.Image)(resources.GetObject("btnAutomatic.Image")));
			this.btnAutomatic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAutomatic.Name = "btnAutomatic";
			this.btnAutomatic.Size = new System.Drawing.Size(23, 22);
			this.btnAutomatic.Text = "Auto Battle";
			this.btnAutomatic.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAutomatic_MouseDown);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainPannel
			// 
			this.MainPannel.AutoSize = true;
			this.MainPannel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.MainPannel.Location = new System.Drawing.Point(0, 28);
			this.MainPannel.Name = "MainPannel";
			this.MainPannel.Size = new System.Drawing.Size(420, 388);
			this.MainPannel.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(421, 423);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.MainPannel);
			this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "MainForm";
			this.Text = "Main Form";
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
        private System.Windows.Forms.ToolStripButton btnFight;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel MainPannel;
		private System.Windows.Forms.ToolStripButton btnInterval;
		private System.Windows.Forms.ToolStripButton btnArenaLvl;
		private System.Windows.Forms.ToolStripButton btnMonsterDen;
		private System.Windows.Forms.ToolStripButton btnAutomatic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
		private System.Windows.Forms.ToolStripMenuItem levelUpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem restockToolStripMenuItem;
		private System.Windows.Forms.ToolStripSplitButton btnExport;
		private System.Windows.Forms.ToolStripMenuItem mnuExport;
		private System.Windows.Forms.ToolStripMenuItem mnuImport;
	}
}

