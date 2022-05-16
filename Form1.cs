using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bouncing_ball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        Vector2 translation = new Vector2(3,3);
        Vector2 ballLocation= new Vector2(0,0);
        private readonly int ballWidth = 100;
        private readonly int ballHeight = 100;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.BackColor);
            e.Graphics.FillEllipse(Brushes.BlanchedAlmond, ballLocation.X, ballLocation.Y, ballWidth, ballHeight);
            e.Graphics.DrawEllipse(Pens.Black, ballLocation.X,  ballLocation.Y, ballWidth, ballHeight);
        }

        private void MoveBall(object sender, EventArgs e)
        {
            // update coordinates
            ballLocation += translation;
            if( ballLocation.X< 0 || ballLocation.X+ballWidth > this.ClientSize.Width)
            {
                translation.X = -translation.X;
            }

            if (ballLocation.Y < 0 || ballLocation.Y + ballHeight > this.ClientSize.Height)
            {
                translation.Y= -translation.Y;
            }
            // update painting
            this.Refresh();
        }
    }
}
