using RayTracer.Utils;
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

        override
        public bool intersect(Ray ray, Hit hit)
        {
            //hit.Found = false;
            //return false;

            Ray rayCopy = new Ray(ray.Origin, ray.Direction);

            rayCopy.Origin = StaticFunctions.ConvertPointToObjectCoordinates(rayCopy.Origin, CompositeMatrix);
            rayCopy.Direction = StaticFunctions.ConvertVectorToObjectCoordinates(rayCopy.Direction, CompositeMatrix);

            double a = 1.0;
            double b = rayCopy.Direction.ScalarMultiplication(2).DotProduct(rayCopy.Origin);
            double c = rayCopy.Origin.DotProduct(rayCopy.Origin) - (sphereRadius * sphereRadius);

            double d = (b * b) - (4 * a * c);

            if (d < 0) { return false; }

            d = Math.Sqrt(d);

            double t1 = (-b + d) / (2 * a);
            double t2 = (-b - d) / (2 * a);

            if (t2 > t1)
            {
                hit.TotalDistance = t1;
            }
            else hit.TotalDistance = t2;

            Vector3 intersectionPoint = rayCopy.Direction.ScalarMultiplication(hit.TotalDistance).Add(rayCopy.Origin);

            Vector3 normal = intersectionPoint.Subtract(sphereOrigin).Normalize();

            intersectionPoint = StaticFunctions.ConvertPointToWorldCoordinates(intersectionPoint, CompositeMatrix);

            // calcular a distância hit.distance (hit.t)
            // do ponto de interseção à origem do raio
            Vector3 originIntersection = intersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = originIntersection.Length();

            /*if (hit.TotalDistance <= ε) { return false; }

            if (hit.TotalDistance >= hit.MinDistance) { return false; }*/

            if (hit.TotalDistance > ε || hit.TotalDistance < hit.MinDistance)
            {
                hit.Found = true;
                hit.MinDistance = hit.TotalDistance;
                hit.IntersectionPoint = intersectionPoint;
                hit.NormalVector = StaticFunctions.ConvertObjectNormalToWorldCoordinates(normal, CompositeMatrix);
                return true;
            }

            return false;
        }

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
