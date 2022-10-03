using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Final
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)//ปุ่ม back
        {
            this.Close();

            Form1 form_one = new Form1();

            form_one.Show();
        }

        private void button2_Click(object sender, EventArgs e)//ปุ่ม รถส่งน้ำแข็ง
        {
            this.Hide();

            Form13 form13 = new Form13();

            form13.Show();
           
        }

        private void button3_Click(object sender, EventArgs e) //ปุ่ม ลงทะเบียนบ้าน
        {
            this.Close();

            Form6 form_six = new Form6();

            form_six.Show();

        }

            

        private void button1_Click(object sender, EventArgs e) //ปุ่ม โรงน้ำแข็ง
        {
            this.Close();

            Form5 form_five = new Form5();

            form_five.Show();
        }

        private void button6_Click(object sender, EventArgs e)//ปุ่ม editimformation
        {
            this.Close();

            Form9 form9 = new Form9();

            form9.Show();
        }
    }
}
