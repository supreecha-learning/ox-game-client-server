using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    
    public class Server
    {
        public string[,] OXboardSer = new string[3,3];
        
        public Server()
        {
            for (int i=0; i<=2; i++)
            {
                for (int j=0; j<=2; j++)
                {
                    OXboardSer[i, j] = " ";
                }
            }
        }
        

        public void RunServer()
        {         
            
            Socket mysck = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp); //สร้าง socket โดยระบุ ip sockettype protocaltype
            mysck.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"),6666)); // สั่งให้ socket รอการเชื่อมต่อโดยผ่าน port ที่ระบุ จาก client
            Console.WriteLine("Waiting for Connect");     
            
            while (true)
            {
                mysck.Listen(10);  // .Listen รอการ connect จาก client ในที่นี้ใส่เป็น 10
                Socket acceptedConn = mysck.Accept(); // มีการ connect จาก client
                Thread t1 = new Thread(() => DoWork(acceptedConn)); //Annoymous function
                t1.Start();
                
            }
                   
/*            
                        
*/
        }

        private void DoWork(Socket sck)
        {
            Console.WriteLine("Connect Complete");        
            OXbot mybot = new OXbot();

            while(true)
            {
                //receive position from client
                byte[] arrbyte = new byte[1024];
                int rec = sck.Receive(arrbyte,0,arrbyte.Length,0);            
                Array.Resize(ref arrbyte,rec); 
                string msgfromclient = Encoding.ASCII.GetString(arrbyte);
                string[] arrmsg = msgfromclient.Split(' ');
                int row = Int32.Parse(arrmsg[0]);
                int col = Int32.Parse(arrmsg[1]);
                string mark = arrmsg[2]; 

                mybot.FlipMark(mark);
                mybot.PutPositionBoard(row,col,mark);  
                mybot.CheckEmptyinArr();
                string botplay = mybot.SendPosition();       
                mybot.DisplayBoard();        
                
            
            }
        }    
    }   
}