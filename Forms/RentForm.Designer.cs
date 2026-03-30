namespace LW3_PCA.Forms
{
    partial class RentForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAutoInfo;
        private System.Windows.Forms.Label lblSelectClient;
        private System.Windows.Forms.ComboBox cmbClients;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnCancel;

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
            lblAutoInfo = new Label();
            lblSelectClient = new Label();
            cmbClients = new ComboBox();
            btnRent = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblAutoInfo
            // 
            lblAutoInfo.AutoSize = true;
            lblAutoInfo.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            lblAutoInfo.Location = new Point(27, 30);
            lblAutoInfo.Name = "lblAutoInfo";
            lblAutoInfo.Size = new Size(51, 20);
            lblAutoInfo.TabIndex = 0;
            lblAutoInfo.Text = "Car: ";
            // 
            // lblSelectClient
            // 
            lblSelectClient.AutoSize = true;
            lblSelectClient.Location = new Point(27, 90);
            lblSelectClient.Name = "lblSelectClient";
            lblSelectClient.Size = new Size(94, 20);
            lblSelectClient.TabIndex = 1;
            lblSelectClient.Text = "Select Client:";
            // 
            // cmbClients
            // 
            cmbClients.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClients.FormattingEnabled = true;
            cmbClients.Location = new Point(124, 87);
            cmbClients.Name = "cmbClients";
            cmbClients.Size = new Size(223, 28);
            cmbClients.TabIndex = 2;
            // 
            // btnRent
            // 
            btnRent.Location = new Point(124, 150);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(89, 35);
            btnRent.TabIndex = 3;
            btnRent.Text = "Rent";
            btnRent.UseVisualStyleBackColor = true;
            btnRent.Click += btnRent_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(258, 150);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 35);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // RentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 341);
            Controls.Add(btnCancel);
            Controls.Add(btnRent);
            Controls.Add(cmbClients);
            Controls.Add(lblSelectClient);
            Controls.Add(lblAutoInfo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Rent a Car";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}