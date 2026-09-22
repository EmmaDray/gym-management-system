using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymManagement
{
    public partial class Form5 : Form
    {
        bool sidebarExpand;
        public Form5()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebar.MinimumSize.Width) // Changed condition here
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else // Removed the redundant else block
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void Menubutton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btnViewClass_Click(object sender, EventArgs e)
        {
            var F12 = new Form12();
            this.Hide();
            F12.Show();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            var F14 = new Form14();
            this.Hide();
            F14.Show();
        }

        private void btnViewTrainer_Click(object sender, EventArgs e)
        {
            var F13 = new Form13();
            this.Hide();
            F13.Show();
        }
    }
}
