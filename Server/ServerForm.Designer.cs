namespace Server
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSiteSetup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnPathSetup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbxTimeSystem = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerSiteSetup = new System.ComponentModel.BackgroundWorker();
            this.serverSetup = new Server.ServerSetup();
            this.connectDatabse = new Server.ConnectDatabase();
            this.remoteControl = new Server.RemoteControl();
            this.serverSendingCommand = new Server.SendingCommand();
            this.monitoring = new Server.Monitoring();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 183);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1087, 670);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.serverSetup);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1079, 641);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.connectDatabse);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1079, 641);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Database Setting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1079, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sending Command";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 3);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1073, 635);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.remoteControl);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1065, 606);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Remote Control";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.serverSendingCommand);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1065, 606);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Data Command";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.monitoring);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1079, 641);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Monitoring";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnLog,
            this.toolStripSeparator1,
            this.tsbtnSiteSetup,
            this.toolStripSeparator3,
            this.tsbtnPathSetup,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 120);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(315, 47);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnLog
            // 
            this.tsbtnLog.BackColor = System.Drawing.SystemColors.Control;
            this.tsbtnLog.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnLog.Image")));
            this.tsbtnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnLog.Name = "tsbtnLog";
            this.tsbtnLog.Size = new System.Drawing.Size(36, 44);
            this.tsbtnLog.Text = "Log";
            this.tsbtnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnLog.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtnSiteSetup
            // 
            this.tsbtnSiteSetup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbtnSiteSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSiteSetup.Image")));
            this.tsbtnSiteSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSiteSetup.Name = "tsbtnSiteSetup";
            this.tsbtnSiteSetup.Size = new System.Drawing.Size(80, 44);
            this.tsbtnSiteSetup.Text = "Site Setup";
            this.tsbtnSiteSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSiteSetup.ToolTipText = "Site Setup";
            this.tsbtnSiteSetup.Click += new System.EventHandler(this.tsbtnSiteSetup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 47);
            // 
            // tsbtnPathSetup
            // 
            this.tsbtnPathSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnPathSetup.Image")));
            this.tsbtnPathSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnPathSetup.Name = "tsbtnPathSetup";
            this.tsbtnPathSetup.Size = new System.Drawing.Size(84, 44);
            this.tsbtnPathSetup.Text = "Path Setup";
            this.tsbtnPathSetup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnPathSetup.Click += new System.EventHandler(this.tsbtnPathSetup_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 47);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(54, 44);
            this.toolStripButton2.Text = "About";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(246, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(483, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 43);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tbxTimeSystem
            // 
            this.tbxTimeSystem.BackColor = System.Drawing.SystemColors.Control;
            this.tbxTimeSystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTimeSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTimeSystem.Location = new System.Drawing.Point(735, 134);
            this.tbxTimeSystem.Name = "tbxTimeSystem";
            this.tbxTimeSystem.Size = new System.Drawing.Size(236, 20);
            this.tbxTimeSystem.TabIndex = 3;
            this.tbxTimeSystem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2200;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // backgroundWorkerSiteSetup
            // 
            this.backgroundWorkerSiteSetup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSiteSetup_DoWork);
            // 
            // serverSetup
            // 
            this.serverSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverSetup.Location = new System.Drawing.Point(3, 3);
            this.serverSetup.Name = "serverSetup";
            this.serverSetup.Size = new System.Drawing.Size(1073, 635);
            this.serverSetup.TabIndex = 0;
            // 
            // connectDatabse
            // 
            this.connectDatabse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectDatabse.Location = new System.Drawing.Point(3, 3);
            this.connectDatabse.Name = "connectDatabse";
            this.connectDatabse.Size = new System.Drawing.Size(1073, 635);
            this.connectDatabse.TabIndex = 0;
            // 
            // remoteControl
            // 
            this.remoteControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.remoteControl.Location = new System.Drawing.Point(3, 3);
            this.remoteControl.Name = "remoteControl";
            this.remoteControl.Size = new System.Drawing.Size(1059, 556);
            this.remoteControl.TabIndex = 0;
            // 
            // serverSendingCommand
            // 
            this.serverSendingCommand.AutoSize = true;
            this.serverSendingCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverSendingCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverSendingCommand.Location = new System.Drawing.Point(3, 3);
            this.serverSendingCommand.Name = "serverSendingCommand";
            this.serverSendingCommand.Size = new System.Drawing.Size(1059, 600);
            this.serverSendingCommand.TabIndex = 0;
            // 
            // monitoring
            // 
            this.monitoring.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("monitoring.BackgroundImage")));
            this.monitoring.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.monitoring.Location = new System.Drawing.Point(3, -9);
            this.monitoring.Name = "monitoring";
            this.monitoring.Size = new System.Drawing.Size(1073, 647);
            this.monitoring.TabIndex = 0;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1087, 853);
            this.Controls.Add(this.tbxTimeSystem);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "ServerForm";
            this.Text = "Server Monitoring";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Server.ServerSetup serverSetup;
        private Server.SendingCommand serverSendingCommand;
        private Server.RemoteControl remoteControl;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnLog;
        private System.Windows.Forms.TabPage tabPage3;
        private Server.ConnectDatabase connectDatabse;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox tbxTimeSystem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStripButton tsbtnSiteSetup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSiteSetup;
        private Server.Monitoring monitoring;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnPathSetup;
    }
}

