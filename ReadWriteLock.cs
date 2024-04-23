using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ReadWriteLock
    {
        static ReaderWriterLockSlim padlock = new ReaderWriterLockSlim();

        static void Main() {
            int x = 0;
            var tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(() => {
                    padlock.EnterReadLock();
                    Console.WriteLine($"Entered read lock, x={x}");
                    Thread.Sleep(3000);
                    padlock.ExitReadLock();
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
            Console.WriteLine("Main Ends");
        }

    }
}
