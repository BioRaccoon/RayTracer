using System;
using System.Collections.Generic;
using System.Linq;
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

        public Triangle(int TransformationIndex,int MaterialIndex ,Vector3 first, Vector3 second, Vector3 third)
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

        public void addNormalVector(Vector3 normal)
        {
            Normal = normal;
        }
}
}
