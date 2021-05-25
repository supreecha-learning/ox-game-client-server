using System;
using MyserverApp;
namespace MyserverApp.BoardGame
{
    public class OXbot
    {

        private string[,] Oxser = new string[3,3];
        private string flip = "";
        private int rowbot = 0;
        private int colbot = 0;
        private string flipmark = "";

        public string SendPosition()
        {
            
            string myrow = Convert.ToString(rowbot);
            string mycal = Convert.ToString(colbot);
            string myflipmark = Convert.ToString(flipmark);
            string position = myrow + " " + mycal + " " + myflipmark;
            return position;
            
        }
        

        public void CheckEmptyinArr()
        {
            OXbot bot = new OXbot();
            for(int row = 0 ; row < 3; row++)
            {
                for(int col = 0 ; col < 3 ; col++)
                {
                    if(Oxser[row,col].Equals(" "))
                    {
                        bot.PutPositionBoard(row,col,flip);
                        rowbot = row;
                        colbot = col;
                        flipmark = flip;
                        
                    }
                    
                }
            }
           
        }

        public void FlipMark(string markclient)
        {
            
            if(markclient.Equals("O"))
            {
                flip = "X";
            }
            else
            {
                flip = "O";
            }
            
        }

        public void PutPositionBoard(int row,int col,string mark)
        {
            if (Oxser[row,col].Equals(" "))
            {
                Oxser[row,col] = mark;
            }
            else
            {
                Console.WriteLine("Is already exist");         
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