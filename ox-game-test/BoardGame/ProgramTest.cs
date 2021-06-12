using NUnit.Framework;


namespace MyserverApp
{
    public class ProgramTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("server")]
        [TestCase("client")]
        public void MainTest(string str)
        {
            string[] arg = new string[1];
            arg[0] = str;
            var test = new Program();
            bool result = Program.RunProgram(arg[0]);
            Assert.AreEqual(true,result);

            
            /*
            try
            {
                Program.Main(arg);
                Assert.IsTrue(true);
            }
            catch 
            {
                Assert.IsTrue(false);
            }
            */
       
        }

        



        

        

       
        
        
        
    }
}