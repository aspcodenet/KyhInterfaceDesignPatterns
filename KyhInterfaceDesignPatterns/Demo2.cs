using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyhInterfaceDesignPatterns
{
    interface ILogger
    {
        void LogError(string txt);
        void LogWarning(string txt);
    }
    class FileLogger : ILogger
    {
        public void DeleteOldFiles()
        {

        }
        public void LogError(string txt)
        {
            System.IO.File.AppendAllText("log.txt", txt);
        }

        public void LogWarning(string txt)
        {
            System.IO.File.AppendAllText("log.txt", txt);
        }
    }
    class ConsoleLogger : ILogger
    {
        public void LogError(string txt)
        {
            Console.WriteLine($"Error---{txt}");
            //Send email to admin
        }

        public void LogWarning(string txt)
        {
            Console.WriteLine($"Warning---{txt}");
        }
    }


    internal class Demo2
    {
        public void Run()
        {
            ILogger logger;
            Console.WriteLine("hur vill du logga? 1=console, 2=file");
            string s = Console.ReadLine();
            if (s == "1")
                logger = new ConsoleLogger();
            else
                logger = new FileLogger();


            logger.LogWarning("Test");
            //if(...)
            logger.LogError("Ngt gick fel");
        }
    }
}
