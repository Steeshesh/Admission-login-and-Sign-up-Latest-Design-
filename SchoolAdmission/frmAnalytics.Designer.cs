// frmAnalytics.Designer.cs
using System.Windows.Forms.DataVisualization.Charting;

namespace SchoolAdmission
{
    partial class frmAnalytics
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGender;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAge;
        private System.Windows.Forms.Label labelGenderDistribution;
        private System.Windows.Forms.Label labelAverageAge;
        private System.Windows.Forms.Label labelTotalStudents;
        private System.Windows.Forms.Label labelAgeDistribution;
        private System.Windows.Forms.Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartGender = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAge = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelGenderDistribution = new System.Windows.Forms.Label();
            this.labelAverageAge = new System.Windows.Forms.Label();
            this.labelTotalStudents = new System.Windows.Forms.Label();
            this.labelAgeDistribution = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAge)).BeginInit();
            this.SuspendLayout();
            // 
            // chartGender
            // 
            this.chartGender.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.chartGender.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chartGender.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            this.chartGender.Legends.Add(legend1);
            this.chartGender.Location = new System.Drawing.Point(35, 80);
            this.chartGender.Name = "chartGender";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            series1.Legend = "Legend1";
            series1.Name = "Gender";
            this.chartGender.Series.Add(series1);
            this.chartGender.Size = new System.Drawing.Size(365, 300);
            this.chartGender.TabIndex = 0;
            this.chartGender.Click += new System.EventHandler(this.chartGender_Click);
            chartArea1.Area3DStyle.Enable3D = false;
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;  // or your preferred chart type
            this.chartGender.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartGender.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartGender.BorderlineWidth = 0;
            // 
            // chartAge
            // 
            // For chartAge
            chartArea2.Area3DStyle.Enable3D = false;
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;  // or your preferred chart type
            this.chartAge.BorderlineColor = System.Drawing.Color.Transparent;
            this.chartAge.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chartAge.BorderlineWidth = 0;
            this.chartAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.chartAge.BackColor = System.Drawing.Color.Transparent;
            this.chartAge.BorderlineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartAge.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            this.chartAge.Legends.Add(legend2);
            this.chartAge.Location = new System.Drawing.Point(380, 80);
            this.chartAge.Name = "chartAge";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(238)))), ((int)(((byte)(144)))));
            series2.Legend = "Legend1";
            series2.Name = "Age";
            this.chartAge.Series.Add(series2);
            this.chartAge.Size = new System.Drawing.Size(369, 300);
            this.chartAge.TabIndex = 1;
            this.chartAge.Click += new System.EventHandler(this.chartAge_Click);

            // 
            // labelGenderDistribution
            // 
            this.labelGenderDistribution.AutoSize = true;
            this.labelGenderDistribution.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelGenderDistribution.ForeColor = System.Drawing.Color.White;
            this.labelGenderDistribution.Location = new System.Drawing.Point(30, 30);
            this.labelGenderDistribution.Name = "labelGenderDistribution";
            this.labelGenderDistribution.Size = new System.Drawing.Size(234, 31);
            this.labelGenderDistribution.TabIndex = 0;
            this.labelGenderDistribution.Text = "Gender Distribution:";
            this.labelGenderDistribution.Click += new System.EventHandler(this.labelGenderDistribution_Click);
            // 
            // labelAverageAge
            // 
            this.labelAverageAge.AutoSize = true;
            this.labelAverageAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAverageAge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(226)))), ((int)(((byte)(178)))));
            this.labelAverageAge.Location = new System.Drawing.Point(30, 390);
            this.labelAverageAge.Name = "labelAverageAge";
            this.labelAverageAge.Size = new System.Drawing.Size(145, 25);
            this.labelAverageAge.TabIndex = 1;
            this.labelAverageAge.Text = "Average Age:";
            // 
            // labelTotalStudents
            // 
            this.labelTotalStudents.AutoSize = true;
            this.labelTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(226)))), ((int)(((byte)(178)))));
            this.labelTotalStudents.Location = new System.Drawing.Point(30, 420);
            this.labelTotalStudents.Name = "labelTotalStudents";
            this.labelTotalStudents.Size = new System.Drawing.Size(256, 25);
            this.labelTotalStudents.TabIndex = 2;
            this.labelTotalStudents.Text = "Total Students Applicant:";
            // 
            // labelAgeDistribution
            // 
            this.labelAgeDistribution.AutoSize = true;
            this.labelAgeDistribution.Font = new System.Drawing.Font("Nirmala UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.labelAgeDistribution.ForeColor = System.Drawing.Color.White;
            this.labelAgeDistribution.Location = new System.Drawing.Point(380, 30);
            this.labelAgeDistribution.Name = "labelAgeDistribution";
            this.labelAgeDistribution.Size = new System.Drawing.Size(199, 31);
            this.labelAgeDistribution.TabIndex = 3;
            this.labelAgeDistribution.Text = "Age Distribution:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnRefresh.Location = new System.Drawing.Point(600, 420);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmAnalytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.chartGender);
            this.Controls.Add(this.chartAge);
            this.Controls.Add(this.labelGenderDistribution);
            this.Controls.Add(this.labelAverageAge);
            this.Controls.Add(this.labelTotalStudents);
            this.Controls.Add(this.labelAgeDistribution);
            this.Controls.Add(this.btnRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAnalytics";
            this.Text = "Analytics";
            this.Load += new System.EventHandler(this.frmAnalytics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}