using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using Graduate_server.MyGraduateServer.entity;
using System.Data;

namespace Graduate_server
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }


    class ClientObject
    {
        private const string VerificationUsers = "1";
        private const string BlockUser = "2";
        private const string UnBlockUser = "3";
        private const string GetUsersData = "4";
        private const string SetUsersData = "5";
        private const string InsertUserData = "6";

        private readonly TcpClient _client;

        public ClientObject(TcpClient tcpClient)
        {
            _client = tcpClient;
        }

        public void Run()
        {
            NetworkStream stream = null;
            var data = new byte[64];
            try
            {
                stream = _client.GetStream();
                var builder = new StringBuilder();
                do
                {
                    var bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (stream.DataAvailable);

                var message = builder.ToString();
                var kartigData = message.Split(new char[] { '|' });
                ExecuteProgram(kartigData, stream, data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (_client != null)
                    _client.Close();
            }
        }
        private static void ExecuteProgram(IReadOnlyList<string> graduateData, Stream stream, byte[] data)
        {
            if (data == null) throw new ArgumentNullException("data");
            switch (graduateData[0])
            {
                case VerificationUsers:
                    var newUsers = Users.VerificationUsers(graduateData[1], graduateData[2]);
                    data = Encoding.Unicode.GetBytes(newUsers);
                    stream.Write(data, 0, data.Length);
                    break;
                case BlockUser:
                    var blockData = new Admin(int.Parse(graduateData[1]));
                    Admin.SetBlockUsersDat(blockData);
                    break;
                case UnBlockUser:
                    var unblockData = new Admin(int.Parse(graduateData[1]));
                    Admin.SetUnblockUsersDat(unblockData);
                    break;
                case GetUsersData:
                    var getUsData = Users.GetUsersDat(graduateData[1], graduateData[2]);
                    data = Encoding.Unicode.GetBytes(getUsData);
                    stream.Write(data, 0, data.Length);
                    break;
                case SetUsersData:
                    var setUsData = new Users(graduateData[1], graduateData[2],
                        graduateData[3], graduateData[4], graduateData[5], graduateData[6], graduateData[7], graduateData[8], int.Parse(graduateData[9]));
                    Users.SetUsersDat(setUsData);
                    break;
                case InsertUserData:
                    var setUserData = new Users(graduateData[1], graduateData[2],
                        graduateData[3], graduateData[4], graduateData[5], graduateData[6], graduateData[7], graduateData[8], int.Parse(graduateData[9]));
                    Users.InsertUsersData(setUserData);
                    break;


            }
        }
    }
}
