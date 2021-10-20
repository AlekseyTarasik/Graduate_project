using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Graduate_server.MyGraduateServer.entity
{
    class Admin
    {
        private readonly int _id;
        private readonly string _login;
        private readonly string _pass;
        private readonly string _type;
        private readonly string _last_n;
        private readonly string _first_n;
        private readonly string _middle_n;
        private readonly string _name_filial;
        private readonly string _position;
        private readonly int _block;
        private const string Delimiter = "|";

        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-90R5R8E\SQLEXPRESS";
            string database = "Graduate_tarasik";

            return GetDBConnection(datasource, database);
        }

        public Admin(int id, string login, string pass, string type, string last_n, string first_n, string middle_n, string name_filial, string position, int block)
        {
            _id = id;
            _login = login;
            _pass = pass;
            _type = type;
            _last_n = last_n;
            _first_n = first_n;
            _middle_n = middle_n;
            _name_filial = name_filial;
            _position = position;
            _block = block;
        }
        public Admin(string login, string pass, string type, string last_n, string first_n, string middle_n, string name_filial, string position, int block)
        {
            _login = login;
            _pass = pass;
            _type = type;
            _last_n = last_n;
            _first_n = first_n;
            _middle_n = middle_n;
            _name_filial = name_filial;
            _position = position;
            _block = block;
        }
        public Admin(string login, string pass, string type, int block)
        {
            _login = login;
            _pass = pass;
            _type = type;
            _block = block;
        }
        public Admin (int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }
        public string Login
        {
            get { return _login; }
        }
        public string Pass
        {
            get { return _pass; }
        }
        public string Type
        {
            get { return _type; }
        }
        public string Last_n
        {
            get { return _last_n; }
        }
        public string First_n
        {
            get { return _first_n; }
        }
        public string Middle_n
        {
            get { return _middle_n; }
        }
        public string Name_filial
        {
            get { return _name_filial; }
        }
        public string Position
        {
            get { return _position; }
        }
        public int Block
        {
            get { return _block; }
        }
        public override string ToString()
        {
            return string.Format("Id: {0}, Login: {1}, Pass: {2}, Type: {3}, Last_n: {4}, First_n: {5}, Middle_n: {6}, Name_filial: {7}, Position: {8}, Block: {9}", _id, _login, _pass, _type, _last_n, _first_n, _middle_n, _name_filial, _position, _block);
        }
        public override bool Equals(object obj)
        {
            var admins = obj as Admin;
            return admins != null && Last_n.Equals(admins.Last_n);
        }
        public static SqlConnection GetDBConnection(string datasource, string database)
        {
            String connString = @"Datasource=" + datasource + ";Initial Catalog=" + database + "Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }


        public static void SetBlockUsersDat(Admin admdata)
        {
            try
            {
                SqlConnection conn = GetDBConnection();
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                string sql = "UPDATE User_data SET block_account = 1 WHERE id_user ='" + admdata._id + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void SetUnblockUsersDat(Admin admdata)
        {
            try
            {
                SqlConnection conn = GetDBConnection();
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                string sql = "UPDATE User_data SET block_account = 0 WHERE id_user ='" + admdata._id + "'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }








    }
}
