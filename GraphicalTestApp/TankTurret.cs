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
            AddChild(_texture);
            AddChild(_hitbox);

            OnUpdate += RotateRight;
            OnUpdate += RotateLeft;

        }

        public TankTurret(string path) : this(0, 0, path)
        {

        }

        public void RotateRight(float deltaTime)
        {
            if(Input.IsKeyPressed(69) && Input.IsKeyDown(69))
            {
                Rotate(deltaTime);
            }

        }

        public void RotateLeft(float deltaTime)
        {
            if (Input.IsKeyPressed(81) && Input.IsKeyDown(81))
            {
                Rotate(deltaTime);
            }

        }
    }
}
