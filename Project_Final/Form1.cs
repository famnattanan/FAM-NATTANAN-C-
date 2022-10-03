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
    public partial class Form1 : Form
    {

        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=employeedata;charset=utf8;");

        MySqlDataAdapter adapter2;

        DataTable table;


        public Form1()
        {
            InitializeComponent();

        }

        public void openConponent()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void DataAdapterLogin(String query) //เชคข้อมูลใน database
        {
            openConponent();

            adapter2 = new MySqlDataAdapter(query, conn);

            table = new DataTable();

            adapter2.Fill(table);

            if(table.Rows.Count > 0)
            {
                this.Hide();

                Form14 form14 = new Form14();

                form14.Show();
            }
            else
            {
                MessageBox.Show("NOT FOUND USER");
            }
        }
        private void button1_Click(object sender, EventArgs e) //ปุ่ม login
        {
            if (username_login.Text == "f1" && password_login.Text == "1f")
            {
                this.Hide();

                Form3 form3 = new Form3();

                form3.Show();
            }
            else
            {
                string login = "SELECT * FROM employeeuser WHERE USERNAME = '" + username_login.Text + "' AND PASSWORD ='" + password_login.Text + "'";

                DataAdapterLogin(login);
            }
            

        }

       

        private void button3_Click(object sender, EventArgs e)//ปุ่ม exit
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) //ปุ่ม register
        {
            this.Hide();

            Form2 form2 = new Form2();

            form2.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
