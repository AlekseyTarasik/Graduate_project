using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Admin
{
    public partial class User_data : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string BlockUser = "2";
        private const string UnBlockUser = "3";
        private const string GetUserDataGrid = "6";
        private string karasik;
        public User_data()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
            GetUsersDataGrid(GetUserDataGrid);
        }
        private  void GetUsersDataGrid(string message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                NetworkStream client_streem = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                client_streem.Write(data, 0, data.Length);
                data = new byte[1024];
                var builder = new StringBuilder();
                do
                {
                    var bytes = client_streem.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (client_streem.DataAvailable);
                message = builder.ToString();         
                string co = @"Data Source=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
                DataSet ds = new DataSet();
                SqlDataAdapter adapter;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.AllowUserToAddRows = false;
                using (SqlConnection conn = new SqlConnection(co))
                {
                    conn.Open();
                    adapter = new SqlDataAdapter("SELECT * FROM User_data", conn);

                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns["id_user"].ReadOnly = true;
                }
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

        
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"192.168.205.135\SQLEXPRESS";
            string database = "Graduate_tarasik";
            return GetDBConnection(datasource, database);
        }
        public static SqlConnection
                 GetDBConnection(string datasource, string database)
        {

            string connString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            User_data user_data = new User_data();
            user_data.ShowDialog();
            Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Inspections insp = new Inspections();
            insp.ShowDialog();
            Close();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Personal_data personal_data = new Personal_data();
            personal_data.ShowDialog();
            Close();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Hide();
            Registration_user registr_user = new Registration_user();
            registr_user.ShowDialog();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Change_users_data change_user_data = new Change_users_data();
            change_user_data.ShowDialog();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var message = BlockUser + Delimiter + textBox2.Text;
            SendUsersData(message);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var message = UnBlockUser + Delimiter + textBox2.Text;
            SendUsersData(message);
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
                MessageBox.Show("Операция прошла успешно!");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Items[0].ToString() == "Фамилия" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Фамилия");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account FROM User_data where last_name LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox1.Items[1].ToString() == "Тип аккаунта" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Тип аккаунта");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account FROM User_data where type_user LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox1.Items[2].ToString() == "Название филиала" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Название филиала");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account FROM User_data where name_filial LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox1.Items[3].ToString() == "Должность" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Должность");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account FROM User_data where position_user LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox1.Items[4].ToString() == "Разблокирован" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Разблокирован");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account FROM User_data where block_account LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    MessageBox.Show("Необходимо ввести слово для поиска!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell ctg = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                ctg = selectedCell;
                break;
            }
            if (ctg != null)
            {
                DataGridViewRow row = ctg.OwningRow;
                Change_user.idUser= row.Cells[0].Value.ToString();
                Change_user.loginUser = row.Cells[1].Value.ToString();
                Change_user.passwordUser = row.Cells[2].Value.ToString();
                Change_user.typeUser = row.Cells[3].Value.ToString();
                Change_user.l_nameUser = row.Cells[4].Value.ToString();
                Change_user.f_nameUser = row.Cells[5].Value.ToString();
                Change_user.m_nameUser = row.Cells[6].Value.ToString();
                Change_user.name_filialUser = row.Cells[7].Value.ToString();
                Change_user.positionUser = row.Cells[8].Value.ToString();
                Change_user.blockUser = row.Cells[9].Value.ToString();
                textBox2.Text = row.Cells[0].Value.ToString();
                karasik = "okay";
            }
        }
    }
}
