using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wire
{
    public class Main
    {
        static string path;
        static List<string> disks = new List<string>();

        public static void programm()
        {
            int[] positions_in_window;
            int position = 2;
            bool we_are_in_main = true;
            Wire.ShowDisks(we_are_in_main, path);
            while (true)
            {
                disks = Wire.Get_Path(we_are_in_main, path);
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                    Arrows arrow = new Arrows(positions_in_window[1] - 1, positions_in_window[0] - 1);
                    position--;
                    position = arrow.Up(arrow, position);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                    Arrows arrow = new Arrows(positions_in_window[1], positions_in_window[0] - 1);
                    position++;
                    position = arrow.Down(arrow, position);    
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    we_are_in_main = true;
                    path = "";
                    position = 2;
                    Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (we_are_in_main)
                    {
                        path += disks[position - 2];
                        Console.Clear();
                        we_are_in_main = false;
                        position = 2;
                        Wire.ShowDisks(we_are_in_main, path);
                    }
                    else
                    {
                        path = disks[position - 2];
                        Console.Clear();
                        position = 2;
                        Wire.ShowDisks(we_are_in_main, path);
                    }
                }
                else if (key.Key == ConsoleKey.F1)
                {

                }
                else if (key.Key == ConsoleKey.F2)
                {

                }
                else if (key.Key == ConsoleKey.F3)
                {

                }

            }
        }
    }
}
