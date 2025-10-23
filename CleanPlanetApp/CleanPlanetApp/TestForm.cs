using System;
using System.Windows.Forms;

namespace CleanPlanetApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            this.Text = "Тестовая форма - ДОЛЖНА ОСТАВАТЬСЯ ОТКРЫТОЙ";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;

            var label = new Label();
            label.Text = "Если вы видите это сообщение - форма работает!";
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(50, 50);
            label.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            var closeButton = new Button();
            closeButton.Text = "Закрыть приложение";
            closeButton.Location = new System.Drawing.Point(50, 100);
            closeButton.Size = new System.Drawing.Size(150, 40);
            closeButton.Click += (s, e) => this.Close();

            this.Controls.Add(label);
            this.Controls.Add(closeButton);

            // Обработчик закрытия
            this.FormClosing += (s, e) =>
            {
                if (MessageBox.Show("Точно закрыть?", "Подтверждение",
                    MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            };
        }
    }
}