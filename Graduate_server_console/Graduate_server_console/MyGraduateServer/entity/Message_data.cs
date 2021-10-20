using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduate_server_console.MyGraduateServer.entity
{
    class Message_data
    {
        private readonly int _id_message;
        private readonly int _id_user_sender;
        private readonly int _id_user_receiver;
        private readonly string _cost;
        private readonly string _text_message;
        private readonly int id_document;


        public int Id_message
        {
            get { return _id_message; }
        }
        public int Id_user_sender
        {
            get { return _id_user_sender; }
        }
        public int Id_user_revceiver
        {
            get { return _id_user_receiver; }
        }
        public string Cost
        {
            get { return _cost; }
        }
        public string Text_message
        {
            get { return _text_message; }
        }
        public int Id_document
        {
            get { return id_document; }
        }
    }
}
