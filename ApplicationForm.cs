﻿using System;
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
        public ApplicationForm()
        {
            InitializeComponent();
        }

        private void ApplicationForm_Load(object sender, EventArgs e)
        {

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

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            Nextbtn.BackColor = Color.FromArgb(150, Color.Black);
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

            // If all fields are filled and phone number is valid, continue with your submission logic here.
            MessageBox.Show("All fields are valid. Proceeding with submission.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            new ApplicationForm2().Show();
            this.Hide();
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

        private void DateOfBirth_Enter_1(object sender, EventArgs e)
        {
            if(DateOfBirth.Text == "YYYY-MM-DD")
            {
                DateOfBirth.Text = "";
                DateOfBirth.ForeColor = Color.Black;
            }
        }

        private void DateOfBirth_Leave_1(object sender, EventArgs e)
        {
            if (DateOfBirth.Text == "")
            {
                DateOfBirth.Text = "YYYY-MM-DD";
                DateOfBirth.ForeColor = Color.DarkGray;
            }
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
    }
}
