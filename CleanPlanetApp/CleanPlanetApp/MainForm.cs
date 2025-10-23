using System;
using System.Drawing;
using System.Windows.Forms;
using CleanPlanetApp.Models;

namespace CleanPlanetApp
{
    public partial class MainForm : Form
    {
        private DatabaseHelper dbHelper;

        public MainForm()
        {
            InitializeComponent();
            LoadLogo();
            dbHelper = new DatabaseHelper();
            LoadPartners();

            // Добавляем обработчик закрытия формы
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Подтверждение закрытия
            DialogResult result = MessageBox.Show(
                "Вы уверены, что хотите закрыть приложение?",
                "Подтверждение закрытия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Отменяем закрытие
            }
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = "Лого.jpg";
                if (System.IO.File.Exists(logoPath))
                {
                    logoPictureBox.Image = Image.FromFile(logoPath);
                }
                else
                {
                    logoPictureBox.BackColor = Color.FromArgb(0, 206, 209);
                }
            }
            catch (Exception)
            {
                logoPictureBox.BackColor = Color.FromArgb(0, 206, 209);
            }
        }

        private void LoadPartners()
        {
            flowLayoutPanel.Controls.Clear();

            try
            {
                var partners = dbHelper.GetPartners();

                foreach (var partner in partners)
                {
                    var card = CreatePartnerCard(partner);
                    flowLayoutPanel.Controls.Add(card);
                }

                // Если партнеров нет, показываем сообщение
                if (partners.Count == 0)
                {
                    var noDataLabel = new Label
                    {
                        Text = "Нет данных о партнерах",
                        Font = new Font("Arial", 12),
                        ForeColor = Color.Red,
                        AutoSize = true
                    };
                    flowLayoutPanel.Controls.Add(noDataLabel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки партнеров: {ex.Message}", "Ошибка");
            }
        }

        private Panel CreatePartnerCard(Partner partner)
        {
            var card = new Panel
            {
                Size = new Size(280, 150),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };

            var typeNameLabel = new Label
            {
                Text = $"{partner.PartnerType} | {partner.Name}",
                Font = new Font("Franklin Gothic Medium", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var directorLabel = new Label
            {
                Text = partner.Director,
                Font = new Font("Franklin Gothic Medium", 9),
                Location = new Point(10, 35),
                AutoSize = true
            };

            var phoneLabel = new Label
            {
                Text = partner.Phone,
                Font = new Font("Franklin Gothic Medium", 9),
                Location = new Point(10, 55),
                AutoSize = true
            };

            var ratingLabel = new Label
            {
                Text = $"Рейтинг: {partner.Rating}",
                Font = new Font("Franklin Gothic Medium", 9, FontStyle.Bold),
                Location = new Point(10, 75),
                AutoSize = true
            };

            var servicesButton = new Button
            {
                Text = "История услуг",
                BackColor = Color.FromArgb(0, 206, 209),
                ForeColor = Color.White,
                Font = new Font("Franklin Gothic Medium", 8),
                Size = new Size(100, 25),
                Location = new Point(160, 110),
                Cursor = Cursors.Hand,
                Tag = partner.PartnerId
            };
            servicesButton.Click += ServicesButton_Click;

            card.Controls.Add(typeNameLabel);
            card.Controls.Add(directorLabel);
            card.Controls.Add(phoneLabel);
            card.Controls.Add(ratingLabel);
            card.Controls.Add(servicesButton);

            card.Click += (s, e) => EditPartner(partner);

            return card;
        }

        private void EditPartner(Partner partner)
        {
            var partnerForm = new PartnerForm(partner);
            if (partnerForm.ShowDialog() == DialogResult.OK)
            {
                LoadPartners();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var partnerForm = new PartnerForm();
            if (partnerForm.ShowDialog() == DialogResult.OK)
            {
                LoadPartners();
            }
        }

        private void ServicesButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int partnerId = (int)button.Tag;

            var servicesForm = new PartnerServicesForm(partnerId);
            servicesForm.ShowDialog();
        }

        private void MaterialCalculationButton_Click(object sender, EventArgs e)
        {
            var calculationForm = new MaterialCalculationForm();
            calculationForm.ShowDialog();
        }

        private void ServicesCostButton_Click(object sender, EventArgs e)
        {
            var servicesForm = new ServicesForm();
            servicesForm.ShowDialog();
        }

        // Добавляем кнопку выхода в главную форму
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}