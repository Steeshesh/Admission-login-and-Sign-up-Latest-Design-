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
            string username = txtUsername.Text.Trim();
            string password = PasswordInput.Text.Trim();

            var loginResult = Login1(username, password);

            if (loginResult.userType == "Student" && loginResult.userID.HasValue)
            {
                UserSession.Username = loginResult.username;
                UserSession.UserID = loginResult.userID.Value;
                UserSession.UserType = loginResult.userType;

                MessageBox.Show("Login successful! Redirecting to Default Page.");
                var defaultPage = new DefaultPage();
                defaultPage.Show();
                this.Hide();
            }
            else if (loginResult.userType == "Admin")
            {
                // Set admin session info
                UserSession.Username = loginResult.username;
                UserSession.UserType = loginResult.userType;

                MessageBox.Show("Welcome Admin!");

                // Show the admin form
                frmNavBar navBar = new frmNavBar();
                navBar.Show();
                this.Hide();

                // Clear the login form fields
                txtUsername.Clear();
                PasswordInput.Clear();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                PasswordInput.Clear();
                PasswordInput.Focus();
            }
        }

        // Keep only this version of Login1
        // Remove the duplicate method and keep only this one
        private (string userType, int? userID, string username) Login1(string username, string password)
        {
            string query = @"
        SELECT UserType, UserID 
        FROM account 
        WHERE Username = @username 
        AND Password = @password";

            using (var conn = database.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userType = reader["UserType"].ToString();
                            int? userId = null;

                            // Handle both Admin and Student UserIDs
                            if (reader["UserID"] != DBNull.Value)
                            {
                                userId = Convert.ToInt32(reader["UserID"]);
                            }

                            return (
                                userType: userType,
                                userID: userId,
                                username: username
                            );
                        }
                    }
                }
            }
            return (null, null, null);
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

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            frmHome HomePage = new frmHome();
            this.Hide();
            HomePage.Show();
            HomePage.FormClosed += (s, args) => this.Close();
        }
    }
}
