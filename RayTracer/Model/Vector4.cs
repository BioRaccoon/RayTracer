using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    /// <summary>
    /// Classe que representa Pontos e Vetores num espaço 3D usando coordenadas homogéneas.
    /// </summary>
    internal class Vector4
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
        /// O valor do W.
        /// </summary>
        public double Wvalue { get; set; }

        /// <summary>
        /// Construtor de vetores e pontos 3D em coordenadas homogéneas.
        /// </summary>
        /// <param name="x">O valor de X.</param>
        /// <param name="y">O valor de Y.</param>
        /// <param name="z">O valor de Z.</param>
        /// <param name="w">O valor de W.</param>
        public Vector4(double x, double y, double z, double w)
        {
            XValue = x;
            YValue = y;
            ZValue = z;
            Wvalue = w;
        }


        public Vector3 ConvertVectorToCartesian()
        {
            return new Vector3(XValue, YValue, ZValue);
        }

        public Vector3 ConvertPointToCartesian()
        {
            return new Vector3(XValue / Wvalue,
                YValue / Wvalue,
                ZValue / Wvalue
                );
        }
    }
}
