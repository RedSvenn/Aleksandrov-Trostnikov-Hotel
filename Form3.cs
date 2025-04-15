using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnacondaHotel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "hotelDataSet.Bronirovanie". При необходимости она может быть перемещена или удалена.
            this.bronirovanieTableAdapter.Fill(this.hotelDataSet.Bronirovanie);
            // Загрузка данных в DataGridView
            this.bronirovanieTableAdapter.Fill(this.hotelDataSet.Bronirovanie);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Преобразуем текст в даты
                    DateTime dateZaezd = DateTime.Parse(textBox2.Text);
                    DateTime dateVyezd = DateTime.Parse(textBox3.Text);

                    string query = "INSERT INTO dbo.Bronirovanie (Id_Client, Дата_заезда, Дата_выезда, Id_Номера) " +
                                   "VALUES (@Id_Client, @Дата_заезда, @Дата_выезда, @Id_Номера)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Client", textBox1.Text); // Здесь предполагается, что в textBox1 - ID клиента.
                        cmd.Parameters.AddWithValue("@Дата_заезда", dateZaezd);
                        cmd.Parameters.AddWithValue("@Дата_выезда", dateVyezd);
                        cmd.Parameters.AddWithValue("@Id_Номера", textBox4.Text);

                        cmd.ExecuteNonQuery();
                    }

                    // Обновляем DataGridView
                    UpdateClientData();

                    MessageBox.Show("Бронь добавлена успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении брони: " + ex.Message);
                }
            }
        }

        // Метод для обновления данных в DataGridView
        private void UpdateClientData()
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT [Id_Client], [Дата_заезда], [Дата_выезда], [Id_Номера]  FROM dbo.Bronirovanie";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);  // Заполняем DataTable данными
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Этот метод пока не используется, можно добавить логику для удаления или других действий
        }

        private void bronirovanieBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bronirovanieBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.hotelDataSet);

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
