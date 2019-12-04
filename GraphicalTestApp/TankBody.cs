using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class TankBody : Entity
    {
        private Sprite _texture;
        private AABB _hitbox;
        private TankTurret tankBarrel;

        public TankBody(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite(path);
            tankBarrel = new TankTurret(0, 0);

            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(tankBarrel);
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }

        public bool CollisionCheck(AABB other)
        {
            return _hitbox.DetectCollision(other);
        }

    }
}
