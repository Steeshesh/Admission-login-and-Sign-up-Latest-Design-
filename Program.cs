using System;
using System.Windows.Forms;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                // Enable DPI awareness
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    SetProcessDPIAware();
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Set the process priority
                System.Diagnostics.Process.GetCurrentProcess().PriorityClass =
                    System.Diagnostics.ProcessPriorityClass.High;

                Application.Run(new frmHome());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application Error: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}