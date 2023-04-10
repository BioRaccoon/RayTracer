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

            CompositeMatrix = transformation.TransformationMatrix;

            if (transformation.types.Count() > 0)
            {
                foreach (string types in transformation.types)
                {
                    List<String> type = types.Split(' ').ToList();
                    switch (type[0])
                    {
                        case "T":
                            CompositeMatrix = transformation.Translate(double.Parse(type[1]), double.Parse(type[2]), double.Parse(type[3]));
                            transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "S":
                            CompositeMatrix = transformation.Scale(double.Parse(type[1]), double.Parse(type[2]), double.Parse(type[3]));
                            transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Rx":
                            CompositeMatrix = transformation.RotateX(double.Parse(type[1]));
                            transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Ry":
                            CompositeMatrix = transformation.RotateY(double.Parse(type[1]));
                            transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        case "Rz":
                            CompositeMatrix = transformation.RotateZ(double.Parse(type[1]));
                            transformation.TransformationMatrix = CompositeMatrix;
                            break;
                        default:
                            break;
                    }
                }
            }

            Transformation trans = transformations[camera.TransformationIndex];

            Transformation copy = new Transformation(trans.TransformationMatrix);

            CompositeMatrix = copy.MultiplyWithMatrix(CompositeMatrix);

            Transformation lightTrans = new Transformation(CompositeMatrix);

            double[] positionMatrix = lightTrans.MultiplyWithPoint(new Vector4(0, 0, 0, 1), new Vector4(0, 0, 0, 1));

            Position = new Vector4(positionMatrix[0], positionMatrix[1], positionMatrix[2], positionMatrix[3]).ConvertVectorToCartesian();

        }

    }
}
