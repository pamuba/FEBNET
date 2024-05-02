using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ParallelLoops
    {
        
        public static IEnumerable<int> Range(int start, int end, int step) {

            for (int i = start; i <= end; i+=step)
            {
                yield return i;
            }

        }
        static void Main() {

            //foreach (var item in Range(1, 10, 1))
            //{
            //    Console.WriteLine(item);
            //}
            var po = new ParallelOptions();
           
            
            po.MaxDegreeOfParallelism = 5;

            //po.CancellationToken
            
            Parallel.ForEach(Range(1, 10, 1), po, Console.WriteLine);

            //Console.WriteLine(Range(1, 10, 1).First());
            //Console.WriteLine("Ouside For");
            //Console.WriteLine(Range(1, 10, 1).Last());

            //var a = new Action(() => Console.WriteLine($"First {Task.CurrentId}"));
            //var b = new Action(() => Console.WriteLine($"Second {Task.CurrentId}"));
            //var c = new Action(() => Console.WriteLine($"Third {Task.CurrentId}"));

            //Parallel.Invoke(a, b, c);

            //Parallel.For(1, 51, i => {
            //    Console.WriteLine($"{i*i}\t");
            //});

            //string[] words = { "hello", "hi", "Paraller", "Task" };
            //Parallel.ForEach(words, word  => Console.WriteLine($"{word} has lenght {word.Length} (tasK:{Task.CurrentId})"));
        }

        //async fn() {
        //
        //  await 1. fetching data
        //  await 2. writing data  
        //  await 3. dowlading from api
        //}
    }
}
