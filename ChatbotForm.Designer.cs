using System.Drawing;
using System.Windows.Forms;
using System;

namespace Admission_login_and_Sign_up__Latest_Design_
{
    partial class ChatbotForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatbotForm));
            this.chatHistoryBox = new System.Windows.Forms.RichTextBox();
            this.userInputBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.gunaLabel_name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chatHistoryBox
            // 
            this.chatHistoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatHistoryBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.chatHistoryBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatHistoryBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chatHistoryBox.Location = new System.Drawing.Point(20, 99);
            this.chatHistoryBox.Name = "chatHistoryBox";
            this.chatHistoryBox.ReadOnly = true;
            this.chatHistoryBox.Size = new System.Drawing.Size(1160, 621);
            this.chatHistoryBox.TabIndex = 2;
            this.chatHistoryBox.TabStop = false;
            this.chatHistoryBox.Text = "";
            // 
            // userInputBox
            // 
            this.userInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userInputBox.BackColor = System.Drawing.Color.White;
            this.userInputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userInputBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.userInputBox.Location = new System.Drawing.Point(20, 740);
            this.userInputBox.Name = "userInputBox";
            this.userInputBox.Size = new System.Drawing.Size(1100, 34);
            this.userInputBox.TabIndex = 0;
            this.userInputBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userInputBox_KeyPress);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.Color.White;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.ForeColor = System.Drawing.Color.Black;
            this.sendButton.Location = new System.Drawing.Point(1130, 740);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(50, 40);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(377, 3);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(173, 91);
            this.guna2PictureBox1.TabIndex = 26;
            this.guna2PictureBox1.TabStop = false;
            // 
            // gunaLabel_name
            // 
            this.gunaLabel_name.AutoSize = true;
            this.gunaLabel_name.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel_name.Font = new System.Drawing.Font("Dosis SemiBold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel_name.ForeColor = System.Drawing.Color.White;
            this.gunaLabel_name.Location = new System.Drawing.Point(540, 20);
            this.gunaLabel_name.Name = "gunaLabel_name";
            this.gunaLabel_name.Size = new System.Drawing.Size(86, 38);
            this.gunaLabel_name.TabIndex = 27;
            this.gunaLabel_name.Text = "Gabco";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Dosis SemiBold", 10.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(533, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Artificial intelligence Assistant";
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.BackgroundImage")));
            this.guna2CircleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.ImageSize = new System.Drawing.Size(32, 32);
            this.guna2CircleButton1.Location = new System.Drawing.Point(50, 22);
            this.guna2CircleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(60, 48);
            this.guna2CircleButton1.TabIndex = 30;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // ChatbotForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gunaLabel_name);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.chatHistoryBox);
            this.Controls.Add(this.userInputBox);
            this.Controls.Add(this.sendButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChatbotForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GABCO AI Admission Assistant";
            this.Load += new System.EventHandler(this.ChatbotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private void AddCenteredWelcomeMessage()
        {
            chatHistoryBox.Clear();
            chatHistoryBox.SelectionAlignment = HorizontalAlignment.Center;

            // Add some spacing from top
            chatHistoryBox.AppendText("\n\n\n");

            // Add GABCO text in large font
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 18F, FontStyle.Bold);
            chatHistoryBox.SelectionColor = SystemColors.MenuHighlight;
            chatHistoryBox.AppendText("GABCO University\n\n");

            // Add welcome message
            chatHistoryBox.SelectionFont = new Font("Segoe UI", 14F);
            chatHistoryBox.SelectionColor = Color.Black;
            chatHistoryBox.AppendText("How can I assist you today?\n\n");

            // Add suggestions with icons
            string[] suggestions = {
        "📚 Ask about our programs",
        "📝 Learn about admission requirements",
        "📋 Understand the application process",
        "📄 Check document requirements",
        "Thank you to maam Jomaris for inspiring us to do this Application",
    };

            chatHistoryBox.SelectionFont = new Font("Segoe UI", 11F);
            chatHistoryBox.SelectionColor = Color.Gray;
            foreach (var suggestion in suggestions)
            {
                chatHistoryBox.AppendText($"{suggestion}\n");
            }
        }
        private RichTextBox chatHistoryBox;
        private TextBox userInputBox;
        private Button sendButton;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Label gunaLabel_name;
        private Label label3;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
    }
}