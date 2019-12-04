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

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += Braking;
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }

        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(265))
            {
                YAcceleration = (-0.1f);
                if (YVelocity < -0.3f)
                {
                    YVelocity = -0.3f;
                }
            }
            if (Input.IsKeyReleased(265))
            {
                ZeroSpeed();
            }
        }

        public void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(264))
            {
                YAcceleration = (0.1f);
                if (YVelocity > 0.3f)
                {
                    YVelocity = 0.3f;
                }
            }
            if (Input.IsKeyReleased(264))
            {
                ZeroSpeed();
            }
        }

        public void Braking(float deltaTime)
        {
            if (YVelocity > 0f)
            {
                YVelocity = 0f;
            }
        }


        public void ZeroSpeed()
        {
            XVelocity = 0;
            XAcceleration = 0;
            YVelocity = 0;
            YAcceleration = 0;
        }
    }
}
