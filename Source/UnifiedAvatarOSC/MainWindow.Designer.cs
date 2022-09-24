namespace UnifiedAvatarOSC
{
    partial class MainWindow
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
            System.Windows.Forms.FlowLayoutPanel updateIntervalAndLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.updateInterval = new System.Windows.Forms.NumericUpDown();
            this.providerUpdater = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OpenModulesFolderBtn = new System.Windows.Forms.Button();
            this.hideOnStartup = new System.Windows.Forms.CheckBox();
            this.loadAllModulesBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buildAndTestLoadsAll = new System.Windows.Forms.CheckBox();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.loadedModules = new System.Windows.Forms.ListBox();
            this.uiUpdater = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            updateIntervalAndLabel = new System.Windows.Forms.FlowLayoutPanel();
            updateIntervalAndLabel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateInterval)).BeginInit();
            this.trayIconStrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateIntervalAndLabel
            // 
            updateIntervalAndLabel.Controls.Add(this.label1);
            updateIntervalAndLabel.Controls.Add(this.updateInterval);
            resources.ApplyResources(updateIntervalAndLabel, "updateIntervalAndLabel");
            updateIntervalAndLabel.Name = "updateIntervalAndLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // updateInterval
            // 
            resources.ApplyResources(this.updateInterval, "updateInterval");
            this.updateInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.updateInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.updateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updateInterval.Name = "updateInterval";
            this.updateInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updateInterval.ValueChanged += new System.EventHandler(this.updateInterval_ValueChanged);
            // 
            // providerUpdater
            // 
            this.providerUpdater.Enabled = true;
            this.providerUpdater.Interval = 1;
            this.providerUpdater.Tick += new System.EventHandler(this.secondUpdater_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconStrip;
            resources.ApplyResources(this.trayIcon, "trayIcon");
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayIconStrip
            // 
            this.trayIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.trayIconStrip.Name = "trayIconStrip";
            resources.ApplyResources(this.trayIconStrip, "trayIconStrip");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.OpenModulesFolderBtn);
            this.groupBox2.Controls.Add(this.hideOnStartup);
            this.groupBox2.Controls.Add(this.loadAllModulesBtn);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(updateIntervalAndLabel);
            this.groupBox2.Controls.Add(this.buildAndTestLoadsAll);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // OpenModulesFolderBtn
            // 
            this.OpenModulesFolderBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.OpenModulesFolderBtn, "OpenModulesFolderBtn");
            this.OpenModulesFolderBtn.Name = "OpenModulesFolderBtn";
            this.OpenModulesFolderBtn.UseVisualStyleBackColor = true;
            this.OpenModulesFolderBtn.Click += new System.EventHandler(this.OpenModulesFolderBtn_Click);
            // 
            // hideOnStartup
            // 
            resources.ApplyResources(this.hideOnStartup, "hideOnStartup");
            this.hideOnStartup.Checked = true;
            this.hideOnStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideOnStartup.Name = "hideOnStartup";
            this.hideOnStartup.UseVisualStyleBackColor = true;
            this.hideOnStartup.CheckedChanged += new System.EventHandler(this.hideOnStartup_CheckedChanged);
            // 
            // loadAllModulesBtn
            // 
            this.loadAllModulesBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.loadAllModulesBtn, "loadAllModulesBtn");
            this.loadAllModulesBtn.Name = "loadAllModulesBtn";
            this.loadAllModulesBtn.UseVisualStyleBackColor = true;
            this.loadAllModulesBtn.Click += new System.EventHandler(this.loadAllModulesBtn_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buildAndTestLoadsAll
            // 
            resources.ApplyResources(this.buildAndTestLoadsAll, "buildAndTestLoadsAll");
            this.buildAndTestLoadsAll.Checked = true;
            this.buildAndTestLoadsAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buildAndTestLoadsAll.Name = "buildAndTestLoadsAll";
            this.buildAndTestLoadsAll.UseVisualStyleBackColor = true;
            this.buildAndTestLoadsAll.CheckedChanged += new System.EventHandler(this.buildAndTestLoadsAll_CheckedChanged);
            // 
            // logTextBox
            // 
            this.logTextBox.BackColor = System.Drawing.Color.Black;
            this.logTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextBox.ForeColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.logTextBox, "logTextBox");
            this.logTextBox.Name = "logTextBox";
            // 
            // loadedModules
            // 
            this.loadedModules.BackColor = System.Drawing.Color.Black;
            this.loadedModules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadedModules.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.loadedModules.FormattingEnabled = true;
            resources.ApplyResources(this.loadedModules, "loadedModules");
            this.loadedModules.Name = "loadedModules";
            this.loadedModules.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.loadedModules_DrawItem);
            // 
            // uiUpdater
            // 
            this.uiUpdater.Enabled = true;
            this.uiUpdater.Interval = 1000;
            this.uiUpdater.Tick += new System.EventHandler(this.uiUpdater_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imageList1, "imageList1");
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.loadedModules);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            updateIntervalAndLabel.ResumeLayout(false);
            updateIntervalAndLabel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updateInterval)).EndInit();
            this.trayIconStrip.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer providerUpdater;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown updateInterval;
        private System.Windows.Forms.CheckBox buildAndTestLoadsAll;
        private System.Windows.Forms.RichTextBox logTextBox;
        private System.Windows.Forms.Timer uiUpdater;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListBox loadedModules;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button loadAllModulesBtn;
        private System.Windows.Forms.CheckBox hideOnStartup;
        private System.Windows.Forms.Button OpenModulesFolderBtn;
    }
}

