using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class UnsubmitCompTask : Form
    {
        public UnsubmitCompTask()
        {
            InitializeComponent();
        }

        private void UnsubmitCompTask_Load(object sender, EventArgs e)
        {
            string name = D.getSplitname();
            string[] splitName = name.Split(',');
            string year = splitName[0];
            string forename = splitName[1];
            string surname = splitName[2];

            List<User> User = D.getUser(forename, surname, year, D);
            User U = User[0];//can only return one user in the list as surname and year are unique in the school system.
            CompTasks = D.VeiwCompletedTasks(U);
            listBox1.DataSource = CompTasks;
            listBox1.DisplayMember = "FullInfo";
        }

        private DataAccess D = new DataAccess();
        private List<CompletedTask> CompTasks = new List<CompletedTask>();

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = D.getSplitname();
            string[] splitName = name.Split(',');
            string year = splitName[0];
            string forename = splitName[1];
            string surname = splitName[2];

            List<User> User = D.getUser(forename, surname, year, D);
            User U = User[0];//can only return one user in the list as surname and year are unique in the school system.
            CompletedTask CT = (CompletedTask)listBox1.SelectedItem;
            string tstamp = CT.TStamp;

            D.unsubmitTask(U, tstamp, CT);//unsubmit
        }
    }
}