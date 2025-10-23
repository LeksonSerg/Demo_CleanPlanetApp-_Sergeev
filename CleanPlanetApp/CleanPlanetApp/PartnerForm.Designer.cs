namespace CleanPlanetApp
{
    partial class PartnerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Text = "Добавление партнера";
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            var mainPanel = new System.Windows.Forms.Panel();
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPanel.Padding = new System.Windows.Forms.Padding(20);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(224, 255, 255);

            var typeLabel = new System.Windows.Forms.Label();
            typeLabel.Text = "Тип партнера:";
            typeLabel.Location = new System.Drawing.Point(20, 20);
            typeLabel.AutoSize = true;

            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox.Location = new System.Drawing.Point(150, 17);
            this.typeComboBox.Size = new System.Drawing.Size(300, 25);
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            var nameLabel = new System.Windows.Forms.Label();
            nameLabel.Text = "Наименование:";
            nameLabel.Location = new System.Drawing.Point(20, 60);
            nameLabel.AutoSize = true;

            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox.Location = new System.Drawing.Point(150, 57);
            this.nameTextBox.Size = new System.Drawing.Size(300, 25);

            var directorLabel = new System.Windows.Forms.Label();
            directorLabel.Text = "Руководитель:";
            directorLabel.Location = new System.Drawing.Point(20, 100);
            directorLabel.AutoSize = true;

            this.directorTextBox = new System.Windows.Forms.TextBox();
            this.directorTextBox.Location = new System.Drawing.Point(150, 97);
            this.directorTextBox.Size = new System.Drawing.Size(300, 25);

            var emailLabel = new System.Windows.Forms.Label();
            emailLabel.Text = "Email:";
            emailLabel.Location = new System.Drawing.Point(20, 140);
            emailLabel.AutoSize = true;

            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox.Location = new System.Drawing.Point(150, 137);
            this.emailTextBox.Size = new System.Drawing.Size(300, 25);

            var phoneLabel = new System.Windows.Forms.Label();
            phoneLabel.Text = "Телефон:";
            phoneLabel.Location = new System.Drawing.Point(20, 180);
            phoneLabel.AutoSize = true;

            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox.Location = new System.Drawing.Point(150, 177);
            this.phoneTextBox.Size = new System.Drawing.Size(300, 25);

            var addressLabel = new System.Windows.Forms.Label();
            addressLabel.Text = "Адрес:";
            addressLabel.Location = new System.Drawing.Point(20, 220);
            addressLabel.AutoSize = true;

            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox.Location = new System.Drawing.Point(150, 217);
            this.addressTextBox.Size = new System.Drawing.Size(300, 25);

            var innLabel = new System.Windows.Forms.Label();
            innLabel.Text = "ИНН:";
            innLabel.Location = new System.Drawing.Point(20, 260);
            innLabel.AutoSize = true;

            this.innTextBox = new System.Windows.Forms.TextBox();
            this.innTextBox.Location = new System.Drawing.Point(150, 257);
            this.innTextBox.Size = new System.Drawing.Size(300, 25);

            var ratingLabel = new System.Windows.Forms.Label();
            ratingLabel.Text = "Рейтинг:";
            ratingLabel.Location = new System.Drawing.Point(20, 300);
            ratingLabel.AutoSize = true;

            this.ratingNumeric = new System.Windows.Forms.NumericUpDown();
            this.ratingNumeric.Location = new System.Drawing.Point(150, 297);
            this.ratingNumeric.Size = new System.Drawing.Size(100, 25);
            this.ratingNumeric.Minimum = 0;
            this.ratingNumeric.Maximum = 10;

            this.saveButton = new System.Windows.Forms.Button();
            this.saveButton.Text = "Сохранить";
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(0, 206, 209);
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Size = new System.Drawing.Size(100, 35);
            this.saveButton.Location = new System.Drawing.Point(250, 350);
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);

            this.cancelButton = new System.Windows.Forms.Button();
            this.cancelButton.Text = "Отмена";
            this.cancelButton.Size = new System.Drawing.Size(100, 35);
            this.cancelButton.Location = new System.Drawing.Point(360, 350);
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);

            mainPanel.Controls.AddRange(new System.Windows.Forms.Control[] {
                typeLabel, this.typeComboBox,
                nameLabel, this.nameTextBox,
                directorLabel, this.directorTextBox,
                emailLabel, this.emailTextBox,
                phoneLabel, this.phoneTextBox,
                addressLabel, this.addressTextBox,
                innLabel, this.innTextBox,
                ratingLabel, this.ratingNumeric,
                this.saveButton, this.cancelButton
            });

            this.Controls.Add(mainPanel);
        }
    }
}