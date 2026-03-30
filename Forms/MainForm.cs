using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entities;
using BusinessLogic;

namespace LW3_PCA.Forms
{
    public partial class MainForm : Form
    {
        private AutoBL _autoBL;
        private ClientBL _clientBL;
        private RentRegistrationBL _rentBL;

        public MainForm()
        {
            InitializeComponent();
            InitializeBusinessLogic();
            InitializeData();
            ConfigureDataGridViews();
        }

        private void InitializeBusinessLogic()
        {
            // Initialize Business Logic layers
            _autoBL = new AutoBL();
            _clientBL = new ClientBL();
            _rentBL = new RentRegistrationBL();
        }

        private void InitializeData()
        {
            // Load sample data if needed (or load from a data source)
            // For demo, adding some sample data
            if (!_autoBL.GetAvailable().Any())
            {
                _autoBL.Add(new Auto { PassengerNumber = 4, EngineCapacity = 1600, Mileage = 50000, ReleaseYear = 2020, RegistrationNumber = 1001, InsuranceSumm = 500, RentCost = 50 });
                _autoBL.Add(new Auto { PassengerNumber = 5, EngineCapacity = 2000, Mileage = 30000, ReleaseYear = 2022, RegistrationNumber = 1002, InsuranceSumm = 600, RentCost = 70 });
                _autoBL.Add(new Auto { PassengerNumber = 2, EngineCapacity = 1200, Mileage = 20000, ReleaseYear = 2023, RegistrationNumber = 1003, InsuranceSumm = 400, RentCost = 40 });
            }

            if (!_clientBL.GetAllClients().Any())
            {
                _clientBL.Add(new Client { FirstName = "John", LastName = "Doe", CarRights = 5 });
                _clientBL.Add(new Client { FirstName = "Jane", LastName = "Smith", CarRights = 10 });
            }

            RefreshAvailableCarsList();
            RefreshUnavailableCarsList();
            RefreshHistoryList();
            RefreshClientsList();
        }

