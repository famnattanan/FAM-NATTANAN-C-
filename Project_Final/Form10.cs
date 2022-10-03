using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Project_Final
{
    public partial class Form10 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=homedata;charset=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        public Form10()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Form6 form6 = new Form6();

            form6.Show();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection x = databaseConnection();

            String insert = "INSERT INTO `home`(`บ้านเลขที่`, `หมู่`, `ซอย`, `ถนน`, `บ้าน`, `ตำบล`, `อำเภอ`, `จังหวัด`, `ชื่อผู้รับ`) VALUES ('" + textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";

            MySqlCommand cmd = new MySqlCommand(insert, x);

            x.Open();

            int rows = cmd.ExecuteNonQuery();

            x.Close();

            if (rows > 0)
            {
                MessageBox.Show("Added Data", "System");

                cleartextbox();

            }

        }
        public void cleartextbox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String message = "DO YOU DELETED All ?";

            String title = "SYSTEM";

            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, button);

            if (result == DialogResult.Yes)
            {
                cleartextbox();
            }
            else
            {
                return;
            }
            
        }
    }
}
