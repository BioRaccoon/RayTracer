using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    /// <summary>
    /// Classe que representa a Imagem a gerar.
    /// </summary>
    internal class Image
    {
        /// <summary>
        /// O comprimento da imagem em pixeis.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// A largura da imagem em pixeis.
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// A cor de fundo da imagem.
        /// </summary>
        public Color3 BackgroundColor { get; set; }

        public Image(int length, int width, Color3 backgroundColor) {
            if (length < 0) { 
                throw new ArgumentOutOfRangeException("length", "The length cannot be below zero!");
            }
            if (width < 0)
            {
                throw new ArgumentOutOfRangeException("length", "The width cannot be below zero!");
            }

            Length = length;
            Width = width;
            BackgroundColor = backgroundColor;
        }
    }
}
