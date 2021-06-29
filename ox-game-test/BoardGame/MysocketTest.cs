using NUnit.Framework;
using System.Net.Sockets;
using System.Net;


namespace MyserverApp.BoardGame
{
    public class MysocketTest 
    {
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
        /*
        [TestCase(10)]
        public void ListenTest(int num)
        {
            var m3 = new MySocket();
            m3.Listen(num);
        }
        
        
        
        
        /*
        [Test]
        public void AcceptTest()
        {
            var m4 = new MySocket();

        }
        
        
        
        [TestCase(0,0)]
        public void ReceiveTest(int offset, int size)
        {
            var m5 = new MySocket();
            byte [] mybyte = new byte [1024];
            SocketFlags myflag = new SocketFlags();
            int actual = m5.Receive(mybyte,offset,size,myflag);
            Assert.AreEqual(actual,actual);
            
           
        }
        */
        
        


        
        


        
        
        
    }
}