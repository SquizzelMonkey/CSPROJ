using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class RemoveTaskSet : Form
    {
        private List<TaskSet> TSList = new List<TaskSet>();
        private DataAccess D = new DataAccess();

        public RemoveTaskSet()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        public virtual void UpdateList()
        {
            listBox1.DataSource = TSList;
            listBox1.DisplayMember = "FullInfo";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        public virtual void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FormsDatabase\FormsDatabase\TrackerDatabase.accdb"); // ConnFinder

            string sqlStatement = "DELETE FROM TaskSets WHERE TaskSetID = @ID AND TaskSetName = @name"; // removes taskset

            if (checkBox1.CheckState == CheckState.Checked)
            {
                button1.BackColor = Color.White;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();

                foreach (TaskSet TS in D.tasksetList())
                {
                    if (TS.TaskSetID == int.Parse(textBox1.Text))
                    {
                        string isql = $"DELETE FROM Tasks WHERE TaskSet = {textBox1.Text} ";//removes tasks linked to this taskset
                        OleDbCommand Cmd = new OleDbCommand(isql, conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            else { button1.BackColor = Color.Red; }
            UpdateList();
        }

        private void RemoveTaskSet_Load(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            TSList = D.tasksetList();
            UpdateList();
        }
    }
}