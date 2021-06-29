using System.Net;
using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public class MySocketclient : Isocketclient
    {
        private Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
        public MySocketclient()
        {

        }

        public void Connect(EndPoint mypoint)
        {
            
        }
        public int Receive(byte[] buff, int offset, int size, SocketFlags flag)
        {
            int len = sck.Receive(buff, offset, size, flag);
            return len;
        }
        

        public int Send(byte[] buff, int offset, int size, SocketFlags flag)
        {
            return 1;
        }

        
    }
}