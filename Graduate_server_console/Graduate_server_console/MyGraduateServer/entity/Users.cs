using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;

namespace Graduate_server_console.MyGraduateServer.entity
{
    class Users
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

        public Users(int id, string login, string pass, string type, string last_n, string first_n, string middle_n, string name_filial, string position, int block)
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
        public Users(string login, string pass, string type, string last_n, string first_n, string middle_n, string name_filial, string position, int block)
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
        public Users(string login, string pass, string type, int block)
        {
            _login = login;
            _pass = pass;
            _type = type;
            _block = block;
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



        public static string VerificationUsers(string login, string pass)
        {
            int blocked = 0;
            string successful_auth = "ok";
            int count = 0;
            string sql = "SELECT * FROM User_data WHERE login_user ='" + login + "' and pass_user ='" + pass + "'";
            var message = new StringBuilder();
            count = MySQLRows();
            Console.WriteLine(count + " строк");
            SqlConnection conn = GetDBConnection();
            conn.Open();
            try
            {            
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (count >= 1 && blocked == reader.GetInt32(9))
                        {
                            message.Append(successful_auth + Delimiter + reader.GetInt32(0) + Delimiter + reader.GetString(1).Trim(' ') + Delimiter + reader.GetString(2).Trim(' ') + Delimiter + reader.GetString(3).Trim(' ') + Delimiter + reader.GetString(4).Trim(' ')
                                + Delimiter + reader.GetString(5).Trim(' ') + Delimiter + reader.GetString(6).Trim(' ') + Delimiter + reader.GetString(7).Trim(' ') + Delimiter + reader.GetString(8).Trim(' ') + Delimiter + reader.GetInt32(9));
                        }
                        else if (count >= 1 && blocked != reader.GetInt32(9))
                        {
                            message.Append("Account is blocked!");
                        }
                        else if (count > 1)
                        {
                            message.Append("uncorrect login or password");
                        }
                        conn.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Разрушить объект, освободить ресурс.
                conn.Dispose();
            }
            return message.ToString();        
        }

        public static string GetUsersDat(string login, string pass)
        {
            string ID;
            string LOGIN;
            string PASSWORD;
            string TYPE;
            string L_NAME;
            string F_NAME;
            string M_NAME;
            string NAME_F;
            string POSITION;
            string dataUser;
            var message = new StringBuilder();
            try
            {
                string connString = @"Datasource=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                string sql = "SELECT * FROM User_data WHERE login ='" + login + "' and password ='" + pass + "'";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count = count + 1;
                }
                if (count == 1)
                {
                    //message.Append("ok");
                    ID = reader[0].ToString();
                    LOGIN = reader[1].ToString();
                    PASSWORD = reader[2].ToString();
                    TYPE = reader[3].ToString();
                    L_NAME = reader[4].ToString();
                    F_NAME = reader[5].ToString();
                    M_NAME = reader[6].ToString();
                    NAME_F = reader[7].ToString();
                    POSITION = reader[8].ToString();
                    dataUser = ID + Delimiter + LOGIN + Delimiter + PASSWORD + Delimiter + TYPE + Delimiter + L_NAME + Delimiter + F_NAME + Delimiter + M_NAME + Delimiter + NAME_F + Delimiter + POSITION;
                    message.Append(dataUser);
                }
                if (count > 1)
                {
                    message.Append("uncorrect login or password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return message.ToString();
        }
        public static void SetUsersDat(Users usdata)
        {
            //var message = new StringBuilder();
            try
            {
                string connString = @"Datasource=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                Console.WriteLine("Openning Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                string sql = "UPDATE User_data SET login_user ='" + usdata._login + "', pass_user ='" + usdata._pass + "', type_user ='" + usdata._type + "', last_name = '" + usdata._last_n + "', first_name = '" + usdata._first_n + "', middle_name = '" + usdata._middle_n + "', name_filial = '" + usdata._name_filial + "', position_user = '" + usdata._position + "' WHERE id_user ='" + usdata._id + "'";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                DbDataReader reader = cmd.ExecuteReader();
                Console.WriteLine("Update!!!");
                int count = 0;

                while (reader.Read())
                {
                    count = count + 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public static void InsertUsersData(Users userdata)
        {
            int count;
            int block = 0;
            try
            {
                count = MySQLRows();
                count = count + 1;
                string connString = @"Datasource=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
                SqlConnection conn = new SqlConnection(connString);
                string sql = "INSERT INTO User_data (idusers, login_user, pass_user, type_user, last_name, first_name, middle_name, name_filial, position_user, block_account) VALUES('" + count + "','" + userdata._login + "','" + userdata._pass + "','" + userdata._type + "','" + userdata._last_n + "','" + userdata._first_n + "','" + userdata._middle_n + "','" + userdata._name_filial + "','" + userdata._position + "','" + block + "');";
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
            string sql = "select count(*) from User_data";

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;


                int returnValue = int.Parse(cmd.ExecuteScalar().ToString());
                kol = returnValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return kol;
        }

        public static string GetUsersDataGrid()
        {
            var message = @"Data Source=.\SQLEXPRESS;Initial Catalog=Graduate_tarasik; Integrated Security=True";
            return message.ToString();
        }
        public static string GetCountInsurDataGrid()
        {
            int kol = 0;
            SqlConnection conn = GetDBConnection();
            conn.Open();
            string sql = "select count(*) from Insurance_contract";

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
            return kol.ToString();
        }
    }
}
