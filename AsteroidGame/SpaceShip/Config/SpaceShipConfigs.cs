using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    public enum SpaceShipTypes
    {
        X_Wing = 0,
        Falcon = 1,
        RebelSheep = 2, 
        SnowSpeeder =3, 
    }

    internal class SpaceShipScales
    {
        public static int GetScale(SpaceShipTypes Type)
        {
            int Scale = 1;
            switch (Type)
            {
                case SpaceShipTypes.Falcon:
                    Scale = 5;
                break;
                case SpaceShipTypes.RebelSheep:
                    Scale = 6;
                    break;
                case SpaceShipTypes.SnowSpeeder:
                    Scale = 20;
                    break;
                case SpaceShipTypes.X_Wing:
                    Scale = 5;
                    break;
            }
            return Scale;
        }
    }

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
