using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Expert_manager
{
    public partial class Preview_employee : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetEmployeeData = "10";
        public Preview_employee()
        {
            InitializeComponent();
            TopMost = true;
            GetEmployeeDataGrid(GetEmployeeData);
        }
        private void GetEmployeeDataGrid(string message)
        {
            string empData = "Эксперт по оценке";
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
                    adapter = new SqlDataAdapter("SELECT * FROM Employee_data WHERE subunit_emp = '" + empData + "'", conn);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[0].HeaderText = "Идентификационный номер";
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[1].HeaderText = "Фамилия";
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[2].HeaderText = "Имя";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[3].HeaderText = "Отчество";
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "Должность";
                    dataGridView1.Columns[4].Width = 150;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "Номер телефона";
                    dataGridView1.Columns[5].Width = 150;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[6].HeaderText = "Дата рождения";
                    dataGridView1.Columns[6].Width = 150;
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Inspection_data.FIO_expert.Length > 0 && Inspection_data.phone_expert.Length > 0)
                {
                    MessageBox.Show("Данные успешно скопированы");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы ничего не выбрали!");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string l_name;
            string f_name; 
            string m_name;
            DataGridViewCell ctg = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                ctg = selectedCell;
                break;
            }
            if (ctg != null)
            {
                DataGridViewRow row = ctg.OwningRow;
                l_name = row.Cells[1].Value.ToString();
                f_name = row.Cells[2].Value.ToString();
                m_name = row.Cells[3].Value.ToString();
                Inspection_data.phone_expert = row.Cells[5].Value.ToString();
                Inspection_data.FIO_expert = l_name.Trim(' ') + " " + f_name.Remove(l_name.Length - (l_name.Length-1)) + ". " + m_name.Remove(m_name.Length - (m_name.Length - 1)) + ".";
            }
        }
    }
}
