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
        public SpaceShipController(SpaceShip SpaceShip)
        {
            _SpaceShip = SpaceShip;
        }

        public  void MouseClick(object sender, MouseEventArgs e)
        {
            _SpaceShip.Fire();
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
                    _SpaceShip.Fire();
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
