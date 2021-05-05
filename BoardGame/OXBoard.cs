using System;

namespace MyserverApp.BoardGame
{
    public class OXBoard
    {
        private string[,] board = new string[3,3];
        //private string winner = "";
        
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

        public void Put(int row , int col, string mark)
        {
            
            if(board[row,col].Equals(" "))
            {
                board[row,col] = mark;
            }
            else
            {
                Console.WriteLine("Is already exist");
                
            }
            
        }

        public bool CheckWinnerbyRow(int row)
        {
            string previousmark = "";
            for(int col = 0; col < 3; col++)
            {
                string mark = board[row,col];
                if (col == 0)
                {
                    previousmark = mark;
                }
            }

            return true;
        }

        public void Isgameover()
        {
            bool checkrow0 = CheckWinnerbyRow(0);
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