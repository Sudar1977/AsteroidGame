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

        private static readonly Image __Image = Properties.Resources.Ast;

        public Object Create(Random Rnd)
        {
            throw new NotImplementedException();
        }

        //public Asteroid Create2(Random Rnd)
        //{
        //    Asteroid enemy = new Asteroid(
        //                        new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
        //                        new Point(-Rnd.Next(0, Game.asteroid_max_speed), 0),
        //                        Game.asteroid_size);
        //    return enemy;
        //}
        //class EnemySheep Create(Random Rnd)
        //{
        //    EnemySheep enemy = new EnemySheep(
        //                        new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
        //                        new Point(-Rnd.Next(0, Game.asteroid_max_speed), 0),
        //                        Game.asteroid_size);

        //    return enemy;
        //}
    }
}
