using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public interface ISocket
    {
        public void Bind(string ip, int port);
        public void Listen(int backLog);
        public ISocket Accept();
        public int Receive(byte[] buff, int offset, int size, SocketFlags flag);
        public int Send(byte[] buff, int offset, int size, SocketFlags flag);
        
    }
}