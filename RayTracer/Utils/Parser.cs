using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RayTracer.Utils
{
    public class Parser
    {

        List<String> images = new List<String>();
        List<String> transformations = new List<String>();
        List<String> cameras = new List<String>();
        List<String> lights = new List<String>();
        List<String> materials = new List<String>();
        List<String> triangles = new List<String>();
        List<String> spheres = new List<String>();
        List<String> boxes = new List<String>();

        public void readTracerFile(string filename)
        {
            string fileContent = File.ReadAllText(filename);

            Regex regex = new Regex(@"[a-zA-Z]+\s\n{\s\n[\sa-zA-z0-9\.-]*}");

            foreach (Match m in regex.Matches(fileContent))
            {
                fillSegmentLists(m.Value);
            }

            Console.WriteLine("Images - " + images.Count);
            Console.WriteLine("Transformations - " + transformations.Count);
            Console.WriteLine("Cameras - " + cameras.Count);
            Console.WriteLine("Lights - " + lights.Count);
            Console.WriteLine("Materials - " + materials.Count);
            Console.WriteLine("Triangles - " + triangles.Count);
            Console.WriteLine("Spheres - " + spheres.Count);
            Console.WriteLine("Boxes - " + boxes.Count);

            images = removeBracketsfromList(images);
            transformations = removeBracketsfromList(transformations);
            cameras = removeBracketsfromList(cameras);
            lights = removeBracketsfromList(lights);
            materials = removeBracketsfromList(materials);
            triangles =removeBracketsfromList(triangles);
            spheres = removeBracketsfromList(spheres);
            boxes = removeBracketsfromList(boxes);

            lol();

            /* switch ()
             {
                 case "Image":
                     break;
                 case "Transformation":
                     break;
                 case "Camera":
                     break;
                 case "Light":
                     break;
                 case "Material":
                     break;
                 case "Triangles":
                     break;
                 case "Sphere":
                     break;
                 case "Box":
                     break;
                 default:
                     break;*/

        }

        public List<String> removeBracketsfromList(List<String> list)
        {
            List<String> values = new List<string>();
            foreach (String str in list)
            {
                List<String> block = str.Split('\n').ToList();
                block.RemoveAt(0);
                block.RemoveAt(0);
                block.RemoveAt(block.Count - 1);
                string temp = "";
                foreach (String str2 in block)
                {
                    temp += str2.Replace("\t", "") + "\n";
                }
                values.Add(temp);
            }
            return values;
        }

        public void fillSegmentLists(string block)
        {
            if (block.Contains("Image"))
            {
                images.Add(block);
                return;
            }
            if (block.Contains("Transformation"))
            {
                transformations.Add(block);
                return;
            }
            if (block.Contains("Camera"))
            {
                cameras.Add(block);
                return;
            }
            if (block.Contains("Light"))
            {
                lights.Add(block);
                return;
            }
            if (block.Contains("Material"))
            {
                materials.Add(block);
                return;
            }
            if (block.Contains("Triangles"))
            {
                triangles.Add(block);
                return;
            }
            if (block.Contains("Sphere"))
            {
                spheres.Add(block);
                return;
            }
            if (block.Contains("Box"))
            {
                boxes.Add(block);
                return;
            }
        }

        public void lol() {

            Console.WriteLine("#######################################");
            foreach (string image in images)
            {
                Console.WriteLine("Image: \n" + image);
            }
            Console.WriteLine("#######################################");
            foreach (string transformation in transformations)
            {
                Console.WriteLine("Transformation: \n" + transformation);
            }
            Console.WriteLine("#######################################");
            foreach (string camera in cameras)
            {
                Console.WriteLine("Camera: \n" + camera);
            }
            Console.WriteLine("#######################################");
            foreach (string light in lights)
            {
                Console.WriteLine("Light: \n" + light);
            }
            Console.WriteLine("#######################################");
            foreach (string material in materials)
            {
                Console.WriteLine("Material: \n" + material);
            }
            Console.WriteLine("#######################################");
            foreach (string triangle in triangles)
            {
                Console.WriteLine("Triangle: \n" + triangle);
            }
            Console.WriteLine("#######################################");
            foreach (string sphere in spheres)
            {
                Console.WriteLine("Sphere: \n" + sphere);
            }
            Console.WriteLine("#######################################");
            foreach (string box in boxes)
            {
                Console.WriteLine("Box: \n" + box);
            }
            Console.WriteLine("#######################################");

        }
    }
}
