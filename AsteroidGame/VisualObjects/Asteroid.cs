using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{

    internal abstract class ImageObject : VisualObject
    {
        private readonly Image _Image;
        protected ImageObject(Point Position, Point Direction, Size Size,Image Image)
         : base(Position, Direction, Size)
        {
            _Image = Image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_Image,_Position.X,_Position.Y,_Size.Width,_Size.Height);
        }
    }

    internal class Asteroid : ImageObject //1:27:08
    {

        //private static readonly Image __Image = Image.FromFile("src\\Ast.png"); 
        private static readonly Image __Image = Properties.Resources.Ast; 

        protected Asteroid(Point Position, Point Direction, int ImageSize) 
             : base(Position, Direction, new Size(ImageSize,ImageSize), __Image)
        {
        }

        public override void Draw(Graphics g)
        {
            ;
        }

    }
}
