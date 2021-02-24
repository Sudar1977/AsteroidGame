using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class SpaceShip : ImageObject, ICollision
    {
        public event EventHandler Destoyed; //2:10:10

        private int _Energy = 20;
        public int Energy => _Energy;
        public Rectangle Rect => new Rectangle(_Position, _Size);

        private static readonly Image __SpaceShip1 = Properties.Resources.X_Wing; 

        //public SpaceSheep(Point Position, Point Direction, Size Size) : base(Position, Direction, Size)
        //{
        //}

        public SpaceShip(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), __SpaceShip1)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(__SpaceShip1, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update()
        {

        }
        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);
            if(is_collision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }
            return is_collision;
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;
            //if (_Energy < 0)
            //    Destoyed?.Invoke(this,EventArgs.Empty);
        }

        public void MoveUp()
        {
            if (_Position.Y > 0)
                _Position.Y -= _Direction.Y;

        }
        public void MoveDown()
        {
            if(_Position.Y - _Size.Height < Game.Height)
                _Position.Y += _Direction.Y;
        }

        public void MoveBack()
        {
            if (_Position.X > 0)
                _Position.X -= _Direction.X;

        }
        public void MoveForward()
        {
            if (_Position.X - _Size.Width < Game.Width)
                _Position.X += _Direction.X;
        }
        
        public void SetPostion(int X,int Y)
        {
            _Position.X = X;
            _Position.Y = Y;
        }

    }
}
