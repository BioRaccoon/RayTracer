using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal abstract class Object3D
    {
        public int TransformationIndex { get; set; }
        public int MaterialIndex { get; set; }

        public abstract bool intersect(Ray ray, Hit hit);

        public abstract void toString();
    }
}
