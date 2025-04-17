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
            
            this.clientTableAdapter.Fill(this.hotelDataSet.Client);
            
            this.bronirovanieTableAdapter.Fill(this.hotelDataSet.Bronirovanie);
           
            this.bronirovanieTableAdapter.Fill(this.hotelDataSet.Bronirovanie);
            UpdateBronirovanieData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    int idClient = int.Parse(textBox1.Text);
                    int idNomera = int.Parse(textBox4.Text);
                    DateTime dateZaezd = dateTimePicker1.Value.Date;
                    DateTime dateVyezd = dateTimePicker2.Value.Date;

                  
                    if (dateVyezd <= dateZaezd)
                    {
                        MessageBox.Show("Дата выезда должна быть позже даты заезда.");
                        return;
                    }

                    string query = @"
                INSERT INTO dbo.Bronirovanie (Id_Client, Id_Номера, Дата_заезда, Дата_выезда)
                VALUES (@Id_Client, @Id_Nomera, @Data_Zaezd, @Data_Vyezd)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id_Client", idClient);
                        cmd.Parameters.AddWithValue("@Id_Nomera", idNomera);
                        cmd.Parameters.AddWithValue("@Data_Zaezd", dateZaezd);
                        cmd.Parameters.AddWithValue("@Data_Vyezd", dateVyezd);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Бронирование успешно добавлено!");
                    UpdateBronirovanieData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении брони: " + ex.Message);
                }
            }
        }


        private void UpdateBronirovanieData()
        {
            string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string selectQuery = @"
            SELECT Id_Бронь, Id_Client, Id_Номера, Дата_заезда, Дата_выезда 
            FROM dbo.Bronirovanie";

                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                {
                    DataTable dt = new DataTable();
                    try
                    {
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
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
                try
                {
                    
                    var idClientCell = dataGridView1.CurrentRow.Cells["Id_Client"]; 
                    if (idClientCell == null || idClientCell.Value == DBNull.Value)
                    {
                        MessageBox.Show("Id_Client не найдено в текущей строке.");
                        return;
                    }

                    int idClient = Convert.ToInt32(idClientCell.Value);

                    string connectionString = @"Data Source=DESKTOP-8JDTNEK\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                       
                        SqlCommand cmd = new SqlCommand("DELETE FROM Bronirovanie WHERE Id_Client = @idClient", conn);
                        cmd.Parameters.AddWithValue("@idClient", idClient);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена.");
                            UpdateBronirovanieData(); 
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена или ошибка удаления.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Выберите бронирование для удаления.");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}