using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Company_management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            products p = new products();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contact c = new contact();
            c.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            login lg = new login();
            lg.Show();
        }

       


        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

       
    }
}
