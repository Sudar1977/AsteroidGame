using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    class AsteroidFactory : IEnemyFactory
    {
        //public Random Rnd => new Random();

        private static readonly Image __Image = Properties.Resources.Ast;

        public Asteroid Create(Random Rnd)
        {
            Asteroid enemy = new Asteroid(
                                new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
                                new Point(-Rnd.Next(0, Game.asteroid_max_speed), 0),
                                Game.asteroid_size);
            return enemy;
        }
    }
}
