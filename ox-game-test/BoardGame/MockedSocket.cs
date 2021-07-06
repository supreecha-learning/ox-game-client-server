using System.Text;
using System.Net.Sockets;
using System.Net;

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

        public ISocket Accept()
        {
            ISocket cliSck = new MockedSocket();
            return cliSck;
        }

        public int Receive(byte[] buff, int offset, int size, SocketFlags flag)
        {
            string dat = "1 1 X";  
            byte[] bytes = Encoding.ASCII.GetBytes(dat); 

            bytes.CopyTo(buff, 0);
            return bytes.Length;     
        }

        public int Send(byte[] buff, int offset, int size, SocketFlags flag)
        {
            return 0;
        }   
        public void Connect(EndPoint ed)
        {

        }      
    }
}