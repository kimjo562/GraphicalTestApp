using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        // Vector 3 Constructor
        public Vector3()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        // Vector3 Overloaded Constructor
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Vector3 Addition
        public static Vector3 operator +(Vector3 _vec1, Vector3 _vec2)
        {
            return new Vector3((_vec1.x + _vec2.x), (_vec1.y + _vec2.y), (_vec1.z + _vec2.z));
        }

        // Vector3 Subtraction
        public static Vector3 operator -(Vector3 _vec1, Vector3 _vec2)
        {
            return new Vector3((_vec1.x - _vec2.x), (_vec1.y - _vec2.y), (_vec1.z - _vec2.z));
        }

        // Vector3 Multiplication
        public static Vector3 operator *(float number, Vector3 _vec2)
        {
            return new Vector3((number * _vec2.x), (number * _vec2.y), (number * _vec2.z));
        }

        // Vector3 Multiplication
        public static Vector3 operator *(Vector3 _vec1, float number)
        {
            return new Vector3((_vec1.x * number), (_vec1.y * number), (_vec1.z * number));
        }

        // Vector3 Division
        public static Vector3 operator /(float number, Vector3 _vec2)
        {
            return new Vector3((number / _vec2.x), (number / _vec2.y), (number / _vec2.z));
        }

        // Vector3 Division
        public static Vector3 operator /(Vector3 _vec1, float number)
        {
            return new Vector3((number / _vec1.x), (number / _vec1.y), (number / _vec1.z));
        }

        // Returns the magnitude of Vector3
        public float Magnitude()
        {
            return (float)Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        // Makes the Vector unit length meaning its Magnitude is 1.
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        // Gets the DotProduct Product for Vector3
        public float DotProduct(Vector3 other)
        {
            return x * other.x + y * other.y + z * other.z;
        }

        // Gets the CrossProduct Product for Vector3
        public Vector3 CrossProduct(Vector3 other)
        {
            return new Vector3((y * other.z - z * other.y), (z * other.x - x * other.z), (x * other.y - y * other.x));
        }

    }
}
