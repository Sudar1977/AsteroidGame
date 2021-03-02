using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    internal class LoadScens
    {

        private int asteroid_count = 10;
        private int enemy_count = 10;
        private int star_count = 100;

        private readonly IEnemyFactory _AsteroidFactory;// = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory;// = new EnemySheepFactory();

        public LoadScens(IEnemyFactory asteroidFactory, IEnemyFactory enemyShipFactory)
        {
            _AsteroidFactory = asteroidFactory;
            _EnemyShipFactory = enemyShipFactory;
        }

        private void ConcatLists(List<VisualObject> newfile, List<VisualObject> listfiles)
        {
            for (int i = 0; i < newfile.Count; i++)
            {
                listfiles.Add(newfile[i]);
            }
        }

        public VisualObject[] LoadSceneObjects(Random _Rnd, int Number, SpaceShip ship)
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            ConcatLists(LoadSceneObjectsListStars(_Rnd), game_objects);
            switch (Number)
            {
                case 0:
                    asteroid_count = 50;
                    enemy_count = 0;
                    Game.__EnemyShipType = EnemyShipTypes.Tie;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.SnowSpeeder);
                    break;
                case 1:
                    asteroid_count = 30;
                    enemy_count = 10;
                    Game.__EnemyShipType = EnemyShipTypes.Tie;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.X_Wing);
                    break;
                case 2:
                    asteroid_count = 10;
                    enemy_count = 10;
                    Game.__EnemyShipType = EnemyShipTypes.Tie;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    enemy_count = 5;
                    Game.__EnemyShipType = EnemyShipTypes.Bomber;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.RebelSheep);
                    break;
                case 3:
                    asteroid_count = 10;
                    enemy_count = 7;
                    Game.__EnemyShipType = EnemyShipTypes.Tie;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    enemy_count = 5;
                    Game.__EnemyShipType = EnemyShipTypes.Bomber;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    enemy_count = 3;
                    Game.__EnemyShipType = EnemyShipTypes.BomberRot;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.RebelSheep);
                    break;
                case 4:
                    asteroid_count = 35;
                    enemy_count = 1;
                    Game.__EnemyShipType = EnemyShipTypes.StarDestroyerDown;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.Falcon);
                    break;
                case 5:
                    asteroid_count = 35;
                    enemy_count = 2;
                    Game.__EnemyShipType = EnemyShipTypes.StarDestroyerLeft;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.Falcon);
                    break;
                case 6:
                    asteroid_count = 35;
                    enemy_count = 2;
                    Game.__EnemyShipType = EnemyShipTypes.StarDestroyerRebel;
                    ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
                    ship.ChangeType(SpaceShipTypes.Falcon);
                    break;

            }
            return game_objects.ToArray();
        }


        public VisualObject[] LoadSceneObjects(Random _Rnd)
        {
            return LoadSceneObjectsList(_Rnd).ToArray();
        }

        public List<VisualObject> LoadSceneObjectsListStars(Random _Rnd)
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
            return game_objects;
        }

        public List<VisualObject> LoadSceneObjectsListEnenmy(Random _Rnd)
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            for (var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add((Asteroid)_AsteroidFactory.Create(_Rnd));
            }
            for (var i = 0; i < enemy_count; i++)
            {
                //game_objects.Add((EnemySheep)_EnemyShipFactory.CreateType(_Rnd,EnemyShipTypes.Bomber));
                game_objects.Add((EnemySheep)_EnemyShipFactory.Create(_Rnd));
            }
            return game_objects;
        }

        public List<VisualObject> LoadSceneObjectsList(Random _Rnd)
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            ConcatLists(LoadSceneObjectsListStars(_Rnd), game_objects);
            ConcatLists(LoadSceneObjectsListEnenmy(_Rnd), game_objects);
            return game_objects;
        }
    }
}