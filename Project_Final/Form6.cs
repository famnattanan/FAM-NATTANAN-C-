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
    public partial class Form6 : Form
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
        public Form6()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

            Form3 form_three = new Form3();

            form_three.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }

        private void button4_Click(object sender, EventArgs e)//ปุ่ม delete
        {
            int select = homedata.CurrentCell.RowIndex;

            int delete = Convert.ToInt32(homedata.Rows[select].Cells["id"].Value);

            MySqlConnection x = databaseConnection();

            String deletes = "DELETE FROM `home1` WHERE id ='" + delete + "'";

            String message = "DO YOU DELETED ?";

            String title = "SYSTEM";

            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message,title,button);

            ShowEquipment();

            if (result == DialogResult.Yes)
            {
                MySqlCommand cmd = new MySqlCommand(deletes, x);

                x.Open();

                cmd.ExecuteNonQuery();

                x.Close();

                ShowEquipment();
            }
            else
            {
                return;
            }

                
            
        }

        private void button3_Click(object sender, EventArgs e) //ปุ่ม edit
        {
            this.Close();

            Form8 form8 = new Form8();

            form8.Show();
        }

        private void button1_Click(object sender, EventArgs e)//ปุ่ม ลงทะเบียน
        {
            this.Close();

            Form12 form_twelth = new Form12();

            form_twelth.Show();
        }

        private void homedata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม ใบเสร็จ
        {
            this.Close();

            Form11 form_elevent = new Form11();

            form_elevent.Show();
        }
    }
}
