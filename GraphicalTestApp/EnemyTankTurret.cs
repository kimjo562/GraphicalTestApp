using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class EnemyTankTurret : Entity
    {
        private Sprite _texture;
        private Timer _timetoShoot;
        private float _shootInterval = 2.5f;
        Random random = new Random();

        public EnemyTankTurret(int x, int y, string path) : base(x, y)
        {
            _timetoShoot = new Timer();

            _texture = new Sprite(path);
            _texture.Y = -5f;
            Rotate((float)Math.PI);
            AddChild(_texture);

            OnUpdate += RotateRight;
            OnUpdate += Shoot;
        }

        public EnemyTankTurret(string path) : this(0, 0, path)
        {

        }

        public void RotateRight(float deltaTime)
        {
            Rotate(-deltaTime * 2.5f);
        }


        public void Shoot(float deltaTime)
        {
            if(_timetoShoot.Seconds >= _shootInterval)
            {
                _shootInterval = (float)random.NextDouble();
                _timetoShoot.Restart();

                Bullet bullet = new Bullet(XAbsolute, YAbsolute);

                Parent.Parent.AddChild(bullet);

                bullet.Rotate(GetRotationAbsolute());
                Vector3 bulletDirection = GetDirectionAbsolute() * 50f;

                bullet.XVelocity = bulletDirection.x * 1f;
                bullet.YVelocity = bulletDirection.y * 1f;

                bullet.X += bulletDirection.x;
                bullet.Y += bulletDirection.y;

            }
        }

    }
}
