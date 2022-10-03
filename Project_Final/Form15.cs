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
    public partial class Form15 : Form
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

            cmd.CommandText = "SELECT `id`, `address`, `recipient` ,`status` FROM home1";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            x.Close();

            homedata.DataSource = ds.Tables[0].DefaultView;
        }

        public Form15()
        {
            InitializeComponent();
        }

        private void homedata_Cellclick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//ปุ่ม delete
        {
            int select = homedata.CurrentCell.RowIndex;

            int delete = Convert.ToInt32(homedata.Rows[select].Cells["id"].Value);

            String deletes = "DELETE FROM `home1` WHERE id ='" + delete + "'";

            String message = "DO YOU DELETED ?";

            String title = "SYSTEM";

            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, button);

            ShowEquipment();

            if (result == DialogResult.Yes)
            {

                MySqlConnection x = databaseConnection();

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

        private void button1_Click(object sender, EventArgs e)//ปุ่ม ลงทะเบียน
        {
            this.Hide();

            Form17 form17 = new Form17();

            form17.Show();
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่ม edit
        {
            this.Hide();

            Form18 form18 = new Form18();

            form18.Show();
        }

        private void button5_Click(object sender, EventArgs e)//ปุ่ม back
        {
            this.Hide();

            Form14 form14 = new Form14();

            form14.Show();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }

        private void homedata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
