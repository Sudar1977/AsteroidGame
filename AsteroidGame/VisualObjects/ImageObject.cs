using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal abstract class ImageObject : VisualObject
    {
        private Image _Image;
        protected ImageObject(Point Position, Point Direction, Size Size,Image Image)
         : base(Position, Direction, Size)
        {
            _Image = Image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_Image,_Position.X,_Position.Y,_Size.Width,_Size.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;
            if ((_Position.X< 0)||(_Position.X > Game.Width))
                _Direction.X *= -1;
            if ((_Position.Y< 0) || (_Position.Y > Game.Height))
                _Direction.Y *= -1;
        }

        public void SetImage(Image image)
        {
            _Image = image;
        }
    }
}
