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

        public abstract bool intersect(Ray ray, Hit hit);

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

            // Swap Composite Matrixes to do T1 (Camera) * T2 (Object3D) instead of T2 * T1 because T1*T2 != T2*T1
            //transformation.TransformationMatrix = camera.CompositeMatrix;

            Transformation trans = transformations[camera.TransformationIndex];

            Transformation copy = new Transformation(trans.TransformationMatrix);

            CompositeMatrix = copy.MultiplyWithMatrix(CompositeMatrix);

            double[,] mamamia = new double[3, 3] { 
                { 8,
99.301136384401332,
0.12331420466224388 },
            { 0,
19.333465438440257,
-0.89769511244927858 },
            {  0,
-28.707481841757051,
-0.42300956491927666}} ;

            double[,] mama = new double[3, 3] {
                { 8,
8,
0.12331420466224388     },
            { 0,
8,
-0.89769511244927858     },
            { 0,
0,
-0.42300956491927666    }};

            double AAAAAA = matrixDeterminant(mamamia);
            double ad = matrixDeterminant(mama);

            double lol = AAAAAA/ad;

        }

        public double matrixDeterminant(double[,] matrix)
        {

            return (matrix[0, 0] * matrix[1, 1] * matrix[2, 2]) +
                   (matrix[0, 1] * matrix[1, 2] * matrix[2, 0]) +
                   (matrix[0, 2] * matrix[1, 0] * matrix[2, 1]) -
                   (matrix[0, 2] * matrix[1, 1] * matrix[2, 0]) -
                   (matrix[0, 1] * matrix[1, 0] * matrix[2, 2]) -
                   (matrix[0, 0] * matrix[1, 2] * matrix[2, 1]);
        }

        public abstract void toString();
    }
}
