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
        // private AABB _hitbox;
        public TankTurret(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite(path);
            _texture.Y = -5f;
            Rotate((float)Math.PI);
            AddChild(_texture);

            OnUpdate += RotateRight;
            OnUpdate += RotateLeft;
            OnUpdate += Shoot;

        }

        public TankTurret(string path) : this(0, 0, path)
        {

        }

        public void RotateRight(float deltaTime)
        {
            if (Input.IsKeyDown(81) && Parent.Parent.Parent != null)
            {
                Rotate(-deltaTime * 1.5f);
            }
        }

        public void RotateLeft(float deltaTime)
        {
            if (Input.IsKeyDown(69) && Parent.Parent.Parent != null)
            {
                Rotate(deltaTime * 1.5f);

            }
        }

        public void Shoot(float deltaTime)
        {
            if (Input.IsKeyPressed(32) && Parent.Parent != null && Parent.Parent.Parent != null)
            {
                Bullet bullet = new Bullet(XAbsolute, YAbsolute);
                Parent.Parent.Parent.AddChild(bullet);

                bullet.Rotate(GetRotationAbsolute());
                Vector3 bulletDirection = GetDirectionAbsolute() * 250f;
          
                bullet.XVelocity = bulletDirection.x;
                bullet.YVelocity = bulletDirection.y;
                
            }
        }


    }
}
