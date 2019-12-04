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

            OnUpdate += BulletFacing;
        }

        public void BulletFacing(float deltaTime)
        {


        }

    }
}
