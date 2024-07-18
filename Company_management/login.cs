using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Web;
using System.Net;

namespace Company_management
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("Server=localhost;Database=company_manage;Uid=root;Pwd=12345;");
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
                //For Exist user login..
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button6.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false ;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                textBox1.Focus();
               
        }

        private void login_Load(object sender, EventArgs e)
        {
            radioButton1.Select();
            button5.Enabled = false;
            button6.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //For new user login..
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button6.Visible = false;
            textBox4.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //for close the form
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //log in button
            if (otpm == textBox3.Text)
            {
                //textBox1.Clear();
                //textBox2.Clear();
                //textBox3.Clear();
                details ds = new details();
                ds.Show();
            }
            if(otpm != textBox3.Text)
            {
                MessageBox.Show("OTP is wrong");
            }

        }
        int unco, emco;

        private void button5_Click(object sender, EventArgs e)
        {
            //create account button
            if (otpm == textBox8.Text && textBox6.Text != string.Empty)
            {
                if (textBox6.Text == textBox7.Text)
                {
                    //if OTP is correct..
                    con.Open();
                    var fdt = System.DateTime.Now.ToString("yy/MM/dd hh:mm:ss");
                    MySqlCommand cmd = new MySqlCommand("insert into login_data(uname,email,password,username,fdt,status) values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','admin','" + fdt.ToString() + "','a')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account created successfully!!");
                    con.Close();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    details d = new details();
                    d.Show();
                }
                else
                {
                    //If OTP is wrong..
                    MessageBox.Show("Re-Entered password is wrong");
                }
            }
            else
            {
                MessageBox.Show("OTP is wrong");
            }
        }
        int unpsco;  //uname,password count
        string uname = string.Empty;
        private void button1_Click(object sender, EventArgs e)
        {
            // send the otp to registered mail id..
           
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(*) from login_data where uname='" + textBox1.Text + "' && password='"+textBox2.Text+"'" , con);
            unpsco = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            try
            {
                if (unpsco == 1)
                {
                    con.Open();
                    MySqlCommand cm = new MySqlCommand("select email from login_data where uname='" + textBox1.Text + "'", con);
                    email = cm.ExecuteScalar().ToString();
                    con.Close();
                    uname = textBox1.Text;
                    generateotp();
                    sendemail();
                    button6.Enabled = true;

                }
                if (unpsco == 0 && unpsco <= 2)
                {
                    MessageBox.Show("Username or Password is Incorrect");
                    textBox4.Clear();
                    textBox5.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Unappropriate action is happened");
                this.Close();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //To evaluate the mail id by the OTP..
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select count(uname) from login_data where uname='" + textBox4.Text + "';", con);
            unco = Convert.ToInt16(cmd.ExecuteScalar());
            MySqlCommand cm = new MySqlCommand("select count(email) from login_data where email='" + textBox5.Text + "';", con);
            emco = Convert.ToInt16(cm.ExecuteScalar());
            con.Close(); 
            try
            {
                if (unco == 0 && emco == 0)
                {
                    uname = textBox4.Text;
                    email = textBox5.Text;
                    generateotp();
                    sendemail();
                    button5.Enabled = true;

                }
                else
                {
                    MessageBox.Show("This Username or Email Id is already Exist..Please enter differently");
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox4.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Unappropriate selection happened");
                this.Close();
            }
           
        }
        string otpm = string.Empty;
        public void generateotp()
        {
            //to genarate OTP
            {
                string num = "0123456789abcdefghijklmnopqrstuvwxyz";
                int len = num.Length;
                string otp = string.Empty;
                int getindex;
                int otpdigit = 5;
                string finaldigit;
                for (int i = 0; i < otpdigit; i++)
                {
                    do
                    {
                        getindex = new Random().Next(0, len);
                        finaldigit = num.ToCharArray()[getindex].ToString();
                    } while (otp.IndexOf(finaldigit) != -1);
                    {
                        otp += finaldigit;
                    }
                    otpm = otp;
                }
            }
        }
        string email;
        public void sendemail()
        {
            //argument (from email Address,To email Address)
       
            MailMessage mail = new MailMessage("<Enter E-Mail id>", email);
            mail.Subject = "Log in OTP for Tech Solutions Private Ltd.";
            mail.Body = "Welcome.. "+uname+"...."+"OTP : " +otpm;
           // mail.Body = "Welcome.." + uname;
            mail.IsBodyHtml = true; 
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential()
            {
                //email ID
                UserName = "<Enter E-Mail id>",
                //email ID password
                Password = "<Enter two step verification password>"
            };
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }
       private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
