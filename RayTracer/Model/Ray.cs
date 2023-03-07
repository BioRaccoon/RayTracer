using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracer.Model
{
    /// <summary>
    /// Classe que representa um raio de luz no espaço.
    /// </summary>
    internal class Ray
    {
        /// <summary>
        /// A origem do raio de luz.
        /// </summary>
        public Vector3 Origin { get; set; }
        /// <summary>
        /// A direção do raio de luz.
        /// </summary>
        public Vector3 Direction { get; set; }
        /// <summary>
        /// A distância total do raio de luz à superfície alvo.
        /// </summary>
        //public int TotalDistance { get; set; }

        public Ray(Vector3 Origin, Vector3 Direction/*, int TotalDistance*/)
        {
            this.Origin = Origin;
            this.Direction = Direction;
            //this.TotalDistance = TotalDistance; //TODO: Não sei se isto é um parâmetro, mas é melhor perguntar
        }

        public Vector3 getPointInLine(double totalDistance)
        {
            return Origin.Add(Direction.ScalarMultiplication(totalDistance));
        }
    }
}
