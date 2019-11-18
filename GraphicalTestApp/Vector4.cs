using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Vector4()
        {
            x = 0;
            y = 0;
            z = 0;
            w = 0;
        }
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        // Vector4 Addition
        public static Vector4 operator +(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.x + _vec2.x), (_vec1.y + _vec2.y), (_vec1.z + _vec2.z), (_vec1.w + _vec2.w));
        }

        // Vector4 Subtraction
        public static Vector4 operator -(Vector4 _vec1, Vector4 _vec2)
        {
            return new Vector4((_vec1.x - _vec2.x), (_vec1.y - _vec2.y), (_vec1.z - _vec2.z), (_vec1.w - _vec2.w));
        }

        // Vector4 Multiplication
        public static Vector4 operator *(float number, Vector4 _vec2)
        {
            return new Vector4((number * _vec2.y), (number * _vec2.z), (number * _vec2.w), (number * _vec2.x));
        }

        // Vector4 Multiplication
        public static Vector4 operator *(Vector4 _vec1, float number)
        {
            return new Vector4((_vec1.x * number), (_vec1.y * number), (_vec1.z * number), (_vec1.w * number));
        }

        // Vector4 Division
        public static Vector4 operator /(float number, Vector4 _vec2)
        {
            return new Vector4((number / _vec2.x), (number / _vec2.y), (number / _vec2.z), (number / _vec2.w));
        }

        // Vector4 Division
        public static Vector4 operator /(Vector4 _vec1, float number)
        {
            return new Vector4((number / _vec1.x), (number / _vec1.y), (number / _vec1.z), (number / _vec1.w));
        }

        // Returns the magnitude of Vector4
        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z) + (w * w));
        }

        // Makes the Vector unit length meaning its Magnitude is 1.
        public void Normalize()
        {
            float m = Magnitude();
            this.x /= m;
            this.y /= m;
            this.z /= m;
            this.w /= m;
        }

        // Gets the Dot Product for Vector4
        public float DotProduct(Vector4 other)
        {
            return x * other.x + y * other.y + z * other.z + w * other.w;
        }

        // Gets the Cross Product for Vector4
        public Vector4 CrossProduct(Vector4 other)
        {
            return new Vector4((y * other.z - z * other.y), (z * other.x - x * other.z), (x * other.y - y * other.x), 0);
        }

    }
}
