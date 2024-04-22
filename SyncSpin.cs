using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March1
{
    public class BankAccount
    {

        public object padlock = new object();

        private int balance;

        public int Balance { get => balance; private set => balance = value; }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            balance -= amount;
        }
    }
    internal class SyncSpin
    {
        static SpinLock sl = new SpinLock();
        public static void LockRecursion(int x) {
            bool lockTaken = false;
            try
            {
                sl.Enter(ref lockTaken);
            }
            catch (Exception e) {
                Console.WriteLine("Inside catch:"+e);
            }
            finally {
                if (lockTaken)
                {
                    Console.WriteLine($"Took a lock, x = {x}");
                    LockRecursion(x - 1);
                    sl.Exit();
                }
                else {
                    Console.WriteLine($"Failed to take a lock,x = {x}");
                }
            }


        }
        static void Main()
        {
            #region
            //var tasks = new List<Task>();
            //var ba = new BankAccount();

            //SpinLock sl = new SpinLock();

            //for (int i = 0; i < 10; i++)
            //{
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int j = 0; j < 1000; j++)
            //        {
            //            var lockTaken = false;

            //            try
            //            {
            //                sl.Enter(ref lockTaken);
            //                if (lockTaken)
            //                    ba.Deposit(100);
            //            }
            //            finally {
            //                if (lockTaken)
            //                    sl.Exit();
            //            }

            //        }
            //    }));

            //    tasks.Add(Task.Factory.StartNew(() => {
            //        for (int j = 0; j < 1000; j++)
            //        {
            //            var lockTaken = false;

            //            try
            //            {
            //                sl.Enter(ref lockTaken);
            //                if (lockTaken)
            //                    ba.Withdraw(100);
            //            }
            //            finally
            //            {
            //                if (lockTaken)
            //                    sl.Exit();
            //            }

            //        }
            //    }));
            //}
            //Task.WaitAll(tasks.ToArray());
            #endregion


            
            LockRecursion(5);

        }
    }
    
}

//SpinLock
//Lock
//Monitor
