using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class CocurrBag
    {
        //stack LIFO
        //queu FIFO
        //no ordering

        static BlockingCollection<int> messages = new BlockingCollection<int>(new ConcurrentBag<int>(), 10);
        static CancellationTokenSource cts = new CancellationTokenSource();
        static Random random = new Random();
        static void Main()
        {
            #region
            //var bag = new ConcurrentBag<int>();
            //var tasks = new List<Task>();

            //for (int i = 0; i < 10; i++)
            //{
            //    //Console.WriteLine("-----------"+i);
            //    var r = i;
            //    tasks.Add(Task.Factory.StartNew(() => {
            //        bag.Add(r);
            //        Console.WriteLine($"{Task.CurrentId} has added {r}");
            //        int result;
            //        if (bag.TryPeek(out result))
            //        {
            //            Console.WriteLine($"{Task.CurrentId} has peeked the value {result}");
            //        }
            //    }));
            //}
            //Task.WaitAll(tasks.ToArray());
            ////int re;
            ////if (bag.TryTake(out re)) {
            ////    Console.WriteLine($"I got {re}");
            ////}

            //IEnumerable<int> values = bag.Take<int>(4);

            //foreach (var item in values)
            //{
            //    Console.WriteLine("Item:"+item);
            //}
            #endregion



            Task.Factory.StartNew(ProduceAndConsume,cts.Token);
            Console.ReadKey();
            cts.Cancel();

        }

        private static void ProduceAndConsume()
        {
            var producer = Task.Factory.StartNew(RunProducer);
            var consumer = Task.Factory.StartNew(RunConsumer);

            try {
                Task.WaitAll(new[] { producer, consumer }, cts.Token);
            }
            catch (AggregateException ae) {
                ae.Handle(e => true);
            }
        }

        private static void RunConsumer() {
            foreach (var item in messages.GetConsumingEnumerable())
            {
                cts.Token.ThrowIfCancellationRequested();
                Console.WriteLine($"-{item}\t");
                //Thread.Sleep(random.Next(1000));
                Thread.Sleep(1000);
            }
        }

        private static void RunProducer()
        {
            while (true) {
                cts.Token.ThrowIfCancellationRequested();
                int i = random.Next(100);

                messages.Add(i);
                Console.WriteLine($"+{i}\t");
                //Thread.Sleep(random.Next(10));
                Thread.Sleep(10);
            }
        }
    }
}  
