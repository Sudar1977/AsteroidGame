using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{

    internal class Asteroid : ImageObject //1:27:08
    {

        //private static readonly Image __Image = Image.FromFile("src\\Ast.png"); 
        private static readonly Image __Image = Properties.Resources.Ast; 

        public Asteroid(Point Position, Point Direction, int ImageSize) 
             : base(Position, Direction, new Size(ImageSize,ImageSize), __Image)
        {
        }
    }
}
