using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class WaitingOnTasks
    {
        //static void Main() {
        //    var cts = new CancellationTokenSource();
        //    var token = cts.Token;

        //    var t = new Task(() => {
        //        //Scheduler is not engaged
        //        //Thread.Sleep(1000);
        //        //Scheduler is  engaged
        //        //Thread.SpinWait(1000);
        //        //SpinWait.SpinUntil();
        //        Console.WriteLine("Press any key to disarm; you have 5 seconds");
        //        bool cancelled = token.WaitHandle.WaitOne(5000);
        //        Console.WriteLine(cancelled? "Bomb disarmed":"BOOM!!!");
        //    }, token);

        //    t.Start();

        //    Console.ReadKey();
        //    cts.Cancel();

        //    Console.WriteLine("Main Ends");
        //}

        static void Main()
        {

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() =>
            {
                Console.WriteLine("I take 5 seconds");
                for (int i = 0; i < 5; i++)
                {
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(1000);
                }
                Console.WriteLine("I am done");
            }, token);
            t.Start();

            Task t2 = Task.Factory.StartNew(() =>
                { 
                    Thread.Sleep(3000);
                    Console.WriteLine("t2 Ends");
                }, token
            );


            //Console.ReadKey();
            //cts.Cancel();

            //Task.WaitAny(new[] { t, t2 }, 2000, token);

            Task.WaitAll (new[] { t, t2 }, 4000, token);

            Console.WriteLine($"Task t1 status: {t.Status}");
            Console.WriteLine($"Task t2 status: {t2.Status}");

            //Task.WaitAll(t,t2);

            //t.Wait(token);
            //t2.Wait(token);



            Console.WriteLine("Main Ends");
        }
    }
}
