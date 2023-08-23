using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Loss : Form
    {
        private StartForm s;
        private MainForm m;
        private Button so;
        private Button co;
        private int score;

        public Loss(StartForm sf, int score)
        {
            InitializeComponent();
            this.s = sf;
            this.score = score;
        }

        private void Loss_Load(object sender, EventArgs e)
        {
            this.Width = 300;
            this.Height = 200;
            // בניית כפתור התחל מחדש
            so = new Button();
            so.Width = 100;
            so.Height = 50;
            this.Controls.Add(so);
            so.Click += so_Click;
            so.Location = new Point(20, 80);
            so.Text = "התחל מחדש";
            //בניית כפתור סגור
            co = new Button();
            co.Width = 100;
            co.Height = 50;
            this.Controls.Add(co);
            co.Click += co_Click;
            co.Location = new Point(160, 80);
            co.Text = "סגור";
            scored.Text = "הניקוד השלך הוא: " + score;
        }
        //פעולה סוגרת את המשחק
        void co_Click(object sender, EventArgs e)
        {
            s.Close();
        }
        //פעולה מתחילה את המשחק מחדש
        void so_Click(object sender, EventArgs e)
        {
            m = new MainForm(s);
            m.Activate();
            m.Show();
            this.Close();
        }
    }
}
