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
            isEntered = true;
            _texture = new Sprite(path);
            bodyTank = new TankBody(150, 150, "tankBlue.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(bodyTank);

            OnUpdate += TurnLeft;
            OnUpdate += TurnRight;

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;

            OnUpdate += PilotReset;
            OnUpdate += Braking;

            OnUpdate += EnterTank;
            OnUpdate += ExitTank;

            OnDraw += YesTest;
        }

        public Pilot(string path) : this(0, 0, path)
        {

        }

        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(265))
            {
                if(isEntered)
                {
                    bodyTank.YAcceleration = (-100f);
                }
                else
                {
                    YAcceleration = (-100f);
                }
            }
            if (Input.IsKeyReleased(265) && !isEntered)
            {
                ZeroSpeed();
            }
        }

        public void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(264))
            {
                if(isEntered)
                {
                    bodyTank.YAcceleration = (100f);
                }
                else
                {
                    YAcceleration = (100f);
                }
            }
            if (Input.IsKeyReleased(264) && !isEntered)
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
            if (Input.IsKeyReleased(263) && !isEntered)
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
            if (Input.IsKeyReleased(262) && !isEntered)
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
            //&& bodyTank.CollisionCheck(_hitbox)
            if (Input.IsKeyPressed(90) && XVelocity == 0 && YVelocity == 0)
            { 
                Parent.RemoveChild(bodyTank);
                AddChild(bodyTank);
                bodyTank.X = 0;
                bodyTank.Y = 0;

                isEntered = true;

                RemoveChild(_hitbox);
                RemoveChild(_texture);
            }

        }

        // Gets off the tank and pilot moves on its own
        private void ExitTank(float deltaTime)
        {
            if (Input.IsKeyPressed(88) && isEntered)
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

                bodyTank.X = 0;
                bodyTank.Y = 0;
            }
        }

        public void Braking(float deltaTime)
        {

            // Up Controls
            if (bodyTank.YVelocity < -100f)
            {
                bodyTank.YVelocity = -100f;
            }

            // -----------------------------------------

            // Down Controls
            if (bodyTank.YVelocity > 0f)
            {
                bodyTank.YVelocity = 0f;
            }
        }

        public void YesTest()
        {
            Raylib.Raylib.DrawText("Top: " + (int)_hitbox.Top + "\nBottom: " + (int)_hitbox.Bottom + "\nLeft: " + (int)_hitbox.Left + "\nRight: " + (int)_hitbox.Right, (int)XAbsolute + 20, (int)YAbsolute + 20, 1, Raylib.Color.GOLD);
        }

        public Entity TankBody
        {
            get { return bodyTank; }
        }


    }
}