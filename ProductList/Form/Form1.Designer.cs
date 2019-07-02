
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddProductButton = new System.Windows.Forms.Button();
            this.FindTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FindButton = new System.Windows.Forms.Button();
            this.ProductNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductPriceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ProductPositionNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.productsPanel = new System.Windows.Forms.Panel();
            this.PreviousPageButton = new System.Windows.Forms.Button();
            this.NextPageButton = new System.Windows.Forms.Button();
            this.PageInfoLabel = new System.Windows.Forms.Label();
            this.ProductPositionInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddProductButton
            // 
            this.AddProductButton.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddProductButton.Location = new System.Drawing.Point(12, 12);
            this.AddProductButton.Name = "AddProductButton";
            this.AddProductButton.Size = new System.Drawing.Size(206, 43);
            this.AddProductButton.TabIndex = 4;
            this.AddProductButton.Text = "Добавить товар";
            this.AddProductButton.UseVisualStyleBackColor = true;
            this.AddProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // FindTextBox
            // 
            this.FindTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindTextBox.Location = new System.Drawing.Point(12, 95);
            this.FindTextBox.Name = "FindTextBox";
            this.FindTextBox.Size = new System.Drawing.Size(620, 31);
            this.FindTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Поиск по номеру позиции";
            // 
            // FindButton
            // 
            this.FindButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FindButton.Location = new System.Drawing.Point(638, 95);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(150, 31);
            this.FindButton.TabIndex = 6;
            this.FindButton.Text = "Найти";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // ProductNameTextBox
            // 
            this.ProductNameTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductNameTextBox.Location = new System.Drawing.Point(278, 28);
            this.ProductNameTextBox.Name = "ProductNameTextBox";
            this.ProductNameTextBox.Size = new System.Drawing.Size(354, 26);
            this.ProductNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(275, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Название товара";
            // 
            // ProductPriceTextBox
            // 
            this.ProductPriceTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductPriceTextBox.Location = new System.Drawing.Point(638, 28);
            this.ProductPriceTextBox.Name = "ProductPriceTextBox";
            this.ProductPriceTextBox.Size = new System.Drawing.Size(150, 26);
            this.ProductPriceTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(635, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Цена";
            // 
            // ProductPositionNumberTextBox
            // 
            this.ProductPositionNumberTextBox.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductPositionNumberTextBox.Location = new System.Drawing.Point(224, 28);
            this.ProductPositionNumberTextBox.Name = "ProductPositionNumberTextBox";
            this.ProductPositionNumberTextBox.Size = new System.Drawing.Size(48, 26);
            this.ProductPositionNumberTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(221, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Номер";
            // 
            // productsPanel
            // 
            this.productsPanel.AutoScroll = true;
            this.productsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.productsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productsPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.productsPanel.Location = new System.Drawing.Point(12, 132);
            this.productsPanel.Name = "productsPanel";
            this.productsPanel.Size = new System.Drawing.Size(776, 450);
            this.productsPanel.TabIndex = 11;
            // 
            // PreviousPageButton
            // 
            this.PreviousPageButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousPageButton.Location = new System.Drawing.Point(11, 588);
            this.PreviousPageButton.Name = "PreviousPageButton";
            this.PreviousPageButton.Size = new System.Drawing.Size(243, 31);
            this.PreviousPageButton.TabIndex = 12;
            this.PreviousPageButton.Text = "Предыдущая страница";
            this.PreviousPageButton.UseVisualStyleBackColor = true;
            this.PreviousPageButton.Click += new System.EventHandler(this.PreviousPageButton_Click);
            // 
            // NextPageButton
            // 
            this.NextPageButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextPageButton.Location = new System.Drawing.Point(261, 588);
            this.NextPageButton.Name = "NextPageButton";
            this.NextPageButton.Size = new System.Drawing.Size(243, 31);
            this.NextPageButton.TabIndex = 13;
            this.NextPageButton.Text = "Следующая страница";
            this.NextPageButton.UseVisualStyleBackColor = true;
            this.NextPageButton.Click += new System.EventHandler(this.NextPageButton_Click);
            // 
            // PageInfoLabel
            // 
            this.PageInfoLabel.AutoSize = true;
            this.PageInfoLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageInfoLabel.Location = new System.Drawing.Point(510, 585);
            this.PageInfoLabel.Name = "PageInfoLabel";
            this.PageInfoLabel.Size = new System.Drawing.Size(0, 17);
            this.PageInfoLabel.TabIndex = 14;
            // 
            // ProductPositionInfoLabel
            // 
            this.ProductPositionInfoLabel.AutoSize = true;
            this.ProductPositionInfoLabel.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ProductPositionInfoLabel.Location = new System.Drawing.Point(510, 603);
            this.ProductPositionInfoLabel.Name = "ProductPositionInfoLabel";
            this.ProductPositionInfoLabel.Size = new System.Drawing.Size(0, 17);
            this.ProductPositionInfoLabel.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 625);
            this.Controls.Add(this.ProductPositionInfoLabel);
            this.Controls.Add(this.PageInfoLabel);
            this.Controls.Add(this.NextPageButton);
            this.Controls.Add(this.PreviousPageButton);
            this.Controls.Add(this.productsPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProductPositionNumberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ProductPriceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProductNameTextBox);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FindTextBox);
            this.Controls.Add(this.AddProductButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(816, 664);
            this.MinimumSize = new System.Drawing.Size(816, 664);
            this.Name = "Form1";
            this.Text = "База товаров";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddProductButton;
        private System.Windows.Forms.TextBox FindTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.TextBox ProductNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ProductPriceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ProductPositionNumberTextBox;
        private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Panel productsPanel;
    private System.Windows.Forms.Button PreviousPageButton;
    private System.Windows.Forms.Button NextPageButton;
    private System.Windows.Forms.Label PageInfoLabel;
    private System.Windows.Forms.Label ProductPositionInfoLabel;
}

