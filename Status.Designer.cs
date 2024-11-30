namespace Admission_login_and_Sign_up__Latest_Design_
{
    partial class Status
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LogoutLink = new System.Windows.Forms.LinkLabel();
            this.Logout = new System.Windows.Forms.PictureBox();
            this.Applybtn = new System.Windows.Forms.Button();
            this.Instructionbtn = new System.Windows.Forms.Button();
            this.Statusbtn = new System.Windows.Forms.Button();
            this.informations = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SimpleInfos = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).BeginInit();
            this.informations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoutLink
            // 
            this.LogoutLink.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.LogoutLink.AutoSize = true;
            this.LogoutLink.BackColor = System.Drawing.Color.Transparent;
            this.LogoutLink.Font = new System.Drawing.Font("Microsoft Himalaya", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutLink.LinkColor = System.Drawing.Color.White;
            this.LogoutLink.Location = new System.Drawing.Point(125, 758);
            this.LogoutLink.Name = "LogoutLink";
            this.LogoutLink.Size = new System.Drawing.Size(86, 33);
            this.LogoutLink.TabIndex = 24;
            this.LogoutLink.TabStop = true;
            this.LogoutLink.Text = "Log-out";
            this.LogoutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogoutLink_LinkClicked);
            // 
            // Logout
            // 
            this.Logout.BackColor = System.Drawing.Color.Transparent;
            this.Logout.BackgroundImage = global::Admission_login_and_Sign_up__Latest_Design_.Properties.Resources.log_out;
            this.Logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logout.Location = new System.Drawing.Point(58, 743);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(78, 61);
            this.Logout.TabIndex = 23;
            this.Logout.TabStop = false;
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Applybtn
            // 
            this.Applybtn.BackColor = System.Drawing.Color.Transparent;
            this.Applybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Applybtn.Font = new System.Drawing.Font("Microsoft Himalaya", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Applybtn.ForeColor = System.Drawing.Color.White;
            this.Applybtn.Location = new System.Drawing.Point(37, 398);
            this.Applybtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Applybtn.Name = "Applybtn";
            this.Applybtn.Size = new System.Drawing.Size(238, 57);
            this.Applybtn.TabIndex = 22;
            this.Applybtn.Text = "Apply";
            this.Applybtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Applybtn.UseVisualStyleBackColor = false;
            this.Applybtn.Click += new System.EventHandler(this.Applybtn_Click);
            // 
            // Instructionbtn
            // 
            this.Instructionbtn.BackColor = System.Drawing.Color.Transparent;
            this.Instructionbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Instructionbtn.Font = new System.Drawing.Font("Microsoft Himalaya", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Instructionbtn.ForeColor = System.Drawing.Color.White;
            this.Instructionbtn.Location = new System.Drawing.Point(37, 317);
            this.Instructionbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Instructionbtn.Name = "Instructionbtn";
            this.Instructionbtn.Size = new System.Drawing.Size(238, 57);
            this.Instructionbtn.TabIndex = 21;
            this.Instructionbtn.Text = "How to Apply";
            this.Instructionbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Instructionbtn.UseVisualStyleBackColor = false;
            this.Instructionbtn.Click += new System.EventHandler(this.Instructionbtn_Click);
            // 
            // Statusbtn
            // 
            this.Statusbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(80)))), ((int)(((byte)(113)))));
            this.Statusbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Statusbtn.Font = new System.Drawing.Font("Microsoft Himalaya", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Statusbtn.ForeColor = System.Drawing.Color.White;
            this.Statusbtn.Location = new System.Drawing.Point(37, 236);
            this.Statusbtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Statusbtn.Name = "Statusbtn";
            this.Statusbtn.Size = new System.Drawing.Size(238, 57);
            this.Statusbtn.TabIndex = 20;
            this.Statusbtn.Text = "Status";
            this.Statusbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Statusbtn.UseVisualStyleBackColor = false;
            // 
            // informations
            // 
            this.informations.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.informations.Controls.Add(this.label1);
            this.informations.Controls.Add(this.panel1);
            this.informations.Controls.Add(this.SimpleInfos);
            this.informations.Controls.Add(this.pictureBox1);
            this.informations.Location = new System.Drawing.Point(336, 26);
            this.informations.Name = "informations";
            this.informations.Size = new System.Drawing.Size(970, 765);
            this.informations.TabIndex = 25;
            this.informations.Paint += new System.Windows.Forms.PaintEventHandler(this.informations_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Admission_login_and_Sign_up__Latest_Design_.Properties.Resources.profile_png;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(49, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 157);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Himalaya", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(322, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "Surname, First Name Middle Name";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(302, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 1);
            this.panel1.TabIndex = 1;
            // 
            // SimpleInfos
            // 
            this.SimpleInfos.BackColor = System.Drawing.Color.Transparent;
            this.SimpleInfos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.SimpleInfos.ColumnCount = 2;
            this.SimpleInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.05917F));
            this.SimpleInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.94083F));
            this.SimpleInfos.Location = new System.Drawing.Point(68, 236);
            this.SimpleInfos.Name = "SimpleInfos";
            this.SimpleInfos.RowCount = 5;
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.SimpleInfos.Size = new System.Drawing.Size(845, 462);
            this.SimpleInfos.TabIndex = 0;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Admission_login_and_Sign_up__Latest_Design_.Properties.Resources.default_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1330, 816);
            this.Controls.Add(this.informations);
            this.Controls.Add(this.LogoutLink);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Applybtn);
            this.Controls.Add(this.Instructionbtn);
            this.Controls.Add(this.Statusbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.Load += new System.EventHandler(this.Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).EndInit();
            this.informations.ResumeLayout(false);
            this.informations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LogoutLink;
        private System.Windows.Forms.PictureBox Logout;
        private System.Windows.Forms.Button Applybtn;
        private System.Windows.Forms.Button Instructionbtn;
        private System.Windows.Forms.Button Statusbtn;
        private System.Windows.Forms.Panel informations;
        private System.Windows.Forms.TableLayoutPanel SimpleInfos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}