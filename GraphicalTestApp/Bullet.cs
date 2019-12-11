using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Sprite _textureBullet;
        private AABB _hitboxBullet;
        public Bullet(float x, float y) : base(x, y)
        {
            _textureBullet = new Sprite("bullet.png");
            _hitboxBullet = new AABB(_textureBullet.Width, _textureBullet.Width);
            AddChild(_textureBullet);
            AddChild(_hitboxBullet);

            OnUpdate += HitCollision;
            OnUpdate += DestroyBullet;
        }

        public void HitCollision(float deltaTime)
        {
            foreach (Actor checkHit in Parent.GetChildren)
            {
                if (checkHit is Pilot)
                {
                    Pilot pilot = (Pilot)checkHit;

                    foreach (Actor pilotInside in pilot.GetChildren)
                    {
                        if (pilotInside is TankBody)
                        {
                            TankBody bodyTank = (TankBody)pilotInside;
                            if (bodyTank.DetectCollision(_hitboxBullet))
                            {
                                pilot.ExitTank(deltaTime);

                                RemoveChild(_hitboxBullet);
                                RemoveChild(_textureBullet);
                                if (Parent != null)
                                {
                                    Parent.RemoveChild(this);
                                }
                            }
                        }

                    }
                    if (pilot.DetectCollision(_hitboxBullet))
                    {
                        RemoveChild(_hitboxBullet);
                        RemoveChild(_textureBullet);
                        if (Parent != null)
                        {
                            Parent.RemoveChild(this);
                        }
                    }
                }

                if (checkHit is TankBody)
                {
                    TankBody bodyTank = (TankBody)checkHit;
                    if (bodyTank.DetectCollision(_hitboxBullet))
                    {
                        RemoveChild(bodyTank);
                        Rotate(-GetRotation());

                        RemoveChild(_hitboxBullet);
                        RemoveChild(_textureBullet);
                        if (Parent != null)
                        {
                            Parent.RemoveChild(this);
                        }
                    }
                }
            }
        }

        ~Bullet()
        {
            if (Parent != null)
            {
                Parent.RemoveChild(this);
            }

            RemoveChild(_textureBullet);
            RemoveChild(_hitboxBullet);
        }

        public void DestroyBullet(float deltaTime)
        {
            if (X < 0 || Y < 0 || X > 1280 || Y > 768)
            {
                if (Parent != null)
                {
                    Parent.RemoveChild(this);
                }

            }
        }

        public bool CollisionCheck(AABB other)
        {
            return _hitboxBullet.DetectCollision(other);
        }
    }
}
