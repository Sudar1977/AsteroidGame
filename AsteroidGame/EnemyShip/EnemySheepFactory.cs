using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    internal class EnemySheepFactory : IEnemyFactory
    {
        //Будем масштабировать размеры по изрображению
        //private static readonly Image __Image = Properties.Resources.Ast;
        //private static readonly Image __Image = Properties.Resources.Ast;

        public Object Create(Random Rnd)
        {
            EnemySheep enemy = new EnemySheep(
                        new Point(Rnd.Next(0, Game.Width),Rnd.Next(0, Game.Height)),
                        new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
                        Game.enemy_size,EnemyShipTypes.Tie);
                        //Game.enemy_size,EnemyShipTypes.BomberRot);
                        //Game.enemy_size,EnemyShipTypes.StarDestroyerRebel);
                        //Game.enemy_size,EnemyShipTypes.StarDestroyerLeft);
                        //Game.enemy_size,EnemyShipTypes.StarDestroyerDown);
            return enemy;
        }
        public Object CreateType(Random Rnd,EnemyShipTypes Type)
        {
            EnemySheep enemy = new EnemySheep(
                        new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
                        new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
                        Game.enemy_size, Type);
            return enemy;
        }
    }
}
