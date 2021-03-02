﻿using AsteroidGame.VisualObjects;
using System;

namespace AsteroidGame
{
    internal class SpaceShipCollisionController
    {
        private readonly IEnemyFactory _AsteroidFactory;// = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory;// = new EnemySheepFactory();
        private readonly SpaceShip _SpaceShip;

        public SpaceShipCollisionController(SpaceShip spaceShip, IEnemyFactory asteroidFactory, IEnemyFactory enemyShipFactory)
        {
            _AsteroidFactory = asteroidFactory;
            _EnemyShipFactory = enemyShipFactory;
            _SpaceShip = spaceShip;
        }

        public void Collision(VisualObject[] _GameObjects, Random _Rnd)
        {
            for (var i = 0; i < _GameObjects.Length; i++)
            {
                var obj = _GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if (_SpaceShip.CheckCollision(collision_object))
                    {
                        //            if(is_collision && obj is Asteroid asteroid)
                        if (collision_object is Asteroid asteroid)
                        {
                            _GameObjects[i] = (Asteroid)_AsteroidFactory.Create(_Rnd);
                            _SpaceShip.ChangeEnergy(-asteroid.Power);
                        }
                        if (collision_object is EnemySheep enemy)
                        {
                            _GameObjects[i] = (EnemySheep)_EnemyShipFactory.Create(_Rnd);
                            _SpaceShip.ChangeEnergy(-enemy.Power);
                        }
                    }
                }
            }
        }

    }

}
