using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class VeiwUsersForm : Form
    {
        private List<User> Users = new List<User>();

        public VeiwUsersForm()
        {
            InitializeComponent();
            //default Boxes
            yearGroup.SelectedItem = "All Years";
            tutorGroup.SelectedItem = "All Tutor Groups";
            UpdateList();
        }

        private void UpdateList()
        {
            UserFoundListBox.DataSource = Users;
            UserFoundListBox.DisplayMember = "FullInfo";
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            bool DAstate = bool.Parse(CheckDA());
            bool SENDstate = bool.Parse(checkSEND());
            try
            {
                bool yearval = db.regex_Validation(yearGroup.SelectedItem.ToString(), "[All Years|11|10|9|8|7]{1}");
                bool tutorval = db.regex_Validation(yearGroup.SelectedItem.ToString(), "[All Groups|A|S|P|I|R|E]{1}");//check validity
                if (yearval == true && tutorval == true)
                {
                    Users = db.GetUsers(lastNameTB.Text, yearGroup.SelectedItem.ToString(), tutorGroup.SelectedItem.ToString(), DAstate, SENDstate);
                    SearchButton.BackColor = Color.White;
                }
                else
                {
                    SearchButton.BackColor = Color.Red;
                }
            }
            catch { SearchButton.BackColor = Color.Red; }//error catching
            UpdateList();
        }

        private string CheckDA()
        {
            string returnBoolDA = "";
            switch (DaBox.CheckState)
            {
                case CheckState.Checked:
                    returnBoolDA = "true";
                    break;

                case CheckState.Unchecked:
                    returnBoolDA = "false";
                    break;
            }
            return returnBoolDA;
        }

        private string checkSEND()
        {
            string returnBoolSEND = "";
            switch (SendBox.CheckState)
            {
                case CheckState.Checked:
                    returnBoolSEND = "true";
                    break;

                case CheckState.Unchecked:
                    returnBoolSEND = "false";
                    break;
            }
            return returnBoolSEND;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTaskForm ATF = new AddTaskForm();
            ATF.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TaskSetsControllerForm TSF = new TaskSetsControllerForm();
            TSF.Show();
        }

        private void UserFoundListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            TasksControllerForm TCF = new TasksControllerForm();
            TCF.Show();
        }

        private void yearGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report R = new Report();
            User U = (User)UserFoundListBox.SelectedItem;
            R.AddLine(U.FullInfo);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            PassChange PC = new PassChange();
            PC.Show();
        }

        private void button6_Click(object sender, EventArgs e)//REWARDS
        {
            DataAccess D = new DataAccess();
            Rewards R = new Rewards();
            R.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UsercontrolForm UCF = new UsercontrolForm();
            UCF.Show();
        }//Note:button click events auto generated. for some reason causes names to seemingly mismatch, but it does work.
    }
}