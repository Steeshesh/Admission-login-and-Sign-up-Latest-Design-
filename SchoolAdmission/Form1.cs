using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using MySql.Data.MySqlClient;

namespace SchoolAdmission
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Button currentButton;
        private int targetTop;
        private const double FADE_STEP = 0.05;
        private const double DRAG_OPACITY = 1.0; // Opacity when dragging
        private bool isDragging = false;
        private Timer opacityTimer;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            // Initialize opacity timer
            opacityTimer = new Timer();
            opacityTimer.Interval = 10;
            opacityTimer.Tick += OpacityTimer_Tick;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp; // Handle mouse up for form as well
            // Enable custom window chrome
            this.FormBorderStyle = FormBorderStyle.None;

            // Round corners for main form
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Initialize navigation
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            currentButton = btnDashboard;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            // Setup navigation timer
            navigationTimer.Interval = 10;
            navigationTimer.Tick += NavigationTimer_Tick;

            // Wire up button events
            btnDashboard.Click += btnDashboard_Click;
            btnAnalytics.Click += button2_Click;
            btnStudentProfile.Click += button1_Click;
            button4.Click += button4_Click; // Logout button

            // Setup button hover events
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                    StyleButton(btn);
                }
            }

            // Add window drag functionality with transparency effect
            panel3.MouseDown += Panel_MouseDown;
            panel3.MouseUp += Panel_MouseUp;
            panel3.MouseMove += Panel_MouseMove;

            // Apply initial styling
            ApplyInitialStyling();
            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            Form2 frmDashboard_Vrb = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Try to open the database connection
            bool isConnected = DatabaseConnection.OpenConnection();
            if (isConnected)
            {
                MessageBox.Show("DB Connected", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to connect to DB. Check your settings.", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ApplyInitialStyling()
        {
            // Style the navigation panel
            panel1.BackColor = Color.FromArgb(24, 30, 54);
            pnlNav.BackColor = Color.FromArgb(0, 126, 249);

            // Style the title label
            label2.ForeColor = Color.FromArgb(0, 156, 149);
            label2.Font = new Font("Verdana", 10.2f, FontStyle.Bold);

            // Add shadow effect to main panel
            panel1.Paint += (s, e) =>
            {
                Color shadowColor = Color.FromArgb(40, 0, 0, 0);
                ControlPaint.DrawBorder(
                    e.Graphics,
                    panel1.ClientRectangle,
                    shadowColor,  // Left
                    1, ButtonBorderStyle.Solid,
                    shadowColor,  // Top
                    1, ButtonBorderStyle.Solid,
                    shadowColor,  // Right
                    2, ButtonBorderStyle.Solid,
                    shadowColor,  // Bottom
                    1, ButtonBorderStyle.Solid
                );
            };
        }

        private void StyleButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font("Nirmala UI", 9.75f, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(0, 126, 249);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, 0, 0);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentButton)
            {
                btn.BackColor = Color.FromArgb(35, 40, 65);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button btn && btn != currentButton)
            {
                btn.BackColor = Color.FromArgb(24, 30, 54);
            }
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartDragging();
            }
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            StopDragging();
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Opacity = DRAG_OPACITY; // Maintain opacity while dragging
            }
        }


        private void NavigationTimer_Tick(object sender, EventArgs e)
        {
            const int STEP = 5;
            if (Math.Abs(pnlNav.Top - targetTop) <= STEP)
            {
                pnlNav.Top = targetTop;
                navigationTimer.Stop();
                return;
            }
            pnlNav.Top += pnlNav.Top < targetTop ? STEP : -STEP;
        }

        private void NavigateButton(Button btn)
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.FromArgb(24, 30, 54);
            }

            currentButton = btn;
            targetTop = btn.Top;
            btn.BackColor = Color.FromArgb(46, 51, 73);

            navigationTimer.Start();

            // Update the navigation panel
            pnlNav.Height = btn.Height;
            pnlNav.Left = btn.Left;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            NavigateButton(btnDashboard);
            // Load your dashboard content here
            panel2.Controls.Clear();
            label2.Text = "Dashboard";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavigateButton(btnAnalytics);
            // Load your analytics content here
            panel2.Controls.Clear();
            label2.Text = "Analytics";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateButton(btnStudentProfile);
            // Load your student profile content here
            panel2.Controls.Clear();
            label2.Text = "Student Profile";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Fade in form
            Opacity = 0;
            Show();

            for (double opacity = 0.0; opacity <= 1.0; opacity += FADE_STEP)
            {
                Opacity = opacity;
                await System.Threading.Tasks.Task.Delay(10);
            }

            Opacity = 1;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartDragging();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            StopDragging();
        }
        private void StartDragging()
        {
            isDragging = true;
            opacityTimer.Stop(); // Stop any ongoing opacity animation
            Opacity = DRAG_OPACITY;
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void StopDragging()
        {
            isDragging = false;
            opacityTimer.Start(); // Start the fade-in animation
        }

        private void OpacityTimer_Tick(object sender, EventArgs e)
        {
            const double OPACITY_STEP = 0.05;

            if (Opacity >= 1.0)
            {
                Opacity = 1.0;
                opacityTimer.Stop();
                return;
            }

            Opacity = Math.Min(1.0, Opacity + OPACITY_STEP);
        }
        protected override void OnMouseCaptureChanged(EventArgs e)
        {
            base.OnMouseCaptureChanged(e);
            if (!isDragging)
            {
                StopDragging();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Dashboard";
            this.pnlFormLoader.Controls.Clear();
            Form2 frmDashboard_Vrb = new Form2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmDashboard_Vrb);
            frmDashboard_Vrb.Show();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Analytics";
            this.pnlFormLoader.Controls.Clear();
            frmAnalytics frmAnalytics_Vrb = new frmAnalytics() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmAnalytics_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmAnalytics_Vrb);
            frmAnalytics_Vrb.Show();
        }

        private void btnStudentProfile_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Student Profile";
            this.pnlFormLoader.Controls.Clear();
            frmStudentProfile frmStudentProfile_Vrb = new frmStudentProfile() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmStudentProfile_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(frmStudentProfile_Vrb);
            frmStudentProfile_Vrb.Show();
        }
        DatabaseConnection dbConnect = new DatabaseConnection();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // Make sure to dispose of the timer

    }

}
  
