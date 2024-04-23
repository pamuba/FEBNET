using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30March
{
    internal class ConCurrDict
    {
        private static ConcurrentDictionary<string, string> capitals = 
            new ConcurrentDictionary<string, string>();

        public static void AddParis() {
            bool success = capitals.TryAdd("France", "Paris");
            string who = Task.CurrentId.HasValue ? ("Task "+Task.CurrentId):"Main Thread";
            Console.WriteLine($"{who} {(success ? "added" : "did not add")} the element.");
        }
        
        static void Main() {
            Task.Factory.StartNew(AddParis).Wait();
            AddParis();

            //capitals["Russia"] = "Leningrad";
            //capitals["Russia"] = "Moscow";

            capitals.AddOrUpdate("Russia", "Moscow",
                (k, old) => old + " --> Moscow");

            Console.WriteLine(capitals["Russia"]);


            //capitals["Sweden"] = "Uppasala";
            var capOfSweden = capitals.GetOrAdd("Sweden", "Stockholm");

            Console.WriteLine(capOfSweden);

            string removed;
            var didRemove = capitals.TryRemove("Russia", out removed);

            if (didRemove)
            { 
                Console.WriteLine(removed);
            }
            else
                Console.WriteLine("Not Removed");

        }
    }
}
