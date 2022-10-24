using System;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class WipeYear : Form
    {
        public WipeYear()
        {
            InitializeComponent();
        }

        private void WipeYear_Load(object sender, EventArgs e)
        {
        }

        public void Wipe()
        {
            DataAccess D = new DataAccess();
            string acayear = D.GetAcademicYear();
                D.AnnihilateYear(textBox1.Text);
            
        }

        public void UpdateLabel()
        {
            DataAccess D = new DataAccess();
            string acayear = D.GetAcademicYear();
            if ((int.Parse(acayear)) + 12 - int.Parse(textBox1.Text) <= 11 && (D.regex_Validation("[0-9]{4}", textBox1.Text) == true))
            {
                label3.Text = "WARNING: ABOUT TO DELETE AN ACTIVE YEAR";
            }
            else { label3.Text = ""; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                Wipe();
                textBox1.Clear();
            }
        }
    }
}