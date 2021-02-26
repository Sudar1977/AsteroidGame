using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    class SpaceShipController
    {
        private readonly SpaceShip _SpaceShip;
        private Rectangle _ShipRect;

        public SpaceShipController(SpaceShip SpaceShip)
        {
            _SpaceShip = SpaceShip;
            _ShipRect  = SpaceShip.Rect;
        }

        public  void MouseClick(object sender, MouseEventArgs e)
        {
            Game.__Bullets.Add(new Bullet(_ShipRect.X + _ShipRect.Width, 
                                          _ShipRect.Y + _ShipRect.Height / 2));
        }

        public  void MouseEvent(object sender, MouseEventArgs e)
        {
            _SpaceShip.SetPostion(Cursor.Position.X, Cursor.Position.Y);
        }

        public  void OnFormKeyDown(object Sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Space:
                    Game.__Bullets.Add(new Bullet(_ShipRect.X + _ShipRect.Width,
                                                  _ShipRect.Y + _ShipRect.Height / 2));
                    //Console.Beep(300, 50);
                    break;

                case Keys.Up:
                case Keys.W:
                    _SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                case Keys.S:
                    _SpaceShip.MoveDown();
                    break;

                case Keys.Right:
                case Keys.D:
                    _SpaceShip.MoveForward();
                    break;

                case Keys.Left:
                case Keys.A:
                    _SpaceShip.MoveBack();
                    break;
            }
        }
    }
}
