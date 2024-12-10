using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class frmCourses : Form
    {
        private int cpt = 0;
        private readonly List<Image> images = new List<Image>();
        private readonly List<string> quotes = new List<string>();
        private readonly List<string> programNames = new List<string>();
        private readonly List<string> programDescriptions = new List<string>();
        private readonly List<(double employment, double passing, double graduation, double acceptance)> programRates = new List<(double, double, double, double)>();

        public frmCourses()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadInitialData();
            this.Load += new EventHandler(frmCourses_Load);
        }

        private void SetupDataGridView()
        {
            // Configure DataGridView
            guna2DataGridView1.Visible = false; // Keep it hidden but use it as storage
            guna2DataGridView1.Columns.Clear();
            guna2DataGridView1.Columns.Add(new DataGridViewImageColumn { Name = "Images" });
        }

        private void LoadInitialData()
        {
            try
            {
                // Store images in resources
                var imageList = new List<Image>
            {
                Properties.Resources.School_of_Law_SOL_1030x1030,
                Properties.Resources.IAD_LOGO_PNG_300x300,
                Properties.Resources.ION_color_logo_300x300,
                Properties.Resources.IOP_logo_300x300,
                Properties.Resources.IOA_LOGO_300x300,
                Properties.Resources.cbfs_logo_300x300,
                Properties.Resources.CCIS_Logo_Official_1_1_300x300
            };

                // Add images to DataGridView
                foreach (var img in imageList)
                {
                    guna2DataGridView1.Rows.Add(img);
                    images.Add(img);
                }

                // Add other data
                programRates.AddRange(new[]
                {
                (92.5, 87.3, 89.1, 45.0),
                (88.7, 91.2, 93.5, 65.0),
                (95.8, 89.7, 91.2, 70.0),
                (94.2, 88.5, 90.8, 55.0),
                (91.5, 86.9, 88.4, 60.0),
                (93.1, 88.2, 89.7, 58.0),
                (96.3, 90.5, 92.1, 52.0)
            });

                programNames.AddRange(new[]
                {
                "School of Law",
                "Institute of Art and Design",
                "Institute of Nursing",
                "Institute of Pharmacy",
                "Institute of Accounting",
                "College of Business and Finance",
                "College of Computing and Information Sciences"
            });

                // Rest of your lists...

                if (guna2DataGridView1.Rows.Count > 0)
                {
                    UpdateDisplay(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading initial data: {ex.Message}");
            }
        }

        private void UpdateDisplay(int index)
        {
            if (index < 0 || index >= guna2DataGridView1.Rows.Count) return;

            try
            {
                // Get image from DataGridView
                var cellValue = guna2DataGridView1.Rows[index].Cells[0].Value;
                if (cellValue is Image img)
                {
                    guna2PictureBox_ccis.Image?.Dispose();
                    guna2PictureBox_ccis.Image = new Bitmap(img);
                    quotesText.Text = quotes[index];
                    gunaLabel_name.Text = programNames[index];
                    labelDescription.Text = programDescriptions[index];
                    employmentRate.Text = $"{programRates[index].employment}%";
                    passingRate.Text = $"{programRates[index].passing}%";
                    graduationRate.Text = $"{programRates[index].graduation}%";
                    acceptanceRate.Text = $"{programRates[index].acceptance}%";
                    guna2PictureBox_ccis.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating display: {ex.Message}");
            }
        }


        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (images.Count == 0) return;
            cpt = (cpt + 1) % images.Count;
            UpdateDisplay(cpt);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            if (images.Count == 0) return;
            cpt = (cpt - 1 + images.Count) % images.Count;
            UpdateDisplay(cpt);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmHome HomePage = new frmHome();
            this.Hide();
            HomePage.Show();
            HomePage.FormClosed += (s, args) => this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                base.OnFormClosing(e);
                foreach (Image img in images)
                {
                    img?.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error closing form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}