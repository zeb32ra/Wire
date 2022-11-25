
namespace Wire
{
    public class Main
    {
        static string path;
        static List<string> disks = new List<string>();
        public static string elem_name;

        public void programm()
        {
            int[] positions_in_window;
            int position = 2;
            bool we_are_in_main = true;
            string name;
            positions_in_window = Wire.ShowDisks(we_are_in_main, path);
            while (true)
            {
                disks = Wire.Get_Path(we_are_in_main, path);
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
                    we_are_in_main = true;
                    path = "";
                    position = 2;
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    if (we_are_in_main)
                    {
                        path += disks[position - 2];
                        Console.Clear();
                        we_are_in_main = false;
                        position = 2;
                        positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                    }
                    else
                    {
                        path = disks[position - 2];
                        if (System.IO.Path.GetExtension(path).Length > 0)
                        { 
                            Wire.Start_a_File(path);
                            path = path.Substring(0, path.LastIndexOf('\\'));                          
                            positions_in_window =  Wire.ShowDisks(we_are_in_main, path);
                        }
                        else
                        {
                            Console.Clear();
                            position = 2;
                            positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                        }
                    }
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a name of the Directory");
                    name = Console.ReadLine();
                    Wire.Create_Directory(path, name);
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter a name of the file");
                    name = Console.ReadLine();
                    Wire.Create_a_File(path, name);
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    path = disks[position - 2];
                    Wire.Delete(path);
                    int slesh_pos = path.LastIndexOf('\\') + 1;
                    path = path.Substring(0, slesh_pos);
                    positions_in_window = Wire.ShowDisks(we_are_in_main, path);
                }

            }
        }
    }
}
