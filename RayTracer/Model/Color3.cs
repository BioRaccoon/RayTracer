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

        public double Red { get; set; }

        // O valor verde da cor.
        public double Green { get; set; }

        // O valor azul da cor.
        public double Blue { get; set; }

        /// <summary>
        /// O construtor da classe. Leva como parâmetros os valores das componentes da cor, entre 0.0 e 1.0.
        /// As verificações são feitas quando o construtor é chamado.
        /// </summary>
        /// <param name="red">O valor vermelho da cor.</param>
        /// <param name="green">O valor verde da cor.</param>
        /// <param name="blue">O valor azul da cor.</param>
        public Color3(double red, double green, double blue){

            if (red < 0.0 || red > 1.0)
            {
                throw new ArgumentOutOfRangeException("red","The red value is not between 0 and 1!");
            }

            if (green < 0.0 || green > 1.0)
            {
                throw new ArgumentOutOfRangeException("green", "The green value is not between 0 and 1!");
            }

            if(blue < 0.0 || blue > 1.0)
            {
                throw new ArgumentOutOfRangeException("blue", "The blue value is not between 0 and 1!");
            }

            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
