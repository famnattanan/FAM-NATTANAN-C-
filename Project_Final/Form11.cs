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
    public partial class Form11 : Form
       
    {
        
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=homedata;charset=utf8;");

        MySqlDataAdapter adapter;

        MySqlCommand command;

        MySqlDataReader myReader;

        DataTable table;

        
        public Form11()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)//ปุ่ม search
        {
            conn.Open();

            string Search = "SELECT * FROM home1 WHERE  `recipient` = '" + textBox1.Text + "'";

            command = new MySqlCommand(Search, conn);

            myReader = command.ExecuteReader();

            if (myReader.Read())
            {
                richTextBox1.Text = myReader.GetString("address");
            }
            else
            {
                MessageBox.Show("NOT FOUND USER");

                this.Close();   

                Form11 form11 = new Form11();

                form11.Show();
            }
        }

        double j, k, num1, num2,num3;

        

        private void button5_Click(object sender, EventArgs e)//ปุ่ม back
        {
            this.Close();

            Form6 form6 = new Form6();

            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e) //ปุ่ม calculater
        {
            int j = 45 * (int)numericUpDown2.Value;
            num2 = j;
            int k = 40 * (int)numericUpDown1.Value;
            num1 = k;
            num3 = num1 + num2;
            textBox2.Text = num3.ToString();
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม print
        {
           
            if(textBox1.Text.Length > 0)
            {
                if (textBox2.Text.Length > 1)
                {
                    printPreviewDialog1.Document = printDocument1;

                    printPreviewDialog1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please press calculate");
            }
            }
            else
            {
                MessageBox.Show("Please enter recipient");
            }
            

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) //ใบเสร็จ
        {
            e.Graphics.DrawString("  NAGONCRONGCHAI ICE ", new Font("Arial", 40, FontStyle.Regular), Brushes.Black, new Point(80, 80));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToShortDateString(), new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(550, 230));
            e.Graphics.DrawString(".......................................................... ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(26, 250));
           
            e.Graphics.DrawString(" ผู้รับ : ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(35, 310));
            e.Graphics.DrawString(" ที่อยู่ :", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(35, 380));


            e.Graphics.DrawString(textBox1.Text, new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(160, 320));
            e.Graphics.DrawString(richTextBox1.Text, new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(160, 390));
            // หน่วยราคารายเมนู

            e.Graphics.DrawString(".......................................................... ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(26, 490));
            e.Graphics.DrawString(" รายการ ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(40, 550));
            e.Graphics.DrawString(" จำนวน ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(590, 550));
            e.Graphics.DrawString(" น้ำเเข็งก้อน [40 บาท/กระสอบ] : ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(40, 620));
            e.Graphics.DrawString(" น้ำเเข็งบด  [60 บาท/กระสอบ] : ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(40, 680));

            // ราคาท้ายบิลรวมๆ
            e.Graphics.DrawString(".......................................................... ", new Font("Arial", 36, FontStyle.Regular), Brushes.Black, new Point(26, 750));
            // หน่วยราคาหน่วยท้ายบิล
            e.Graphics.DrawString(numericUpDown1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(650, 620));
            e.Graphics.DrawString(numericUpDown2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(650, 680));

            e.Graphics.DrawString(" รวมทั้งสิ้น : ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(350, 820));
            e.Graphics.DrawString(textBox2.Text, new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(600, 820));
            e.Graphics.DrawString(" บาท : ", new Font("Arial", 30, FontStyle.Regular), Brushes.Black, new Point(730, 820));
        }

        private void Form11_Load(object sender, EventArgs e)
        {
                
        }

        

    }
}
