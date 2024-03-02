using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
     
        private string connectionString = @"Provider=MSOLEDBSQL;Data Source=DESKTOP-9A2HM9B\MSSERVER2024;Initial Catalog=MyDatabase;Integrated Security=SSPI;";


        public Form1()
        {
            InitializeComponent();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT ID, Name FROM Users", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (OleDbException ex)
                {
                    // Обработка ошибок, связанных с подключением к базе данных
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
                finally
                {
                    // Закрытие соединения, если оно открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       }      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnChooseDatabase_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\MSSERVER\\MSSQL16.MSSQLSERVER\\MSSQL\\DATA"; // Установите начальный каталог по вашему усмотрению
                openFileDialog.Filter = "Database files (*.mdf)|*.mdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем полный путь к выбранному файлу базы данных
                    string fullPath = openFileDialog.FileName;
                    // Обновляем строку подключения, используя выбранный путь
                    UpdateConnectionString(fullPath);
                    // Перезагружаем данные из базы данных
                    LoadData();
                }
            }
        }

        private void LoadData()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT ID, Name FROM Users", connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (OleDbException ex)
                {
                    // Обработка ошибок, связанных с подключением к базе данных
                    MessageBox.Show("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message);
                }
                finally
                {
                    // Закрытие соединения, если оно открыто
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void UpdateConnectionString(string fullPath)
        {
            var databaseName = Path.GetFileNameWithoutExtension(fullPath);
            connectionString = $@"Provider=MSOLEDBSQL;Data Source=DESKTOP-9A2HM9B\MSSERVER2024;Initial Catalog={databaseName};Integrated Security=SSPI;";
        }

    }
}
