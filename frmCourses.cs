using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System;
using System.Linq;
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
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Load += new EventHandler(frmCourses_Load);

        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            LoadContent();
        }

        private void LoadContent()
        {
            try
            {
                // Path to the directory containing course pictures
                string basePath = Path.Combine(Application.StartupPath, "CoursesPics");

                // Check if the directory exists
                if (!Directory.Exists(basePath))
                {
                    MessageBox.Show($"Course pictures directory not found: {basePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mapping program names to their corresponding image file names
                var programToImageMap = new Dictionary<string, string>
        {
            { "School of Law", "School-of-Law-SOL-1030x1030.png" },
            { "Institute of Art and Design", "IAD-LOGO-PNG-300x300.png" },
            { "Institute of Nursing", "ION-color-logo-300x300.png" },
            { "Institute of Pharmacy", "IOP-logo-300x300.png" },
            { "Institute of Accounting", "IOA-LOGO-300x300.png" },
            { "College of Business and Finance", "cbfs-logo-300x300.png" },
            { "College of Computing and Information Sciences", "CCIS-Logo-Official-1-1-300x300.png" }
        };

                images.Clear();

                foreach (var entry in programToImageMap)
                {
                    string imagePath = Path.Combine(basePath, entry.Value);

                    if (File.Exists(imagePath))
                    {
                        try
                        {
                            using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                            {
                                images.Add(Image.FromStream(stream));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error loading image {imagePath}: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Image not found for {entry.Key}: {imagePath}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Add program rates, names, descriptions, and quotes in the same order
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

                programNames.AddRange(programToImageMap.Keys);

                programDescriptions.AddRange(new[]
                {
            "• Champion justice and legal excellence\n• Master constitutional and civil rights law\n• Develop expertise in criminal and corporate law\n• Shape policy and advocate for change\n• Lead the future of legal practice",
            "• Express creativity through innovative design\n• Master digital and traditional art forms\n• Create compelling visual narratives\n• Learn industry-standard design tools\n• Shape the future of visual communication",
            "• Provide compassionate patient care\n• Master advanced clinical skills\n• Lead healthcare innovation\n• Develop specialized nursing expertise\n• Transform lives through quality care",
            "• Advance pharmaceutical research\n• Develop life-saving medications\n• Master drug development processes\n• Lead healthcare innovation\n• Improve patient outcomes",
            "• Master financial analysis and reporting\n• Lead audit and compliance initiatives\n• Develop strategic business insights\n• Navigate complex financial systems\n• Shape future financial practices",
            "• Drive business innovation and growth\n• Master global financial markets\n• Develop strategic leadership skills\n• Lead organizational transformation\n• Shape the future of commerce",
            "• Innovate through code and technology\n• Master cutting-edge development tools\n• Lead digital transformation\n• Develop AI and machine learning solutions\n• Shape the future of technology"
        });

                quotes.AddRange(new[]
                {
            "Justice is the foundation of peace.",
            "Creativity takes courage.",
            "Caring is the essence of nursing.",
            "Pharmacy is the science of wellness.",
            "Accounting is the language of business.",
            "Business is the catalyst of progress.",
            "Innovation starts with code."
        });

                if (images.Count > 0)
                {
                    UpdateDisplay(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading content: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UpdateDisplay(int index)
        {
            if (index < 0 || index >= images.Count) return;

            try
            {
                guna2PictureBox_ccis.Image?.Dispose();
                guna2PictureBox_ccis.Image = new Bitmap(images[index]);
                quotesText.Text = quotes[index];
                gunaLabel_name.Text = programNames[index];
                labelDescription.Text = programDescriptions[index];
                employmentRate.Text = $"{programRates[index].employment}%";
                passingRate.Text = $"{programRates[index].passing}%";
                graduationRate.Text = $"{programRates[index].graduation}%";
                acceptanceRate.Text = $"{programRates[index].acceptance}%";
                guna2PictureBox_ccis.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating display: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            // Create the coursePage
            frmHome AboutPage = new frmHome();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            frmAbout AboutPage = new frmAbout();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            Login AboutPage = new Login();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            Signup AboutPage = new Signup();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }
    }
}