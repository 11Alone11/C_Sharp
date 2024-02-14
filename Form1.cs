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
using System.Runtime.InteropServices;


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
            richTextBox1.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            comboBoxFont.SelectedItem = "Times New Roman";
            numericUpDownFontSize.Value = 14;
            pictureBoxColorIndicator.BackColor = Color.Black;
            buttonChooseColor.BackColor = pictureBoxColorIndicator.BackColor;
        }

        private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePreview("FontChanged");
        }

        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            UpdatePreview("SizeChanged");
        }

        private void numericUpDownFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(numericUpDownFontSize.Text.Length - 1 > 1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }
            if (int.TryParse(e.KeyChar.ToString(), out int newValue))
            {
                if (newValue < 1 || newValue > 100)
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                e.Handled = true;
                return;
            }
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview("BoldChanged");
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview("ItalicChanged"); 
        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePreview("UnderlineChanged");
        }

        private void UpdatePreview(String Message)
        {
            string selectedText = richTextBox1.SelectedText;
            int selectionStart = richTextBox1.SelectionStart;
            int selectionLength = richTextBox1.SelectionLength;
            
                switch (Message)
                {
                    case "FontChanged":
                        {
                            richTextBox1.SelectionFont = new System.Drawing.Font(
                            comboBoxFont.SelectedItem.ToString(),
                            richTextBox1.SelectionFont?.Size ?? richTextBox1.Font.Size,
                            richTextBox1.SelectionFont?.Style ?? FontStyle.Regular);
                            break;
                        }
                    case "SizeChanged":
                        {
                            if (richTextBox1.SelectionLength > 0)
                            {
                                int selectionEnd = selectionStart + richTextBox1.SelectionLength;

                                for (int i = selectionStart; i < selectionEnd; i++)
                                {
                                    richTextBox1.Select(i, 1);
                                    richTextBox1.SelectionFont = new System.Drawing.Font(
                                    richTextBox1.SelectionFont.FontFamily,
                                    (float)numericUpDownFontSize.Value,
                                    richTextBox1.SelectionFont.Style);
                                }

                                richTextBox1.Select(selectionStart, richTextBox1.SelectionLength);
                            }
                            break;
                        }
                    case "BoldChanged":
                        {
                            if (richTextBox1.SelectionLength > 0)
                            {
                                int selectionEnd = selectionStart + richTextBox1.SelectionLength;

                                for (int i = selectionStart; i < selectionEnd; i++)
                                {
                                richTextBox1.Select(i, 1);

                                    FontStyle currentStyle = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

                                    if (checkBoxBold.Checked)
                                    {
                                        currentStyle |= FontStyle.Bold;
                                    }
                                    else
                                    {
                                        currentStyle &= ~FontStyle.Bold;
                                    }

                                    System.Drawing.Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
                                    System.Drawing.Font newFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, currentStyle);
                                richTextBox1.SelectionFont = newFont;
                                }

                            richTextBox1.Select(selectionStart, selectionLength);
                            }
                            break;
                        }
                    case "ItalicChanged":
                        {
                            if (richTextBox1.SelectionLength > 0)
                            {
                                int selectionEnd = selectionStart + richTextBox1.SelectionLength;

                                for (int i = selectionStart; i < selectionEnd; i++)
                                {
                                richTextBox1.Select(i, 1);

                                    FontStyle currentStyle = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

                                    if (checkBoxItalic.Checked)
                                    {
                                        currentStyle |= FontStyle.Italic;
                                    }
                                    else
                                    {
                                        currentStyle &= ~FontStyle.Italic;
                                    }

                                    System.Drawing.Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
                                    System.Drawing.Font newFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, currentStyle);
                                richTextBox1.SelectionFont = newFont;
                                }

                            richTextBox1.Select(selectionStart, selectionLength);
                            }
                            break;
                        }
                    case "UnderlineChanged":
                    {
                        if (richTextBox1.SelectionLength > 0)
                        {
                            int selectionEnd = selectionStart + richTextBox1.SelectionLength;

                            for (int i = selectionStart; i < selectionEnd; i++)
                            {
                                richTextBox1.Select(i, 1);

                                FontStyle currentStyle = richTextBox1.SelectionFont?.Style ?? FontStyle.Regular;

                                if (checkBoxUnderline.Checked)
                                {
                                    currentStyle |= FontStyle.Underline;
                                }
                                else
                                {
                                    currentStyle &= ~FontStyle.Underline;
                                }

                                System.Drawing.Font currentFont = richTextBox1.SelectionFont ?? richTextBox1.Font;
                                System.Drawing.Font newFont = new System.Drawing.Font(currentFont.FontFamily, currentFont.Size, currentStyle);
                                richTextBox1.SelectionFont = newFont;
                            }

                            richTextBox1.Select(selectionStart, selectionLength);
                        }
                        break;
                    }
                    default:
                        {
                            break;
                        }
                }

            richTextBox1.Select(selectionStart, selectionLength);
            richTextBox1.Focus();
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
                 
                    richTextBox1.SelectionColor = colorDialog.Color;
                  
                }
            }
        }

    }
}
