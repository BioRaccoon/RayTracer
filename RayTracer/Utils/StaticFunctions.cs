using RayTracer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Utils
{
    internal class StaticFunctions
    {
        
        public static double parseDouble(string stringInput)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;

            // Verificar o símbolo utilizado para separar a parte decimal
            string decimalSeparator = culture.NumberFormat.NumberDecimalSeparator;
            //Console.WriteLine($"Símbolo utilizado para separar a parte decimal: '{decimalSeparator}'");
            double result;

            // Tentar fazer o parse diretamente
            if (double.TryParse(stringInput, out result))
            {
                //Console.WriteLine($"O número parseado é: {result}");
                return result;
            }
            else
            {
                // Se o parse falhar, substituir o símbolo incorreto pelo símbolo correto e tentar novamente
                stringInput = stringInput.Replace(decimalSeparator == "." ? ";" : ".", decimalSeparator == "." ? "." : ",");
                if (double.TryParse(stringInput, out result))
                {
                    //Console.WriteLine($"O número parseado é: {result}");
                    return result;
                }
                else
                {
                    //Console.WriteLine("Falha ao fazer o parse do número.");
                }
            }
            return result;
        }

        public static Vector3 ConvertPointToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertPointToHomogenous();

            double[] vectorMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, vectorHomogeneous);

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertPointToCartesian();

            return vectorCartesian;
        }

        public static Vector3 ConvertPointToObjectCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertPointToHomogenous();

            CompositeMatrix = Transformation.InvertMatrix(CompositeMatrix);

            double[] vectorMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, vectorHomogeneous);

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertPointToCartesian();

            return vectorCartesian;
        }

        public static Vector3 ConvertVectorToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            double[] vectorMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, vectorHomogeneous);

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }

        public static Vector3 ConvertVectorToObjectCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            CompositeMatrix = Transformation.InvertMatrix(CompositeMatrix);

            double[] vectorMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, vectorHomogeneous);

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }

        public static Vector3 ConvertObjectNormalToWorldCoordinates(Vector3 vectorCartesian, double[,] CompositeMatrix)
        {
            Vector4 vectorHomogeneous = vectorCartesian.ConvertVectorToHomogenous();

            CompositeMatrix = Transformation.InvertMatrix(CompositeMatrix);

            CompositeMatrix = Transformation.TransposeMatrix(CompositeMatrix);

            double[] vectorMatrix = Transformation.MultiplyWithPoint(CompositeMatrix, vectorHomogeneous);

            vectorHomogeneous = new Vector4(vectorMatrix[0], vectorMatrix[1], vectorMatrix[2], vectorMatrix[3]);

            vectorCartesian = vectorHomogeneous.ConvertVectorToCartesian();

            return vectorCartesian.Normalize();
        }

    }
}
