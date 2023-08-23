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
    public partial class StartForm : Form
    {
        private Button b;
        private MainForm m;
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            //בנייה של כפתור התחל
            b = new Button();
            b.Width = 150;
            b.Height = 50;
            this.Controls.Add(b);
            b.Click += b_Click;
            this.Width = 300;
            this.Height = 200;
            b.Location = new Point(70, 50);
            b.Text = "התחל";
        }
        //פעולה המתחילה את המחשק
        void b_Click(object sender, EventArgs e)
        {
            m = new MainForm(this);
            m.Activate();
            m.Show();
            this.Visible = false;

        }
    }
}
