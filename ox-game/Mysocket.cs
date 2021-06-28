using System.Net;
using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public class MySocket : ISocket
    {
        private Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

        public MySocket(Socket s)
        {
            sck = s;
        }

        public MySocket()
        {
        }

        public void Bind(string ip, int port)
        {
            sck.Bind(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        public void Listen(int backLog)
        {
            sck.Listen(backLog);
            
        
        }

        public ISocket Accept()
        {
            Socket cliSck = sck.Accept();

            ISocket s = new MySocket(cliSck);
            return s;
        }

        public int Receive(byte[] buff, int offset, int size, SocketFlags flag)
        {
            int len = sck.Receive(buff, offset, size, flag);
            return len;
        }

        public int Send(byte[] buff, int offset, int size, SocketFlags flag)
        {
            int len = sck.Send(buff, offset, size, flag);
            return len;
        }         
    }
}