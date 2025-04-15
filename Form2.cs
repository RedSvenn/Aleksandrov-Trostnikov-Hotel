using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AnacondaHotel
{
    public partial class Form2 : Form
    {
        private BindingSource bindingSource = new BindingSource();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateClientData();
            this.dataGridView1.AllowUserToAddRows = true;
            this.dataGridView1.AllowUserToDeleteRows = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO dbo.Client (Фамилия, Имя, Отчество, СерияНомерПаспорта, НомерТелефона) " +
                               "VALUES (@Фамилия, @Имя, @Отчество, @СерияНомерПаспорта, @НомерТелефона)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Фамилия", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Имя", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Отчество", textBox3.Text);
                    cmd.Parameters.AddWithValue("@СерияНомерПаспорта", textBox4.Text);
                    cmd.Parameters.AddWithValue("@НомерТелефона", textBox5.Text);

                    cmd.ExecuteNonQuery();
                }
                UpdateClientData();
            }

            MessageBox.Show("Клиент добавлен!");
        }

        // Метод для обновления данных в DataGridView
        private void UpdateClientData()
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Запрос для получения всех данных из таблицы Client
                string selectQuery = "SELECT [IdClient], [Фамилия], [Имя], [Отчество], [СерияНомерПаспорта], [НомерТелефона] FROM dbo.Client";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);
                        bindingSource.DataSource = dt;
                        dataGridView1.DataSource = bindingSource;

                    
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
            if (dataGridView1.CurrentRow != null)
            {
                int idClient = Convert.ToInt32(dataGridView1.CurrentRow.Cells["IdClient"].Value);

                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Client WHERE [IdClient] = @id", conn);
                    cmd.Parameters.AddWithValue("@id", idClient);
                    cmd.ExecuteNonQuery();
                }

                this.clientTableAdapter.Fill(this.hotelDataSet.Client);
 
                dataGridView1.DataSource = this.clientBindingSource;
                dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Выберите клиента для удаления.");
            }
        }


    }
}
