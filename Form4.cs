using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AnacondaHotel
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=DESKTOP-8JDTNEK\\SQLEXPRESS;Database=HotelDB;Integrated Security=True";

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UpdateButtonColors();
        }

        private void UpdateButtonColors()
        {
            for (int i = 1; i <= 10; i++)
            {
                Button btn = Controls.Find("button" + i, true)[0] as Button;
                if (btn != null)
                {
                    if (IsRoomBooked(i))
                        btn.BackColor = Color.Red;
                    else
                        btn.BackColor = Color.Green;
                }
            }
        }

        private bool IsRoomBooked(int roomId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Bronirovanie WHERE Id_Номера = @roomId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@roomId", roomId);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) => ToggleButtonColor(1);
        private void button2_Click(object sender, EventArgs e) => ToggleButtonColor(2);
        private void button3_Click(object sender, EventArgs e) => ToggleButtonColor(3);
        private void button4_Click(object sender, EventArgs e) => ToggleButtonColor(4);
        private void button5_Click(object sender, EventArgs e) => ToggleButtonColor(5);
        private void button6_Click(object sender, EventArgs e) => ToggleButtonColor(6);
        private void button7_Click(object sender, EventArgs e) => ToggleButtonColor(7);
        private void button8_Click(object sender, EventArgs e) => ToggleButtonColor(8);
        private void button9_Click(object sender, EventArgs e) => ToggleButtonColor(9);
        private void button10_Click(object sender, EventArgs e) => ToggleButtonColor(10);

        private void ToggleButtonColor(int roomId)
        {
            Button btn = Controls.Find("button" + roomId, true)[0] as Button;
            if (btn != null)
            {
                if (btn.BackColor == Color.Red)
                    btn.BackColor = Color.Green;
                else
                    btn.BackColor = Color.Red;
            }
        }
    }
}
