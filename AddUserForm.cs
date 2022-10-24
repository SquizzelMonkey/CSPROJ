using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
        }

        private string CheckDA()//check box state
        {
            string returnBoolDA = "";
            switch (AddDAbox.CheckState)
            {
                case CheckState.Checked:
                    returnBoolDA = "true";
                    break;

                case CheckState.Unchecked:
                    returnBoolDA = "false";
                    break;
            }
            return returnBoolDA;
        }

        private string checkSEND()//check send status
        {
            string returnBoolSEND = "";
            switch (AddSendBox.CheckState)
            {
                case CheckState.Checked:
                    returnBoolSEND = "true";
                    break;

                case CheckState.Unchecked:
                    returnBoolSEND = "false";
                    break;
            }
            return returnBoolSEND;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataAccess db = new DataAccess();

                bool DAstate = bool.Parse(CheckDA());
                bool SENDstate = bool.Parse(checkSEND());
                string UT = addAuthBox.SelectedItem.ToString();
                bool UTregex = db.regex_Validation(UT, "[Admin|Student|Staff]{1}");
                //REGEX check for validation
                bool Tutorregex = db.regex_Validation(AddTutorBox.Text, "[A|S|P|I|R|E]");
                bool Yearregex = db.regex_Validation(AddYearBox.Text, "[7|8|9|10|11]");
                if (UTregex == true && Tutorregex == true && Yearregex == true)
                {
                    AddButton.BackColor = Color.White;
                    db.AddUser(UT, AddForenameBox.Text, AddSurnameBox.Text, (int.Parse(AddYearBox.Text)).ToString(), AddTutorBox.Text, DAstate, SENDstate);
                }
                else { AddButton.BackColor = Color.Red; }
            }
            catch { AddButton.BackColor = Color.Red; }//if an error occurs, prevent crash
        }

        private void addAuthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}