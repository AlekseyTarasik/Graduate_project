using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Graduate_server_console
{
    class Program
    {
        private const int Port = 8888;
        private const string ServerStartedTemplate = "The server was successfully started!";
        private const string IpAddress = "127.0.0.1";
        private static TcpListener _listener;
        static void Main(string[] args)
        {
            Console.WriteLine(ServerStartedTemplate);
            try
            {
                _listener = new TcpListener(IPAddress.Parse(IpAddress), Port);
                _listener.Start();
                while (true)
                {
                    var client = _listener.AcceptTcpClient();
                    var clientObject = new ClientObject(client);
                    var clientThread = new Thread(clientObject.Run);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_listener != null)
                    _listener.Stop();
            }
        }
    }
}
