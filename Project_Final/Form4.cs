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
    public partial class Form4 : Form
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=driverdata;charset=utf8;");

        MySqlDataAdapter adapter;

        MySqlCommand command;

        MySqlDataReader myReader;

        DataTable table;
        private void ShowEquipment()
        {
            MySqlConnection x = databaseConnection();

            DataSet ds = new DataSet();

            x.Open();

            MySqlCommand cmd;

            cmd = x.CreateCommand();

            cmd.CommandText = "SELECT * FROM driver";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            x.Close();

            driverdata.DataSource = ds.Tables[0].DefaultView;
        }
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=driverdata;charset=utf8;";

            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowEquipment();

        }

        private void button4_Click(object sender, EventArgs e)//ปุ่ม add
        {
            if (no_car.Text.Length > 0)
            {
                if (face_name.Text.Length > 0)
                {
                    if (name.Text.Length > 0)
                    {
                        if (id.Text.Length == 13)
                        {
                            if (phone.Text.Length == 10)
                            {
                                MySqlConnection x = databaseConnection();

                                String insert = "INSERT INTO `driver`(`หมายเลขรถ`, `คำนำหน้า`, `ชื่อคนขับ`, `เลขบัตรประชาชน`, `หมายเลขโทรศัพท์`) VALUES ('" + no_car.Text + "','" + face_name.Text + "','" + name.Text + "','" + id.Text + "','" + phone.Text + "')";

                                MySqlCommand cmd = new MySqlCommand(insert, x);

                                x.Open();

                                int rows = cmd.ExecuteNonQuery();

                                x.Close();

                                if (rows > 0)
                                {
                                    MessageBox.Show("Added Data", "System");

                                    ShowEquipment();
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("enter phone 10 charactors", "System");
                            }
                        }
                        else
                        {
                            MessageBox.Show("enter id 13 charactors", "System");
                        }
                    }
                    else
                    {
                        MessageBox.Show("enter name", "System");
                    }
                }
                else
                {
                    MessageBox.Show("enter face name", "System");
                }
            }
            else
            {
                MessageBox.Show("enter number of a car", "System");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Form3 form_three = new Form3();

            form_three.Show();
        }

        private void dataEquiment_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            driverdata.CurrentRow.Selected = true;

            no_car.Text = driverdata.Rows[e.RowIndex].Cells["หมายเลขรถ"].FormattedValue.ToString();

            face_name.Text = driverdata.Rows[e.RowIndex].Cells["คำนำหน้า"].FormattedValue.ToString();

            name.Text = driverdata.Rows[e.RowIndex].Cells["ชื่อคนขับ"].FormattedValue.ToString();

            id.Text = driverdata.Rows[e.RowIndex].Cells["เลขบัตรประชาชน"].FormattedValue.ToString();

            phone.Text = driverdata.Rows[e.RowIndex].Cells["หมายเลขโทรศัพท์"].FormattedValue.ToString();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Form13 form13 = new Form13();

            form13.Show();
        }

        private void button5_Click(object sender, EventArgs e) //ปุ่ม delete
        {
            int select = driverdata.CurrentCell.RowIndex;

            int delete = Convert.ToInt32(driverdata.Rows[select].Cells["id"].Value);

            MySqlConnection x = databaseConnection();

            String deletes = "DELETE FROM `driver` WHERE id ='" + delete + "'";

            MySqlCommand cmd = new MySqlCommand(deletes , x);

            x.Open();

            int rows = cmd.ExecuteNonQuery();

            x.Close();

            if (rows > 0)
            {
                String message = "DO YOU DELETE DATA ?";

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

        private void button3_Click(object sender, EventArgs e) //ปุ่ม edit
        {
            int select = driverdata.CurrentCell.RowIndex;

            int edit = Convert.ToInt32(driverdata.Rows[select].Cells["id"].Value);

            MySqlConnection x = databaseConnection();

            String edits = "UPDATE `driver` SET `หมายเลขรถ`='"+no_car.Text+"',`คำนำหน้า`='"+face_name.Text+"',`ชื่อคนขับ`='"+name.Text+"',`เลขบัตรประชาชน`='"+id.Text+"',`หมายเลขโทรศัพท์`='"+phone.Text+"' WHERE id = '"+edit+"'";

            MySqlCommand cmd = new MySqlCommand(edits, x);

            x.Open();

            int rows = cmd.ExecuteNonQuery();

            x.Close();

            if (rows > 0)
            {
                String message = "DO YOU UPDATE DATA ?";

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

        private void button1_Click(object sender, EventArgs e) //ปุ่ม search
        {
            conn.Open();

            string Search = "SELECT * FROM driver WHERE  `หมายเลขรถ` = '" + no_car.Text + "'";

            command = new MySqlCommand(Search, conn);

            myReader = command.ExecuteReader();

            if (myReader.Read())
            {

                face_name.Text = myReader.GetString("คำนำหน้า");

                name.Text = myReader.GetString("ชื่อคนขับ");

                id.Text = myReader.GetString("เลขบัตรประชาชน");

                phone.Text = myReader.GetString("หมายเลขโทรศัพท์");
            }
            else
            {
                MessageBox.Show("NOT FOUND USER");

                this.Close();

                Form4 form4 = new Form4();

                form4.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
