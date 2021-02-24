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
            Image SheepImage = Properties.Resources.Tie;
            switch (Type)
            {
                case EnemyShipTypes.Tie:
                    SheepImage = Properties.Resources.Tie;
                    break;
                case EnemyShipTypes.Bomber:
                    SheepImage = Properties.Resources.Bomber;
                    break;
                case EnemyShipTypes.BomberRot:
                    SheepImage = Properties.Resources.Bomber2;
                    break;
                case EnemyShipTypes.StarDestroyerRebel:
                    SheepImage = Properties.Resources.StarDestroyer3;
                    break;
            }
            this.SetImage(SheepImage);
            _Size.Width = SheepImage.Width / EnemyShipScales.GetScale(Type);
            _Size.Height = SheepImage.Height / EnemyShipScales.GetScale(Type);

        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }

    internal class EnemyShipScales
    {
        public static int GetScale(EnemyShipTypes Type)
        {
            int Scale = 1;
            switch (Type)
            {
                case EnemyShipTypes.Tie:
                    Scale = 3;
                    break;
                case EnemyShipTypes.Bomber:
                    Scale = 3;
                    break;
                case EnemyShipTypes.BomberRot:
                    Scale = 3;
                    break;
                case EnemyShipTypes.StarDestroyerRebel:
                    Scale = 2;
                    break;
            }
            return Scale;
        }

    }
}
