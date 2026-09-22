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
    public partial class Form7 : Form
    {
        public Form7()
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
                cmd.CommandText = "select * from Member";
                cmd.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                con.Close();
                dgvMember.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void cmboRegisterFill()
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
                //int i = = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        cmbRId.Items.Add(dt.Rows[j]["RId"]);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                try
                {
                    con.Open();

                    // Check if a Register ID is selected
                    if (!string.IsNullOrEmpty(cmbRId.Text))
                {   // Check if the selected Register ID already exists in the Member table
                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Member WHERE RID = @RID", con);
                    checkCmd.Parameters.AddWithValue("@RID", cmbRId.Text);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("The selected Register ID is already associated with a Member ID.");
                        return;
                    }
                    // Retrieve data from Register table based on the selected Register ID
                    SqlCommand registerCmd = new SqlCommand("SELECT * FROM Register WHERE RId = @RId", con);
                        registerCmd.Parameters.AddWithValue("@RId", cmbRId.Text);
                        SqlDataReader reader = registerCmd.ExecuteReader();

                        // If data is found, populate Member fields
                        if (reader.Read())
                        {
                        string memberId = txtMid.Text;
                        if (string.IsNullOrEmpty(memberId))
                        {
                            MessageBox.Show("Please enter a Member ID.");
                            return;
                        }

                        txtMid.Text = memberId;

                        txtMname.Text = reader["name"].ToString();
                            txtAge.Text = reader["age"].ToString();

                        string registerGender = reader["gender"].ToString();
                        
                        if (registerGender == "Male")
                        {
                            rdbMale.Checked = true;
                            rdbFemale.Checked = false;

                        }
                        else
                        {
                            rdbFemale.Checked = true;
                            rdbMale.Checked = false;
                        }
                        txtEmail.Text = reader["email"].ToString();
                        txtPh.Text = reader["phone"].ToString();
                        txtWeight.Text = reader["weight"].ToString();
                        txtHeight.Text = reader["height"].ToString();
                        cmbmember.Text = reader["membership"].ToString();
                        reader.Close();
                        // Insert into Member table
                        SqlCommand cmd = new SqlCommand("INSERT INTO Member (MId, name, age, gender, email, phone, weight, height, membership, RID) " +
                                                        "VALUES (@MId, @Name, @Age, @Gender, @Email, @Phone, @Weight, @Height, @Membership, @RID)", con);

                        // Add parameters
                        cmd.Parameters.AddWithValue("@MId", txtMid.Text);
                        cmd.Parameters.AddWithValue("@Name", txtMname.Text);
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@Gender", registerGender);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtPh.Text);
                        cmd.Parameters.AddWithValue("@Weight", txtWeight.Text);
                        cmd.Parameters.AddWithValue("@Height", txtHeight.Text);
                        cmd.Parameters.AddWithValue("@Membership", cmbmember.Text);
                        cmd.Parameters.AddWithValue("@RID", cmbRId.Text);
                        
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Inserted Successfully");
                        displayData();
                        clearMember();
                        
                        }
                    else{
                        MessageBox.Show("No data found for the selected Register ID.");
                    }
                    
                    
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

        private void Form7_Load(object sender, EventArgs e)
        {
            displayData();
            cmboRegisterFill();
            
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            
            displayData();
            clearMember();
        }

        public void clearMember()
        {
            txtMid.Enabled = true;
            cmbRId.Enabled = true;
            
            txtMid.Text = "";
            txtMname.Text = "";
            txtAge.Text = "";
            rdbMale.Checked = false; // Assuming these are your radio buttons for gender
            rdbFemale.Checked = false;
            txtEmail.Text = "";
            txtPh.Text = "";
            txtWeight.Text = "";
            txtHeight.Text = "";
            cmbmember.SelectedIndex = -1; // Assuming this is your ComboBox for membership
            cmbRId.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var F5 = new Form5();
            this.Hide();
            F5.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

               

                // Check if there are dependent records in ChildTable2
                SqlCommand cmdCheckChild = new SqlCommand("SELECT COUNT(*) FROM Enroll WHERE Mid = @MemberId", con);
                cmdCheckChild.Parameters.AddWithValue("@memberId", txtMid.Text);
                int childCount = (int)cmdCheckChild.ExecuteScalar();

                
                if (childCount > 0)
                {
                    MessageBox.Show("Cannot delete this record because it is associated with records in the Enroll table. Please delete the associated records first.");
                }

                else
                {
                    if (string.IsNullOrEmpty(txtMid.Text))
                    {
                        MessageBox.Show("Please put Member Id before delete.");
                        return;
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from Member where MId ='" + txtMid.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    
                    if (dt.Rows.Count == 1)
                    {
                        // No dependent records found, proceed with deletion
                    SqlCommand cmdDeleteTrainer = new SqlCommand("DELETE FROM Member WHERE MId = @MemberId", con);
                    cmdDeleteTrainer.Parameters.AddWithValue("@memberId", txtMid.Text);
                    cmdDeleteTrainer.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully!!");
                    displayData();
                    clearMember();
                    }
                    else
                    {
                        MessageBox.Show("The member id is not found.");
                    }
                    
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                String gender = "";
                if (rdbMale.Checked == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                con.Open();

                // Check if a Member ID is selected
                if (!string.IsNullOrEmpty(txtMid.Text))
                {
                    // Check if the Register ID ComboBox is empty
                    if (string.IsNullOrEmpty(cmbRId.Text))
                    {
                        MessageBox.Show("Please select a Register ID.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtMname.Text))
                    {
                        MessageBox.Show("Please put name before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtAge.Text))
                    {
                        MessageBox.Show("Please put age before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(gender))
                    {
                        MessageBox.Show("Please select gender before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtEmail.Text))
                    {
                        MessageBox.Show("Please put email before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtPh.Text))
                    {
                        MessageBox.Show("Please put name before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtWeight.Text))
                    {
                        MessageBox.Show("Please put weight before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(txtHeight.Text))
                    {
                        MessageBox.Show("Please put height before update.");
                        return;
                    }
                    if (string.IsNullOrEmpty(cmbmember.Text))
                    {
                        MessageBox.Show("Please select membership type before update.");
                        return;
                    }
                    // Update the Member record in the database
                    SqlCommand cmd = new SqlCommand("UPDATE Member SET name = @Name, age = @Age, gender = @Gender, email = @Email, phone = @Phone, weight = @Weight, height = @Height, membership = @Membership WHERE MId = @MId", con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Name", txtMname.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);

                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPh.Text);
                    cmd.Parameters.AddWithValue("@Weight", txtWeight.Text);
                    cmd.Parameters.AddWithValue("@Height", txtHeight.Text);
                    cmd.Parameters.AddWithValue("@Membership", cmbmember.Text);
                    cmd.Parameters.AddWithValue("@MId", txtMid.Text);

                    // Execute the update command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Member information updated successfully.");
                        con.Close();
                        displayData();
                        clearMember();// Refresh the DataGridView with updated data
                        
                    }
                    else
                    {
                        MessageBox.Show("No member found with the selected Member ID.");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Member ID to update.");
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

        

        private void dgvMember_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtMid.Enabled = false;
                cmbRId.Enabled = false;
                DataGridViewRow i = dgvMember.Rows[e.RowIndex];
                txtMid.Text = i.Cells[0].Value.ToString();
                txtMname.Text = i.Cells[1].Value.ToString();
                txtAge.Text = i.Cells[2].Value.ToString();
                String g = i.Cells[3].Value.ToString().Trim();
                if (g == "Male")
                {
                    rdbMale.Checked = true;
                    rdbFemale.Checked = false;

                }
                else
                {
                    rdbFemale.Checked = true;
                    rdbMale.Checked = false;
                }
                txtEmail.Text = i.Cells[4].Value.ToString();
                txtPh.Text = i.Cells[5].Value.ToString();
                txtWeight.Text = i.Cells[6].Value.ToString();
                txtHeight.Text = i.Cells[7].Value.ToString();
                cmbmember.Text = i.Cells[8].Value.ToString();
                cmbRId.Text = i.Cells[9].Value.ToString();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMid.Text))
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
                    cmd.CommandText = "select * from Member where MId ='" + txtMid.Text + "' ";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter dp = new SqlDataAdapter(cmd);
                    dp.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count == 1)
                    {
                        dgvMember.DataSource = dt;
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

        private void button2_Click(object sender, EventArgs e)
        {
            var F3 = new Form3();
            this.Hide();
            F3.Show();
        }

        private void pictureBoxRe_Click(object sender, EventArgs e)
        {
            displayData();
            clearMember();
        }
    }
}
