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
    public partial class Form2 : Form
    {
        private MySqlConnection databaseConnection() //เรียก database
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=employeedata;charset=utf8;";

            MySqlConnection conn = new MySqlConnection(connectionString);

            return conn;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม confirm
        {
            if ( NAME.Text.Length > 0 || LASTNAME.Text.Length > 0)
            {
                if(EMAIL.Text.Length > 0)
                {
                    if (PHONE.Text.Length == 10 )
                    {
                        if (USERNAME.Text.Length >= 5 && USERNAME.Text.Length <= 20)
                        {
                            if (PASSWORD.Text.Length >= 5 && PASSWORD.Text.Length <= 20)
                            {
                                if (PASSWORD.Text == PASSWORD2.Text)
                                {

                                    MySqlConnection conn = databaseConnection();

                                    String sql = "INSERT INTO `employeeuser`(`USERNAME`, `PASSWORD`, `NAME`, `LASTNAME`, `EMAIL`, `TYPEMAIL`, `SEX`, `PHONE`, `DATE`, `MONTH`, `YEAR`) VALUES('" + USERNAME.Text + "','" + PASSWORD.Text + "','" + NAME.Text + "','" + LASTNAME.Text + "','" + EMAIL.Text + "','" + TYPEMAIL.Text + "','" + SEX.Text + "','" + PHONE.Text + "','" + DATE.Text + "','" + MONTH.Text + "','" + YEAR.Text + "')";

                                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                                    conn.Open();

                                    int rows = cmd.ExecuteNonQuery();

                                    conn.Close();

                                    if (rows > 0)
                                    {
                                        String message = "DO YOU ADD DATA ?";

                                        String title = "SYSTEM";

                                        MessageBoxButtons button = MessageBoxButtons.YesNo;

                                        DialogResult result = MessageBox.Show(message, title, button);

                                        if (result == DialogResult.Yes)
                                        {
                                            this.Hide();

                                            Form1 form1 = new Form1();

                                            form1.Show();
                                        }
                                        else
                                        {
                                            return;
                                        }
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

        private void button3_Click(object sender, EventArgs e) //ปุ่ม back
        {
            this.Hide();

            Form1 form1 = new Form1();

            form1.Show();
        }
    }
 }
