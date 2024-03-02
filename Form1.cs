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

        private string currentFilePath;


        public Form1()
        {
            InitializeComponent();

            buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            buttonSave.Click += new EventHandler(buttonSaveText_Click);
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
        { if (checkBoxBold.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("BoldChanged"); 
           
        }

        private void checkBoxItalic_CheckedChanged(object sender, EventArgs e)
        {if (checkBoxItalic.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("ItalicChanged"); 
            
        }

        private void checkBoxUnderline_CheckedChanged(object sender, EventArgs e)
        { if (checkBoxUnderline.Focused)
            {
                ApplyTextStyle();
            }
            UpdatePreview("UnderlineChanged");
           
        }

        private void ApplyTextStyle()
        {
            // Убедимся, что есть выбранный шрифт, прежде чем пытаться применить стиль
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = FontStyle.Regular;

                if (checkBoxBold.Checked)
                    style |= FontStyle.Bold;

                if (checkBoxItalic.Checked)
                    style |= FontStyle.Italic;

                if (checkBoxUnderline.Checked)
                    style |= FontStyle.Underline;

                // Сохраняем текущий шрифт и размер
                Font currentFont = richTextBox1.SelectionFont;
                float currentSize = currentFont.Size;
                FontFamily currentFamily = currentFont.FontFamily;

                // Применяем новый стиль, сохраняя все остальные атрибуты шрифта
                richTextBox1.SelectionFont = new Font(currentFamily, currentSize, style);

                // Восстановим цвет, если он был изменен
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



        private void buttonSaveText_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(currentFilePath))
                {

                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    buttonSaveAsNew_Click(sender, e);
                    currentFilePath = null;
                }
                else
                {
                    buttonSaveAsNew_Click(sender, e);
                    currentFilePath = null;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Отказано в доступе к файлу: {ex.Message}", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)


        {

            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "RTF files (*.rtf)|*.rtf";
                    openFileDialog.RestoreDirectory = true;

                    try
                    {
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            currentFilePath = openFileDialog.FileName;
                            richTextBox1.LoadFile(currentFilePath, RichTextBoxStreamType.RichText); 
                            AnalyzeAndAddStylesToComboBox(); // Вызов функции анализа стилей

                        }
                        else
                        {
                            currentFilePath = null;
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        // Вывести сообщение пользователю, что доступ запрещен
                        MessageBox.Show($"Доступ запрещен. {ex.Message}", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка открытия файла 123: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Вывести сообщение пользователю, что доступ запрещен
                MessageBox.Show($"Доступ запрещен. {ex.Message}", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonSaveAsNew_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "RTF files (*.rtf)|*.rtf";
                    saveFileDialog.RestoreDirectory = true;

                    try
                    {
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            currentFilePath = saveFileDialog.FileName;
                            richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                            currentFilePath = null;
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show($"Отказано в доступе при попытке сохранения файла: {ex.Message}", "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения как нового файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show($"Ошибка доступа к файлу: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла неизвестная ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        // Этот метод анализирует текст в RichTextBox и извлекает уникальные стили
        private void AnalyzeAndAddStylesToComboBox()
        {
            comboBox1.Items.Clear(); // Очистить comboBox перед добавлением новых стилей
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

            comboBox1.DisplayMember = "Name"; // Устанавливаем отображаемое имя
            richTextBox1.Select(0, 0); // Сбросить выделение
        }

       


        // Этот метод возвращает строковое описание стиля для данного шрифта и цвета
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


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is TextStyle selectedStyle)
            {
                // Применить стиль к выделенному тексту
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectionFont = selectedStyle.Font;
                    richTextBox1.SelectionColor = selectedStyle.Color;
                }
                else
                {
                    // Если текст не выделен, установить стиль для нового текста
                    richTextBox1.Font = selectedStyle.Font;
                    richTextBox1.ForeColor = selectedStyle.Color;
                }
            }
        }

        private void UpdateUIWithCurrentTextStyle()
        {
            // Отключаем обработку событий изменения для контролов, чтобы избежать рекурсивного вызова
            comboBoxFont.SelectedIndexChanged -= comboBoxFont_SelectedIndexChanged;
            numericUpDownFontSize.ValueChanged -= numericUpDownFontSize_ValueChanged;
            checkBoxBold.CheckedChanged -= checkBoxBold_CheckedChanged;
            checkBoxItalic.CheckedChanged -= checkBoxItalic_CheckedChanged;
            checkBoxUnderline.CheckedChanged -= checkBoxUnderline_CheckedChanged;

            // Сохраняем текущее положение курсора
            int selectionStart = richTextBox1.SelectionStart;

            // Если курсор не в начале текста, получаем стили предыдущего символа
            if (selectionStart > 0)
            {
                // Получаем стиль символа непосредственно перед текущей позицией курсора
                Font currentFont = richTextBox1.SelectionFont;
                Color currentColor = richTextBox1.SelectionColor;

                // Обновляем элементы управления
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

            // Включаем обратно обработку событий изменения для контролов
            comboBoxFont.SelectedIndexChanged += comboBoxFont_SelectedIndexChanged;
            numericUpDownFontSize.ValueChanged += numericUpDownFontSize_ValueChanged;
            checkBoxBold.CheckedChanged += checkBoxBold_CheckedChanged;
            checkBoxItalic.CheckedChanged += checkBoxItalic_CheckedChanged;
            checkBoxUnderline.CheckedChanged += checkBoxUnderline_CheckedChanged;
        }



    }


}
