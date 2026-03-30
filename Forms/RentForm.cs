using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entities;

namespace LW3_PCA.Forms
{
    public partial class RentForm : Form
    {
        public Auto SelectedAuto { get; private set; }
        public Client SelectedClient { get; private set; }

        private List<Client> _clients;

        public RentForm(Auto auto, List<Client> clients)
        {
            InitializeComponent();
            SelectedAuto = auto;
            _clients = clients;
            LoadAutoDetails();
            LoadClients();
        }

        private void LoadAutoDetails()
        {
            lblAutoInfo.Text = $"Car: Reg #{SelectedAuto.RegistrationNumber} | " +
                              $"Passengers: {SelectedAuto.PassengerNumber} | " +
                              $"Year: {SelectedAuto.ReleaseYear} | " +
                              $"Cost: ${SelectedAuto.RentCost}/day";
        }

        private void LoadClients()
        {
            cmbClients.DataSource = _clients;
            cmbClients.DisplayMember = "LastName";
            cmbClients.ValueMember = null; // We'll use SelectedItem
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (cmbClients.SelectedItem == null)
            {
                MessageBox.Show("Please select a client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedClient = (Client)cmbClients.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}