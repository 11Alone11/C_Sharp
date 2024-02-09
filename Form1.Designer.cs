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
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(28, 28);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(183, 28);
            this.comboBoxFont.TabIndex = 0;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxFont_SelectedIndexChanged);
            // 
            // numericUpDownFontSize
            // 
            this.numericUpDownFontSize.Location = new System.Drawing.Point(217, 29);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            // 
            // checkBoxBold
            // 
            this.checkBoxBold.AutoSize = true;
            this.checkBoxBold.Location = new System.Drawing.Point(28, 89);
            this.checkBoxBold.Name = "checkBoxBold";
            this.checkBoxBold.Size = new System.Drawing.Size(95, 24);
            this.checkBoxBold.TabIndex = 2;
            this.checkBoxBold.Text = "Жирный";
            this.checkBoxBold.UseVisualStyleBackColor = true;
            this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckedChanged);
            // 
            // buttonSaveText
            // 
            this.buttonSaveText.Location = new System.Drawing.Point(580, 26);
            this.buttonSaveText.Name = "buttonSaveText";
            this.buttonSaveText.Size = new System.Drawing.Size(168, 29);
            this.buttonSaveText.TabIndex = 3;
            this.buttonSaveText.Text = "Сохранить текст";
            this.buttonSaveText.UseVisualStyleBackColor = true;
            this.buttonSaveText.Click += new System.EventHandler(this.buttonSaveText_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(28, 139);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(720, 225);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // checkBoxItalic
            // 
            this.checkBoxItalic.AutoSize = true;
            this.checkBoxItalic.Location = new System.Drawing.Point(131, 89);
            this.checkBoxItalic.Name = "checkBoxItalic";
            this.checkBoxItalic.Size = new System.Drawing.Size(80, 24);
            this.checkBoxItalic.TabIndex = 5;
            this.checkBoxItalic.Text = "Косой";
            this.checkBoxItalic.UseVisualStyleBackColor = true;
            this.checkBoxItalic.CheckedChanged += new System.EventHandler(this.checkBoxItalic_CheckedChanged);
            // 
            // buttonLoadText
            // 
            this.buttonLoadText.Location = new System.Drawing.Point(580, 61);
            this.buttonLoadText.Name = "buttonLoadText";
            this.buttonLoadText.Size = new System.Drawing.Size(168, 29);
            this.buttonLoadText.TabIndex = 6;
            this.buttonLoadText.Text = "Загрузить текст";
            this.buttonLoadText.UseVisualStyleBackColor = true;
            this.buttonLoadText.Click += new System.EventHandler(this.buttonLoadText_Click);
            // 
            // pictureBoxColorIndicator
            // 
            this.pictureBoxColorIndicator.Location = new System.Drawing.Point(363, 26);
            this.pictureBoxColorIndicator.Name = "pictureBoxColorIndicator";
            this.pictureBoxColorIndicator.Size = new System.Drawing.Size(53, 53);
            this.pictureBoxColorIndicator.TabIndex = 7;
            this.pictureBoxColorIndicator.TabStop = false;
            // 
            // buttonChooseColor
            // 
            this.buttonChooseColor.BackColor = System.Drawing.Color.Transparent;
            this.buttonChooseColor.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonChooseColor.FlatAppearance.BorderSize = 0;
            this.buttonChooseColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChooseColor.Location = new System.Drawing.Point(363, 26);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(53, 53);
            this.buttonChooseColor.TabIndex = 8;
            this.buttonChooseColor.UseVisualStyleBackColor = false;
            this.buttonChooseColor.Click += new System.EventHandler(this.buttonChooseColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonChooseColor);
            this.Controls.Add(this.pictureBoxColorIndicator);
            this.Controls.Add(this.buttonLoadText);
            this.Controls.Add(this.checkBoxItalic);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonSaveText);
            this.Controls.Add(this.checkBoxBold);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFont);
            this.Name = "Form1";
            this.Text = "Form1";
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

