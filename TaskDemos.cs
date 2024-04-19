using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
   
    internal class TaskDemos
    {
        public static void Write(object c)
        {
            
        }

        //public static int TextLength(object c) {
        //    Console.WriteLine($"Task ID:{Task.CurrentId}");
        //    //Console.WriteLine(c.ToString().Length);
        //    return c.ToString().Length;
        //}
        static void Main() {

            var cts = new CancellationTokenSource();
            var token = cts.Token;

            token.Register(() => {
                Console.WriteLine("Cancellation has been Requested");
            });

            var t = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    //if (token.IsCancellationRequested)
                    //{ 
                    //    throw new OperationCanceledException();
                    //}
                    //break;
                    token.ThrowIfCancellationRequested();
                    Console.Write(i++ + "\t");
                }
            }, token);
            t.Start();

            Console.ReadLine();
            cts.Cancel();

            //wait
            //waitall
            //waitany


            //Task<int> t = new Task<int>(() => TextLength("Hello World"));
            //t.Start();
            //Console.WriteLine(t.Result);

            //var t2 = new Task<int>(TextLength, "Hello World");
            //t2.Start();

            //Task<int> t1 = Task.Factory.StartNew<int>(TextLength, "Hello World");
            //Task<int> t2 = Task.Factory.StartNew(TextLength, "Hello World");

            //Console.WriteLine(t1.Result);
            //Console.WriteLine(t2.Result);

            //Thread t1 = new Thread(Write);
            //Thread t2 = new Thread(Write);

            //t1.Start('c');
            //t2.Start('d');

            //1.
            //Task.Factory.StartNew(() => Write('.'));
            ////2.
            //var t = new Task(() => Write('?'));
            //t.Start();

            Console.ReadLine();
            //Write('-');
            //Console.WriteLine("Main Ended");

            //object ob = new object();
            //ob = '.';
            //ParameterizedThreadStart t = new ParameterizedThreadStart(Write);
            //Thread th = new Thread(t);
            //th.Start(ob);
        }
    }
}
