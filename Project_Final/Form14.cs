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
    public partial class Form14 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=homedata;charset=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        private void ShowEquipment()
        {
            MySqlConnection x = databaseConnection();

            DataSet ds = new DataSet();

            x.Open();

            MySqlCommand cmd;

            cmd = x.CreateCommand();

            cmd.CommandText = "SELECT * FROM home1";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            x.Close();

            homedata.DataSource = ds.Tables[0].DefaultView;
        }
        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม ใบเสร็จ
        {
            this.Close();

            Form16 form16 = new Form16();

            form16.Show();
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่ม ลงทะเบียนบ้าน
        {
            this.Close();

            Form15 form15 = new Form15();

            form15.Show();
        }

        private void button1_Click(object sender, EventArgs e)//ปุ่ม logout
        {
            this.Close();

            Form1 form1 = new Form1();

            form1.Show();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }
        private void button4_Click(object sender, EventArgs e) //ปุ่ม reday
        {
            MySqlConnection x = databaseConnection();

            String edits = "UPDATE `home1` SET `status`='NOT SEND'";

            MySqlCommand cmd = new MySqlCommand(edits, x);

            x.Open();

            int rows = cmd.ExecuteNonQuery();

            x.Close();

            if (rows > 0)
            {
                String message = "DO YOU RESTET ?";

                String title = "SYSTEM";

                MessageBoxButtons button = MessageBoxButtons.YesNo;

                DialogResult result = MessageBox.Show(message, title, button);

                if (result == DialogResult.Yes)
                {
                    ShowEquipment();
                }
                else
                {
                    return;
                }
            }
        }
    }
}

       

