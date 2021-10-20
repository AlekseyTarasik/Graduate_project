using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Graduate_client
{
    class Connection
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-90R5R8E\SQLEXPRESS";
            string database = "Graduate_tarasik";

            return GetDBConnection(datasource, database);
        }

        public static SqlConnection GetDBConnection(string datasource, string database)
        {
            String connString = @"Datasource=" + datasource + ";Initial Catalog=" + database + "Integrated Security=True";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
