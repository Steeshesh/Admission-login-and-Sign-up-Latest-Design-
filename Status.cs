using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class Status : Form
    {
        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
        {

        }

        private void Instructionbtn_Click(object sender, EventArgs e)
        {
            new DefaultPage().Show();
            this.Hide();
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            informations.BackColor = Color.FromArgb(150, Color.Black);
        }

        private void Applybtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
            this.Hide();
        }
    }
}
