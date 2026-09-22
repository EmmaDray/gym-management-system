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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        public void Showdata()
        {
            
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Class";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvClass.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtClassname_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtClassname.Text))
            {
                MessageBox.Show("Please put name before Search.");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Class where Name ='" + txtClassname.Text + "'";
                cmd.ExecuteNonQuery();//need dataadapter when do search 
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgvClass.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("The class is not found!!"); // there is another one- null or empty show message - type the name = using (if)
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

        private void Form12_Load(object sender, EventArgs e)
        {
            Showdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Showdata();
            txtClassname.Text = "";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F5 = new Form5();
            this.Hide();
            F5.Show();
        }
    }
}
