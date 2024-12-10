using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using Guna.UI2.WinForms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class frmAbout : Form
    {
        private string[] inspirationalMessages = new string[]
        {
        "Those who join our community—\n" +
        "to learn, research, teach, work, and grow\n" +
        "—join nearly four centuries of students \n" +
        "and scholars in the pursuit of truth,\n" +
        "knowledge, and a better world.",

        "Every student who walks through our doors—\n" +
        "driven by curiosity, passion, and purpose\n" +
        "—becomes part of a transformative journey\n" +
        "that transcends boundaries of thought,\n" +
        "innovation, and human potential.",

        "In this community of dreamers and doers—\n" +
        "where ideas spark, challenge, and evolve\n" +
        "—we forge paths of extraordinary impact,\n" +
        "connecting 120,000 alumni across\n" +
        "generations, disciplines, and continents.",

        "Our legacy is written not in stone—\n" +
        "but in the lives changed, barriers broken\n" +
        "—by minds that dare to reimagine\n" +
        "what is possible, what can be learned,\n" +
        "and how we can reshape our world.",

        "From this singular place of learning—\n" +
        "where wisdom meets ambition\n" +
        "—emerge voices that will lead, \n" +
        "innovate, challenge, and ultimately\n" +
        "transform the landscapes of tomorrow."
        };

        private int currentMessageIndex = 0;
        private bool isAnimating = false;

        public frmAbout()
        {
            InitializeComponent();
            label2.Text = inspirationalMessages[0];

            // Wire up the event handler
            this.guna2CircleButton2.Click += new EventHandler(this.guna2CircleButton2_Click);
        }

        private async void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (isAnimating) return;

            try
            {
                isAnimating = true;
                guna2CircleButton2.Enabled = false;

               

                // Update index
                currentMessageIndex = (currentMessageIndex + 1) % inspirationalMessages.Length;

                // Update text
                label2.Text = inspirationalMessages[currentMessageIndex];

                

                // Optional: Add typing effect
                 await TypingEffect(inspirationalMessages[currentMessageIndex]);
            }
            finally
            {
                isAnimating = false;
                guna2CircleButton2.Enabled = true;
            }
        }

        private async Task FadeOutAsync()
        {
            for (double opacity = 1.0; opacity >= 0; opacity -= 0.1)
            {
                label2.ForeColor = Color.FromArgb(
                    (int)(opacity * 255),
                    label2.ForeColor.R,
                    label2.ForeColor.G,
                    label2.ForeColor.B
                );
                await Task.Delay(10);
            }
        }

        private async Task FadeInAsync()
        {
            for (double opacity = 0.0; opacity <= 1.0; opacity += 0.1)
            {
                label2.ForeColor = Color.FromArgb(
                    (int)(opacity * 255),
                    label2.ForeColor.R,
                    label2.ForeColor.G,
                    label2.ForeColor.B
                );
                await Task.Delay(30);
            }
        }

        private async Task TypingEffect(string message)
        {
            label2.Text = "";
            foreach (char c in message)
            {
                label2.Text += c;
                await Task.Delay(10);
            }
        }

        // Remove the duplicate click handler
        // private void guna2CircleButton2_Click_1(object sender, EventArgs e) { }

        // Optional: Add smooth sliding animation
        private async Task SlideTransition()
        {
            int originalX = label2.Location.X;
            int originalY = label2.Location.Y;

            // Slide out to the left
            for (int x = originalX; x >= -label2.Width; x -= 20)
            {
                label2.Location = new Point(x, originalY);
                await Task.Delay(1);
            }

            // Update text
            currentMessageIndex = (currentMessageIndex + 1) % inspirationalMessages.Length;
            label2.Text = inspirationalMessages[currentMessageIndex];

            // Position for slide in from right
            label2.Location = new Point(this.Width, originalY);

            // Slide in from right
            for (int x = this.Width; x >= originalX; x -= 20)
            {
                label2.Location = new Point(x, originalY);
                await Task.Delay(1);
            }

            // Ensure final position is correct
            label2.Location = new Point(originalX, originalY);
        }

        // Optional: Add bounce effect
        private async Task BounceEffect()
        {
            int originalY = label2.Location.Y;
            for (int i = 0; i < 3; i++)
            {
                for (int y = originalY; y >= originalY - 10; y--)
                {
                    label2.Location = new Point(label2.Location.X, y);
                    await Task.Delay(10);
                }
                for (int y = originalY - 10; y <= originalY; y++)
                {
                    label2.Location = new Point(label2.Location.X, y);
                    await Task.Delay(10);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            // Create the coursePage
            frmCourses AboutPage = new frmCourses();

            // Hide the current form
            this.Hide();

            // Show the new form
            AboutPage.Show();

            // Close the application when the new form is closed
            AboutPage.FormClosed += (s, args) => this.Close();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
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