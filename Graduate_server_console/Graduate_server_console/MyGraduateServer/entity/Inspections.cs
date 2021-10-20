using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Graduate_server_console.MyGraduateServer.entity
{
    class Inspections
    {
        private readonly int _id_inspection;
        private readonly string _type_insur;
        private readonly string _subtype_insur;
        private readonly string _number_insur;
        private readonly string _number_inspect;
        private readonly string _FIO_start_expert_manager;
        private readonly string _data_time_create_inspect;
        private readonly string _type_inspect;
        private readonly string _organization_inspect;
        private readonly string _FIO_employee;
        private readonly string _phone_employee;
        private readonly string _FIO_victim;
        private readonly string _phone_victim;
        private readonly string _type_victim;
        private readonly string _object_inspect;
        private readonly string _data_time_inspect;
        private readonly string _place_inspect;
        private readonly string _duration_inspection;
        private readonly string _FIO_expert;
        private readonly string _phone_expert;
        private readonly string _status_inspect;

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

        public Inspections(int id_insp, string type_ins, string subtype_ins, string number_ins, string number_insp, string FIO_start_manag, string data_time_create, string type_insp, string organiz_insp,
            string FIO_emp, string phone_emp, string FIO_vic, string phone_vic, string type_vic, string object_insp, string data_time_insp, string place_insp, string duration_insp, string FIO_exp, string phone_exp, string status_insp)
        {
            _id_inspection = id_insp;
            _type_insur = type_ins;
            _subtype_insur = subtype_ins;
            _number_insur = number_ins;
            _number_inspect = number_insp;
            _FIO_start_expert_manager = FIO_start_manag;
            _data_time_create_inspect = data_time_create;
            _type_inspect = type_insp;
            _organization_inspect = organiz_insp;
            _FIO_employee = FIO_emp;
            _phone_employee = phone_emp;
            _FIO_victim = FIO_vic;
            _phone_victim = phone_vic;
            _type_victim = type_vic;
            _object_inspect = object_insp;
            _data_time_inspect = data_time_insp;

            _place_inspect = place_insp;
            _duration_inspection = duration_insp;
            _FIO_expert = FIO_exp;
            _phone_expert = phone_exp;
            _status_inspect = status_insp;
        }

        public int id_inspection
        {
            get { return _id_inspection; }
        }
        public string type_insur
        {
            get { return _type_insur; }
        }
        public string subtype_insur
        {
            get { return _subtype_insur; }
        }
        public string number_insur
        {
            get { return _number_insur; }
        }
        public string number_inspect
        {
            get { return _number_inspect; }
        }
        public string FIO_start_expert_manager
        {
            get { return _FIO_start_expert_manager; }
        }
        public string data_time_create_inspect
        {
            get { return _data_time_create_inspect; }
        }
        public string type_inspect
        {
            get { return _type_inspect; }
        }
        public string organization_inspect
        {
            get { return _organization_inspect; }
        }
        public string FIO_employee
        {
            get { return _FIO_employee; }
        }
        public string phone_employee
        {
            get { return _phone_employee; }
        }
        public string FIO_victim
        {
            get { return _FIO_victim; }
        }
        public string phone_victim
        {
            get { return _phone_victim; }
        }
        public string type_victim
        {
            get { return _type_victim; }
        }
        public string object_inspect
        {
            get { return _object_inspect; }
        }
        public string data_time_inspect
        {
            get { return _data_time_inspect; }
        }
        public string place_inspect
        {
            get { return _place_inspect; }
        }
        public string duration_inspection
        {
            get { return _duration_inspection; }
        }
        public string FIO_expert
        {
            get { return _FIO_expert; }
        }
        public string phone_expert
        {
            get { return _phone_expert; }
        }
        public string status_inspect
        {
            get { return _status_inspect; }
        }


        public static void InsertInspectionsData(Inspections inspdata)
        {
            int count;
            int block = 0;
            try
            {
                count = MySQLRows();
                count = count + 1;
                string connString = @"Datasource=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string sql = "INSERT INTO Inspection_data (id_inspection, type_insur, subtype_insur, number_insur, number_inspect, FIO_start_expert_manage, data_time_create_inspect, type_inspect, organization_inspect, FIO_employee, phone_employee, FIO_victim, phone_victim, type_victim, object_inspect, data_time_inspect, place_inspect, duration_inspection, FIO_expert, phone_expert, status_inspection) VALUES('" + count + "','" + inspdata._type_insur + "','" + inspdata._subtype_insur + "','" + inspdata._number_inspect + "','" + inspdata._FIO_start_expert_manager + "','" + inspdata._data_time_create_inspect + "','" + inspdata._type_inspect + "','" + inspdata._organization_inspect + "','" + inspdata._FIO_employee + "','" + inspdata._phone_employee + "','" + inspdata._FIO_victim + "','" + inspdata._phone_victim + "','" + inspdata._type_victim + "','" + inspdata._object_inspect + "','" + inspdata._data_time_inspect+ "','" + inspdata._place_inspect + "','" + inspdata._duration_inspection + "','" + inspdata._FIO_expert + "','" + inspdata._phone_expert + "','" + inspdata._status_inspect+ "');";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader myReader;
                try
                {
                    conn.Open();
                    myReader = cmd.ExecuteReader();
                    while (myReader.Read())
                    { }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static int MySQLRows()
        {
            int kol = 0;
            SqlConnection conn = GetDBConnection();
            conn.Open();
            string sql = "select count(*) from Inspection_data";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                int returnValue = int.Parse(cmd.ExecuteScalar().ToString());
                kol = returnValue + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return kol;
        }


    }
}
