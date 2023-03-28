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

        public void MultiplyWithMatrix(double [,] matrixA)
        {
            if (matrixA.GetLength(1) != 4) return;
            int i, j, k;
            double[,] matrixB = new double[4,4];

            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                {
                    matrixB[i,j] = TransformationMatrix[i,j];
                    TransformationMatrix[i,j] = 0.0;
                }
            for (i = 0; i < 4; i++)
                for (j = 0; j < 4; j++)
                    for (k = 0; k < 4; k++)
                        TransformationMatrix[i,j] += matrixB[i,k] * matrixA[k,j];
        }
    }
}
