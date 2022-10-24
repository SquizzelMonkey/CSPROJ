using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();
        }

        private void AddTaskForm_Load(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            comboBox1.DataSource = D.tasksetList();
            comboBox1.DisplayMember = "TaskSetName";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess D = new DataAccess();
            try
            {
                button1.BackColor = Color.White;
                D.Addtask(comboBox1.Text, textBox2.Text, int.Parse(textBox1.Text));
            }
            catch { button1.BackColor = Color.Red; }
        }
    }
}