using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Pilot : Entity
    {
        private Sprite _texture;
        private AABB _hitbox;
        private TankBody bodyTank;
        bool isEntered = true;

        public Pilot(int x, int y, string path) : base(x, y)
        {
            isEntered = false;
            _texture = new Sprite(path);
            bodyTank = new TankBody(150, 150, "tankBlue.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;
            OnUpdate += EnterTank;
            OnUpdate += ExitTank;
        }

        public Pilot(string path) : this(0, 0, path)
        {

        }


        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(265))
            {
                YAcceleration -= (0.1f * deltaTime);
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
                YAcceleration += (0.1f * deltaTime);
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
                XAcceleration -= (0.1f * deltaTime);
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
                XAcceleration += (0.1f * deltaTime);
            }
            if (Input.IsKeyReleased(262))
            {
                ZeroSpeed();
            }

        }


        public void TurnRight(float deltaTime)
        {
            if (Input.IsKeyDown(262) && isEntered == true)
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
            if (Input.IsKeyDown(263) && isEntered == true)
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


        // Pilot enters the tank and drives it
        private void EnterTank(float deltaTime)
        {
            if (Input.IsKeyDown(90))
            {
                isEntered = true;
                AddChild(bodyTank);
                Parent.RemoveChild(bodyTank);
                bodyTank.X = XAbsolute;
                bodyTank.Y = YAbsolute;
            }

        }

        // Gets off the tank and pilot moves on its own
        private void ExitTank(float deltaTime)
        {
            if (Input.IsKeyDown(88))
            {
                RemoveChild(bodyTank);
                Parent.AddChild(bodyTank);
                isEntered = false;
            }
           // root.AddChild(bodyTank);
        }

        public Entity TankBody
        {
            get { return bodyTank; }
        }


    }
}