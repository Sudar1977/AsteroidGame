using AsteroidGame.VisualObjects;
using System;

namespace AsteroidGame
{
    internal class BulletCollisionController
    {
        private readonly IEnemyFactory _AsteroidFactory = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory = new EnemySheepFactory();
        private BulletsList _bullets;

        public BulletCollisionController(BulletsList bullets)
        {
            _bullets = bullets;
        }

        //public void Collision(VisualObject[] _GameObjects, Random _Rnd, BulletsList bullets)
        public void Collision(VisualObject[] _GameObjects, Random _Rnd)
        {
            for (var i = 0; i < _GameObjects.Length; i++)
            {
                var obj = _GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    foreach (var bullet in _bullets.ToArray())
                    {
                        if (bullet.CheckCollision(collision_object))
                        {
                            Game._Counter++;
                            _bullets.Remove(bullet);
                            if (collision_object is Asteroid)
                                _GameObjects[i] = (Asteroid)_AsteroidFactory.Create(_Rnd);
                            if (collision_object is EnemySheep)
                                _GameObjects[i] = (EnemySheep)_EnemyShipFactory.Create(_Rnd);
                            //Console.Beep(250, 100);
                        }
                    }
                }
            }
        }
    }
}
