namespace OpenProtocolInterpreter.Sample
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolstripLast = new System.Windows.Forms.ToolStripStatusLabel();
            this.lastMessageArrived = new System.Windows.Forms.ToolStripStatusLabel();
            this.textIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTighteningSubscribe = new System.Windows.Forms.Button();
            this.btnJobInfoSubscribe = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.btnSendProduct = new System.Windows.Forms.Button();
            this.btnSendJob = new System.Windows.Forms.Button();
            this.numericJob = new System.Windows.Forms.NumericUpDown();
            this.btnAbortJob = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJob)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatus,
            this.toolstripLast,
            this.lastMessageArrived});
            this.statusStrip1.Location = new System.Drawing.Point(0, 268);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(653, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectionStatus
            // 
            this.connectionStatus.BackColor = System.Drawing.Color.Red;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(79, 17);
            this.connectionStatus.Text = "Disconnected";
            // 
            // toolstripLast
            // 
            this.toolstripLast.Name = "toolstripLast";
            this.toolstripLast.Size = new System.Drawing.Size(96, 17);
            this.toolstripLast.Text = "Last Mid Arrived:";
            // 
            // lastMessageArrived
            // 
            this.lastMessageArrived.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lastMessageArrived.Name = "lastMessageArrived";
            this.lastMessageArrived.Size = new System.Drawing.Size(463, 17);
            this.lastMessageArrived.Spring = true;
            this.lastMessageArrived.Text = "Last MID";
            // 
            // textIp
            // 
            this.textIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIp.Location = new System.Drawing.Point(36, 12);
            this.textIp.Name = "textIp";
            this.textIp.Size = new System.Drawing.Size(160, 22);
            this.textIp.TabIndex = 2;
            this.textIp.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP:";
            // 
            // btnConnection
            // 
            this.btnConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnection.Location = new System.Drawing.Point(385, 10);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(100, 23);
            this.btnConnection.TabIndex = 4;
            this.btnConnection.Text = "Connect";
            this.btnConnection.UseVisualStyleBackColor = true;
            this.btnConnection.Click += new System.EventHandler(this.BtnConnection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port:";
            // 
            // numericPort
            // 
            this.numericPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericPort.Location = new System.Drawing.Point(250, 13);
            this.numericPort.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(120, 22);
            this.numericPort.TabIndex = 7;
            this.numericPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericPort.Value = new decimal(new int[] {
            4545,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTighteningSubscribe);
            this.groupBox1.Controls.Add(this.btnJobInfoSubscribe);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subscribes";
            // 
            // btnTighteningSubscribe
            // 
            this.btnTighteningSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTighteningSubscribe.Location = new System.Drawing.Point(115, 21);
            this.btnTighteningSubscribe.Name = "btnTighteningSubscribe";
            this.btnTighteningSubscribe.Size = new System.Drawing.Size(103, 51);
            this.btnTighteningSubscribe.TabIndex = 11;
            this.btnTighteningSubscribe.Text = "Tightening Subscribe";
            this.btnTighteningSubscribe.UseVisualStyleBackColor = true;
            this.btnTighteningSubscribe.Click += new System.EventHandler(this.BtnTighteningSubscribe_Click);
            // 
            // btnJobInfoSubscribe
            // 
            this.btnJobInfoSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJobInfoSubscribe.Location = new System.Drawing.Point(6, 21);
            this.btnJobInfoSubscribe.Name = "btnJobInfoSubscribe";
            this.btnJobInfoSubscribe.Size = new System.Drawing.Size(103, 51);
            this.btnJobInfoSubscribe.TabIndex = 10;
            this.btnJobInfoSubscribe.Text = "Job Info Subscribe";
            this.btnJobInfoSubscribe.UseVisualStyleBackColor = true;
            this.btnJobInfoSubscribe.Click += new System.EventHandler(this.BtnJobInfoSubscribe_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAbortJob);
            this.groupBox2.Controls.Add(this.txtProduct);
            this.groupBox2.Controls.Add(this.btnSendProduct);
            this.groupBox2.Controls.Add(this.btnSendJob);
            this.groupBox2.Controls.Add(this.numericJob);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(629, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Commands";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(189, 21);
            this.txtProduct.MaxLength = 25;
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(160, 22);
            this.txtProduct.TabIndex = 10;
            // 
            // btnSendProduct
            // 
            this.btnSendProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendProduct.Location = new System.Drawing.Point(355, 20);
            this.btnSendProduct.Name = "btnSendProduct";
            this.btnSendProduct.Size = new System.Drawing.Size(100, 23);
            this.btnSendProduct.TabIndex = 11;
            this.btnSendProduct.Text = "Send Product";
            this.btnSendProduct.UseVisualStyleBackColor = true;
            this.btnSendProduct.Click += new System.EventHandler(this.BtnSendProduct_Click);
            // 
            // btnSendJob
            // 
            this.btnSendJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendJob.Location = new System.Drawing.Point(74, 21);
            this.btnSendJob.Name = "btnSendJob";
            this.btnSendJob.Size = new System.Drawing.Size(100, 23);
            this.btnSendJob.TabIndex = 10;
            this.btnSendJob.Text = "Send Job";
            this.btnSendJob.UseVisualStyleBackColor = true;
            this.btnSendJob.Click += new System.EventHandler(this.BtnSendJob_Click);
            // 
            // numericJob
            // 
            this.numericJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericJob.Location = new System.Drawing.Point(6, 21);
            this.numericJob.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericJob.Name = "numericJob";
            this.numericJob.Size = new System.Drawing.Size(62, 22);
            this.numericJob.TabIndex = 10;
            this.numericJob.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAbortJob
            // 
            this.btnAbortJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbortJob.Location = new System.Drawing.Point(6, 50);
            this.btnAbortJob.Name = "btnAbortJob";
            this.btnAbortJob.Size = new System.Drawing.Size(168, 23);
            this.btnAbortJob.TabIndex = 12;
            this.btnAbortJob.Text = "Abort Job";
            this.btnAbortJob.UseVisualStyleBackColor = true;
            this.btnAbortJob.Click += new System.EventHandler(this.BtnAbortJob_Click);
            // 
            // DriverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 290);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numericPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConnection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textIp);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DriverForm";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericJob)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolstripLast;
        private System.Windows.Forms.TextBox textIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTighteningSubscribe;
        private System.Windows.Forms.Button btnJobInfoSubscribe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripStatusLabel lastMessageArrived;
        private System.Windows.Forms.Button btnSendJob;
        private System.Windows.Forms.NumericUpDown numericJob;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Button btnSendProduct;
        private System.Windows.Forms.Button btnAbortJob;
    }
}

