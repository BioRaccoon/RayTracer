using RayTracer.Utils;
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
        public double[,] CompositeMatrix { get; set; }

        public double ε = 1.0E-4;

        public abstract bool intersect(Ray ray, Hit hit);

        public void GeometricTransformations(List<Transformation> transformations, Camera camera)
        {

            Transformation transformation = transformations[TransformationIndex];

            CompositeMatrix = Transformation.IdentityMatrix();

            if (transformation.types.Count() > 0)
            {
                foreach (string types in transformation.types)
                {
                    List<String> type = types.Split(' ').ToList();
                    switch (type[0])
                    {
                        case "T":
                            CompositeMatrix = Transformation.Translate(
                                StaticFunctions.parseDouble(type[1]), 
                                StaticFunctions.parseDouble(type[2]),
                                StaticFunctions.parseDouble(type[3]), 
                                CompositeMatrix);
                            //Transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "S":
                            CompositeMatrix = Transformation.Scale(
                                StaticFunctions.parseDouble(type[1]), 
                                StaticFunctions.parseDouble(type[2]), 
                                StaticFunctions.parseDouble(type[3]),
                                CompositeMatrix);
                            //Transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Rx":
                            CompositeMatrix = Transformation.RotateX(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            //Transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Ry":
                            CompositeMatrix = Transformation.RotateY(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            //Transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Rz":
                            CompositeMatrix = Transformation.RotateZ(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            //Transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        default:
                            break;
                    }
                }
            }

            CompositeMatrix = Transformation.MultiplyWithMatrix(camera.CompositeMatrix, CompositeMatrix);

        }

        public abstract void toString();
    }
}
