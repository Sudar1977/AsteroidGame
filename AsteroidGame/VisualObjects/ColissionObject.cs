using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal abstract class ColissionObject : VisualObject, ICollision
    {
        public ColissionObject(Point Position, Point Direction, Size Size) 
            : base(Position, Direction, Size)
        {
        }

        public Rectangle Rect => new Rectangle(_Direction,_Size);
        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
