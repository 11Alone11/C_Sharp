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
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form


    {

        public static string releaseFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string fileNameAlertSave = "saved.rtf";
        public static string fileNameAlertSaveValidator = "valid.txt";
        public string currentFilePath = Path.Combine(releaseFolderPath, fileNameAlertSave);
        public string currentFilePathValidator = Path.Combine(releaseFolderPath, fileNameAlertSaveValidator);


        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            richTextBox1.SelectionChanged += new EventHandler(richTextBox1_SelectionChanged);
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                comboBoxFont.Items.Add(font.Name);
            }
            richTextBox1.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            comboBoxFont.SelectedItem = "Times New Roman";
            numericUpDownFontSize.Value = 14;
            pictureBoxColorIndicator.BackColor = Color.Black;
            buttonChooseColor.BackColor = pictureBoxColorIndicator.BackColor;

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
            this.FormClosing += Form1_FormClosing;
            this.Load += Form1_Load;
            richTextBox1.KeyPress += RichTextBox1_KeyPress;
            comboBox1.KeyPress += comboBox_KeyPress;
            comboBoxFont.KeyPress += comboBox_KeyPress;
        }

        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool error = false;
            try
            {
                richTextBox1.SaveFile(this.currentFilePath, RichTextBoxStreamType.RichText);
            }
            catch (UnauthorizedAccessException ex)
            {
                error = true;
                MessageBox.Show($"Отказано в доступе к файлу: {ex.Message}", "Файл аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Файл аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!error)
            {
                try
                {
                    string saveText = File.ReadAllText(this.currentFilePath);
                    File.WriteAllText(this.currentFilePathValidator, CalculateHash(saveText));
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Отказано в доступе к файлу: {ex.Message}", "Файл-валидатор аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Файл-валидатор аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string prevValid = null;
            string currentValid = null;
            bool error = false;
            try
            {
                if (File.Exists(this.currentFilePath))
                {
                    currentValid = File.ReadAllText(this.currentFilePath);
                    richTextBox1.LoadFile(this.currentFilePath, RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(this.currentFilePath))
                    {
                        sw.Close();
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                error = true;
                MessageBox.Show($"Доступ запрещен. {ex.Message}", "Файл аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Файл аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                if (File.Exists(this.currentFilePathValidator))
                {
                    prevValid = File.ReadAllText(this.currentFilePathValidator);
                }
                else
                {
                    using (StreamWriter sw = File.CreateText(this.currentFilePathValidator))
                    {
                        sw.Close();
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                error = true;
                MessageBox.Show($"Доступ запрещен. {ex.Message}", "Файл-валидатор аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Файл-валидатор аварийного сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (!error && prevValid != null && currentValid != null)
            {
                if (prevValid != CalculateHash(currentValid))
                {
                    MessageBox.Show($"Файл аварийного сохранения был изменен извне, возможны потери прогресса работы", "Внесистемные изменения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            AnalyzeAndAddStylesToComboBox();
        }

        private string CalculateHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }


        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateUIWithCurrentTextStyle();
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
            if (e.KeyChar == '\b')
            {
                if (numericUpDownFontSize.Text.Length > 0)
                {
                    numericUpDownFontSize.Text = numericUpDownFontSize.Text.Substring(0, numericUpDownFontSize.Text.Length - 1);
                    numericUpDownFontSize.Focus();
                    numericUpDownFontSize.Select(numericUpDownFontSize.Text.Length, 0);
                }
                e.Handled = true;
                return;
            }
            if (numericUpDownFontSize.Text.Length - 1 > 1)
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
            if (checkBoxBold.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("BoldChanged");

        }

        private void RichTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxItalic.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("ItalicChanged");

        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUnderline.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("UnderlineChanged");

        }

        private void ApplyTextStyle()
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = FontStyle.Regular;
                if (checkBoxBold.Checked)
                    style |= FontStyle.Bold;
                if (checkBoxItalic.Checked)
                    style |= FontStyle.Italic;
                if (checkBoxUnderline.Checked)
                    style |= FontStyle.Underline;
                Font currentFont = richTextBox1.SelectionFont;
                float currentSize = currentFont.Size;
                FontFamily currentFamily = currentFont.FontFamily;
                richTextBox1.SelectionFont = new Font(currentFamily, currentSize, style);
                richTextBox1.SelectionColor = richTextBox1.SelectionColor;
            }
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
                        float newSize = (float)numericUpDownFontSize.Value;

                        if (richTextBox1.SelectionLength > 0)
                        {
                            // Применить размер ко всему выделенному тексту
                            richTextBox1.SelectionFont = new Font(
                                richTextBox1.SelectionFont.FontFamily,
                                newSize,
                                richTextBox1.SelectionFont.Style);
                        }
                        else
                        {
                            // Проверка наличия символа слева от курсора
                            if (selectionStart > 0 && richTextBox1.Text.Length >= selectionStart)
                            {
                                // Выделить символ слева от курсора
                                richTextBox1.Select(selectionStart - 1, 1);

                                // Получить размер шрифта предыдущего символа
                                float previousFontSize = richTextBox1.SelectionFont.Size;

                                // Восстановить исходное положение курсора без выделения
                                richTextBox1.Select(selectionStart, 0);

                                // Применить новый размер шрифта
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, newSize, richTextBox1.Font.Style);
                            }
                            else
                            {
                                // Применить новый размер шрифта без изменения позиции курсора
                                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, newSize, richTextBox1.Font.Style);
                            }
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
                colorDialog.Color = pictureBoxColorIndicator.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxColorIndicator.BackColor = colorDialog.Color;
                    buttonChooseColor.BackColor = pictureBoxColorIndicator.BackColor;
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
            }
        }

        class TextStyle
        {
            public string Name { get; set; }
            public Font Font { get; set; }
            public Color Color { get; set; }

            public TextStyle(string name, Font font, Color color)
            {
                Name = name;
                Font = font;
                Color = color;
            }
        }

        private void AnalyzeAndAddStylesToComboBox()
        {
            comboBox1.Items.Clear();
            Dictionary<string, TextStyle> uniqueStyles = new Dictionary<string, TextStyle>();

            for (int i = 0; i < richTextBox1.TextLength; i++)
            {
                richTextBox1.Select(i, 1);
                Font font = richTextBox1.SelectionFont;
                Color color = richTextBox1.SelectionColor;
                string styleDescriptor = GetStyleDescription(font, color);

                if (!uniqueStyles.ContainsKey(styleDescriptor))
                {
                    string styleName = richTextBox1.SelectedText.Substring(0, Math.Min(5, richTextBox1.SelectedText.Length));
                    uniqueStyles.Add(styleDescriptor, new TextStyle(styleName, font, color));
                }
            }

            foreach (var style in uniqueStyles.Values)
            {
                comboBox1.Items.Add(style);
            }

            comboBox1.DisplayMember = "Name";
            richTextBox1.Select(0, 0);
        }

        private string GetStyleDescription(Font font, Color color)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(font.FontFamily.Name);
            sb.Append("-");
            sb.Append(font.Size);
            sb.Append("-");
            sb.Append(font.Bold ? "B" : "nB");
            sb.Append(font.Italic ? "I" : "nI");
            sb.Append(font.Underline ? "U" : "nU");
            sb.Append("-");
            sb.Append(color.ToArgb().ToString());

            return sb.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int pos = richTextBox1.SelectionStart;
            if (comboBox1.SelectedItem is TextStyle selectedStyle)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectionFont = selectedStyle.Font;
                    richTextBox1.SelectionColor = selectedStyle.Color;
                }
                else
                {
                    Font currentFont = selectedStyle.Font;
                    Color currentColor = selectedStyle.Color;
                    comboBoxFont.SelectedIndexChanged -= comboBoxFont_SelectedIndexChanged;
                    numericUpDownFontSize.ValueChanged -= numericUpDownFontSize_ValueChanged;
                    checkBoxBold.CheckedChanged -= checkBoxBold_CheckedChanged;
                    checkBoxItalic.CheckedChanged -= checkBoxItalic_CheckedChanged;
                    checkBoxUnderline.CheckedChanged -= checkBoxUnderline_CheckedChanged;
                    if (currentFont != null)
                    {
                        comboBoxFont.SelectedItem = currentFont.FontFamily.Name;
                        numericUpDownFontSize.Value = (decimal)currentFont.Size;
                        checkBoxBold.Checked = currentFont.Bold;
                        checkBoxItalic.Checked = currentFont.Italic;
                        checkBoxUnderline.Checked = currentFont.Underline;
                    }
                    pictureBoxColorIndicator.BackColor = currentColor;
                    buttonChooseColor.BackColor = currentColor;
                    comboBoxFont.SelectedIndexChanged += comboBoxFont_SelectedIndexChanged;
                    numericUpDownFontSize.ValueChanged += numericUpDownFontSize_ValueChanged;
                    checkBoxBold.CheckedChanged += checkBoxBold_CheckedChanged;
                    checkBoxItalic.CheckedChanged += checkBoxItalic_CheckedChanged;
                    checkBoxUnderline.CheckedChanged += checkBoxUnderline_CheckedChanged;

                }
            }
            richTextBox1.Select(pos, pos);
        }

        private void UpdateUIWithCurrentTextStyle()
        {
            comboBoxFont.SelectedIndexChanged -= comboBoxFont_SelectedIndexChanged;
            numericUpDownFontSize.ValueChanged -= numericUpDownFontSize_ValueChanged;
            checkBoxBold.CheckedChanged -= checkBoxBold_CheckedChanged;
            checkBoxItalic.CheckedChanged -= checkBoxItalic_CheckedChanged;
            checkBoxUnderline.CheckedChanged -= checkBoxUnderline_CheckedChanged;
            int selectionStart = richTextBox1.SelectionStart;
            if (selectionStart > 0)
            {
                Font currentFont = richTextBox1.SelectionFont;
                Color currentColor = richTextBox1.SelectionColor;
                if (currentFont != null)
                {
                    comboBoxFont.SelectedItem = currentFont.FontFamily.Name;
                    numericUpDownFontSize.Value = (decimal)currentFont.Size;
                    checkBoxBold.Checked = currentFont.Bold;
                    checkBoxItalic.Checked = currentFont.Italic;
                    checkBoxUnderline.Checked = currentFont.Underline;
                }
                pictureBoxColorIndicator.BackColor = currentColor;
                buttonChooseColor.BackColor = currentColor;
            }
            comboBoxFont.SelectedIndexChanged += comboBoxFont_SelectedIndexChanged;
            numericUpDownFontSize.ValueChanged += numericUpDownFontSize_ValueChanged;
            checkBoxBold.CheckedChanged += checkBoxBold_CheckedChanged;
            checkBoxItalic.CheckedChanged += checkBoxItalic_CheckedChanged;
            checkBoxUnderline.CheckedChanged += checkBoxUnderline_CheckedChanged;
        }



    }


}
