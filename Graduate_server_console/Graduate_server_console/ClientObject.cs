using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Graduate_server_console.MyGraduateServer.entity;


namespace Graduate_server_console
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
        private const string SetUsersData = "4";
        private const string InsertUserData = "5";
        private const string GetUserDataGrid = "6";
        private const string GetInspectionDataGrid = "7";
        private const string GetCurrentInspectionDataGrid = "8";
        private const string GetCountInspections = "9";
        private const string GetEmployeeData = "10";
        private const string GetInsuranceData = "11";
        private const string GetCountInsuranceData = "12";
        private const string InsertInspectionData = "13";
        private const string GetMessageData = "14";


        private readonly TcpClient _client;

        public ClientObject(TcpClient tcpClient)
        {
            _client = tcpClient;
        }

        public void Run()
        {
            NetworkStream stream = null;
            var data = new byte[1024];
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
                case SetUsersData:
                    var setUsData = new Users(int.Parse(graduateData[1]), graduateData[2], graduateData[3],
                        graduateData[4], graduateData[5], graduateData[6], graduateData[7], graduateData[8], graduateData[9], int.Parse(graduateData[10]));
                    Users.SetUsersDat(setUsData);
                    break;
                case InsertUserData:
                    var setUserData = new Users(graduateData[1], graduateData[2],
                        graduateData[3], graduateData[4], graduateData[5], graduateData[6], graduateData[7], graduateData[8], int.Parse(graduateData[9]));
                    Users.InsertUsersData(setUserData);
                    break;
                case GetUserDataGrid:
                    var newGetGrid = Users.GetUsersDataGrid();
                    data = Encoding.Unicode.GetBytes(newGetGrid);
                    stream.Write(data, 0, data.Length);
                    //stream.Write(GetByteDataSet(Graduate_tarasik), 0, GetByteDataSet(Graduate_tarasik).Length);
                    break;
                case GetCountInsuranceData:
                    var newGetCountInsur = Users.GetCountInsurDataGrid();
                    data = Encoding.Unicode.GetBytes(newGetCountInsur);
                    stream.Write(data, 0, data.Length);
                    //stream.Write(GetByteDataSet(Graduate_tarasik), 0, GetByteDataSet(Graduate_tarasik).Length);
                    break;
                case InsertInspectionData:
                    var setInspectionData = new Inspections(int.Parse(graduateData[1]), graduateData[2],
                        graduateData[3], graduateData[4], graduateData[5], graduateData[6], graduateData[7], graduateData[8],
                        graduateData[9], graduateData[10], graduateData[11], graduateData[12], graduateData[13], graduateData[14],
                        graduateData[15], graduateData[16], graduateData[17], graduateData[18], graduateData[19], graduateData[20], graduateData[21]);
                    Inspections.InsertInspectionsData(setInspectionData);
                    break;

            }
        }
    }
}
