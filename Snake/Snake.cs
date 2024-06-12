using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Snake
{
    class Snake
    {
        //תכונות של הנחש
        private Node first;
        private Node last;
        private int location;
        //פעולה בונה
        public Snake()
        {
            this.first = null;
            this.last = null;
            location = 1;

        }
        //פעולה הבונה נחש חדש זהה
        public Snake Dup()
        {
            Snake q1 = new Snake();
            Node pos = this.first;
            while (pos != null)
            {
                
                q1.Insert(pos.GetPoint(),pos.GetBrush());
                pos = pos.GetNext();
            }
            return q1;
        }
        //הפעולה בודקת אם הנחש ריק
        public bool IsEmpty()
        {
            return this.first == null;
        }
        // פעולה המכניסה חוליה חדש 
        public void Insert(int x,int y,Brush b)
        {
            if (this.first == null)
            {
                this.first = new Node(x, y, b);
                this.last = this.first;
            }
            else
            {
                Node temp = new Node(x, y, b);
                this.last.SetNext(temp);
                this.last = temp;
            }
        }
        // פעולה המכניסה חוליה חדש 
        public void Insert(Point p,Brush b)
        {
            if (this.first == null)
            {
                this.first = new Node(p,b);
                this.last = this.first;
            }
            else
            {
                Node temp = new Node(p,b);
                this.last.SetNext(temp);
                this.last = temp;
            }
        }
        // פעולה המכניסה חוליה חדש 
        public void Insert(Node x)
        {
             Brush b;
             if (location % 2 == 0)
                 b = Brushes.Green;
             else
                 b = Brushes.DarkGreen;
             this.location++;
            if (this.first == null)
            {
                this.first = x;
                
                this.last = this.first;
            }
            else
            {
                this.last.SetNext(x);
                this.last = x;
            }
            this.first.SetBrush(b);
           
        }
        // פעולה מוחקת את חוליה הראשונה 
        public Node Remove()
        {
           
            if (this.first == this.last)
                this.last = null;
            Node x = this.first;
            this.first = this.first.GetNext();
          
            x.SetNext(null);
            
            return x;
        }
        // פעולה מחזירה את החוליה הראשונה 
        public Node Head()
        {
            return this.first;
        }
        //הפעולה מחזירה את הצבע של החוליה הראשונה
        public Brush GetBrush()
        {
            return this.first.GetBrush();
        }
        //הפעולה מעדכנת את הצבע של החוליה הראשונה לאדום
        public void TurnRed()
        {
            this.first.SetBrush(Brushes.Red);
        }
        //הפעולה מעדכנת את הצבע של החוליה האחרונה לירוק
        public void TurnGreen()
        {
            this.last.SetBrush(Brushes.Green);
        }
        //הפעולה מעדכנת את הצבע של החוליה האחרונה לירוק כהה
        public void TurnDarkGreen()
        {
            this.last.SetBrush(Brushes.DarkGreen);
        }
        //הפעולה מזיזה את החוליה הראשונה להיות אחרונה לכיוון שמאל 
        public void xP40()
        {
            this.first.SetX(this.last.GetX() + 40);
            this.first.SetY(this.last.GetY());
        }
        //הפעולה מזיזה את החוליה הראשונה להיות אחרונה לכיוון ימין 
        public void xM40()
        {
            this.first.SetX(this.last.GetX() - 40);
            this.first.SetY(this.last.GetY());
        }
        //הפעולה מזיזה את החוליה הראשונה להיות אחרונה  למטה 
        public void yP40()
        {
            this.first.SetX(this.last.GetX());
            this.first.SetY(this.last.GetY() + 40);
        }
        //הפעולה מזיזה את החוליה הראשונה להיות אחרונה  למעלה 
        public void yM40()
        {
            this.first.SetX(this.last.GetX());
            this.first.SetY(this.last.GetY() - 40);
        }
        //הפעולה בונה נקודה חדשה ימינה מהחוליה האחרונה
        public Point Right40()
        {
            return new Point(this.last.GetX() + 40, this.last.GetY());
        }
        //הפעולה בונה נקודה חדשה שמאלה מהחוליה האחרונה
        public Point Left40()
        {
            return new Point(this.last.GetX() - 40, this.last.GetY());
        }
        //הפעולה בונה נקודה חדשה למעלה מהחוליה האחרונה
        public Point Up40()
        {
            return new Point(this.last.GetX(), this.last.GetY() - 40);
        }
        //הפעולה בונה נקודה חדשה למטה מהחוליה האחרונה
        public Point Down40()
        {
            return new Point(this.last.GetX(), this.last.GetY() + 40);
        }

        //הפעולה מחזירה את החוליה הראשונה
        public Node GetFirst()
        {
            return this.first;
        }
        //הפעולה מחזירה את החוליה האחרונה
        public Node GetLast()
        {
            return this.last;
        }
       
        //הפעולה מציירת את החוליה הראשונה(בצורת ריבוע)
        public void Draw(Graphics gr)
        {
            this.first.Draw(gr);
        }
        //הפעולה מציירת את החוליה הראשונה(בצורת משולש)
        public void DrawFirst(Graphics gr,int type)
        {
            this.first.DrawFirst(gr, type);
        }
    }
}
