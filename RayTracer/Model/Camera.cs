using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Camera
    {
        public int TransformationIndex { get; set; }
        public double Distance { get; set; }
        public double FieldOfView { get; set; }
        public double[,] CompositeMatrix { get; set; }

        public Camera(int cameraTransformationIndex, double cameraDistance, double fov)
        {
            TransformationIndex = cameraTransformationIndex;
            Distance = cameraDistance;
            FieldOfView = fov;  
        }

        public void GeometricTransformations(List<Transformation> transformations)
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
                            break;
                        case "S":
                            CompositeMatrix = Transformation.Scale(
                                StaticFunctions.parseDouble(type[1]),
                                StaticFunctions.parseDouble(type[2]),
                                StaticFunctions.parseDouble(type[3]),
                                CompositeMatrix);
                            break;
                        case "Rx":
                            CompositeMatrix = Transformation.RotateX(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            break;
                        case "Ry":
                            CompositeMatrix = Transformation.RotateY(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            break;
                        case "Rz":
                            CompositeMatrix = Transformation.RotateZ(
                                StaticFunctions.parseDouble(type[1]),
                                CompositeMatrix);
                            break;
                        default:
                            break;
                    }
                }
            }

        }
    }
}
