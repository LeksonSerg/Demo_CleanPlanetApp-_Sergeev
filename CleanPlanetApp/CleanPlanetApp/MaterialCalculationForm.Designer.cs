namespace CleanPlanetApp
{
    partial class MaterialCalculationForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox serviceTypeComboBox;
        private System.Windows.Forms.ComboBox materialTypeComboBox;
        private System.Windows.Forms.TextBox serviceCountTextBox;
        private System.Windows.Forms.TextBox serviceParametersTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label serviceTypeLabel;
        private System.Windows.Forms.Label materialTypeLabel;
        private System.Windows.Forms.Label serviceCountLabel;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Label parametersHint;

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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.serviceTypeLabel = new System.Windows.Forms.Label();
            this.serviceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.materialTypeLabel = new System.Windows.Forms.Label();
            this.materialTypeComboBox = new System.Windows.Forms.ComboBox();
            this.serviceCountLabel = new System.Windows.Forms.Label();
            this.serviceCountTextBox = new System.Windows.Forms.TextBox();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.serviceParametersTextBox = new System.Windows.Forms.TextBox();
            this.parametersHint = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.mainPanel.Controls.Add(this.titleLabel);
            this.mainPanel.Controls.Add(this.serviceTypeLabel);
            this.mainPanel.Controls.Add(this.serviceTypeComboBox);
            this.mainPanel.Controls.Add(this.materialTypeLabel);
            this.mainPanel.Controls.Add(this.materialTypeComboBox);
            this.mainPanel.Controls.Add(this.serviceCountLabel);
            this.mainPanel.Controls.Add(this.serviceCountTextBox);
            this.mainPanel.Controls.Add(this.parametersLabel);
            this.mainPanel.Controls.Add(this.serviceParametersTextBox);
            this.mainPanel.Controls.Add(this.parametersHint);
            this.mainPanel.Controls.Add(this.calculateButton);
            this.mainPanel.Controls.Add(this.closeButton);
            this.mainPanel.Controls.Add(this.resultLabel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(20);
            this.mainPanel.Size = new System.Drawing.Size(500, 400);
            this.mainPanel.TabIndex = 0;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.titleLabel.Location = new System.Drawing.Point(20, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(480, 30);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Расчет количества материала для услуги";
            // 
            // serviceTypeLabel
            // 
            this.serviceTypeLabel.AutoSize = true;
            this.serviceTypeLabel.Location = new System.Drawing.Point(20, 70);
            this.serviceTypeLabel.Name = "serviceTypeLabel";
            this.serviceTypeLabel.Size = new System.Drawing.Size(83, 16);
            this.serviceTypeLabel.TabIndex = 1;
            this.serviceTypeLabel.Text = "Тип услуги:";
            // 
            // serviceTypeComboBox
            // 
            this.serviceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceTypeComboBox.Location = new System.Drawing.Point(150, 67);
            this.serviceTypeComboBox.Name = "serviceTypeComboBox";
            this.serviceTypeComboBox.Size = new System.Drawing.Size(300, 24);
            this.serviceTypeComboBox.TabIndex = 2;
            // 
            // materialTypeLabel
            // 
            this.materialTypeLabel.AutoSize = true;
            this.materialTypeLabel.Location = new System.Drawing.Point(20, 110);
            this.materialTypeLabel.Name = "materialTypeLabel";
            this.materialTypeLabel.Size = new System.Drawing.Size(110, 16);
            this.materialTypeLabel.TabIndex = 3;
            this.materialTypeLabel.Text = "Тип материала:";
            // 
            // materialTypeComboBox
            // 
            this.materialTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialTypeComboBox.Location = new System.Drawing.Point(150, 107);
            this.materialTypeComboBox.Name = "materialTypeComboBox";
            this.materialTypeComboBox.Size = new System.Drawing.Size(300, 24);
            this.materialTypeComboBox.TabIndex = 4;
            // 
            // serviceCountLabel
            // 
            this.serviceCountLabel.AutoSize = true;
            this.serviceCountLabel.Location = new System.Drawing.Point(20, 150);
            this.serviceCountLabel.Name = "serviceCountLabel";
            this.serviceCountLabel.Size = new System.Drawing.Size(128, 16);
            this.serviceCountLabel.TabIndex = 5;
            this.serviceCountLabel.Text = "Количество услуг:";
            // 
            // serviceCountTextBox
            // 
            this.serviceCountTextBox.Location = new System.Drawing.Point(158, 147);
            this.serviceCountTextBox.Name = "serviceCountTextBox";
            this.serviceCountTextBox.Size = new System.Drawing.Size(100, 22);
            this.serviceCountTextBox.TabIndex = 6;
            this.serviceCountTextBox.Text = "1";
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Location = new System.Drawing.Point(20, 190);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(133, 16);
            this.parametersLabel.TabIndex = 7;
            this.parametersLabel.Text = "Параметры услуги:";
            // 
            // serviceParametersTextBox
            // 
            this.serviceParametersTextBox.Location = new System.Drawing.Point(158, 187);
            this.serviceParametersTextBox.Name = "serviceParametersTextBox";
            this.serviceParametersTextBox.Size = new System.Drawing.Size(100, 22);
            this.serviceParametersTextBox.TabIndex = 8;
            this.serviceParametersTextBox.Text = "1.0";
            // 
            // parametersHint
            // 
            this.parametersHint.AutoSize = true;
            this.parametersHint.Font = new System.Drawing.Font("Arial", 8F);
            this.parametersHint.ForeColor = System.Drawing.Color.Gray;
            this.parametersHint.Location = new System.Drawing.Point(260, 190);
            this.parametersHint.Name = "parametersHint";
            this.parametersHint.Size = new System.Drawing.Size(197, 16);
            this.parametersHint.TabIndex = 9;
            this.parametersHint.Text = "(вес в кг, площадь в м² и т.д.)";
            // 
            // calculateButton
            // 
            this.calculateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(209)))));
            this.calculateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculateButton.ForeColor = System.Drawing.Color.White;
            this.calculateButton.Location = new System.Drawing.Point(150, 230);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(120, 35);
            this.calculateButton.TabIndex = 10;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.UseVisualStyleBackColor = false;
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Location = new System.Drawing.Point(280, 230);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(100, 35);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Закрыть";
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.resultLabel.ForeColor = System.Drawing.Color.Blue;
            this.resultLabel.Location = new System.Drawing.Point(20, 290);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(294, 19);
            this.resultLabel.TabIndex = 12;
            this.resultLabel.Text = "Результат расчета появится здесь";
            // 
            // MaterialCalculationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.mainPanel);
            this.Name = "MaterialCalculationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Расчет количества материала";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}