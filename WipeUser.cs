using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class WipeUser : Form
    {
        public WipeUser()
        {
            InitializeComponent();
        }

        private List<User> Users = new List<User>();

        private void WipeUser_Load(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            Users = db.GetUsers("", "All Years", "All Tutor Groups", false, false);//fill list
            UpdateList();
        }

        private void UpdateList()
        {
            DataAccess db = new DataAccess();
            listBox1.DataSource = Users;
            listBox1.DisplayMember = "FullInfo";
            Users = db.GetUsers(textBox4.Text, "All Years", "All Tutor Groups", false, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            if (checkBox1.CheckState == CheckState.Checked)
            {
                D.AnnihilateUser(textBox3.Text);//call the SQl method
            }
        }
    }
}