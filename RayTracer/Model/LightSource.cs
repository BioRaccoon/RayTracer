using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class LightSource
    {
        public int TransformationIndex { get; set; }
        public Color3 Intensity { get; set; }

        public LightSource(int LightTransformationIndex, Color3 lightIntensity)
        {
            TransformationIndex = LightTransformationIndex;
            Intensity = lightIntensity;
        }
    }
}
