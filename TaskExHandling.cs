using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal static class TaskExHandling
    {
        static void Main()
        {
            try {
                ExpDemo();
            }
            catch (AggregateException ex) {
                foreach (var x in ex.InnerExceptions)
                {
                    Console.WriteLine($"Exception {x.GetType()} from {x.Source}");
                }
            }


            #region
            //var arr = new int[] { 1, 2, 3, 4, 5 };

            //try
            //{
            //    try
            //    {
            //        Console.WriteLine(arr[100]);
            //    }
            //    catch (Exception ex)
            //    {
            //        //Console.WriteLine("Inner");
            //        //Console.WriteLine(ex.Message);
            //        throw new Exception("",ex);
            //    }
            //}
            //catch (Exception ex) {
            //    if(ex.InnerException != null)
            //        Console.WriteLine((ex.InnerException).Message);
            //}
            #endregion


            Console.ReadKey();
            Console.WriteLine("Main Ends");
        }

        private static void ExpDemo()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                throw new InvalidOperationException("Cant do this") { Source = "t" };
            });

            var t2 = Task.Factory.StartNew(() =>
            {
                throw new AccessViolationException("Cant Access this") { Source = "t2" };
            });

            try
            {
                Task.WaitAll(t1, t2);
            }
            catch (AggregateException ex)
            {
                ex.Handle((e) => {
                    if (e is InvalidOperationException)
                    {
                        Console.WriteLine("InvalidOperationException Handled");
                        return true;
                    }
                    else return false;
                });
                //foreach (var x in ex.InnerExceptions)
                //{
                //    Console.WriteLine($"Exception {x.GetType()} from {x.Source}");
                //}
            }
        }
    }
}

//Err2  Err1