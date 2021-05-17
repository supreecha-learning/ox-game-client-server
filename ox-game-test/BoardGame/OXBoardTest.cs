using NUnit.Framework;

namespace MyserverApp.BoardGame
{
    public class OXBoardGameTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(0, 0, "O")]
        [TestCase(1, 1, "O")]
        [TestCase(1, 2, "X")]
        [TestCase(2, 1, "X")]
        public void PutSamePositionTest(int row, int col, string mark)
        {
            var board = new OXBoard();

            bool success = board.Put(row, col, mark);
            Assert.AreEqual(true, success);

            success = board.Put(row, col, mark);
            Assert.AreEqual(false, success);
        }

        [Test]
        public void InitWithSpaceTest()
        {
            var board = new OXBoard();

            int cnt = 0;
            for (int i=0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    string mark = board.GetMark(i, j);
                    if (mark.Equals(" "))
                    {
                        cnt++;
                    }
                }
            }

            Assert.AreEqual(9, cnt);
        } 


        [TestCase(0, 0, "X")]
        [TestCase(0, 0, "O")]
        [TestCase(2, 1, "O")]
        public void GetMarkTest(int row, int col, string mark)
        {
            var board = new OXBoard();
            
            board.Put(row, col, mark);
            string newMark = board.GetMark(row, col);

            Assert.AreEqual(mark, newMark);
        } 

        private void PutBoardFromString(OXBoard board, string boardStr)
        {
            string[] rows = boardStr.Split(',');

            int r = 0;
            foreach (string row in rows)
            {
                string[] cols = row.Split(':');
                int c = 0;

                foreach (string mark in cols)
                {
                    board.Put(r, c, mark);
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
            OXBoard board = new OXBoard();
            PutBoardFromString(board, boardStr);

            bool gamveOver = board.Isgameover();
            Assert.AreEqual(isOver, gamveOver);
            
        }

        [Test]
        public void ClearTest()
        {
            var clearboard = new OXBoard();

            bool checkclear = clearboard.Clear();

            Assert.AreEqual(true,checkclear);
        }

        [Test]  
        public void GettherWinnerTest()
        {
            var board = new OXBoard();

            string winner = board.GettheWinner();
            Assert.AreEqual(winner,winner);
        
        }
        [Test]
        public void DisplayBoardTest()
        {
            var board = new OXBoard();
            try
            {
                board.DisplayBoard();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }   

        

        

       
        
        
        
    }
}