using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ParallelCancel
    {
        private static ParallelLoopResult result;

        public static void Demos() {
            var cts = new CancellationTokenSource();

            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;


            result = Parallel.For(0, 41, po, (int x, ParallelLoopState state) => {
                Console.WriteLine($"{x} [{Task.CurrentId}]\t");
                if (x == 10) {
                    //throw new Exception();
                    //state.Stop();
                    //Recommanded
                    //state.Break();
                    //return;
                    cts.Cancel();
                }
            });

            Console.WriteLine();
            Console.WriteLine($"has the loop Completed:{result.IsCompleted}");
            if (result.LowestBreakIteration.HasValue) {
                Console.WriteLine($"Lowest Break Iteration is {result.LowestBreakIteration}");
            }
        }
        static void Main() {
            try
            {
                Demos();
            }
            catch(AggregateException ae) {
                //Console.WriteLine(ae);
                ae.Handle(e => {
                    Console.WriteLine(e.Message);
                    return true;
                });
            }
        }
    }
}
