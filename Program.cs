using System;


namespace MyserverApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string command = args[0];
            if(command == "server")
            {
                Server s1 = new Server();
                s1.RunServer();
            }
            else if(command == "client")
            {
                Client c1 = new Client();
                c1.RunClient();
            }
            
        }
    }
}
