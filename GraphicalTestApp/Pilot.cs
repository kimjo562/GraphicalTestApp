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
        private bool isEntered = true;

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

            OnUpdate += WrapScreen;

            OnDraw += PositionFinder;
        }

        public Pilot(string path) : this(0, 0, path)
        {

        }

        // Allows the pilot to move up
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

        // Allows the pilot to move down
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

        // Allows the pilot to move left
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

        // Allows the pilot to move right
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

        // Allows the tank to turn right
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

        // Allows the tank to turn left
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

        // Resets the movement
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
            if (Input.IsKeyPressed(90) && XVelocity == 0 && YVelocity == 0 && bodyTank.CollisionCheck(_hitbox))
            {
                Rotate(bodyTank.GetRotation());
                bodyTank.Rotate(-bodyTank.GetRotation());

                bodyTank.XVelocity = 0;
                bodyTank.YVelocity = 0;

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
        public void ExitTank(float deltaTime)
        {
            if (Input.IsKeyPressed(88) && isEntered)
            {
                RemoveChild(bodyTank);
                Parent.AddChild(bodyTank);

                bodyTank.X = XAbsolute;
                bodyTank.Y = YAbsolute;

                AddChild(_texture);
                AddChild(_hitbox);

                // Grabs Tank's Rotation
                bodyTank.Rotate(GetRotation());
                // Grabs Pilots Rotation
                Rotate(-GetRotation());

                Vector3 tankDirection = bodyTank.GetDirectionAbsolute() * 250f;
                bodyTank.XVelocity = -tankDirection.x;
                bodyTank.YVelocity = tankDirection.y;

                bodyTank.XVelocity = 0;
                bodyTank.YVelocity = 0;
                bodyTank.YAcceleration = 0;

                isEntered = false;
            }
        }

        // Resets the Pilot back to the tank and recenters
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

        // Allows the Tank to slow down and stop
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

        // Checks to see if the collision of pilot
        public bool DetectCollision(AABB other)
        {
            if(_hitbox.DetectCollision(other))
            {
                RemoveChild(_hitbox);
                RemoveChild(_texture);
                if(Parent != null)
                {
                    Parent.RemoveChild(this);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        // Lets the pilot wrap to the other side of the screen
        public void WrapScreen(float deltaTime)
        {
            if (XAbsolute < 0 - 45)
            {
                X = 1280 + 45;

            }
            if (XAbsolute > 1280 + 45)
            {
                X = 0 - 45;

            }

            if (YAbsolute < 0 - 45)
            {
                Y = 780 + 45;

            }
            if (YAbsolute > 780 + 45)
            {
                Y = 0 - 45;

            }
        }

        // Shows the pilots position 
        public void PositionFinder()
        {
            Raylib.Raylib.DrawText("Top: " + (int)_hitbox.Top + "\nBottom: " + (int)_hitbox.Bottom + "\nLeft: " + (int)_hitbox.Left + "\nRight: " + (int)_hitbox.Right, (int)XAbsolute + 20, (int)YAbsolute + 20, 1, Raylib.Color.GOLD);
        }

        // Gets call function _children
        public List<Actor> GetChildren
        {
            get { return _children; }
        }

    }
}