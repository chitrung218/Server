using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Monitoring : UserControl
    {
        public Monitoring()
        {
            InitializeComponent();
        }

        private void Monitoring_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            //formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 60, 60));
            formGraphics.DrawEllipse(Pens.Red, new Rectangle(0, 0, 30, 30));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
        public void AddEventIntoPaint()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Monitoring_Paint);
        }
        public void DrawIt()
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                50, 100, 150, 150);
            graphics.DrawEllipse(System.Drawing.Pens.Red, rectangle);
            //graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        }
    }
}
