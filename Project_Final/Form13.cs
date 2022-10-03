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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)//ปุ่ม back
        {
            this.Close();

            Form3 form3 = new Form3();

            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)//ปุ่ม datadriver
        {
            this.Close();

            Form4 form4 = new Form4();

            form4.Show();
        }
    }
}
