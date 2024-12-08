using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class ApplicationForm2 : Form
    {
        private Database db = new Database();

        public ApplicationForm2()
        {
            InitializeComponent();

            // Enable double buffering to reduce flickering
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
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
            LogOutUser();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LogOutUser();
        }

        private void LogOutUser()
        {
            // Clear the current user's session data
            UserSession.Clear();

            // Redirect to the Login form
            Login loginForm = new Login();
            loginForm.Show();

            // Close the current form
            this.Close();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!IsDocumentUploaded(FormalPic) || !IsDocumentUploaded(Record) ||
                !IsDocumentUploaded(BirthCert) || !IsDocumentUploaded(GoodMorals))
            {
                MessageBox.Show("Please upload all required documents before proceeding.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!IsDocumentUploaded(FormalPic)) FormalButton.Focus();
                else if (!IsDocumentUploaded(Record)) TORButton.Focus();
                else if (!IsDocumentUploaded(BirthCert)) BCertButton.Focus();
                else if (!IsDocumentUploaded(GoodMorals)) GMoralButton.Focus();
            }
            else
            {
                // Update document requirements
                bool docReqUpdated = db.ExecuteQuery(
                    "UPDATE docreqs SET FormalPicture = @FormalPicture, BirthCertificate = @BirthCertificate, TranscriptOfRecords = @TranscriptOfRecords, GoodMorals = @GoodMorals WHERE UserID = @UserID",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                        cmd.Parameters.AddWithValue("@FormalPicture", FormalPic.ImageLocation);
                        cmd.Parameters.AddWithValue("@BirthCertificate", BirthCert.ImageLocation);
                        cmd.Parameters.AddWithValue("@TranscriptOfRecords", Record.ImageLocation);
                        cmd.Parameters.AddWithValue("@GoodMorals", GoodMorals.ImageLocation);
                    });

                // Update program selection
                bool programUpdated = db.ExecuteQuery(
                    "UPDATE program SET ProgramName = @ProgramName WHERE UserID = @UserID",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                        cmd.Parameters.AddWithValue("@ProgramName", ProgramName.Text);
                    });

                //Update status
                bool statusUpdated = db.ExecuteQuery(
                    "UPDATE status SET ReqStatus = 'Pending' WHERE UserID = @UserID",
                    cmd =>
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
                    });

                // Verify success and notify user
                if (docReqUpdated && programUpdated)
                {
                    MessageBox.Show("Application submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    new Status().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to submit application. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool IsDocumentUploaded(PictureBox pictureBox)
        {
            return !string.IsNullOrEmpty(pictureBox.ImageLocation);
        }

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            //using (SolidBrush brush = new SolidBrush(Color.FromArgb(150, Color.Black)))
            {
                // e.Graphics.FillRectangle(brush, informations.ClientRectangle);
            }
        }

        private void FormalButton_Click(object sender, EventArgs e)
        {
            UploadDocument(FormalPic);
        }

        private void TORButton_Click(object sender, EventArgs e)
        {
            UploadDocument(Record);
        }

        private void BCertButton_Click(object sender, EventArgs e)
        {
            UploadDocument(BirthCert);
        }

        private void GMoralButton_Click(object sender, EventArgs e)
        {
            UploadDocument(GoodMorals);
        }

        private void UploadDocument(PictureBox pictureBox)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Filter = "Image files (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg|All files (*.*)|*.*"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox.ImageLocation = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Provide a Valid Photo", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
            this.Hide();
        }

        // Retained empty event handlers and methods to avoid breaking references in other parts of the code
        private void ApplicationForm2_Load(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void ProgramSelection_Enter(object sender, EventArgs e) { }
        private void FormalPic_Click(object sender, EventArgs e) { }

        private void ProgramName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
