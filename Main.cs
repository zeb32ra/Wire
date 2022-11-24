using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Wire
{
    public class Main
    {
        static string path;
        static string previos_path;
        static List<string> disks = new List<string>();
        public static string elem_name;

        public static void programm()
        {
            int[] positions_in_window;
            int position = 2;
            bool we_are_in_main = true;
            string name;
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
                    previos_path = "";
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
                        previos_path = path;
                        Wire.ShowDisks(we_are_in_main, path);
                    }
                    else
                    { 
                        // if open file
                        path = disks[position - 2];
                        Console.Clear();
                        position = 2;
                        Wire.ShowDisks(we_are_in_main, path);
                    }
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a name of the Directory");
                    name = Console.ReadLine();
                    Wire.Create_Directory(path, name);
                    Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a name of the file");
                    name = Console.ReadLine();
                    Wire.Create_a_File(path, name);
                    Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    path = disks[position - 2];
                    Wire.Delete(path);
                    int slesh_pos = path.LastIndexOf('\\') + 1;
                    path = path.Substring(0, slesh_pos);
                    Wire.ShowDisks(we_are_in_main, path);
                }

            }
        }
    }
}
