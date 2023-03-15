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
            readFile();
            fillFormFields();
        }

        public void readFile()
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
            parser.readTracerFile(filePath);
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
