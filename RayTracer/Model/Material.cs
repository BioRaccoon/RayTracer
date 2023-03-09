using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Model
{
    internal class Material
    {
        public Color3 Color { get; set; }
        public double AmbientLight { get; set; }
        public double DifuseLight { get; set; }
        public double SpecularLight { get; set; }
        public double Refraction { get; set; }
        public double RefractionIndex { get; set; }

        public Material(Color3 color, double ambient, double difuse, double specular, double refraction, double refractionIndex)
        {
            Color = color;
            AmbientLight = ambient;
            DifuseLight = difuse;
            SpecularLight = specular;
            Refraction = refraction;
            RefractionIndex = refractionIndex;
        }

    }
}
