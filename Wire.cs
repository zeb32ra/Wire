
using System.Diagnostics;

namespace Wire
{
    static class Wire
    {
        public static int[] ShowDisks(bool main_or_not, string path="C:\\")
        {
            if (main_or_not)
            {
                Console.WriteLine("TThis Computer");
                Console.WriteLine("----------------------------------------------");
                int string_count = 2;
                DriveInfo[] drives = DriveInfo.GetDrives();
                int i = 2;
                int available_pos = 0;

                foreach (DriveInfo drive in drives)
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine(drive.Name + " " + drive.AvailableFreeSpace / (1024 * 1024 * 1024) + " GB from " + drive.TotalSize / (1024 * 1024 * 1024) + " GB");
                    i++;
                    available_pos++;
                }
                int[] rows_in_window = { available_pos + string_count, string_count };
                return rows_in_window;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("F1 - Create a directory, F2 - Create a file, F3 - Delete");
                Console.WriteLine("----------------------------------------------------------");
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);
                
                List<string> content = new List<string>();
                int string_count = 2;
                int available_pos = 0;
                
                foreach (string folder in folders)
                {
                    content.Add(folder.Substring(folder.LastIndexOf('\\') + 1));
                    available_pos++;
                }
                foreach (string file in files)
                {
                    content.Add(file.Substring(file.LastIndexOf('\\') + 1));
                    available_pos++;
                }
                int i = 2;
                int max = 0;
                foreach (string el in content)
                {
                    if (el.Length > max)
                    {
                        max = el.Length;
                    }
                }
                foreach (string elem in content)
                {
                    Console.SetCursorPosition(2, i);
                    Console.WriteLine(elem);
                    Console.SetCursorPosition(max + 10, i);
                    Console.WriteLine(Directory.GetCreationTime(elem));
                    Console.SetCursorPosition((max + 10) + 30, i);
                    Console.WriteLine(System.IO.Path.GetExtension(elem));
                    i++;
                }
                
                int[] rows = { available_pos + string_count, string_count };
                return rows;
            }
            
        }

        public static List<string> Get_Path(bool main_or_not, string path="C:\\")
        {
            if (main_or_not)
            {
                List<string> paths = new List<string>();
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    paths.Add(drive.Name);
                }
                return paths;
            }
            else
            {
                List<string> paths = new List<string>();
                string[] files = Directory.GetFiles(path);
                string[] folders = Directory.GetDirectories(path);

                foreach (string folder in folders)
                {
                    paths.Add(folder);
                }
                foreach (string file in files)
                {
                    paths.Add(file);
                }
                return paths;
            }
        }
        public static void Create_Directory(string path, string name)
        {
            Directory.CreateDirectory(path + "\\" + name);
        }
        public static void Create_a_File(string path, string name)
        {
            File.Create(path + "\\" + name);  
        }
        public static void Delete(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            else if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public static void Start_a_File(string path)
        {
            Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
        }

    }
}
