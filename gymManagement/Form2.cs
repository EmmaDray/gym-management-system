using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace gymManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            if (rdbAdmin.Checked)
            {
                try
                {   SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    String query = "select * from userAccount where username = '" + txtUser.Text + "' and password = '" + txtPassword.Text + "' and role = '" + rdbAdmin.Text + "' ";
                    SqlDataAdapter adp = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    
                   if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Admin login success");
                        var F3 = new Form3();
                        this.Hide();
                        F3.Show();
                        txtUser.Text = "";
                        txtPassword.Text = "";}
                    else
                    {
                        MessageBox.Show("Incorrect Password or Username");
                    }

                }
                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
                    con.Open();
                    String query = "select * from userAccount where username =  '" + txtUser.Text + "' and password = '" + txtPassword.Text + "'and role = '" + rdbMember.Text + "' ";
                    SqlDataAdapter adp = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    
                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Member login Success");
                        var U = new Form5();
                        this.Hide();
                        U.Show();
                        txtUser.Text = "";
                        txtPassword.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password or Username");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var F4 = new Form4();
            this.Hide();
            F4.Show();
        }
    }
}
