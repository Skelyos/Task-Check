using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Check
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("The time is = " + DateTime.UtcNow);
                System.Threading.Thread.Sleep(1000 * 60 * 5); // Sleep for 5 minutes
            }
        }
    }
}
