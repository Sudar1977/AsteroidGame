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
        private Game _Game;

        //public EnemySheepFactory(Game game)
        //{
        //    _Game = game;
        //}

        public Object Create(Random Rnd)
        {
            EnemySheep enemy = new EnemySheep(
                        new Point(Rnd.Next(0, Game.Width),Rnd.Next(0, Game.Height)),
                        new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
                        Game.enemy_size,Game.__EnemyShipType);
            return enemy;
        }
        //public Object CreateType(Random Rnd,EnemyShipTypes Type)
        //{
        //    EnemySheep enemy = new EnemySheep(
        //                new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
        //                new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
        //                Game.enemy_size, Type);
        //    return enemy;
        //}
        //public Object Create(Random Rnd, EnemyShipTypes Type)
        //{
        //    EnemySheep enemy = new EnemySheep(
        //                new Point(Rnd.Next(0, Game.Width), Rnd.Next(0, Game.Height)),
        //                new Point(Rnd.Next(0, Game.enemy_max_speed), 0),
        //                Game.enemy_size, Type);
        //    return enemy;
        //}

    }
}
