using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    public class Client
    {
        private ISocket sck = new MySocket();
       
        public void RunClient()
        {
                      
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),6666);
            sck.Connect(endpoint);
            string msgser = "Hello Client";
            Console.WriteLine("Receive : {0}",msgser);          
            OXBoard b1 = new OXBoard();
            OXbot mybot = new OXbot();
            
            while (true)
            {       
                 
                Console.Write("Player play : ");
                string msg = Console.ReadLine();
                
                if(msg != "clear")
                {              
                    CheckAllofGame(b1,msg);   
                }
                else
                {
                    b1.Clear();
                    b1.DisplayBoard();
                    
                } 
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                sck.Send(buffer,0,buffer.Length,0);

                //receive from bot
                
                byte[] databot = new byte[1024];
                int rec = sck.Receive(databot,0,databot.Length,0);            
                Array.Resize(ref databot,rec); 
                string positionbot = Encoding.ASCII.GetString(databot);
                CheckAllofGame(b1,positionbot);
  
            }             
        }
        

        public void SetSocket(ISocket set)
        {
            sck = set;
        }

        private void CheckAllofGame(OXBoard a1,string msg)
        {
            string[] arrmsg = msg.Split(' ');
            int row = Int32.Parse(arrmsg[0]);
            int col = Int32.Parse(arrmsg[1]);
            string mark = arrmsg[2];                
            a1.Put(row,col,mark); 
            bool isover = a1.Isgameover();
            string getwinner = a1.GettheWinner();
            bool isdraw = a1.CheckDraw(); 
            a1.DisplayBoard();                  
            if(isover == true && isdraw != true)
            {                                 
                Console.WriteLine("Winner is {0}",getwinner);
                return;                                 
            }
            else if(isdraw == true && getwinner == "")
            {
                Console.WriteLine("Is Draw");
                
            } 
        }

        

        

        
        
        
    }
}