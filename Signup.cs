using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class Signup : Form
    {

        private Database database;
        public Signup()
        {
            InitializeComponent();
            database = new Database();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Check if fields are empty
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Username and Password fields cannot be empty", "Sign up failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match, please re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Call RegisterUser function to add user to the database
            if (RegisterUser(username, password))
            {
                MessageBox.Show("Your account has been successfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Clear();
                txtPassword.Clear();
                txtConPassword.Clear();
            }
            else
            {
                MessageBox.Show("Username already exists. Please try a different one.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RegisterUser(string username, string password)
        {
            // Check if the username already exists
            string checkUserQuery = "SELECT COUNT(*) FROM AccountInformation WHERE Username = @username";
            object result = database.ExecuteScalar(checkUserQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
            });

            if (result != null && Convert.ToInt32(result) > 0)
            {
                return false; // Username already exists
            }

            // Register the new user
            string registerQuery = "INSERT INTO AccountInformation (Username, Password) VALUES (@username, @password)";
            return database.ExecuteQuery(registerQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
            });
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            char passwordChar = checkbxShowPas.Checked ? '\0' : '*';
            txtPassword.PasswordChar = passwordChar;
            txtConPassword.PasswordChar = passwordChar;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtConPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
