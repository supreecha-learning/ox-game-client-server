using System;
using MyserverApp;
namespace MyserverApp.BoardGame
{
    public class OXbot
    {

        string[,] Oxser = new string[3,3];
        public OXbot()
        {
            Server s1 = new Server();
            Oxser = s1.OXboardSer; 
        }
        public string SendPositionBotplay()
        {
           return "SS";
        }

        public bool CheckEmptyinArr(string[,] arrser)
        {
            for(int row = 0 ; row < 3; row++)
            {
                for(int col = 0 ; col < 3 ; col++)
                {
                    if(arrser[row,col].Equals(" "))
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }

        public string FlipMark(string markclient)
        {
            string remark = "";
            if(markclient.Equals("O"))
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