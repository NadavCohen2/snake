using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Leaves
    {
        //תכונות של הגבעול
        private int X;
        private int Y;

        private Pen color;
        //פעולה בונה
         public Leaves (int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.color = new Pen(Brushes.Brown, 3);
        }
        //פעולה שמציירת את התפוח
        public void Draw(Graphics gr)
        {
            if (X /40 % 2 == 0)
                gr.DrawLine(color, X + 20, Y + 10, X + 25, Y);
            else
                gr.DrawLine(color, X + 20, Y + 10, X + 15, Y);
        }
    }
}
