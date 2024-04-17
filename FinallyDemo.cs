using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class FinallyDemo
    {
        static int dmeo() {
            try
            {
                Console.WriteLine("Inside try");
                throw new Exception("safasd");
            }
            finally {
                Console.WriteLine("Inside Finally");
            }
        }

        static void Main(String[] args) {
            Console.WriteLine(dmeo());
        }

    }
}
