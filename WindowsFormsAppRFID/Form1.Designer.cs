namespace WindowsFormsAppRFID
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtRFIDData;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPortName;
        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.Label lblPortName;
        private System.Windows.Forms.Label lblBaudRate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtRFIDData = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPortName = new System.Windows.Forms.TextBox();
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblPortName = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRFIDData
            // 
            this.txtRFIDData.Location = new System.Drawing.Point(16, 15);
            this.txtRFIDData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRFIDData.Multiline = true;
            this.txtRFIDData.Name = "txtRFIDData";
            this.txtRFIDData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRFIDData.Size = new System.Drawing.Size(479, 245);
            this.txtRFIDData.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(396, 268);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 28);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPortName
            // 
            this.txtPortName.Location = new System.Drawing.Point(124, 271);
            this.txtPortName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPortName.Name = "txtPortName";
            this.txtPortName.Size = new System.Drawing.Size(160, 24);
            this.txtPortName.TabIndex = 2;
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.cbBaudRate.Location = new System.Drawing.Point(124, 304);
            this.cbBaudRate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(160, 24);
            this.cbBaudRate.TabIndex = 3;
            // 
            // lblPortName
            // 
            this.lblPortName.AutoSize = true;
            this.lblPortName.Location = new System.Drawing.Point(16, 274);
            this.lblPortName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPortName.Name = "lblPortName";
            this.lblPortName.Size = new System.Drawing.Size(74, 16);
            this.lblPortName.TabIndex = 4;
            this.lblPortName.Text = "Port Name:";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(16, 308);
            this.lblBaudRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(74, 16);
            this.lblBaudRate.TabIndex = 5;
            this.lblBaudRate.Text = "Baud Rate:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 346);
            this.Controls.Add(this.lblBaudRate);
            this.Controls.Add(this.lblPortName);
            this.Controls.Add(this.cbBaudRate);
            this.Controls.Add(this.txtPortName);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtRFIDData);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "RFID Reader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
