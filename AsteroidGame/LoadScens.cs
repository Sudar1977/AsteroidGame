using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AsteroidGame
{
    internal class LoadScens
    {
        private readonly IEnemyFactory _AsteroidFactory = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory = new EnemySheepFactory();
        public VisualObject[] LoadSceneObjects(Random _Rnd)
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            for (var i = 0; i < 100; i++)
            {
                game_objects.Add(
                    new Star(
                        new Point(600, (int)(i / 2.0 * 20)),
                        new Point(-i, 0),
                        2));
            }
            for (var i = 0; i < Game.asteroid_count; i++)
            {
                game_objects.Add((Asteroid)_AsteroidFactory.Create(_Rnd));
            }
            for (var i = 0; i < Game.enemy_count; i++)
            {
                //game_objects.Add((EnemySheep)_EnemyShipFactory.CreateType(_Rnd,EnemyShipTypes.Bomber));
                game_objects.Add((EnemySheep)_EnemyShipFactory.Create(_Rnd));
            }
            game_objects.Add(new Asteroid(new Point(Game.Width / 2, 200), new Point(-Game.asteroid_max_speed, 0), Game.asteroid_size));
            return game_objects.ToArray();
        }
    }


}