        private void ConfigureDataGridViews()
        {
            // Configure Auto DataGridViews
            ConfigureAutoGridView(dgvAvailableCars);
            ConfigureAutoGridView(dgvRentedCars); 

            // Configure History DataGridView
            dgvHistory.AutoGenerateColumns = false;
            dgvHistory.Columns.Clear();
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "DateOfAction", HeaderText = "Date" });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TypeOfAction", HeaderText = "Type" });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ClientName", HeaderText = "Client" });
            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CarInfo", HeaderText = "Car (Reg #)" });

            // Configure Clients DataGridView
            dgvClients.AutoGenerateColumns = false;
            dgvClients.Columns.Clear();
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FirstName", HeaderText = "First Name" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "LastName", HeaderText = "Last Name" });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CarRights", HeaderText = "Car Rights (Years)" });
        }

        private void ConfigureAutoGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RegistrationNumber", HeaderText = "Reg #" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PassengerNumber", HeaderText = "Passengers" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "EngineCapacity", HeaderText = "Engine (cc)" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Mileage", HeaderText = "Mileage (km)" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ReleaseYear", HeaderText = "Year" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RentCost", HeaderText = "Rent Cost ($/day)" });
        }

        // --- Refresh Methods ---
        public void RefreshAvailableCarsList()
        {
            var availableCars = _autoBL.GetAvailable().ToList();
            dgvAvailableCars.DataSource = null;
            dgvAvailableCars.DataSource = availableCars;
            UpdateRentButtonState();
        }

        public void RefreshUnavailableCarsList()
        {
            var rentedCars = _autoBL.GetUnavailable().ToList();
            dgvRentedCars.DataSource = null;
            dgvRentedCars.DataSource = rentedCars;
            UpdateReturnButtonState();
        }

        public void RefreshHistoryList()
        {
            var registrations = _rentBL.GetAllRegistrations().ToList();

            var historyItems = registrations.Select(r => new
            {
                r.Id,
                r.DateOfAction,
                TypeOfAction = r.TypeOfAction switch
                {
                    RentActionType.Rent => "RENT",
                    RentActionType.Return => "RETURN",
                    _ => "UNKNOWN"
                },
                ClientName = $"{r.Client.FirstName} {r.Client.LastName}",
                CarInfo = $"{r.Auto.RegistrationNumber} ({r.Auto.PassengerNumber} seats)"
            }).ToList();

            dgvHistory.DataSource = null;
            dgvHistory.DataSource = historyItems;
        }

        public void RefreshClientsList()
        {
            var clients = _clientBL.GetAllClients().ToList();
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
        }

        // --- Button State Management ---
        private void UpdateRentButtonState()
        {
            btnRent.Enabled = dgvAvailableCars.SelectedRows.Count > 0;
        }

        private void UpdateReturnButtonState()
        {
            btnReturn.Enabled = dgvRentedCars.SelectedRows.Count > 0;
        }

        // --- Search / Filter Logic ---
        private void ApplyFilter()
        {
            int? passengers = null;
            int? year = null;
            double? maxCost = null;
            int? maxMileage = null;
            int? engineCapacity = null;

            if (int.TryParse(txtFilterPassengers.Text, out int p))
                passengers = p;
            if (int.TryParse(txtFilterYear.Text, out int y))
                year = y;
            if (double.TryParse(txtFilterCost.Text, out double c))
                maxCost = c;
            if (int.TryParse(txtFilterMileage.Text, out int m))
                maxMileage = m;
            if (int.TryParse(txtFilterEngineCapacity.Text, out int ec))
                engineCapacity = ec;

            var filtered = _autoBL.GetAvailable()
                .Where(a => (!passengers.HasValue || a.PassengerNumber == passengers.Value) &&
                            (!year.HasValue || a.ReleaseYear == year.Value) &&
                            (!maxCost.HasValue || a.RentCost <= maxCost.Value) &&
                            (!maxMileage.HasValue || a.Mileage <= maxMileage.Value) &&
                            (!engineCapacity.HasValue || a.EngineCapacity == engineCapacity.Value))
                .ToList();

            dgvAvailableCars.DataSource = null;
            dgvAvailableCars.DataSource = filtered;
        }

        private void ClearFilter()
        {
            txtFilterPassengers.Text = "";
            txtFilterYear.Text = "";
            txtFilterCost.Text = "";
            txtFilterMileage.Text = "";
            txtFilterEngineCapacity.Text = "";
            RefreshAvailableCarsList();
        }

        // --- Event Handlers ---
        private void btnRent_Click(object sender, EventArgs e)
        {
            if (dgvAvailableCars.SelectedRows.Count == 0) return;

            var selectedAuto = (Auto)dgvAvailableCars.SelectedRows[0].DataBoundItem;
            using (var rentForm = new RentForm(selectedAuto, _clientBL.GetAllClients().ToList()))
            {
                if (rentForm.ShowDialog() == DialogResult.OK)
                {
                    // Perform rent registration
                    _autoBL.RentAuto(selectedAuto);
                    _rentBL.RegisterRent(selectedAuto, rentForm.SelectedClient);

                    RefreshAvailableCarsList();
                    RefreshUnavailableCarsList();
                    RefreshHistoryList();
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvRentedCars.SelectedRows.Count == 0) return;

            var selectedAuto = (Auto)dgvRentedCars.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Return car {selectedAuto.RegistrationNumber}?", "Confirm Return",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _autoBL.ReturnAuto(selectedAuto);
                _rentBL.RegisterReturn(selectedAuto);

                RefreshAvailableCarsList();
                RefreshUnavailableCarsList();
                RefreshHistoryList();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ClearFilter();
        }

        private void dgvAvailableCars_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRentButtonState();
        }

        private void dgvRentedCars_SelectionChanged(object sender, EventArgs e)
        {
            UpdateReturnButtonState();
        }
    }
}