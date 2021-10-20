using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;

namespace Graduate_client.Expert_manager
{
    public partial class Create_new_inspection : Form
    {
        private const int Port = 8888;
        private const string Address = "127.0.0.1";
        private const string Delimiter = "|";
        private const string GetCountInsuranceData = "12";
        private const string InsertInspectionData = "13";
        public Create_new_inspection()
        {
            InitializeComponent();
            TopMost = true;
            GetCountInsuranceDataGrid(GetCountInsuranceData);
        }
        private void GetCountInsuranceDataGrid(string message)
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
                label2.Text = message;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Preview_employee preview_emp = new Preview_employee();
            preview_emp.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Preview_insurance_contract preview_insur_contr = new Preview_insurance_contract();
            preview_insur_contr.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (Inspection_data.type_insur.Length > 0 && Inspection_data.subtype_insur.Length > 0 && Inspection_data.number_insur.Length > 0
                    && Inspection_data.object_inspect.Length > 0 && Inspection_data.FIO_employee.Length > 0 && Inspection_data.phone_employee.Length > 0
                    && Inspection_data.FIO_victim.Length > 0 && Inspection_data.type_victim.Length > 0 && Inspection_data.phone_victim.Length > 0)
                {
                    textBox1.Text = Inspection_data.type_insur;
                    textBox2.Text = Inspection_data.subtype_insur;
                    textBox3.Text = Inspection_data.number_insur;
                    textBox9.Text = Inspection_data.FIO_employee;
                    textBox10.Text = Inspection_data.phone_employee;
                    textBox11.Text = Inspection_data.FIO_victim;
                    textBox12.Text = Inspection_data.phone_victim;
                    textBox13.Text = Inspection_data.type_victim;
                    textBox14.Text = Inspection_data.object_inspect;
                }
                else
                    MessageBox.Show("Данные отсутствуют!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Данные отсутствуют!");
            }         
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (Inspection_data.FIO_expert.Length > 0 && Inspection_data.phone_expert.Length > 0)
                {
                    textBox18.Text = Inspection_data.FIO_expert;
                    textBox19.Text = Inspection_data.phone_expert;
                }
                else
                    MessageBox.Show("Данные отсутствуют!");
            }
            catch(Exception ex)
            {
                    MessageBox.Show("Данные отсутствуют!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "" && textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "" && textBox20.Text != "")
                {
                    var message = InsertInspectionData + Delimiter + textBox1.Text + Delimiter + textBox2.Text + Delimiter + textBox3.Text + Delimiter + textBox4.Text + Delimiter + textBox5.Text + Delimiter + textBox6.Text + Delimiter + textBox7.Text + Delimiter + textBox8.Text + Delimiter + textBox9.Text + Delimiter + textBox10.Text + Delimiter
                    + textBox11.Text + Delimiter + textBox12.Text + Delimiter + textBox13.Text + Delimiter + textBox14.Text + Delimiter + textBox15.Text + Delimiter + textBox16.Text + Delimiter + textBox17.Text + Delimiter + textBox18.Text + Delimiter + textBox19.Text + Delimiter + textBox20.Text;
                    SendInspectionData(message);
                    MessageBox.Show("Осмотр успешно создан!");
                    MessageBox.Show(message);
                }
                else
                    MessageBox.Show("Заполните все поля корректно, иначе вы не сможете создать новый осмотр!");
            }
            catch
            {
                MessageBox.Show("Заполните все поля корректно, иначе вы не сможете создать новый осмотр!");
            }
        }
        private static void SendInspectionData(string message)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(Address, Port);
                var stream = client.GetStream();
                var data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
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
