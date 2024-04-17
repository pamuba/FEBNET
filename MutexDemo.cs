using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class MutexDemo
    {
        private static Mutex mutex = new Mutex();
        static void Main(string[] args) {
            for (int i = 1; i <=10 ; i++)
            {
                Thread obj = new Thread(MutexFun)
                {
                    Name = "Thread:" + i
                };
                obj.Start();
                Console.WriteLine(DateTime.Now.Millisecond);
            }
        }

        //shared resource
        private static void MutexFun() {
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to enter the CS");

            if (mutex.WaitOne(100))
            {
                try
                {
                    //Wait until its safe to enter the Critical Section
                    //Blocks the current thread until the current WaitOne receives a signal
                    //mutex.WaitOne(100);
                    Console.WriteLine(Thread.CurrentThread.Name + " is processingnow");
                    Thread.Sleep(2000);
                    Console.WriteLine(Thread.CurrentThread.Name + " has Completed now");
                }
                catch (Exception e) { }
                finally
                {
                    mutex.ReleaseMutex();
                    Console.WriteLine(Thread.CurrentThread.Name + " has releaed the mutex");
                }
                mutex.ReleaseMutex();
                Console.WriteLine(Thread.CurrentThread.Name + " has releaed the mutex");

            }
            else {
                Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
                
            }
        }
        //~MutexDemo()
        //{
        //    mutex.Dispose();
        //}
    }
}
