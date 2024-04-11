using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    public delegate void ResultCallback(int Result);

    class NumHelper {

        private int _Number = 0;
        private ResultCallback _resultCallback;

        public NumHelper(int Number, ResultCallback resultCallback) { 
            _Number = Number;
            _resultCallback = resultCallback;
        }
        public void Sum()
        {
            int Result = 0;

            for (int i = 1; i <= _Number; i++)
            {
                Result += i;
            }
            _resultCallback(Result);
        }
    }
    internal class lambdaexp
    {
        static int balance = 100;
        readonly static string lockOb = "22";
        static void Main(string[] args) 
        {
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1",
                Priority = ThreadPriority.BelowNormal
            
            };
            Thread t2 = new Thread(Method1)
            {
                Name = "Thread2",
                Priority = ThreadPriority.Lowest
            };
            Thread t3 = new Thread(Method1)
            {
                Name = "Thread3",
                Priority = ThreadPriority.Highest
            };

            t1.Start();
            t2.Start();
            t3.Start();

        }
            
        
        public static void Method1() {
            lock (lockOb) {
                Console.WriteLine("Started by " + Thread.CurrentThread.Name);
                //Thread.Sleep(5000);
                balance += 20;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("-----" + Thread.CurrentThread.Name);
                }
                Console.WriteLine(balance);
                Console.WriteLine(Thread.CurrentThread.Name + " Ended");
            }
        }
    }
}
