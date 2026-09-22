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
    public partial class Form13 : Form
    {
        public Form13()
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
                cmd.CommandText = "select * from trainer";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvTrainer.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Showdata();
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTid.Text))
            {
                MessageBox.Show("Please put Trainer Id before search .");
                return;
            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Trainer where TId ='" + txtTid.Text + "'";
                cmd.ExecuteNonQuery();//need dataadapter when do search 
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dgvTrainer.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("The Trainer Id is not found!!"); // there is another one- null or empty show message - type the name = using (if)
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

        private void btnRe_Click(object sender, EventArgs e)
        {
            Showdata();
            txtTid.Text = "";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F5 = new Form5();
            this.Hide();
            F5.Show();
        }

        private void dgvTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
