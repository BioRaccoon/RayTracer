using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    /// <summary>
    /// Classe que representa uma cor em valores de Vermelho, Verde e Azul. (RGB)
    /// </summary>
    internal class Color3
    {
        // O valor vermelho da cor.
        private readonly double _red;
        // O valor verde da cor.
        private readonly double _green;
        // O valor azul da cor.
        private readonly double _blue;

        /// <summary>
        /// O construtor da classe. Leva como parâmetros os valores das componentes da cor, entre 0.0 e 1.0.
        /// A verificação é feita logo ao ser chamado o construtor.
        /// </summary>
        /// <param name="red">O valor vermelho da cor.</param>
        /// <param name="green">O valor verde da cor.</param>
        /// <param name="blue">O valor azul da cor.</param>
        public Color3(double red, double green, double blue){
            if ((red < 0.0 || red > 1.0) && (green < 0.0 || green > 1.0) && (blue < 0.0 || blue > 1.0))
            {

            }

        }
    }
}
