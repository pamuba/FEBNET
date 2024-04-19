using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class WaitingOnTasks
    {
        static void Main() {
            var cts = new CancellationTokenSource();
            var token = cts.Token;

            var t = new Task(() => {
                //Scheduler is not engaged
                //Thread.Sleep(1000);
                //Scheduler is  engaged
                //Thread.SpinWait(1000);
                //SpinWait.SpinUntil();
                Console.WriteLine("Press any key to disarm; you have 5 seconds");
                bool cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled? "Bomb disarmed":"BOOM!!!");
            }, token);

            t.Start();

            Console.ReadKey();
            cts.Cancel();

            Console.WriteLine("Main Ends");
        }
    }
}
