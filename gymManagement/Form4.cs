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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Documents\gym.mdf;Integrated Security=True;Connect Timeout=30");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {String gender = "";
            if (rdbMale.Checked == true)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
          


            
            
                
                try
            {
                if (string.IsNullOrEmpty(txtFname.Text))
                {
                    MessageBox.Show("Please put name before register.");
                    return;
                }
                if (string.IsNullOrEmpty(txtAge.Text))
                {
                    MessageBox.Show("Please put age before register.");
                    return;
                }
                if (string.IsNullOrEmpty(gender))
                {
                    MessageBox.Show("Please select gender before register.");
                    return;
                }
                if (string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Please put email before register.");
                    return;
                }
                if (string.IsNullOrEmpty(txtPh.Text))
                {
                    MessageBox.Show("Please put phone before register.");
                    return;
                }
                if (string.IsNullOrEmpty(txtWeight.Text))
                {
                    MessageBox.Show("Please put weight before register.");
                    return;
                }
                if (string.IsNullOrEmpty(txtHeight.Text))
                {
                    MessageBox.Show("Please put height before insert.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbMembership.Text))
                {
                    MessageBox.Show("Please put membership before insert.");
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Register (name, age, gender, email, phone, weight, height, membership) " +
                                  "VALUES (@Name, @Age, @Gender, @Email, @Phone, @Weight, @Height, @Membership)";

                // Add parameters//to set the values of the SQL query parameters//prevent errors due to exceeding maximum query lengths or encountering issues with special characters.
                
                cmd.Parameters.AddWithValue("@Name", txtFname.Text);
                cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPh.Text);
                cmd.Parameters.AddWithValue("@Weight", txtWeight.Text);
                cmd.Parameters.AddWithValue("@Height", txtHeight.Text);
                cmd.Parameters.AddWithValue("@Membership", cmbMembership.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registered Successfully!! Wait The admin will give you username and password.");
                var F2 = new Form2();
                this.Hide();
                F2.Show();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)//do auto id in sql file with In the "Column Properties" window, find the "Identity Specification" section.
//Set the "Identity" property to "Yes" and configure the "Identity Increment" and "Identity Seed" properties as needed.
        {

           // try
           // {
               
                
               // con.Open();

                    //SqlDataAdapter sda = new SqlDataAdapter("SELECT ISNULL(MAX(CAST(RId AS INT)), 0) + 1 FROM Register", con);
                    //DataTable dt = new DataTable();
                    //sda.Fill(dt);
                    //txtRid.Text = dt.Rows[0][0].ToString();
                //con.Close();
                
           // }
            //catch (Exception ex)
            //{
             //   MessageBox.Show( ex.Message);
            //}
       }
    }
}
