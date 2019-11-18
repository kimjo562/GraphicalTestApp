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
        private TankTurret arrow;
        public TankBody(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite("noobdog.png");
            arrow = new TankTurret("arrow.png");

            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(arrow);

            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += MoveLeft;
            OnUpdate += MoveRight;
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }

        public void MoveUp(float deltaTime)
        {
            if (Input.IsKeyPressed(87) && Input.IsKeyDown(87))
            {
                YAcceleration -= 0.1f;
            }
            if (Input.IsKeyReleased(87))
            {
                YVelocity = 0;
                YAcceleration = 0;
            }
        }

        public void MoveDown(float deltaTime)
        {
            if (Input.IsKeyPressed(83) && Input.IsKeyDown(83))
            {
                YAcceleration += 0.1f;
            }
            if (Input.IsKeyReleased(83))
            {
                YVelocity = 0;
                YAcceleration = 0;
            }
        }

        public void MoveLeft(float deltaTime)
        {
            if (Input.IsKeyPressed(65) && Input.IsKeyDown(65))
            {
                XAcceleration -= 0.1f;
            }
            if (Input.IsKeyReleased(65))
            {
                XVelocity = 0;
                XAcceleration = 0;
            }
        }

        public void MoveRight(float deltaTime)
        {
            if (Input.IsKeyPressed(68) && Input.IsKeyDown(68))
            {
                XAcceleration += 0.1f;
            }
            if (Input.IsKeyReleased(68))
            {
                XVelocity = 0;
                XAcceleration = 0;
            }
        }

    }
}
