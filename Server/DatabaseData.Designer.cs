namespace Server
{
    partial class DatabaseData
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
            this.dgDisplay = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LEQ5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // dgDisplay
            // 
            this.dgDisplay.AllowUserToAddRows = false;
            this.dgDisplay.AllowUserToDeleteRows = false;
            this.dgDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDisplay.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.LEQ5,
            this.MAX,
            this.MIN});
            this.dgDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDisplay.Location = new System.Drawing.Point(0, 0);
            this.dgDisplay.Name = "dgDisplay";
            this.dgDisplay.ReadOnly = true;
            this.dgDisplay.RowHeadersWidth = 50;
            this.dgDisplay.RowTemplate.Height = 24;
            this.dgDisplay.Size = new System.Drawing.Size(532, 526);
            this.dgDisplay.TabIndex = 0;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            this.Time.Width = 120;
            // 
            // LEQ5
            // 
            this.LEQ5.HeaderText = "LEQ5";
            this.LEQ5.Name = "LEQ5";
            this.LEQ5.ReadOnly = true;
            this.LEQ5.Width = 120;
            // 
            // MAX
            // 
            this.MAX.HeaderText = "MAX";
            this.MAX.Name = "MAX";
            this.MAX.ReadOnly = true;
            this.MAX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.MAX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MAX.Width = 120;
            // 
            // MIN
            // 
            this.MIN.HeaderText = "MIN";
            this.MIN.Name = "MIN";
            this.MIN.ReadOnly = true;
            this.MIN.Width = 120;
            // 
            // DatabaseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 526);
            this.Controls.Add(this.dgDisplay);
            this.Name = "DatabaseData";
            this.Text = "DatabaseData";
            ((System.ComponentModel.ISupportInitialize)(this.dgDisplay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgDisplay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn LEQ5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn MIN;
    }
}