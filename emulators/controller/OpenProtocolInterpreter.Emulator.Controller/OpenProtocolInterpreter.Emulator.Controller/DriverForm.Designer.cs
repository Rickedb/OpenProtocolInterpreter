namespace OpenProtocolInterpreter.Emulator.Controller
{
    partial class DriverForm
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
            this.StartStopServerButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TighteningTab = new System.Windows.Forms.TabPage();
            this.SendTighteningButton = new System.Windows.Forms.Button();
            this.TighteningIdTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.BatchStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.LastChangeInParameterDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.AngleTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.AngleMaxTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.FinalAngleTargetTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.AngleMinTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TorqueTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TorqueMaxLimitTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TorqueFinalTargetTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TorqueMinLimitTextBox = new System.Windows.Forms.TextBox();
            this.TighteningStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TorqueStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.AngleStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BatchCounterTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BatchSizeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ParameterSetIdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.JobIdTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.VinNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TorqueControllerNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChannelIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CellIdTextBox = new System.Windows.Forms.TextBox();
            this.JobTab = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.JobBatchCounterTextBox = new System.Windows.Forms.TextBox();
            this.JobBatchModeComboBox = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.JobStatusComboBox = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.JobBatchSizeTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.Job_JobIdTextBox = new System.Windows.Forms.TextBox();
            this.AlarmTab = new System.Windows.Forms.TabPage();
            this.VinMessagesTab = new System.Windows.Forms.TabPage();
            this.label23 = new System.Windows.Forms.Label();
            this.IdentifierPart1TextBox = new System.Windows.Forms.TextBox();
            this.SendVinNumberButton = new System.Windows.Forms.Button();
            this.SendJobInfoButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TighteningTab.SuspendLayout();
            this.JobTab.SuspendLayout();
            this.VinMessagesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartStopServerButton
            // 
            this.StartStopServerButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StartStopServerButton.Location = new System.Drawing.Point(744, 417);
            this.StartStopServerButton.Name = "StartStopServerButton";
            this.StartStopServerButton.Size = new System.Drawing.Size(149, 67);
            this.StartStopServerButton.TabIndex = 0;
            this.StartStopServerButton.Text = "Start Server";
            this.StartStopServerButton.UseVisualStyleBackColor = true;
            this.StartStopServerButton.Click += new System.EventHandler(this.StartStopServerButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TighteningTab);
            this.tabControl1.Controls.Add(this.JobTab);
            this.tabControl1.Controls.Add(this.AlarmTab);
            this.tabControl1.Controls.Add(this.VinMessagesTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 388);
            this.tabControl1.TabIndex = 2;
            // 
            // TighteningTab
            // 
            this.TighteningTab.Controls.Add(this.SendTighteningButton);
            this.TighteningTab.Controls.Add(this.TighteningIdTextBox);
            this.TighteningTab.Controls.Add(this.button1);
            this.TighteningTab.Controls.Add(this.label22);
            this.TighteningTab.Controls.Add(this.BatchStatusComboBox);
            this.TighteningTab.Controls.Add(this.label21);
            this.TighteningTab.Controls.Add(this.LastChangeInParameterDateTimePicker);
            this.TighteningTab.Controls.Add(this.label20);
            this.TighteningTab.Controls.Add(this.label16);
            this.TighteningTab.Controls.Add(this.AngleTextBox);
            this.TighteningTab.Controls.Add(this.label17);
            this.TighteningTab.Controls.Add(this.AngleMaxTextBox);
            this.TighteningTab.Controls.Add(this.label18);
            this.TighteningTab.Controls.Add(this.FinalAngleTargetTextBox);
            this.TighteningTab.Controls.Add(this.label19);
            this.TighteningTab.Controls.Add(this.AngleMinTextBox);
            this.TighteningTab.Controls.Add(this.label15);
            this.TighteningTab.Controls.Add(this.TorqueTextBox);
            this.TighteningTab.Controls.Add(this.label14);
            this.TighteningTab.Controls.Add(this.TorqueMaxLimitTextBox);
            this.TighteningTab.Controls.Add(this.label13);
            this.TighteningTab.Controls.Add(this.TorqueFinalTargetTextBox);
            this.TighteningTab.Controls.Add(this.label12);
            this.TighteningTab.Controls.Add(this.TorqueMinLimitTextBox);
            this.TighteningTab.Controls.Add(this.TighteningStatusComboBox);
            this.TighteningTab.Controls.Add(this.label11);
            this.TighteningTab.Controls.Add(this.TorqueStatusComboBox);
            this.TighteningTab.Controls.Add(this.label10);
            this.TighteningTab.Controls.Add(this.AngleStatusComboBox);
            this.TighteningTab.Controls.Add(this.label9);
            this.TighteningTab.Controls.Add(this.label5);
            this.TighteningTab.Controls.Add(this.BatchCounterTextBox);
            this.TighteningTab.Controls.Add(this.label6);
            this.TighteningTab.Controls.Add(this.BatchSizeTextBox);
            this.TighteningTab.Controls.Add(this.label7);
            this.TighteningTab.Controls.Add(this.ParameterSetIdTextBox);
            this.TighteningTab.Controls.Add(this.label8);
            this.TighteningTab.Controls.Add(this.JobIdTextBox);
            this.TighteningTab.Controls.Add(this.label4);
            this.TighteningTab.Controls.Add(this.VinNumberTextBox);
            this.TighteningTab.Controls.Add(this.label3);
            this.TighteningTab.Controls.Add(this.TorqueControllerNameTextBox);
            this.TighteningTab.Controls.Add(this.label2);
            this.TighteningTab.Controls.Add(this.ChannelIdTextBox);
            this.TighteningTab.Controls.Add(this.label1);
            this.TighteningTab.Controls.Add(this.CellIdTextBox);
            this.TighteningTab.Location = new System.Drawing.Point(4, 24);
            this.TighteningTab.Name = "TighteningTab";
            this.TighteningTab.Padding = new System.Windows.Forms.Padding(3);
            this.TighteningTab.Size = new System.Drawing.Size(877, 360);
            this.TighteningTab.TabIndex = 0;
            this.TighteningTab.Text = "Tightening";
            this.TighteningTab.UseVisualStyleBackColor = true;
            // 
            // SendTighteningButton
            // 
            this.SendTighteningButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendTighteningButton.Location = new System.Drawing.Point(666, 308);
            this.SendTighteningButton.Name = "SendTighteningButton";
            this.SendTighteningButton.Size = new System.Drawing.Size(205, 43);
            this.SendTighteningButton.TabIndex = 45;
            this.SendTighteningButton.Text = "Send tightening";
            this.SendTighteningButton.UseVisualStyleBackColor = true;
            this.SendTighteningButton.Click += new System.EventHandler(this.SendTighteningButton_Click);
            // 
            // TighteningIdTextBox
            // 
            this.TighteningIdTextBox.Location = new System.Drawing.Point(631, 88);
            this.TighteningIdTextBox.Name = "TighteningIdTextBox";
            this.TighteningIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.TighteningIdTextBox.TabIndex = 44;
            this.TighteningIdTextBox.Text = "1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(167, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(289, 75);
            this.button1.TabIndex = 3;
            this.button1.Text = "Random Tightening";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(631, 71);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 15);
            this.label22.TabIndex = 43;
            this.label22.Text = "Tightening Id:";
            // 
            // BatchStatusComboBox
            // 
            this.BatchStatusComboBox.FormattingEnabled = true;
            this.BatchStatusComboBox.Items.AddRange(new object[] {
            "Nok",
            "Ok",
            "NotUsed",
            "Running"});
            this.BatchStatusComboBox.Location = new System.Drawing.Point(476, 135);
            this.BatchStatusComboBox.Name = "BatchStatusComboBox";
            this.BatchStatusComboBox.Size = new System.Drawing.Size(137, 23);
            this.BatchStatusComboBox.TabIndex = 42;
            this.BatchStatusComboBox.Text = "Ok";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(476, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 15);
            this.label21.TabIndex = 41;
            this.label21.Text = "Batch Status:";
            // 
            // LastChangeInParameterDateTimePicker
            // 
            this.LastChangeInParameterDateTimePicker.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.LastChangeInParameterDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.LastChangeInParameterDateTimePicker.Location = new System.Drawing.Point(8, 328);
            this.LastChangeInParameterDateTimePicker.Name = "LastChangeInParameterDateTimePicker";
            this.LastChangeInParameterDateTimePicker.Size = new System.Drawing.Size(153, 23);
            this.LastChangeInParameterDateTimePicker.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 310);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 15);
            this.label20.TabIndex = 39;
            this.label20.Text = "Last Change:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 15);
            this.label16.TabIndex = 37;
            this.label16.Text = "Angle:";
            // 
            // AngleTextBox
            // 
            this.AngleTextBox.Location = new System.Drawing.Point(167, 229);
            this.AngleTextBox.Name = "AngleTextBox";
            this.AngleTextBox.Size = new System.Drawing.Size(137, 23);
            this.AngleTextBox.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(167, 117);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 15);
            this.label17.TabIndex = 35;
            this.label17.Text = "Angle Max:";
            // 
            // AngleMaxTextBox
            // 
            this.AngleMaxTextBox.Location = new System.Drawing.Point(167, 135);
            this.AngleMaxTextBox.Name = "AngleMaxTextBox";
            this.AngleMaxTextBox.Size = new System.Drawing.Size(137, 23);
            this.AngleMaxTextBox.TabIndex = 34;
            this.AngleMaxTextBox.Text = "360";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(167, 164);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "Final Angle Target:";
            // 
            // FinalAngleTargetTextBox
            // 
            this.FinalAngleTargetTextBox.Location = new System.Drawing.Point(167, 182);
            this.FinalAngleTargetTextBox.Name = "FinalAngleTargetTextBox";
            this.FinalAngleTargetTextBox.Size = new System.Drawing.Size(137, 23);
            this.FinalAngleTargetTextBox.TabIndex = 32;
            this.FinalAngleTargetTextBox.Text = "180";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(167, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 15);
            this.label19.TabIndex = 31;
            this.label19.Text = "Angle Min:";
            // 
            // AngleMinTextBox
            // 
            this.AngleMinTextBox.Location = new System.Drawing.Point(167, 88);
            this.AngleMinTextBox.Name = "AngleMinTextBox";
            this.AngleMinTextBox.Size = new System.Drawing.Size(137, 23);
            this.AngleMinTextBox.TabIndex = 30;
            this.AngleMinTextBox.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(319, 211);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 15);
            this.label15.TabIndex = 29;
            this.label15.Text = "Torque:";
            // 
            // TorqueTextBox
            // 
            this.TorqueTextBox.Location = new System.Drawing.Point(319, 229);
            this.TorqueTextBox.Name = "TorqueTextBox";
            this.TorqueTextBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueTextBox.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(319, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 15);
            this.label14.TabIndex = 27;
            this.label14.Text = "Torque Max Limit:";
            // 
            // TorqueMaxLimitTextBox
            // 
            this.TorqueMaxLimitTextBox.Location = new System.Drawing.Point(319, 135);
            this.TorqueMaxLimitTextBox.Name = "TorqueMaxLimitTextBox";
            this.TorqueMaxLimitTextBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueMaxLimitTextBox.TabIndex = 26;
            this.TorqueMaxLimitTextBox.Text = "150";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(319, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "Torque Final Target:";
            // 
            // TorqueFinalTargetTextBox
            // 
            this.TorqueFinalTargetTextBox.Location = new System.Drawing.Point(319, 182);
            this.TorqueFinalTargetTextBox.Name = "TorqueFinalTargetTextBox";
            this.TorqueFinalTargetTextBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueFinalTargetTextBox.TabIndex = 24;
            this.TorqueFinalTargetTextBox.Text = "120";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(319, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 15);
            this.label12.TabIndex = 23;
            this.label12.Text = "Torque Min Limit:";
            // 
            // TorqueMinLimitTextBox
            // 
            this.TorqueMinLimitTextBox.Location = new System.Drawing.Point(319, 88);
            this.TorqueMinLimitTextBox.Name = "TorqueMinLimitTextBox";
            this.TorqueMinLimitTextBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueMinLimitTextBox.TabIndex = 22;
            this.TorqueMinLimitTextBox.Text = "80";
            // 
            // TighteningStatusComboBox
            // 
            this.TighteningStatusComboBox.FormattingEnabled = true;
            this.TighteningStatusComboBox.Items.AddRange(new object[] {
            "Nok",
            "Ok"});
            this.TighteningStatusComboBox.Location = new System.Drawing.Point(631, 39);
            this.TighteningStatusComboBox.Name = "TighteningStatusComboBox";
            this.TighteningStatusComboBox.Size = new System.Drawing.Size(137, 23);
            this.TighteningStatusComboBox.TabIndex = 21;
            this.TighteningStatusComboBox.Text = "Ok";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(631, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tightening Status:";
            // 
            // TorqueStatusComboBox
            // 
            this.TorqueStatusComboBox.FormattingEnabled = true;
            this.TorqueStatusComboBox.Items.AddRange(new object[] {
            "Low",
            "Ok",
            "High"});
            this.TorqueStatusComboBox.Location = new System.Drawing.Point(319, 39);
            this.TorqueStatusComboBox.Name = "TorqueStatusComboBox";
            this.TorqueStatusComboBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueStatusComboBox.TabIndex = 19;
            this.TorqueStatusComboBox.Text = "Ok";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(319, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "Torque Status:";
            // 
            // AngleStatusComboBox
            // 
            this.AngleStatusComboBox.FormattingEnabled = true;
            this.AngleStatusComboBox.Items.AddRange(new object[] {
            "Low",
            "Ok",
            "High"});
            this.AngleStatusComboBox.Location = new System.Drawing.Point(167, 39);
            this.AngleStatusComboBox.Name = "AngleStatusComboBox";
            this.AngleStatusComboBox.Size = new System.Drawing.Size(137, 23);
            this.AngleStatusComboBox.TabIndex = 17;
            this.AngleStatusComboBox.Text = "Ok";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Angle Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(476, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Batch Counter:";
            // 
            // BatchCounterTextBox
            // 
            this.BatchCounterTextBox.Location = new System.Drawing.Point(476, 87);
            this.BatchCounterTextBox.Name = "BatchCounterTextBox";
            this.BatchCounterTextBox.Size = new System.Drawing.Size(137, 23);
            this.BatchCounterTextBox.TabIndex = 14;
            this.BatchCounterTextBox.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Batch Size:";
            // 
            // BatchSizeTextBox
            // 
            this.BatchSizeTextBox.Location = new System.Drawing.Point(476, 39);
            this.BatchSizeTextBox.Name = "BatchSizeTextBox";
            this.BatchSizeTextBox.Size = new System.Drawing.Size(137, 23);
            this.BatchSizeTextBox.TabIndex = 12;
            this.BatchSizeTextBox.Text = "4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Parameter Set Id:";
            // 
            // ParameterSetIdTextBox
            // 
            this.ParameterSetIdTextBox.Location = new System.Drawing.Point(6, 276);
            this.ParameterSetIdTextBox.Name = "ParameterSetIdTextBox";
            this.ParameterSetIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.ParameterSetIdTextBox.TabIndex = 10;
            this.ParameterSetIdTextBox.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 211);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Job Id:";
            // 
            // JobIdTextBox
            // 
            this.JobIdTextBox.Location = new System.Drawing.Point(6, 229);
            this.JobIdTextBox.Name = "JobIdTextBox";
            this.JobIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.JobIdTextBox.TabIndex = 8;
            this.JobIdTextBox.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "VIN Number:";
            // 
            // VinNumberTextBox
            // 
            this.VinNumberTextBox.Location = new System.Drawing.Point(6, 182);
            this.VinNumberTextBox.Name = "VinNumberTextBox";
            this.VinNumberTextBox.Size = new System.Drawing.Size(137, 23);
            this.VinNumberTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Torque Controller Name:";
            // 
            // TorqueControllerNameTextBox
            // 
            this.TorqueControllerNameTextBox.Location = new System.Drawing.Point(6, 135);
            this.TorqueControllerNameTextBox.Name = "TorqueControllerNameTextBox";
            this.TorqueControllerNameTextBox.Size = new System.Drawing.Size(137, 23);
            this.TorqueControllerNameTextBox.TabIndex = 4;
            this.TorqueControllerNameTextBox.Text = "Emulator controller";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Channel Id:";
            // 
            // ChannelIdTextBox
            // 
            this.ChannelIdTextBox.Location = new System.Drawing.Point(6, 88);
            this.ChannelIdTextBox.Name = "ChannelIdTextBox";
            this.ChannelIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.ChannelIdTextBox.TabIndex = 2;
            this.ChannelIdTextBox.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cell Id:";
            // 
            // CellIdTextBox
            // 
            this.CellIdTextBox.Location = new System.Drawing.Point(6, 39);
            this.CellIdTextBox.Name = "CellIdTextBox";
            this.CellIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.CellIdTextBox.TabIndex = 0;
            this.CellIdTextBox.Text = "1";
            // 
            // JobTab
            // 
            this.JobTab.Controls.Add(this.SendJobInfoButton);
            this.JobTab.Controls.Add(this.label28);
            this.JobTab.Controls.Add(this.JobBatchCounterTextBox);
            this.JobTab.Controls.Add(this.JobBatchModeComboBox);
            this.JobTab.Controls.Add(this.label27);
            this.JobTab.Controls.Add(this.JobStatusComboBox);
            this.JobTab.Controls.Add(this.label26);
            this.JobTab.Controls.Add(this.label25);
            this.JobTab.Controls.Add(this.JobBatchSizeTextBox);
            this.JobTab.Controls.Add(this.label24);
            this.JobTab.Controls.Add(this.Job_JobIdTextBox);
            this.JobTab.Location = new System.Drawing.Point(4, 24);
            this.JobTab.Name = "JobTab";
            this.JobTab.Padding = new System.Windows.Forms.Padding(3);
            this.JobTab.Size = new System.Drawing.Size(877, 360);
            this.JobTab.TabIndex = 1;
            this.JobTab.Text = "Job";
            this.JobTab.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 216);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(107, 15);
            this.label28.TabIndex = 25;
            this.label28.Text = "Job Batch Counter:";
            // 
            // JobBatchCounterTextBox
            // 
            this.JobBatchCounterTextBox.Location = new System.Drawing.Point(6, 234);
            this.JobBatchCounterTextBox.Name = "JobBatchCounterTextBox";
            this.JobBatchCounterTextBox.Size = new System.Drawing.Size(137, 23);
            this.JobBatchCounterTextBox.TabIndex = 24;
            this.JobBatchCounterTextBox.Text = "1";
            // 
            // JobBatchModeComboBox
            // 
            this.JobBatchModeComboBox.FormattingEnabled = true;
            this.JobBatchModeComboBox.Items.AddRange(new object[] {
            "Low",
            "Ok",
            "High"});
            this.JobBatchModeComboBox.Location = new System.Drawing.Point(6, 131);
            this.JobBatchModeComboBox.Name = "JobBatchModeComboBox";
            this.JobBatchModeComboBox.Size = new System.Drawing.Size(137, 23);
            this.JobBatchModeComboBox.TabIndex = 23;
            this.JobBatchModeComboBox.Text = "Ok";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 114);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(95, 15);
            this.label27.TabIndex = 22;
            this.label27.Text = "Job Batch Mode:";
            // 
            // JobStatusComboBox
            // 
            this.JobStatusComboBox.FormattingEnabled = true;
            this.JobStatusComboBox.Items.AddRange(new object[] {
            "Low",
            "Ok",
            "High"});
            this.JobStatusComboBox.Location = new System.Drawing.Point(6, 81);
            this.JobStatusComboBox.Name = "JobStatusComboBox";
            this.JobStatusComboBox.Size = new System.Drawing.Size(137, 23);
            this.JobStatusComboBox.TabIndex = 21;
            this.JobStatusComboBox.Text = "Ok";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(6, 64);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 15);
            this.label26.TabIndex = 20;
            this.label26.Text = "Job Status:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 165);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 15);
            this.label25.TabIndex = 5;
            this.label25.Text = "Job Batch Size:";
            // 
            // JobBatchSizeTextBox
            // 
            this.JobBatchSizeTextBox.Location = new System.Drawing.Point(6, 183);
            this.JobBatchSizeTextBox.Name = "JobBatchSizeTextBox";
            this.JobBatchSizeTextBox.Size = new System.Drawing.Size(137, 23);
            this.JobBatchSizeTextBox.TabIndex = 4;
            this.JobBatchSizeTextBox.Text = "1";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 15);
            this.label24.TabIndex = 3;
            this.label24.Text = "Job Id:";
            // 
            // Job_JobIdTextBox
            // 
            this.Job_JobIdTextBox.Location = new System.Drawing.Point(6, 31);
            this.Job_JobIdTextBox.Name = "Job_JobIdTextBox";
            this.Job_JobIdTextBox.Size = new System.Drawing.Size(137, 23);
            this.Job_JobIdTextBox.TabIndex = 2;
            this.Job_JobIdTextBox.Text = "1";
            // 
            // AlarmTab
            // 
            this.AlarmTab.Location = new System.Drawing.Point(4, 24);
            this.AlarmTab.Name = "AlarmTab";
            this.AlarmTab.Size = new System.Drawing.Size(877, 360);
            this.AlarmTab.TabIndex = 2;
            this.AlarmTab.Text = "Alarm";
            this.AlarmTab.UseVisualStyleBackColor = true;
            // 
            // VinMessagesTab
            // 
            this.VinMessagesTab.Controls.Add(this.label23);
            this.VinMessagesTab.Controls.Add(this.IdentifierPart1TextBox);
            this.VinMessagesTab.Controls.Add(this.SendVinNumberButton);
            this.VinMessagesTab.Location = new System.Drawing.Point(4, 24);
            this.VinMessagesTab.Name = "VinMessagesTab";
            this.VinMessagesTab.Size = new System.Drawing.Size(877, 360);
            this.VinMessagesTab.TabIndex = 3;
            this.VinMessagesTab.Text = "VIN";
            this.VinMessagesTab.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 21);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(90, 15);
            this.label23.TabIndex = 48;
            this.label23.Text = "Identifier Part 1:";
            // 
            // IdentifierPart1TextBox
            // 
            this.IdentifierPart1TextBox.Location = new System.Drawing.Point(27, 39);
            this.IdentifierPart1TextBox.Name = "IdentifierPart1TextBox";
            this.IdentifierPart1TextBox.Size = new System.Drawing.Size(188, 23);
            this.IdentifierPart1TextBox.TabIndex = 47;
            // 
            // SendVinNumberButton
            // 
            this.SendVinNumberButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendVinNumberButton.Location = new System.Drawing.Point(660, 304);
            this.SendVinNumberButton.Name = "SendVinNumberButton";
            this.SendVinNumberButton.Size = new System.Drawing.Size(205, 43);
            this.SendVinNumberButton.TabIndex = 46;
            this.SendVinNumberButton.Text = "Send VIN Number";
            this.SendVinNumberButton.UseVisualStyleBackColor = true;
            this.SendVinNumberButton.Click += new System.EventHandler(this.SendVinNumberButton_Click);
            // 
            // SendJobInfoButton
            // 
            this.SendJobInfoButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SendJobInfoButton.Location = new System.Drawing.Point(666, 311);
            this.SendJobInfoButton.Name = "SendJobInfoButton";
            this.SendJobInfoButton.Size = new System.Drawing.Size(205, 43);
            this.SendJobInfoButton.TabIndex = 46;
            this.SendJobInfoButton.Text = "Send Job Info";
            this.SendJobInfoButton.UseVisualStyleBackColor = true;
            this.SendJobInfoButton.Click += new System.EventHandler(this.SendJobInfoButton_Click);
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 496);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.StartStopServerButton);
            this.Name = "DriverForm";
            this.Text = "DriverForm";
            this.tabControl1.ResumeLayout(false);
            this.TighteningTab.ResumeLayout(false);
            this.TighteningTab.PerformLayout();
            this.JobTab.ResumeLayout(false);
            this.JobTab.PerformLayout();
            this.VinMessagesTab.ResumeLayout(false);
            this.VinMessagesTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartStopServerButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage TighteningTab;
        private System.Windows.Forms.DateTimePicker LastChangeInParameterDateTimePicker;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox AngleTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox AngleMaxTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox FinalAngleTargetTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox AngleMinTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TorqueTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TorqueMaxLimitTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TorqueFinalTargetTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TorqueMinLimitTextBox;
        private System.Windows.Forms.ComboBox TighteningStatusComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox TorqueStatusComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox AngleStatusComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox BatchCounterTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BatchSizeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ParameterSetIdTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox JobIdTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox VinNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TorqueControllerNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ChannelIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CellIdTextBox;
        private System.Windows.Forms.TabPage JobTab;
        private System.Windows.Forms.TabPage AlarmTab;
        private System.Windows.Forms.TabPage VinMessagesTab;
        private System.Windows.Forms.Button SendTighteningButton;
        private System.Windows.Forms.TextBox TighteningIdTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox BatchStatusComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox IdentifierPart1TextBox;
        private System.Windows.Forms.Button SendVinNumberButton;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox JobBatchCounterTextBox;
        private System.Windows.Forms.ComboBox JobBatchModeComboBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox JobStatusComboBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox JobBatchSizeTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox Job_JobIdTextBox;
        private System.Windows.Forms.Button SendJobInfoButton;
    }
}