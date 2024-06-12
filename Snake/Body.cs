using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Snake
{
    class Body
    {
        //תוכונות של גוף התפוח
        private int X;
        private int Y;
        private Brush color;
        // פעולה בונה
        public Body(int x, int y, Brush b)
        {
            this.X = x;
            this.Y = y;
            this.color = b;
        }
        //פעוךה שמציירת את הגוף
        public void Draw(Graphics gr)
        {
            gr.FillEllipse(color, new Rectangle(this.X , this.Y + 10, 40, 30));
        }
    }
   
}
