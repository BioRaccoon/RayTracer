using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Camera
    {
        public int TransformationIndex { get; set; }
        public double Distance { get; set; }
        public double FieldOfView { get; set; }
        public Camera(int cameraTransformationIndex, double cameraDistance, double fov)
        {
            TransformationIndex = cameraTransformationIndex;
            Distance = cameraDistance;
            FieldOfView = fov;  
        }
    }
}
