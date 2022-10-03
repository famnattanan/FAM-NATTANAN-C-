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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=homedata;charset=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        private void button1_Click(object sender, EventArgs e)//ปุ่ม confirm
        {
            if (richTextBox1.Text.Length > 0)
            {
                if (textBox1.Text.Length > 0)
                {
                    MySqlConnection x = databaseConnection();

                    String insert = "INSERT INTO `home1`(`address`, `recipient`, `status`) VALUES ('" + richTextBox1.Text + "','" + textBox1.Text + "','NOT SEND')";

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
                else
                {
                    MessageBox.Show("Please enter Recipient");
                }
            }
            else
            {
                MessageBox.Show("Please enter Address");
            }
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่ม clear
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
        public void cleartextbox()
        {
            textBox1.Clear();

            richTextBox1.Clear();

        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม back
        {
            this.Close();

            Form15 form15 = new Form15();

            form15.Show();
        }
    }
    
    
    

    
    
}
