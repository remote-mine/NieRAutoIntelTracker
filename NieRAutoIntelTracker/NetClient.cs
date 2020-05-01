using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NieRAutoIntelTracker
{
    class NetClient
    {
        // Update to live server info
        const int PORT = 8888;
        const string SERVER_IP = "127.0.0.1";

        private TcpClient _client;

        public bool IsConnected { get; set; }

        public void Initialize()
        {
            try
            {
                _client = new TcpClient(SERVER_IP, PORT);
                IsConnected = true;
            }
            catch
            {
                IsConnected = false;
            }
        }

        public void Write(byte[] info)
        {
            // Get Stream connected to _client
            NetworkStream stream = _client.GetStream();

            // Send request to _client through above stream
            stream.Write(info, 0, info.Length);

            // Accept response if you want it, left it in just in case
            byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
            int bytesRead = stream.Read(bytesToRead, 0, _client.ReceiveBufferSize);
            var serverResponse = Encoding.ASCII.GetString(bytesToRead, 0, bytesRead); // Do with as you will
        }

        public void Close() => _client.Close();
    }
}
