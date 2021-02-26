namespace AsteroidGame.VisualObjects
{
    internal class EnemyShipScales
    {
        public static int GetScale(EnemyShipTypes Type)
        {
            int Scale = 1;
            switch (Type)
            {
                case EnemyShipTypes.Tie:
                    Scale = 5;
                    break;
                case EnemyShipTypes.Bomber:
                    Scale = 5;
                    break;
                case EnemyShipTypes.BomberRot:
                    Scale = 5;
                    break;
                case EnemyShipTypes.StarDestroyerRebel:
                    Scale = 1;
                    break;
                case EnemyShipTypes.StarDestroyerLeft:
                    Scale = 2;
                    break;
                case EnemyShipTypes.StarDestroyerDown:
                    Scale = 3;
                    break;
            }
            return Scale;
        }

    }
}
