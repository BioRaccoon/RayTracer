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
            double α; // 0 < α < 1
            double β; // 0 < β < 1
            double γ; // 0 < γ < 1;

            ray.Origin = StaticFunctions.ConvertPointToObjectCoordinates(ray.Origin, CompositeMatrix);
            ray.Direction = StaticFunctions.ConvertVectorToObjectCoordinates(ray.Direction, CompositeMatrix);

            // α + β + γ = 1

            double[,] A = new double[3, 3]
            { { FirstVertex.XValue - SecondVertex.XValue, FirstVertex.XValue - ThirdVertex.XValue, ray.Direction.XValue},
              { FirstVertex.YValue - SecondVertex.YValue, FirstVertex.YValue - ThirdVertex.YValue, ray.Direction.YValue},
              { FirstVertex.ZValue - SecondVertex.ZValue, FirstVertex.ZValue - ThirdVertex.ZValue, ray.Direction.ZValue}};

            double[,] matrixToCalcBeta = new double[3, 3]
            { {FirstVertex.XValue - ray.Origin.XValue, FirstVertex.XValue - ThirdVertex.XValue, ray.Direction.XValue},
              {FirstVertex.YValue - ray.Origin.YValue, FirstVertex.YValue - ThirdVertex.YValue, ray.Direction.YValue},
              {FirstVertex.ZValue - ray.Origin.ZValue, FirstVertex.ZValue - ThirdVertex.ZValue, ray.Direction.ZValue}};

            β = matrixDeterminant(matrixToCalcBeta) / matrixDeterminant(A);

            //if (β <= 0.0) { return false; } // β > 0.0 -> intersection

            if (β <= -ε) { return false; } // β > -ε -> intersection

            double[,] matrixToCalcGamma = new double[3, 3]
            { {FirstVertex.XValue - SecondVertex.XValue, FirstVertex.XValue - ray.Origin.XValue, ray.Direction.XValue},
              {FirstVertex.YValue - SecondVertex.YValue, FirstVertex.YValue - ray.Origin.YValue, ray.Direction.YValue},
              {FirstVertex.ZValue - SecondVertex.ZValue, FirstVertex.ZValue - ray.Origin.ZValue, ray.Direction.ZValue}};

            γ = matrixDeterminant(matrixToCalcGamma) / matrixDeterminant(A);

            //if (γ <= 0.0) { return false; } // γ > 0.0 -> intersection

            if (γ <= -ε) { return false; } // γ > -ε -> intersection
                
            //if (β + γ >= 1.0) { return false; } // β + γ < 1.0 -> intersection

            if (β + γ >= 1.0 + ε) { return false; } // β + γ < 1.0 + ε -> intersection

            α = 1.0 - β - γ;

            // P’ = a + β * (b - a) + γ * (c - a)

            Vector3 intersectionPoint = (SecondVertex.Subtract(FirstVertex).ScalarMultiplication(β).Add(FirstVertex)).Add
                (ThirdVertex.Subtract(FirstVertex).ScalarMultiplication(γ));

            Vector3 rayOriginToIntersection = intersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = rayOriginToIntersection.Length();

            hit.IntersectionPoint = intersectionPoint;

            // P = T P’
            hit.IntersectionPoint = StaticFunctions.ConvertPointToWorldCoordinates(hit.IntersectionPoint, CompositeMatrix);

            ray.Origin = StaticFunctions.ConvertPointToWorldCoordinates(ray.Origin, CompositeMatrix);
            ray.Direction = StaticFunctions.ConvertVectorToWorldCoordinates(ray.Direction, CompositeMatrix);

            rayOriginToIntersection = hit.IntersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = calculateMagnitude(rayOriginToIntersection);

            if (hit.TotalDistance <= ε) { return false; } // hit.t > ε -> intersection in front of ray

            if (hit.TotalDistance >= hit.FoundDistance) { return false; }// hit.t < hit.tmin -> closer intersection

            hit.FoundDistance = hit.TotalDistance;
            hit.Found = true;
            hit.IntersectionPoint = intersectionPoint;
            // N = (T-1)T N’
            hit.NormalVector = StaticFunctions.ConvertObjectNormalToWorldCoordinates(Normal, CompositeMatrix); 

            return true;
        }

        public static double calculateMagnitude(Vector3 vector)
        {
            return Math.Sqrt(vector.XValue * vector.XValue + vector.YValue * vector.YValue + vector.ZValue * vector.ZValue);
        }

        public new double matrixDeterminant(double[,] matrix)
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
