using System;

namespace MyApp
{

    class RefTest {

        public void dis() {

            unsafe
            {
                int i = 100;
                int* j = &i;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
        }
    }
}
