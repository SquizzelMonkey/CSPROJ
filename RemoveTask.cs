using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FormsDatabase
{
    public partial class RemoveTask : RemoveTaskSet
    {
        DataAccess D = new DataAccess();
        public RemoveTask()
        {
            InitializeComponent();
            checkBox1.Text = "Remove This Task";//overwrite inherited text
        }
       public override void UpdateList()
        {
            listBox1.DataSource = D.taskList("All Tasks");
            listBox1.DisplayMember = "FullInfo";
        }
        public override void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\FormsDatabase\FormsDatabase\TrackerDatabase.accdb"); // ConnFinder

            string sqlStatement = "DELETE FROM Tasks WHERE TaskID = @ID AND Task = @name";

            if (checkBox1.CheckState == CheckState.Checked)
            {
                button1.BackColor = Color.White;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sqlStatement, conn);
                cmd.Parameters.AddWithValue("@ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@name", textBox2.Text);//add SQl parameters
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            else { button1.BackColor = Color.Red; }
            UpdateList();
        }
        private void RemoveTask_Load(object sender, EventArgs e)
        {
            UpdateList();
        }
    }
}
