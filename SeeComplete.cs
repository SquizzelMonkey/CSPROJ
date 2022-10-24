using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class SeeComplete : Form
    {
        private DataAccess D = new DataAccess();

        public SeeComplete()
        {
            InitializeComponent();
        }

        public User Student;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void SeeComplete_Load(object sender, EventArgs e)
        {
            string name = D.getSplitname();
            string[] splitName = name.Split(',');
            string year = splitName[0];
            string forename = splitName[1];
            string surname = splitName[2];
            // User U = D.getUser(forename, surname, year, D);
            if (Student == null)
            {
                List<User> User = D.getUser(forename, surname, year, D);
                User U = User[0];
                UpdateList(U);
            }
            else { User U = Student; UpdateList(U); }
        }

        public void UpdateList(User U)
        {
            List<KeyValuePair<string, string>> KeyValueList = new List<KeyValuePair<string, string>>();
            foreach (CompletedTask CompTask in D.VeiwCompletedTasks(U))
            {
                foreach (EnTask T in D.taskList("All Tasks"))
                {
                    if (T.TaskID == CompTask.TaskID)
                    {
                        KeyValueList.Add(
                    new KeyValuePair<string, string>(CompTask.TStamp + " : " + T.TaskName, CompTask.TaskID.ToString()));//displayes the right information as pairs
                    }
                }
            }
            listBox1.DisplayMember = "Key";
            listBox1.ValueMember = "Value";
            listBox1.DataSource = KeyValueList;
        }
    }
}