using System;

namespace RayTracer.Model
{
    /// <summary>
    /// Classe que representa Pontos e Vetores num espaço 3D usando coordenadas cartesianas.
    /// </summary>
    internal class Vector3
    {
        /// <summary>
        /// O valor de X.
        /// </summary>
        public double XValue { get; set; }
        /// <summary>
        /// O valor de Y.
        /// </summary>
        public double YValue { get; set; }
        /// <summary>
        /// O valor do Z.
        /// </summary>
        public double ZValue { get; set; }

        /// <summary>
        /// Construtor de vetores e pontos 3D.
        /// </summary>
        /// <param name="x">O valor de X.</param>
        /// <param name="y">O valor de Y.</param>
        /// <param name="z">O valor de Z.</param>
        public Vector3(double x, double y, double z)
        {
            XValue = x;
            YValue = y;
            ZValue = z;
        }

        public Vector3(Vector3 vector3)
        {
            XValue = vector3.XValue;
            YValue = vector3.YValue;
            ZValue = vector3.ZValue;
        }

        /// <summary>
        /// Método para verificar se dois Vetores são iguais.
        /// </summary>
        /// <param name="anotherVector">O vetor para comparar.</param>
        /// <returns>Verdadeiro ou falso, dependedo da equalidade dos Vetores.</returns>
        public bool EqualsVector3(Vector3 anotherVector)
        {
            if (XValue != anotherVector.XValue || YValue != anotherVector.YValue || ZValue != anotherVector.ZValue)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Função para adicionar dois vetores.
        /// </summary>
        /// <param name="anotherVector">O vetor a adicionar.</param>
        /// <returns>O vetor resultante da adição.</returns>
        public Vector3 Add(Vector3 anotherVector)
        {
            return new Vector3
                (XValue + anotherVector.XValue,
                YValue + anotherVector.YValue,
                ZValue + anotherVector.ZValue);
        }

        /// <summary>
        /// Função para subtrair dois vetores.
        /// </summary>
        /// <param name="anotherVector">O vetor a subtrair.</param>
        /// <returns>O vetor resultante da subtração.</returns>
        public Vector3 Subtract(Vector3 anotherVector)
        {
            return new Vector3
                (XValue - anotherVector.XValue,
                YValue - anotherVector.YValue,
                ZValue - anotherVector.ZValue);
        }

        /// <summary>
        /// Função para multipicar um vetor, por um escalar Real.
        /// </summary>
        /// <param name="scalar">Um valor Real para multiplicar pelo vetor.</param>
        /// <returns>O vetor escalado.</returns>
        public Vector3 ScalarMultiplication(double scalar)
        {
            return new Vector3
                (XValue * scalar,
                YValue * scalar,
                ZValue * scalar);
        }
        /// <summary>
        /// Função que retorna o produto escalar de dois vetores.
        /// </summary>
        /// <param name="anotherVector">O outro vetor a usar para o produto.</param>
        /// <returns>Um escalar.</returns>
        public double DotProduct(Vector3 anotherVector)
        {
            return XValue * anotherVector.XValue + 
                YValue * anotherVector.YValue +
                ZValue * anotherVector.ZValue;
        }
        /// <summary>
        /// Função que usa a implementação do DotProduct para calcular o comprimento de um vetor.
        /// </summary>
        /// <returns>O comprimento do Vetor, usando a raiz quadrada do DotProduct.</returns>
        public double Length()
        {
            return Math.Sqrt(DotProduct(this));
        }

        /// <summary>
        /// Função que muda o comprimento do vetor para a unidade. (Normaliza o vetor).
        /// </summary>
        /// <returns>O mesmo vetor, normalizado.</returns>
        public Vector3 Normalize()
        {
            return ScalarMultiplication(1/Length());
        }
        /// <summary>
        /// Função que retorna o produto de vetores que resulta numa normal (pseudo-vectorial) entre dois vetores.
        /// Componentes negativas ou positivas indicam a direção do vetor de acordo com a regra da mão direita.
        /// </summary>
        /// <param name="anotherVector">O outro vetor para calcular o produto.</param>
        /// <returns>A normal (pseudo-vetorial) entre dois vetores.</returns>
        public Vector3 CrossProduct(Vector3 anotherVector)
        {
            return new Vector3(
                (YValue * anotherVector.ZValue - ZValue * anotherVector.YValue),
                (ZValue * anotherVector.XValue - XValue * anotherVector.ZValue),
                (XValue * anotherVector.YValue - YValue * anotherVector.XValue)
            );
        }

        public Vector4 ConvertVectorToHomogenous()
        {
            return new Vector4(XValue,YValue,ZValue, 0.0);
        }

        public Vector4 ConvertPointToHomogenous()
        {
            return new Vector4(XValue, YValue, ZValue, 1.0);
        }

    }
}
