using System;
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
            // Empty for now, if needed in future.
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed.
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Handle label click if needed.
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Handle label click if needed.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed.
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Handle label click if needed.
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            // Handle panel paint event if needed.
        }

        private void SignupButton_Click(object sender, EventArgs e)
        {
            // Get input from fields
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConPassword.Text.Trim();

            // Check if any fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("All fields are required.", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();
                return;
            }

            // Call the registration function
            if (RegisterUser(username, password))
            {
                MessageBox.Show("Account successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            else
            {
                MessageBox.Show("The username already exists. Please try a different one.", "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RegisterUser(string username, string password)
        {
            // Check if username already exists
            string checkUserQuery = "SELECT COUNT(*) FROM account WHERE Username = @username";
            object result = database.ExecuteScalar(checkUserQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
            });

            if (result != null && Convert.ToInt32(result) > 0)
            {
                return false; // Username already exists
            }

            // Insert a new row in user and retrieve the UserID
            string insertUserQuery = "INSERT INTO user (FirstName, MiddleName, LastName, Gender, DateOfBirth, Nationality, FathersName, MothersName, GuardiansName) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";
            int userId = database.ExecuteInsertAndReturnId(insertUserQuery, null);

            if (userId == -1)
            {
                MessageBox.Show("An error occurred while creating the user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Insert the account details in account
            string registerQuery = "INSERT INTO account (Username, Password, UserID, UserType) VALUES (@username, @password, @userId, 'Student')";
            bool accountInserted = database.ExecuteQuery(registerQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@userId", userId);
            });

            if (!accountInserted)
            {
                MessageBox.Show("An error occurred while creating the account. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Insert placeholder rows for academic, contact, docreqs, and program tables
            string insertAcademicQuery = "INSERT INTO academic (UserID, HighSchoolName, HighSchoolAddress, Strand, GeneralWeightedAverage) VALUES (@userId, NULL, NULL, NULL, NULL)";
            string insertContactQuery = "INSERT INTO contact (UserID, PhoneNo, EmailAddress, HomeAddress, GuardiansNo) VALUES (@userId, NULL, NULL, NULL, NULL)";
            string insertDocReqsQuery = "INSERT INTO docreqs (UserID, FormalPicture, BirthCertificate, TranscriptOfRecords, GoodMorals) VALUES (@userId, NULL, NULL, NULL, NULL)";
            string insertProgramQuery = "INSERT INTO program (UserID, ProgramName) VALUES (@userId, NULL)";

            bool academicInserted = database.ExecuteQuery(insertAcademicQuery, cmd => cmd.Parameters.AddWithValue("@userId", userId));
            bool contactInserted = database.ExecuteQuery(insertContactQuery, cmd => cmd.Parameters.AddWithValue("@userId", userId));
            bool docReqsInserted = database.ExecuteQuery(insertDocReqsQuery, cmd => cmd.Parameters.AddWithValue("@userId", userId));
            bool programInserted = database.ExecuteQuery(insertProgramQuery, cmd => cmd.Parameters.AddWithValue("@userId", userId));

            if (!academicInserted || !contactInserted || !docReqsInserted || !programInserted)
            {
                MessageBox.Show("An error occurred while setting up additional data. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; // User successfully registered
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConPassword.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Handle label click if needed.
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
            // Handle label click if needed.
        }

        private void txtConPassword_TextChanged(object sender, EventArgs e)
        {
            // Handle text change if needed.
        }
    }
}
