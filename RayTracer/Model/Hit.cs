using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Hit
    {
        public bool Found { get; set; }
        public Material MaterialHit { get; set; }
        public Vector3 IntersectionPoint { get; set; }
        public Vector3 NormalVector { get; set; }
        public double TotalDistance { get; set; }
        public double FoundDistance { get; set; }

        public Hit(bool foundHit, Material materialHit, Vector3 intersectionPoint, Vector3 normal, double distance, double foundDistance) {
            Found = foundHit;
            MaterialHit = materialHit;
            IntersectionPoint = intersectionPoint;
            NormalVector = normal;
            TotalDistance = distance;
            FoundDistance = foundDistance;
        }

        public Hit()
        {
        }


    }
}
