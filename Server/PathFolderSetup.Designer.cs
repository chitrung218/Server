namespace Server
{
    partial class PathFolderSetup
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
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDatabaseBackup = new System.Windows.Forms.FolderBrowserDialog();
            this.tbxDatabaseBackup = new System.Windows.Forms.TextBox();
            this.btnDatabaseBackupBrowser = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxData = new System.Windows.Forms.TextBox();
            this.folderBrowserData = new System.Windows.Forms.FolderBrowserDialog();
            this.btnDataBrowser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxLogViewer = new System.Windows.Forms.TextBox();
            this.btnLogViewerBrowser = new System.Windows.Forms.Button();
            this.folderBrowserLogViewer = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMysqlDump = new System.Windows.Forms.TextBox();
            this.btnMysqlDumpBrowser = new System.Windows.Forms.Button();
            this.folderBrowserMysqlDump = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxMysql = new System.Windows.Forms.TextBox();
            this.btnMysqlBrowser = new System.Windows.Forms.Button();
            this.folderBrowserMysql = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database Backup:";
            // 
            // tbxDatabaseBackup
            // 
            this.tbxDatabaseBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDatabaseBackup.Location = new System.Drawing.Point(233, 50);
            this.tbxDatabaseBackup.Name = "tbxDatabaseBackup";
            this.tbxDatabaseBackup.Size = new System.Drawing.Size(292, 24);
            this.tbxDatabaseBackup.TabIndex = 1;
            this.tbxDatabaseBackup.Text = "C:\\Database_Backup";
            // 
            // btnDatabaseBackupBrowser
            // 
            this.btnDatabaseBackupBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabaseBackupBrowser.Location = new System.Drawing.Point(641, 46);
            this.btnDatabaseBackupBrowser.Name = "btnDatabaseBackupBrowser";
            this.btnDatabaseBackupBrowser.Size = new System.Drawing.Size(105, 28);
            this.btnDatabaseBackupBrowser.TabIndex = 2;
            this.btnDatabaseBackupBrowser.Text = "Browser";
            this.btnDatabaseBackupBrowser.UseVisualStyleBackColor = true;
            this.btnDatabaseBackupBrowser.Click += new System.EventHandler(this.btnDatabaseBackupBrowser_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(264, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 38);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(513, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(105, 38);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data:";
            // 
            // tbxData
            // 
            this.tbxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxData.Location = new System.Drawing.Point(233, 110);
            this.tbxData.Name = "tbxData";
            this.tbxData.Size = new System.Drawing.Size(292, 24);
            this.tbxData.TabIndex = 6;
            this.tbxData.Text = "C:\\Harmony_Data";
            // 
            // btnDataBrowser
            // 
            this.btnDataBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataBrowser.Location = new System.Drawing.Point(641, 104);
            this.btnDataBrowser.Name = "btnDataBrowser";
            this.btnDataBrowser.Size = new System.Drawing.Size(105, 30);
            this.btnDataBrowser.TabIndex = 7;
            this.btnDataBrowser.Text = "Browser";
            this.btnDataBrowser.UseVisualStyleBackColor = true;
            this.btnDataBrowser.Click += new System.EventHandler(this.btnDataBrowser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log Viewer:";
            // 
            // tbxLogViewer
            // 
            this.tbxLogViewer.Location = new System.Drawing.Point(233, 164);
            this.tbxLogViewer.Name = "tbxLogViewer";
            this.tbxLogViewer.Size = new System.Drawing.Size(292, 24);
            this.tbxLogViewer.TabIndex = 9;
            this.tbxLogViewer.Text = "C:\\Program Files\\ReflectSoftware\\ReflectInsight\\Bin\\ReflectInsight.exe";
            // 
            // btnLogViewerBrowser
            // 
            this.btnLogViewerBrowser.Location = new System.Drawing.Point(641, 161);
            this.btnLogViewerBrowser.Name = "btnLogViewerBrowser";
            this.btnLogViewerBrowser.Size = new System.Drawing.Size(105, 30);
            this.btnLogViewerBrowser.TabIndex = 10;
            this.btnLogViewerBrowser.Text = "Browser";
            this.btnLogViewerBrowser.UseVisualStyleBackColor = true;
            this.btnLogViewerBrowser.Click += new System.EventHandler(this.btnLogViewerBrowser_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "MySql Dump:";
            // 
            // tbxMysqlDump
            // 
            this.tbxMysqlDump.Location = new System.Drawing.Point(233, 226);
            this.tbxMysqlDump.Name = "tbxMysqlDump";
            this.tbxMysqlDump.Size = new System.Drawing.Size(292, 24);
            this.tbxMysqlDump.TabIndex = 12;
            this.tbxMysqlDump.Text = "C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin\\mysqldump.exe";
            // 
            // btnMysqlDumpBrowser
            // 
            this.btnMysqlDumpBrowser.Location = new System.Drawing.Point(641, 220);
            this.btnMysqlDumpBrowser.Name = "btnMysqlDumpBrowser";
            this.btnMysqlDumpBrowser.Size = new System.Drawing.Size(105, 30);
            this.btnMysqlDumpBrowser.TabIndex = 13;
            this.btnMysqlDumpBrowser.Text = "Browser";
            this.btnMysqlDumpBrowser.UseVisualStyleBackColor = true;
            this.btnMysqlDumpBrowser.Click += new System.EventHandler(this.btnMysqlDumpBrowser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Mysql:";
            // 
            // tbxMysql
            // 
            this.tbxMysql.Location = new System.Drawing.Point(233, 289);
            this.tbxMysql.Name = "tbxMysql";
            this.tbxMysql.Size = new System.Drawing.Size(292, 24);
            this.tbxMysql.TabIndex = 15;
            this.tbxMysql.Text = "C:\\Program Files\\MySQL\\MySQL Server 5.6\\bin\\mysql.exe";
            // 
            // btnMysqlBrowser
            // 
            this.btnMysqlBrowser.Location = new System.Drawing.Point(641, 280);
            this.btnMysqlBrowser.Name = "btnMysqlBrowser";
            this.btnMysqlBrowser.Size = new System.Drawing.Size(105, 33);
            this.btnMysqlBrowser.TabIndex = 16;
            this.btnMysqlBrowser.Text = "Browser";
            this.btnMysqlBrowser.UseVisualStyleBackColor = true;
            this.btnMysqlBrowser.Click += new System.EventHandler(this.btnMysqlBrowser_Click);
            // 
            // PathFolderSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 510);
            this.Controls.Add(this.btnMysqlBrowser);
            this.Controls.Add(this.tbxMysql);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnMysqlDumpBrowser);
            this.Controls.Add(this.tbxMysqlDump);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLogViewerBrowser);
            this.Controls.Add(this.tbxLogViewer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDataBrowser);
            this.Controls.Add(this.tbxData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDatabaseBackupBrowser);
            this.Controls.Add(this.tbxDatabaseBackup);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "PathFolderSetup";
            this.Text = "PathFolderSetup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDatabaseBackup;
        private System.Windows.Forms.TextBox tbxDatabaseBackup;
        private System.Windows.Forms.Button btnDatabaseBackupBrowser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserData;
        private System.Windows.Forms.Button btnDataBrowser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxLogViewer;
        private System.Windows.Forms.Button btnLogViewerBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserLogViewer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxMysqlDump;
        private System.Windows.Forms.Button btnMysqlDumpBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserMysqlDump;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxMysql;
        private System.Windows.Forms.Button btnMysqlBrowser;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserMysql;
    }
}