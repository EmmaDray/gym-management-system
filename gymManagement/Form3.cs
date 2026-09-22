using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gymManagement
{
    public partial class Form3 : Form
    {
        bool sidebarExpand;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void gYMCLASSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F6 = new Form6();
            F6.Show();
            this.Hide();
        }

        private void qUITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F11 = new Form11();
            F11.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void mEMBERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F7 = new Form7();
            F7.Show();
            this.Hide();
        }

        private void tRAINERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F8 = new Form8();
            F8.Show();
            this.Hide();
        }

        private void eNROLMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F9 = new Form9();
            F9.Show();
            this.Hide();
        }

        private void uSERACCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var F10 = new Form10();
            F10.Show();
            this.Hide();
        }

        private void qUITToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            menuStrip1.Parent = siderbar1;
            menuStrip1.BackColor = Color.Transparent;
        }

        private void downTimer_Tick(object sender, EventArgs e)
        {
           

            if (sidebarExpand)
            {
                siderbar1.Height -= 10;
                if (siderbar1.Height <= siderbar1.MinimumSize.Height) // Changed condition here
                {
                    sidebarExpand = false;
                    downTimer.Stop();
                }
            }
            else // Removed the redundant else block
            {
                siderbar1.Height += 10;
                if (siderbar1.Height >= siderbar1.MaximumSize.Height)
                {
                    sidebarExpand = true;
                    downTimer.Stop();
                }
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            downTimer.Start();
        }
    }
}
