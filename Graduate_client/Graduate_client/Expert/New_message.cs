using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduate_client.Expert
{
    public partial class New_message : Form
    {
        public New_message()
        {
            this.TopMost = true;
            InitializeComponent();
            label2.Text = Users.l_nameUser.Trim(' ') + " " + Users.f_nameUser.Remove(Users.f_nameUser.Length - (Users.f_nameUser.Length - 1)) + ". " + Users.m_nameUser.Remove(Users.m_nameUser.Length - (Users.m_nameUser.Length - 1)) + ".";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
