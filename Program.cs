using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using ClassLibrary1;
namespace MyApp
{
    delegate string StrMod(string str);

    public static class Test {
        public static string ReplaceSpaces(string s) {
            Console.WriteLine("Replacing Spaces:");
            return s.Replace(" ", "-");
        }

        public static string RemoveSpaces(string s)
        {
            Console.WriteLine("Removing Spaces:");
            return s.Replace(" ", "");
        }
        public static string ReverseString(this string s)
        {
            string val = null;
            Console.WriteLine("Reversing String:");
            for (int i = s.Length-1; i >= 0; i--) {
                val += s[i];
            }
            return val;
        }
    }

    class Program 
    {
        public  event StrMod SomeEvent;

        static void Main(string[] args)
        {
            //string str = "Hello how ru";
            //StrMod strOp = new StrMod(Test.ReplaceSpaces);
            //Console.WriteLine(strOp(str));

            //strOp = new StrMod(Test.ReverseString);
            //Console.WriteLine(strOp(str));


            //strOp = new StrMod(Test.RemoveSpaces);
            //Console.WriteLine(strOp(str));

            //Multicasting the delegate

            string str = "Hello how ru";
            str.ReverseString();
            StrMod strOp = new StrMod(Test.ReplaceSpaces);
            strOp += Test.ReverseString;
            strOp += Test.RemoveSpaces;

            //Console.WriteLine(strOp(str));


            //strOp -= Test.ReverseString;

            //Delegate[] del = strOp.GetInvocationList();


            //foreach (Delegate d in del) {
            //    Console.WriteLine(d.Method);
            //}

            //Raising an event like a button click
            Program evt = new Program();
            evt.SomeEvent += strOp;
            Console.WriteLine(evt.SomeEvent(str));
            

        }
        
    }
}


