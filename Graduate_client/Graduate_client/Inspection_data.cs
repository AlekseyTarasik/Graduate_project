using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduate_client
{
    class Inspection_data
    {
        public Inspection_data(string id_insp, string type_ins, string subtype_ins, string number_ins, string number_insp, string FIO_start_manag, string data_time_create, string type_insp, string organiz_insp,
            string FIO_emp, string phone_emp, string FIO_vic, string phone_vic, string type_vic, string object_insp, string data_time_insp, string place_insp, string duration_insp, string FIO_exp, string phone_exp, string status_insp)
        {
            id_inspection = id_insp;
            type_insur = type_ins;
            subtype_insur = subtype_ins;
            number_insur = number_ins;
            number_inspect = number_insp;
            FIO_start_expert_manager = FIO_start_manag;
            data_time_create_inspect = data_time_create;
            type_inspect = type_insp;
            organization_inspect = organiz_insp;
            FIO_employee = FIO_emp;
            phone_employee = phone_emp;
            FIO_victim = FIO_vic;
            phone_victim = phone_vic;
            type_victim = type_vic;
            object_inspect = object_insp;
            data_time_inspect = data_time_insp;
            place_inspect = place_insp;
            duration_inspection = duration_insp;
            FIO_expert = FIO_exp;
            phone_expert = phone_exp;
            status_inspect = status_insp;
        }
        public static void Inspection_data_null()
        {
            id_inspection = null;
            type_insur = null;
            subtype_insur = null;
            number_insur = null;
            number_inspect = null;
            FIO_start_expert_manager = null;
            data_time_create_inspect = null;
            type_inspect = null;
            organization_inspect = null;
            FIO_employee = null;
            phone_employee = null;
            FIO_victim = null;
            phone_victim = null;
            type_victim = null;
            object_inspect = null;
            data_time_inspect = null;
            place_inspect = null;
            duration_inspection = null;
            FIO_expert = null;
            phone_expert = null;
            status_inspect = null;
        }
        public static string id_inspection { get; set; }
        public static string type_insur { get; set; }
        public static string subtype_insur { get; set; }
        public static string number_insur { get; set; }
        public static string number_inspect { get; set; }
        public static string FIO_start_expert_manager { get; set; }
        public static string data_time_create_inspect { get; set; }
        public static string type_inspect { get; set; }
        public static string organization_inspect { get; set; }
        public static string FIO_employee { get; set; }
        public static string phone_employee { get; set; }
        public static string FIO_victim { get; set; }
        public static string phone_victim { get; set; }
        public static string type_victim { get; set; }
        public static string object_inspect { get; set; }
        public static string data_time_inspect { get; set; }
        public static string place_inspect { get; set; }
        public static string duration_inspection { get; set; }
        public static string FIO_expert { get; set; }
        public static string phone_expert { get; set; }
        public static string status_inspect { get; set; }
    }
}
