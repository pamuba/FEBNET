using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    class Account { 
        public int ID { get; set; }
        public double Balance { get; set; }

        public Account(int iD, double balance)
        {
            ID = iD;
            Balance = balance;
        }
        public void WithdrawMoney(double amount)
        {
            Balance -= amount;
        }
        public void DepositMoney(double amount)
        {
            Balance += amount;
        }

    }

    class AccountManager {
        private Account FromAccount;
        private Account ToAccount;
        private double TransferAmoumt;

        public AccountManager(Account fromAccount, Account toAccount, double transferAmoumt)
        {
            FromAccount = fromAccount;
            ToAccount = toAccount;
            TransferAmoumt = transferAmoumt;
        }

        public void FundTranfer()
        {
            //object lock1, lock2;

            //if (FromAccount.ID < ToAccount.ID)
            //{
            //    lock1 = FromAccount;
            //    lock2 = ToAccount;
            //}
            //else {
            //    lock2 = FromAccount;
            //    lock1 = ToAccount;
            //}


            //Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {((Account)lock1).ID}");
            //lock (lock1)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {((Account)lock1).ID}");
            //    Console.WriteLine($"{Thread.CurrentThread.Name}  Implementing the Transaction");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {((Account)lock2).ID}");
            //    lock (lock2) {
            //        Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {((Account)lock2).ID}");
            //        Console.WriteLine("Amount Transferred:" + Thread.CurrentThread.Name);
            //        FromAccount.WithdrawMoney(TransferAmoumt);
            //        ToAccount.DepositMoney(TransferAmoumt);

            //    }
            //}

            //Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {FromAccount.ID}");
            //lock (FromAccount) { 
            //    Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {FromAccount.ID}");
            //    Console.WriteLine($"{Thread.CurrentThread.Name}  Implementing the Transaction");
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {ToAccount.ID}");

            //    if (Monitor.TryEnter(ToAccount, 500))
            //    {
            //        Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {ToAccount.ID}");
            //        try
            //        {
            //            Console.WriteLine("Amount Transferred:");
            //            FromAccount.WithdrawMoney(TransferAmoumt);
            //            ToAccount.DepositMoney(TransferAmoumt);
            //        }
            //        finally { Monitor.Exit(ToAccount); }
            //    }
            //    else { 
            //        Console.WriteLine($"{Thread.CurrentThread.Name} Unable to acquire the lock on {FromAccount.ID}. Exiting...");
            //    }
            //}



                
                //Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {FromAccount.ID}");
                //Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {FromAccount.ID}");
                //Console.WriteLine($"{Thread.CurrentThread.Name}  Implementing the Transaction");
                //Thread.Sleep(1000);
                //Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire the lock on {ToAccount.ID}");

                //DeadLock.autoObj.WaitOne();
            
                //Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock on {ToAccount.ID}");
                //Console.WriteLine("Amount Transferred: "+ Thread.CurrentThread.Name);
                //FromAccount.WithdrawMoney(TransferAmoumt);
                //ToAccount.DepositMoney(TransferAmoumt);
            
        }

    }

    internal class DeadLock
    {
        public static AutoResetEvent autoObj = new AutoResetEvent(false);

        static void Main() {
            Console.WriteLine("Main Thread");
            Account acc1001 = new Account(1001, 1000);
            Account acc1002 = new Account(1002, 2000);

            AccountManager manager1 = new AccountManager(acc1001, acc1002, 500);
            Thread thread1 = new Thread(manager1.FundTranfer) { 
                Name = "Thread1"
            };

            AccountManager manager2 = new AccountManager(acc1002, acc1001, 500);
            Thread thread2 = new Thread(manager2.FundTranfer)
            {
                Name = "Thread2"
            };

            thread1.Start();
            thread2.Start();

            autoObj.Set();
            autoObj.Set();

            //thread1.Join();
            //thread2.Join();

            //Console.ReadLine();

        }
    }
}
