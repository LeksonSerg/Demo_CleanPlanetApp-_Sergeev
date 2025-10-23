using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using CleanPlanetApp.Models;

namespace CleanPlanetApp
{
    public partial class ServicesForm : Form
    {
        private DatabaseHelper dbHelper;

        public ServicesForm()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
            LoadServices();
        }

        private void LoadServices()
        {
            var services = dbHelper.GetServicesWithCost();

            dataGridView.Rows.Clear();
            foreach (var service in services)
            {
                dataGridView.Rows.Add(
                    service.ServiceCode,
                    service.ServiceName,
                    service.ServiceTypeName,
                    service.MinimalCost.ToString("C2"),
                    service.CalculatedCost > 0 ? service.CalculatedCost.ToString("C2") : "Ошибка расчета"
                );
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}