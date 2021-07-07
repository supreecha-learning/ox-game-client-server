using NUnit.Framework;
using System.Net.Sockets;



namespace MyserverApp.BoardGame
{
    public class MysocketTest 
    {
        public byte[] mybuff = new byte[1024];
        public SocketFlags flag = new SocketFlags();
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void SocketTest()
        {
            Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            var m1 = new MySocket(sck);
            
        }
        [TestCase("127.0.0.1", 6666)]
        public void BindTest(string ip,int port)
        {
            var m2 = new MySocket();
            m2.Bind(ip,port);
        }
        
        
        
        
        
        


        
        


        
        
        
    }
}