using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wire
{
    public class Main
    {
        
        public static void programm()
        {
            int[] positions_in_window;
            int position = 2;
            positions_in_window = Wire.ShowDisks();
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Arrows arrow = new Arrows(positions_in_window[1] - 1, positions_in_window[0] - 1);
                    position--;
                    position = arrow.Up(arrow, position);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Arrows arrow = new Arrows(positions_in_window[1], positions_in_window[0] - 1);
                    position++;
                    position = arrow.Down(arrow, position);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Wire.ShowDisks();
                }
                else if (key.Key == ConsoleKey.Enter)
                {

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
