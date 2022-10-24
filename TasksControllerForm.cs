using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class TasksControllerForm : Form
    {
        private List<EnTask> TaskList = new List<EnTask>();

        public TasksControllerForm()
        {
            InitializeComponent();
        }

        private void TasksControllerForm_Load(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();

            TaskList = D.taskList("All Tasks");
            comboBox1.DataSource = D.tasksetList();
            comboBox1.DisplayMember = "TaskSetName";
            UpdateList("All Tasks");
        }

        private void UpdateList(string input)
        {
            DataAccess D = new DataAccess();

            if (input != "All Tasks")
            {
                TaskList = D.taskList(input);//if specified
            }
            else
            {
                TaskList = D.taskList("All Tasks");//if general
            }
            listBox1.DataSource = TaskList;
            listBox1.DisplayMember = "FullInfo";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddTaskForm ATF = new AddTaskForm();
            ATF.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveTask RTF = new RemoveTask();
            RTF.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();

            string input = D.TSID(comboBox1.Text);
            UpdateList(input);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateList("All Tasks");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report R = new Report();
            EnTask T = (EnTask)listBox1.SelectedItem;
            R.AddLine(T.FullInfo);
        }
    }
}