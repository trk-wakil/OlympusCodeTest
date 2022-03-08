using System;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Olympus!");

            try
            {

                var fileManager = new FileManager();
                var threadManager = new ThreadManager();

                threadManager.PerformThreadedAction(fileManager.AddNewLine, 10, 10);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
