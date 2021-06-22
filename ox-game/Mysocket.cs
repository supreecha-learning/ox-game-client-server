using System.Net;
using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public class MySocket : ISocket
    {
        private Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

        public void Bind(string ip, int port)
        {
            sck.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        public void Listen(int backLog)
        {
            sck.Listen(backLog);
        }

        public Socket Accept()
        {
            Socket cliSck = sck.Accept();
            return cliSck;
        }
    }
}