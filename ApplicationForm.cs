    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Admission_login_and_Sign_up__Latest_Design_
    {
        public partial class ApplicationForm : Form
        {
        private Database database;
            public ApplicationForm()
            {
                InitializeComponent();
                database = new Database();
                EnableDoubleBuffering(this);
                // Enable double buffering to prevent flickering
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                              ControlStyles.AllPaintingInWmPaint |
                              ControlStyles.UserPaint, true);
                this.UpdateStyles();
            }

            private void ApplicationForm_Load(object sender, EventArgs e)
            {

            }
        private void UpdateUI()
        {
            this.SuspendLayout();

            // Perform UI updates here
            Nextbtn.BackColor = Color.FromArgb(150, Color.Black);
            // Add other UI updates if needed

            this.ResumeLayout();
        }
        private void EnableDoubleBuffering(Control control)
        {
            if (control == null) return;

            foreach (Control child in control.Controls)
                EnableDoubleBuffering(child);

            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void Statusbtn_Click(object sender, EventArgs e)
            {
                new Status().Show();
                this.Hide();
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

        private void label7_Click(object sender, EventArgs e)
            {

            }

            private void Personalinfo_Enter(object sender, EventArgs e)
            {

            }

            private void NextButton_Click(object sender, EventArgs e)
            {
                // Define the TextBoxes (Your existing TextBox controls)
                TextBox[] textBoxes = { FirstName, MiddleName, LastName, DateOfBirth, Nationality, MotherName,
                                FatherName, GuardianName, PhoneNum, EmailAdd, HomeAdd,
                                GuardianNum, HSName, HSAddress, Strand, GWA };

                // Define the corresponding questions or labels for each TextBox
                string[] questionTexts = {
                  "First Name", "Middle Name", "Last Name", "Date of Birth", "Nationality", "Father's Name",
                  "Mother's Name", "Guardian's Name", "Phone Number", "Email Address", "Home Address",
                  "Guardian's Number", "High School Name", "High School Address", "Strand", "GWA"
                 };

                bool allAnswered = true;
                List<string> unansweredQuestions = new List<string>(); // List to track unanswered questions

                // Check for unanswered TextBoxes
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    if (string.IsNullOrEmpty(textBoxes[i].Text)) // If TextBox is empty
                    {
                        unansweredQuestions.Add(questionTexts[i]); // Add the question text for the unanswered field
                        allAnswered = false; // Mark as unanswered
                    }
                }

                // If there are unanswered TextBoxes, show validation messages
                if (!allAnswered)
                {
                    // Display an error message for each unanswered question
                    foreach (var questionText in unansweredQuestions)
                    {
                        MessageBox.Show($"{questionText} is empty. Please make sure that ALL fields are filled.",
                                        "Submission Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                    }
                    return; // Stop further checks until user answers the skipped or no answer question/s
                }

                // Validate the Date of Birth (DateOfBirth TextBox)
                string dateOfBirth = DateOfBirth.Text;

                // Try to parse the Date of Birth in the required format (e.g., "MM/dd/yyyy")
                DateTime parsedDateOfBirth;
                string[] validDateFormats = { "MM/dd/yyyy", "yyyy-MM-dd", "dd/MM/yyyy" }; // Define acceptable formats

                if (string.IsNullOrEmpty(dateOfBirth) || !DateTime.TryParseExact(dateOfBirth, validDateFormats,
                                                    System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None,
                                                    out parsedDateOfBirth))
                {
                    MessageBox.Show("Please enter a valid birth date in the format MM/dd/yyyy, dd/MM/yyyy, or yyyy-MM-dd.",
                                    "Date of Birth",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Stop further execution if the birth date is invalid
                }

                // Validate the Gmail email address format (EmailAdd TextBox)
                string emailAddress = EmailAdd.Text;
                string gmailRegex = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";  // Regex for validating Gmail address

                if (string.IsNullOrEmpty(emailAddress) || !Regex.IsMatch(emailAddress, gmailRegex))
                {
                    MessageBox.Show("Please enter a valid Gmail address (e.g., example@gmail.com).",
                                    "Invalid Email",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return; // Stop further execution if the email format is invalid
                }

                // Validate the phone number (PhoneNum TextBox)
                string phoneNumber = PhoneNum.Text;

                // Check if the phone number is empty or invalid
                if (string.IsNullOrEmpty(phoneNumber) || !phoneNumber.All(char.IsDigit) || phoneNumber.Length != 11)
                {
                    MessageBox.Show("Please enter a valid 11-digit phone number.", "Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if the phone number is invalid
                }

                // Validate the guardian number (guardianNum TextBox)
                string guardianNum = GuardianNum.Text;

                // Check if the phone number is empty or invalid
                if (string.IsNullOrEmpty(guardianNum) || !guardianNum.All(char.IsDigit) || guardianNum.Length != 11)
                {
                    MessageBox.Show("Please enter a valid 11-digit guardian number.", "Guardian Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if the phone number is invalid
                }

                // Validate the GWA (GWA TextBox)
                string gwa = GWA.Text;

                // Check if the GWA is empty or cannot be parsed to a valid double
                if (string.IsNullOrEmpty(gwa) || !double.TryParse(gwa, out double gwaValue))
                {
                    MessageBox.Show("Please enter a valid Grade Weighted Average (GWA). It must have two decimal places only.", "GWA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if the GWA is invalid
                }

                // Optionally, you can add constraints like minimum and maximum values for GWA
                if (gwaValue < 1.00 || gwaValue > 5.00)  // Assuming GWA ranges from 0 to 5
                {
                    MessageBox.Show("Please enter a valid GWA between 1.0 and 5.0.", "GWA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further execution if the GWA is out of range
                }

                // Define the RadioButton controls to check if at least one is selected
                RadioButton[] radioButtons = { MaleButton, FemaleButton }; // Example array of radio buttons

                bool radioButtonsAnswered = false;

                // Check if at least one radio button is checked
                foreach (var radioButton in radioButtons)
                {
                    if (radioButton.Checked)
                    {
                        radioButtonsAnswered = true; // If any radio button is checked, mark as answered
                        break; // Exit the loop if we find a selected radio button
                    }
                }

                // If no radio button is selected, show a message
                if (!radioButtonsAnswered)
                {
                    MessageBox.Show("Please select a gender", "Gender", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Stop further checks until user answers the radio button questions
                }

            // Assuming UserSession is a static class that holds information about the current user
            int userId = UserSession.UserID; // Replace with the correct way to get the logged-in user's ID

            if (userId == 0)
            {
                MessageBox.Show("Invalid user session. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prepare the update queries
            string updateUserQuery = @"UPDATE user 
                               SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, 
                                   Gender = @Gender, DateOfBirth = @DateOfBirth, Nationality = @Nationality, 
                                   FathersName = @FathersName, MothersName = @MothersName, GuardiansName = @GuardiansName, AppStatus = 'Pending'
                               WHERE UserID = @UserID";

            string updateAcademicQuery = @"UPDATE academic 
                                   SET HighSchoolName = @HighSchoolName, HighSchoolAddress = @HighSchoolAddress, 
                                       Strand = @Strand, GeneralWeightedAverage = @GWA
                                   WHERE UserID = @UserID";

            string updateContactQuery = @"UPDATE contact 
                                  SET PhoneNo = @PhoneNo, EmailAddress = @EmailAddress, HomeAddress = @HomeAddress, 
                                      GuardiansNo = @GuardiansNo
                                  WHERE UserID = @UserID";

            // Execute the queries
            bool userUpdated = database.ExecuteQuery(updateUserQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@FirstName", FirstName.Text);
                cmd.Parameters.AddWithValue("@MiddleName", MiddleName.Text);
                cmd.Parameters.AddWithValue("@LastName", LastName.Text);
                cmd.Parameters.AddWithValue("@Gender", MaleButton.Checked ? "Male" : "Female");
                cmd.Parameters.AddWithValue("@DateOfBirth", DateOfBirth.Text);
                cmd.Parameters.AddWithValue("@Nationality", Nationality.Text);
                cmd.Parameters.AddWithValue("@FathersName", FatherName.Text);
                cmd.Parameters.AddWithValue("@MothersName", MotherName.Text);
                cmd.Parameters.AddWithValue("@GuardiansName", GuardianName.Text);
                cmd.Parameters.AddWithValue("@UserID", userId);
            });

            bool academicUpdated = database.ExecuteQuery(updateAcademicQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@HighSchoolName", HSName.Text);
                cmd.Parameters.AddWithValue("@HighSchoolAddress", HSAddress.Text);
                cmd.Parameters.AddWithValue("@Strand", Strand.Text);
                cmd.Parameters.AddWithValue("@GWA", Convert.ToDecimal(GWA.Text));
                cmd.Parameters.AddWithValue("@UserID", userId);
            });

            bool contactUpdated = database.ExecuteQuery(updateContactQuery, cmd =>
            {
                cmd.Parameters.AddWithValue("@PhoneNo", PhoneNum.Text);
                cmd.Parameters.AddWithValue("@EmailAddress", EmailAdd.Text);
                cmd.Parameters.AddWithValue("@HomeAddress", HomeAdd.Text);
                cmd.Parameters.AddWithValue("@GuardiansNo", GuardianNum.Text);
                cmd.Parameters.AddWithValue("@UserID", userId);
            });

            // Check the results
            if (userUpdated && academicUpdated && contactUpdated)
            {
                MessageBox.Show("Your information has been successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new ApplicationForm2().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to update your information. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label9_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
            {
            
            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void DateOfBirth_TextChanged(object sender, EventArgs e)
            {

            }

            private void FatherName_TextChanged(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }
            private void MaleButton_CheckedChanged(object sender, EventArgs e)
            {

            }
            private void FirstName_TextChanged(object sender, EventArgs e)
            {

            }
            private void Nationality_TextChanged(object sender, EventArgs e)
            {

            }

            private void MiddleName_TextChanged(object sender, EventArgs e)
            {

            }

            private void PhoneNum_TextChanged(object sender, EventArgs e)
            {
            
            }

            private void FemaleButton_CheckedChanged(object sender, EventArgs e)
            {

            }

            private void EmailAdd_Enter(object sender, EventArgs e)
            {
                if (EmailAdd.Text == "Example@gmail.com")
                {
                    EmailAdd.Text = "";
                    EmailAdd.ForeColor = Color.Black;
                }
            }

            private void EmailAdd_Leave(object sender, EventArgs e)
            {
                if (EmailAdd.Text == "")
                {
                    EmailAdd.Text = "Example@gmail.com";
                    EmailAdd.ForeColor = Color.DarkGray;
                }
            }

            private void EmailAdd_TextChanged(object sender, EventArgs e)
            {

            }

            private void LastName_TextChanged(object sender, EventArgs e)
            {

            }

            private void MotherName_TextChanged(object sender, EventArgs e)
            {

            }

            private void GuardianName_TextChanged(object sender, EventArgs e)
            {

            }

            private void HomeAdd_TextChanged(object sender, EventArgs e)
            {

            }

            private void GuardianNum_TextChanged(object sender, EventArgs e)
            {

            }

            private void HSName_TextChanged(object sender, EventArgs e)
            {

            }

            private void HSAddress_TextChanged(object sender, EventArgs e)
            {

            }

            private void Strand_TextChanged(object sender, EventArgs e)
            {

            }

            private void GWA_TextChanged(object sender, EventArgs e)
            {

            }

            private void DateOfBirth_Enter(object sender, EventArgs e)
            {
                if (DateOfBirth.Text == "YYYY-MM-DD")
                {
                    DateOfBirth.Text = "";
                    DateOfBirth.ForeColor = Color.Black;
                }
            }

            private void DateOfBirth_Leave(object sender, EventArgs e)
            {
                if (DateOfBirth.Text == "")
                {
                    DateOfBirth.Text = "YYYY-MM-DD";
                    DateOfBirth.ForeColor = Color.DarkGray;
                }
            }

        private void Nextbtn_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
