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
            tankBarrel = new TankTurret(0, 0);

            _hitbox = new AABB(_texture.Width, _texture.Height);
            AddChild(_texture);
            AddChild(_hitbox);
            AddChild(tankBarrel);

            OnUpdate += YesTest;
        }

        public TankBody(string path) : this(0, 0, path)
        {

        }

        public bool CollisionCheck(AABB other)
        {
            return _hitbox.DetectCollision(other);
        }

        public void YesTest(float deltaTime)
        {
            Raylib.Raylib.DrawText("Top: " + (int)_hitbox.Top + "\nBottom: " + (int)_hitbox.Bottom + "\nRight: " + (int)_hitbox.Right + "\nLeft: " + (int)_hitbox.Left, (int)XAbsolute + 50, (int)YAbsolute - 35, 1, Raylib.Color.WHITE);
        }

    }
}
