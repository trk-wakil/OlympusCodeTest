using System;
using System.Threading;

namespace ConsoleApp
{

    /// <summary>
    /// This class will manage creating and running threads
    /// </summary>

    public class ThreadManager
    {


        /// <summary>
        /// Execute a given action on multiple threads each with the given number of times
        /// </summary>
        /// <param name="action">The action to perfomr</param>
        /// <param name="numOfThreads">Number of threads to create</param>
        /// <param name="numOfExecutions">Number of executions on each thread</param>
        public void PerformThreadedAction(Action<int> action, int numOfThreads, int numOfExecutions)
        {
            
            for (int c = 0; c < numOfThreads; c++)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    for (int d = 0; d < numOfExecutions; d++)
                    {
                        Console.WriteLine($" ---Thread Running:  {Thread.CurrentThread.ManagedThreadId}");
                        action.Invoke(Thread.CurrentThread.ManagedThreadId);
                    }                        
                }));

                t.Start();
                
            }
            
        }


    }
}
