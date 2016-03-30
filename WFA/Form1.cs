using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClockTimer_Tick(null, null);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawEllipse(Pens.Black, 20, 20, this.ClientSize.Width - 40, this.ClientSize.Width - 40);
            label1.Location = new Point(0, this.ClientSize.Width);
            this.Height = 40 + this.ClientSize.Width + label1.Height;
            int p1 = this.ClientSize.Width / 2;
            double angle = DateTime.Now.Second * 6 - 90;
            int p2x = (int)(p1 + Math.Cos((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20));
            int p2y = (int)(p1 + Math.Sin((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20));
            e.Graphics.DrawLine(Pens.Black, p1, p1, p2x, p2y);
            angle = (DateTime.Now.Minute + DateTime.Now.Second / 60f) * 6 - 90;
            p2x = (int)(p1 + Math.Cos((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 40));
            p2y = (int)(p1 + Math.Sin((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 40));
            e.Graphics.DrawLine(Pens.Black, p1, p1, p2x, p2y);
            angle = (DateTime.Now.Hour + DateTime.Now.Minute / 60f + DateTime.Now.Second / 3600f) * 30 - 90;
            p2x = (int)(p1 + Math.Cos((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 60));
            p2y = (int)(p1 + Math.Sin((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 60));
            e.Graphics.DrawLine(Pens.Black, p1, p1, p2x, p2y);
            for (int i = 0; i < 12; i++)
            {
                angle = i * 30 - 90;
                int p1x = (int)(p1 + Math.Cos((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20));
                int p1y = (int)(p1 + Math.Sin((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20));
                p2x = (int)(p1 + Math.Cos((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20 - this.ClientSize.Width / 12));
                p2y = (int)(p1 + Math.Sin((Math.PI / 180.0) * angle) * (this.ClientSize.Width / 2 - 20 - this.ClientSize.Width / 12));
                e.Graphics.DrawLine(Pens.Black, p1x, p1y, p2x, p2y);
            }
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
