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
    public partial class Form8 : Form
    {
        private void ShowEquipment()//show datagrideview
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
        private MySqlConnection databaseConnection()//database
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=homedata;charset=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }

        private void dataConnection_Cellclick(object sender, DataGridViewCellEventArgs e)
        {
            homedata.CurrentRow.Selected = true;

            richTextBox1.Text = homedata.Rows[e.RowIndex].Cells["address"].FormattedValue.ToString();

            textBox7.Text = homedata.Rows[e.RowIndex].Cells["recipient"].FormattedValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e) //ปุ่ม edit
        {
            int select = homedata.CurrentCell.RowIndex;

            int edit = Convert.ToInt32(homedata.Rows[select].Cells["id"].Value);

            MySqlConnection x = databaseConnection();

            String edits = "UPDATE `home1` SET `address`='"+richTextBox1.Text+"',`recipient`='"+textBox7.Text+"' WHERE id = '" + edit + "'";

            MySqlCommand cmd = new MySqlCommand(edits, x);

            x.Open();

            int rows = cmd.ExecuteNonQuery();

            x.Close();

            if (rows > 0)
            {
                String message = "DO YOU UPDATE ?";

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

        private void button3_Click(object sender, EventArgs e) //ปุ่ม back
        {
            this.Close();

            Form6 form6 = new Form6();

            form6.Show();
        }

        
    }
}
