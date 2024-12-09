using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolAdmission
{
    public partial class frmCommentDialog : Form
    {
        public string Comment { get; private set; }

        public frmCommentDialog()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Form properties
            this.BackColor = Color.FromArgb(46, 51, 73);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Rejection Reason";

            // Label
            Label lblComment = new Label();
            lblComment.Text = "Please provide a reason for rejection:";
            lblComment.ForeColor = Color.White;
            lblComment.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblComment.Location = new Point(20, 20);
            lblComment.AutoSize = true;
            this.Controls.Add(lblComment);

            // TextBox
            TextBox txtComment = new TextBox();
            txtComment.Multiline = true;
            txtComment.Size = new Size(340, 100);
            txtComment.Location = new Point(20, 50);
            txtComment.BackColor = Color.FromArgb(74, 79, 99);
            txtComment.ForeColor = Color.White;
            txtComment.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtComment.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtComment);

            // Submit Button
            Button btnSubmit = new Button();
            btnSubmit.Text = "Submit";
            btnSubmit.Size = new Size(100, 35);
            btnSubmit.Location = new Point(160, 160);
            btnSubmit.BackColor = Color.FromArgb(64, 134, 246);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubmit.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MessageBox.Show("Please provide a reason for rejection.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                this.Comment = txtComment.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };
            this.Controls.Add(btnSubmit);

            // Cancel Button
            Button btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(270, 160);
            btnCancel.BackColor = Color.FromArgb(51, 56, 78);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btnCancel.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };
            this.Controls.Add(btnCancel);
        }

        private void frmCommentDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
