namespace Server
{
    partial class SendingCommand
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxConnectedClients = new System.Windows.Forms.ListBox();
            this.btnSendingCommand = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.npuTimeSingleSecond = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.npuTimeSingleMinute = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.npuTimeSingleHour = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateSingle = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxFileTypeS = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.npuToTimeSecond = new System.Windows.Forms.NumericUpDown();
            this.npuFromTimeSecond = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.lbxFileTypeP = new System.Windows.Forms.ListBox();
            this.npuToTimeMinute = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.npuFromTimeMinute = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.npuToTimeHour = new System.Windows.Forms.NumericUpDown();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.npuFromTimeHour = new System.Windows.Forms.NumericUpDown();
            this.cbbSelectionType = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxClientCode = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleHour)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeHour)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbxConnectedClients);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(564, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connected Clients";
            // 
            // lbxConnectedClients
            // 
            this.lbxConnectedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxConnectedClients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbxConnectedClients.FormattingEnabled = true;
            this.lbxConnectedClients.ItemHeight = 20;
            this.lbxConnectedClients.Location = new System.Drawing.Point(3, 29);
            this.lbxConnectedClients.Name = "lbxConnectedClients";
            this.lbxConnectedClients.Size = new System.Drawing.Size(278, 160);
            this.lbxConnectedClients.TabIndex = 1;
            // 
            // btnSendingCommand
            // 
            this.btnSendingCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendingCommand.Location = new System.Drawing.Point(657, 443);
            this.btnSendingCommand.Name = "btnSendingCommand";
            this.btnSendingCommand.Size = new System.Drawing.Size(160, 54);
            this.btnSendingCommand.TabIndex = 1;
            this.btnSendingCommand.Text = "Sending Command";
            this.btnSendingCommand.UseVisualStyleBackColor = true;
            this.btnSendingCommand.Click += new System.EventHandler(this.btnSendingCommand_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.npuTimeSingleSecond);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.npuTimeSingleMinute);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.npuTimeSingleHour);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpDateSingle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lbxFileTypeS);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(14, 371);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(434, 199);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Single File";
            // 
            // npuTimeSingleSecond
            // 
            this.npuTimeSingleSecond.Location = new System.Drawing.Point(343, 146);
            this.npuTimeSingleSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.npuTimeSingleSecond.Name = "npuTimeSingleSecond";
            this.npuTimeSingleSecond.Size = new System.Drawing.Size(66, 27);
            this.npuTimeSingleSecond.TabIndex = 13;
            this.npuTimeSingleSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Second";
            // 
            // npuTimeSingleMinute
            // 
            this.npuTimeSingleMinute.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.npuTimeSingleMinute.Location = new System.Drawing.Point(227, 146);
            this.npuTimeSingleMinute.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.npuTimeSingleMinute.Name = "npuTimeSingleMinute";
            this.npuTimeSingleMinute.Size = new System.Drawing.Size(66, 27);
            this.npuTimeSingleMinute.TabIndex = 11;
            this.npuTimeSingleMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Minute";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hour";
            // 
            // npuTimeSingleHour
            // 
            this.npuTimeSingleHour.Location = new System.Drawing.Point(112, 145);
            this.npuTimeSingleHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.npuTimeSingleHour.Name = "npuTimeSingleHour";
            this.npuTimeSingleHour.Size = new System.Drawing.Size(65, 27);
            this.npuTimeSingleHour.TabIndex = 8;
            this.npuTimeSingleHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npuTimeSingleHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Time:";
            // 
            // dtpDateSingle
            // 
            this.dtpDateSingle.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSingle.Location = new System.Drawing.Point(112, 84);
            this.dtpDateSingle.Name = "dtpDateSingle";
            this.dtpDateSingle.Size = new System.Drawing.Size(106, 27);
            this.dtpDateSingle.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Date:";
            // 
            // lbxFileTypeS
            // 
            this.lbxFileTypeS.FormattingEnabled = true;
            this.lbxFileTypeS.ItemHeight = 20;
            this.lbxFileTypeS.Items.AddRange(new object[] {
            "DMPF",
            "DMPW",
            "DMPO",
            "DMP3",
            "DMPL",
            "RCHK",
            "SETT",
            "SETM"});
            this.lbxFileTypeS.Location = new System.Drawing.Point(112, 40);
            this.lbxFileTypeS.Name = "lbxFileTypeS";
            this.lbxFileTypeS.ScrollAlwaysVisible = true;
            this.lbxFileTypeS.Size = new System.Drawing.Size(100, 24);
            this.lbxFileTypeS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Type: ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.npuToTimeSecond);
            this.groupBox3.Controls.Add(this.npuFromTimeSecond);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lbxFileTypeP);
            this.groupBox3.Controls.Add(this.npuToTimeMinute);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dtpToDate);
            this.groupBox3.Controls.Add(this.npuFromTimeMinute);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.npuToTimeHour);
            this.groupBox3.Controls.Add(this.dtpFromDate);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.npuFromTimeHour);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(14, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(434, 349);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time Period";
            // 
            // npuToTimeSecond
            // 
            this.npuToTimeSecond.Location = new System.Drawing.Point(344, 273);
            this.npuToTimeSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.npuToTimeSecond.Name = "npuToTimeSecond";
            this.npuToTimeSecond.Size = new System.Drawing.Size(66, 27);
            this.npuToTimeSecond.TabIndex = 31;
            this.npuToTimeSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // npuFromTimeSecond
            // 
            this.npuFromTimeSecond.Location = new System.Drawing.Point(343, 146);
            this.npuFromTimeSecond.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.npuFromTimeSecond.Name = "npuFromTimeSecond";
            this.npuFromTimeSecond.Size = new System.Drawing.Size(66, 27);
            this.npuFromTimeSecond.TabIndex = 22;
            this.npuFromTimeSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(344, 250);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "Second";
            // 
            // lbxFileTypeP
            // 
            this.lbxFileTypeP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxFileTypeP.FormattingEnabled = true;
            this.lbxFileTypeP.ItemHeight = 20;
            this.lbxFileTypeP.Items.AddRange(new object[] {
            "DMPF",
            "DMPW",
            "DMPO",
            "DMP3"});
            this.lbxFileTypeP.Location = new System.Drawing.Point(118, 40);
            this.lbxFileTypeP.Name = "lbxFileTypeP";
            this.lbxFileTypeP.Size = new System.Drawing.Size(100, 24);
            this.lbxFileTypeP.TabIndex = 1;
            // 
            // npuToTimeMinute
            // 
            this.npuToTimeMinute.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.npuToTimeMinute.Location = new System.Drawing.Point(228, 273);
            this.npuToTimeMinute.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.npuToTimeMinute.Name = "npuToTimeMinute";
            this.npuToTimeMinute.Size = new System.Drawing.Size(66, 27);
            this.npuToTimeMinute.TabIndex = 29;
            this.npuToTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Second";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 207);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 23;
            this.label14.Text = "ToDate:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(231, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "Minute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "File Type:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(113, 207);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(105, 27);
            this.dtpToDate.TabIndex = 24;
            // 
            // npuFromTimeMinute
            // 
            this.npuFromTimeMinute.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.npuFromTimeMinute.Location = new System.Drawing.Point(227, 146);
            this.npuFromTimeMinute.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.npuFromTimeMinute.Name = "npuFromTimeMinute";
            this.npuFromTimeMinute.Size = new System.Drawing.Size(66, 27);
            this.npuFromTimeMinute.TabIndex = 20;
            this.npuFromTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(123, 250);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 20);
            this.label16.TabIndex = 27;
            this.label16.Text = "Hour";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 14;
            this.label12.Text = "FromDate:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 272);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 20);
            this.label17.TabIndex = 25;
            this.label17.Text = "ToTime:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Minute";
            // 
            // npuToTimeHour
            // 
            this.npuToTimeHour.Location = new System.Drawing.Point(114, 272);
            this.npuToTimeHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.npuToTimeHour.Name = "npuToTimeHour";
            this.npuToTimeHour.Size = new System.Drawing.Size(65, 27);
            this.npuToTimeHour.TabIndex = 26;
            this.npuToTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npuToTimeHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(112, 84);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(106, 27);
            this.dtpFromDate.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Hour";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(90, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "FromTime:";
            // 
            // npuFromTimeHour
            // 
            this.npuFromTimeHour.Location = new System.Drawing.Point(113, 145);
            this.npuFromTimeHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.npuFromTimeHour.Name = "npuFromTimeHour";
            this.npuFromTimeHour.Size = new System.Drawing.Size(65, 27);
            this.npuFromTimeHour.TabIndex = 17;
            this.npuFromTimeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.npuFromTimeHour.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbbSelectionType
            // 
            this.cbbSelectionType.FormattingEnabled = true;
            this.cbbSelectionType.Items.AddRange(new object[] {
            "Single File",
            "Time Period"});
            this.cbbSelectionType.Location = new System.Drawing.Point(720, 312);
            this.cbbSelectionType.Name = "cbbSelectionType";
            this.cbbSelectionType.Size = new System.Drawing.Size(121, 24);
            this.cbbSelectionType.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(560, 243);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 5;
            this.label18.Text = "Client Code:";
            this.label18.Visible = false;
            // 
            // tbxClientCode
            // 
            this.tbxClientCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxClientCode.Location = new System.Drawing.Point(720, 236);
            this.tbxClientCode.Name = "tbxClientCode";
            this.tbxClientCode.Size = new System.Drawing.Size(121, 27);
            this.tbxClientCode.TabIndex = 6;
            this.tbxClientCode.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(560, 312);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(130, 20);
            this.label19.TabIndex = 7;
            this.label19.Text = "Command Type:";
            // 
            // SendingCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbbSelectionType);
            this.Controls.Add(this.tbxClientCode);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSendingCommand);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SendingCommand";
            this.Size = new System.Drawing.Size(1013, 574);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuTimeSingleHour)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuToTimeHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.npuFromTimeHour)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxConnectedClients;
        private System.Windows.Forms.Button btnSendingCommand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxFileTypeS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateSingle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown npuTimeSingleHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown npuTimeSingleSecond;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown npuTimeSingleMinute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbxFileTypeP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown npuToTimeSecond;
        private System.Windows.Forms.NumericUpDown npuFromTimeSecond;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown npuToTimeMinute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.NumericUpDown npuFromTimeMinute;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown npuToTimeHour;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown npuFromTimeHour;
        private System.Windows.Forms.ComboBox cbbSelectionType;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxClientCode;
        private System.Windows.Forms.Label label19;
    }
}
