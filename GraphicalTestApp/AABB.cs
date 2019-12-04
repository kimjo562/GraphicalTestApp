using System;

namespace GraphicalTestApp
{
    // Top Left                    (min) o------o (max x, min y)
    // Bottom Left                       |      |
    // Bottom Right                      |      |
    // Top Right          (min x, max y) o------o (max)
    class AABB : Actor
    {
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        private Raylib.Color _color = Raylib.Color.GREEN;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute - Width / 2; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public bool DetectCollision(AABB other)
        {
            //## Implement DetectCollision(AABB) ##//
            // return false;

            if (!(other.Left != Left || other.Left != Left || other.Left != Left || other.Bottom != Bottom))
            {
                _color = Raylib.Color.RED;
              return true;
            }
            else
            {
                _color = Raylib.Color.BLUE;
              return false;
            }
        }

        public bool DetectCollision(Vector3 point)
        {
            //## Implement DetectCollision(Vector3) ##//
            // return false;
            return !(point.x > Right || point.y < Top || point.x > Left || point.y > Bottom);

        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(
                XAbsolute - Width / 2,
                YAbsolute - Height / 2,
                Width,
                Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 1, _color);
            base.Draw();
        }
    }
}
