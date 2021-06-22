using System.Net.Sockets;

namespace MyserverApp.BoardGame
{
    public interface ISocket
    {
        public void Bind(string ip, int port);
        public void Listen(int backLog);
        public Socket Accept();
        
    }
}