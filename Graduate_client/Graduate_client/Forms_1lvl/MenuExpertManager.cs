using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graduate_client.Expert_manager;

namespace Graduate_client.Forms_1lvl
{
    public partial class MenuExpertManager : Form
    {
        public MenuExpertManager()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            All_inspections_manager all_insp_manager = new All_inspections_manager();
            all_insp_manager.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Current_inspection_manager curr_insp_manager = new Current_inspection_manager();
            curr_insp_manager.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Personal_data_manager personal_data_manager = new Personal_data_manager();
            personal_data_manager.ShowDialog();
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
