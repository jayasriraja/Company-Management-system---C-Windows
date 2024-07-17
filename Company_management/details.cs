using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Company_management
{
    public partial class details : Form
    {
        public details()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Database=company_manage;Uid=root;Pwd=12345;");
        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void details_Load(object sender, EventArgs e)
        {
            //For show the employee details in page load..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT name as Employee_Name, designation as Designation, experiance as Experiance,qualification as Qualification,achievements as Achievements,doj as Date_of_Join FROM com_employee where status='a'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //For show the employee details..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT name as Employee_Name, designation as Designation, experiance as Experiance,qualification as Qualification,achievements as Achievements,doj as Date_of_Join FROM com_employee where status='a'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //For show the project details..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT pro_name as Project_Name, client as Client_Name, sw_used as Software,description as Description FROM com_projects where status='a'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //For show the event details..
            con.Open();
            MySqlDataAdapter cmd = new MySqlDataAdapter("SELECT event_name as Event_Name, organiser_name as Organiser,purpose as Goals,achievements as Outcomes,date as Date, venue as Venue FROM com_events where status='a'", con);
            DataSet dd = new DataSet();
            cmd.Fill(dd);
            dataGridView1.DataSource = dd.Tables[0];
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_details ad = new add_details();
            ad.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
