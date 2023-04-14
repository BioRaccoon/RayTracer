﻿using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Sphere : Object3D
    {

        public Vector3 sphereOrigin = new Vector3 (0, 0, 0);
        public double sphereRadius = 1.0;

        public Sphere(int TransformationIndex, int MaterialIndex)
        {
            this.TransformationIndex = TransformationIndex;
            this.MaterialIndex = MaterialIndex;
        }

        double ε = 1E-3;

        override
        public bool intersect(Ray ray, Hit hit)
        {
            //hit.Found = false;
            //return false;

            Vector3 temp = new Vector3(0, 0, 0);

            Ray rayCopy = new Ray(ray.Origin, ray.Direction);

            rayCopy.Origin = temp.ConvertPointToObjectCoordinates(rayCopy.Origin, CompositeMatrix);
            rayCopy.Direction = temp.ConvertVectorToObjectCoordinates(rayCopy.Direction, CompositeMatrix);

            //Vector3 raySphereOrigin = sphereOrigin.Subtract(ray.Origin);

            double a = 1.0;
            double b = rayCopy.Direction.ScalarMultiplication(2).DotProduct(rayCopy.Origin);
            //double b = ray.Direction.ScalarMultiplication(2).DotProduct(raySphereOrigin);
            double c = rayCopy.Origin.DotProduct(rayCopy.Origin) - (sphereRadius * sphereRadius);
            //double c = raySphereOrigin.DotProduct(raySphereOrigin) - (sphereRadius * sphereRadius);

            double d = (b * b) - (4 * a * c);

            if(d < 0) { return false; }

            d = Math.Sqrt(d);

            double t;
            double tPlus = (-b + d) / (2 * a);
            double tMinus = (-b - d) / (2 * a);

            /*if (tMinus < 0.0)
            {
                t = tPlus;
            } else { t = tMinus; }*/

            if (tMinus > tPlus)
            {
                hit.TotalDistance = tPlus;
            }
            else hit.TotalDistance = tMinus;

            Vector3 intersectionPoint = rayCopy.Direction.ScalarMultiplication(hit.TotalDistance).Add(rayCopy.Origin);
            //hit.IntersectionPoint = intersectionPoint;

            hit.NormalVector = intersectionPoint.Subtract(sphereOrigin).Normalize();

            intersectionPoint = temp.ConvertPointToWorldCoordinates(intersectionPoint, CompositeMatrix);

            // calcular a distância hit.distance (hit.t)
            // do ponto de interseção à origem do raio
            Vector3 originIntersection = intersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = originIntersection.Length();

            if (hit.TotalDistance <= ε) { return false; }

            if (hit.TotalDistance >= hit.MinDistance) { return false; }

            hit.Found = true;
            //if (hit.TotalDistance < hit.MinDistance)
            //{
                hit.MinDistance = hit.TotalDistance;
            //}
            hit.IntersectionPoint = intersectionPoint;
            hit.NormalVector = temp.ConvertObjectNormalToWorldCoordinates(hit.NormalVector, CompositeMatrix);

            return true;
        }

        //vector norm
        /*public static double calculateMagnitude(Vector3 vector)
        {
            return Math.Sqrt(vector.XValue * vector.XValue + vector.YValue * vector.YValue + vector.ZValue * vector.ZValue);
        }*/

        public double Distance(Vector3 point1, Vector3 point2)
        {
            double dx = point1.XValue - point2.XValue;
            double dy = point1.YValue - point2.YValue;
            double dz = point1.ZValue - point2.ZValue;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        override
        public void toString()
        {
            Console.WriteLine("This is a sphere with material index - " + MaterialIndex);
        }
    }
}
