using System;

namespace MyserverApp.BoardGame
{
    public static class MyConsole
    {
        private static bool intest = false;
        private static string retmsg = "";
        


        public static void WriteLine(string format, object arg0)
        {
            Console.WriteLine(format,arg0);
                   
        }
        
        public static void WriteLine(string format)
        {
            Console.WriteLine(format);
        }
        public static void Write(string value)
        {
            Console.Write(value);
        }
        public static string ReadLine()
        {
            if(!intest)
            {
                retmsg = Console.ReadLine();
            }
            return retmsg;
        }
        

        public static void SetIsTestMode(bool istestmode)
        {
            intest = istestmode;
        }
        public static void SetReturnMessage(string msg)
        {
            retmsg = msg;
            
        }
        
        
        
        
       
           
    }
}