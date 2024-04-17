using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class SemaphoreDemo
    {
        public static Semaphore semaphore = new Semaphore(2,3);
        static void Main(string[] args)
        {
            for (int i = 0; i <=10; i++)
            {
                Thread th = new Thread(DoSomeTask)
                {
                    Name = "Thread: " + i
                };
                th.Start();
            }
            Console.ReadKey();
        }
        static void DoSomeTask() {
            Console.WriteLine(Thread.CurrentThread.Name + "Wants to Enter CS for processing");
            try
            {
                semaphore.WaitOne();
                Console.WriteLine("Success:" + Thread.CurrentThread.Name + " is processing");
                Thread.Sleep(3000);
                Console.WriteLine("Done:" + Thread.CurrentThread.Name + " has finished");

            }
            finally {
                semaphore.Release();
            }
        }
    }
}
