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
        public event EventHandler Destoyed; 
        public event Action<int, int> BulletShoot; 
        private const int MaxEnergy = 100;
        private SpaceShipTypes _Type = SpaceShipTypes.X_Wing;
        public SpaceShipTypes Type => _Type;

        private int _Energy = MaxEnergy;
        public int Energy => _Energy;
        public Rectangle Rect => new Rectangle(_Position, _Size);

        private static readonly Image _SpaceShip = Properties.Resources.X_Wing; 
        //private static readonly Image _SpaceShip = Properties.Resources.Falcon;// .X_Wing; 
        //private static readonly Image _SpaceShip = Properties.Resources.RebelSheep;// .X_Wing; 
        //private static readonly Image _SpaceShip = Properties.Resources.SnowSpeeder;// .X_Wing; 
        private static int _Scale = 6;
        private static int _Widh = _SpaceShip.Width / _Scale;
        private static int _Height = _SpaceShip.Height / _Scale;

        public SpaceShip(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), _SpaceShip)
        {
        }

        public SpaceShip(Point Position, Point Direction)
            : base(Position, Direction, new Size(_Widh, _Height), _SpaceShip)
        {
        }

        public SpaceShip(Point Position, Point Direction,SpaceShipTypes Type)
            : base(Position, Direction, new Size(_Widh, _Height), _SpaceShip)
        {
            ChangeType(Type);
        }

        public void ChangeType(SpaceShipTypes Type)
        {
            Image SheepImage = SpaceShipImage.GetImage(Type);
            this.SetImage(SheepImage);
            _Size.Width = SheepImage.Width / SpaceShipScales.GetScale(Type);
            _Size.Height = SheepImage.Height / SpaceShipScales.GetScale(Type);
            _Type = Type;
        }

        public bool CheckCollision(ICollision obj)
        {
            return Rect.IntersectsWith(obj.Rect);
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;
            if (_Energy < 0)
                Destoyed?.Invoke(this,EventArgs.Empty);
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

        public void EnergyRestore()
        {
            _Energy = MaxEnergy;
        }

        public void Fire()
        {
            BulletShoot?.Invoke(_Position.X + _Size.Width, 
                                _Position.Y + _Size.Height/2 +5);
        }

    }
}
