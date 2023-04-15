using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Triangle : Object3D
    {
        public Vector3 FirstVertex { get; set; }
        public Vector3 SecondVertex { get; set; }
        public Vector3 ThirdVertex { get; set; }
        public Vector3 Normal { get; set; }

        public Triangle(int TransformationIndex, int MaterialIndex, Vector3 first, Vector3 second, Vector3 third)
        {
            this.TransformationIndex = TransformationIndex;
            this.MaterialIndex = MaterialIndex;
            FirstVertex = first;
            SecondVertex = second;
            ThirdVertex = third;
        }

        public Triangle(int MaterialIndex, Vector3 first, Vector3 second, Vector3 third)
        {
            this.MaterialIndex = MaterialIndex;
            FirstVertex = first;
            SecondVertex = second;
            ThirdVertex = third;
        }

        double ε = 1E-6;

        override
        public void toString()
        {
            Console.WriteLine("This is a triangle with material index - " + MaterialIndex);
        }

        override
        public bool intersect(Ray ray, Hit hit)
        {
            //double α; // 0 < α < 1
            double β; // 0 < β < 1
            double γ; // 0 < γ < 1;

            Ray rayCopy = new Ray(ray.Origin, ray.Direction);

            rayCopy.Origin = StaticFunctions.ConvertPointToObjectCoordinates(rayCopy.Origin, CompositeMatrix);
            rayCopy.Direction = StaticFunctions.ConvertVectorToObjectCoordinates(rayCopy.Direction, CompositeMatrix);

            // α + β + γ = 1

            double[,] A = new double[3, 3]
            { { FirstVertex.XValue - SecondVertex.XValue, FirstVertex.XValue - ThirdVertex.XValue, rayCopy.Direction.XValue},
              { FirstVertex.YValue - SecondVertex.YValue, FirstVertex.YValue - ThirdVertex.YValue, rayCopy.Direction.YValue},
              { FirstVertex.ZValue - SecondVertex.ZValue, FirstVertex.ZValue - ThirdVertex.ZValue, rayCopy.Direction.ZValue}};

            double[,] matrixToCalcBeta = new double[3, 3]
            { {FirstVertex.XValue - rayCopy.Origin.XValue, FirstVertex.XValue - ThirdVertex.XValue, rayCopy.Direction.XValue},
              {FirstVertex.YValue - rayCopy.Origin.YValue, FirstVertex.YValue - ThirdVertex.YValue, rayCopy.Direction.YValue},
              {FirstVertex.ZValue - rayCopy.Origin.ZValue, FirstVertex.ZValue - ThirdVertex.ZValue, rayCopy.Direction.ZValue}};

            β = matrixDeterminant(matrixToCalcBeta) / matrixDeterminant(A);

            //if (β <= 0.0) { return false; } // β > 0.0 -> intersection

            if (β <= -ε) { return false; } // β > -ε -> intersection

            double[,] matrixToCalcGamma = new double[3, 3]
            { {FirstVertex.XValue - SecondVertex.XValue, FirstVertex.XValue - rayCopy.Origin.XValue, rayCopy.Direction.XValue},
              {FirstVertex.YValue - SecondVertex.YValue, FirstVertex.YValue - rayCopy.Origin.YValue, rayCopy.Direction.YValue},
              {FirstVertex.ZValue - SecondVertex.ZValue, FirstVertex.ZValue - rayCopy.Origin.ZValue, rayCopy.Direction.ZValue}};

            γ = matrixDeterminant(matrixToCalcGamma) / matrixDeterminant(A);

            //if (γ <= 0.0) { return false; } // γ > 0.0 -> intersection

            if (γ <= -ε) { return false; } // γ > -ε -> intersection
                
            //if (β + γ >= 1.0) { return false; } // β + γ < 1.0 -> intersection

            if (β + γ >= 1.0 + ε) { return false; } // β + γ < 1.0 + ε -> intersection

            // α = 1.0 - β - γ; não é necessário calcular

            // P’ = a + β * (b - a) + γ * (c - a)

            Vector3 intersectionPoint = (SecondVertex.Subtract(FirstVertex).ScalarMultiplication(β).Add(FirstVertex)).Add
                (ThirdVertex.Subtract(FirstVertex).ScalarMultiplication(γ));

            // P = T P’
            intersectionPoint = StaticFunctions.ConvertPointToWorldCoordinates(intersectionPoint, CompositeMatrix);
            //ray.Origin = StaticFunctions.ConvertPointToWorldCoordinates(ray.Origin, CompositeMatrix);
            //ray.Direction = StaticFunctions.ConvertVectorToWorldCoordinates(ray.Direction, CompositeMatrix);

            Vector3 rayOriginToIntersection = intersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = rayOriginToIntersection.Length();

            if (hit.TotalDistance <= ε) { return false; } // hit.t > ε -> intersection in front of ray

            if (hit.TotalDistance >= hit.MinDistance) { return false; }// hit.t < hit.tmin -> closer intersection

            hit.MinDistance = hit.TotalDistance;
            hit.Found = true;
            hit.IntersectionPoint = intersectionPoint;
            // N = (T-1)T N’
            hit.NormalVector = StaticFunctions.ConvertObjectNormalToWorldCoordinates(Normal, CompositeMatrix); 
            //hit.NormalVector = Normal;

            return true;
        }

        /*public static double calculateMagnitude(Vector3 vector)
        {
            return Math.Sqrt(vector.XValue * vector.XValue + vector.YValue * vector.YValue + vector.ZValue * vector.ZValue);
        }*/

        public double matrixDeterminant(double[,] matrix)
        {

            return (matrix[0, 0] * matrix[1, 1] * matrix[2, 2]) +
                   (matrix[0, 1] * matrix[1, 2] * matrix[2, 0]) +
                   (matrix[0, 2] * matrix[1, 0] * matrix[2, 1]) -
                   (matrix[0, 2] * matrix[1, 1] * matrix[2, 0]) -
                   (matrix[0, 1] * matrix[1, 0] * matrix[2, 2]) -
                   (matrix[0, 0] * matrix[1, 2] * matrix[2, 1]);
        }

    }
}
