using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class STUDENT_FORM : Form
    {
        private static DataAccess D = new DataAccess();

        private List<EnTask> T = D.taskList("All Tasks");
        private List<TaskSet> TS = D.tasksetList();

        public STUDENT_FORM()
        {
            InitializeComponent();
        }

        private void STUDENT_FORM_Load(object sender, EventArgs e)
        {
            label3.Text = Environment.UserName.ToString();
            comboBox2.DataSource = D.taskList("All Tasks");
            comboBox2.DisplayMember = "TaskName";
            UpdateForm();
        }

        public void UpdateForm()
        {
            string tsdesc = "";

            foreach (EnTask task in T)
            {
                if (task.TaskName == comboBox2.Text)
                {
                    foreach (TaskSet Taskset in TS)
                    {
                        if (task.TaskSetID == Taskset.TaskSetID)
                        {
                            tsdesc = Taskset.TaskSetDescription;
                        }
                    }
                    aboutTask.Text = $"TaskSet: {task.GetTSName(task.TaskSetID)} \nName: {task.TaskName}\nTheme:{tsdesc}";//task information RHS
                }
            }
            // Your point label:
            string acayear = D.GetAcademicYear();
            int CurrentUserYear1to5 = int.Parse(acayear.Remove(0, 1)) - ((int.Parse(acayear.Remove(0, 1)) - 7) + 6);
            string name = D.getSplitname();
            string[] splitName = name.Split(',');
            string year = splitName[0];
            string forename = splitName[1];
            string surname = splitName[2];
            List<User> User = D.getUser(forename, surname, year, D);
            User U = User[0];
            switch (CurrentUserYear1to5)
            {
                case 1:
                    label8.Text = U.PointScoreY1.ToString();
                    break;

                case 2:
                    label8.Text = U.PointScoreY2.ToString(); break;//show score of this year
                case 3:
                    label8.Text = U.PointScoreY3.ToString(); break;
                case 4:
                    label8.Text = U.PointScoreY4.ToString(); break;
                case 5:
                    label8.Text = U.PointScoreY5.ToString(); break;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                try
                {
                    string name = D.getSplitname();
                    string[] splitName = name.Split(',');
                    string year = splitName[0];
                    string forename = splitName[1];
                    string surname = splitName[2];
                    List<User> User = D.getUser(forename, surname, year, D);
                    User U = User[0];// as the list only contains one item
                    EnTask TtoComplete = null;
                    foreach (EnTask Task in T)
                    {
                        if (Task.TaskName == comboBox2.Text)
                        {
                            TtoComplete = Task;
                        }
                    }
                    string DT = DateTime.Now.ToString();
                    D.CompleteTask(U, TtoComplete, textBox1.Text, DT);

                    button1.BackColor = Color.Green;
                    System.Threading.Thread.Sleep(1000);
                    button1.BackColor = Color.White;
                }
                catch
                {
                    button1.BackColor = Color.Red;
                    button1.Text = "ERROR";
                    System.Threading.Thread.Sleep(1000);//if error occurs
                    button1.BackColor = Color.White;
                    button1.Text = "Submit Task";
                }
                UpdateForm();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SeeComplete SC = new SeeComplete();
            SC.ShowDialog();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UnsubmitCompTask UCT = new UnsubmitCompTask();
            UCT.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}