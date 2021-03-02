using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal class LoadScens
    {

        private int asteroid_count  = 10;
        private int enemy_count     = 10;
        private int star_count      = 100;
  
        private readonly IEnemyFactory _AsteroidFactory;// = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory;// = new EnemySheepFactory();

        public LoadScens(IEnemyFactory asteroidFactory, IEnemyFactory enemyShipFactory)
        {
            _AsteroidFactory = asteroidFactory;
            _EnemyShipFactory = enemyShipFactory;
        }

        public VisualObject[] LoadSceneObjects(Random _Rnd,int Number,SpaceShip ship)
        {
            switch(Number)
            {
                case 0:
                    asteroid_count = 50;
                    enemy_count = 0;
                    ship.ChangeType(SpaceShipTypes.SnowSpeeder);
                    break;
                case 1:
                    asteroid_count = 30;
                    enemy_count = 10;
                    Game.__EnemyShipType = EnemyShipTypes.Tie;
                    ship.ChangeType(SpaceShipTypes.X_Wing);
                    break;
                case 2:
                    asteroid_count = 25;
                    enemy_count = 10;
                    Game.__EnemyShipType = EnemyShipTypes.Bomber;
                    ship.ChangeType(SpaceShipTypes.RebelSheep);
                    break;
                case 3:
                    asteroid_count = 25;
                    enemy_count = 10;
                    Game.__EnemyShipType = EnemyShipTypes.BomberRot;
                    ship.ChangeType(SpaceShipTypes.RebelSheep);
                    break;
                case 4:
                    asteroid_count = 35;
                    enemy_count = 1;
                    Game.__EnemyShipType = EnemyShipTypes.StarDestroyerDown;
                    ship.ChangeType(SpaceShipTypes.Falcon);
                    break;
            }
            return LoadSceneObjects(_Rnd);
        }


        public VisualObject[] LoadSceneObjects(Random _Rnd)
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            for (var i = 0; i < star_count; i++)
            {
                game_objects.Add(
                    new Star(
                        new Point(600, (int)(i / 2.0 * 20)),
                        new Point(-i, 0),
                        2));
            }
            for (var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add((Asteroid)_AsteroidFactory.Create(_Rnd));
            }
            for (var i = 0; i < enemy_count; i++)
            {
                //game_objects.Add((EnemySheep)_EnemyShipFactory.CreateType(_Rnd,EnemyShipTypes.Bomber));
                game_objects.Add((EnemySheep)_EnemyShipFactory.Create(_Rnd));
            }
            game_objects.Add(new Asteroid(new Point(Game.Width / 2, 200), new Point(-Game.asteroid_max_speed, 0), Game.asteroid_size));
            return game_objects.ToArray();
        }
    }

    internal class LoadScensController
    {
        private LoadScens _LoadScens;

        public LoadScensController(LoadScens loadScens)
        {
            _LoadScens = loadScens;
        }


    }
}
