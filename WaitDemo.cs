using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class WaitDemo
    {
        const int limit = 20;

        static readonly object lockMonitor = new object();

        static void PrintEven() {
            try
            {
                Monitor.Enter(lockMonitor);
                for (int i = 0; i <= limit; i = i + 2)
                {
                    Thread.Sleep(30);
                    Console.WriteLine($"{i} ");
                    Monitor.Pulse(lockMonitor);

                    if (i != limit)
                        Monitor.Wait(lockMonitor);
                }
            }
            finally { 
                Monitor.Exit(lockMonitor);
            }
        }
        static void PrintOdd()
        {
            try
            {
                Monitor.Enter(lockMonitor);
                for (int i = 1; i <= limit; i = i + 2)
                {
                    Thread.Sleep(30);
                    Console.WriteLine($"{i} ");
                    Monitor.Pulse(lockMonitor);

                    if(i != (limit-1))
                        Monitor.Wait(lockMonitor);

                }
            }
            finally
            {
                Monitor.Exit(lockMonitor);
            }
        }
        static void Main(string[] args) {
            Thread EvenThread = new Thread(PrintEven);
            Thread OddThread = new Thread(PrintOdd);
            
            EvenThread.Start();
            
            //Thread.Sleep(1000);

            OddThread.Start();

            OddThread.Join();
            EvenThread.Join();
            Console.ReadKey();
        }
    }
}
