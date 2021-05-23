using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MyserverApp
{
    
    public class Server
    {
        private string[,] OXboardSer = new string[3,3];

        

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

        private static void DoWork(Socket sck)
        {
            Console.WriteLine("Connect Complete");
            Client c1 = new Client();
            Server s1 = new Server();

            while(true)
            {
                
                byte[] arrbyte = new byte[1024];
                int rec = sck.Receive(arrbyte,0,arrbyte.Length,0);            
                Array.Resize(ref arrbyte,rec); 
                string msgfromclient = Encoding.ASCII.GetString(arrbyte);
                string[] arrmsg = msgfromclient.Split(' ');
                int row = Int32.Parse(arrmsg[0]);
                int col = Int32.Parse(arrmsg[1]);
                string mark = arrmsg[2];
                string flipmark = FlipMark(mark);        
                s1.PutPositionClient(row,col,mark);              
                //Console.WriteLine(msgfromclient);
                s1.DisplayBoardServer();
            
            }
         
        }

        private static string FlipMark(string markclient)
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

        private static void CheckBoardEmpty()
        {
            for(int row = 0 ; row < 3 ; row++)
            {
                for(int col = 0 ; col < 3 ;col++)
                {

                }
            }
        }

        private void DisplayBoardServer()
        {
            for (int r=0; r<3; r++)
            {     
                Console.WriteLine("   |   |   ");        
                Console.WriteLine(" {0} | {1} | {2} ", OXboardSer[r,0], OXboardSer[r,1], OXboardSer[r,2]);
                if (r != 2)
                {
                    Console.WriteLine("___|___|___");                  
                }
                 
            }
            Console.WriteLine("   |   |   ");   
        }
        

        private void PutPositionClient(int row, int col,string mark)
        {
            if(OXboardSer[row,col] == " ")
            {
                OXboardSer[row,col] = mark;
            }
            
            
            
        }

       

        
         
        
        
    }
}