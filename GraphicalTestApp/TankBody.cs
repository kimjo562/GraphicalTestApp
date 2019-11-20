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
            tankBarrel = new TankTurret(-33, -24, "barrelBlue.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(tankBarrel);

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            // OnUpdate += MoveLeft;
            // OnUpdate += MoveRight;

            OnUpdate += TurnRight;
            OnUpdate += TurnLeft;
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }


        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(265))
            {
                Vector3 facing = new Vector3(Getm1x1, Getm1x2, 1) * deltaTime * 50;
                X += facing.x;
                Y += facing.y;
                //XAcceleration = facing.x;
                //YAcceleration = facing.y;
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
                Vector3 facing = new Vector3(Getm1x1, Getm1x2, 1) * deltaTime * -50;
                X += facing.x;
                Y += facing.y;
                //XAcceleration = facing.x;
                //YAcceleration = facing.y;
            }
            if (Input.IsKeyReleased(264))
            {
                ZeroSpeed();
            }
        }

        public void MoveLeft(float deltaTime)
        {
            if (Input.IsKeyDown(263))
            {
                Vector3 facing = new Vector3(Getm1x1, Getm1x2, 1) * deltaTime * -50;
                XAcceleration += facing.x;
                YAcceleration += facing.y;
            }
            if (Input.IsKeyReleased(263))
            {
                ZeroSpeed();
            }
        }

        public void MoveRight(float deltaTime)
        {
            if (Input.IsKeyDown(262))
            {
                Vector3 facing = new Vector3(Getm1x1, Getm1x2, 1) * deltaTime * 50;
                XAcceleration += facing.x;
                YAcceleration += facing.y;
            }
            if (Input.IsKeyReleased(262))
            {
                ZeroSpeed();
            }

        }

        public void TurnRight(float deltaTime)
        {
            if (Input.IsKeyDown(262))
            {
                Rotate(deltaTime);
            }
            if (Input.IsKeyReleased(262))
            {
                ZeroSpeed();
            }
        }

        public void TurnLeft(float deltaTime)
        {
            if (Input.IsKeyDown(263))
            {
                Rotate(-deltaTime);
            }
            if (Input.IsKeyReleased(263))
            {
                ZeroSpeed();
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
