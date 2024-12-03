using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class ApplicationForm2 : Form
    {
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

        private void Logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!IsDocumentUploaded(FormalPic) || !IsDocumentUploaded(Record) || !IsDocumentUploaded(BirthCert) || !IsDocumentUploaded(GoodMorals))
            {
                MessageBox.Show("Please upload all required documents before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!IsDocumentUploaded(FormalPic)) FormalButton.Focus();
                else if (!IsDocumentUploaded(Record)) TORButton.Focus();
                else if (!IsDocumentUploaded(BirthCert)) BCertButton.Focus();
                else if (!IsDocumentUploaded(GoodMorals)) GMoralButton.Focus();
            }
            else
            {
                MessageBox.Show("All required files are uploaded. Proceeding to Status.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new Status().Show();
                this.Hide();
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
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void ProgramSelection_Enter(object sender, EventArgs e) { }
        private void txtCourseDip_SelectedIndexChanged(object sender, EventArgs e) { }
        private void FormalPic_Click(object sender, EventArgs e) { }
    }
}
