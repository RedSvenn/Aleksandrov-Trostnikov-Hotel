using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnacondaHotel
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.BackColor == Color.Red)
            {
                button1.BackColor = Color.Green; // Меняем на зеленый, если был красный
            }
            else
            {
                button1.BackColor = Color.Red; // Меняем на красный, если был не красный
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.BackColor == Color.Red)
            {
                button2.BackColor = Color.Green; // Меняем на зеленый, если был красный
            }
            else
            {
                button2.BackColor = Color.Red; // Меняем на красный, если был не красный
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.BackColor == Color.Red)
            {
                button3.BackColor = Color.Green; // Меняем на зеленый, если был красный
            }
            else
            {
                button3.BackColor = Color.Red; // Меняем на красный, если был не красный
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.BackColor == Color.Red)
            {
                button4.BackColor = Color.Green; // Меняем на зеленый, если был красный
            }
            else
            {
                button4.BackColor = Color.Red; // Меняем на красный, если был не красный
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
