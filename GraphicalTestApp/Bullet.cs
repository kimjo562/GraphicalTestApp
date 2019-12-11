using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _textureBullet;
        private AABB _hitboxBullet;
        public Bullet(float x, float y) : base(x, y)
        {
            _textureBullet = new Sprite("bullet.png");
            _hitboxBullet = new AABB(_textureBullet.Width, _textureBullet.Height);
            AddChild(_textureBullet);
            AddChild(_hitboxBullet);

            OnUpdate += DestroyBullet;
        }

        ~Bullet()
        {
            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }

            RemoveChild(_textureBullet);
            RemoveChild(_hitboxBullet);
        }

        public void DestroyBullet(float deltaTime)
        {
            if (X < 0 || Y < 0 || X > 1280 || Y > 768)
            {
                Parent.RemoveChild(this);
            }
        }

        public bool CollisionCheck(AABB other)
        {
            return _hitboxBullet.DetectCollision(other);
        }
    }
}
