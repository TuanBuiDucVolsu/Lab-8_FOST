using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOST8
{
    class Vector3
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3 CrossProduct(Vector3 v2)
        { 
            return new Vector3 // векторное произведение векторов 
            {
                X = Y * v2.Z - v2.Y * Z,
                Y = v2.X * Z - X * v2.Z,
                Z = X * v2.Y - v2.X * Y
            };
        } 

        public static Vector3 operator*(Vector3 vec, double num)
        { 
            return new Vector3
            {
                X = vec.X * num,
                Y = vec.Y * num,
                Z = vec.Z * num
            };
        }
        public static Vector3 operator*(double num, Vector3 vec)
        {
            return vec * num;
        }
        public static Vector3 operator+(Vector3 v1, Vector3 v2)
        {
            return new Vector3 // сложение векторов 
            {
                X = v1.X + v2.X,
                Y = v1.Y + v2.Y,
                Z = v1.Z + v2.Z
            };
        }
    }
}
