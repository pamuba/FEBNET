using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    public class BankAccount { 

        public object padlock = new object();

        private int balance;

        public int Balance { get => balance; private set => balance = value; }

        public void Deposit(int amount) {
            //op1: temp <- get_Balance() + amount
            //op2: set_Balance(temp)
            //lock (padlock)
            //{
            //Balance += amount;
            //}
            Interlocked.Add(ref balance, amount);

            //st 1
            //Interlocked.MemoryBarrier();
            //st 2
            //Interlocked.MemoryBarrier();
            //Thread.MemoryBarrier();
            //st 3
        }

        public void Withdraw(int amount)
        {
            //lock (padlock)
            //{
            //    Balance -= amount;
            //}
            //lock free programming
            Interlocked.Add(ref balance, -amount);
        }
    }
    internal class TaskSync
    {
        static void Main() {
            var tasks = new List<Task>();
            var ba = new BankAccount();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Deposit(100);
                    }
                }));

                tasks.Add(Task.Factory.StartNew(() => {
                    for (int j = 0; j < 1000; j++)
                    {
                        ba.Withdraw(100);
                    }
                }));
            }
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"Final balance: {ba.Balance}");
        }
    }
}
