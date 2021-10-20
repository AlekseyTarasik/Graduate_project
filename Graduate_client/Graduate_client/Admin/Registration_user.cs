using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Admin
{
    public partial class Registration_user : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string InsertUserData = "5";
        private string FIO;
        public Registration_user()
        {
            InitializeComponent();
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && comboBox1.Text != "")
            {
                if(textBox2.Text == textBox3.Text)
                {
                    var message = InsertUserData + Delimiter + textBox1.Text + Delimiter + textBox2.Text + Delimiter + comboBox1.SelectedItem + Delimiter + textBox3.Text + Delimiter + textBox4.Text + Delimiter + textBox5.Text + Delimiter + textBox6.Text + Delimiter + textBox7.Text + Delimiter + textBox8.Text;
                    FIO = textBox4.Text + " " + textBox5.Text + " " + textBox6.Text;
                    SendUserData(message, FIO);
                }
                else
                    MessageBox.Show("Проверьте правильность ввода пароля и его копии в соотвествующих полях!");
            }
            else
                MessageBox.Show("Заполните все поля корректно, иначе вы не сможете создать нового пользователя!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private static void SendUserData(string message, string fio)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                var stream = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
                MessageBox.Show("Аккаунт для " + fio + "создан");
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
