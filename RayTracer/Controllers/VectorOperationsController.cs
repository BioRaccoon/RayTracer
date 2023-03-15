using RayTracer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Controllers
{
    internal class VectorOperationsController
    {
        public VectorOperationsController() { }

        public void CalcNormals(List<Triangle> triangles)
        {
            foreach (Triangle triangle in triangles)
            {
               Vector3 edgeAB = new Vector3(triangle.SecondVertex.Subtract(triangle.FirstVertex));
               Vector3 edgeBC = new Vector3(triangle.ThirdVertex.Subtract(triangle.FirstVertex));
               Vector3 normalVector = edgeAB.CrossProduct(edgeBC);
               triangle.addNormalVector(normalVector.Normalize());
            }
        }
    }
}
