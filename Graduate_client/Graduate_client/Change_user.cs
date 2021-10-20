using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduate_client
{
    class Change_user
    {
        Change_user(string id, string login, string password, string type, string l_name, string f_name, string m_name, string name_filial, string position, string block)
        {
            idUser = id;
            loginUser = login;
            passwordUser = password;
            typeUser = type;
            l_nameUser = l_name;
            f_nameUser = f_name;
            m_nameUser = m_name;
            name_filialUser = name_filial;
            positionUser = position;
            blockUser = block;
        }

        public static void Change_user_null()
        {
            idUser = null;
            loginUser = null;
            passwordUser = null;
            typeUser = null;
            l_nameUser = null;
            f_nameUser = null;
            m_nameUser = null;
            name_filialUser = null;
            positionUser = null;
            blockUser = "0";
        }
        public static string idUser { get; set; }
        public static string loginUser { get; set; }
        public static string passwordUser { get; set; }
        public static string typeUser { get; set; }
        public static string l_nameUser { get; set; }
        public static string f_nameUser { get; set; }
        public static string m_nameUser { get; set; }
        public static string name_filialUser { get; set; }
        public static string positionUser { get; set; }
        public static string blockUser { get; set; }
    }
}
