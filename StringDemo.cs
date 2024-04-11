using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _30March
{
    public delegate string DelAnon(string name);
    internal class StringDemo
    {
        //Func 16 i/p params  => out param
        //Action 16 i/p params => void
        //Predicate 16 i/p params => boolean

        public static double AddNumber1(int i, float f, double d) {
            return i + f + d;
        }
        public static void AddNumber2(int i, float f, double d)
        {
            Console.WriteLine(i + f + d);
        }
        public static bool CheckLength(string name) { 
            if (name.Length > 5)
                    return true;
            return false;
        }

        //public static string Hello(string name) {
        //    return "Hello @" + name + "Welcome to the Site";
        //}

        static void Main(string[] args) {
            Func<int, float, double, double> ob1 = new Func<int, float, double, double>(AddNumber1);
            double Result = ob1.Invoke(100, 200f, 123.345);
            Console.WriteLine(Result);

            Action<int, float, double> ob2 = new Action<int, float, double>(AddNumber2);
            ob2.Invoke(100, 200f, 123.345);

            Predicate<string> ob3 = new Predicate<string>(CheckLength);
            bool result = ob3.Invoke("Hello How Are You");
            Console.WriteLine(result);

            //Hello("John");

            DelAnon del = (name) =>
            {
                return "Hello @" + name + " Welcome to the Site";
            };

            Console.WriteLine(del.Invoke("John"));


            var DelAnon1 = new Func<string, string>(
                    delegate (string name)
                    {
                        return "Hello @" + name + " Welcome to the Site";
                    }
                );

            Console.WriteLine(DelAnon1.Invoke("John"));

        }
    }
}
