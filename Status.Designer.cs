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
            this.TakeExamButton = new System.Windows.Forms.Button();
            this.fullName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SimpleInfos = new System.Windows.Forms.TableLayoutPanel();
            this.requirementsStatusLB = new System.Windows.Forms.Label();
            this.requirementStatus = new System.Windows.Forms.Label();
            this.documentationStatusLB = new System.Windows.Forms.Label();
            this.documentationStat = new System.Windows.Forms.Label();
            this.examinationStatusLB = new System.Windows.Forms.Label();
            this.examinationStatus = new System.Windows.Forms.Label();
            this.programLB = new System.Windows.Forms.Label();
            this.ChosenProgram = new System.Windows.Forms.Label();
            this.studentIDLB = new System.Windows.Forms.Label();
            this.studentID = new System.Windows.Forms.Label();
            this.studentPic = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).BeginInit();
            this.informations.SuspendLayout();
            this.SimpleInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentPic)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoutLink
            // 
            this.LogoutLink.ActiveLinkColor = System.Drawing.Color.DarkGray;
            this.LogoutLink.AutoSize = true;
            this.LogoutLink.BackColor = System.Drawing.Color.Transparent;
            this.LogoutLink.Font = new System.Drawing.Font("Microsoft Himalaya", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogoutLink.LinkColor = System.Drawing.Color.White;
            this.LogoutLink.Location = new System.Drawing.Point(111, 606);
            this.LogoutLink.Name = "LogoutLink";
            this.LogoutLink.Size = new System.Drawing.Size(70, 28);
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
            this.Logout.Location = new System.Drawing.Point(52, 594);
            this.Logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(69, 49);
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
            this.Applybtn.Location = new System.Drawing.Point(33, 318);
            this.Applybtn.Name = "Applybtn";
            this.Applybtn.Size = new System.Drawing.Size(212, 46);
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
            this.Instructionbtn.Location = new System.Drawing.Point(33, 254);
            this.Instructionbtn.Name = "Instructionbtn";
            this.Instructionbtn.Size = new System.Drawing.Size(212, 46);
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
            this.Statusbtn.Location = new System.Drawing.Point(33, 189);
            this.Statusbtn.Name = "Statusbtn";
            this.Statusbtn.Size = new System.Drawing.Size(212, 46);
            this.Statusbtn.TabIndex = 20;
            this.Statusbtn.Text = "Status";
            this.Statusbtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Statusbtn.UseVisualStyleBackColor = false;
            // 
            // informations
            // 
            this.informations.BackColor = System.Drawing.Color.Transparent;
            this.informations.Controls.Add(this.studentPic);
            this.informations.Controls.Add(this.TakeExamButton);
            this.informations.Controls.Add(this.fullName);
            this.informations.Controls.Add(this.panel1);
            this.informations.Controls.Add(this.SimpleInfos);
            this.informations.Location = new System.Drawing.Point(299, 21);
            this.informations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.informations.Name = "informations";
            this.informations.Size = new System.Drawing.Size(862, 612);
            this.informations.TabIndex = 25;
            this.informations.Paint += new System.Windows.Forms.PaintEventHandler(this.informations_Paint_1);
            // 
            // TakeExamButton
            // 
            this.TakeExamButton.Font = new System.Drawing.Font("Microsoft Himalaya", 14F, System.Drawing.FontStyle.Bold);
            this.TakeExamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TakeExamButton.Location = new System.Drawing.Point(677, 573);
            this.TakeExamButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TakeExamButton.Name = "TakeExamButton";
            this.TakeExamButton.Size = new System.Drawing.Size(145, 27);
            this.TakeExamButton.TabIndex = 8;
            this.TakeExamButton.Text = "Take the Exam";
            this.TakeExamButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.TakeExamButton.UseVisualStyleBackColor = true;
            this.TakeExamButton.Click += new System.EventHandler(this.TakeExamButton_Click);
            // 
            // fullName
            // 
            this.fullName.AutoSize = true;
            this.fullName.BackColor = System.Drawing.Color.Transparent;
            this.fullName.Font = new System.Drawing.Font("Microsoft Himalaya", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullName.ForeColor = System.Drawing.Color.White;
            this.fullName.Location = new System.Drawing.Point(284, 83);
            this.fullName.Name = "fullName";
            this.fullName.Size = new System.Drawing.Size(472, 47);
            this.fullName.TabIndex = 2;
            this.fullName.Text = "Surname, First Name Middle Name";
            this.fullName.Click += new System.EventHandler(this.fullName_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(266, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 1);
            this.panel1.TabIndex = 1;
            // 
            // SimpleInfos
            // 
            this.SimpleInfos.BackColor = System.Drawing.Color.Transparent;
            this.SimpleInfos.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.SimpleInfos.ColumnCount = 2;
            this.SimpleInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.05917F));
            this.SimpleInfos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.94083F));
            this.SimpleInfos.Controls.Add(this.requirementsStatusLB, 0, 0);
            this.SimpleInfos.Controls.Add(this.requirementStatus, 1, 0);
            this.SimpleInfos.Controls.Add(this.documentationStatusLB, 0, 1);
            this.SimpleInfos.Controls.Add(this.documentationStat, 1, 1);
            this.SimpleInfos.Controls.Add(this.examinationStatusLB, 0, 2);
            this.SimpleInfos.Controls.Add(this.examinationStatus, 1, 2);
            this.SimpleInfos.Controls.Add(this.programLB, 0, 3);
            this.SimpleInfos.Controls.Add(this.ChosenProgram, 1, 3);
            this.SimpleInfos.Controls.Add(this.studentIDLB, 0, 4);
            this.SimpleInfos.Controls.Add(this.studentID, 1, 4);
            this.SimpleInfos.Location = new System.Drawing.Point(60, 178);
            this.SimpleInfos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SimpleInfos.Name = "SimpleInfos";
            this.SimpleInfos.RowCount = 5;
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.SimpleInfos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.SimpleInfos.Size = new System.Drawing.Size(751, 370);
            this.SimpleInfos.TabIndex = 0;
            // 
            // requirementsStatusLB
            // 
            this.requirementsStatusLB.AutoSize = true;
            this.requirementsStatusLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requirementsStatusLB.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requirementsStatusLB.ForeColor = System.Drawing.Color.White;
            this.requirementsStatusLB.Location = new System.Drawing.Point(6, 3);
            this.requirementsStatusLB.Name = "requirementsStatusLB";
            this.requirementsStatusLB.Size = new System.Drawing.Size(365, 71);
            this.requirementsStatusLB.TabIndex = 0;
            this.requirementsStatusLB.Text = "Requirements Status:";
            this.requirementsStatusLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // requirementStatus
            // 
            this.requirementStatus.AutoSize = true;
            this.requirementStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.requirementStatus.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requirementStatus.ForeColor = System.Drawing.Color.White;
            this.requirementStatus.Location = new System.Drawing.Point(380, 3);
            this.requirementStatus.Name = "requirementStatus";
            this.requirementStatus.Size = new System.Drawing.Size(365, 71);
            this.requirementStatus.TabIndex = 1;
            this.requirementStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.requirementStatus.Click += new System.EventHandler(this.applicationStatus_Click_1);
            // 
            // documentationStatusLB
            // 
            this.documentationStatusLB.AutoSize = true;
            this.documentationStatusLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentationStatusLB.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentationStatusLB.ForeColor = System.Drawing.Color.White;
            this.documentationStatusLB.Location = new System.Drawing.Point(6, 77);
            this.documentationStatusLB.Name = "documentationStatusLB";
            this.documentationStatusLB.Size = new System.Drawing.Size(365, 71);
            this.documentationStatusLB.TabIndex = 2;
            this.documentationStatusLB.Text = "Admin Feedback";
            this.documentationStatusLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // documentationStat
            // 
            this.documentationStat.AutoSize = true;
            this.documentationStat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentationStat.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentationStat.ForeColor = System.Drawing.Color.White;
            this.documentationStat.Location = new System.Drawing.Point(380, 77);
            this.documentationStat.Name = "documentationStat";
            this.documentationStat.Size = new System.Drawing.Size(365, 71);
            this.documentationStat.TabIndex = 3;
            this.documentationStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // examinationStatusLB
            // 
            this.examinationStatusLB.AutoSize = true;
            this.examinationStatusLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.examinationStatusLB.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examinationStatusLB.ForeColor = System.Drawing.Color.White;
            this.examinationStatusLB.Location = new System.Drawing.Point(6, 151);
            this.examinationStatusLB.Name = "examinationStatusLB";
            this.examinationStatusLB.Size = new System.Drawing.Size(365, 75);
            this.examinationStatusLB.TabIndex = 4;
            this.examinationStatusLB.Text = "Examination Status: ";
            this.examinationStatusLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // examinationStatus
            // 
            this.examinationStatus.AutoSize = true;
            this.examinationStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.examinationStatus.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examinationStatus.ForeColor = System.Drawing.Color.White;
            this.examinationStatus.Location = new System.Drawing.Point(380, 151);
            this.examinationStatus.Name = "examinationStatus";
            this.examinationStatus.Size = new System.Drawing.Size(365, 75);
            this.examinationStatus.TabIndex = 5;
            this.examinationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // programLB
            // 
            this.programLB.AutoSize = true;
            this.programLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programLB.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programLB.ForeColor = System.Drawing.Color.White;
            this.programLB.Location = new System.Drawing.Point(6, 229);
            this.programLB.Name = "programLB";
            this.programLB.Size = new System.Drawing.Size(365, 70);
            this.programLB.TabIndex = 6;
            this.programLB.Text = "Program:";
            this.programLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChosenProgram
            // 
            this.ChosenProgram.AutoSize = true;
            this.ChosenProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChosenProgram.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChosenProgram.ForeColor = System.Drawing.Color.White;
            this.ChosenProgram.Location = new System.Drawing.Point(380, 229);
            this.ChosenProgram.Name = "ChosenProgram";
            this.ChosenProgram.Size = new System.Drawing.Size(365, 70);
            this.ChosenProgram.TabIndex = 7;
            this.ChosenProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentIDLB
            // 
            this.studentIDLB.AutoSize = true;
            this.studentIDLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentIDLB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.studentIDLB.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentIDLB.ForeColor = System.Drawing.Color.White;
            this.studentIDLB.Location = new System.Drawing.Point(6, 302);
            this.studentIDLB.Name = "studentIDLB";
            this.studentIDLB.Size = new System.Drawing.Size(365, 65);
            this.studentIDLB.TabIndex = 8;
            this.studentIDLB.Text = "Student ID";
            this.studentIDLB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // studentID
            // 
            this.studentID.AutoSize = true;
            this.studentID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentID.Font = new System.Drawing.Font("Microsoft Himalaya", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentID.ForeColor = System.Drawing.Color.White;
            this.studentID.Location = new System.Drawing.Point(380, 302);
            this.studentID.Name = "studentID";
            this.studentID.Size = new System.Drawing.Size(365, 65);
            this.studentID.TabIndex = 9;
            this.studentID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.studentID.Click += new System.EventHandler(this.studentID_Click);
            // 
            // studentPic
            // 
            this.studentPic.ImageRotate = 0F;
            this.studentPic.Location = new System.Drawing.Point(60, 15);
            this.studentPic.Name = "studentPic";
            this.studentPic.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.studentPic.Size = new System.Drawing.Size(157, 137);
            this.studentPic.TabIndex = 9;
            this.studentPic.TabStop = false;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Admission_login_and_Sign_up__Latest_Design_.Properties.Resources.ADMISSION_SYSTEM__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.informations);
            this.Controls.Add(this.LogoutLink);
            this.Controls.Add(this.Logout);
            this.Controls.Add(this.Applybtn);
            this.Controls.Add(this.Instructionbtn);
            this.Controls.Add(this.Statusbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status";
            this.Load += new System.EventHandler(this.Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logout)).EndInit();
            this.informations.ResumeLayout(false);
            this.informations.PerformLayout();
            this.SimpleInfos.ResumeLayout(false);
            this.SimpleInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentPic)).EndInit();
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
        private System.Windows.Forms.Label fullName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label requirementsStatusLB;
        private System.Windows.Forms.Label requirementStatus;
        private System.Windows.Forms.Label documentationStatusLB;
        private System.Windows.Forms.Label documentationStat;
        private System.Windows.Forms.Label examinationStatusLB;
        private System.Windows.Forms.Label examinationStatus;
        private System.Windows.Forms.Label programLB;
        private System.Windows.Forms.Label ChosenProgram;
        private System.Windows.Forms.Label studentIDLB;
        private System.Windows.Forms.Label studentID;
        private System.Windows.Forms.Button TakeExamButton;
        private Guna.UI2.WinForms.Guna2CirclePictureBox studentPic;
    }
}