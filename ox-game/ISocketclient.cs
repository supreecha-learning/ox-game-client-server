
using System.Net;
using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public interface Isocketclient
    {
        public void Connect(EndPoint mypoint);
        public int Send(byte[] buff, int offset, int size, SocketFlags flag);
        public int Receive(byte[] buff, int offset, int size, SocketFlags flag);
       
        
    }
}