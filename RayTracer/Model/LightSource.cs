using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class LightSource
    {
        public int TransformationIndex { get; set; }
        public Color3 Intensity { get; set; }
        public Vector3 Position { get; set; }
        public double[,] CompositeMatrix { get; set; }

        public LightSource(int LightTransformationIndex, Color3 lightIntensity)
        {
            TransformationIndex = LightTransformationIndex;
            Intensity = lightIntensity;
        }

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

            CompositeMatrix = Transformation.MultiplyWithMatrix(camera.CompositeMatrix, CompositeMatrix);

            double[] positionMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, new Vector4 (0,0,0,1));

            Position = new Vector4(positionMatrix[0], positionMatrix[1], positionMatrix[2], positionMatrix[3]).ConvertVectorToCartesian();

        }

    }
}
