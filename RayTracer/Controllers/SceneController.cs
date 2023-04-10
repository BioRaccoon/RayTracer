using RayTracer.Controllers;
using RayTracer.Model;
using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        List<Object3D> sceneObjects;

        bool fileLoaded = false;

        public RayTracerForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            startRenderBtn.Enabled = false;
            saveImageBtn.Enabled = false;
            backgroundColorBtn.Enabled = false;
        }

        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            bool success = readFile();
            if (success)
            {
                fillFormFields();
                calculateTrianglesNormalVectors();
                convertToObject3DList();
                generateGeometricTransformations();
                /*foreach (Material material in materials)
                {
                    Console.WriteLine("Index - " + materials.IndexOf(material) + " ||||| " + material.Color.toString());
                }*/

                fileLoaded = true;
                startRenderBtn.Enabled = true;
                backgroundColorBtn.Enabled = true;
            }
        }

        private void generateGeometricTransformations()
        {
            camera.GeometricTransformations(transformations);
            foreach (Object3D object3 in sceneObjects)
            {
                object3.GeometricTransformations(transformations, camera);
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

            //Console.WriteLine("############################################### Calculanting Normals ###############################################");

            int loop = 1;
            foreach (List<Triangle> solidTriangles in triangles)
            {
                Console.WriteLine(loop + "º solid has " + solidTriangles.Count + " triangles");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                vectorOperationsController.CalcNormals(solidTriangles);
                /*foreach (Triangle triangle in solidTriangles)
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
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");*/
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

            rayTracerPictBox.Width = image.Width;
            rayTracerPictBox.Height = image.Height;
            rayTracerPictBox.Location = new Point((rayTracerBox.Width / 2) - (rayTracerPictBox.Width / 2),
                                             (rayTracerBox.Height / 2) - (rayTracerPictBox.Height / 2));

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

            Vector3 origin = new Vector3 (0, 0, 30);

            int Hres = image.Width;
            int Vres = image.Height;

            rayTracerPictBox.Image = new Bitmap(image.Width, image.Height);

            Console.WriteLine("---------------------------------------------------------------------------------");

            int totalIterations = Vres * Hres;
            int processedIterations = 0;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

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

                    Ray ray = new Ray(origin, direction);

                    Color3 color = traceRay(ray, int.Parse(recursiveIndex.Text));

                    // Limitation of the primary components (R, G and B) of the colors obtained

                    color.CheckRange();

                    // Conversion of the primary components (R, G and B) of the colors obtained and coloring of the pixels that make up the image

                    ((Bitmap)rayTracerPictBox.Image).SetPixel(j, i, Color.FromArgb(Convert.ToInt32(255.0 * color.Red), Convert.ToInt32(255.0 * color.Green), Convert.ToInt32(255.0 * color.Blue)));

                    processedIterations++;

                    double progressPercentage = (double)processedIterations / totalIterations * 100;

                    // update progress bar value, making sure it's within valid range
                    int progressValue = (int)(progressPercentage * (progressBar1.Maximum - progressBar1.Minimum) / 100 + progressBar1.Minimum);
                    if (progressValue < progressBar1.Minimum)
                    {
                        progressValue = progressBar1.Minimum;
                    }
                    else if (progressValue > progressBar1.Maximum)
                    {
                        progressValue = progressBar1.Maximum;
                    }
                    progressBar1.Value = progressValue;

                    // calculate elapsed time and display progress message
                    TimeSpan elapsed = stopwatch.Elapsed;
                    string progressMessage = $"{progressValue}% - {elapsed.TotalSeconds:0.00}s";
                    lblProgress.Text = progressMessage;

                    // force the progress bar and label to repaint immediately
                    progressBar1.Refresh();
                    lblProgress.Refresh();
                    rayTracerPictBox.Refresh();
                }
            }

            stopwatch.Stop();
            TimeSpan totalElapsed = stopwatch.Elapsed;
            string finalMessage = $"Completed in {totalElapsed.TotalSeconds:0.00}s";
            lblProgress.Text = finalMessage;
            saveImageBtn.Enabled = true;

        }

        public void convertToObject3DList()
        {
            sceneObjects = new List<Object3D>();
            foreach (Box box in boxes)
            {
                sceneObjects.Add(box);
            }

            foreach (Sphere sphere in spheres)
            {
                sceneObjects.Add(sphere);
            }

            foreach (List<Triangle> trianglesList in triangles)
            {
                foreach (Triangle triangle in trianglesList)
                {
                    sceneObjects.Add(triangle);
                }
            }

        }

        Color3 traceRay(Ray ray, int recursiveIndex)
        {
            Hit hit = new Hit();
            hit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
            hit.FoundDistance = 1.0E12; // usem um valor muito elevado. Por exemplo, hit.tmin = 1.0E12;
            double hitMin = 1.0E12;
            foreach (Object3D object3 in sceneObjects)
            { // ciclo para percorrer todos os objectos da cena
              //if (object3 is Sphere || object3 is Triangle)
              //{
                Ray rayCopy = new Ray(ray.Origin, ray.Direction);
                object3.intersect(rayCopy, hit);
                if (hit.FoundDistance < hitMin)
                {
                    hitMin = hit.FoundDistance;
                    hit.MaterialHit = materials[object3.MaterialIndex];
                }
              //}
            }

            if (hit.Found)
            {
                return hit.MaterialHit.Color; // se houver intersecção, retorna a cor do material constituinte do objecto intersectado mais próximo da origem do raio
            }
            else
            {
                return image.BackgroundColor; // caso contrário, retorna a cor de fundo
            }
        }

        private void saveImageBtn_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|";
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        rayTracerPictBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        rayTracerPictBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 3:
                        rayTracerPictBox.Image.Save(fs,
                          System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                }

                fs.Close();
            }
        }
    }
}
