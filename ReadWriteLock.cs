using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ReadWriteLock
    {
        static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        static Random random = new Random();
        static void Main() {
            int x = 0;
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                var a = i;

                tasks.Add(Task.Factory.StartNew(() => {

                    //padlock.EnterReadLock();
                    //padlock.EnterReadLock();

                    //padlock.EnterWriteLock();

                    padlock.EnterUpgradeableReadLock();

                    if (a%2 == 0)
                    {
                        padlock.EnterWriteLock();
                        x = 111;
                        padlock.ExitWriteLock();
                    }
                    else
                    {
                        padlock.EnterWriteLock();
                        x = 999;
                        padlock.ExitWriteLock();
                    }
                        
                    
                    Console.WriteLine($"Entered read lock, x={x}");
                    Thread.Sleep(1000);

                    padlock.ExitUpgradeableReadLock();

                    //padlock.ExitWriteLock();
                    //padlock.ExitReadLock();
                    //padlock.ExitReadLock();
                    Console.WriteLine($"Exit read lock, x={x}");
                }));
            }
            try {
                Task.WaitAll(tasks.ToArray());
            }
            catch (AggregateException ag) {
                ag.Handle(e => {
                    Console.WriteLine(e);
                    return true;
                });
            }
            while (true) {
                Console.ReadKey();
                padlock.EnterWriteLock();
                Console.WriteLine($"Write Lock aq");
                int newVal = random.Next(10);
                x  = newVal;
                Console.WriteLine($"Set x = {x}");
                padlock.ExitWriteLock();
                Console.WriteLine("Write Lock released");
            }
            //Console.WriteLine("Main Ends");
        }

    }
}
