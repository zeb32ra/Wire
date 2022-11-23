using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Wire
{
    static class Wire
    {
        public static int[] ShowDisks()
        {
            /*Console.SetCursorPosition(10, 0);*/
            Console.WriteLine("This Computer");
            Console.WriteLine("-----------------------------------------------");
            int string_count = 2;
            DriveInfo[] drives = DriveInfo.GetDrives();
            int i = 2;
            int available_pos = 0;
            foreach (DriveInfo drive in drives)
            {
                Console.SetCursorPosition(2, i);
                Console.WriteLine(drive.Name + " " + drive.AvailableFreeSpace / (1024 * 1024 * 1024) + " GB from " + drive.TotalSize / (1024 * 1024 *1024) + " GB");
                i++;
                available_pos++;
            }
            int[] rows_in_window = {available_pos + string_count, string_count};
            return rows_in_window;
        }
    }
}
