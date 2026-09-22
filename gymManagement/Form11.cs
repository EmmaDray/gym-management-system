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


namespace gymManagement
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        public void displayData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Register";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                dgvRe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form11_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRid.Text))
            {
                MessageBox.Show("Please put Register Id before search .");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Register where RId ='" + txtRid.Text + "'";
                cmd.ExecuteNonQuery();//need dataadapter when do search 
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgvRe.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("The Register Id is not found!!"); // there is another one- null or empty show message - type the name = using (if)
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displayData();
            txtRid.Text = "";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }
    }
}
