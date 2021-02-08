using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : VisualObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        public Bullet(int Position) 
            : base(new Point(0,Position), Point.Empty, new Size(__BulletSizeY,__BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(_Position,_Size);
            g.FillEllipse(Brushes.Red,rect);
            g.DrawEllipse(Pens.White, rect);
        }
    }
}
