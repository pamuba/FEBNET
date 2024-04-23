using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March2
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
        public void Transfer(BankAccount where, int amount)
        {
            balance -= amount;
            where.Balance += amount;
        }
    }
    internal class MutexTask
    {
        static void Main()
        {
            var tasks = new List<Task>();
            var ba = new BankAccount();
            var ba2 = new BankAccount();

            Mutex mutex = new Mutex();
            Mutex mutex2 = new Mutex();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        bool havelock = mutex.WaitOne();
                        try { ba.Deposit(1); }
                        finally {if (havelock) mutex.ReleaseMutex(); }
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 10; j++)
                    {
                        bool havelock = mutex2.WaitOne();
                        try { ba2.Deposit(1); }
                        finally { if (havelock) mutex2.ReleaseMutex(); }
                    }
                }));
                tasks.Add(Task.Factory.StartNew(() =>
                {
                    for (int k = 0; k < 10; k++)
                    {
                        bool haveLock = WaitHandle.WaitAll(new[] { mutex, mutex2 });
                        try
                        {
                            ba.Transfer(ba2, 10);
                            //Console.WriteLine("Deposited");
                        }
                        finally
                        {
                            if (haveLock)
                            {
                                mutex.ReleaseMutex();
                                mutex2.ReleaseMutex();
                            }
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final balance: {ba.Balance}");
            Console.WriteLine($"Final balance: {ba2.Balance}");

          }
        }
    
}
