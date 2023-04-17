using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracer.Model
{
    internal class Box : Object3D
    {

        public Vector3 firstVextex = new Vector3(-0.5,-0.5,-0.5);
        public Vector3 secondVextex = new Vector3(0.5, 0.5, 0.5);

        public Vector3 thirdVextex = new Vector3(0.5, 0.5, -0.5);
        public Vector3 fourthVextex = new Vector3(-0.5, -0.5, 0.5);

        public Vector3 fifthVextex = new Vector3(-0.5, 0.5, -0.5);
        public Vector3 sixthVextex = new Vector3(0.5, -0.5, 0.5);

        public Vector3 seventhVextex = new Vector3(-0.5, 0.5, 0.5);
        public Vector3 eigthVextex = new Vector3(0.5, -0.5, -0.5);


        public Box(int TransformationIndex, int MaterialIndex)
        {
            this.TransformationIndex = TransformationIndex;
            this.MaterialIndex = MaterialIndex;
        }

        public bool checkIfRayIsParallel(double rayOriginCoordinate, double rayDirectionCoordinate, double boxMinCoordinate, double boxMaxCoordinate)
        {

            if (Math.Abs(rayDirectionCoordinate) < ε) // check if ray is parallel
            {
                if (rayOriginCoordinate < boxMinCoordinate || rayOriginCoordinate > boxMaxCoordinate) { return false; }
            }

            return true;
        }

        public double calculateIntersectionDistance(double boxMinOrMaxCoordinate, double rayOriginCoordinate, double rayDirectionCoordinate) { 

            return (boxMinOrMaxCoordinate - rayOriginCoordinate) / rayDirectionCoordinate;
        
        }

        override
        public bool intersect(Ray ray, Hit hit)
        {
            //hit.Found = false;
            //return false;

            Ray rayCopy = new Ray(ray.Origin, ray.Direction);

            rayCopy.Origin = StaticFunctions.ConvertPointToObjectCoordinates(rayCopy.Origin, CompositeMatrix);
            rayCopy.Direction = StaticFunctions.ConvertVectorToObjectCoordinates(rayCopy.Direction, CompositeMatrix);

            Vector3 boxMin = firstVextex;
            Vector3 boxMax = secondVextex;

            double tFar = 1.0E6;
            double tNear = -1.0E6;

            /////////////////////// X axis ///////////////////////

            if (!checkIfRayIsParallel(rayCopy.Origin.XValue, rayCopy.Direction.XValue, boxMin.XValue, boxMax.XValue)) return false;

            double txmin = calculateIntersectionDistance(boxMin.XValue, rayCopy.Origin.XValue, rayCopy.Direction.XValue);
            double txmax = calculateIntersectionDistance(boxMax.XValue, rayCopy.Origin.XValue, rayCopy.Direction.XValue);

            if (txmin > txmax) // If tx1 > tx2, swap
            {
                double temp = txmin;
                txmin = txmax;
                txmax = temp;
            }

            if (txmin > tNear) tNear = txmin;

            if (txmax < tFar) tFar = txmax;

            if (tNear > tFar) return false; // box is missed

            if (tFar < 0) return false; // box is behind

            /////////////////////// Y axis ///////////////////////

            if (!checkIfRayIsParallel(rayCopy.Origin.YValue, rayCopy.Direction.YValue, boxMin.YValue, boxMax.YValue)) return false;

            double tymin = calculateIntersectionDistance(boxMin.YValue, rayCopy.Origin.YValue, rayCopy.Direction.YValue);
            double tymax = calculateIntersectionDistance(boxMax.YValue, rayCopy.Origin.YValue, rayCopy.Direction.YValue);

            if (tymin > tymax) // If ty1 > ty2, swap
            {
                double temp = tymin;
                tymin = tymax;
                tymax = temp;
            }

            //if ((tNear > tymax) || (tymin > tFar)) return false;

            if (tymin > tNear) tNear = tymin;

            if (tymax < tFar) tFar = tymax;

            if (tNear > tFar) return false; // box is missed

            if (tFar < 0) return false; // box is behind

            /////////////////////// Z axis ///////////////////////

            if (!checkIfRayIsParallel(rayCopy.Origin.ZValue, rayCopy.Direction.ZValue, boxMin.ZValue, boxMax.ZValue)) return false;

            double tzmin = calculateIntersectionDistance(boxMin.ZValue, rayCopy.Origin.ZValue, rayCopy.Direction.ZValue);
            double tzmax = calculateIntersectionDistance(boxMax.ZValue, rayCopy.Origin.ZValue, rayCopy.Direction.ZValue);

            if (tzmin > tzmax) // If tz1 > tz2, swap
            {
                double temp = tzmin;
                tzmin = tzmax;
                tzmax = temp;
            }

            //if ((tNear > tzmax) || (tzmin > tFar)) return false;

            if (tzmin > tNear) tNear = tzmin;

            if (tzmax < tFar) tFar = tzmax;

            if (tNear > tFar) return false; // box is missed

            if (tFar < 0) return false; // box is behind

            // calculate intersection point
            // P(t) = R + tNear * D
            Vector3 intersectionPoint = rayCopy.Direction.ScalarMultiplication(tNear).Add(rayCopy.Origin);

            hit.TotalDistance = tNear;

            hit.NormalVector = checkWhichBoxFaceWasHit(intersectionPoint);

            intersectionPoint = StaticFunctions.ConvertPointToWorldCoordinates(intersectionPoint, CompositeMatrix);

            Vector3 rayOriginToIntersection = intersectionPoint.Subtract(ray.Origin);
            hit.TotalDistance = rayOriginToIntersection.Length();

            if (hit.TotalDistance <= ε) { return false; }

            if (hit.TotalDistance >= hit.MinDistance) { return false; }

            if (hit.TotalDistance < hit.MinDistance)
            {
                hit.MinDistance = hit.TotalDistance;
            }

            hit.Found = true;
            hit.IntersectionPoint = intersectionPoint;
            hit.NormalVector = StaticFunctions.ConvertObjectNormalToWorldCoordinates(hit.NormalVector, CompositeMatrix);

            return true;
        }

        public Vector3 checkWhichBoxFaceWasHit(Vector3 intersectionPoint)
        {

            // Check which face was hit
            if (Math.Abs(intersectionPoint.XValue + 0.5) < ε)
            {
                // Front face was hit
                return new Vector3(-1, 0, 0);
            }
            else if (Math.Abs(intersectionPoint.XValue - 0.5) < ε)
            {
                // Back face was hit
                return new Vector3(1, 0, 0);
            }
            else if (Math.Abs(intersectionPoint.YValue + 0.5) < ε)
            {
                // Bottom face was hit
                return new Vector3(0, -1, 0);
            }
            else if (Math.Abs(intersectionPoint.YValue - 0.5) < ε)
            {
                // Top face was hit
                return new Vector3(0, 1, 0);
            }
            else if (Math.Abs(intersectionPoint.ZValue + 0.5) < ε)
            {
                // Left face was hit
                return new Vector3(0, 0, -1);
            }
            else if (Math.Abs(intersectionPoint.ZValue - 0.5) < ε)
            {
                // Right face was hit
                return new Vector3(0, 0, 1);
            }


            return null;
        }

    override
        public void toString()
        {
            Console.WriteLine("This is a box with material index - " + MaterialIndex);
        }
    }
}
