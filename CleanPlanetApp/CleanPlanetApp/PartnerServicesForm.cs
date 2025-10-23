using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CleanPlanetApp.Models;

namespace CleanPlanetApp
{
    public partial class PartnerServicesForm : Form
    {
        private int partnerId;
        private DatabaseHelper dbHelper;
        public PartnerServicesForm(int partnerId)
        {
            this.partnerId = partnerId;
            dbHelper = new DatabaseHelper();
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            var services = dbHelper.GetPartnerServices(partnerId);

            dataGridView.Rows.Clear();
            foreach (var service in services)
            {
                dataGridView.Rows.Add(
                    service.ServiceName,
                    service.Quantity,
                    service.ExecutionDate.ToString("dd.MM.yyyy")
                );
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}