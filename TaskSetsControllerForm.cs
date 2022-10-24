using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class TaskSetsControllerForm : Form
    {
        private List<TaskSet> TSList = new List<TaskSet>();

        public TaskSetsControllerForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void TaskSetsForm_Load(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            TSList = D.tasksetList();
            UpdateList();
        }

        private void UpdateList()
        {
            listBox1.DataSource = TSList;
            listBox1.DisplayMember = "FullInfo";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Addtaskset ATSF = new Addtaskset();
            ATSF.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveTaskSet R = new RemoveTaskSet();
            R.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Report R = new Report();
            TaskSet TS = (TaskSet)listBox1.SelectedItem;
            R.AddLine(TS.FullInfo);
        }
    }
}