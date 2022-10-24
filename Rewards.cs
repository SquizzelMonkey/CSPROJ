using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsDatabase
{
    public partial class Rewards : Form
    {
        public Rewards()
        {
            InitializeComponent();
        }
        DataAccess D = new DataAccess();
        private void Rewards_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = D.RewardScan();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
