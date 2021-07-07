using System;

using System.Text;
using System.Threading;
using MyserverApp.BoardGame;

namespace MyserverApp
{
    public class Server
    {
        private ISocket mysck = new MySocket();
        private bool isInfinite = true;        

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
        
        public void SetSocket(ISocket sck)
        {
            mysck = sck;
        }

        public void SetIsInfinte(bool flag)
        {
            isInfinite = flag;
        }

        public void RunServer()
        {                     
            mysck.Bind("127.0.0.1", 6666); // สั่งให้ socket รอการเชื่อมต่อโดยผ่าน port ที่ระบุ จาก client
            Console.WriteLine("Waiting for Connect");     
            
            do
            {
                mysck.Listen(10);  // .Listen รอการ connect จาก client ในที่นี้ใส่เป็น 10
                ISocket acceptedConn = mysck.Accept(); // มีการ connect จาก client
                Thread t1 = new Thread(() => DoWork(acceptedConn)); //Annoymous function
                t1.Start();
            } while (isInfinite);
        }

        private void DoWork(ISocket sck)
        {
            Console.WriteLine("Connect Complete");        
            OXbot mybot = new OXbot();

            while (true)
            {
                //receive position from client
                byte[] arrbyte = new byte[1024];
                int rec = sck.Receive(arrbyte, 0, arrbyte.Length, 0);            
                Array.Resize(ref arrbyte, rec); 
                string msgfromclient = Encoding.ASCII.GetString(arrbyte);
                string[] arrmsg = msgfromclient.Split(' ');
                int row = Int32.Parse(arrmsg[0]);
                int col = Int32.Parse(arrmsg[1]);
                string mark = arrmsg[2]; 

                string flipmark = mybot.FlipMark(mark);
                mybot.PutPositionBoard(row,col,mark);  
                string posibot = mybot.SendPositionBotplay(flipmark);
                //mybot.DisplayBoard();
                //Console.WriteLine(posibot);
                
                //Send botplay
                byte[] databot = Encoding.ASCII.GetBytes(posibot);
                sck.Send(databot, 0, databot.Length, 0);
            }
        }   

        
    }   
}