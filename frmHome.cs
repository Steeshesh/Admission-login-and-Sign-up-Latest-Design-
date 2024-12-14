using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    public partial class frmHome : Form
    {
        private bool isClosing = false;

        public frmHome()
        {
            // Enable double buffering
            SetStyle(
                ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true);
            UpdateStyles();

            InitializeComponent();
            OptimizeFormPerformance();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void OptimizeFormPerformance()
        {
            // Suspend layout while making changes
            this.SuspendLayout();

            // Optimize PictureBox controls
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox)
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.BackColor = Color.Transparent;
                }
                else if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                }
            }

            // Form-level optimizations
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.AutoScaleMode = AutoScaleMode.Dpi;

            // Resume layout
            this.ResumeLayout(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.CompositingMode = CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.Low;
            e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

            base.OnPaint(e);
        }

        private void NavigateToForm<T>() where T : Form, new()
        {
            if (isClosing) return;

            try
            {
                var newForm = new T
                {
                    StartPosition = FormStartPosition.Manual,
                    Location = this.Location,
                    Size = this.Size
                };

                newForm.FormClosed += (s, args) =>
                {
                    if (!isClosing)
                    {
                        isClosing = true;
                        this.Close();
                    }
                };

                this.Hide();
                newForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to form: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            NavigateToForm<ChatbotForm>();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            NavigateToForm<frmAbout>();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            NavigateToForm<frmCourses>();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            NavigateToForm<Login>();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            NavigateToForm<Signup>();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            // Defer non-critical initialization
            BeginInvoke(new Action(() =>
            {
                // Additional initialization if needed
            }));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!isClosing && e.CloseReason == CloseReason.UserClosing)
            {
                isClosing = true;
            }
            base.OnFormClosing(e);
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}