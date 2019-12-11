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
            tankBarrel = new TankTurret(0, 0, "barrelBlue.png");
            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(tankBarrel);

            OnDraw += YesTest;
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }

        public bool DetectCollision(AABB other)
        {
            if (_hitbox.DetectCollision(other))
            {
                RemoveChild(_hitbox);
                RemoveChild(_texture);
                RemoveChild(tankBarrel);
                if (Parent != null)
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

        public bool CollisionCheck(AABB other)
        {
            return _hitbox.DetectCollision(other);
        }

        public void YesTest()
        {
            Raylib.Raylib.DrawText("Top: " + (int)_hitbox.Top + "\nBottom: " + (int)_hitbox.Bottom + "\nLeft: " + (int)_hitbox.Left + "\nRight: " + (int)_hitbox.Right, (int)XAbsolute + 50, (int)YAbsolute - 35, 1, Raylib.Color.WHITE);
        }

    }
}
