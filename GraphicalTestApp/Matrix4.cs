using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Matrix4
    {
        public float m1x1, m1x2, m1x3, m1x4, m2x1, m2x2, m2x3, m2x4, m3x1, m3x2, m3x3, m3x4, m4x1, m4x2, m4x3, m4x4;

        // Creates Matrix4 for a 3D space (Uses Vector4)
        public Matrix4()
        {
            m1x1 = 1; m1x2 = 0; m1x3 = 0; m1x4 = 0;
            m2x1 = 0; m2x2 = 1; m2x3 = 0; m2x4 = 0;
            m3x1 = 0; m3x2 = 0; m3x3 = 1; m3x4 = 0;
            m4x1 = 0; m4x2 = 0; m4x3 = 0; m4x4 = 1;
        }

        // Creates a Matrix4 with the specified values.
        public Matrix4(float m1x1, float m1x2, float m1x3, float m1x4, float m2x1, float m2x2, float m2x3, float m2x4, float m3x1, float m3x2, float m3x3, float m3x4, float m4x1, float m4x2, float m4x3, float m4x4)
        {
            this.m1x1 = m1x1; this.m1x2 = m1x2; this.m1x3 = m1x3; this.m1x4 = m1x4; // 1 0 0 0
            this.m2x1 = m2x1; this.m2x2 = m2x2; this.m2x3 = m2x3; this.m2x4 = m2x4; // 0 1 0 0
            this.m3x1 = m3x1; this.m3x2 = m3x2; this.m3x3 = m3x3; this.m3x4 = m3x4; // 0 0 1 0
            this.m4x1 = m4x1; this.m4x2 = m4x2; this.m4x3 = m4x3; this.m4x4 = m4x4; // 0 0 0 1
        }

        // Sets this Matrix4 to the specified values
        public void Set(float m1x1, float m1x2, float m1x3, float m1x4, float m2x1, float m2x2, float m2x3, float m2x4, float m3x1, float m3x2, float m3x3, float m3x4, float m4x1, float m4x2, float m4x3, float m4x4)
        {
            this.m1x1 = m1x1; this.m1x2 = m1x2; this.m1x3 = m1x3; this.m1x4 = m1x4; // 1 0 0 0
            this.m2x1 = m2x1; this.m2x2 = m2x2; this.m2x3 = m2x3; this.m2x4 = m2x4; // 0 1 0 0
            this.m3x1 = m3x1; this.m3x2 = m3x2; this.m3x3 = m3x3; this.m3x4 = m3x4; // 0 0 1 0
            this.m4x1 = m4x1; this.m4x2 = m4x2; this.m4x3 = m4x3; this.m4x4 = m4x4; // 0 0 0 1
        }

        //Set this Matrix4 to the values of the specified Matrix4
        public void Set(Matrix4 matrix4)
        {
            m1x1 = matrix4.m1x1; m1x2 = matrix4.m1x2; m1x3 = matrix4.m1x3; m1x4 = matrix4.m1x4; // 1 0 0 0
            m2x1 = matrix4.m2x1; m2x2 = matrix4.m2x2; m2x3 = matrix4.m2x3; m2x4 = matrix4.m2x4; // 0 1 0 0
            m3x1 = matrix4.m3x1; m3x2 = matrix4.m3x2; m3x3 = matrix4.m3x3; m3x4 = matrix4.m3x4; // 0 0 1 0
            m4x1 = matrix4.m4x1; m4x2 = matrix4.m4x2; m4x3 = matrix4.m4x3; m4x4 = matrix4.m4x4; // 0 0 0 1
        }

        // Matrix4 * Vector4
        public static Matrix4 operator *(Matrix4 lhs, Matrix4 rhs)
        {
            return new Matrix4(
                (lhs.m1x1 * rhs.m1x1) + (lhs.m1x2 * rhs.m2x1) + (lhs.m1x3 * rhs.m3x1) + (lhs.m1x4 * rhs.m4x1),
                (lhs.m1x1 * rhs.m1x2) + (lhs.m1x2 * rhs.m2x2) + (lhs.m1x3 * rhs.m2x2) + (lhs.m2x4 * rhs.m4x2),  // First Matrix
                (lhs.m1x1 * rhs.m1x3) + (lhs.m1x2 * rhs.m2x3) + (lhs.m1x3 * rhs.m3x3) + (lhs.m3x4 * rhs.m4x3),
                (lhs.m1x1 * rhs.m1x4) + (lhs.m1x2 * rhs.m2x4) + (lhs.m1x3 * rhs.m3x4) + (lhs.m4x4 * rhs.m4x4),

                (lhs.m2x1 * rhs.m1x1) + (lhs.m2x2 * rhs.m2x1) + (lhs.m2x3 * rhs.m3x1) + (lhs.m2x4 * rhs.m4x1),
                (lhs.m2x1 * rhs.m1x2) + (lhs.m2x2 * rhs.m2x2) + (lhs.m2x3 * rhs.m3x2) + (lhs.m2x4 * rhs.m4x2),  // Second Matrix
                (lhs.m2x1 * rhs.m1x3) + (lhs.m2x2 * rhs.m2x3) + (lhs.m2x3 * rhs.m3x3) + (lhs.m2x4 * rhs.m4x3),
                (lhs.m2x1 * rhs.m1x4) + (lhs.m2x2 * rhs.m2x4) + (lhs.m2x3 * rhs.m3x4) + (lhs.m2x4 * rhs.m4x4),

                (lhs.m3x1 * rhs.m1x1) + (lhs.m3x2 * rhs.m2x1) + (lhs.m3x3 * rhs.m3x1) + (lhs.m3x4 * rhs.m4x1),
                (lhs.m3x1 * rhs.m1x2) + (lhs.m3x2 * rhs.m2x2) + (lhs.m3x3 * rhs.m3x2) + (lhs.m3x4 * rhs.m4x2),  // Third Matrix
                (lhs.m3x1 * rhs.m1x3) + (lhs.m3x2 * rhs.m2x3) + (lhs.m3x3 * rhs.m3x3) + (lhs.m3x4 * rhs.m4x3),
                (lhs.m3x1 * rhs.m1x4) + (lhs.m3x2 * rhs.m2x4) + (lhs.m3x3 * rhs.m3x4) + (lhs.m3x4 * rhs.m4x4),

                (lhs.m4x1 * rhs.m1x1) + (lhs.m4x2 * rhs.m2x1) + (lhs.m4x3 * rhs.m3x1) + (lhs.m4x4 * rhs.m4x1),
                (lhs.m4x1 * rhs.m1x2) + (lhs.m4x2 * rhs.m2x2) + (lhs.m4x3 * rhs.m3x2) + (lhs.m4x4 * rhs.m4x2),  // Forth Matrix
                (lhs.m4x1 * rhs.m1x3) + (lhs.m4x2 * rhs.m2x3) + (lhs.m4x3 * rhs.m3x3) + (lhs.m4x4 * rhs.m4x3),
                (lhs.m4x1 * rhs.m1x4) + (lhs.m4x2 * rhs.m2x4) + (lhs.m4x3 * rhs.m3x4) + (lhs.m4x4 * rhs.m4x4));
        }

        // Matrix4 * Vector4
        public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        {
            return new Vector4(
                (lhs.m1x1 * rhs.x) + (lhs.m1x2 * rhs.y) + (lhs.m1x3 * rhs.z) + (lhs.m1x4 * rhs.w),   // X Vector
                (lhs.m2x1 * rhs.x) + (lhs.m2x2 * rhs.y) + (lhs.m2x3 * rhs.z) + (lhs.m2x4 * rhs.w),   // Y Vector
                (lhs.m3x1 * rhs.x) + (lhs.m3x2 * rhs.y) + (lhs.m3x3 * rhs.z) + (lhs.m3x4 * rhs.w),   // Z Vector
                (lhs.m4x1 * rhs.x) + (lhs.m4x2 * rhs.y) + (lhs.m4x3 * rhs.z) + (lhs.m4x4 * rhs.w));  // W Vector
        }

        // Sets the Rotation on the x Axis
        public void SetRotateX(double radians)
        {
            Set(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)-Math.Sin(radians), 0,
                0, (float)Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        // Sets the Rotation on the y Axis
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)Math.Sin(radians), 0,
                0, 1, 0, 0,
               (float)-Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);
        }

        // Sets the Rotation on the z Axis
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)-Math.Sin(radians), 0, 0,
                (float)Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);
        }

        // Rotates on the x Axis
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);

            Set(this * m);
        }

        // Rotates on the y Axis
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);

            Set(this * m);
        }

        // Rotates on the z Axis
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);

            Set(this * m);
        }

        public void SetTranslation(float x, float y, float z)
        {
            m1x4 = z; m2x4 = y; m3x4 = z; m4x4 = 1;
        }

        public void Translate(float x, float y, float z)
        {
            // apply vector offset
            m1x4 += z; m2x4 += y; m3x4 += z;
        }

    }
}
