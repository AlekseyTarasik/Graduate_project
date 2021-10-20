using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graduate_client.Expert;

namespace Graduate_client.Forms_1lvl
{
    public partial class MenuExpert : Form
    {
        public MenuExpert()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            All_inspections all_insp = new All_inspections();
            all_insp.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Current_inspections curr_insp = new Current_inspections();
            curr_insp.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Personal_data_expert personal_data = new Personal_data_expert();
            personal_data.ShowDialog();
            Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }
    }
}
