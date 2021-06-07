using System;

namespace MyserverApp.BoardGame
{
    public class OXBoard
    {
        private string[,] board = new string[3,3];
        private string winner = "";
        
        public OXBoard()
        {
            for (int i=0; i<=2; i++)
            {
                for (int j=0; j<=2; j++)
                {
                    board[i, j] = " ";
                }
            }
        }

        public bool Put(int row , int col, string mark)
        {
            bool ok = true;

            if (board[row,col].Equals(" "))
            {
                board[row,col] = mark;
            }
            else
            {
                Console.WriteLine("Is already exist");
                ok = false;
            }
            
            return ok;
        }

        public string GetMark(int row, int col)
        {
            return board[row, col];
        }

        private bool CheckWinnerbyRow(int row)
        {
            string previousmark = "";
            for(int col = 0; col < 3; col++)
            {
                string mark = board[row,col];
                if (col == 0)
                {
                    previousmark = mark;
                }
                else if(!previousmark.Equals(mark))
                {
                    return false;
                }

                previousmark = mark;
            }

            if(previousmark.Equals("O") || previousmark.Equals("X"))
            {
                winner = previousmark;
                return(true);
            }

            return false;
        }
        private bool CheckWinnerbyCol(int col)
        {
            string premark = "";
            for(int row = 0; row < 3 ; row++)
            {
                string mark = board[row,col];
                if(row == 0)
                {
                    premark = mark;
                }
                else if(!premark.Equals(mark))
                {
                    return false;
                }
                premark = mark;
                
            }
            if(premark.Equals("O") || premark.Equals("X"))
            {
                winner = premark;
                return true;
            }
            return false;

        }
        private bool CheckWinnerbyDiagonal()
        {
            string[] diagonal1 = new string[3] 
            {
                board[0,0], 
                board[1,1], 
                board[2,2] 
            };
            string[] diagonal2 = new string[3] 
            {
                board[0,2], 
                board[1,1], 
                board[2,0] 
            };

            bool winnerdia1 = IsarrayOver(diagonal1);
            bool winnerdia2 = IsarrayOver(diagonal2);

            return winnerdia1 || winnerdia2;


        }
        public bool IsarrayOver(string[] arr1)
        {
            string previousmark = "";
            for(int i = 0 ; i < 3 ;i++)
            {
                string mark = arr1[i];
                if(i == 0)
                {
                    previousmark = mark;
                }
                else if(!previousmark.Equals(mark))
                {
                    return false;
                }
                previousmark = mark;
            }

            if(previousmark == "O" || previousmark == "X")
            {
                winner = previousmark;
                return true;
            }
            return false;
        }

        public bool Isgameover()
        {
            bool checkrow0 = CheckWinnerbyRow(0);
            bool checkrow1 = CheckWinnerbyRow(1);
            bool checkrow2 = CheckWinnerbyRow(2);

            bool checkcol0 = CheckWinnerbyCol(0);
            bool checkcol1 = CheckWinnerbyCol(1);
            bool checkcol2 = CheckWinnerbyCol(2);

            bool checkdraw = CheckDraw();
            bool checkdiagonal = CheckWinnerbyDiagonal();

            bool isover = checkrow0 || checkrow1 || checkrow2 ||checkcol0 
            || checkcol1 || checkcol2 || checkdiagonal || checkdraw;
            return (isover);
        }
        public bool CheckDraw()
        {
            for(int row = 0 ; row < 3 ;row++)
            {
                for(int col = 0 ; col < 3;col++)
                {
                    if(board[row,col].Equals(" "))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public string GettheWinner()
        {
            return winner;
        }

        public void Clear()
        {
            for(int i = 0; i < 3 ; i++)
            {
                for(int j = 0; j < 3 ; j++ )
                {
                    board[i, j] = " ";
                }
            }
            
            
        }

        
        public void DisplayBoard()
        {
            
            for (int r=0; r<3; r++)
            {     
                Console.WriteLine("   |   |   ");        
                Console.WriteLine(" {0} | {1} | {2} ", board[r,0], board[r,1], board[r,2]);
                if (r != 2)
                {
                    Console.WriteLine("___|___|___");                  
                }
                 
            }
            Console.WriteLine("   |   |   ");   
        }
    }
}