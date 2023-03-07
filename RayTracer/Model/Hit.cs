using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Hit
    {
        bool Found { get; set; }
        Material MaterialHit { get; set; }
        Vector3 IntersectionPoint { get; set; }
        Vector3 NormalVector { get; set; }
        double TotalDistance { get; set; }
        double FoundDistance { get; set; }

        public Hit(bool foundHit, Material materialHit, Vector3 intersectionPoint, Vector3 normal, double distance, double foundDistance) {
            Found = foundHit;
            MaterialHit = materialHit;
            IntersectionPoint = intersectionPoint;
            NormalVector = normal;
            TotalDistance = distance;
            FoundDistance = foundDistance;
        }

    }
}
