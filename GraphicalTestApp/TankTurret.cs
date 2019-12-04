using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class TankTurret : Entity
    {
        private Sprite _texture;
        private AABB _hitbox;
        public TankTurret(int x, int y) : base(x, y)
        {
            _texture = new Sprite("barrelBlue.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);

            OnUpdate += RotateRight;
            OnUpdate += RotateLeft;
           // OnUpdate += Shoot;

        }

        public TankTurret(string path) : this(0, 0)
        {

        }

        public void RotateRight(float deltaTime)
        {
            if (Input.IsKeyDown(69))
            {
                foreach (Actor child in _children)
                {
                    child.Rotate(-deltaTime * 1.5f);
                }
            }
        }

        public void RotateLeft(float deltaTime)
        {
            if (Input.IsKeyDown(81))
            {
                foreach (Actor child in _children)
                {
                    child.Rotate(deltaTime * 1.5f);
                }
            }
        }

        public void Shoot(float deltaTime)
        {
            if (Input.IsKeyDown(32))
            {
                Bullet bullet = new Bullet(XAbsolute, YAbsolute);
                Parent.Parent.Parent.AddChild(bullet);


            }
        }

    }
}
