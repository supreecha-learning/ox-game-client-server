using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public class MockedSocket : ISocket
    {
        public void Bind(string ip, int port)
        {
        }

        public void Listen(int backLog)
        {
        }

        public Socket Accept()
        {
            
            Socket cliSck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            return cliSck;
            
        }
    }
}