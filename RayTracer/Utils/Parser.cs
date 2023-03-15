using RayTracer.Model;
using System;
using System.CodeDom.Compiler;
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
    internal class Parser
    {

        List<String> images = new List<String>();
        List<String> transformations = new List<String>();
        List<String> cameras = new List<String>();
        List<String> lights = new List<String>();
        List<String> materials = new List<String>();
        List<String> triangles = new List<String>();
        List<String> spheres = new List<String>();
        List<String> boxes = new List<String>();

        Image image;
        Camera camera;
        List<Transformation> transformationsList = new List<Transformation>();
        List<LightSource> lightsList = new List<LightSource>();
        List<Material> materialsList = new List<Material>();
        List<Triangle> allTriangles = new List<Triangle>();
        List<List<Triangle>> trianglesList = new List<List<Triangle>>();
        List<Sphere> spheresList = new List<Sphere>();
        List<Box> boxesList = new List<Box>();

        public Image getImage() { return image; }

        public Camera getCamera() { return camera; }

        public List<Transformation> getTransformations() {  return transformationsList; }

        public List <LightSource> getLights() {  return lightsList; }

        public List<Material> getMaterials() {  return materialsList; }

        public List<List<Triangle>> getTriangles() { return trianglesList; }

        public List<Sphere> getSphere() {  return spheresList; }

        public List<Box> getBoxes() {  return boxesList; }

        public bool readTracerFile(string filename)
        {
            if (filename == string.Empty) return false;
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
            triangles = removeBracketsfromList(triangles);
            spheres = removeBracketsfromList(spheres);
            boxes = removeBracketsfromList(boxes);

            segmentsConverter();

            printAllLists();
            return true;
        }

        public void segmentsConverter()
        {
            foreach (string imageString in images)
            {
                string[] imageTemp = imageString.Split('\n');
                string[] widthHeight = imageTemp[0].Split(' ');
                string[] stringImageColor3 = imageTemp[1].Split(' ');
                image = new Image(int.Parse(widthHeight[0]), int.Parse(widthHeight[1]), 
                    new Color3(double.Parse(stringImageColor3[0]), double.Parse(stringImageColor3[1]), double.Parse(stringImageColor3[2])));
            }
            /*foreach (string transformationString in transformations)
            {
            }*/
            foreach (string cameraString in cameras)
            {
                string[] cameraTemp = cameraString.Split('\n');
                camera = new Camera(int.Parse(cameraTemp[0]), double.Parse(cameraTemp[1]), double.Parse(cameraTemp[2]));
            }
            foreach (string lightString in lights)
            {
                string[] lightTemp = lightString.Split('\n');
                string[] stringLightColor3 = lightTemp[1].Split(' ');
                LightSource light = new LightSource(int.Parse(lightTemp[0]), 
                    new Color3(double.Parse(stringLightColor3[0]), double.Parse(stringLightColor3[1]), double.Parse(stringLightColor3[2])));
                lightsList.Add(light);
            }
            foreach (string materialString in materials)
            {
                string[] materialTemp = materialString.Split('\n');
                string[] stringMaterialColor3 = materialTemp[1].Split(' ');
                string[] stringLightEffects = materialTemp[1].Split(' ');
                Material material = new Material(
                    new Color3(double.Parse(stringMaterialColor3[0]), double.Parse(stringMaterialColor3[1]), double.Parse(stringMaterialColor3[2])),
                    double.Parse(stringLightEffects[0]), 
                    double.Parse(stringLightEffects[1]), 
                    double.Parse(stringLightEffects[2]), 
                    double.Parse(stringLightEffects[3]), 
                    double.Parse(stringLightEffects[4]));
                materialsList.Add(material);
            }
            foreach (string triangleString in triangles)
            {
                List<Triangle> tempTriangleList = new List<Triangle>();
                string[] triangleTemp = triangleString.Split('\n');
                int transformationIndex = int.Parse(triangleTemp[0]);
                triangleTemp = triangleTemp.Skip(1).ToArray();

                for (int i = 0; i < triangleTemp.Length - 3; i++)
                {
                    string[] stringTriangleFirstVertex = triangleTemp[i+1].Split(' ');
                    string[] stringTriangleSecondVertex = triangleTemp[i+2].Split(' ');
                    string[] stringTriangleThirdVertex = triangleTemp[i+3].Split(' ');
                    Triangle triangle = new Triangle(transformationIndex, int.Parse(triangleTemp[i]),
                        new Vector3(double.Parse(stringTriangleFirstVertex[0]), double.Parse(stringTriangleFirstVertex[1]), double.Parse(stringTriangleFirstVertex[2])),
                        new Vector3(double.Parse(stringTriangleSecondVertex[0]), double.Parse(stringTriangleSecondVertex[1]), double.Parse(stringTriangleSecondVertex[2])),
                        new Vector3(double.Parse(stringTriangleThirdVertex[0]), double.Parse(stringTriangleThirdVertex[1]), double.Parse(stringTriangleThirdVertex[2])));
                    allTriangles.Add(triangle);
                    tempTriangleList.Add(triangle);
                    i += 3;
                }
                trianglesList.Add(tempTriangleList);
            }
            foreach (string sphereString in spheres)
            {
                string[] sphereTemp = sphereString.Split('\n');
                Sphere sphere = new Sphere(int.Parse(sphereTemp[0]), int.Parse(sphereTemp[1]));
                spheresList.Add(sphere);
            }
            foreach (string boxString in boxes)
            {
                string[] boxTemp = boxString.Split('\n');
                Box box = new Box(int.Parse(boxTemp[0]), int.Parse(boxTemp[1]));
                boxesList.Add(box);
            }
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

        public void printAllLists() {

            Console.WriteLine("#######################################");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Image: \n" + 
                "Dimensions: " + image.Width + "x" + image.Length + "\n" + 
                "R: " + image.BackgroundColor.Red + " G: " + image.BackgroundColor.Green + " B: " + image.BackgroundColor.Blue);
            Console.WriteLine("---------------------------------------------------------");
            /*Console.WriteLine("#######################################");
            foreach (Transformation transformation in transformationsList)
            {
                Console.WriteLine("Transformation: \n" + transformation);
            }*/
            Console.WriteLine("#######################################");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Camera: \n" + 
                "Transformation: " + camera.TransformationIndex + "\n" +
                "Distance: " + camera.Distance + "\n" + 
                "FOV: " + camera.FieldOfView);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("#######################################");
            foreach (LightSource light in lightsList)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Light: \n" +
                    "Transformation: " + light.TransformationIndex + "\n" +
                    "R: " + light.Intensity.Red + " G: " + light.Intensity.Green + " B: " + light.Intensity.Blue);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.WriteLine("#######################################");
            foreach (Material material in materialsList)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Material: \n" +
                    "R: " + material.Color.Red + " G: " + material.Color.Green + " B: " + material.Color.Blue + "\n" +
                    "Ambient Light: " + material.AmbientLight + "\n" +
                    "Difuse Light: " + material.DifuseLight + "\n" +
                    "Specular Light: " + material.SpecularLight + "\n" +
                    "Refraction: " + material.Refraction + "\n" +
                    "Refraction Index: " + material.RefractionIndex);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.WriteLine("#######################################");
            int loop = 1;
            foreach (List<Triangle> solid in trianglesList)
            {
                Console.WriteLine(loop + "º solid has " + solid.Count + " triangles");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                foreach (Triangle triangle in solid)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Triangle: \n" +
                        "Transformation Index: " + triangle.TransformationIndex + "\n" +
                        "Material Index: " + triangle.MaterialIndex + "\n" +
                        "First Vertex: " + "x: " + triangle.FirstVertex.XValue + " y: " + triangle.FirstVertex.YValue + " z: " + triangle.FirstVertex.ZValue + "\n" +
                        "Second Vertex: " + "x: " + triangle.SecondVertex.XValue + " y: " + triangle.SecondVertex.YValue + " z: " + triangle.SecondVertex.ZValue + "\n" +
                        "Third Vertex: " + "x: " + triangle.ThirdVertex.XValue + " y: " + triangle.ThirdVertex.YValue + " z: " + triangle.ThirdVertex.ZValue);
                    Console.WriteLine("---------------------------------------------------------");
                }
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                loop++;
            }
            Console.WriteLine("#######################################");
            foreach (Sphere sphere in spheresList)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Sphere: \n" +
                    "Transformation Index: " + sphere.TransformationIndex + "\n" +
                    "Material Index: " + sphere.MaterialIndex);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.WriteLine("#######################################");
            foreach (Box box in boxesList)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Box: \n" +
                    "Transformation Index: " + box.TransformationIndex + "\n" +
                    "Material Index: " + box.MaterialIndex);
                Console.WriteLine("---------------------------------------------------------");
            }
            Console.WriteLine("#######################################");

        }
    }
}
