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
            this.checkBoxItalic = new System.Windows.Forms.CheckBox();
            this.checkBoxUnderline = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBoxColorIndicator = new System.Windows.Forms.PictureBox();
            this.buttonChooseColor = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.BackColor = System.Drawing.SystemColors.Control;
            this.comboBoxFont.Cursor = System.Windows.Forms.Cursors.Arrow;
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
            this.numericUpDownFontSize.Location = new System.Drawing.Point(336, 30);
            this.numericUpDownFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFontSize.MinimumSize = new System.Drawing.Size(100, 0);
            this.numericUpDownFontSize.Name = "numericUpDownFontSize";
            this.numericUpDownFontSize.Size = new System.Drawing.Size(100, 32);
            this.numericUpDownFontSize.TabIndex = 1;
            this.numericUpDownFontSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFontSize.ValueChanged += new System.EventHandler(this.numericUpDownFontSize_ValueChanged);
            this.numericUpDownFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownFontSize_KeyPress);
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
            // checkBoxItalic
            // 
            this.checkBoxItalic.Appearance = System.Windows.Forms.Appearance.Button;
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
            // checkBoxUnderline
            // 
            this.checkBoxUnderline.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxUnderline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUnderline.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.checkBoxUnderline.FlatAppearance.BorderSize = 2;
            this.checkBoxUnderline.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxUnderline.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGreen;
            this.checkBoxUnderline.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.checkBoxUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUnderline.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxUnderline.Location = new System.Drawing.Point(323, 90);
            this.checkBoxUnderline.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxUnderline.MinimumSize = new System.Drawing.Size(200, 50);
            this.checkBoxUnderline.Name = "checkBoxUnderline";
            this.checkBoxUnderline.Size = new System.Drawing.Size(220, 50);
            this.checkBoxUnderline.TabIndex = 10;
            this.checkBoxUnderline.Text = "Подчеркнутый";
            this.checkBoxUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUnderline.UseVisualStyleBackColor = true;
            this.checkBoxUnderline.CheckedChanged += new System.EventHandler(this.checkBoxUnderline_CheckedChanged);
            // 
            // pictureBoxColorIndicator
            // 
            this.pictureBoxColorIndicator.Location = new System.Drawing.Point(476, 30);
            this.pictureBoxColorIndicator.Name = "pictureBoxColorIndicator";
            this.pictureBoxColorIndicator.Size = new System.Drawing.Size(47, 47);
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
            this.buttonChooseColor.Location = new System.Drawing.Point(476, 30);
            this.buttonChooseColor.Name = "buttonChooseColor";
            this.buttonChooseColor.Size = new System.Drawing.Size(47, 47);
            this.buttonChooseColor.TabIndex = 8;
            this.buttonChooseColor.UseVisualStyleBackColor = false;
            this.buttonChooseColor.Click += new System.EventHandler(this.buttonChooseColor_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AcceptsTab = true;
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(20, 272);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(888, 254);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(23, 183);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(140, 48);
            this.buttonOpenFile.TabIndex = 14;
            this.buttonOpenFile.Text = "Открыть файл";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(183, 183);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(178, 48);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Сохранить в файл";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(621, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(928, 546);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.checkBoxUnderline);
            this.Controls.Add(this.buttonChooseColor);
            this.Controls.Add(this.pictureBoxColorIndicator);
            this.Controls.Add(this.checkBoxItalic);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBoxBold);
            this.Controls.Add(this.numericUpDownFontSize);
            this.Controls.Add(this.comboBoxFont);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Текстовый редактор";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxColorIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.NumericUpDown numericUpDownFontSize;
        private System.Windows.Forms.CheckBox checkBoxBold;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.CheckBox checkBoxItalic;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.PictureBox pictureBoxColorIndicator;
        private System.Windows.Forms.Button buttonChooseColor;
        private System.Windows.Forms.CheckBox checkBoxUnderline;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

