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

        public double[,]  IdentityMatrix()
        {
            double[,] result = new double[4, 4] { {1.0, 0 ,0 ,0 },
                {0, 1.0 ,0 ,0 },
                {0, 0 ,1.0 ,0 },
                {0, 0 ,0 ,1.0 }
            };
            return result;
        }


        public double[] MultiplyWithPoint(Vector4 pointA, Vector4 pointB) 
        {

            double[] pointAMatrix = pointA.ConvertToMatrix();
            double[] pointBMatrix = pointB.ConvertToMatrix();

            int i, j;

            for (i = 0; i < 4; i++)
                pointBMatrix[i] = 0.0;
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    pointBMatrix[i] += TransformationMatrix[i, j] * pointAMatrix[j];
            return pointBMatrix;
        }

        public double[,] MultiplyWithMatrix(double [,] matrixA)
        {
            if (matrixA.GetLength(1) != 4) throw new Exception("The array length must be 4.");
            int i, j, k;
            double[,] matrixB = new double[4,4];
            double[,] result = new double[4,4];

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    matrixB[i,j] = TransformationMatrix[i,j];
                    result[i,j] = 0.0;
                }
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    for (k = 0; k < 4; k++)
                        result[i,j] += matrixB[i,k] * matrixA[k,j];
            return result;
        }

        public double[,] Translate(double x, double y, double z)
        {
            double[,] result = new double[4,4];

            result[0,0] = 1.0;
            result[0,1] = 0.0;
            result[0,2] = 0.0;
            result[0,3] = x;
            result[1,0] = 0.0;
            result[1,1] = 1.0;
            result[1,2] = 0.0;
            result[1,3] = y;
            result[2,0] = 0.0;
            result[2,1] = 0.0;
            result[2,2] = 1.0;
            result[2,3] = z;
            result[3,0] = 0.0;
            result[3,1] = 0.0;
            result[3,2] = 0.0;
            result[3,3] = 1.0;

            result = MultiplyWithMatrix(result);

            return result;
        }

        public double[,] TransposeMatrix(double[,] matrix)
        {
            int xLength = matrix.GetLength(0);
            int yLength = matrix.GetLength(1);

            double[,] transposedMatrix = new double[yLength, xLength];

            for (int i = 0; i < xLength; i++)
            {
                for (int j = 0; j < yLength; j++)
                {
                    transposedMatrix[j, i] = matrix[i, j];
                }
            }

            return transposedMatrix;
        }

        public double[,] rotateX(double a) 
        {
            double [,] rotateXMatrix = new double[4,4];

            a *= Math.PI / 180.0;
            rotateXMatrix[0,0] = 1.0;
            rotateXMatrix[0,1] = 0.0;
            rotateXMatrix[0, 2] = 0.0;
            rotateXMatrix[0, 3] = 0.0;
            rotateXMatrix[1, 0] = 0.0;
            rotateXMatrix[1, 1] = Math.Cos(a);
            rotateXMatrix[1, 2] = -Math.Sin(a);
            rotateXMatrix[1, 3] = 0.0;
            rotateXMatrix[2, 0] = 0.0;
            rotateXMatrix[2, 1] = Math.Sin(a);
            rotateXMatrix[2, 2] = Math.Cos(a);
            rotateXMatrix[2, 3] = 0.0;
            rotateXMatrix[3, 0] = 0.0;
            rotateXMatrix[3, 1] = 0.0;
            rotateXMatrix[3, 2] = 0.0;
            rotateXMatrix[3, 3] = 1.0;

            return MultiplyWithMatrix(rotateXMatrix);
        }
    }
}
