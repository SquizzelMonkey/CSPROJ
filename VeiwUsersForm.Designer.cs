namespace FormsDatabase
{
    partial class VeiwUsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeiwUsersForm));
            this.UserFoundListBox = new System.Windows.Forms.ListBox();
            this.lastNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.DaBox = new System.Windows.Forms.CheckBox();
            this.SendBox = new System.Windows.Forms.CheckBox();
            this.yearGroup = new System.Windows.Forms.ComboBox();
            this.tutorGroup = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UserFoundListBox
            // 
            this.UserFoundListBox.FormattingEnabled = true;
            this.UserFoundListBox.ItemHeight = 20;
            this.UserFoundListBox.Location = new System.Drawing.Point(3, 108);
            this.UserFoundListBox.Name = "UserFoundListBox";
            this.UserFoundListBox.Size = new System.Drawing.Size(1098, 484);
            this.UserFoundListBox.TabIndex = 0;
            this.UserFoundListBox.SelectedIndexChanged += new System.EventHandler(this.UserFoundListBox_SelectedIndexChanged);
            // 
            // lastNameTB
            // 
            this.lastNameTB.Location = new System.Drawing.Point(24, 32);
            this.lastNameTB.Name = "lastNameTB";
            this.lastNameTB.Size = new System.Drawing.Size(100, 26);
            this.lastNameTB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by Surname";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(8, 65);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(144, 43);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // DaBox
            // 
            this.DaBox.AutoSize = true;
            this.DaBox.Location = new System.Drawing.Point(412, 34);
            this.DaBox.Name = "DaBox";
            this.DaBox.Size = new System.Drawing.Size(58, 24);
            this.DaBox.TabIndex = 4;
            this.DaBox.Text = "DA";
            this.DaBox.UseVisualStyleBackColor = true;
            // 
            // SendBox
            // 
            this.SendBox.AutoSize = true;
            this.SendBox.Location = new System.Drawing.Point(465, 34);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(80, 24);
            this.SendBox.TabIndex = 5;
            this.SendBox.Text = "SEND";
            this.SendBox.UseVisualStyleBackColor = true;
            // 
            // yearGroup
            // 
            this.yearGroup.AllowDrop = true;
            this.yearGroup.FormattingEnabled = true;
            this.yearGroup.Items.AddRange(new object[] {
            "Year 7",
            "Year 8",
            "Year 9",
            "Year 10",
            "Year 11",
            "All Years"});
            this.yearGroup.Location = new System.Drawing.Point(158, 29);
            this.yearGroup.Name = "yearGroup";
            this.yearGroup.Size = new System.Drawing.Size(121, 28);
            this.yearGroup.TabIndex = 6;
            this.yearGroup.SelectedIndexChanged += new System.EventHandler(this.yearGroup_SelectedIndexChanged);
            // 
            // tutorGroup
            // 
            this.tutorGroup.FormattingEnabled = true;
            this.tutorGroup.Items.AddRange(new object[] {
            "A",
            "S",
            "P",
            "I",
            "R",
            "E",
            "All Tutor Groups"});
            this.tutorGroup.Location = new System.Drawing.Point(285, 29);
            this.tutorGroup.Name = "tutorGroup";
            this.tutorGroup.Size = new System.Drawing.Size(121, 28);
            this.tutorGroup.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "YearGroup";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "TutorGroup";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(926, 14);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(82, 88);
            this.button7.TabIndex = 16;
            this.button7.Text = "TaskSet Controls";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(824, 14);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 88);
            this.button3.TabIndex = 17;
            this.button3.Text = "Task Controls";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1014, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 92);
            this.button4.TabIndex = 18;
            this.button4.Text = "Copy Selected To Report";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(550, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 32);
            this.button5.TabIndex = 19;
            this.button5.Text = "Password Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(551, 50);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(173, 52);
            this.button6.TabIndex = 20;
            this.button6.Text = "Get Rewards Analysis";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(730, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 88);
            this.button1.TabIndex = 21;
            this.button1.Text = "User Controls";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // VeiwUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 608);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tutorGroup);
            this.Controls.Add(this.yearGroup);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.DaBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastNameTB);
            this.Controls.Add(this.UserFoundListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VeiwUsersForm";
            this.Text = "LHS - ASPIRE ENRICHMENT TRACKER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UserFoundListBox;
        private System.Windows.Forms.TextBox lastNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.CheckBox DaBox;
        private System.Windows.Forms.CheckBox SendBox;
        private System.Windows.Forms.ComboBox yearGroup;
        private System.Windows.Forms.ComboBox tutorGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button button4;
        protected System.Windows.Forms.Button button5;
        public System.Windows.Forms.Button button6;
    }
}

