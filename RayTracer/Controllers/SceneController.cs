﻿using RayTracer.Controllers;
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
                backgroundColorLabel.BackColor = Color.FromArgb(Convert.ToInt32(255.0 * image.BackgroundColor.Red), Convert.ToInt32(255.0 * image.BackgroundColor.Green), Convert.ToInt32(255.0 * image.BackgroundColor.Blue));
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
                rayTracerPictBox.Image = null;
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

            //int numThreads = Environment.ProcessorCount;
            int numSamples = Convert.ToInt32(numSamplesWheel.Value);

            for (int i = 0; i < Vres; i++) // cicle to go through all image lines
            {
                for(int j = 0; j < Hres; j++) // cicle to go through all columns (pixels) of line i
                {
                    Color3 color = new Color3(0, 0, 0);
                    if (!antiAliasingCheckBox.Checked) numSamples = 1;
                    if (antiAliasingCheckBox.Checked && numSamples == 0) numSamples = 1;
                    for (int k = 0; k < numSamples; k++) // Loop para realizar amostragem superdimensionada
                    {
                        double offsetX = (k % 2 - 0.5) * pixelSideSize / 2.0;
                        double offsetY = ((k / 2) % 2 - 0.5) * pixelSideSize / 2.0;
                        if (!antiAliasingCheckBox.Checked) {
                            offsetX = 0;
                            offsetY = 0;
                        }
                        //P.x, P.y and P.z coordinates of the pixel center[i][j]
                        double Px = (j + 0.5) * pixelSideSize - width / 2.0 + offsetX;
                        double Py = -(i + 0.5) * pixelSideSize + height / 2.0 + offsetY;
                        //double Pz = 0.0;

                        Vector3 direction = new Vector3(Px, Py, -camera.Distance); // or new Vector3 (Px - 0.0 , Py - 0.0, Pz - camera.Distance);

                        direction = direction.Normalize();

                        Ray ray = new Ray(origin, direction);

                        //color = traceRay(ray, int.Parse(recursiveIndex.Text));
                        Color3 sampleColor = traceRay(ray, int.Parse(recursiveIndex.Text));

                        color = color.add(sampleColor);
                    }

                    // Divide a cor acumulada pelo número de amostras para obter a cor média
                    color = color.divideScalar(numSamples);

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

        double ε = 1.0E-3;

        Color3 traceRay(Ray ray, int recursiveIndex)
        {
            Hit hit = new Hit();
            hit.Found = false; // inicialização; também pode ser realizada no construtor da classe Hit
            hit.MinDistance = 1.0E12; // usem um valor muito elevado. Por exemplo, hit.tmin = 1.0E12;
            foreach (Object3D object3 in sceneObjects)
            { // ciclo para percorrer todos os objectos da cena
              //if (object3 is Sphere || object3 is Triangle)
              //{
                if(object3.intersect(ray, hit))
                {
                    hit.MaterialHit = materials[object3.MaterialIndex];
                }
            }

            if (hit.Found)
            {
                Color3 color = new Color3(0.0, 0.0, 0.0); // inicialização
                //double cosTheta = 0.0;
                foreach (LightSource light in sceneLights)
                { // ciclo para percorrer todas as fontes de luz da cena
                    // cálculo da componente de reflexão ambiente com origem na fonte de luz light
                    // color = color + light.color * hit.material.color * hit.material.ambientCoefficient
                    if (ambientLightCheckBox.Checked) color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.AmbientLight));
                    // cálculo da componente de reflexão difusa com origem na fonte de luz light
                    // comecem por construir o vector l que une o ponto de intersecção ao ponto correspondente à posição da fonte de luz light
                    Vector3 l = new Vector3(light.Position.Subtract(hit.IntersectionPoint));
                    // Vector3 l = new Vector3(hit.IntersectionPoint.Subtract(light.Position));
                    // antes de normalizar o vector l, calculem o seu comprimento
                    double tLight = l.Length();
                    // normalizem o vector l
                    l = l.Normalize();
                    // calculem o co-seno do ângulo de incidência da luz. Este é igual ao produto escalar do vector normal pelo vector l(assumindo que ambos os vectores são unitários)
                    //double cosTheta = hit.NormalVector.DotProduct(l); // em que “∙” designa o produto escalar de vectores 3D
                    double cosTheta = hit.NormalVector.DotProduct(l);
                    // só interessa calcular a componente de reflexão difusa se o ângulo de incidência
                    // θ for inferior a 90.0° (por outras palavras, se cosTheta > 0.0).Um ângulo de
                    // incidência superior àquele valor significa que o raio luminoso está a incidir no lado
                    // de trás da superfície do objecto intersectado
                    if (cosTheta > 0.0)
                    {
                        if (shadowsCheckBox.Checked)
                        {
                            //Ray shadowRay = new Ray(hit.IntersectionPoint, l);
                            // shadowRay = new Ray(hit.point + ε * hit.normal, l);
                            Ray shadowRay = new Ray(hit.IntersectionPoint.Add(hit.NormalVector.ScalarMultiplication(ε)), l); // shadowRay = new Ray(hit.point + ε * l, l);
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
                            if (!shadowHit.Found)
                            {
                                // color = color + light.color * hit.material.color * hit.material.diffuseCoefficient * cosTheta;
                                color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.DifuseLight).multiplyScalar(cosTheta));
                            }
                        }
                        if(difuseReflectionCheckBox.Checked) color = color.add(light.Intensity.multiply(hit.MaterialHit.Color).multiplyScalar(hit.MaterialHit.DifuseLight).multiplyScalar(cosTheta));
                    }
                }

                // antes de calcularem recursivamente a componente de reflexão especular, confirmem que a profundidade máxima de recursividade rec do traçador de raios ainda não foi atingida
                if (recursiveIndex > 0 && specularReflectionCheckBox.Checked)
                {
                    // comecem por calcular o co-seno do ângulo do raio incidente
                    double cosThetaV = -(ray.Direction.DotProduct(hit.NormalVector));
                    if (hit.MaterialHit.SpecularLight > 0.0)
                    { // o material constituinte do objecto intersectado reflecte a luz especular
                        // calculem a direcção do raio reflectido
                        Vector3 r = new Vector3(
                                        ray.Direction.Add(
                                            hit.NormalVector.ScalarMultiplication(
                                                2.0 * cosThetaV
                                               )
                                            )
                                        );
                        // normalizem o vector
                        r = r.Normalize();
                        // construam o raio reflectido que tem origem no ponto de intersecção e a direcção do vector r
                        Ray reflectedRay = new Ray(hit.IntersectionPoint, r);
                        Ray rayCopy = new Ray(reflectedRay.Origin, reflectedRay.Direction);

                        // uma vez construído o raio, deverão invocar a função traceRay(), a qual irá acompanhar recursivamente o percurso do referido raio; quando regressar, a cor retornada por esta função deverá ser usada para calcular a componente de reflexão especular, a qual será adicionada à cor color
                        color = color.add(
                            hit.MaterialHit.Color.multiplyScalar(
                                hit.MaterialHit.SpecularLight)
                            .multiply(
                                traceRay(rayCopy, recursiveIndex - 1)
                                )
                            );
                        /*color = color.add(
                            hit.MaterialHit.Color.multiplyScalar(
                                hit.MaterialHit.SpecularLight + 
                                (1.0 - hit.MaterialHit.SpecularLight) * 
                                ((1.0 - cosTheta) * (1.0 - cosTheta) * (1.0 - cosTheta)* (1.0 - cosTheta) * (1.0 - cosTheta))).
                                multiply(traceRay(rayCopy, recursiveIndex - 1)));*/
                    }

                    if (hit.MaterialHit.Refraction > 0.0 && refractionCheckBox.Checked)
                    { 
                        // o material constituinte do objecto intersectado refracta a luz para calcular a razão entre os índices
                        // de refracção e o co-seno do ângulo do raio refractado, comecem por admitir que o raio luminoso está a transitar do
                        // ar para o meio constituinte do objecto intersectado
                        double eta = 1.0 / hit.MaterialHit.RefractionIndex;
                        double cosThetaR = Math.Sqrt(1.0 - eta * eta * (1.0 - cosThetaV * cosThetaV));
                        // se o raio luminoso estiver a transitar do meio constituinte do objecto intersectado para o ar, invertam a razão
                        // entre os índices de refracção e troquem o sinal do co - seno do ângulo do raio refractado
                         if (cosThetaV < 0.0)
                        {
                            eta = hit.MaterialHit.RefractionIndex;
                            cosThetaR = -cosThetaR;
                        }
                        // calculem a direcção do raio refractado
                        Vector3 r = new Vector3(ray.Direction.ScalarMultiplication(eta).
                            Add(hit.NormalVector.ScalarMultiplication(eta * cosThetaV - cosThetaR)));
                        // normalizem o vector
                        r = r.Normalize();
                        // construam o raio refractado que tem origem no ponto de intersecção e a direcção do vector r
                        Ray refractedRay = new Ray(hit.IntersectionPoint, r);
                        // uma vez construído o raio, deverão invocar a função traceRay(), a qual irá acompanhar recursivamente o percurso do referido
                        // raio; quando regressar, a cor retornada por esta função deverá ser usada para calcular a componente de refracção, a qual será
                        // adicionada à cor color
                        color = color.add(hit.MaterialHit.Color.
                            multiplyScalar(hit.MaterialHit.RefractionIndex).
                            multiply(traceRay(refractedRay, recursiveIndex - 1)));
                    }

                }

                if (!ambientLightCheckBox.Checked && !difuseReflectionCheckBox.Checked && !shadowsCheckBox.Checked && !specularReflectionCheckBox.Checked && !refractionCheckBox.Checked) return hit.MaterialHit.Color;

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
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp";
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

        private void rayTracerPictBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        private void backgroundColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.SolidColorOnly = true;
            //color.FullOpen = true;
            if (color.ShowDialog() == DialogResult.OK)
            {
                image.BackgroundColor = new Color3(color.Color.R / 255.0, color.Color.G / 255.0, color.Color.B / 255.0);
                backgroundColorLabel.BackColor = color.Color;
            }
        }
    }
}
