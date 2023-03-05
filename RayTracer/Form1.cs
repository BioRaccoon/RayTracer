using RayTracer.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RayTracer
{
    public partial class raytracerForm : Form
    {
        public raytracerForm()
        {
            InitializeComponent();
        }

        private void loadSceneBtn_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
             {
             //Get the path of specified file
             filePath = openFileDialog.FileName;
             //Read the contents of the file into a stream
             /*var fileStream = openFileDialog.OpenFile();
             using (StreamReader reader = new StreamReader(fileStream))
             {
             fileContent = reader.ReadToEnd();
             }*/
            }            

            Parser parser = new Parser();
            parser.readTracerFile(filePath);
        }
    }
}
