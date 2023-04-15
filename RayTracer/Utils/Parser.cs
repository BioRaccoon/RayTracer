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
            double colorRedValue = 0;
            double colorGreenValue = 0;
            double colorBlueValue = 0;
            foreach (string imageString in images)
            {
                string[] imageTemp = imageString.Split('\n');
                string[] widthHeight = imageTemp[0].Split(' ');
                string[] stringImageColor3 = imageTemp[1].Split(' ');
                colorRedValue = StaticFunctions.parseDouble(stringImageColor3[0]);
                colorGreenValue = StaticFunctions.parseDouble(stringImageColor3[1]);
                colorBlueValue = StaticFunctions.parseDouble(stringImageColor3[2]);
                image = new Image(int.Parse(widthHeight[0]), int.Parse(widthHeight[1]), 
                    new Color3(colorRedValue, colorGreenValue, colorBlueValue));
            }
            foreach (string transformationString in transformations)
            {
                List<string> types = new List<string>();
                string[] typesArray = transformationString.Split('\n');
                foreach (string type in typesArray)
                {
                    if (type.Length > 0 || type != "") types.Add(type);
                }
                transformationsList.Add(new Transformation(types));
            }
            foreach (string cameraString in cameras)
            {
                string[] cameraTemp = cameraString.Split('\n');
                double cameraDistance = StaticFunctions.parseDouble(cameraTemp[1]);
                double cameraFOV = StaticFunctions.parseDouble(cameraTemp[2]);
                camera = new Camera(int.Parse(cameraTemp[0]), cameraDistance, cameraFOV);
            }
            foreach (string lightString in lights)
            {
                string[] lightTemp = lightString.Split('\n');
                string[] stringLightColor3 = lightTemp[1].Split(' ');
                colorRedValue = StaticFunctions.parseDouble(stringLightColor3[0]);
                colorGreenValue = StaticFunctions.parseDouble(stringLightColor3[1]);
                colorBlueValue = StaticFunctions.parseDouble(stringLightColor3[2]);
                LightSource light = new LightSource(int.Parse(lightTemp[0]), 
                    new Color3(colorRedValue, colorGreenValue, colorBlueValue));
                lightsList.Add(light);
            }
            foreach (string materialString in materials)
            {
                string[] materialTemp = materialString.Split('\n');
                string[] stringMaterialColor3 = materialTemp[0].Split(' ');
                string[] stringLightEffects = materialTemp[1].Split(' ');
                colorRedValue = StaticFunctions.parseDouble(stringMaterialColor3[0]);
                colorGreenValue = StaticFunctions.parseDouble(stringMaterialColor3[1]);
                colorBlueValue = StaticFunctions.parseDouble(stringMaterialColor3[2]);

                double ambient = StaticFunctions.parseDouble(stringLightEffects[0]);
                double difuse = StaticFunctions.parseDouble(stringLightEffects[1]);
                double specular = StaticFunctions.parseDouble(stringLightEffects[2]);
                double refraction = StaticFunctions.parseDouble(stringLightEffects[3]);
                double refractionIndex = StaticFunctions.parseDouble(stringLightEffects[4]);

                Material material = new Material(
                    new Color3(colorRedValue, colorGreenValue, colorBlueValue),
                    ambient, difuse, specular, refraction, refractionIndex);
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

                    double vertexXValue = StaticFunctions.parseDouble(stringTriangleFirstVertex[0]);
                    double vertexYValue = StaticFunctions.parseDouble(stringTriangleFirstVertex[1]);
                    double vertexZValue = StaticFunctions.parseDouble(stringTriangleFirstVertex[2]);
                    Vector3 firstVertex = new Vector3(vertexXValue, vertexYValue, vertexZValue);
                    
                    vertexXValue = StaticFunctions.parseDouble(stringTriangleSecondVertex[0]);
                    vertexYValue = StaticFunctions.parseDouble(stringTriangleSecondVertex[1]);
                    vertexZValue = StaticFunctions.parseDouble(stringTriangleSecondVertex[2]);
                    Vector3 secondVertex = new Vector3(vertexXValue, vertexYValue, vertexZValue);
                    
                    vertexXValue = StaticFunctions.parseDouble(stringTriangleThirdVertex[0]);
                    vertexYValue = StaticFunctions.parseDouble(stringTriangleThirdVertex[1]);
                    vertexZValue = StaticFunctions.parseDouble(stringTriangleThirdVertex[2]);
                    Vector3 thirdVertex = new Vector3(vertexXValue, vertexYValue, vertexZValue);

                    Triangle triangle = new Triangle(transformationIndex, int.Parse(triangleTemp[i]),
                        firstVertex, secondVertex, thirdVertex);
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
                "Dimensions: " + image.Width + "x" + image.Height + "\n" + 
                "R: " + image.BackgroundColor.Red + " G: " + image.BackgroundColor.Green + " B: " + image.BackgroundColor.Blue);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("#######################################");
            foreach (Transformation transformation in transformationsList)
            {
                Console.WriteLine("Transformation: \n" + 
                    "Index: " + transformationsList.IndexOf(transformation) + "\n");
                if (transformation.types.Count == 0)
                {
                    Console.WriteLine("This tranformation has no types!");
                }
                else
                {
                    foreach (string type in transformation.types)
                    {
                        Console.WriteLine("Type: " + type + "\n");
                    }
                }
            }
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
