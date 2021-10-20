using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Expert_manager
{
    public partial class Preview_insurance_contract : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetInsuranceData = "11";
        public Preview_insurance_contract()
        {
            InitializeComponent();
            TopMost = true;
            GetInsuranceDataGrid(GetInsuranceData);
        }
        private void GetInsuranceDataGrid(string message)
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
                    adapter = new SqlDataAdapter("SELECT * FROM Insurance_contract", conn);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[0].HeaderText = "Идентификационный номер";
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[1].HeaderText = "Тип страхования";
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[2].HeaderText = "Вид страхования";
                    dataGridView1.Columns[2].Width = 150;
                    dataGridView1.Columns[3].ReadOnly = true;
                    dataGridView1.Columns[3].HeaderText = "Номер договора";
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "Объект страхования";
                    dataGridView1.Columns[4].Width = 150;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "Страховой взнос";
                    dataGridView1.Columns[5].Width = 150;
                    dataGridView1.Columns[6].ReadOnly = true;
                    dataGridView1.Columns[6].HeaderText = "Сумма страховой выплаты";
                    dataGridView1.Columns[6].Width = 150;
                    dataGridView1.Columns[7].ReadOnly = true;
                    dataGridView1.Columns[7].HeaderText = "Начало действия договора";
                    dataGridView1.Columns[7].Width = 150;
                    dataGridView1.Columns[8].ReadOnly = true;
                    dataGridView1.Columns[8].HeaderText = "Окончание действия договора";
                    dataGridView1.Columns[8].Width = 150;
                    dataGridView1.Columns[9].ReadOnly = true;
                    dataGridView1.Columns[9].HeaderText = "Фамилия страхового агента";
                    dataGridView1.Columns[9].Width = 150;
                    dataGridView1.Columns[10].ReadOnly = true;
                    dataGridView1.Columns[10].HeaderText = "Имя страхового агента";
                    dataGridView1.Columns[10].Width = 150;
                    dataGridView1.Columns[11].ReadOnly = true;
                    dataGridView1.Columns[11].HeaderText = "Отчество страхового агента";
                    dataGridView1.Columns[11].Width = 150;
                    dataGridView1.Columns[12].ReadOnly = true;
                    dataGridView1.Columns[12].HeaderText = "Должность страхового агента";
                    dataGridView1.Columns[12].Width = 150;
                    dataGridView1.Columns[13].ReadOnly = true;
                    dataGridView1.Columns[13].HeaderText = "Номер телефона";
                    dataGridView1.Columns[13].Width = 150;
                    dataGridView1.Columns[14].ReadOnly = true;
                    dataGridView1.Columns[14].HeaderText = "Фамилия клиента";
                    dataGridView1.Columns[14].Width = 150;
                    dataGridView1.Columns[15].ReadOnly = true;
                    dataGridView1.Columns[15].HeaderText = "Имя клиента";
                    dataGridView1.Columns[15].Width = 150;
                    dataGridView1.Columns[16].ReadOnly = true;
                    dataGridView1.Columns[16].HeaderText = "Отчество клиента";
                    dataGridView1.Columns[16].Width = 150;
                    dataGridView1.Columns[17].ReadOnly = true;
                    dataGridView1.Columns[17].HeaderText = "Тип клиента";
                    dataGridView1.Columns[17].Width = 150;
                    dataGridView1.Columns[18].ReadOnly = true;
                    dataGridView1.Columns[18].HeaderText = "Номер телефона клиента";
                    dataGridView1.Columns[18].Width = 150;
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
                if (Inspection_data.type_insur.Length > 0 && Inspection_data.subtype_insur.Length > 0 && Inspection_data.number_insur.Length > 0 
                    && Inspection_data.object_inspect.Length > 0 && Inspection_data.FIO_employee.Length > 0 && Inspection_data.phone_employee.Length > 0 
                    && Inspection_data.FIO_victim.Length > 0 && Inspection_data.type_victim.Length > 0 && Inspection_data.phone_victim.Length > 0)
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
            string l_name_emp;
            string f_name_emp;
            string m_name_emp;
            string l_name_cust;
            string f_name_cust;
            string m_name_cust;
            DataGridViewCell ctg = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                ctg = selectedCell;
                break;
            }
            if (ctg != null)
            {
                DataGridViewRow row = ctg.OwningRow;
                Inspection_data.type_insur = row.Cells[1].Value.ToString();
                Inspection_data.subtype_insur = row.Cells[2].Value.ToString();
                Inspection_data.number_insur = row.Cells[3].Value.ToString();
                Inspection_data.object_inspect = row.Cells[4].Value.ToString();
                l_name_emp = row.Cells[9].Value.ToString();
                f_name_emp = row.Cells[10].Value.ToString();
                m_name_emp = row.Cells[11].Value.ToString();
                Inspection_data.phone_employee = row.Cells[13].Value.ToString();
                l_name_cust = row.Cells[14].Value.ToString();
                f_name_cust = row.Cells[15].Value.ToString();
                m_name_cust = row.Cells[16].Value.ToString();
                Inspection_data.type_victim = row.Cells[17].Value.ToString();
                Inspection_data.phone_victim = row.Cells[18].Value.ToString();
                Inspection_data.FIO_employee = l_name_emp.Trim(' ') + " " + f_name_emp.Remove(l_name_emp.Length - (l_name_emp.Length - 1)) + ". " + m_name_emp.Remove(m_name_emp.Length - (m_name_emp.Length - 1)) + ".";
                Inspection_data.FIO_victim = l_name_cust.Trim(' ') + " " + f_name_cust.Remove(l_name_cust.Length - (l_name_cust.Length - 1)) + ". " + m_name_cust.Remove(m_name_cust.Length - (m_name_cust.Length - 1)) + ".";

            }
        }
    }
}
