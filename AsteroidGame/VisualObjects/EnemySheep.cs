using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class EnemySheep : ImageObject, ICollision
    {
        private static readonly Image __Image = Properties.Resources.Tie;
        public EnemySheep(Point Position, Point Direction, int ImageSize)
         : base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
        {
        }
        public EnemySheep(Point Position, Point Direction, int ImageSize, EnemyShipTypes Type)
         : base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
        {
            switch (Type)
            {
                case EnemyShipTypes.Tie:
                    this.SetImage(Properties.Resources.Tie);
                    break;
                case EnemyShipTypes.Bomber:
                    this.SetImage(Properties.Resources.Bomber);
                    break;
                case EnemyShipTypes.BomberRot:
                    this.SetImage(Properties.Resources.Bomber2);
                    break;
                case EnemyShipTypes.StarDestroyerRebel:
                    this.SetImage(Properties.Resources.StarDestroyer3);
                    break;

            }
        }


        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
