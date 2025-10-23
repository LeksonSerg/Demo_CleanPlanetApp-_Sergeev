namespace CleanPlanetApp
{
    partial class ServicesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button closeButton;

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
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Text = "Услуги и себестоимость";
            this.BackColor = System.Drawing.Color.White;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            var mainPanel = new System.Windows.Forms.Panel();
            mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainPanel.Padding = new System.Windows.Forms.Padding(20);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(224, 255, 255);

            var titleLabel = new System.Windows.Forms.Label();
            titleLabel.Text = "Услуги и расчет себестоимости";
            titleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 14, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.FromArgb(0, 206, 209);
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(20, 20);

            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridView.Location = new System.Drawing.Point(20, 60);
            this.dataGridView.Size = new System.Drawing.Size(840, 350);
            this.dataGridView.BackColor = System.Drawing.Color.White;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ReadOnly = true;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.RowHeadersVisible = false;

            this.dataGridView.Columns.Add("ServiceCode", "Код услуги");
            this.dataGridView.Columns.Add("ServiceName", "Наименование услуги");
            this.dataGridView.Columns.Add("ServiceTypeName", "Тип услуги");
            this.dataGridView.Columns.Add("MinimalCost", "Мин. стоимость");
            this.dataGridView.Columns.Add("CalculatedCost", "Себестоимость");

            this.closeButton = new System.Windows.Forms.Button();
            this.closeButton.Text = "Закрыть";
            this.closeButton.Size = new System.Drawing.Size(100, 35);
            this.closeButton.Location = new System.Drawing.Point(760, 420);
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);

            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(this.dataGridView);
            mainPanel.Controls.Add(this.closeButton);

            this.Controls.Add(mainPanel);
        }
    }
}