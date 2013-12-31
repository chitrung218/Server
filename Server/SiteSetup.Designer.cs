namespace Server
{
    partial class SiteSetup
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sITENMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sITECODEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iPADDRESSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cONNECTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONNECTING_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clieninfoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.siteinfoDataSet1 = new Server.siteinfoDataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSiteNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSiteCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxIpAddress = new System.Windows.Forms.TextBox();
            this.clieninfoTableAdapter1 = new Server.siteinfoDataSet1TableAdapters.clieninfoTableAdapter();
            this.timerCheckClientStatus = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogDatabaseFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clieninfoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteinfoDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.recordToolStripMenuItem,
            this.maintenanceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(773, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShowShortcutKeys = false;
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.printToolStripMenuItem.Text = "Exit";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.recordToolStripMenuItem.Text = "Record";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.addToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(171, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cODEDataGridViewTextBoxColumn,
            this.sITENMDataGridViewTextBoxColumn,
            this.sITECODEDataGridViewTextBoxColumn,
            this.iPADDRESSDataGridViewTextBoxColumn,
            this.cONNECTDataGridViewTextBoxColumn,
            this.CONNECTING_TIME});
            this.dataGridView1.DataSource = this.clieninfoBindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 294);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(773, 361);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cODEDataGridViewTextBoxColumn
            // 
            this.cODEDataGridViewTextBoxColumn.DataPropertyName = "CODE";
            this.cODEDataGridViewTextBoxColumn.HeaderText = "CODE";
            this.cODEDataGridViewTextBoxColumn.Name = "cODEDataGridViewTextBoxColumn";
            // 
            // sITENMDataGridViewTextBoxColumn
            // 
            this.sITENMDataGridViewTextBoxColumn.DataPropertyName = "SITE_NM";
            this.sITENMDataGridViewTextBoxColumn.HeaderText = "SITE_NM";
            this.sITENMDataGridViewTextBoxColumn.Name = "sITENMDataGridViewTextBoxColumn";
            // 
            // sITECODEDataGridViewTextBoxColumn
            // 
            this.sITECODEDataGridViewTextBoxColumn.DataPropertyName = "SITE_CODE";
            this.sITECODEDataGridViewTextBoxColumn.HeaderText = "SITE_CODE";
            this.sITECODEDataGridViewTextBoxColumn.Name = "sITECODEDataGridViewTextBoxColumn";
            // 
            // iPADDRESSDataGridViewTextBoxColumn
            // 
            this.iPADDRESSDataGridViewTextBoxColumn.DataPropertyName = "IP_ADDRESS";
            this.iPADDRESSDataGridViewTextBoxColumn.HeaderText = "IP_ADDRESS";
            this.iPADDRESSDataGridViewTextBoxColumn.Name = "iPADDRESSDataGridViewTextBoxColumn";
            this.iPADDRESSDataGridViewTextBoxColumn.Width = 150;
            // 
            // cONNECTDataGridViewTextBoxColumn
            // 
            this.cONNECTDataGridViewTextBoxColumn.DataPropertyName = "CONNECT";
            this.cONNECTDataGridViewTextBoxColumn.HeaderText = "CONNECT";
            this.cONNECTDataGridViewTextBoxColumn.Name = "cONNECTDataGridViewTextBoxColumn";
            // 
            // CONNECTING_TIME
            // 
            this.CONNECTING_TIME.DataPropertyName = "TIME";
            dataGridViewCellStyle1.Format = "yyyy/MM/dd HH:mm:ss";
            dataGridViewCellStyle1.NullValue = null;
            this.CONNECTING_TIME.DefaultCellStyle = dataGridViewCellStyle1;
            this.CONNECTING_TIME.HeaderText = "CONNECTING_TIME";
            this.CONNECTING_TIME.Name = "CONNECTING_TIME";
            this.CONNECTING_TIME.Width = 180;
            // 
            // clieninfoBindingSource1
            // 
            this.clieninfoBindingSource1.DataMember = "clieninfo";
            this.clieninfoBindingSource1.DataSource = this.siteinfoDataSet1;
            // 
            // siteinfoDataSet1
            // 
            this.siteinfoDataSet1.DataSetName = "siteinfoDataSet1";
            this.siteinfoDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "CODE:";
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(132, 68);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(113, 22);
            this.tbxCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(325, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "SITE_NM:";
            // 
            // tbxSiteNum
            // 
            this.tbxSiteNum.Location = new System.Drawing.Point(453, 68);
            this.tbxSiteNum.Name = "tbxSiteNum";
            this.tbxSiteNum.Size = new System.Drawing.Size(113, 22);
            this.tbxSiteNum.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "SITE_CODE:";
            // 
            // tbxSiteCode
            // 
            this.tbxSiteCode.Location = new System.Drawing.Point(132, 156);
            this.tbxSiteCode.Name = "tbxSiteCode";
            this.tbxSiteCode.Size = new System.Drawing.Size(113, 22);
            this.tbxSiteCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(325, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "IP_ADDRESS:";
            // 
            // tbxIpAddress
            // 
            this.tbxIpAddress.Location = new System.Drawing.Point(453, 153);
            this.tbxIpAddress.Name = "tbxIpAddress";
            this.tbxIpAddress.Size = new System.Drawing.Size(113, 22);
            this.tbxIpAddress.TabIndex = 9;
            // 
            // clieninfoTableAdapter1
            // 
            this.clieninfoTableAdapter1.ClearBeforeFill = true;
            // 
            // timerCheckClientStatus
            // 
            this.timerCheckClientStatus.Enabled = true;
            this.timerCheckClientStatus.Interval = 2000;
            this.timerCheckClientStatus.Tick += new System.EventHandler(this.timerCheckClientStatus_Tick);
            // 
            // openFileDialogDatabaseFile
            // 
            this.openFileDialogDatabaseFile.FileName = "openFileDialog1";
            // 
            // SiteSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 655);
            this.Controls.Add(this.tbxIpAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxSiteCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxSiteNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SiteSetup";
            this.Text = "SiteSetup";
            this.Load += new System.EventHandler(this.SiteSetup_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clieninfoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.siteinfoDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
       
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSiteNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSiteCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxIpAddress;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private siteinfoDataSet1 siteinfoDataSet1;
        private System.Windows.Forms.BindingSource clieninfoBindingSource1;
        private siteinfoDataSet1TableAdapters.clieninfoTableAdapter clieninfoTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sITENMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sITECODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iPADDRESSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cONNECTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONNECTING_TIME;
        private System.Windows.Forms.Timer timerCheckClientStatus;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogDatabaseFile;
    }
}