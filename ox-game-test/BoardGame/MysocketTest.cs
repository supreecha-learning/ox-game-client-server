using NUnit.Framework;
using System.Net.Sockets;
using System.Net;


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
        /*
        [Test]
        public void AcceptTest()
        {
            var m3 = new MySocket();      
            ISocket a = m3.Accept();
            
            
            
        }
        */
/*
        [TestCase(10)]
        public void ListenTest(int num)
        {
            var m3 = new MySocket();
            m3.Listen(num);
        }
        /*
        [TestCase(0,0)]
        public void ReceiveTest(int offset, int size)
        {
            var m6 = new MySocket();
            string dat = "1 1 X";  
            byte[] bytes = Encoding.ASCII.GetBytes(dat); 
            SocketFlags s1 = new SocketFlags();

            int expect = m6.Receive(bytes,offset,size,s1);
            int actual = expect;
            Assert.AreEqual(expect,actual);

 
           
        }
        */
        
        
        


        
        


        
        
        
    }
}