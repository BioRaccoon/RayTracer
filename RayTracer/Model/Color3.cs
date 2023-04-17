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
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color3 CheckRange()
        {
            if (Red > 1.0) Red = 1.0;
            if (Blue > 1.0) Blue = 1.0;
            if (Green > 1.0) Green = 1.0;

            if (Red < 0.0) Red = 0.0;
            if (Blue < 0.0) Blue = 0.0;
            if (Green < 0.0) Green = 0.0;

            return this;
        }

        public string toString()
        {
            return Red + "," + Green + "," + Blue;
        }

        public Color3 multiply(Color3 colorToMultiplyBy)
        {
            return new Color3(Red * colorToMultiplyBy.Red, Green * colorToMultiplyBy.Green, Blue * colorToMultiplyBy.Blue);
        }

        public Color3 multiplyScalar(double scalar)
        {
            return new Color3(Red * scalar, Green * scalar, Blue * scalar);
        }

        public Color3 add(Color3 colorToAdd)
        {
            return new Color3(Red + colorToAdd.Red, Green + colorToAdd.Green, Blue + colorToAdd.Blue);
        }

        public Color3 divideScalar(int scalar)
        {
            if (scalar == 0) return this;
            return new Color3(Red / scalar, Green / scalar, Blue / scalar);
        }
    }
}
