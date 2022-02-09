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
            this.btnStartStopServer = new System.Windows.Forms.Button();
            this.ControllerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TighteningStrategy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.JobStrategy = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MinTighteningDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxTighteningDelay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ViewLogs = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationGrid)).BeginInit();
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
            this.ConfigurationGrid.Location = new System.Drawing.Point(12, 12);
            this.ConfigurationGrid.Name = "ConfigurationGrid";
            this.ConfigurationGrid.RowTemplate.Height = 25;
            this.ConfigurationGrid.Size = new System.Drawing.Size(843, 188);
            this.ConfigurationGrid.TabIndex = 1;
            // 
            // btnStartStopServer
            // 
            this.btnStartStopServer.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartStopServer.Location = new System.Drawing.Point(638, 208);
            this.btnStartStopServer.Name = "btnStartStopServer";
            this.btnStartStopServer.Size = new System.Drawing.Size(217, 86);
            this.btnStartStopServer.TabIndex = 2;
            this.btnStartStopServer.Text = "Start Server";
            this.btnStartStopServer.UseVisualStyleBackColor = true;
            this.btnStartStopServer.Click += new System.EventHandler(this.OnStartStopServer_Click);
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
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 306);
            this.Controls.Add(this.btnStartStopServer);
            this.Controls.Add(this.ConfigurationGrid);
            this.Name = "ConfigurationForm";
            this.Text = "ConfigurationForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.OnConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ConfigurationGrid)).EndInit();
            this.ResumeLayout(false);

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
    }
}