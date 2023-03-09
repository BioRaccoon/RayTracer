using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Transformation
    {
        double[,] TransformationMatrix = new double[4, 4];

        public Transformation(double[,] transformationMatrix)
        {
            TransformationMatrix = transformationMatrix;
        }
    }
}
