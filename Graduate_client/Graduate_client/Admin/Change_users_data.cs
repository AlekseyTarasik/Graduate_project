using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Admin
{
    public partial class Change_users_data : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetEmployeeData = "10";
        private const string SetUsersData = "4";
        public Change_users_data()
        {
            this.TopMost = true;
            InitializeComponent();
            textBox1.Text = Change_user.idUser;
            textBox1.Enabled = false;
            textBox2.Text = Change_user.loginUser;
            textBox3.Text = Change_user.passwordUser;
            textBox4.Text = Change_user.typeUser;
            textBox5.Text = Change_user.l_nameUser;
            textBox5.Enabled = false;
            textBox6.Text = Change_user.f_nameUser;
            textBox6.Enabled = false;
            textBox7.Text = Change_user.m_nameUser;
            textBox7.Enabled = false;
            textBox8.Text = Change_user.name_filialUser;
            textBox9.Text = Change_user.positionUser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox8.Text != "" && textBox9.Text != "")
            {
                var message = SetUsersData + Delimiter + textBox1.Text + Delimiter + textBox2.Text + Delimiter + textBox3.Text + Delimiter + textBox4.Text + Delimiter + textBox5.Text + Delimiter + textBox6.Text
                    + Delimiter + textBox7.Text + Delimiter + textBox8.Text + Delimiter + textBox9.Text;
                SendUsersData(message);
                MessageBox.Show(message);
            }
            else
            {
                MessageBox.Show("Заполните все поля, иначе вы не сможете изменить данные пользователя!");
            }
        }
        private static void SendUsersData(string message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                var stream = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                MessageBox.Show("Пользовательские данные изменены!");
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
