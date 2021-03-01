using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{

    internal class SpaceShipImage
    {
        public static Image GetImage(SpaceShipTypes Type)
        {
            Image SheepImage = Properties.Resources.X_Wing;
            switch (Type)
            {
                case SpaceShipTypes.Falcon:
                    SheepImage = Properties.Resources.Falcon;
                    break;
                case SpaceShipTypes.RebelSheep:
                    SheepImage = Properties.Resources.RebelSheep;
                    break;
                case SpaceShipTypes.SnowSpeeder:
                    SheepImage = Properties.Resources.SnowSpeeder;
                    break;
                case SpaceShipTypes.X_Wing:
                    SheepImage = Properties.Resources.X_Wing;
                    break;
            }
            return SheepImage;
        }
    }

}
