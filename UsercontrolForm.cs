using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class UsercontrolForm : Form
    {
        private DataAccess D = new DataAccess();
        private bool verified;

        public UsercontrolForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUserForm addnewuser = new AddUserForm();
            addnewuser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveUser remuser = new RemoveUser();
            remuser.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ANHILLIATEUSERFORM
            if (verified == true)
            {
                WipeUser WU = new WipeUser();
                WU.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AmendUserForm AUF = new AmendUserForm();
            AUF.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkval() == true)
            {
                verified = true;
            }
        }

        public bool checkval()
        {
            bool val = false;
            val = D.verifyPASS(textBox1.Text);
            return val;
        }

        private void UsercontrolForm_Load(object sender, EventArgs e)
        {
            button6.BackColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ANNYEARFORM
            if (verified == true)
            {
                WipeYear WY = new WipeYear();
                WY.ShowDialog();
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (D.verifyPASS(textBox1.Text) == true)//password verification
            {
                verified = true;//verify for this form
                textBox1.Clear();
                button6.BackColor = Color.Green;//indicate verified
            }
        }
    }
}