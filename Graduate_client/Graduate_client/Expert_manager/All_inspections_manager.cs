using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace Graduate_client.Expert_manager
{
    public partial class All_inspections_manager : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetInspectionDataGrid = "7";
        private string karasik;
        public All_inspections_manager()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
            GetInspectionsDataGrid(GetInspectionDataGrid);
        }
        private void GetInspectionsDataGrid(string message)
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
                    adapter = new SqlDataAdapter("SELECT * FROM Inspection_data", conn);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[0].HeaderText = "Идентификационный номер";
                    dataGridView1.Columns[0].Width = 150;
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[3].Width = 150;
                    dataGridView1.Columns[4].Width = 150;
                    dataGridView1.Columns[5].Width = 200;
                    dataGridView1.Columns[9].Width = 200;
                    dataGridView1.Columns[11].Width = 200;
                    dataGridView1.Columns[15].Width = 200;
                    dataGridView1.Columns[18].Width = 200;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[12].Visible = false;
                    dataGridView1.Columns[13].Visible = false;
                    dataGridView1.Columns[14].Visible = false;
                    dataGridView1.Columns[16].Visible = false;
                    dataGridView1.Columns[17].Visible = false;
                    dataGridView1.Columns[19].Visible = false;
                    dataGridView1.Columns[20].Visible = false;
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Items[0].ToString() == "Тип страхования" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Тип страхования");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where type_insur LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox2.Items[1].ToString() == "ФИО эксперта" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по ФИО эксперта");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where FIO_expert LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox2.Items[2].ToString() == "ФИО менеджера" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по ФИО менеджера");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where FIO_expert_manager LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox2.Items[3].ToString() == "ФИО клиента" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по ФИО клиента");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where FIO_customer LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox2.Items[4].ToString() == "ФИО страхового агента" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по ФИО страхового агента");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where FIO_employee LIKE '%" + textBox1.Text + "%'";
                    var dataAdapter = new SqlDataAdapter(sql, conn);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];
                }
                if (comboBox2.Items[5].ToString() == "Номер страхового случая" && textBox1.Text != "")
                {
                    MessageBox.Show("Поиск будет производится по Номер страхового случая");
                    SqlConnection conn = GetDBConnection();
                    conn.Open();
                    string sql = "SELECT id_inspection, type_insur, number_insur, orgaingation_inspect, FIO_expert, FIO_expert_manager, FIO_customer, FIO_employee FROM Inspection_data where number_insur LIKE '%" + textBox1.Text + "%'";
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

        private void linkUsers1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            All_inspections_manager all_insp = new All_inspections_manager();
            all_insp.ShowDialog();
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Current_inspection_manager curr_insp = new Current_inspection_manager();
            curr_insp.ShowDialog();
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Personal_data_manager personal_data_exp = new Personal_data_manager();
            personal_data_exp.ShowDialog();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Hide();
            Create_new_inspection create_new_insp = new Create_new_inspection();
            create_new_insp.ShowDialog();
            //Close();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            Int16 i, j;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (i = 0; i <= dataGridView1.RowCount - 2; i++)
            {
                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                {
                    xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
            }

            xlWorkBook.SaveAs(@"D:\all_inspections_manager.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (karasik == "okay")
                {
                    Hide();
                    Change_inspection_manager change_insp = new Change_inspection_manager();
                    change_insp.ShowDialog();
                    Close();
                }
                else
                    MessageBox.Show("Выберите хотя бы один из осмотров!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                Inspection_data.id_inspection = row.Cells[0].Value.ToString();
                Inspection_data.type_insur = row.Cells[1].Value.ToString();
                Inspection_data.subtype_insur = row.Cells[2].Value.ToString();
                Inspection_data.number_insur = row.Cells[3].Value.ToString();
                Inspection_data.number_inspect = row.Cells[4].Value.ToString();
                Inspection_data.FIO_start_expert_manager = row.Cells[5].Value.ToString();
                Inspection_data.data_time_create_inspect = row.Cells[6].Value.ToString();
                Inspection_data.type_inspect = row.Cells[7].Value.ToString();
                Inspection_data.organization_inspect = row.Cells[8].Value.ToString();
                Inspection_data.FIO_employee = row.Cells[9].Value.ToString();
                Inspection_data.phone_employee = row.Cells[10].Value.ToString();
                Inspection_data.FIO_victim = row.Cells[11].Value.ToString();
                Inspection_data.phone_victim = row.Cells[12].Value.ToString();
                Inspection_data.type_victim = row.Cells[13].Value.ToString();
                Inspection_data.object_inspect = row.Cells[14].Value.ToString();
                Inspection_data.data_time_inspect = row.Cells[15].Value.ToString();
                Inspection_data.place_inspect = row.Cells[16].Value.ToString();
                Inspection_data.duration_inspection = row.Cells[17].Value.ToString();
                Inspection_data.FIO_expert = row.Cells[18].Value.ToString();
                Inspection_data.phone_expert = row.Cells[19].Value.ToString();
                Inspection_data.status_inspect = row.Cells[20].Value.ToString();
                karasik = "okay";
            }
        }
    }
}
