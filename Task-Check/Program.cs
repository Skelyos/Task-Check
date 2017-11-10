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
                var Day = DateTime.UtcNow.Day;
                var Month = DateTime.UtcNow.Month;
                var Year = DateTime.UtcNow.Year;

                var Hour = DateTime.UtcNow.Hour;
                var Minute = DateTime.UtcNow.Minute;
                var Second = DateTime.UtcNow.Second;

                Console.WriteLine("The time is = " + Day + "/" + Month + "/" + Year + " @ " + Hour + ":" + Minute + ":" + Second);

                System.Threading.Thread.Sleep(1000 * 1); // Sleep for x time
            }
        }
    }
}
