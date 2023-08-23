using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace   Snake
{
    class Node
    {
        //תכונות של חוליה אחת
         private int x;
         private int y;
         private Brush col;
         private Node next;

        //פעולה בונה
         public Node(int x, int y, Brush c)
        {
            this.x = x;
            this.y = y;
            this.col = c;
            this.next = null;
        }
        //פעולה בונה
        public Node(Point p, Brush b)
        {
            this.x = p.X;
            this.y = p.Y;
            this.col = b;
        }
        //פעולה המחזירה את X
        public int GetX()
        {
            return this.x;
        }
        //פעולה המחזירה את Y
        public int GetY()
        {
            return this.y;
        }
        //פעולה המחזירה את XוY כנקודה
        public Point GetPoint()
        {
            Point p=new Point(this.x,this.y);
            return p;
        }
        //פעולה המחזירה את החוליה הבאה
        public Node GetNext()
        {
            return this.next;
        }
        //פעולה המחזירה את הצבע
        public Brush GetBrush()
        {
            return this.col;
        }
        //פעולה המעדכנת את X
        public void SetX(int x)
        {
            this.x = x;
        }
        //פעולה המעדכנת את Y
        public void SetY(int y)
        {
            this.y = y;
        }
        //פעולה המעדכנת את הצבע
        public void SetBrush(Brush c)
        {
            this.col = c;
        }
        //פעולה המעדכנת את XוY כנקודה
        public void SetPoint(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
        }
        //פעולה המעדכנת את החוליה הבאה
        public void SetNext(Node next)
        {
            this.next = next;
        }
        //פעולה המציירת את החוליה(בצורת ריבוע)
        public void Draw(Graphics gr)
        {
            gr.FillRectangle(this.col, this.x, this.y, 40, 40);
        }
        //פעולה המציירת את החוליה(בצורת משולש)
        public void DrawFirst(Graphics gr, int type)
        {
            Point[] arr;

            switch (type)
            {
                case 1:
                    arr = new Point[]
                    {
                     new Point(x,y),
                     new Point(x+40,y+20),
                     new Point(x,y+40),
                     new Point(x,y)   
                    };
                    gr.FillPolygon(this.col, arr);
                    break;
                case 2:

                    arr = new Point[]
                    {
                     new Point(x,y),
                     new Point(x+20,y+40),
                     new Point(x+40,y),
                     new Point(x,y)   
                    };
                    gr.FillPolygon(this.col, arr);
                    break;
                case 3:
                    arr = new Point[]
                    {
                     new Point(x+40,y),
                     new Point(x+40,y+40),
                     new Point(x,y+20),
                     new Point(x+40,y)   
                    };
                    gr.FillPolygon(this.col, arr);
                    break;
                case 4:
                    arr = new Point[]
                    {
                     new Point(x,y+40),
                     new Point(x+40,y+40),
                     new Point(x+20,y),
                     new Point(x,y+40)   
                    };
                    gr.FillPolygon(this.col, arr);
                    break;
            }
        }
    }
}
