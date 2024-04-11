using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class EnterDemo
    {
        private static readonly object lockObject = new object();

        public static void PrintNumbers() {
            Console.WriteLine(Thread.CurrentThread.Name+ " Trying to access the critical section.");
            TimeSpan timeout = TimeSpan.FromMicroseconds(1000);
            bool IsLockTaken = false;
            try
            {
                Monitor.TryEnter(lockObject, timeout, ref IsLockTaken);
                Console.WriteLine(Monitor.IsEntered(lockObject));
                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section.");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ".");
                    }
                    Console.WriteLine();
                }
                else {
                    Console.WriteLine(Thread.CurrentThread.Name+" Couldnt acquire Lock");
                }
                
            }
            finally {
                if (IsLockTaken) {
                    Monitor.Exit(lockObject);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exited the critical section.");
                }
                
            }


        }
        static void Main(string[] args) {
            //Thread test = new Thread(PrintNumbers);
            //test.Start();
            Thread[] threads = new Thread[3];

            for (int i = 0; i < 3; i++)
            {
                threads[i] = new Thread(PrintNumbers) {
                    Name = "Child Thread: " + i
                };
            }
            foreach(Thread t in threads) {
                t.Start();
            }

        }
    }
}
