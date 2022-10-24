using System;
using System.Windows.Forms;
using System.Drawing;

namespace FormsDatabase
{
    public partial class PassChange : Form
    {
        private DataAccess D = new DataAccess();

        public PassChange()
        {
            InitializeComponent();
        }

        private void PassChange_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (D.verifyPASS(textBox1.Text) == true)
            {
                D.SetPassword(textBox2.Text);
            }
            else
            {
                button1.BackColor = Color.Red;
                System.Threading.Thread.Sleep(100);
                button1.BackColor = Color.White;//show error occurred
            }
        }
    }
}