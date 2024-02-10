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
using M = Microsoft.Office.Interop.Word;


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
                Filter = "Word Document (*.docx)|*.docx",
                DefaultExt = "docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveRichTextContentToWordDoc(saveFileDialog.FileName);
            }
        }

        private void buttonLoadText_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Word Document (*.docx)|*.docx",
                DefaultExt = "docx"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadWordDocToRichTextBox(openFileDialog.FileName);
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

        private void SaveRichTextContentToWordDoc(string filePath)
        {
            var wordApp = new M.Application();
            M.Document doc = null;

            try
            {
                doc = wordApp.Documents.Add();
                wordApp.Visible = false; // Не показываем документ пользователю во время сохранения

                // Проходимся по всему тексту RichTextBox и сохраняем форматирование
                for (int i = 0; i < richTextBox1.TextLength; i++)
                {
                    richTextBox1.Select(i, 1);
                    string selectedText = richTextBox1.SelectedText;
                    System.Drawing.Font font = richTextBox1.SelectionFont;
                    System.Drawing.Color textColor = richTextBox1.SelectionColor;

                    M.Range range = doc.Range(doc.Content.End - 1);

                    // Добавляем текст в документ
                    range.Text = selectedText;

                    // Применяем шрифт и размер
                    range.Font.Name = font.Name;
                    range.Font.Size = font.Size;

                    // Применяем стили жирного и курсивного текста
                    range.Font.Bold = font.Bold ? 1 : 0;
                    range.Font.Italic = font.Italic ? 1 : 0;

                    // Устанавливаем цвет текста
                    int colorRgb = (textColor.R + 0x100 * textColor.G + 0x10000 * textColor.B);
                    range.Font.Color = (M.WdColor)(colorRgb);

                    // Если нужно применить другие стили, добавьте их здесь
                }

                // Сохраняем документ
                doc.SaveAs2(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                // Закрываем документ и Word, освобождаем ресурсы
                if (doc != null)
                {
                    doc.Close(M.WdSaveOptions.wdDoNotSaveChanges);
                    Marshal.ReleaseComObject(doc);
                }
                wordApp.Quit(M.WdSaveOptions.wdDoNotSaveChanges);
                Marshal.ReleaseComObject(wordApp);
            }
        }

        private void LoadWordDocToRichTextBox(string filePath)
        {
            var wordApp = new M.Application();
            M.Document doc = null;

            try
            {
                // Открываем документ только для чтения
                doc = wordApp.Documents.Open(filePath, ReadOnly: true);
                wordApp.Visible = false;

                // Копируем содержимое в буфер обмена
                doc.Content.Select();
                doc.Content.Copy();

                // Вставляем содержимое буфера обмена в RichTextBox
                richTextBox1.Paste();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файла Word: " + ex.Message);
            }
            finally
            {
                // Закрываем Word и освобождаем ресурсы
                if (doc != null)
                {
                    doc.Close(M.WdSaveOptions.wdDoNotSaveChanges);
                    Marshal.ReleaseComObject(doc);
                }
                wordApp.Quit(M.WdSaveOptions.wdDoNotSaveChanges);
                Marshal.ReleaseComObject(wordApp);
                Clipboard.Clear(); // Очистка буфера обмена
            }
        }


    }
}
