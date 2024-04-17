using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ResetDemo
    {
        static ManualResetEvent autoObj = new ManualResetEvent(false);
        static void Main()
        {
            new Thread(SomeMethod).Start();
            //
            //
            //Set
            Console.ReadLine();
            autoObj.Set();
            //Console.ReadLine();
            //autoObj.Set();


        }
        static void SomeMethod() {
            Console.WriteLine("Starting 1");
            //Wait
            autoObj.WaitOne();
            Console.WriteLine("Finishing  1");

            Console.WriteLine("Starting 2");
            //Wait
            autoObj.WaitOne();
            Console.WriteLine("Finishing 2");

        }
    }
}
