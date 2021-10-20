using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Graduate_client.Expert
{
    public partial class Change_inspection_expert : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetMessageData = "14";
        public Change_inspection_expert()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TopMost = true;
            InitializeComponent();
            GetMessageDataGrid(GetMessageData);
            textBox1.Text = Inspection_data.id_inspection;
            textBox2.Text = Inspection_data.type_insur;
            textBox3.Text = Inspection_data.subtype_insur;
            textBox4.Text = Inspection_data.number_insur;
            textBox5.Text = Inspection_data.number_inspect;
            textBox6.Text = Inspection_data.FIO_start_expert_manager;
            dateTimePicker1.Text = Inspection_data.data_time_create_inspect;
            textBox7.Text = Inspection_data.type_inspect;
            textBox8.Text = Inspection_data.organization_inspect;
            textBox9.Text = Inspection_data.FIO_employee;
            textBox10.Text = Inspection_data.phone_employee;
            textBox11.Text = Inspection_data.FIO_victim;
            textBox12.Text = Inspection_data.phone_victim;
            textBox13.Text = Inspection_data.type_victim;
            textBox14.Text = Inspection_data.object_inspect;
            dateTimePicker2.Text = Inspection_data.data_time_inspect;
            textBox15.Text = Inspection_data.place_inspect;
            textBox16.Text = Inspection_data.duration_inspection;
            textBox17.Text = Inspection_data.FIO_expert;
            textBox18.Text = Inspection_data.phone_expert;
            textBox19.Text = Inspection_data.status_inspect;
        }
        private void GetMessageDataGrid(string message)
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
                    adapter = new SqlDataAdapter("SELECT * FROM Message_data WHERE id_inspection = '" + Inspection_data.id_inspection + "'", conn);
                    ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[0].HeaderText = "Идентификационный номер";
                    dataGridView1.Columns[0].Width = 140;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[1].HeaderText = "Отправитель";
                    dataGridView1.Columns[1].Width = 130;
                    dataGridView1.Columns[2].ReadOnly = true;
                    dataGridView1.Columns[2].HeaderText = "Получатель";
                    dataGridView1.Columns[2].Width = 130;
                    dataGridView1.Columns[4].ReadOnly = true;
                    dataGridView1.Columns[4].HeaderText = "Стоимости";
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].ReadOnly = true;
                    dataGridView1.Columns[5].HeaderText = "Текст сообщения";
                    dataGridView1.Columns[5].Width = 500;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Inspection_data.Inspection_data_null();
            Hide();
            Main_authorization main_auth = new Main_authorization();
            main_auth.ShowDialog();
            Close();
        }

        private void linkUsers1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inspection_data.Inspection_data_null();
            Hide();
            All_inspections all_insp = new All_inspections();
            all_insp.ShowDialog();
            Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inspection_data.Inspection_data_null();
            Hide();
            Current_inspections curr_insp = new Current_inspections();
            curr_insp.ShowDialog();
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Inspection_data.Inspection_data_null();
            Hide();
            Personal_data_expert personal_data_exp = new Personal_data_expert();
            personal_data_exp.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            New_message new_mess = new New_message();
            new_mess.ShowDialog();
        }
    }
}
