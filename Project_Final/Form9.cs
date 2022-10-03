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
    public partial class Form9 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=employeedata;charset=utf8;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Form9()
        {
            InitializeComponent();
        }
        private void ShowEquipment()
        {
            MySqlConnection x = databaseConnection();

            DataSet ds = new DataSet();

            x.Open();

            MySqlCommand cmd;

            cmd = x.CreateCommand();

            cmd.CommandText = "SELECT * FROM employeeuser";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(ds);

            x.Close();

            employeedata.DataSource = ds.Tables[0].DefaultView;
        }
        

        private void dataEquiment_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            employeedata.CurrentRow.Selected = true;

            NAME.Text = employeedata.Rows[e.RowIndex].Cells["NAME"].FormattedValue.ToString();

            LASTNAME.Text = employeedata.Rows[e.RowIndex].Cells["LASTNAME"].FormattedValue.ToString();

            EMAIL.Text = employeedata.Rows[e.RowIndex].Cells["EMAIL"].FormattedValue.ToString();

            TYPEMAIL.Text = employeedata.Rows[e.RowIndex].Cells["TYPEMAIL"].FormattedValue.ToString();

            SEX.Text = employeedata.Rows[e.RowIndex].Cells["SEX"].FormattedValue.ToString();

            PHONE.Text = employeedata.Rows[e.RowIndex].Cells["PHONE"].FormattedValue.ToString();

            DATE.Text = employeedata.Rows[e.RowIndex].Cells["DATE"].FormattedValue.ToString();

            MONTH.Text = employeedata.Rows[e.RowIndex].Cells["MONTH"].FormattedValue.ToString();

            YEAR.Text = employeedata.Rows[e.RowIndex].Cells["YEAR"].FormattedValue.ToString();

            USERNAME.Text = employeedata.Rows[e.RowIndex].Cells["USERNAME"].FormattedValue.ToString();
            
            PASSWORD.Text = employeedata.Rows[e.RowIndex].Cells["PASSWORD"].FormattedValue.ToString();
            
            PASSWORD2.Text = employeedata.Rows[e.RowIndex].Cells["PASSWORD"].FormattedValue.ToString();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            ShowEquipment();
        }

        private void button3_Click_1(object sender, EventArgs e)//ปุ่ม back
        {
            this.Hide();

            Form3 form3 = new Form3();

            form3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e) //ปุ่ม confirm
        {
            if (NAME.Text.Length > 0 || LASTNAME.Text.Length > 0)
            {
                if (EMAIL.Text.Length > 0)
                {
                    if (PHONE.Text.Length == 10)
                    {
                        if (USERNAME.Text.Length >= 5 && USERNAME.Text.Length <= 20)
                        {
                            if (PASSWORD.Text.Length >= 5 && PASSWORD.Text.Length <= 20)
                            {
                                if (PASSWORD.Text == PASSWORD2.Text)
                                {

                                    int select = employeedata.CurrentCell.RowIndex;

                                    int edit = Convert.ToInt32(employeedata.Rows[select].Cells["id"].Value);

                                    MySqlConnection x = databaseConnection();

                                    String edits = "UPDATE `employeeuser` SET `NAME`='"+NAME.Text+ "',`LASTNAME`='" + LASTNAME.Text + "',`EMAIL`='" + EMAIL.Text + "',`TYPEMAIL`='" + TYPEMAIL.Text + "',`SEX`='" + SEX.Text + "',`PHONE`='" + PHONE.Text + "',`DATE`='" + DATE.Text + "',`MONTH`='" + MONTH.Text + "',`YEAR`='" + YEAR.Text + "',`USERNAME`='" + USERNAME.Text + "',`PASSWORD`='" + PASSWORD.Text + "' WHERE id = '"+edit+"'";

                                    MySqlCommand cmd = new MySqlCommand(edits, x);

                                    x.Open();

                                    int rows = cmd.ExecuteNonQuery();

                                    x.Close();

                                    if (rows > 0)
                                    {
                                        MessageBox.Show("Edit Data", "System", MessageBoxButtons.YesNo);

                                        ShowEquipment();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password must same");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Password must have more than 4 character and less than 21 character");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username must have more than 4 character and less than 21 character");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter your phonenumber ");
                    }

                }
                else
                {
                    MessageBox.Show("Please enter your email");
                }
            }
            else
            {
                MessageBox.Show("Please enter your name and lastname");
            }
        }
    }
}
