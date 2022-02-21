namespace OpenProtocolInterpreter.Emulator.AutomaticControllers
{
    partial class ConfigurationForm
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
            this.ConfigurationGrid = new System.Windows.Forms.DataGridView();
            this.ControllerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TighteningStrategy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.JobStrategy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MinTighteningDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTighteningDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ViewLogs = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnStartStopServer = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericTotalControllers = new System.Windows.Forms.NumericUpDown();
            this.btnAutoCreateControllers = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTotalControllers)).BeginInit();
            this.SuspendLayout();
            // 
            // ConfigurationGrid
            // 
            this.ConfigurationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConfigurationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControllerName,
            this.Port,
            this.TighteningStrategy,
            this.JobStrategy,
            this.MinTighteningDelay,
            this.MaxTighteningDelay,
            this.Enabled,
            this.ViewLogs});
            this.ConfigurationGrid.Location = new System.Drawing.Point(12, 54);
            this.ConfigurationGrid.Name = "ConfigurationGrid";
            this.ConfigurationGrid.RowTemplate.Height = 25;
            this.ConfigurationGrid.Size = new System.Drawing.Size(843, 531);
            this.ConfigurationGrid.TabIndex = 1;
            // 
            // ControllerName
            // 
            this.ControllerName.Frozen = true;
            this.ControllerName.HeaderText = "Controller Name";
            this.ControllerName.Name = "ControllerName";
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            // 
            // TighteningStrategy
            // 
            this.TighteningStrategy.HeaderText = "Tightening Strategy";
            this.TighteningStrategy.Items.AddRange(new object[] {
            "Random",
            "OnlyOk",
            "OnlyNok"});
            this.TighteningStrategy.Name = "TighteningStrategy";
            // 
            // JobStrategy
            // 
            this.JobStrategy.HeaderText = "Job Strategy";
            this.JobStrategy.Items.AddRange(new object[] {
            "Random",
            "OnlyOk",
            "OnlyNok"});
            this.JobStrategy.Name = "JobStrategy";
            // 
            // MinTighteningDelay
            // 
            this.MinTighteningDelay.HeaderText = "Min Tightening Delay (ms)";
            this.MinTighteningDelay.Name = "MinTighteningDelay";
            // 
            // MaxTighteningDelay
            // 
            this.MaxTighteningDelay.HeaderText = "Max Tightening Delay (ms)";
            this.MaxTighteningDelay.Name = "MaxTighteningDelay";
            // 
            // Enabled
            // 
            this.Enabled.HeaderText = "Ënabled";
            this.Enabled.Name = "Enabled";
            // 
            // ViewLogs
            // 
            this.ViewLogs.HeaderText = "Logs";
            this.ViewLogs.Name = "ViewLogs";
            this.ViewLogs.Text = "View Logs";
            // 
            // btnStartStopServer
            // 
            this.btnStartStopServer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartStopServer.Location = new System.Drawing.Point(638, 603);
            this.btnStartStopServer.Name = "btnStartStopServer";
            this.btnStartStopServer.Size = new System.Drawing.Size(217, 86);
            this.btnStartStopServer.TabIndex = 2;
            this.btnStartStopServer.Text = "Start Server";
            this.btnStartStopServer.UseVisualStyleBackColor = true;
            this.btnStartStopServer.Click += new System.EventHandler(this.OnStartStopServer_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(12, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(217, 86);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total controllers:";
            // 
            // numericTotalControllers
            // 
            this.numericTotalControllers.Location = new System.Drawing.Point(12, 25);
            this.numericTotalControllers.Name = "numericTotalControllers";
            this.numericTotalControllers.Size = new System.Drawing.Size(120, 23);
            this.numericTotalControllers.TabIndex = 5;
            this.numericTotalControllers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericTotalControllers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAutoCreateControllers
            // 
            this.btnAutoCreateControllers.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAutoCreateControllers.Location = new System.Drawing.Point(138, 7);
            this.btnAutoCreateControllers.Name = "btnAutoCreateControllers";
            this.btnAutoCreateControllers.Size = new System.Drawing.Size(144, 41);
            this.btnAutoCreateControllers.TabIndex = 6;
            this.btnAutoCreateControllers.Text = "Auto create";
            this.btnAutoCreateControllers.UseVisualStyleBackColor = true;
            this.btnAutoCreateControllers.Click += new System.EventHandler(this.OnAutoCreateControllers_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 701);
            this.Controls.Add(this.btnAutoCreateControllers);
            this.Controls.Add(this.numericTotalControllers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnStartStopServer);
            this.Controls.Add(this.ConfigurationGrid);
            this.Name = "ConfigurationForm";
            this.Text = "ConfigurationForm";
            this.Load += new System.EventHandler(this.OnConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTotalControllers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView ConfigurationGrid;
        private Button btnStartStopServer;
        private DataGridViewTextBoxColumn ControllerName;
        private DataGridViewTextBoxColumn Port;
        private DataGridViewComboBoxColumn TighteningStrategy;
        private DataGridViewComboBoxColumn JobStrategy;
        private DataGridViewTextBoxColumn MinTighteningDelay;
        private DataGridViewTextBoxColumn MaxTighteningDelay;
        private DataGridViewCheckBoxColumn Enabled;
        private DataGridViewButtonColumn ViewLogs;
        private Button btnSave;
        private Label label1;
        private NumericUpDown numericTotalControllers;
        private Button btnAutoCreateControllers;
    }
}