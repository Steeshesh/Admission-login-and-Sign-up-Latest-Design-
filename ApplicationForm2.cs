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
    public partial class ApplicationForm2 : Form
    {
        public ApplicationForm2()
        {
            InitializeComponent();
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
            // Check if not all required buttons have been clicked/uploaded
            if (!IsDocumentUploaded(FormalPic) || !IsDocumentUploaded(Record) || !IsDocumentUploaded(BirthCert) || !IsDocumentUploaded(GoodMorals))
            {
                // If any button has not been clicked/uploaded, show an error message
                MessageBox.Show("Please upload all required documents before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Optionally, highlight the first missing document by focusing on the respective button
                if (!IsDocumentUploaded(FormalPic))
                {
                    FormalButton.Focus();  // Focus on the missing button
                }
                else if (!IsDocumentUploaded(Record))
                {
                    TORButton.Focus();
                }
                else if (!IsDocumentUploaded(BirthCert))
                {
                    BCertButton.Focus();
                }
                else if (!IsDocumentUploaded(GoodMorals))
                {
                    GMoralButton.Focus();
                }
            }
            else
            {
                // If all buttons have a document uploaded, proceed to the next form
                MessageBox.Show("All required files are uploaded. Proceeding to Status.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                new Status().Show();  // Proceed to the status form
                this.Hide();
            }
        }

        // Helper method to check if a document has been uploaded (by checking the ImageLocation of PictureBox)
        private bool IsDocumentUploaded(PictureBox pictureBox)
        {
            return !string.IsNullOrEmpty(pictureBox.ImageLocation);  // Check if ImageLocation is not empty
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void informations_Paint(object sender, PaintEventArgs e)
        {
            informations.BackColor = Color.FromArgb(150, Color.Black);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void FormalButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jgp files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    FormalPic.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Provide a Valid Photo", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TORButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jgp files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    Record.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Provide a Valid Photo", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCertButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jgp files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    BirthCert.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Provide a Valid Photo", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Error); // kahit wala na to pede nyo ilagay lahat ng error validation sa submit button
            }
        }

        private void GMoralButton_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jgp files(*.jpg)|*.jpg| PNG files(*.png)|*.png| ALL Files(*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    GoodMorals.ImageLocation = imageLocation;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Provide a Valid Photo", "NOTICE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Backbtn_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();//it does not save the recent input so nag rerefresh pag bumabalik
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ProgramSelection_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtCourseDip_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormalPic_Click(object sender, EventArgs e)
        {

        }
    }
}
