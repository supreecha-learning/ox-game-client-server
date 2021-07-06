using NUnit.Framework;

namespace MyserverApp.BoardGame
{
    public class ClientTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RunClientTest()
        {

            var mckSocket = new MockedSocket();
            var cli = new Client();
            /*

            var mckSocket = new MockedSocket();
            
            var srv = new Server();
            srv.SetSocket(mckSocket);
            srv.SetIsInfinte(false);

            srv.RunServer();
            */
        }
    
    }
}