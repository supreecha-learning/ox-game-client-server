using System;


namespace MyserverApp
{
    public class Program
    {
        
        private static void Main(string[] args)
        {
            string command = args[0];
            RunProgram(command);
            
 
        }

        public static bool RunProgram(string cmd)
        {
            bool result = false;
            if(cmd == "server")
            {
                Server s1 = new Server();
                result = true;
                s1.RunServer();
            }
            else if(cmd == "client")
            {
                Client c1 = new Client();
                result = true;
                c1.RunClient();
            }
            return(result);
        }

        
    }
}
