﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class AmendUserForm : Form
    {
        public AmendUserForm()
        {
            InitializeComponent();
        }

        private List<User> Users = new List<User>();

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateRHS();
        }

        private void AmendUserForm_Load(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            Users = db.GetUsers("", "All Years", "All Tutor Groups", false, false);
            UpdateList();
            UpdateRHS();
        }

        private void UpdateList()
        {
            DataAccess db = new DataAccess();
            listBox1.DataSource = Users;
            listBox1.DisplayMember = "FullInfo";
            Users = db.GetUsers(textBox9.Text, "All Years", "All Tutor Groups", false, false);
        }

        private void UpdateRHS()
        {
            DataAccess db = new DataAccess();
            //update right hand side

            User U = (User)listBox1.SelectedItem;
            AuthBox.Text = U.UserType;
            label13.Text = U.ID.ToString();
            Forenamebox.Text = U.Forename;
            Surnamebox.Text = U.Surname;

            if (U.DA == true)
            {
                DAbox.CheckState = CheckState.Checked;
            }
            else { DAbox.CheckState = CheckState.Unchecked; }

            if (U.SEND == true)
            {
                SENDbox.CheckState = CheckState.Checked;
            }
            else { SENDbox.CheckState = CheckState.Unchecked; }
            int NewYear = 12 - (U.YearGroup - int.Parse(db.GetAcademicYear()));

            Yearbox.Text = (NewYear).ToString();
            Tutorbox.Text = U.TutorGroup;
            PSY1.Text = U.PointScoreY1.ToString();
            PSY2.Text = U.PointScoreY2.ToString();
            PSY3.Text = U.PointScoreY3.ToString();
            PSY4.Text = U.PointScoreY4.ToString();
            PSY5.Text = U.PointScoreY5.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            UpdateRHS();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            bool DA;
            bool SEND;
            bool Usertype = D.regex_Validation("[Admin|Staff|Student]", AuthBox.Text);
            //name will not be checked as it is generated by the school's system and should therefore be valid anyway
            bool Form = D.regex_Validation("[A|S|P|I|R|E]", Tutorbox.Text);
            if (DAbox.CheckState == CheckState.Checked)
            {
                DA = true;
            }
            else { DA = false; }
            if (SENDbox.CheckState == CheckState.Checked)
            {
                SEND = true;
            }
            else { SEND = false; }
            if (Usertype == Form == true)//check for erroneus form and usertype
            {
                D.AmendUser(label13.Text, AuthBox.Text, Forenamebox.Text, Surnamebox.Text, Yearbox.Text, Tutorbox.Text, DA, SEND, PSY1.Text, PSY2.Text, PSY3.Text, PSY4.Text, PSY5.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (AmendStudentTasks AST = new AmendStudentTasks())
            {
                AST.AmendingStudent = (User)listBox1.SelectedItem;//pass which user the admin selects
                AST.ShowDialog();
            }
        }

        private void PSY1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}