using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Apple
    {
        //תכונות של התפוח
        private Body B;
        private Leaves L;
        private int X;
        private int Y;
        private int mone;
        private Brush color;
        //פעולה בונה
         public Apple (int x, int y,int mone)
        {
            this.X = x;
            this.Y = y;
            this.mone = mone / 10;
            if (this.mone % 3 == 0)
                color = Brushes.GreenYellow;
            else

                if (this.mone % 3 == 1)
                    color = Brushes.Red;
                else
                    color = Brushes.Yellow;
            B = new Body(x * 40, y * 40, color);
            L = new Leaves(x * 40, y * 40);
        }
        //פעולה שמציירת את התפוח
        public void Draw(Graphics gr)
        {
            B.Draw(gr);
            L.Draw(gr);
        }
    }


}
