namespace ITask2
{
    partial class ITask
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingpanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DaysPanel = new System.Windows.Forms.Panel();
            this.delimiter = new System.Windows.Forms.Panel();
            this.PrevBtn = new System.Windows.Forms.Button();
            this.NextBtn = new System.Windows.Forms.Button();
            this.Day7Lbl = new System.Windows.Forms.Label();
            this.Day6Lbl = new System.Windows.Forms.Label();
            this.Day5Lbl = new System.Windows.Forms.Label();
            this.Day4Lbl = new System.Windows.Forms.Label();
            this.Day3Lbl = new System.Windows.Forms.Label();
            this.Day2Lbl = new System.Windows.Forms.Label();
            this.Day1Lbl = new System.Windows.Forms.Label();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.loadingpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.loadingpanel);
            this.panel1.Controls.Add(this.DaysPanel);
            this.panel1.Controls.Add(this.delimiter);
            this.panel1.Controls.Add(this.PrevBtn);
            this.panel1.Controls.Add(this.NextBtn);
            this.panel1.Controls.Add(this.Day7Lbl);
            this.panel1.Controls.Add(this.Day6Lbl);
            this.panel1.Controls.Add(this.Day5Lbl);
            this.panel1.Controls.Add(this.Day4Lbl);
            this.panel1.Controls.Add(this.Day3Lbl);
            this.panel1.Controls.Add(this.Day2Lbl);
            this.panel1.Controls.Add(this.Day1Lbl);
            this.panel1.Controls.Add(this.MonthLabel);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 783);
            this.panel1.TabIndex = 0;
            // 
            // loadingpanel
            // 
            this.loadingpanel.Controls.Add(this.pictureBox1);
            this.loadingpanel.Location = new System.Drawing.Point(15, 135);
            this.loadingpanel.Name = "loadingpanel";
            this.loadingpanel.Size = new System.Drawing.Size(935, 645);
            this.loadingpanel.TabIndex = 30;
            this.loadingpanel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ITask7.Properties.Resources.hzk6C;
            this.pictureBox1.Location = new System.Drawing.Point(233, 187);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(434, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DaysPanel
            // 
            this.DaysPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.DaysPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DaysPanel.Location = new System.Drawing.Point(15, 156);
            this.DaysPanel.Name = "DaysPanel";
            this.DaysPanel.Size = new System.Drawing.Size(935, 612);
            this.DaysPanel.TabIndex = 43;
            // 
            // delimiter
            // 
            this.delimiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.delimiter.Location = new System.Drawing.Point(15, 79);
            this.delimiter.Name = "delimiter";
            this.delimiter.Size = new System.Drawing.Size(935, 10);
            this.delimiter.TabIndex = 42;
            // 
            // PrevBtn
            // 
            this.PrevBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PrevBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrevBtn.Location = new System.Drawing.Point(794, 29);
            this.PrevBtn.Name = "PrevBtn";
            this.PrevBtn.Size = new System.Drawing.Size(75, 39);
            this.PrevBtn.TabIndex = 41;
            this.PrevBtn.Text = "Prev";
            this.PrevBtn.UseVisualStyleBackColor = false;
            this.PrevBtn.Click += new System.EventHandler(this.PrevBtn_Click);
            // 
            // NextBtn
            // 
            this.NextBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextBtn.Location = new System.Drawing.Point(875, 29);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(75, 39);
            this.NextBtn.TabIndex = 40;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = false;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            this.NextBtn.MouseEnter += new System.EventHandler(this.NextBtn_MouseEnter);
            this.NextBtn.MouseLeave += new System.EventHandler(this.NextBtn_MouseLeave);
            // 
            // Day7Lbl
            // 
            this.Day7Lbl.AutoSize = true;
            this.Day7Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day7Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day7Lbl.Location = new System.Drawing.Point(819, 112);
            this.Day7Lbl.Name = "Day7Lbl";
            this.Day7Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day7Lbl.TabIndex = 39;
            this.Day7Lbl.Text = "label8";
            // 
            // Day6Lbl
            // 
            this.Day6Lbl.AutoSize = true;
            this.Day6Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day6Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day6Lbl.Location = new System.Drawing.Point(686, 112);
            this.Day6Lbl.Name = "Day6Lbl";
            this.Day6Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day6Lbl.TabIndex = 38;
            this.Day6Lbl.Text = "label7";
            // 
            // Day5Lbl
            // 
            this.Day5Lbl.AutoSize = true;
            this.Day5Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day5Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day5Lbl.Location = new System.Drawing.Point(555, 112);
            this.Day5Lbl.Name = "Day5Lbl";
            this.Day5Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day5Lbl.TabIndex = 37;
            this.Day5Lbl.Text = "label6";
            // 
            // Day4Lbl
            // 
            this.Day4Lbl.AutoSize = true;
            this.Day4Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day4Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day4Lbl.Location = new System.Drawing.Point(425, 112);
            this.Day4Lbl.Name = "Day4Lbl";
            this.Day4Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day4Lbl.TabIndex = 36;
            this.Day4Lbl.Text = "label5";
            // 
            // Day3Lbl
            // 
            this.Day3Lbl.AutoSize = true;
            this.Day3Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day3Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day3Lbl.Location = new System.Drawing.Point(290, 112);
            this.Day3Lbl.Name = "Day3Lbl";
            this.Day3Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day3Lbl.TabIndex = 35;
            this.Day3Lbl.Text = "label4";
            // 
            // Day2Lbl
            // 
            this.Day2Lbl.AutoSize = true;
            this.Day2Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day2Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day2Lbl.Location = new System.Drawing.Point(158, 112);
            this.Day2Lbl.Name = "Day2Lbl";
            this.Day2Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day2Lbl.TabIndex = 34;
            this.Day2Lbl.Text = "label3";
            // 
            // Day1Lbl
            // 
            this.Day1Lbl.AutoSize = true;
            this.Day1Lbl.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Day1Lbl.ForeColor = System.Drawing.SystemColors.Control;
            this.Day1Lbl.Location = new System.Drawing.Point(26, 112);
            this.Day1Lbl.Name = "Day1Lbl";
            this.Day1Lbl.Size = new System.Drawing.Size(54, 20);
            this.Day1Lbl.TabIndex = 33;
            this.Day1Lbl.Text = "label2";
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Font = new System.Drawing.Font("Baskerville Old Face", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MonthLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.MonthLabel.Location = new System.Drawing.Point(15, 30);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(95, 31);
            this.MonthLabel.TabIndex = 32;
            this.MonthLabel.Text = "January";
            // 
            // ITask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(993, 833);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ITask";
            this.Text = "ITask";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.loadingpanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label Day7Lbl;
        public System.Windows.Forms.Label Day6Lbl;
        public System.Windows.Forms.Label Day5Lbl;
        public System.Windows.Forms.Label Day4Lbl;
        public System.Windows.Forms.Label Day3Lbl;
        public System.Windows.Forms.Label Day2Lbl;
        public System.Windows.Forms.Label Day1Lbl;
        public System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.Panel delimiter;
        public System.Windows.Forms.Button PrevBtn;
        public System.Windows.Forms.Button NextBtn;
        public System.Windows.Forms.Panel DaysPanel;
        public System.Windows.Forms.Panel loadingpanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
