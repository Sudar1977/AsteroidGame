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
            Image SheepImage = EnemyShipImage.GetImage(Type);
            this.SetImage(SheepImage);
            _Size.Width = SheepImage.Width / EnemyShipScales.GetScale(Type);
            _Size.Height = SheepImage.Height / EnemyShipScales.GetScale(Type);

        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
