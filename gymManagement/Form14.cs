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
using System.Xml.Linq;

namespace gymManagement
{
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");

        public void cmbClassFill()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Class";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                //int i = = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        cmbCid.Items.Add(dt.Rows[j]["CId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cmbTrainerFill()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Trainer";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                //int i = = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        cmbTid.Items.Add(dt.Rows[j]["TId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cmbMemberFill()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Member";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                //int i = = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        cmbMid.Items.Add(dt.Rows[j]["MId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void clearData()
        {
            txtEid.Text = "";
            cmbCid.Text = "";
            cmbTid.Text = "";
            cmbMid.Text = "";
            txtCurrent.Text = "";
        }
        private void btnEnrol_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEid.Text))
                {
                    MessageBox.Show("Please put Enrol Id before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbCid.Text))
                {
                    MessageBox.Show("Please put class Id before Enroll.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbTid.Text))
                {
                    MessageBox.Show("Please put Trainer Id before Enroll.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbMid.Text))
                {
                    MessageBox.Show("Please put member Id before Enroll.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCurrent.Text))
                {
                    MessageBox.Show("Please put current weight before insert.");
                    return;
                }
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Enroll (EId,Cid,Tid,Mid,CWeight) " +
                                  "VALUES (@EId, @Cid, @Tid, @Mid, @CWeight)";

                // Add parameters//to set the values of the SQL query parameters//prevent errors due to exceeding maximum query lengths or encountering issues with special characters.

                cmd.Parameters.AddWithValue("@EId", txtEid.Text);
                cmd.Parameters.AddWithValue("@Cid", cmbCid.Text);
                cmd.Parameters.AddWithValue("@Tid", cmbTid.Text);
                cmd.Parameters.AddWithValue("@Mid", cmbMid.Text);
                cmd.Parameters.AddWithValue("@CWeight", txtCurrent.Text);
                

                cmd.ExecuteNonQuery();
                MessageBox.Show("Enrolled Successfully!!");
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearData();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            cmbClassFill();
            cmbTrainerFill();
            cmbMemberFill();
            try
           {


            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("SELECT ISNULL(MAX(CAST(EId AS INT)), 0) + 1 FROM Enroll", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            txtEid.Text = dt.Rows[0][0].ToString();
            con.Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show( ex.Message);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F5 = new Form5();
            this.Hide();
            F5.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var F12 = new Form12();
            this.Hide();
            F12.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var F13 = new Form13();
            this.Hide();
            F13.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ask the Admin if you forgot it..");
        }
    }
}
