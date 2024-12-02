using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class Login : Form
    {
        private Database database;

        public Login()
        {
            InitializeComponent();
            database = new Database();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Get username and password from text boxes
            string username = txtUsername.Text.Trim();
            string password = PasswordInput.Text.Trim();

            // Call Login function to validate credentials and retrieve user type
            string userType = Login1(username, password);

            if (userType == "Student")
            {
                MessageBox.Show("Login successful! Redirecting to Default Page.");
                new DefaultPage().Show();
                this.Hide();
            }
            else if (userType == "Admin")
            {
                MessageBox.Show("Welcome Admin. Returning to Login page for now.");
                txtUsername.Text = "";
                PasswordInput.Text = "";
                PasswordInput.Focus();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                PasswordInput.Text = "";
                PasswordInput.Focus();
            }
        }

        private string Login1(string username, string password)
        {
            string query = "SELECT UserType FROM account WHERE Username = @username AND Password = @password";
            object result = database.ExecuteScalar(query, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
            });

            return result?.ToString(); // Return the UserType if found, otherwise null
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                PasswordInput.PasswordChar = '\0';
            }
            else
            {
                PasswordInput.PasswordChar = '*';
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Signup().Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
    }
}
