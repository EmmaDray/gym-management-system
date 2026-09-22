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
using System.Linq.Expressions;

namespace gymManagement
{
    public partial class Form8 : Form
    {
        public Form8()
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
                cmd.CommandText = "select* from Trainer";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                dgvTrainer.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            String gender = "";
            if(rdbTmale.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }


            try
            {
                if (string.IsNullOrEmpty(txtTid.Text))
                {
                    MessageBox.Show("Please put nid before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTname.Text))
                {
                    MessageBox.Show("Please put name before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Please select gender before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSpe.Text))
                {
                    MessageBox.Show("Please put specialization before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTemail.Text))
                {
                    MessageBox.Show("Please put email before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTage.Text))
                {
                    MessageBox.Show("Please put age before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(txtExp.Text))
                {
                    MessageBox.Show("Please put exprience before insert.");
                    return;
                }

                con.Open();
                SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Trainer WHERE TId = @TID", con);
                checkCmd.Parameters.AddWithValue("@TID", txtTid.Text);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("The selected Trainer ID is already exit.");
                    return;
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Trainer(TId,name,gender,specialization,email,age,Experience) values('" + txtTid.Text + "', '" + txtTname.Text+ "', '" + gender + "', '" + txtSpe.Text + "', '" + txtTemail.Text + "', '" + txtTage.Text + "', '" + txtExp.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Trainer!!");
                con.Close();
                displayData();
                clearTrainer();
            }
            catch(Exception ex)
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

        private void dgvTrainer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow i = dgvTrainer.Rows[e.RowIndex];
                txtTid.Text = i.Cells[0].Value.ToString();
                txtTname.Text = i.Cells[1].Value.ToString();
                String g = i.Cells[2].Value.ToString().Trim();
                if(g == "Male")
                {
                    rdbTmale.Checked = true;
                    rdbTfemale.Checked = false;

                }
                else
                {
                    rdbTfemale.Checked = true;
                    rdbTmale.Checked = false;
                }
                txtSpe.Text = i.Cells[3].Value.ToString();
                txtTemail.Text = i.Cells[4].Value.ToString(); 
                txtTage.Text = i.Cells[5].Value.ToString();
                txtExp.Text = i.Cells[6].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String gender = "";
            if(rdbTmale.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            try
            {
                if (string.IsNullOrEmpty(txtTid.Text))
                {
                    MessageBox.Show("Please put nid before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTname.Text))
                {
                    MessageBox.Show("Please put name before update.");
                    return;
                }
                if (string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Please select gender before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtSpe.Text))
                {
                    MessageBox.Show("Please put specialization before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTemail.Text))
                {
                    MessageBox.Show("Please put email before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtTage.Text))
                {
                    MessageBox.Show("Please put age before update.");
                    return;
                }
                if (string.IsNullOrEmpty(txtExp.Text))
                {
                    MessageBox.Show("Please put exprience before update.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Trainer set TId= '" + txtTid.Text + "',name= '" + txtTname.Text + "',gender= '" + gender + "', specialization = '" + txtSpe.Text + "', email = '" + txtTemail.Text + "', age = '" + txtTage.Text + "', Experience = '" + txtExp.Text + "' where TId = '" + txtTid.Text + "' ";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update Successfully!!");
                displayData();
                clearTrainer();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Check if there are dependent records in ChildTable1
                SqlCommand cmdCheckChild1 = new SqlCommand("SELECT COUNT(*) FROM Class WHERE TID = @TrainerId", con);
                cmdCheckChild1.Parameters.AddWithValue("@TrainerId", txtTid.Text);
                int child1Count = (int)cmdCheckChild1.ExecuteScalar();

                // Check if there are dependent records in ChildTable2
                SqlCommand cmdCheckChild2 = new SqlCommand("SELECT COUNT(*) FROM Enroll WHERE Tid = @TrainerId", con);
                cmdCheckChild2.Parameters.AddWithValue("@TrainerId", txtTid.Text);
                int child2Count = (int)cmdCheckChild2.ExecuteScalar();

                if (child1Count > 0 && child2Count > 0)
                {
                    MessageBox.Show("Cannot delete this record because it is associated with records in both Class and Enroll tables. Please delete the associated records first.");
                }
                else if (child1Count > 0)
                {
                    MessageBox.Show("Cannot delete this record because it is associated with records in the Class table. Please delete the associated records first.");
                }
                else if (child2Count > 0)
                {
                    MessageBox.Show("Cannot delete this record because it is associated with records in the Enroll table. Please delete the associated records first.");
                }

                else
                {
                    if (string.IsNullOrEmpty(txtTid.Text))
                    {
                        MessageBox.Show("Please put Trainer Id before delete.");
                        return;
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Trainer where TId ='" + txtTid.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count == 1)
                    {
                       // No dependent records found, proceed with deletion
                    SqlCommand cmdDeleteTrainer = new SqlCommand("DELETE FROM Trainer WHERE TId = @TrainerId", con);
                    cmdDeleteTrainer.Parameters.AddWithValue("@TrainerId", txtTid.Text);
                    cmdDeleteTrainer.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully!!");
                    displayData();
                    clearTrainer(); 
                    }
                    else
                    {
                        MessageBox.Show("The Trainer id is not found.");
                    }
                   
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtTid.Text))
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
                    cmd.CommandText = "select * from Trainer where TId ='" + txtTid.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if(dt.Rows.Count == 1)
                    {
                        dgvTrainer.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("The trainer id is not found.");
                    }
                    
                        
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            

        }
        public void clearTrainer()
        {
            txtTid.Text = "";
            txtTname.Text = "";
            
            rdbTmale.Checked = false; // Assuming these are your radio buttons for gender
            rdbTfemale.Checked = false;
            txtSpe.Text = "";
            txtTemail.Text = "";
            txtTage.Text = "";
            txtExp.Text = "";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            var F7 = new Form7();
            this.Hide();
            F7.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displayData();
            clearTrainer();
        }
    }
}
