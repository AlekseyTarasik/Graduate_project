using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graduate_client.Admin;

namespace Graduate_client.Forms_1lvl
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            User_data user_data = new User_data();
            user_data.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Inspections insp = new Inspections();
            insp.ShowDialog();
            Close();
            /*Hide();
            Change_inspection_2 change_insp = new Change_inspection_2();
            change_insp.ShowDialog();
            Close();*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Personal_data personal_data = new Personal_data();
            personal_data.ShowDialog();
            Close();
        }
    }
}
