using System;
using System.Net;
using System.Net.Sockets;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    public class Client
    {
        
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
                    string[] arrmsg = msg.Split(' ');
                    int row = Int32.Parse(arrmsg[0]);
                    int col = Int32.Parse(arrmsg[1]);
                    string mark = arrmsg[2];
                    b1.Put(row,col,mark);
                    b1.DisplayBoard();
                    b1.CheckWinnerbyRow(0);
                }
                else
                {
                    b1.Clear();
                    b1.DisplayBoard();
                }                  
                



                /*
                string msg = Console.ReadLine();
                byte[] arrbyte = Encoding.ASCII.GetBytes(msg);
                sck.Send(arrbyte,0,arrbyte.Length,0);

                //Receive echo from server
                int rec = sck.Receive(arrbyte,0,arrbyte.Length,0);
                Array.Resize(ref arrbyte,rec);
                Console.WriteLine("Receive Echo : {0}",Encoding.Default.GetString(arrbyte));
                */


                
                
            }
            /*
            sck.Close();
            Console.Read();
            */
        }
    }
}