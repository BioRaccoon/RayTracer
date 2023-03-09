using RayTracer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Controllers
{
    internal class VectorOperationsController
    {

        public VectorOperationsController() { }

        public List<Vector3> CalcNormals()
        {
            List<Vector3> result = new List<Vector3>();
            List<Triangle> triangles = new List<Triangle>();
            foreach (Triangle triangle in triangles)
            {
               Vector3 edgeAB = new Vector3( triangle.SecondVertex.Subtract(triangle.FirstVertex));
               Vector3 edgeBC = new Vector3(triangle.SecondVertex.Subtract(triangle.FirstVertex));

            }
            return result;
        }
    }
}
