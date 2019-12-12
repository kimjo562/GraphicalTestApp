using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class EnemyTank : Entity
    {
        private Sprite _texture;
        private AABB _hitbox;
        private EnemyTankTurret tankBarrel;

        Random random = new Random();

        public EnemyTank(int x, int y, string path) : base(x, y)
        {
            _texture = new Sprite(path);
            tankBarrel = new EnemyTankTurret(0, 0, "barrelRed.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(tankBarrel);

            OnUpdate += MoveUp;
            OnUpdate += RandomizedPosition;
            OnUpdate += HitDetection;

            OnDraw += PositionFinder;
        }

        public EnemyTank(string path) : this(0, 0, path)
        {

        }

        public void MoveUp(float deltaTime)
        {
                YVelocity = (-150f);
        }

        public void HitDetection(float deltaTime)
        {


        }

        public void RandomizedPosition(float deltaTime)
        {
            int spawnLocation = random.Next(4);
            if (XAbsolute < 0 - 45 || XAbsolute > 1280 + 45 || YAbsolute < 0 - 45 || YAbsolute > 780 + 45)
                switch (spawnLocation)
                {
                    case 0: // Top
                        X = random.Next(1280 + 1);
                        Y = 0;

                        XVelocity = -175f;
                        YVelocity = 0;
                        break;

                    case 1: // Bottom
                        X = random.Next(1280 + 1);
                        Y = 786;

                        XVelocity = 175f;
                        YVelocity = 0;
                        break;

                    case 2:
                        X = 0; // Left
                        Y = random.Next(1280 + 1);

                        XVelocity = 175f;
                        YVelocity = 0;
                        break;

                    case 3:
                        X = 1280; // Right
                        Y = random.Next(1280 + 1);

                        XVelocity = -175f;
                        YVelocity = 0;
                        break;
                }

        }


        public bool CollisionCheck(AABB other)
        {
            return _hitbox.DetectCollision(other);
        }


        public void PositionFinder()
        {
            Raylib.Raylib.DrawText("Top: " + (int)_hitbox.Top + "\nBottom: " + (int)_hitbox.Bottom + "\nLeft: " + (int)_hitbox.Left + "\nRight: " + (int)_hitbox.Right, (int)XAbsolute + 50, (int)YAbsolute - 35, 1, Raylib.Color.WHITE);
        }
    }
}
