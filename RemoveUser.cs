using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class RemoveUser : Form
    {
        private List<User> Users = new List<User>();

        public RemoveUser()
        {
            InitializeComponent();
        }

        private void RemoveUser_Load(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            Users = db.GetUsers("", "All Years", "All Tutor Groups", false, false);
            UpdateList();
        }

        private void UpdateList()
        {
            DataAccess db = new DataAccess();
            listBox1.DataSource = Users;
            listBox1.DisplayMember = "FullInfo";
            Users = db.GetUsers(textBox4.Text, "All Years", "All Tutor Groups", false, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FormsDatabase\FormsDatabase\TrackerDatabase.accdb"); //ConnFinder

            string sqlStatement = "DELETE FROM Users WHERE Forename = @Firstname AND Surname = @lastname AND UserID = @ID";

            if (checkBox1.CheckState == CheckState.Checked)
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@Firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", textBox3.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                //set to remove all tasks associated with this user
            }
            UpdateList();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
    }
}