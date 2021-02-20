using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    class SpaceShipController
    {
        public static void mouseClick(object sender, MouseEventArgs e)
        {
            Game.__Bullets.Add(new Bullet(Game.__SpaceShip.Rect.X + Game.__SpaceShip.Rect.Width, 
                                          Game.__SpaceShip.Rect.Y + Game.__SpaceShip.Rect.Height / 2));
        }

        public static void mouseEvent(object sender, MouseEventArgs e)
        {
            Game.__SpaceShip.SetPostion(Cursor.Position.X, Cursor.Position.Y);
        }

        public static void OnFormKeyDown(object Sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Space:
                    Game.__Bullets.Add(new Bullet(Game.__SpaceShip.Rect.X + Game.__SpaceShip.Rect.Width,
                                                  Game.__SpaceShip.Rect.Y + Game.__SpaceShip.Rect.Height / 2));
                    //Console.Beep(300, 50);
                    break;

                case Keys.Up:
                case Keys.W:
                    Game.__SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                case Keys.S:
                    Game.__SpaceShip.MoveDown();
                    break;

                case Keys.Right:
                case Keys.D:
                    Game.__SpaceShip.MoveForward();
                    break;

                case Keys.Left:
                case Keys.A:
                    Game.__SpaceShip.MoveBack();
                    break;
            }
        }


    }
}
