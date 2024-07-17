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
    public partial class add_details : Form
    {
        public add_details()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Database=company_manage;Uid=root;Pwd=12345;");
        private void add_details_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // For add employee details..
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button1.Visible = true;
            //For not visible the add project details...
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            button2.Visible = false;
            //For not visible the add event details..
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            button3.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // For add the project details..
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            button2.Visible = true;
            // For not visible the add employee details..
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button1.Visible = false;
            //For not visible the add event details..
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox15.Visible = false;
            textBox16.Visible = false;
            button3.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // For add the event details..
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
            textBox15.Visible = true;
            textBox16.Visible = true;
            button3.Visible = true;
            // For not visible the add employee details..
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button1.Visible = false;
            //For not visible the add project details...
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            button2.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Radio button 1
            // For add employee details..
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && textBox6.Text != string.Empty)
                {
                    con.Open();
                    var fdt = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss");
                    MySqlCommand cmd = new MySqlCommand("insert into com_employee(name,designation,experiance,qualification,achievements,doj,username,fdt,status) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','admin','" + fdt.ToString() + "','a')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New employee details added successfully!!");
                    con.Close();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                }
            else
        
            {
                MessageBox.Show("Inappropriate action is happened");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Radio button 2
            // For add project details..
            if (textBox7.Text != string.Empty && textBox8.Text != string.Empty && textBox9.Text != string.Empty && textBox10.Text != string.Empty)
            { 
                con.Open();
                var fdt = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss");
                MySqlCommand cmd = new MySqlCommand("insert into com_projects(pro_name,client,sw_used,description,username,fdt,status) values('" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','admin','" + fdt.ToString() + "','a')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New project details added successfully!!");
                con.Close();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
             }
            else
            {
                MessageBox.Show("Inappropriate action is happened");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Radio button 3
            //For add event details..
            if (textBox11.Text != string.Empty && textBox12.Text != string.Empty && textBox13.Text != string.Empty && textBox14.Text != string.Empty && textBox15.Text != string.Empty && textBox16.Text != string.Empty)
            {
                    con.Open();
                    var fdt = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss");
                    MySqlCommand cmd = new MySqlCommand("insert into com_events(event_name,organiser_name,purpose,achievements,date,venue,username,fdt,status) values('" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','admin','" + fdt.ToString() + "','a')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New event details added successfully!!");
                    con.Close();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
             }
            else
            {
                    MessageBox.Show("Inappropriate action is happened");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
