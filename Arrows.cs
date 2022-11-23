using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wire
{
    public class Arrows
    {
        int min;
        int max;
        int position;
        public Arrows(int Pmin, int Pmax)
        {
            min = Pmin;
            max = Pmax;
        }
        public int Up(Arrows arrow, int cur_pos=2)
        {
            if (cur_pos <= arrow.min)
            {
                cur_pos += 1;
                Clear_An_Arrow(cur_pos);
                Draw_An_Arrow(cur_pos);
            }
            else
            {
                Clear_An_Arrow(cur_pos + 1);
                Draw_An_Arrow(cur_pos);
            }
            return cur_pos;
        }
        public int Down(Arrows arrow, int cur_pos=2)
        {
            if (cur_pos > arrow.max)
            {
                cur_pos -= 1;
                Clear_An_Arrow(cur_pos);
                Draw_An_Arrow(cur_pos);
            }
            else
            {
                Clear_An_Arrow(cur_pos - 1);
                Draw_An_Arrow(cur_pos);
            }
            return cur_pos;
        }
        private void Draw_An_Arrow(int cur_pos)
        {
            Console.SetCursorPosition(0, cur_pos);
            Console.WriteLine("->");
            Console.SetCursorPosition(0, cur_pos);
        }
        private void Clear_An_Arrow(int cur_pos)
        {
            Console.SetCursorPosition(0, cur_pos);
            Console.WriteLine("  ");
            Console.SetCursorPosition(0, cur_pos);
        }
    }
}
