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

        double ε = 1E-6;

        override
        public bool intersect(Ray ray, Hit hit)
        {

            ray.Origin = StaticFunctions.ConvertPointToObjectCoordinates(ray.Origin, CompositeMatrix);
            ray.Direction = StaticFunctions.ConvertVectorToObjectCoordinates(ray.Direction, CompositeMatrix);

            Vector3 boxMin = firstVextex;
            Vector3 boxMax = secondVextex;

            double tFar = 1.0E6;
            double tNear = -1.0E6;

            /////////////////////// X axis ///////////////////////

            if (!checkIfRayIsParallel(ray.Origin.XValue, ray.Direction.XValue, boxMin.XValue, boxMax.XValue)) return false;

            double txmin = calculateIntersectionDistance(boxMin.XValue, ray.Origin.XValue, ray.Direction.XValue);
            double txmax = calculateIntersectionDistance(boxMax.XValue, ray.Origin.XValue, ray.Direction.XValue);

            if (txmin > txmax) // If tx1 > tx2, swap
            {
                double temp = txmin;
                txmin = txmax;
                txmax = temp;
            }

            if (txmin > tNear) tNear = txmin;

            if (txmax < tFar) tFar = txmax;

            if(tNear > tFar) return false; // box is missed

            if (tFar < 0) return false; // box is behind

            /////////////////////// Y axis ///////////////////////

            if (!checkIfRayIsParallel(ray.Origin.YValue, ray.Direction.YValue, boxMin.YValue, boxMax.YValue)) return false;

            double tymin = calculateIntersectionDistance(boxMin.YValue, ray.Origin.YValue, ray.Direction.YValue);
            double tymax = calculateIntersectionDistance(boxMax.YValue, ray.Origin.YValue, ray.Direction.YValue);

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

            if (!checkIfRayIsParallel(ray.Origin.ZValue, ray.Direction.ZValue, boxMin.ZValue, boxMax.ZValue)) return false;

            double tzmin = calculateIntersectionDistance(boxMin.ZValue, ray.Origin.ZValue, ray.Direction.ZValue);
            double tzmax = calculateIntersectionDistance(boxMax.ZValue, ray.Origin.ZValue, ray.Direction.ZValue);

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

            Vector3 intersectionPoint = ray.Direction.ScalarMultiplication(tNear).Add(ray.Origin);

            /////////////////////////////////////////////
            intersectionPoint = StaticFunctions.ConvertPointToWorldCoordinates(intersectionPoint, CompositeMatrix);
            /////////////////////////////////////////////

            hit.Found = true;
            hit.TotalDistance = tNear;
            if (hit.TotalDistance < hit.FoundDistance)
            {
                hit.FoundDistance = hit.TotalDistance;
            }
            hit.IntersectionPoint = intersectionPoint;
            hit.NormalVector = checkWhichBoxFaceWasHit(tNear, txmin, txmax, tymin, tymax, tzmin, tzmax);
            hit.NormalVector = StaticFunctions.ConvertObjectNormalToWorldCoordinates(hit.NormalVector, CompositeMatrix);

            return true;
        }

        public Vector3 checkWhichBoxFaceWasHit(double tNear, double txmin, double txmax, double tymin, double tymax, double tzmin, double tzmax)
        {

            // Check which face was hit
            if (tNear == txmin)
            {
                // Front face was hit
                return new Vector3(-1, 0, 0);
            }
            else if (tNear == txmax)
            {
                // Back face was hit
                return new Vector3(1, 0, 0);
            }
            else if (tNear == tymin)
            {
                // Bottom face was hit
                return new Vector3(0, -1, 0);
            }
            else if (tNear == tymax)
            {
                // Top face was hit
                return new Vector3(0, 1, 0);
            }
            else if (tNear == tzmin)
            {
                // Left face was hit
                return new Vector3(0, 0, -1);
            }
            else if (tNear == tzmax)
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
