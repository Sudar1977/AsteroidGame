using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{

    internal interface IEnemyFactory
    {
        //Random Rnd { get; }
        Asteroid Create(Random Rnd);
    }
}
