namespace Server
{
    partial class DatabaseRestore
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
            this.tbxDatabaseFile = new System.Windows.Forms.TextBox();
            this.btnDatabaseFileBrowser = new System.Windows.Forms.Button();
            this.openFileDatabase = new System.Windows.Forms.OpenFileDialog();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database File:";
            // 
            // tbxDatabaseFile
            // 
            this.tbxDatabaseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDatabaseFile.Location = new System.Drawing.Point(146, 46);
            this.tbxDatabaseFile.Name = "tbxDatabaseFile";
            this.tbxDatabaseFile.Size = new System.Drawing.Size(257, 24);
            this.tbxDatabaseFile.TabIndex = 1;
            // 
            // btnDatabaseFileBrowser
            // 
            this.btnDatabaseFileBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatabaseFileBrowser.Location = new System.Drawing.Point(481, 46);
            this.btnDatabaseFileBrowser.Name = "btnDatabaseFileBrowser";
            this.btnDatabaseFileBrowser.Size = new System.Drawing.Size(92, 28);
            this.btnDatabaseFileBrowser.TabIndex = 2;
            this.btnDatabaseFileBrowser.Text = "Browser";
            this.btnDatabaseFileBrowser.UseVisualStyleBackColor = true;
            this.btnDatabaseFileBrowser.Click += new System.EventHandler(this.btnDatabaseFileBrowser_Click);
            // 
            // openFileDatabase
            // 
            this.openFileDatabase.FileName = "openFileDialog1";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(341, 153);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 34);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(172, 153);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(88, 34);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DatabaseRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 267);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDatabaseFileBrowser);
            this.Controls.Add(this.tbxDatabaseFile);
            this.Controls.Add(this.label1);
            this.Name = "DatabaseRestore";
            this.Text = "DatabaseRestore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDatabaseFile;
        private System.Windows.Forms.Button btnDatabaseFileBrowser;
        private System.Windows.Forms.OpenFileDialog openFileDatabase;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}