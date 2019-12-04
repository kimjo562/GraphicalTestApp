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

            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;

            OnUpdate += PilotReset;

            OnUpdate += EnterTank;
            OnUpdate += ExitTank;
        }

        public Pilot(string path) : this(0, 0, path)
        {

        }


        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(265) && isEntered == false)
            {
                YAcceleration = (-100f);
            }
            if (Input.IsKeyReleased(265))
            {
                ZeroSpeed();
            }
        }

        public void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(264) && isEntered == false)
            {
                YAcceleration = (100f);
            }
            if (Input.IsKeyReleased(264))
            {
                ZeroSpeed();
            }
        }

        public void MoveLeft(float deltaTime)
        {
            if (Input.IsKeyDown(263) && isEntered == false)
            {
                XAcceleration = (-100f);
            }
            if (Input.IsKeyReleased(263))
            {
                ZeroSpeed();
            }
        }

        public void MoveRight(float deltaTime)
        {
            if (Input.IsKeyDown(262) && isEntered == false)
            {
                XAcceleration = (100f);
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
                Rotate(deltaTime * 2f);
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
                Rotate(-deltaTime * 2f);
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
            if (Input.IsKeyPressed(90))
            { 
                AddChild(bodyTank);
                Parent.RemoveChild(bodyTank);
                bodyTank.X = 0;
                bodyTank.Y = 0;

                isEntered = true;
                // RemoveChild(_hitbox);
                RemoveChild(_texture);
            }

        }

        // Gets off the tank and pilot moves on its own
        private void ExitTank(float deltaTime)
        {
            if (Input.IsKeyPressed(88))
            {
                RemoveChild(bodyTank);
                Parent.AddChild(bodyTank);

                bodyTank.X = XAbsolute;
                bodyTank.Y = YAbsolute;

                AddChild(_texture);
                AddChild(_hitbox);

                Rotate(-GetRotation());

                isEntered = false;
            }
            // root.AddChild(bodyTank);
        }

        private void PilotReset(float deltaTime)
        {
            if (isEntered == true)
            {
                X = bodyTank.XAbsolute;
                Y = bodyTank.YAbsolute;
            }
        }

        public Entity TankBody
        {
            get { return bodyTank; }
        }


    }
}