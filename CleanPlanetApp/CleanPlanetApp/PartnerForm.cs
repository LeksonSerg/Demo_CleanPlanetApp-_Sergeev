using System;
using System.Drawing;
using System.Windows.Forms;
using CleanPlanetApp.Models;

namespace CleanPlanetApp
{
    public partial class PartnerForm : Form
    {
        private Partner partner;
        private DatabaseHelper dbHelper;
        private bool isEditMode;

        private ComboBox typeComboBox;
        private TextBox nameTextBox;
        private TextBox directorTextBox;
        private TextBox emailTextBox;
        private TextBox phoneTextBox;
        private TextBox addressTextBox;
        private TextBox innTextBox;
        private NumericUpDown ratingNumeric;

        public PartnerForm(Partner existingPartner = null)
        {
            dbHelper = new DatabaseHelper();
            partner = existingPartner ?? new Partner();
            isEditMode = existingPartner != null;

            InitializeComponent();

            this.Text = isEditMode ? "Редактирование партнера" : "Добавление партнера";

            LoadPartnerTypes();

            if (isEditMode)
            {
                LoadPartnerData();
            }
        }

        private void LoadPartnerTypes()
        {
            var types = dbHelper.GetPartnerTypes();
            typeComboBox.Items.AddRange(types.ToArray());
        }

        private void LoadPartnerData()
        {
            typeComboBox.SelectedItem = partner.PartnerType;
            nameTextBox.Text = partner.Name;
            directorTextBox.Text = partner.Director;
            emailTextBox.Text = partner.Email;
            phoneTextBox.Text = partner.Phone;
            addressTextBox.Text = partner.LegalAddress;
            innTextBox.Text = partner.INN;
            ratingNumeric.Value = partner.Rating;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SavePartner();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void SavePartner()
        {
            try
            {
                partner.PartnerType = typeComboBox.SelectedItem?.ToString() ?? "";
                partner.Name = nameTextBox.Text;
                partner.Director = directorTextBox.Text;
                partner.Email = emailTextBox.Text;
                partner.Phone = phoneTextBox.Text;
                partner.LegalAddress = addressTextBox.Text;
                partner.INN = innTextBox.Text;
                partner.Rating = (int)ratingNumeric.Value;

                if (string.IsNullOrWhiteSpace(partner.Name) || string.IsNullOrWhiteSpace(partner.PartnerType))
                {
                    MessageBox.Show("Заполните обязательные поля: Тип партнера и Наименование", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dbHelper.SavePartner(partner))
                {
                    MessageBox.Show("Партнер успешно сохранен", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}