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

        //private static readonly Image __Image = Properties.Resources.Ast;

        public Object Create(Random Rnd)
        {
            EnemySheep enemy = new EnemySheep(
                        new Point(Rnd.Next(0, Game.Width),Rnd.Next(0, Game.Height)),
                        new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
                        Game.enemy_size);
            return enemy;
        }
    }
}
