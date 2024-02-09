using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }

            // Установка шрифта по умолчанию для RichTextBox
            richTextBox1.Font = new Font("Times New Roman", 14);

            // Выбор шрифта по умолчанию в ComboBox
            comboBoxFont.SelectedItem = "Times New Roman";

            // Установка размера шрифта по умолчанию в NumericUpDown
            numericUpDownFontSize.Value = 14;

            pictureBoxColorIndicator.BackColor = Color.Black;

            buttonChooseColor.BackColor = pictureBoxColorIndicator.BackColor;
        }


        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Применение шрифта только к выделенному тексту
            ApplyFontToSelectedText();
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            // Применение размера шрифта только к выделенному тексту
            ApplyFontToSelectedText();
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            // Применение жирного стиля только к выделенному тексту
            ApplyFontStyleToSelectedText(FontStyle.Bold, checkBoxBold.Checked);
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            // Применение курсивного стиля только к выделенному тексту
            ApplyFontStyleToSelectedText(FontStyle.Italic, checkBoxItalic.Checked);
        }

        private void ApplyFontToSelectedText()
        {
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
            {
                Font currentFont = richTextBox1.SelectionFont;
                float fontSize = currentFont != null ? currentFont.Size : richTextBox1.Font.Size;
                string fontName = comboBoxFont.SelectedItem.ToString();

                // Если размер шрифта изменился
                if (numericUpDownFontSize.Focused)
                {
                    fontSize = (float)numericUpDownFontSize.Value;
                }

                // Если имя шрифта изменилось
                if (comboBoxFont.Focused)
                {
                    fontName = comboBoxFont.SelectedItem.ToString();
                }

                richTextBox1.SelectionFont = new Font(fontName, fontSize, currentFont != null ? currentFont.Style : richTextBox1.Font.Style);
            }
        }

        private void ApplyFontStyleToSelectedText(FontStyle style, bool enabled)
        {
            if (!string.IsNullOrEmpty(richTextBox1.SelectedText) && richTextBox1.SelectionFont != null)
            {
                FontStyle currentStyle = richTextBox1.SelectionFont.Style;
                currentStyle = enabled ? currentStyle | style : currentStyle & ~style;

                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, currentStyle);
            }
        }

        private void buttonSaveText_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*",
                DefaultExt = "rtf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void buttonLoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*",
                DefaultExt = "rtf"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }


        private void buttonChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Установить начальный цвет в ColorDialog, равный текущему цвету индикатора
                colorDialog.Color = pictureBoxColorIndicator.BackColor;

                // Показать диалог выбора цвета
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Изменить фон pictureBoxColorIndicator на выбранный цвет
                    pictureBoxColorIndicator.BackColor = colorDialog.Color;

                    buttonChooseColor.BackColor = pictureBoxColorIndicator.BackColor;

                    // Применить выбранный цвет к выделенному тексту
                    if (!string.IsNullOrEmpty(richTextBox1.SelectedText))
                    {
                        richTextBox1.SelectionColor = colorDialog.Color;
                    }
                }
            }
        }

    }
}
