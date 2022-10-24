using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class AmendStudentTasks : Form
    {
        public AmendStudentTasks()
        {
            InitializeComponent();
        }

        private static DataAccess D = new DataAccess();
        public User AmendingStudent;//who the admin selected to amend
        private List<EnTask> T = D.taskList("All Tasks");
        private List<TaskSet> TS = D.tasksetList();

        private void AmendStudentTasks_Load(object sender, EventArgs e)
        {
            User U = AmendingStudent;

            comboBox2.DataSource = D.taskList("All Tasks");
            comboBox2.DisplayMember = "TaskName";//only display name
            UpdateForm(U);
        }

        public void UpdateForm(User U)
        {
            label3.Text = U.Forename + " " + U.Surname; // sets amended student name
            string tsdesc = "";

            foreach (EnTask task in T)
            {
                if (task.TaskName == comboBox2.Text)
                {
                    foreach (TaskSet Taskset in TS)
                    {
                        if (task.TaskSetID == Taskset.TaskSetID)
                        {
                            tsdesc = Taskset.TaskSetDescription;// show description if correct task
                        }
                    }
                    aboutTask.Text = $"TaskSet: {task.GetTSName(task.TaskSetID)} \nName: {task.TaskName}\nTheme:{tsdesc}";
                }
            }
            // student point label:
            string acayear = D.GetAcademicYear();
            int CurrentUserYear1to5 = int.Parse(acayear.Remove(0, 1)) - ((int.Parse(acayear.Remove(0, 1)) - 7) + 6);

            switch (CurrentUserYear1to5)
            {
                case 1:
                    label8.Text = U.PointScoreY1.ToString();
                    break;

                case 2:
                    label8.Text = U.PointScoreY2.ToString(); break;
                case 3:
                    label8.Text = U.PointScoreY3.ToString(); break;
                case 4:
                    label8.Text = U.PointScoreY4.ToString(); break;
                case 5:
                    label8.Text = U.PointScoreY5.ToString(); break;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm(AmendingStudent);
        }

 

        private void button2_Click(object sender, EventArgs e)
        {
            SeeComplete SC = new SeeComplete();
            SC.Student = AmendingStudent;
            SC.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                try
                {
                    User U = AmendingStudent;
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

                    System.Threading.Thread.Sleep(1000);
                    button1.BackColor = Color.Green;//button indications
                    System.Threading.Thread.Sleep(1000);
                    button1.BackColor = Color.White;
                }
                catch
                {
                    button1.BackColor = Color.Red;
                    System.Threading.Thread.Sleep(1000);//show error occurred
                    button1.BackColor = Color.White;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UnsubmitCompTask UCT = new UnsubmitCompTask();
            UCT.ShowDialog();
        }
    }
}