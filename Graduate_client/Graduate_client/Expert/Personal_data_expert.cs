using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Graduate_client.Expert
{
    public partial class Personal_data_expert : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";

        private const string SetUsersData = "4";
        public Personal_data_expert()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
            label2.Text = Users.idUser.ToString();
            textBox1.Text = Users.loginUser;
            textBox2.Text = Users.passwordUser;
            if (Users.typeUser == "expert")
                textBox3.Text = "эксперт";
            textBox4.Text = Users.l_nameUser;
            textBox5.Text = Users.f_nameUser;
            textBox6.Text = Users.m_nameUser;
            textBox7.Text = Users.name_filialUser;
            textBox8.Text = Users.positionUser;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }

        private void linkUsers1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            All_inspections all_insp = new All_inspections();
            all_insp.ShowDialog();
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Current_inspections curr_insp = new Current_inspections();
            curr_insp.ShowDialog();
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Personal_data_expert personal_data_exp = new Personal_data_expert();
            personal_data_exp.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                var message = SetUsersData + Delimiter + Users.idUser + Delimiter + textBox1.Text + Delimiter + textBox2.Text + Delimiter + Users.typeUser + Delimiter + Users.l_nameUser + Delimiter + Users.f_nameUser + Delimiter + Users.m_nameUser + Delimiter + Users.name_filialUser + Delimiter + Users.positionUser + Delimiter + Users.blockUser;
                SendUserData(message);
                Users.loginUser = textBox1.Text;
                Users.passwordUser = textBox2.Text;
            }
            else
            {
                MessageBox.Show("Логин либо пароль не могут быть пустыми!");
            }
        }

        private static void SendUserData(string message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                var stream = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                MessageBox.Show("Личные данные изменены!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client != null) client.Close();
            }
        }
    }
}
