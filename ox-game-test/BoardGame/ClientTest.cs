using NUnit.Framework;

namespace MyserverApp.BoardGame
{
    public class ClientTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("1 1 X")]
        [TestCase("clear")]
        public void RunClientTest(string cmd)
        {       
            var mckSocket = new MockedSocket();

            var cli = new Client();
            cli.SetSocket(mckSocket);
            cli.Setinfiniteloop(false);
            MyConsole.SetIsTestMode(true);
            MyConsole.SetReturnMessage(cmd); 
            cli.RunClient();
            
            
            
        
            
        }
        
    
    }
}