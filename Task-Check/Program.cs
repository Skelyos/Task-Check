using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

                var mod = Second % 10;

                List<string> LineList = new List<string>();

                string Location = System.Configuration.ConfigurationManager.AppSettings["LogPath"];
                string Destination = System.Configuration.ConfigurationManager.AppSettings["LogDestination"];

                if (mod == 0)
                {
                    using (var fs = File.OpenRead(Location + ".txt"))
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        { 
                            var Line = reader.ReadLine();
                            LineList.Add(Line);

                            Console.WriteLine(Line);
                        }
                    }

                    using (StreamWriter file2 = new StreamWriter(Destination + ".txt", true))
                    {

                    }
                }
                else
                {
                    Console.WriteLine("The time is = " + Day + "/" + Month + "/" + Year + " @ " + Hour + ":" + Minute + ":" + Second);
                }



                System.Threading.Thread.Sleep(1000 * 1); // Sleep for x time
            }
        }
    }
}
