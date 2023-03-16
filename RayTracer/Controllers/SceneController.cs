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

        bool fileLoaded = false;

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
                fileLoaded = true;
            }       
        }
        private void startRenderBtn_Click(object sender, EventArgs e)
        {
            if (fileLoaded)
            {
                primaryRaysGeneration();
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
                        "Normal: " + "x: " + triangle.Normal.XValue + " y: " + triangle.Normal.YValue + " z: " + triangle.Normal.ZValue + " Height: " + triangle.Normal.Length());

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
            imageHeightCtrl.Text = image.Height + "px";

            camera = parser.getCamera();
            cameraDistanceCtrl.Text = camera.Distance + "";
            cameraFOVCtrl.Text = camera.FieldOfView + "";

            pictureBox1.Width = image.Width;
            pictureBox1.Height = image.Height;
            pictureBox1.Location = new Point((rayTracerBox.Width / 2) - (pictureBox1.Width / 2),
                                             (rayTracerBox.Height / 2) - (pictureBox1.Height / 2));

            transformations = parser.getTransformations();
            lights = parser.getLights();
            materials = parser.getMaterials();
            triangles = parser.getTriangles();
            spheres = parser.getSphere();
            boxes = parser.getBoxes();
        }

        public void primaryRaysGeneration()
        {
            // Preliminary calculations
            double radianFOV = camera.FieldOfView * Math.PI / 180.0;
            double height = Math.Tan(radianFOV / 2) * camera.Distance * 2.0;
            double width = height * (image.Height / image.Width);
            double pixelSideSize = height / image.Width;
            //double pixelSideSize = width / image.Height;

            // Generation and monitoring of the path of primary rays

            Vector3 origin = new Vector3 (0, 0, camera.Distance);
            int Hres = image.Width;
            int Vres = image.Height;

            pictureBox1.Image = new Bitmap(image.Width, image.Height);

            for (int i = 0; i < Vres; i++) // cicle to go through all image lines
            {
                for(int j = 0; j < Hres; j++) // cicle to go through all columns (pixels) of line i
                {
                    //P.x, P.y and P.z coordinates of the pixel center[i][j]
                    double Px = (j + 0.5) * pixelSideSize - width / 2.0;
                    double Py = -(i + 0.5) * pixelSideSize + height / 2.0;
                    double Pz = 0.0;

                    Vector3 direction = new Vector3 (Px , Py, -camera.Distance); // or new Vector3 (Px - 0.0 , Py - 0.0, Pz - camera.Distance);

                    direction = direction.Normalize();

                    Console.WriteLine("Linha - " + i + " Coluna - " + j + " Direction - (" + direction.XValue + "," + direction.YValue + "," + direction.ZValue + ")");

                    Ray ray = new Ray(origin, direction);

                    Color3 color = traceRay(ray, int.Parse(recursiveIndex.Text));

                    // Limitation of the primary components (R, G and B) of the colors obtained

                    color.CheckRange();

                    // Conversion of the primary components (R, G and B) of the colors obtained and coloring of the pixels that make up the image

                    ((Bitmap)pictureBox1.Image).SetPixel(j, i, Color.FromArgb(Convert.ToInt32(255.0 * color.Red), Convert.ToInt32(255.0 * color.Green), Convert.ToInt32(255.0 * color.Blue)));
                }
            }
        }

        private Color3 traceRay(Ray ray, int recursiveIndex)
        {
            return new Color3(0.4, 0.5, 0.6);
        }

    }
}
