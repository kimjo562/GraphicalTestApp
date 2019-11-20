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
        public TankTurret(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite(path);
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);

            OnUpdate += RotateRight;
            OnUpdate += RotateLeft;
            //OnUpdate += Orbit;

        }

        public TankTurret(string path) : this(0, 0, path)
        {

        }

        private void Orbit(float deltaTime)
        {
            foreach (Actor child in _children)
            {
                child.Rotate(-2.5f * deltaTime);
            }
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
    }
}
