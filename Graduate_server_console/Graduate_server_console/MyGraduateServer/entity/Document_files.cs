using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduate_server_console.MyGraduateServer.entity
{
    class Document_files
    {
        private readonly int _id_doc;
        private readonly string _name_doc;
        private readonly string title_doc;
        private readonly string document_data;
        private readonly string image_data;

        private const string Delimiter = "|";
        public int Id
        {
            get { return _id_doc; }
        }
        public string Name
        {
            get { return _name_doc; }
        }
        public string Title
        {
            get { return title_doc; }
        }
        public string Document_Data
        {
            get { return document_data; }
        }
        public string Image_data
        {
            get { return image_data; }
        }
        public static string SendDocumentFiles(string name, string title, string document_data)
        {
            string kar = "Karasik";
            return kar.ToString();
        }
        public static string SendImageFiles(string name, string title, string image_data)
        {
            string kar = "Karasik";
            return kar.ToString();
        }
        public static string GetDocumentFiles(string name, string title, string document_data)
        {
            string kar = "Karasik";
            return kar.ToString();
        }
        public static string GetImageFiles(string name, string title, string image_data)
        {
            string kar = "Karasik";
            return kar.ToString();
        }
    }
}
