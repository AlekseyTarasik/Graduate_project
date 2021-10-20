using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace Graduate_server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Port = 8888;
        private const string ServerStartedTemplate = "The server was successfully started!";
        private const string IpAddress = "127.0.0.1";
        private static TcpListener _listener;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_OnClick(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Hidden;
            MessageBox.Show(ServerStartedTemplate);
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
