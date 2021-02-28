using AsteroidGame.VisualObjects;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AsteroidGame
{
    internal class BulletsList
    {
        private List<Bullet> _Bullets;
        //public Bulets => _Bullets;
        public BulletsList()
        {
            _Bullets = new List<Bullet>();
        }
        public Bullet[] ToArray()
        {
            return _Bullets.ToArray();
        }

        public void Draw(Graphics g)
        {
            _Bullets.ForEach(bullet => bullet.Draw(g));
        }

        public void Update()
        {
            _Bullets.ForEach(bullet => bullet.Update());
            foreach (var bullet_to_remove in _Bullets.Where(b => b.Rect.Left > Game.Width).ToArray())
            {
                _Bullets.Remove(bullet_to_remove);
            }
        }

        public void AddBullet(int X, int Y)
        {
            _Bullets.Add(new Bullet(X, Y));
        }

        public bool Remove(Bullet bullet)
        {
            return _Bullets.Remove(bullet);
        }

        public void RemoveAt(int index)
        {
            _Bullets.RemoveAt(index);
        }

        public void OnBulletShoot(int X, int Y)
        {
            _Bullets.Add(new Bullet(X, Y));
        }
    }
}
