using NUnit.Framework;

namespace MyserverApp.BoardGame
{
    public class ClientTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase("1 1 X",true,false)]
        [TestCase("1 2 X",true,true)]
        [TestCase("clear",false,false)]
        public void RunClientTest(string cmd,bool isover,bool isdraw)
        {       
            var mckSocket = new MockedSocket();

            var cli = new Client();
            cli.SetIsover(isover);
            cli.SetDraw(isdraw);
            cli.SetSocket(mckSocket);
            cli.Setinfiniteloop(false);
            MyConsole.SetIsTestMode(true);
            //MyConsole.ReadLine();
            MyConsole.SetReturnMessage(cmd); 
            cli.RunClient();
      
        }
        
        
        


        
        
    
    }
}