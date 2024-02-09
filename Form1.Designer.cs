namespace WindowsFormsApp1
{
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
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.numericUpDownFontSize = new System.Windows.Forms.NumericUpDown();
            this.checkBoxBold = new System.Windows.Forms.CheckBox();
            this.buttonSaveText = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBoxItalic = new System.Windows.Forms.CheckBox();
            this.buttonLoadText = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBoxColorIndicator = new System.Windows.Forms.PictureBox();
            this.buttonChooseColor = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxFont.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBoxFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxFont.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(23, 30);
            this.comboBoxFont.Margin = new System.Windows.Forms.Padding(10);
            this.comboBoxFont.MaximumSize = new System.Drawing.Size(1000, 0);
            this.comboBoxFont.MinimumSize = new System.Drawing.Size(300, 0);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(300, 34);
            this.comboBoxFont.TabIndex = 0;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxFont_SelectedIndexChanged);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownFontSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDownFontSize.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.numericUpDownFontSize.Location = new System.Drawing.Point(336, 31);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(95, 32);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxBold.BackColor = System.Drawing.Color.White;
            this.checkBoxBold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxBold.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.checkBoxBold.FlatAppearance.BorderSize = 2;
            this.checkBoxBold.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxBold.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxBold.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkBoxBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxBold.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxBold.Location = new System.Drawing.Point(23, 90);
            this.checkBoxBold.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxBold.MinimumSize = new System.Drawing.Size(140, 50);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(140, 50);
            this.checkBoxBold.TabIndex = 2;
            this.checkBoxBold.Text = "Жирный";
            this.checkBoxBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxBold.UseVisualStyleBackColor = false;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
            // 
            // buttonSaveText
            // 
            this.buttonSaveText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveText.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonSaveText.FlatAppearance.BorderSize = 2;
            this.buttonSaveText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSaveText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveText.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveText.Location = new System.Drawing.Point(665, 30);
            this.buttonSaveText.Margin = new System.Windows.Forms.Padding(10);
            this.buttonSaveText.MinimumSize = new System.Drawing.Size(240, 50);
            this.buttonSaveText.Name = "buttonSaveText";
            this.buttonSaveText.Size = new System.Drawing.Size(240, 50);
            this.buttonSaveText.TabIndex = 3;
            this.buttonSaveText.Text = "Сохранить текст";
            this.buttonSaveText.UseVisualStyleBackColor = true;
            this.buttonSaveText.Click += new System.EventHandler(this.buttonSaveText_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(23, 170);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(882, 353);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "Hello World";
            // 
            // checkBoxItalic
            // 
            this.checkBoxItalic.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxItalic.AutoSize = true;
            this.checkBoxItalic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxItalic.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.checkBoxItalic.FlatAppearance.BorderSize = 2;
            this.checkBoxItalic.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxItalic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxItalic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkBoxItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxItalic.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxItalic.Location = new System.Drawing.Point(183, 90);
            this.checkBoxItalic.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxItalic.MinimumSize = new System.Drawing.Size(120, 50);
            this.checkBoxItalic.Name = "checkBoxItalic";
            this.checkBoxItalic.Size = new System.Drawing.Size(120, 50);
            this.checkBoxItalic.TabIndex = 5;
            this.checkBoxItalic.Text = "Косой";
            this.checkBoxItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxItalic.UseVisualStyleBackColor = true;
            this.checkBoxItalic.CheckedChanged += new System.EventHandler(this.checkBoxItalic_CheckedChanged);
            // 
            // buttonLoadText
            // 
            this.buttonLoadText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoadText.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.buttonLoadText.FlatAppearance.BorderSize = 2;
            this.buttonLoadText.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonLoadText.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLoadText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadText.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.buttonLoadText.Location = new System.Drawing.Point(665, 100);
            this.buttonLoadText.Margin = new System.Windows.Forms.Padding(10);
            this.buttonLoadText.MinimumSize = new System.Drawing.Size(240, 50);
            this.buttonLoadText.Name = "buttonLoadText";
            this.buttonLoadText.Size = new System.Drawing.Size(240, 50);
            this.buttonLoadText.TabIndex = 6;
            this.buttonLoadText.Text = "Загрузить текст";
            this.buttonLoadText.UseVisualStyleBackColor = true;
            this.buttonLoadText.Click += new System.EventHandler(this.buttonLoadText_Click);
            // 
            // pictureBoxColorIndicator
            // 
            this.pictureBoxColorIndicator.Location = new System.Drawing.Point(456, 30);
            this.pictureBoxColorIndicator.Name = "pictureBoxColorIndicator";
            this.pictureBoxColorIndicator.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxColorIndicator.TabIndex = 7;
            this.pictureBoxColorIndicator.TabStop = false;
            // 
            // buttonChooseColor
            // 
            this.buttonChooseColor.BackColor = System.Drawing.Color.Transparent;
            this.buttonChooseColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChooseColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonChooseColor.FlatAppearance.BorderSize = 0;
            this.buttonChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChooseColor.Location = new System.Drawing.Point(456, 30);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(60, 60);
            this.buttonChooseColor.TabIndex = 8;
            this.buttonChooseColor.UseVisualStyleBackColor = false;
            this.buttonChooseColor.Click += new System.EventHandler(this.buttonChooseColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 546);
            this.Controls.Add(this.buttonChooseColor);
            this.Controls.Add(this.pictureBoxColorIndicator);
            this.Controls.Add(this.buttonLoadText);
            this.Controls.Add(this.checkBoxItalic);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonSaveText);
            this.Controls.Add(this.checkBoxBold);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFont);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текстовый редактор";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.Button buttonSaveText;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxItalic;
        private System.Windows.Forms.Button buttonLoadText;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBoxColorIndicator;
        private System.Windows.Forms.Button buttonChooseColor;
    }
}

