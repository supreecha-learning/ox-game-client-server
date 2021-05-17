using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace MyserverApp
{
    
    public class Server
    {
        private static string[,] OXboardSer = new string[3,3];

        

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
            while(true)
            {
                
                byte[] arrbyte = new byte[1024];
                int rec = sck.Receive(arrbyte,0,arrbyte.Length,0);
                Array.Resize(ref arrbyte,rec); 
                int row = c1.SendInputRow(); 
                int col = c1.SendInputCol(); 
                string mark = c1.SendInputMark(); 
                Console.WriteLine(mark);
                
                
                       
                
                

               
            }
              
        }

        private static void PutPosition(int row, int col,string mark)
        {
            if(OXboardSer[row,col].Equals(" "))
            {
                OXboardSer[row,col] = mark;
            }
            
        }

       

        
         
        
        
    }
}