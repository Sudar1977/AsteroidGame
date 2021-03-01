namespace AsteroidGame
{
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
                    Scale = 24;
                    break;
                case SpaceShipTypes.X_Wing:
                    Scale = 5;
                    break;
            }
            return Scale;
        }
    }

}
