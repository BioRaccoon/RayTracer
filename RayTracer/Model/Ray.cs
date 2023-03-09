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

        public Ray(Vector3 Origin, Vector3 Direction)
        {
            this.Origin = Origin;
            this.Direction = Direction;
        }

        public Vector3 getPointInLine(double totalDistance)
        {
            return Origin.Add(Direction.ScalarMultiplication(totalDistance));
        }
    }
}
