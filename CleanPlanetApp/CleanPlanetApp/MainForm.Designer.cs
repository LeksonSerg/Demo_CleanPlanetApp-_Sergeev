namespace CleanPlanetApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button materialCalculationButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button servicesCostButton;
        public System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button exitButton;

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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.materialCalculationButton = new System.Windows.Forms.Button();
            this.servicesCostButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Controls.Add(this.addButton);
            this.headerPanel.Controls.Add(this.materialCalculationButton);
            this.headerPanel.Controls.Add(this.servicesCostButton);
            this.headerPanel.Controls.Add(this.exitButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1381, 100);
            this.headerPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 16F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.titleLabel.Location = new System.Drawing.Point(148, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(505, 34);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Партнеры компании \'Чистая Планета\'";
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new System.Drawing.Point(20, 10);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(80, 80);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.Location = new System.Drawing.Point(1239, 31);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(118, 35);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Добавить партнера";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // materialCalculationButton
            // 
            this.materialCalculationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.materialCalculationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.materialCalculationButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.materialCalculationButton.ForeColor = System.Drawing.Color.White;
            this.materialCalculationButton.Location = new System.Drawing.Point(889, 31);
            this.materialCalculationButton.Name = "materialCalculationButton";
            this.materialCalculationButton.Size = new System.Drawing.Size(108, 35);
            this.materialCalculationButton.TabIndex = 3;
            this.materialCalculationButton.Text = "Расчет материала";
            this.materialCalculationButton.UseVisualStyleBackColor = false;
            this.materialCalculationButton.Click += new System.EventHandler(this.MaterialCalculationButton_Click);
            // 
            // servicesCostButton
            // 
            this.servicesCostButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.servicesCostButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.servicesCostButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.servicesCostButton.ForeColor = System.Drawing.Color.White;
            this.servicesCostButton.Location = new System.Drawing.Point(1003, 31);
            this.servicesCostButton.Name = "servicesCostButton";
            this.servicesCostButton.Size = new System.Drawing.Size(221, 35);
            this.servicesCostButton.TabIndex = 3;
            this.servicesCostButton.Text = "Услуги и себестоимость";
            this.servicesCostButton.UseVisualStyleBackColor = false;
            this.servicesCostButton.Click += new System.EventHandler(this.ServicesCostButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(20)))), ((int)(((byte)(60)))));
            this.exitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Location = new System.Drawing.Point(783, 31);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(100, 35);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel.Size = new System.Drawing.Size(1381, 600);
            this.flowLayoutPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1381, 700);
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чистая Планета - Партнеры";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }
    }
}