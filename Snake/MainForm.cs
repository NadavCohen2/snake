using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class MainForm : Form
    {
 
        private Graphics gr;
        private int keys = 1;
        private Snake s;
        private int scoren;
        private Snake pos;
        private int rndX;
        private int rndY;
        private Apple pa;
        private Rectangle apple;
        private Rectangle firstS;
        private Node last;
        private bool Lose;
        private bool stop;
        private Loss l;
        private StartForm sf;
        private int mone;

        public MainForm(StartForm sf)
        {
            InitializeComponent();
            this.sf = sf;
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //אתחול משתנים ובניית עצמים
            this.Location = new Point(0, 0);
            s = new Snake();
            stop = false;
            this.BackColor = Color.LightBlue;
            s.Insert(200, 200,Brushes.Green);
                this.Width = 1100;
                this.Height = 900;
                timer1.Enabled = true;
                s.Insert(s.Right40(), Brushes.DarkGreen);
                s.Insert(s.Right40(), Brushes.Red);
                Random rnd = new Random();
                rndX = rnd.Next(2, 20);
                rndY = rnd.Next(2, 20);
                scoren = 0;
                mone = 0;
                Lose = false;
                
                
           
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

            gr = e.Graphics;
            // אובייקט תפוח
            pa = new Apple(rndX, rndY,scoren);
            this.pa.Draw(gr);
            //הכנסה של תפוח למלבלן לצורך בדיקה
            apple = new Rectangle(rndX * 40, rndY * 40 , 40, 40);
            //שכפול הנחש
             pos = s.Dup();
          // ציור הנחש
            while (pos.GetFirst()!=pos.GetLast())
                   {
                       pos.Draw(gr);
                       pos.Remove();
                   }
            pos.DrawFirst(gr, keys);
            pos.Remove();
            //ציור הגבולות
            Pen p = new Pen(Color.Black, 3);
            gr.DrawLine(p, 800, 80, 800, 800);
            gr.DrawLine(p, 80, 80, 80, 800);
            gr.DrawLine(p, 80, 800, 800, 800);
            gr.DrawLine(p, 80, 80, 800, 80);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //בדיקה האם הנחש אכל תפוח
            if (this.apple.IntersectsWith(firstS))
                IfEat();
              
            else
                RegularMove();
            
           
            last = this.s.GetLast();
            this.firstS = new Rectangle(last.GetX(), last.GetY(), 40, 40);
            IfTouchTheWall();
            IfTouchHim();
            //בדיקה האם הפסיד
            if (Lose == true)
            {
                l = new Loss(sf,scoren);
                l.Activate();
                l.Show();
                this.Close();
            }
            Invalidate();
            if (scoren != 3420)
            {
                this.score.Text = "your score: " + scoren;
            }
            else
            {
                l = new Loss(sf, scoren);
                l.Activate();
                l.Show();
                this.Close();
            }

        }
       
        //פעולה לבדיקה על איזה חץ לחץ
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.Right:
                    if (keys != 3)
                        keys = 1;
                    break;
                case Keys.Down:
                    if (keys != 4)
                        keys = 2;
                    break;
                case Keys.Left:
                    if (keys != 1)
                        keys = 3;
                    break;
                case Keys.Up:
                    if (keys != 2)
                        keys = 4;
                    break;
                case Keys.Space:
                    if (!stop)
                    {
                        keys += 10;
                        timer1.Enabled = false;
                        stop = true;
                    }
                    else
                    {
                        keys -= 10;
                        timer1.Enabled = true;
                        stop = false;
                    }

                        break;  
            }
        }
        //פעולה שבודקת האם הוא אכל ואם כן אז היא משנה תתפוח ומזיזה
        public void IfEat()
        {
            Random rnd = new Random();
            rndX = rnd.Next(2, 20);
            rndY = rnd.Next(2, 20);
            while (!AppelOnSnake())
            {
                rndX = rnd.Next(2, 20);
                rndY = rnd.Next(2, 20);
            }
            switch (keys)
            {
                case 1:
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    mone++;
                    s.Insert(s.Right40(), Brushes.Red);
                    scoren += 10;
                    break;
                case 2:
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    mone++;
                    s.Insert(s.Down40(), Brushes.Red);
                    scoren += 10;
                    break;
                case 3:
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    mone++;
                    s.Insert(s.Left40(), Brushes.Red);
                    scoren += 10;
                    break;
                case 4:
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    mone++;
                    s.Insert(s.Up40(), Brushes.Red);
                    scoren += 10;
                    break;
            }
            
        }
        //תזוזה רגילה(אם לא אכל)
        public void RegularMove()
        {
            switch (keys)
            {
                case 1:
                    s.xP40();

                    s.TurnRed();
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    s.Insert(s.Remove());
                    mone++;
                    break;
                case 2:

                    s.yP40();

                    s.TurnRed();
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    s.Insert(s.Remove());
                    mone++;
                    break;
                case 3:
                    s.xM40();
                    s.TurnRed();
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    s.Insert(s.Remove());
                    mone++;
                    break;
                case 4:
                    s.yM40();
                    s.TurnRed();
                    if (mone % 2 == 0)
                        s.TurnGreen();
                    else
                        s.TurnDarkGreen();
                    s.Insert(s.Remove());
                    mone++;
                    break;
                    
                    
            }
        }
        //פעולה שבודקת האם הוא נגע בקיר ואם כן מפסיקה את המשחק
        public void IfTouchTheWall()
        {
            if (this.last.GetX() <= 70 || this.last.GetX() >= 800 || this.last.GetY() <= 70 || this.last.GetY() >= 800)
                Lose = true;
        }
        //פעולה שבודקת האם הוא נגע בעצמו ואם כן מפסיקה את המשחק
        public void IfTouchHim()
        {
            pos = s.Dup();
            while(pos.GetFirst()!=pos.GetLast())
            {
            if (pos.GetFirst().GetPoint() == s.GetLast().GetPoint())
                Lose = true;
            pos.Remove();
            }
           
        }
        //הפעולה בודקת שהתפוח החדש לא יוצא על הנחש 
        public bool AppelOnSnake()
        {
            pos = s.Dup();
            while (!pos.IsEmpty())
            {
                if (pos.GetFirst().GetX() == rndX * 40 && pos.GetFirst().GetY() == rndY * 40)
                    return false;
                pos.Remove();
            }
            return true;
        }
    }
}
