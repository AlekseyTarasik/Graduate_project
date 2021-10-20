using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using Graduate_client.Forms_1lvl;

namespace Graduate_client
{
    public partial class Main_authorization : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";

        private const string VerificationUsers = "1";
        private static string mess;
        public Main_authorization()
        {

            InitializeComponent();
            Users.idUser = 1;
            Users.typeUser = null;
            Users.l_nameUser = null;
            Users.f_nameUser = null;
            Users.m_nameUser = null;
            Users.name_filialUser = null;
            Users.positionUser = null;
            Users.blockUser = 0;
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            var message = VerificationUsers + Delimiter + txt_login.Text + Delimiter + txt_pass.Text;
            Users.loginUser = txt_login.Text;
            Users.passwordUser = txt_pass.Text;
            SendAndGetLogPassUser(message);
            if (mess == "ok" && Users.typeUser == "admin")
            {
                Hide();
                MenuAdmin admin_pers = new MenuAdmin();
                admin_pers.ShowDialog();
                Close();
            }
            else if (mess == "ok" && Users.typeUser == "manager")
            {
                Hide();
                MenuExpertManager manager_pers = new MenuExpertManager();
                manager_pers.ShowDialog();
                Close();
            }
            else if (mess == "ok" && Users.typeUser == "expert")
            {
                Hide();
                MenuExpert expert_pers = new MenuExpert();
                expert_pers.ShowDialog();
                Close();
            }
            else if (mess == "Account is blocked!")
            {
                MessageBox.Show("Аккаунт пользователя заблокирован! Обратитесь к администратору!");
            }
            else if (mess != "uncorrect login or password")
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
        }

        private void SendAndGetLogPassUser(string message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                var stream = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                data = new byte[1024];
                var builder = new StringBuilder();
                do
                {
                    var bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (stream.DataAvailable);

                message = builder.ToString();
                if (message != "uncorrect login or password")
                {
                    var karasb = message.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    mess = karasb[0];
                    Users.idUser = int.Parse(karasb[1]);
                    Users.typeUser = karasb[4];
                    Users.l_nameUser = karasb[5];
                    Users.f_nameUser = karasb[6];
                    Users.m_nameUser = karasb[7];
                    Users.name_filialUser = karasb[8];
                    Users.positionUser = karasb[9];
                    Users.blockUser = int.Parse(karasb[10]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неправильный логин или пароль!");
                MessageBox.Show("Необходимо запустить сервер!!!");
            }
            finally
            {
                if (client != null) client.Close();
            }
        }
    }
}
