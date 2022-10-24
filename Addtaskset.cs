using System;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class Addtaskset : Form
    {
        public Addtaskset()
        {
            InitializeComponent();
        }

        private void Addtaskset_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            TaskSet TS = new TaskSet();
            TS.TaskSetName = textBox1.Text;// get info
            TS.TaskSetDescription = textBox2.Text;
            D.Addtaskset(TS.TaskSetName, TS.TaskSetDescription);//add
        }
    }
}