using RayTracer.Controllers;
using RayTracer.Model;
using RayTracer.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
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
        List<LightSource> sceneLights;
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
            foreach (LightSource light in sceneLights)
            {
                light.GeometricTransformations(transformations, camera);
            }
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
            sceneLights = parser.getLights();
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

        double ε = 1E-6;

        Color3 traceRay(Ray ray, int recursiveIndex)
        {
            Hit hit = new Hit();
            hit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
            hit.MinDistance = 1.0E12; // usem um valor muito elevado. Por exemplo, hit.tmin = 1.0E12;
            foreach (Object3D object3 in sceneObjects)
            { // ciclo para percorrer todos os objectos da cena
              //if (object3 is Sphere || object3 is Triangle)
              //{
                //Ray rayCopy = new Ray(ray.Origin, ray.Direction);
                if(object3.intersect(ray, hit))
                {
                    hit.MaterialHit = materials[object3.MaterialIndex];
                }
            }

            if (hit.Found)
            {
                Color3 color = new Color3(0.0, 0.0, 0.0); // inicialização
                foreach (LightSource light in sceneLights)
                { // ciclo para percorrer todas as fontes de luz da cena
                    // cálculo da componente de reflexão ambiente com origem na fonte de luz light
                    // color = color + light.color * hit.material.color * hit.material.ambientCoefficient
                    color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.AmbientLight));
                    // cálculo da componente de reflexão difusa com origem na fonte de luz light
                    // comecem por construir o vector l que une o ponto de intersecção ao ponto correspondente à posição da fonte de luz light
                    Vector3 l = new Vector3(light.Position.Subtract(hit.IntersectionPoint));
                    // Vector3 l = new Vector3(hit.IntersectionPoint.Subtract(light.Position));
                    // antes de normalizar o vector l, calculem o seu comprimento
                    double tLight = l.Length();
                    // normalizem o vector l
                    l = l.Normalize();
                    // calculem o co-seno do ângulo de incidência da luz. Este é igual ao produto escalar do vector normal pelo vector l(assumindo que ambos os vectores são unitários)
                    double cosTheta = hit.NormalVector.DotProduct(l); // em que “∙” designa o produto escalar de vectores 3D
                    // só interessa calcular a componente de reflexão difusa se o ângulo de incidência
                    // θ for inferior a 90.0° (por outras palavras, se cosTheta > 0.0).Um ângulo de
                    // incidência superior àquele valor significa que o raio luminoso está a incidir no lado
                    // de trás da superfície do objecto intersectado
                    if (cosTheta > 0.0)
                    {
                        /*// construam o raio de detecção de sombra que tem origem no ponto de intersecção e a direcção do vector l
                        Ray shadowRay = new Ray(hit.IntersectionPoint, l);
                        Ray shadowRayCopy = new Ray(shadowRay.Origin, shadowRay.Direction);
                        //Ray shadowRay = new Ray(hit.IntersectionPoint.Add(l.ScalarMultiplication(ε)), l); // shadowRay = new Ray(hit.point + ε * l, l);
                        Hit shadowHit = new Hit();
                        shadowHit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
                        shadowHit.MinDistance = tLight; // a intersecção, se existir, terá de ocorrer aquém da posição da fonte de luz*/
                        Ray shadowRay = new Ray(hit.IntersectionPoint, l);
                        //Ray shadowRay = new Ray(hit.IntersectionPoint.Add(l.ScalarMultiplication(ε)), l); // shadowRay = new Ray(hit.point + ε * l, l);
                        Hit shadowHit = new Hit();
                        foreach (Object3D sceneObject in sceneObjects)
                        {
                            shadowHit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
                            shadowHit.MinDistance = tLight; // a intersecção, se existir, terá de ocorrer aquém da posição da fonte de luz
                            sceneObject.intersect(shadowRay, shadowHit);
                            // há sombra, pois o raio shadowRay intersecta um
                            // (basta um) objecto da cena, a distância shadowHit.t do ponto de
                            // intersecção à origem do raio é shadowHit.t > 0.0 (pois a intersecção terá
                            // de ocorrer à frente da origem do raio) e shadowHit.t < shadowHit.tLight
                            // (pois a intersecção terá de ocorrer aquém da posição da fonte de luz).
                            // Mais precisamente, e para evitar o problema, já referido, que decorre de
                            // a precisão de cálculo ser limitada, a intersecção só deverá ser reportada
                            // quando a distância shadowHit.t do ponto de intersecção à origem do raio
                            // for shadowHit.t > ε e não shadowHit.t > 0.0 (documento “TR - 05.pdf”, págs. 14 a 17)
                            if (shadowHit.Found) break;
                            // encontrada que está uma obstrução à passagem da luz proveniente da fonte light,
                            // não há necessidade de percorrer os restantes objectos da cena
                        }
                        // atentem na negação “!” da condição; se o ponto estiver exposto à luz proveniente da fonte light,
                        // calculem a componente de reflexão difusa e adicionem a cor resultante à cor color
                        //if (!shadowHit.Found)
                        //{
                            // color = color + light.color * hit.material.color * hit.material.diffuseCoefficient * cosTheta;
                            color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.DifuseLight).multiplyScalar(cosTheta));
                        //}
                    }
                }
                return color.divideScalar(sceneLights.Count).CheckRange(); // em que sceneLights.length designa o número de fontes de luz existentes na cena; se houver intersecção, retorna a cor correspondente à componente de luz ambiente reflectida pelo objecto intersectado mais próximo da origem do raio

            }
            else
            {
                return image.BackgroundColor; // caso contrário, retorna a cor de fundo
            }
        }

       

        Color3 traceRays(Ray ray, int recursiveIndex)
        {
            Hit hit = new Hit();
            hit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
            hit.MinDistance = 1.0E12; // usem um valor muito elevado. Por exemplo, hit.tmin = 1.0E12;
            double hitMin = 1.0E12;
            foreach (Object3D object3 in sceneObjects)
            { // ciclo para percorrer todos os objectos da cena
              //if (object3 is Sphere || object3 is Triangle)
              //{
                Ray rayCopy = new Ray(ray.Origin, ray.Direction);
                object3.intersect(rayCopy, hit);
                if (hit.MinDistance < hitMin)
                {
                    hitMin = hit.MinDistance;
                    hit.MaterialHit = materials[object3.MaterialIndex];
                }
                //}
            }

            if (hit.Found)
            {
                //return hit.MaterialHit.Color; // se houver intersecção, retorna a cor do material constituinte do objecto intersectado mais próximo da origem do raio

                Color3 color = new Color3(0.0, 0.0, 0.0); // inicialização
                foreach (LightSource light in sceneLights)
                { // ciclo para percorrer todas as fontes de luz da cena
                    // cálculo da componente de reflexão ambiente com origem na fonte de luz light
                    color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.AmbientLight)).CheckRange();

                    // cálculo da componente de reflexão difusa com origem na fonte de luz light
                    // comecem por construir o vector l que une o ponto de intersecção ao ponto correspondente à posição da fonte de luz light
                    Vector3 l = new Vector3(light.Position.Subtract(hit.IntersectionPoint));
                    // normalizem o vector l
                    l = l.Normalize();
                    // calculem o co-seno do ângulo de incidência da luz. Este é igual ao produto escalar do vector normal pelo vector l(assumindo que ambos os vectores são unitários)
                    double cosTheta = hit.NormalVector.DotProduct(l); // em que “∙” designa o produto escalar de vectores 3D
                    // só interessa calcular a componente de reflexão difusa se o ângulo de incidência
                    // θ for inferior a 90.0° (por outras palavras, se cosTheta > 0.0).Um ângulo de
                    // incidência superior àquele valor significa que o raio luminoso está a incidir no lado
                    // de trás da superfície do objecto intersectado
                    if (cosTheta > 0.0)
                    {
                        color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.DifuseLight).multiplyScalar(cosTheta)).CheckRange();
                    }
                }
                return color.divideScalar(sceneLights.Count); // em que sceneLights.length designa o número de fontes de luz existentes na cena; se houver intersecção, retorna a cor correspondente à componente de luz ambiente reflectida pelo objecto intersectado mais próximo da origem do raio

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
