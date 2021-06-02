using System;
using MyserverApp;
namespace MyserverApp.BoardGame
{
    public class OXbot
    {

        private string[,] Oxser = new string[3,3];
        string winner = "";
        private bool mybool = true;
        public OXbot()
        {
            Server s1 = new Server();
            Oxser = s1.OXboardSer;
        }

     
        public string SendPositionBotplay(string flip)
        {
            string result = "";
            string flipmark = flip;
            
            if(mybool != false)
            {
                for(int row = 0 ; row < 3; row++)
                {
                    for(int col = 0 ; col < 3 ; col++)
                    {
                        if(Oxser[row,col].Equals(" "))
                        {
                            Oxser[row,col] = flipmark;
                            result = row + " " + col + " " + flipmark;
                            return result;   
                        }
                    
                    }
                }
            }
            return result;
           
        }
        private bool CheckWinnerbyRow(int row)
        {
            string previousmark = "";
            for(int col = 0; col < 3; col++)
            {
                string mark = Oxser[row,col];
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
                string mark = Oxser[row,col];
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
                Oxser[0,0], 
                Oxser[1,1], 
                Oxser[2,2] 
            };
            string[] diagonal2 = new string[3] 
            {
                Oxser[0,2], 
                Oxser[1,1], 
                Oxser[2,0] 
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
                    if(Oxser[row,col].Equals(" "))
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

        public string FlipMark(string flip)
        {
            string remark = "";
            if(flip.Equals("O"))
            {
                remark = "X";
            }
            else
            {
                remark = "O";
            }
            return remark;
            
        }

        public void PutPositionBoard(int row,int col,string mark)
        {
            
            if (Oxser[row,col].Equals(" "))
            {
                Oxser[row,col] = mark;
            }
            else
            {
                mybool = false;       
            }
            
        }
        public void DisplayBoard()
        {
            
            for (int r=0; r<3; r++)
            {     
                Console.WriteLine("   |   |   ");        
                Console.WriteLine(" {0} | {1} | {2} ", Oxser[r,0], Oxser[r,1], Oxser[r,2]);
                if (r != 2)
                {
                    Console.WriteLine("___|___|___");                  
                }
                 
            }
            Console.WriteLine("   |   |   ");   
        }
    }
}