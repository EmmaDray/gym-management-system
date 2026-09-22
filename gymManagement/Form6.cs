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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void displayData()
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
                dgvClassM.DataSource = dt;
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
        private void Form6_Load(object sender, EventArgs e)
        {
            displayData();
            cmbTrainerFill();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtCId.Text))
                {
                    MessageBox.Show("Please put Class Id before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Please put name before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCapacity.Text))
                {
                    MessageBox.Show("Please put Capacity before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtPurpose.Text))
                {
                    MessageBox.Show("Please put purpose before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtStatus.Text))
                {
                    MessageBox.Show("Please put Status before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtDuration.Text))
                {
                    MessageBox.Show("Please put Duration before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtFee.Text))
                {
                    MessageBox.Show("Please put Fee before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbTid.Text))
                {
                    MessageBox.Show("Please put Trainer Id before insert.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Class(CId,name,capacity,purpose,status,duration,fee,TID) values('" + txtCId.Text + "', '" + txtName.Text + "', '" +txtCapacity.Text+ "', '" + txtPurpose.Text + "', '" + txtStatus.Text + "', '" +txtDuration.Text + "', '" +txtFee.Text + "','" +cmbTid.Text + "' )";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Class Information!!");
                con.Close();
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearClassinfo();
        }

        private void txtCapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCId.Text))
                {
                    MessageBox.Show("Please put Class Id before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Please put name before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtCapacity.Text))
                {
                    MessageBox.Show("Please put Capacity before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtPurpose.Text))
                {
                    MessageBox.Show("Please put purpose before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtStatus.Text))
                {
                    MessageBox.Show("Please put Status before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtDuration.Text))
                {
                    MessageBox.Show("Please put Duration before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtFee.Text))
                {
                    MessageBox.Show("Please put Fee before update.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbTid.Text))
                {
                    MessageBox.Show("Please put Trainer Id before update.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Class set CId= '" + txtCId.Text + "',name= '" + txtName.Text + "',capacity= '" + txtCapacity.Text + "', purpose = '" + txtPurpose.Text + "', status = '" + txtStatus.Text + "', duration = '" + txtDuration.Text + "', fee = '" + txtFee.Text + "', TID = '" + cmbTid.Text + "' where CId = '" + txtCId.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Successfully!!");
                displayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            clearClassinfo();
            con.Close();
        }

        private void dgvClassM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow i = dgvClassM.Rows[e.RowIndex];
                txtCId.Text = i.Cells[0].Value.ToString();
                txtName.Text = i.Cells[1].Value.ToString();
                txtCapacity.Text = i.Cells[2].Value.ToString();
                txtPurpose.Text = i.Cells[3].Value.ToString();

                txtStatus.Text = i.Cells[4].Value.ToString();
                txtDuration.Text = i.Cells[5].Value.ToString();
                txtFee.Text = i.Cells[6].Value.ToString();
                cmbTid.Text = i.Cells[7].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmdCheckChild = new SqlCommand("SELECT COUNT(*) FROM Enroll WHERE Cid = @ClassId", con);
                cmdCheckChild.Parameters.AddWithValue("@ClassId", txtCId.Text);
                int childCount = (int)cmdCheckChild.ExecuteScalar();
                if (childCount > 0)
                {
                    MessageBox.Show("Cannot delete this record because it is associated with records in the Enroll table. Please delete the associated records first.");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtCId.Text))
                    {
                        MessageBox.Show("Please put Class Id before delete.");
                        return;
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Class where CId ='" + txtCId.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        // No dependent records found, proceed with deletion
                    SqlCommand cmdDeleteTrainer = new SqlCommand("DELETE FROM Class WHERE CId = @ClassId", con);
                    cmdDeleteTrainer.Parameters.AddWithValue("@ClassId", txtCId.Text);
                    cmdDeleteTrainer.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully!!");
                    displayData();
                    clearClassinfo();
                    }
                    else
                    {
                        MessageBox.Show("The class id is not found.");
                    }
                    
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCId.Text))
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
                    cmd.CommandText = "select * from Class where CId ='" + txtCId.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count == 1)
                    {
                        dgvClassM.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("The class id is not found.");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void clearClassinfo()
        {
            

            txtCId.Text = "";
            txtName.Text = "";
            txtCapacity.Text = "";
            
            txtPurpose.Text = "";
            txtStatus.Text = "";
            txtStatus.Text = "";
            txtDuration.Text = "";
            txtFee.Text = "";
            cmbTid.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displayData();
            clearClassinfo();
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }
    }
}
