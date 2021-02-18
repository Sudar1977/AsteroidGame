using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Bullet : ColissionObject
    {
        private const int __BulletSizeX = 20;
        private const int __BulletSizeY = 5;
        private const int __BulletSpeed = 3;


        public Bullet(int Position) 
            : base(new Point(0,Position), Point.Empty, new Size(__BulletSizeX,__BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(_Position,_Size);
            g.FillEllipse(Brushes.Cyan,rect);
            g.DrawEllipse(Pens.White, rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + __BulletSpeed, _Position.Y);
        }
    }
}
