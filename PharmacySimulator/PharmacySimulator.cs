using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace PharmacySimulator
{
    public partial class PharmacySimulator : Form
    {
        Pharmacy pharmacy;

        public PharmacySimulator()
        {
            InitializeComponent();
            pharmacy = new Pharmacy();
            RefreshControls();
        }

        private void RefreshControls()
        {
            balanceLabel.Text = pharmacy.Balance.ToString();
            reputationLabel.Text = pharmacy.Reputation.ToString();
            chamberLabel.Text = pharmacy.ChamberReputation.ToString();

            InventoryGridView.RowHeadersVisible = false;
            InventoryGridView.ColumnCount = 2;
            InventoryGridView.Columns[0].Name = "Towar";
            InventoryGridView.Columns[0].Width = 150;
            InventoryGridView.Columns[1].Name = "Ilość";
            InventoryGridView.Columns[1].Width = 50;
            InventoryGridView.Rows.Clear();

            foreach(InventoryItem inventoryItem in pharmacy.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    InventoryGridView.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }

            queueBox.Clear();

            foreach(Patient patient in pharmacy.PatientsQueue)
            {
                queueBox.Text += patient.Name + Environment.NewLine;
            }


            InventoryGridView.Sort(InventoryGridView.Columns[0], ListSortDirection.Ascending);

            wsEmployee1.Text = pharmacy.Workstations[0].EmployeeName;
            wsPatient1.Text = pharmacy.Workstations[0].PatientName;
            wsStatus1.Text = pharmacy.Workstations[0].GetStatus();

            wsEmployee2.Text = pharmacy.Workstations[1].EmployeeName;
            wsPatient2.Text = pharmacy.Workstations[1].PatientName;
            wsStatus2.Text = pharmacy.Workstations[1].GetStatus();

            wsEmployee3.Text = pharmacy.Workstations[2].EmployeeName;
            wsPatient3.Text = pharmacy.Workstations[2].PatientName;
            wsStatus3.Text = pharmacy.Workstations[2].GetStatus();

            wsEmployee4.Text = pharmacy.Workstations[3].EmployeeName;
            wsPatient4.Text = pharmacy.Workstations[3].PatientName;
            wsStatus4.Text = pharmacy.Workstations[3].GetStatus();

            reportBox.SelectionStart = reportBox.Text.Length;
            reportBox.ScrollToCaret();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            reportBox.Text += pharmacy.ProcessNextTurn();
            RefreshControls();
        }
    }
}
