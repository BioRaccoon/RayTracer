using RayTracer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Utils
{
    internal class StaticFunctions
    {
        /*public static Vector3 ConvertPointToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertPointToHomogenous();

            Transformation transformation = new Transformation(CompositeMatrix);

            double[] vectorMatrix = transformation.MultiplyWithPoint(vectorHomogeneous, new Vector4(0, 0, 0, 0));

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertPointToCartesian();

            return vectorCartesian;
        }

        public static Vector3 ConvertPointToObjectCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertPointToHomogenous();

            Transformation transformation = new Transformation(CompositeMatrix);

            transformation.TransformationMatrix = transformation.InvertMatrix(CompositeMatrix);

            double[] vectorMatrix = transformation.MultiplyWithPoint(vectorHomogeneous, new Vector4(0, 0, 0, 0));

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertPointToCartesian();

            return vectorCartesian;
        }

        public static Vector3 ConvertVectorToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            Transformation transformation = new Transformation(CompositeMatrix);

            double[] vectorMatrix = transformation.MultiplyWithPoint(vectorHomogeneous, new Vector4(0, 0, 0, 0));

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }

        public static Vector3 ConvertVectorToObjectCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            Transformation transformation = new Transformation(CompositeMatrix);

            transformation.TransformationMatrix = transformation.InvertMatrix(CompositeMatrix);

            double[] vectorMatrix = transformation.MultiplyWithPoint(vectorHomogeneous, new Vector4(0, 0, 0, 0));

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }

        public static Vector3 ConvertObjectNormalToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            Transformation transformation = new Transformation(CompositeMatrix);

            transformation.TransformationMatrix = transformation.TransposeMatrix(transformation.InvertMatrix(CompositeMatrix));

            double[] vectorMatrix = transformation.MultiplyWithPoint(vectorHomogeneous, new Vector4(0, 0, 0, 0));

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }*/

    }
}
