using System;

namespace FormsDatabase
{
    public partial class StaffForm : VeiwUsersForm
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        private void TesterFormStaffInherit_Load(object sender, EventArgs e)
        {//Remove the option to trigger admin commands by hiding the buttons
            button5.Hide();
            button6.Hide();
            button1.Hide();
            button3.Hide();
            button7.Hide();
  
        }



        private void SendEmail()
        {
            System.Diagnostics.Process.Start("mailto:enrichment@lhs.aspireplus.org.uk?&subject=REQUEST_DATABASE_AMENDMENT");//default mail for enrichment
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendEmail();
        }
    }
}