using System;
using System.Threading;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            DataAccess DA = new DataAccess();
            DA.CryptoHash("",10);
            this.Show();
            pictureBox1.Show();
            label1.Show();
            AddTick(50);//multiples of 1/10 seconds. Gives time to look up Usertype set to 50 when done

            //Username is overriden with a valid stringin DataAccess.getsplitname()for demonstration (STUDENT)
          string FormToLoad = DA.GetUsertype(); //Loads the right level of auth. regex will close application if username is invalid.
            //Logging in with STUART LUCAS Student Account (overwritten from environment username in code)
        // string FormToLoad = "STAFF"; // FOR TESTING PURPOSES
            switch (FormToLoad)
            {
                case "ADMIN":
                    VeiwUsersForm VUF_ADMIN = new VeiwUsersForm();
                    VUF_ADMIN.ShowDialog();
                    break;

                case "STAFF":
                    StaffForm VUF_STAFF = new StaffForm();
                    VUF_STAFF.ShowDialog();
                    break;

                case "STUDENT":
                    STUDENT_FORM StudentForm = new STUDENT_FORM();
                    StudentForm.ShowDialog();
                    break;
            }
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void AddTick(int tick)//RECURSION
        {
            Thread.Sleep(100);//delay
            if (tick > 0)//base case
            {
                progressBar1.Increment(3);
                AddTick(tick - 1);//takes one off the tick count passed in
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}