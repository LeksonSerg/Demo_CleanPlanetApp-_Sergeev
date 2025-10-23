using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using CleanPlanetApp.Models;

namespace CleanPlanetApp
{
    public partial class MaterialCalculationForm : Form
    {
        private DatabaseHelper dbHelper;

        public MaterialCalculationForm()
        {
            dbHelper = new DatabaseHelper();
            InitializeComponent();
            LoadServiceTypes();
            LoadMaterialTypes();
        }

        private void LoadServiceTypes()
        {
            try
            {
                using (var connection = new SqlConnection(dbHelper.GetConnectionString()))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT ServiceTypeId, ServiceTypeName FROM ServiceTypes",
                        connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            serviceTypeComboBox.Items.Add(new
                            {
                                Id = (int)reader["ServiceTypeId"],
                                Name = reader["ServiceTypeName"].ToString()
                            });
                        }
                    }

                    if (serviceTypeComboBox.Items.Count > 0)
                    {
                        serviceTypeComboBox.DisplayMember = "Name";
                        serviceTypeComboBox.ValueMember = "Id";
                        serviceTypeComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов услуг: {ex.Message}");
            }
        }

        private void LoadMaterialTypes()
        {
            try
            {
                using (var connection = new SqlConnection(dbHelper.GetConnectionString()))
                {
                    connection.Open();
                    var command = new SqlCommand(
                        "SELECT MaterialId, MaterialType FROM Materials",
                        connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            materialTypeComboBox.Items.Add(new
                            {
                                Id = (int)reader["MaterialId"],
                                Name = reader["MaterialType"].ToString()
                            });
                        }
                    }

                    if (materialTypeComboBox.Items.Count > 0)
                    {
                        materialTypeComboBox.DisplayMember = "Name";
                        materialTypeComboBox.ValueMember = "Id";
                        materialTypeComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов материалов: {ex.Message}");
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем выбранные значения
                if (serviceTypeComboBox.SelectedItem == null ||
                    materialTypeComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите тип услуги и тип материала");
                    return;
                }

                // Получаем ID выбранных элементов
                dynamic selectedService = serviceTypeComboBox.SelectedItem;
                dynamic selectedMaterial = materialTypeComboBox.SelectedItem;

                int serviceTypeId = selectedService.Id;
                int materialTypeId = selectedMaterial.Id;

                // Парсим ввод пользователя
                if (!int.TryParse(serviceCountTextBox.Text, out int serviceCount) || serviceCount <= 0)
                {
                    MessageBox.Show("Введите корректное количество услуг (целое положительное число)");
                    return;
                }

                if (!double.TryParse(serviceParametersTextBox.Text, out double serviceParameters) || serviceParameters <= 0)
                {
                    MessageBox.Show("Введите корректные параметры услуги (положительное число)");
                    return;
                }

                // Вызываем метод расчета
                int result = dbHelper.CalculateMaterialQuantity(
                    serviceTypeId, materialTypeId, serviceCount, serviceParameters);

                if (result >= 0)
                {
                    resultLabel.Text = $"Необходимое количество материала: {result}";
                    resultLabel.ForeColor = Color.Green;
                }
                else
                {
                    resultLabel.Text = "Ошибка расчета";
                    resultLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}