using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vahtershasimulator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public class DatabaseConnection
        {
            public static MySqlConnection GetConnection()
            {
                string connectionString = "server=localhost;database=romashka;username=batat;password=Alliseeisred12!;";

                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли выбранные строки в DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для добавления в базу данных.", "Ошибка");
                return; // Выходим из метода, если строк не выбрано
            }

            // Получаем данные из выбранной строки DataGridView
            string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string surname = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            string otchestvo = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            string position = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            string vremya = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            // Формируем SQL-запрос для вставки данных
            string query = "INSERT INTO buenoы (Имя, Фамилия, Отчество, Категория, Время) VALUES (@name, @surname, @otchestvo, @position, @vremya)";

            // Создаем объект MySqlCommand
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Добавляем параметры для защиты от SQL-инъекций
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@otchestvo", otchestvo);
                    command.Parameters.AddWithValue("@position", position);
                    command.Parameters.AddWithValue("@vremya", vremya);

                    // Открываем соединение с базой данных
                    connection.Open();

                    // Выполняем запрос на вставку
                    command.ExecuteNonQuery();

                    // Закрываем соединение
                    connection.Close();

                    // Отображаем сообщение об успешной вставке
                    MessageBox.Show("Данные успешно добавлены в базу данных!", "Успешно");

                    // Удаляем выбранную строку из DataGridView
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка");
                return;
            }

            // Получаем ID выбранной строки из DataGridView
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Предполагается, что ID находится в первом столбце

            // Формируем SQL-запрос для удаления строки
            string query = "DELETE FROM buenoы WHERE ID = @id"; // Замените "ID" на имя столбца с ID в вашей таблице

            // Создаем объект MySqlCommand
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Добавляем параметр для защиты от SQL-инъекций
                    command.Parameters.AddWithValue("@id", id);

                    // Открываем соединение с базой данных
                    connection.Open();

                    // Выполняем запрос на удаление
                    command.ExecuteNonQuery();

                    // Закрываем соединение
                    connection.Close();

                    // Отображаем сообщение об успешном удалении
                    MessageBox.Show("Строка успешно удалена из базы данных!", "Успешно");

                    // Удаляем строку из DataGridView
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
         
        string query = "SELECT * FROM buenoы";

            // Создаем объект MySqlCommand
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Открываем соединение с базой данных
                    connection.Open();

                    // Создаем объект MySqlDataAdapter
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    // Создаем объект DataTable
                    DataTable table = new DataTable();

                    // Заполняем DataTable данными
                    adapter.Fill(table);

                    // Заполняем DataGridView данными из DataTable
                    dataGridView1.DataSource = table;

                    // Закрываем соединение
                    connection.Close();
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM buenoы";

            // Создаем объект MySqlCommand
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Открываем соединение с базой данных
                    connection.Open();

                    // Создаем объект MySqlDataAdapter
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                    // Создаем объект DataTable
                    DataTable table = new DataTable();

                    // Заполняем DataTable данными
                    adapter.Fill(table);

                    // Заполняем DataGridView данными из DataTable
                    dataGridView1.DataSource = table;

                    // Закрываем соединение
                    connection.Close();
                }
            }
        }
    }
}
