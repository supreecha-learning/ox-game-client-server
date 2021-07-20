using NUnit.Framework;

namespace MyserverApp.BoardGame
{
    public class ServerTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RunServerTest()
        {
            
            var mckSocket = new MockedSocket();
            var srv = new Server();
            srv.SetSocket(mckSocket);
            srv.SetIsInfinte(false);
            srv.RunServer();
        }
    
    }
}