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

                var FullDate = " - " + Day + "-" + Month + "-" + Year;

                var Hour = DateTime.UtcNow.Hour;
                var Minute = DateTime.UtcNow.Minute;
                var Second = DateTime.UtcNow.Second;

                var mod = Second % 30;

                int ArrayLength = 0;
                List<string> LineList = new List<string>();
                string[] Commands = { "" };
                List<string> FileCheck = new List<string>();
                string[] FileCheckArray = { "" };
                int count = 0;

                bool LineCheck = false;
                var Line = " ";

                string Location = System.Configuration.ConfigurationManager.AppSettings["LogPath"];
                string Destination = System.Configuration.ConfigurationManager.AppSettings["LogDestination"];

                if (mod == 0)
                {
                    using (var fs = File.OpenRead(Location + ".txt"))
                    using (var reader = new StreamReader(fs))
                    {
                        while (!reader.EndOfStream)
                        {
                            Line = reader.ReadLine();
                            LineList.Add(Line);
                            Commands = LineList.ToArray();
                            FileCheck.Add(Line);
                            FileCheckArray = FileCheck.ToArray();
                            ArrayLength = Commands.Length;
                        }

                        if (LineCheck == false)
                        {
                            for (int i = 0; i < ArrayLength; i++)
                            {
                                if (Line == " ")
                                {
                                    Console.WriteLine("File clear");
                                    LineCheck = true;
                                }
                                else if (Commands[count] == FileCheckArray[count])
                                {
                                    Console.WriteLine("File not clear");
                                    LineCheck = false;
                                }
                                count++;
                            }
                        }

                        else if (LineCheck == true)
                        {
                            Console.WriteLine("Written to another text file @ " + Day + "/" + Month + "/" + Year + " @ " + Hour + ":" + Minute + ":" + Second);
                            count = 0;
                            for (int i = 0; i < ArrayLength; i++)
                            {
                                using (StreamWriter Writer = new StreamWriter(Destination + FullDate + ".txt", true))
                                {
                                    Writer.WriteLine(Commands[count]);
                                    count++;
                                }
                            }
                        }
                    }
                }

                else
                {
                    Console.WriteLine(Day + "/" + Month + "/" + Year + " @ " + Hour + ":" + Minute + ":" + Second);
                }

                if (mod != 0)
                {
                    System.Threading.Thread.Sleep(1000 * 1); // Sleep for 1
                }
                else
                {
                    System.Threading.Thread.Sleep(1000 * 30); // Sleep for 10 
                }
            }
        }
    }
}
