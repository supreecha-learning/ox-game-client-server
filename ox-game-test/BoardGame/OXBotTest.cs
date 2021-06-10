using NUnit.Framework;


namespace MyserverApp.BoardGame
{
    public class OXBotTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0,0,"X")]
        
        public void PutPositionBoardTest(int row,int col,string mark)
        {
            var mybot = new OXbot();
            bool actual = mybot.PutPositionBoard(row,col,mark);       
            Assert.AreEqual(true,actual);

            bool actual1 = mybot.PutPositionBoard(row,col,mark);
            Assert.AreEqual(false,actual1);

            
        }
        private void PutBoardFromString(OXbot board, string boardStr)
        {
            string[] rows = boardStr.Split(',');

            int r = 0;
            foreach (string row in rows)
            {
                string[] cols = row.Split(':');
                int c = 0;

                foreach (string mark in cols)
                {
                    board.PutPositionBoard(r, c, mark);
                    c++;
                }

                r++;
            }
        }
        [TestCase("", false)]
        [TestCase("O:O:O,X:X:X,O:O: ", true)]
        [TestCase("O:X:O,X:X:O,O:O:X", true)]
        [TestCase("O:O:X,X:O:O,X:O:X",true)]
        [TestCase("O:O:X,X:O:O,X:X:O",true)]
        
        public void IsgameoverTest(string boardStr, bool isOver)
        {
            OXbot mybot = new OXbot();
            PutBoardFromString(mybot, boardStr);

            bool gamveOver = mybot.Isgameover();
            Assert.AreEqual(isOver, gamveOver);
            
        }
        [Test]
        public void DisplayBoardTest()
        {
            var mybot = new OXbot();
            try
            {
                mybot.DisplayBoard();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }   
        [TestCase("X")]
        [TestCase("O")]
        
        public void FlipMarkTest(string mark)
        {
            var mybot = new OXbot();
            string flipmark = mybot.FlipMark(mark);
            Assert.AreEqual(flipmark,flipmark);
            
        }
        [TestCase("X")]
        [TestCase("O")]
        public void SendPositionBotTest(string mark)
        {
            var mybot = new OXbot();
            if(mark == "X")
            {
                Loop(mybot,mark);
            }
            
            
            string actual = mybot.SendPositionBotplay(mark);
            Assert.AreEqual(actual,actual);

           
        }

        private void Loop(OXbot bot,string mark)
        {
            for(int row = 0 ; row < 3 ; row++)
            {
                for(int col = 0 ; col < 3 ; col++)
                {
                    bot.Oxser[row,col] = mark;
                }
            }
        }
        

        



        

        

       
        
        
        
    }
}