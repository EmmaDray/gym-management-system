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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        public void cmbEnrollFill()
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Enroll";
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
                        cmbE.Items.Add(dt.Rows[j]["EId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
                        cmbC.Items.Add(dt.Rows[j]["CId"]);
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
                        cmbT.Items.Add(dt.Rows[j]["TId"]);
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
                        cmbM.Items.Add(dt.Rows[j]["MId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void displayData()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select* from Enroll";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                dgvEnrol.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void Form9_Load(object sender, EventArgs e)
        {
            displayData();
            cmbClassFill();
            cmbEnrollFill();
            cmbTrainerFill();
            cmbMemberFill();
        }

        private void dgvEnrol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow i = dgvEnrol.Rows[e.RowIndex];
                cmbE.Text = i.Cells[0].Value.ToString();
                cmbC.Text = i.Cells[1].Value.ToString();


                cmbT.Text = i.Cells[2].Value.ToString();
                cmbM.Text = i.Cells[3].Value.ToString();
                txtCw.Text = i.Cells[4].Value.ToString();

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbE.Text))
                {
                    MessageBox.Show("Please put Enrollment ID before update.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbC.Text))
                {
                    MessageBox.Show("Please put class id before update.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbT.Text))
                {
                    MessageBox.Show("Please select TrainerID before update.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbM.Text))
                {
                    MessageBox.Show("Please put Member id before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCw.Text))
                {
                    MessageBox.Show("Please put current weight before update.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Enroll set EId= '" + cmbE.Text + "',Cid= '" + cmbC.Text + "',Tid= '" + cmbT.Text + "', Mid = '" + cmbM.Text + "', CWeight = '" + txtCw.Text + "'where EId = '" + cmbE.Text + "' ";
                cmd.ExecuteNonQuery();
                
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Member information updated successfully.");
                    con.Close();
                    displayData();
                    clearEnrol();// Refresh the DataGridView with updated data

                }
                else
                {
                    MessageBox.Show("No member found with the selected Member ID.");
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
            displayData();
            clearEnrol();
           
        }
        public void clearEnrol()
        {
            cmbE.Text = "";
            cmbC.Text = "";
            cmbT.Text = "";
            cmbM.Text = "";
            txtCw.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbE.Text))
                {
                    MessageBox.Show("Please put Enrollment ID before Delete.");
                    return;
                }
                
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Enroll where EId ='" + cmbE.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted SuccessFully!!");
                displayData();
                clearEnrol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displayData();
            clearEnrol();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(cmbE.Text))
            {
                MessageBox.Show("Please fill the id for searth.");

            }
            else
            {
                try
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Enroll where EId ='" + cmbE.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count == 1)
                    {
                        dgvEnrol.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("The Enroll id is not found.");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
