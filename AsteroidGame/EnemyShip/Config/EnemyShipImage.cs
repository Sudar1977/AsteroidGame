using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal class EnemyShipImage
    {
        public static Image GetImage(EnemyShipTypes Type)
        {
            Image SheepImage = Properties.Resources.Tie;
            switch (Type)
            {
                case EnemyShipTypes.Tie:
                    SheepImage = Properties.Resources.Tie;
                    break;
                case EnemyShipTypes.Bomber:
                    SheepImage = Properties.Resources.Bomber;
                    break;
                case EnemyShipTypes.BomberRot:
                    SheepImage = Properties.Resources.Bomber2;
                    break;
                case EnemyShipTypes.StarDestroyerRebel:
                    SheepImage = Properties.Resources.StarDestroyer3;
                    break;
                case EnemyShipTypes.StarDestroyerLeft:
                    SheepImage = Properties.Resources.StarDestroyer1left;
                    break;
                case EnemyShipTypes.StarDestroyerDown:
                    SheepImage = Properties.Resources.StarDestroyer2left;
                    break;
            }
            return SheepImage;
        }
    }
}
