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
			this.cbTeamSelect = new System.Windows.Forms.ToolStripComboBox();
			this.btnAddTeam = new System.Windows.Forms.ToolStripButton();
			this.btnAddRobo = new System.Windows.Forms.ToolStripButton();
			this.btnFight = new System.Windows.Forms.ToolStripButton();
			this.btnArenaLvl = new System.Windows.Forms.ToolStripButton();
			this.btnInterval = new System.Windows.Forms.ToolStripButton();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.MainPannel = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMonsterDen = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbTeamSelect,
            this.btnAddTeam,
            this.btnAddRobo,
            this.btnArenaLvl,
            this.btnMonsterDen,
            this.btnFight,
            this.btnInterval});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(554, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
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
			this.MainPannel.Size = new System.Drawing.Size(554, 393);
			this.MainPannel.TabIndex = 2;
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
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(554, 423);
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
	}
}

