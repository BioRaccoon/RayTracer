﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracer.Model
{
    internal class Transformation
    {
        public List<string> types { get; set; }
        public double[,] TransformationMatrix {get; set;}

        public Transformation(List<string> types)
        {
            this.types = types;
            TransformationMatrix = IdentityMatrix();
        }

        public Transformation(double[,] transformationMatrix) {
            TransformationMatrix = transformationMatrix;
        }

        public static double[,] IdentityMatrix()
        {
            double[,] identityMatrix = new double[4, 4];

            identityMatrix[0, 0] = 1.0;
            identityMatrix[0, 1] = 0.0;
            identityMatrix[0, 2] = 0.0;
            identityMatrix[0, 3] = 0.0;
            identityMatrix[1, 0] = 0.0;
            identityMatrix[1, 1] = 1.0;
            identityMatrix[1, 2] = 0.0;
            identityMatrix[1, 3] = 0.0;
            identityMatrix[2, 0] = 0.0;
            identityMatrix[2, 1] = 0.0;
            identityMatrix[2, 2] = 1.0;
            identityMatrix[2, 3] = 0.0;
            identityMatrix[3, 0] = 0.0;
            identityMatrix[3, 1] = 0.0;
            identityMatrix[3, 2] = 0.0;
            identityMatrix[3, 3] = 1.0;

            return identityMatrix;
        }

        /*public double[] MultiplyWithPoint(Vector4 pointA, Vector4 pointB) 
        {

            double[] pointAMatrix = pointA.ConvertToMatrix();
            double[] pointBMatrix = pointB.ConvertToMatrix();

            int i, j;

            for (i = 0; i < 4; i++)
            {
                pointBMatrix[i] = 0.0;
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    pointBMatrix[i] += TransformationMatrix[i, j] * pointAMatrix[j];
                }
            }
            return pointBMatrix;
        }*/

        public static double[] MultiplyWithPoint(double[,] matrix, Vector4 pointA)
        {

            double[] pointAMatrix = pointA.ConvertToMatrix();
            double[] pointBMatrix = {0.0, 0.0, 0.0, 0.0};

            int i, j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    pointBMatrix[i] += matrix[i, j] * pointAMatrix[j];
                }
            }
            return pointBMatrix;
        }

        /*public double[,] MultiplyWithMatrix(double[,] matrixA) // multiplica duas matrizes 4 x 4
        {
            if (matrixA.GetLength(1) != 4) throw new Exception("The array length must be 4.");

            int i, j, k;
            double[,] matrixB = new double[4, 4];
            double[,] result = new double[4, 4];

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    matrixB[i, j] = TransformationMatrix[i, j];
                    result[i, j] = 0.0;
                }
            }
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    for (k = 0; k < 4; k++)
                    {
                        result[i, j] += matrixB[i, k] * matrixA[k, j];
                    }
                }
            }
            return result;
        }*/

        public static double[,] MultiplyWithMatrix(double[,] matrix1, double[,] matrix2)
        {
            // Verificar as dimensões das matrizes
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new ArgumentException("O número de colunas da primeira matriz deve ser igual ao número de linhas da segunda matriz.");
            }

            // Criar uma matriz para armazenar o resultado
            double[,] result = new double[4, 4];

            // Realizar a multiplicação das matrizes
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        result[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }

            return result;
        }

        public static double[,] Translate(double x, double y, double z, double[,] matrix)
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

            return MultiplyWithMatrix(matrix, result);
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            double[,] result = new double[columns, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public static double[,] RotateX(double a, double[,] matrix) 
        {
            double [,] rotateXMatrix = new double[4,4];

            a *= Math.PI / 180.0;
            rotateXMatrix[0, 0] = 1.0;
            rotateXMatrix[0, 1] = 0.0;
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

            return MultiplyWithMatrix(matrix, rotateXMatrix);
        }


        public static double[,] RotateY(double a, double[,] matrix) // cria a matriz correspondente à rotação em torno do eixo Y e multiplica a matriz de transformação composta pela matriz recém-criada
        {
            double[,] rotateYMatrix = new double[4, 4];

            a *= Math.PI / 180.0;
            rotateYMatrix[0,0] = Math.Cos(a);
            rotateYMatrix[0,1] = 0.0;
            rotateYMatrix[0,2] = Math.Sin(a);
            rotateYMatrix[0,3] = 0.0;
            rotateYMatrix[1,0] = 0.0;
            rotateYMatrix[1,1] = 1.0;
            rotateYMatrix[1,2] = 0.0;
            rotateYMatrix[1,3] = 0.0;
            rotateYMatrix[2,0] = -Math.Sin(a);
            rotateYMatrix[2,1] = 0.0;
            rotateYMatrix[2,2] = Math.Cos(a);
            rotateYMatrix[2,3] = 0.0;
            rotateYMatrix[3,0] = 0.0;
            rotateYMatrix[3,1] = 0.0;
            rotateYMatrix[3,2] = 0.0;
            rotateYMatrix[3,3] = 1.0;
            return MultiplyWithMatrix(matrix, rotateYMatrix);
        }

        public static double[,] RotateZ(double a, double[,] matrix) // cria a matriz correspondente à rotação em torno do eixo Y e multiplica a matriz de transformação composta pela matriz recém-criada
        {
            double[,] rotateZMatrix = new double[4, 4];

            a *= Math.PI / 180.0;
            rotateZMatrix[0, 0] = Math.Cos(a);
            rotateZMatrix[0, 1] = -Math.Sin(a);
            rotateZMatrix[0, 2] = 0.0;
            rotateZMatrix[0, 3] = 0.0;
            rotateZMatrix[1, 0] = Math.Sin(a);
            rotateZMatrix[1, 1] = Math.Cos(a);
            rotateZMatrix[1, 2] = 0.0;
            rotateZMatrix[1, 3] = 0.0;
            rotateZMatrix[2, 0] = 0.0;
            rotateZMatrix[2, 1] = 0.0;
            rotateZMatrix[2, 2] = 1.0;
            rotateZMatrix[2, 3] = 0.0;
            rotateZMatrix[3, 0] = 0.0;
            rotateZMatrix[3, 1] = 0.0;
            rotateZMatrix[3, 2] = 0.0;
            rotateZMatrix[3, 3] = 1.0;
            return MultiplyWithMatrix(matrix, rotateZMatrix);
        }

        public static double[,] Scale(double x, double y, double z, double[,] matrix)
        {
            double [,] scaleMatrix = new double [4,4];

            scaleMatrix[0,0] = x;
            scaleMatrix[0,1] = 0.0;
            scaleMatrix[0,2] = 0.0;
            scaleMatrix[0,3] = 0.0;
            scaleMatrix[1,0] = 0.0;
            scaleMatrix[1,1] = y;
            scaleMatrix[1,2] = 0.0;
            scaleMatrix[1,3] = 0.0;
            scaleMatrix[2,0] = 0.0;
            scaleMatrix[2,1] = 0.0;
            scaleMatrix[2,2] = z;
            scaleMatrix[2,3] = 0.0;
            scaleMatrix[3,0] = 0.0;
            scaleMatrix[3,1] = 0.0;
            scaleMatrix[3,2] = 0.0;
            scaleMatrix[3,3] = 1.0;
            return MultiplyWithMatrix(matrix, scaleMatrix);
        }

        // Using Gaussian elimination method
        public static double[,] InvertMatrix(double[,] matrix)
        {
            // Check if matrix is square
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
            {
                throw new ArgumentException("Matrix must be square.");
            }

            // Create an identity matrix
            double[,] identity = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                identity[i, i] = 1.0;
            }

            // Copy the input matrix to a new matrix to avoid modifying the original
            double[,] A = new double[n, n];
            Array.Copy(matrix, A, n * n);

            // Forward elimination
            for (int i = 0; i < n; i++)
            {
                double pivot = A[i, i];

                if (pivot == 0.0)
                {
                    throw new ArgumentException("Matrix is singular and cannot be inverted.");
                }

                for (int j = i + 1; j < n; j++)
                {
                    double factor = A[j, i] / pivot;
                    for (int k = 0; k < n; k++)
                    {
                        A[j, k] -= factor * A[i, k];
                        identity[j, k] -= factor * identity[i, k];
                    }
                }
            }

            // Backward substitution
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    double factor = A[j, i] / A[i, i];
                    for (int k = 0; k < n; k++)
                    {
                        A[j, k] -= factor * A[i, k];
                        identity[j, k] -= factor * identity[i, k];
                    }
                }
            }

            // Scale the rows of the identity matrix to obtain the inverse
            double[,] inverse = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                double scale = A[i, i];
                for (int j = 0; j < n; j++)
                {
                    inverse[i, j] = identity[i, j] / scale;
                }
            }

            return inverse;
        }


    }
}
