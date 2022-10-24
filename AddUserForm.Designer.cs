namespace FormsDatabase
{
    partial class AddUserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserForm));
            this.AddDAbox = new System.Windows.Forms.CheckBox();
            this.AddSendBox = new System.Windows.Forms.CheckBox();
            this.AddYearBox = new System.Windows.Forms.ComboBox();
            this.AddTutorBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddForenameBox = new System.Windows.Forms.TextBox();
            this.AddSurnameBox = new System.Windows.Forms.TextBox();
            this.addAuthBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddDAbox
            // 
            this.AddDAbox.AutoSize = true;
            this.AddDAbox.Location = new System.Drawing.Point(117, 203);
            this.AddDAbox.Name = "AddDAbox";
            this.AddDAbox.Size = new System.Drawing.Size(58, 24);
            this.AddDAbox.TabIndex = 0;
            this.AddDAbox.Text = "DA";
            this.AddDAbox.UseVisualStyleBackColor = true;
            // 
            // AddSendBox
            // 
            this.AddSendBox.AutoSize = true;
            this.AddSendBox.Location = new System.Drawing.Point(181, 203);
            this.AddSendBox.Name = "AddSendBox";
            this.AddSendBox.Size = new System.Drawing.Size(80, 24);
            this.AddSendBox.TabIndex = 1;
            this.AddSendBox.Text = "SEND";
            this.AddSendBox.UseVisualStyleBackColor = true;
            this.AddSendBox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // AddYearBox
            // 
            this.AddYearBox.FormattingEnabled = true;
            this.AddYearBox.Items.AddRange(new object[] {
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.AddYearBox.Location = new System.Drawing.Point(162, 125);
            this.AddYearBox.Name = "AddYearBox";
            this.AddYearBox.Size = new System.Drawing.Size(121, 28);
            this.AddYearBox.TabIndex = 2;
            // 
            // AddTutorBox
            // 
            this.AddTutorBox.FormattingEnabled = true;
            this.AddTutorBox.Items.AddRange(new object[] {
            "A",
            "S",
            "P",
            "I",
            "R",
            "E"});
            this.AddTutorBox.Location = new System.Drawing.Point(162, 159);
            this.AddTutorBox.Name = "AddTutorBox";
            this.AddTutorBox.Size = new System.Drawing.Size(121, 28);
            this.AddTutorBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Forename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Surname";
            // 
            // AddForenameBox
            // 
            this.AddForenameBox.Location = new System.Drawing.Point(183, 61);
            this.AddForenameBox.Name = "AddForenameBox";
            this.AddForenameBox.Size = new System.Drawing.Size(100, 26);
            this.AddForenameBox.TabIndex = 6;
            // 
            // AddSurnameBox
            // 
            this.AddSurnameBox.Location = new System.Drawing.Point(183, 93);
            this.AddSurnameBox.Name = "AddSurnameBox";
            this.AddSurnameBox.Size = new System.Drawing.Size(100, 26);
            this.AddSurnameBox.TabIndex = 7;
            // 
            // addAuthBox
            // 
            this.addAuthBox.FormattingEnabled = true;
            this.addAuthBox.Items.AddRange(new object[] {
            "Student",
            "Staff",
            "Admin"});
            this.addAuthBox.Location = new System.Drawing.Point(162, 17);
            this.addAuthBox.Name = "addAuthBox";
            this.addAuthBox.Size = new System.Drawing.Size(121, 28);
            this.addAuthBox.TabIndex = 8;
            this.addAuthBox.SelectedIndexChanged += new System.EventHandler(this.addAuthBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Year";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tutor Group";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Authorisation Level";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(65, 259);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(171, 67);
            this.AddButton.TabIndex = 12;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 349);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addAuthBox);
            this.Controls.Add(this.AddSurnameBox);
            this.Controls.Add(this.AddForenameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTutorBox);
            this.Controls.Add(this.AddYearBox);
            this.Controls.Add(this.AddSendBox);
            this.Controls.Add(this.AddDAbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddUserForm";
            this.Text = "Add User";
            this.Load += new System.EventHandler(this.AddUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AddDAbox;
        private System.Windows.Forms.CheckBox AddSendBox;
        private System.Windows.Forms.ComboBox AddYearBox;
        private System.Windows.Forms.ComboBox AddTutorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AddForenameBox;
        private System.Windows.Forms.TextBox AddSurnameBox;
        private System.Windows.Forms.ComboBox addAuthBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddButton;
    }
}