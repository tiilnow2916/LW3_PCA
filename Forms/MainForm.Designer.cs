namespace LW3_PCA.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAvailable;
        private System.Windows.Forms.TabPage tabPageRented;
        private System.Windows.Forms.TabPage tabPageHistory;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.DataGridView dgvAvailableCars;
        private System.Windows.Forms.DataGridView dgvRentedCars;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label lblPassengers;
        private System.Windows.Forms.TextBox txtFilterPassengers;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtFilterYear;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtFilterCost;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearFilter;
        private TextBox txtFilterMileage;
        private Label lblMileage;
        private TextBox txtFilterEngineCapacity;
        private Label lblEngineCapacity;
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
            tabControl1 = new TabControl();
            tabPageAvailable = new TabPage();
            btnRent = new Button();
            groupBoxFilter = new GroupBox();
            btnClearFilter = new Button();
            btnSearch = new Button();
            txtFilterCost = new TextBox();
            lblCost = new Label();
            txtFilterYear = new TextBox();
            lblYear = new Label();
            txtFilterPassengers = new TextBox();
            this.txtFilterMileage = new TextBox();
            this.lblMileage = new Label();
            this.txtFilterEngineCapacity = new TextBox();
            this.lblEngineCapacity = new Label();
            lblPassengers = new Label();
            dgvAvailableCars = new DataGridView();
            tabPageRented = new TabPage();
            btnReturn = new Button();
            dgvRentedCars = new DataGridView();
            tabPageHistory = new TabPage();
            dgvHistory = new DataGridView();
            tabPageClients = new TabPage();
            dgvClients = new DataGridView();
            tabControl1.SuspendLayout();
            tabPageAvailable.SuspendLayout();
            groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).BeginInit();
            tabPageRented.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRentedCars).BeginInit();
            tabPageHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageAvailable);
            tabControl1.Controls.Add(tabPageRented);
            tabControl1.Controls.Add(tabPageHistory);
            tabControl1.Controls.Add(tabPageClients);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(875, 561);
            tabControl1.TabIndex = 0;
            // 
            // tabPageAvailable
            // 
            tabPageAvailable.Controls.Add(btnRent);
            tabPageAvailable.Controls.Add(groupBoxFilter);
            tabPageAvailable.Controls.Add(dgvAvailableCars);
            tabPageAvailable.Location = new Point(4, 29);
            tabPageAvailable.Name = "tabPageAvailable";
            tabPageAvailable.Padding = new Padding(3);
            tabPageAvailable.Size = new Size(867, 528);
            tabPageAvailable.TabIndex = 0;
            tabPageAvailable.Text = "Available Cars";
            // 
            // btnRent
            // 
            btnRent.Anchor = AnchorStyles.Bottom;
            btnRent.Location = new Point(382, 487);
            btnRent.Name = "btnRent";
            btnRent.Size = new Size(133, 35);
            btnRent.TabIndex = 2;
            btnRent.Text = "Rent Selected Car";
            btnRent.UseVisualStyleBackColor = true;
            btnRent.Click += btnRent_Click;
            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(btnClearFilter);
            groupBoxFilter.Controls.Add(btnSearch);
            groupBoxFilter.Controls.Add(txtFilterCost);
            groupBoxFilter.Controls.Add(lblCost);
            groupBoxFilter.Controls.Add(txtFilterYear);
            groupBoxFilter.Controls.Add(lblYear);
            groupBoxFilter.Controls.Add(txtFilterPassengers);
            groupBoxFilter.Controls.Add(lblPassengers);
            groupBoxFilter.Location = new Point(9, 10);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(850, 80);
            groupBoxFilter.TabIndex = 1;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Filter Cars";
            this.groupBoxFilter.Controls.Add(this.txtFilterMileage);
            this.groupBoxFilter.Controls.Add(this.lblMileage);
            this.groupBoxFilter.Controls.Add(this.txtFilterEngineCapacity);
            this.groupBoxFilter.Controls.Add(this.lblEngineCapacity);
            // 
            // btnClearFilter
            // 
            btnClearFilter.Location = new Point(747, 45);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(80, 28);
            btnClearFilter.TabIndex = 7;
            btnClearFilter.Text = "Clear";
            btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(661, 47);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 28);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtFilterCost
            // 
            txtFilterCost.Location = new Point(451, 45);
            txtFilterCost.Name = "txtFilterCost";
            txtFilterCost.Size = new Size(89, 27);
            txtFilterCost.TabIndex = 5;
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.Location = new Point(363, 50);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(73, 20);
            lblCost.TabIndex = 4;
            lblCost.Text = "Max Cost:";
            // 
            // txtFilterYear
            // 
            txtFilterYear.Location = new Point(247, 48);
            txtFilterYear.Name = "txtFilterYear";
            txtFilterYear.Size = new Size(89, 27);
            txtFilterYear.TabIndex = 3;
            // 
            // txtFilterMileage
            this.txtFilterMileage.Location = new Point(451, 20);
            this.txtFilterMileage.Name = "txtFilterMileage";
            this.txtFilterMileage.Size = new Size(89, 27);
            this.txtFilterMileage.TabIndex = 9;
            // lblMileage
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new Point(363, 23);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new Size(62, 20);
            this.lblMileage.TabIndex = 8;
            this.lblMileage.Text = "Mileage:";
            // txtFilterEngineCapacity
            this.txtFilterEngineCapacity.Location = new Point(247, 20);
            this.txtFilterEngineCapacity.Name = "txtFilterEngineCapacity";
            this.txtFilterEngineCapacity.Size = new Size(89, 27);
            this.txtFilterEngineCapacity.TabIndex = 11;

            // lblEngineCapacity
            this.lblEngineCapacity.AutoSize = true;
            this.lblEngineCapacity.Location = new Point(190, 23);
            this.lblEngineCapacity.Name = "lblEngineCapacity";
            this.lblEngineCapacity.Size = new Size(51, 20);
            this.lblEngineCapacity.TabIndex = 10;
            this.lblEngineCapacity.Text = "Engine:";
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(190, 52);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(40, 20);
            lblYear.TabIndex = 2;
            lblYear.Text = "Year:";
            // 
            // txtFilterPassengers
            // 
            txtFilterPassengers.Location = new Point(98, 50);
            txtFilterPassengers.Name = "txtFilterPassengers";
            txtFilterPassengers.Size = new Size(72, 27);
            txtFilterPassengers.TabIndex = 1;
            // 
            // lblPassengers
            // 
            lblPassengers.AutoSize = true;
            lblPassengers.Location = new Point(9, 50);
            lblPassengers.Name = "lblPassengers";
            lblPassengers.Size = new Size(83, 20);
            lblPassengers.TabIndex = 0;
            lblPassengers.Text = "Passengers:";
            // 
            // dgvAvailableCars
            // 
            dgvAvailableCars.AllowUserToAddRows = false;
            dgvAvailableCars.AllowUserToDeleteRows = false;
            dgvAvailableCars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAvailableCars.ColumnHeadersHeight = 29;
            dgvAvailableCars.Location = new Point(9, 100);
            dgvAvailableCars.Name = "dgvAvailableCars";
            dgvAvailableCars.ReadOnly = true;
            dgvAvailableCars.RowHeadersWidth = 62;
            dgvAvailableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailableCars.Size = new Size(850, 380);
            dgvAvailableCars.TabIndex = 0;
            dgvAvailableCars.SelectionChanged += dgvAvailableCars_SelectionChanged;
            // 
            // tabPageRented
            // 
            tabPageRented.Controls.Add(btnReturn);
            tabPageRented.Controls.Add(dgvRentedCars);
            tabPageRented.Location = new Point(4, 29);
            tabPageRented.Name = "tabPageRented";
            tabPageRented.Padding = new Padding(3);
            tabPageRented.Size = new Size(867, 528);
            tabPageRented.TabIndex = 1;
            tabPageRented.Text = "Rented Cars";
            // 
            // btnReturn
            // 
            btnReturn.Anchor = AnchorStyles.Bottom;
            btnReturn.Location = new Point(382, 487);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(133, 35);
            btnReturn.TabIndex = 1;
            btnReturn.Text = "Return Selected Car";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Click += btnReturn_Click;
            // 
            // dgvRentedCars
            // 
            dgvRentedCars.AllowUserToAddRows = false;
            dgvRentedCars.AllowUserToDeleteRows = false;
            dgvRentedCars.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRentedCars.ColumnHeadersHeight = 29;
            dgvRentedCars.Location = new Point(9, 20);
            dgvRentedCars.Name = "dgvRentedCars";
            dgvRentedCars.ReadOnly = true;
            dgvRentedCars.RowHeadersWidth = 62;
            dgvRentedCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRentedCars.Size = new Size(850, 460);
            dgvRentedCars.TabIndex = 0;
            dgvRentedCars.SelectionChanged += dgvRentedCars_SelectionChanged;
            // 
            // tabPageHistory
            // 
            tabPageHistory.Controls.Add(dgvHistory);
            tabPageHistory.Location = new Point(4, 29);
            tabPageHistory.Name = "tabPageHistory";
            tabPageHistory.Size = new Size(867, 528);
            tabPageHistory.TabIndex = 2;
            tabPageHistory.Text = "History";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHistory.ColumnHeadersHeight = 29;
            dgvHistory.Location = new Point(9, 20);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersWidth = 62;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new Size(850, 500);
            dgvHistory.TabIndex = 0;
            // 
            // tabPageClients
            // 
            tabPageClients.Controls.Add(dgvClients);
            tabPageClients.Location = new Point(4, 29);
            tabPageClients.Name = "tabPageClients";
            tabPageClients.Size = new Size(867, 528);
            tabPageClients.TabIndex = 3;
            tabPageClients.Text = "Clients";
            // 
            // dgvClients
            // 
            dgvClients.AllowUserToAddRows = false;
            dgvClients.AllowUserToDeleteRows = false;
            dgvClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClients.ColumnHeadersHeight = 29;
            dgvClients.Location = new Point(9, 20);
            dgvClients.Name = "dgvClients";
            dgvClients.ReadOnly = true;
            dgvClients.RowHeadersWidth = 62;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.Size = new Size(850, 500);
            dgvClients.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(875, 561);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Car Rental Management";
            tabControl1.ResumeLayout(false);
            tabPageAvailable.ResumeLayout(false);
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableCars).EndInit();
            tabPageRented.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRentedCars).EndInit();
            tabPageHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            tabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            ResumeLayout(false);
        }
    }
}