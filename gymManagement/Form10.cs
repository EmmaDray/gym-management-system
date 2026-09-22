using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace gymManagement
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        public void displaydata()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from userAccount";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                dgvUseracc.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            String role = "";
            if (rdbAdmin.Checked == true)
            {
                role = "admin";
            }
            else
            {
                role = "member";
            }
            try
            {
                if (string.IsNullOrEmpty(txtuName.Text))
                {
                    MessageBox.Show("Please put name before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtpassword.Text))
                {
                    MessageBox.Show("Please put password before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please select role before insert.");
                    return;
                }
                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM userAccount WHERE username = @UName", con);
                checkCmd.Parameters.AddWithValue("@UName", txtuName.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("The selected user name is already exit.");
                    return;
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into userAccount(username,password,role) values('" + txtuName.Text + "', '" + txtpassword.Text + "', '" + role + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted user account!!");
                con.Close();
                displaydata();
                clearUser();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            }
        public void clearUser()
        {
            txtuName.Text = "";
            txtpassword.Text = "";

            rdbAdmin.Checked = false; // Assuming these are your radio buttons for gender
            rdbMember.Checked = false;
        }

        private void dgvUseracc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow i = dgvUseracc.Rows[e.RowIndex];
                txtuName.Text = i.Cells[0].Value.ToString();
                txtpassword.Text = i.Cells[1].Value.ToString();
                String g = i.Cells[2].Value.ToString().Trim();
                if (g == "Male")
                {
                    rdbAdmin.Checked = true;
                    rdbMember.Checked = false;

                }
                else
                {
                    rdbMember.Checked = true;
                    rdbAdmin.Checked = false;
                }
              
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            displaydata();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String role = "";
            if (rdbAdmin.Checked == true)
            {
                role = "admin";
            }
            else
            {
                role = "member";
            }
            try
            {
                if (string.IsNullOrEmpty(txtuName.Text))
                {
                    MessageBox.Show("Please put username before Update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtpassword.Text))
                {
                    MessageBox.Show("Please put password before Update.");
                    return;
                }
                if (string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please select role before Update.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update userAccount set username= '" + txtuName.Text + "',password= '" +txtpassword.Text + "',role= '" + role + "' where username = '" + txtuName.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated Successfully!!");
                displaydata();
                clearUser();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuName.Text))
            {
                MessageBox.Show("Please fill the user name for Delete.");

            }
            else {
                try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from userAccount where username ='" + txtuName.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted SuccessFully!!");
                displaydata();
                clearUser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            }

           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtuName.Text))
            {
                MessageBox.Show("Please fill the user name for searth.");

            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from userAccount where username ='" + txtuName.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count == 1)
                    {
                        dgvUseracc.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("The user name is not found.");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var F9 = new Form9();
            this.Hide();
            F9.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displaydata();
            clearUser();
        }
    }
}
