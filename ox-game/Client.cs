using System;
using System.Net;
using System.Text;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    public class Client
    {
        private ISocket sck = new MySocket();
        private bool istest = false;
        private bool isinfinte = true;
        private bool myisover = false;

        private bool myisdraw = false;
       
        public void RunClient()
        {
                      
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"),6666);
            sck.Connect(endpoint);
            string msgser = "Hello Client";       
            Console.WriteLine("Receive : {0}",msgser);          
            OXBoard b1 = new OXBoard();
            OXbot mybot = new OXbot();
            
            do
            {       
                 
                MyConsole.Write("Player play : ");        
                string msg = MyConsole.ReadLine();
                
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
                //Console.ReadLine();
                //receive from bot     
                byte[] databot = new byte[1024];
                int rec = sck.Receive(databot,0,databot.Length,0);            
                Array.Resize(ref databot,rec); 
                string positionbot = Encoding.ASCII.GetString(databot);
                CheckAllofGame(b1,positionbot);
                
  
            }while(isinfinte);        
        }
        
        public void Istest(bool test)
        {
            istest = test;
        }
        

        public void SetSocket(ISocket set)
        {
            sck = set;
        }

        public void Setinfiniteloop(bool flag)
        {
            isinfinte = flag;
        }
        public void SetIsover(bool myset)
        {
            myisover = myset;
        }

        public void SetDraw(bool mydraw)
        {
            myisdraw  = mydraw;
 
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

            if(istest == true)
            {
                isover = myisover;
                isdraw = myisdraw;
            }
                         
            a1.DisplayBoard();                  
            if(isover == true && isdraw != true)
            {                                 
                MyConsole.WriteLine("Winner is {0}",getwinner);
                return;                                 
            }

            else if(isdraw == true && getwinner == "")
            {
                MyConsole.WriteLine("Is Draw");
                
            } 
        }
        

        

        

        
        
        
    }
}