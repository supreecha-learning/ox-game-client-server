using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    public class Client
    {
        string[] arrmsg = new string[3];
        public void RunClient()
        {
            
            Socket sck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),6666);
            sck.Connect(endpoint);
            string msgser = "Hello Client";
            Console.WriteLine("Receive : {0}",msgser);
            
            OXBoard b1 = new OXBoard();
            

            while (true)
            {       
                 
                Console.Write("Player play : ");
                string msg = Console.ReadLine(); 
                
                if(msg != "clear")
                {
                    arrmsg = msg.Split(' ');
                    int row = Int32.Parse(arrmsg[0]);
                    int col = Int32.Parse(arrmsg[1]);
                    string mark = arrmsg[2];
                    b1.Put(row,col,mark);         
                    b1.DisplayBoard();
                    
                    bool isover = b1.Isgameover();
                    string getwinner = b1.GettheWinner();
                    bool isdraw = b1.CheckDraw();
                    if(isover == true && isdraw != true)
                    {
                        Console.WriteLine("Winner is {0}",getwinner);
                        b1.Clear();              
                    }
                    else if(isdraw == true)
                    {
                        Console.WriteLine("Is Draw");
                        b1.Clear();
                    }

                }
                else
                {
                    b1.Clear();
                    b1.DisplayBoard();
                } 
                               
                byte[] arrbyte = Encoding.ASCII.GetBytes(msg);
                sck.Send(arrbyte,0,arrbyte.Length,0);

              
            }             
        }
        public int GetRow()
        {
            int getrow = Int32.Parse(arrmsg[0]);
            return(getrow);
            
        }

        public int GetCol()
        {
            int getcol = Int32.Parse(arrmsg[1]);
            return(getcol);
            
        }

        public string GetMark()
        {
            return(arrmsg[2]);
        }
        
    }
}