using RayTracer.Controllers;
using RayTracer.Model;
using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Image = RayTracer.Model.Image;

namespace RayTracer
{
    public partial class RayTracerForm : Form
    {

        Parser parser;
        VectorOperationsController vectorOperationsController;

        Image image;
        Camera camera;
        List<Transformation> transformations;
        List<LightSource> lights;
        List<Material> materials;
        List<List<Triangle>> triangles;
        List<Sphere> spheres;
        List<Box> boxes;

        public RayTracerForm()
        {
            InitializeComponent();
        }

        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            bool success = readFile();
            if (success) {
                fillFormFields();
                calculateTrianglesNormalVectors();
            }
            
        }

        public void calculateTrianglesNormalVectors()
        {
            vectorOperationsController = new VectorOperationsController();

            Console.WriteLine("############################################### Calculanting Normals ###############################################");

            int loop = 1;
            foreach (List<Triangle> solidTriangles in triangles)
            {
                Console.WriteLine(loop + "º solid has " + solidTriangles.Count + " triangles");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                vectorOperationsController.CalcNormals(solidTriangles);
                foreach (Triangle triangle in solidTriangles)
                {
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("Triangle: \n" +
                        "Transformation Index: " + triangle.TransformationIndex + "\n" +
                        "Material Index: " + triangle.MaterialIndex + "\n" +
                        "First Vertex: " + "x: " + triangle.FirstVertex.XValue + " y: " + triangle.FirstVertex.YValue + " z: " + triangle.FirstVertex.ZValue + "\n" +
                        "Second Vertex: " + "x: " + triangle.SecondVertex.XValue + " y: " + triangle.SecondVertex.YValue + " z: " + triangle.SecondVertex.ZValue + "\n" +
                        "Third Vertex: " + "x: " + triangle.ThirdVertex.XValue + " y: " + triangle.ThirdVertex.YValue + " z: " + triangle.ThirdVertex.ZValue + "\n" +
                        "Normal: " + "x: " + triangle.Normal.XValue + " y: " + triangle.Normal.YValue + " z: " + triangle.Normal.ZValue + " Length: " + triangle.Normal.Length());

                    Console.WriteLine("---------------------------------------------------------");
                }
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                loop++;
            }

        }

        public bool readFile()
        {
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }

            parser = new Parser();
            return parser.readTracerFile(filePath);
        }

        public void fillFormFields()
        {
            image = parser.getImage();
            imageWidthCtrl.Text = image.Width + "px";
            imageHeightCtrl.Text = image.Length + "px";

            camera = parser.getCamera();
            cameraDistanceCtrl.Text = camera.Distance + "";
            cameraFOVCtrl.Text = camera.FieldOfView + "";

            transformations = parser.getTransformations();
            lights = parser.getLights();
            materials = parser.getMaterials();
            triangles = parser.getTriangles();
            spheres = parser.getSphere();
            boxes = parser.getBoxes();
        }

    }
}
