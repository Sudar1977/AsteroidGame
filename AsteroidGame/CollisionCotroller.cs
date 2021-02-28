﻿using AsteroidGame.VisualObjects;
using System;

namespace AsteroidGame
{
    internal class CollisionCotroller
    {
        private readonly IEnemyFactory _AsteroidFactory = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory = new EnemySheepFactory();

        public CollisionCotroller()
        {

        }
        public void CollisionVisualObjects(VisualObject[] _GameObjects, Random _Rnd)
        {
            for (var i = 0; i < _GameObjects.Length; i++)
            {
                var obj = _GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (Game.__SpaceShip.CheckCollision(collision_object))
                    {
                        //            if(is_collision && obj is Asteroid asteroid)
                        if (collision_object is Asteroid asteroid)
                        {
                            _GameObjects[i] = (Asteroid)_AsteroidFactory.Create(_Rnd);
                            Game.__SpaceShip.ChangeEnergy(-asteroid.Power);
                        }
                    }
                }
            }
        }
    }
}
