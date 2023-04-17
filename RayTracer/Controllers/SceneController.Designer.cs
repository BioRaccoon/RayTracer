namespace RayTracer
{
    partial class RayTracerForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.rayTracerBox = new System.Windows.Forms.GroupBox();
            this.rayTracerPictBox = new System.Windows.Forms.PictureBox();
            this.sceneCtrlsBox = new System.Windows.Forms.GroupBox();
            this.loadSceneBtn = new System.Windows.Forms.Button();
            this.imageCtrlsBox = new System.Windows.Forms.GroupBox();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.imageHeightCtrl = new System.Windows.Forms.DomainUpDown();
            this.imageWidthCtrl = new System.Windows.Forms.DomainUpDown();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.cameraCtrlsBox = new System.Windows.Forms.GroupBox();
            this.imageFOVLabel = new System.Windows.Forms.Label();
            this.imageDistanceLabel = new System.Windows.Forms.Label();
            this.rendererCtrlsBox = new System.Windows.Forms.GroupBox();
            this.startRenderBtn = new System.Windows.Forms.Button();
            this.recursionCtrlsBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lightEffectsCtrlsBox = new System.Windows.Forms.GroupBox();
            this.shadowsCheckBox = new System.Windows.Forms.CheckBox();
            this.refractionCheckBox = new System.Windows.Forms.CheckBox();
            this.specularReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.difuseReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.ambientLightCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundCtrlsBox = new System.Windows.Forms.GroupBox();
            this.selectedColorLabel = new System.Windows.Forms.Label();
            this.backgroundColorLabel = new System.Windows.Forms.Label();
            this.backgroundColorBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cameraDistanceCtrl = new System.Windows.Forms.NumericUpDown();
            this.cameraFOVCtrl = new System.Windows.Forms.NumericUpDown();
            this.recursiveIndex = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numSamplesWheel = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.antiAliasingCheckBox = new System.Windows.Forms.CheckBox();
            this.rayTracerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rayTracerPictBox)).BeginInit();
            this.sceneCtrlsBox.SuspendLayout();
            this.imageCtrlsBox.SuspendLayout();
            this.cameraCtrlsBox.SuspendLayout();
            this.rendererCtrlsBox.SuspendLayout();
            this.recursionCtrlsBox.SuspendLayout();
            this.lightEffectsCtrlsBox.SuspendLayout();
            this.backgroundCtrlsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDistanceCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFOVCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursiveIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSamplesWheel)).BeginInit();
            this.SuspendLayout();
            // 
            // rayTracerBox
            // 
            this.rayTracerBox.Controls.Add(this.rayTracerPictBox);
            this.rayTracerBox.Location = new System.Drawing.Point(9, 10);
            this.rayTracerBox.Margin = new System.Windows.Forms.Padding(2);
            this.rayTracerBox.Name = "rayTracerBox";
            this.rayTracerBox.Padding = new System.Windows.Forms.Padding(2);
            this.rayTracerBox.Size = new System.Drawing.Size(498, 310);
            this.rayTracerBox.TabIndex = 0;
            this.rayTracerBox.TabStop = false;
            // 
            // rayTracerPictBox
            // 
            this.rayTracerPictBox.Location = new System.Drawing.Point(4, 16);
            this.rayTracerPictBox.Margin = new System.Windows.Forms.Padding(2);
            this.rayTracerPictBox.Name = "rayTracerPictBox";
            this.rayTracerPictBox.Size = new System.Drawing.Size(489, 290);
            this.rayTracerPictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rayTracerPictBox.TabIndex = 0;
            this.rayTracerPictBox.TabStop = false;
            this.rayTracerPictBox.Paint += new System.Windows.Forms.PaintEventHandler(this.rayTracerPictBox_Paint);
            // 
            // sceneCtrlsBox
            // 
            this.sceneCtrlsBox.Controls.Add(this.loadSceneBtn);
            this.sceneCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneCtrlsBox.Location = new System.Drawing.Point(9, 354);
            this.sceneCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.sceneCtrlsBox.Name = "sceneCtrlsBox";
            this.sceneCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.sceneCtrlsBox.Size = new System.Drawing.Size(150, 73);
            this.sceneCtrlsBox.TabIndex = 1;
            this.sceneCtrlsBox.TabStop = false;
            this.sceneCtrlsBox.Text = "Scene";
            // 
            // loadSceneBtn
            // 
            this.loadSceneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loadSceneBtn.Location = new System.Drawing.Point(19, 21);
            this.loadSceneBtn.Margin = new System.Windows.Forms.Padding(2);
            this.loadSceneBtn.Name = "loadSceneBtn";
            this.loadSceneBtn.Size = new System.Drawing.Size(112, 41);
            this.loadSceneBtn.TabIndex = 0;
            this.loadSceneBtn.Text = "Load File";
            this.loadSceneBtn.UseVisualStyleBackColor = true;
            this.loadSceneBtn.Click += new System.EventHandler(this.loadSceneBtn_Click);
            // 
            // imageCtrlsBox
            // 
            this.imageCtrlsBox.Controls.Add(this.saveImageBtn);
            this.imageCtrlsBox.Controls.Add(this.imageHeightCtrl);
            this.imageCtrlsBox.Controls.Add(this.imageWidthCtrl);
            this.imageCtrlsBox.Controls.Add(this.HeightLabel);
            this.imageCtrlsBox.Controls.Add(this.widthLabel);
            this.imageCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageCtrlsBox.Location = new System.Drawing.Point(9, 432);
            this.imageCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.imageCtrlsBox.Name = "imageCtrlsBox";
            this.imageCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.imageCtrlsBox.Size = new System.Drawing.Size(150, 150);
            this.imageCtrlsBox.TabIndex = 2;
            this.imageCtrlsBox.TabStop = false;
            this.imageCtrlsBox.Text = "Image";
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveImageBtn.Location = new System.Drawing.Point(19, 95);
            this.saveImageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(112, 41);
            this.saveImageBtn.TabIndex = 0;
            this.saveImageBtn.Text = "Save Image";
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // imageHeightCtrl
            // 
            this.imageHeightCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageHeightCtrl.Location = new System.Drawing.Point(72, 58);
            this.imageHeightCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.imageHeightCtrl.Name = "imageHeightCtrl";
            this.imageHeightCtrl.Size = new System.Drawing.Size(74, 22);
            this.imageHeightCtrl.TabIndex = 4;
            this.imageHeightCtrl.Text = "0px";
            this.imageHeightCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageWidthCtrl
            // 
            this.imageWidthCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageWidthCtrl.Location = new System.Drawing.Point(72, 30);
            this.imageWidthCtrl.Margin = new System.Windows.Forms.Padding(2);
            this.imageWidthCtrl.Name = "imageWidthCtrl";
            this.imageWidthCtrl.Size = new System.Drawing.Size(74, 22);
            this.imageWidthCtrl.TabIndex = 3;
            this.imageWidthCtrl.Text = "0px";
            this.imageWidthCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(15, 60);
            this.HeightLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(49, 17);
            this.HeightLabel.TabIndex = 1;
            this.HeightLabel.Text = "Height";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(17, 32);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(44, 17);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width";
            this.widthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cameraCtrlsBox
            // 
            this.cameraCtrlsBox.Controls.Add(this.cameraFOVCtrl);
            this.cameraCtrlsBox.Controls.Add(this.cameraDistanceCtrl);
            this.cameraCtrlsBox.Controls.Add(this.imageFOVLabel);
            this.cameraCtrlsBox.Controls.Add(this.imageDistanceLabel);
            this.cameraCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraCtrlsBox.Location = new System.Drawing.Point(163, 432);
            this.cameraCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.cameraCtrlsBox.Name = "cameraCtrlsBox";
            this.cameraCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.cameraCtrlsBox.Size = new System.Drawing.Size(170, 95);
            this.cameraCtrlsBox.TabIndex = 6;
            this.cameraCtrlsBox.TabStop = false;
            this.cameraCtrlsBox.Text = "Camera";
            // 
            // imageFOVLabel
            // 
            this.imageFOVLabel.AutoSize = true;
            this.imageFOVLabel.Location = new System.Drawing.Point(10, 60);
            this.imageFOVLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.imageFOVLabel.Name = "imageFOVLabel";
            this.imageFOVLabel.Size = new System.Drawing.Size(87, 17);
            this.imageFOVLabel.TabIndex = 1;
            this.imageFOVLabel.Text = "Field of View";
            this.imageFOVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageDistanceLabel
            // 
            this.imageDistanceLabel.AutoSize = true;
            this.imageDistanceLabel.Location = new System.Drawing.Point(20, 32);
            this.imageDistanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.imageDistanceLabel.Name = "imageDistanceLabel";
            this.imageDistanceLabel.Size = new System.Drawing.Size(63, 17);
            this.imageDistanceLabel.TabIndex = 0;
            this.imageDistanceLabel.Text = "Distance";
            this.imageDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rendererCtrlsBox
            // 
            this.rendererCtrlsBox.Controls.Add(this.startRenderBtn);
            this.rendererCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rendererCtrlsBox.Location = new System.Drawing.Point(169, 354);
            this.rendererCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.rendererCtrlsBox.Name = "rendererCtrlsBox";
            this.rendererCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.rendererCtrlsBox.Size = new System.Drawing.Size(150, 73);
            this.rendererCtrlsBox.TabIndex = 2;
            this.rendererCtrlsBox.TabStop = false;
            this.rendererCtrlsBox.Text = "Renderer";
            // 
            // startRenderBtn
            // 
            this.startRenderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.startRenderBtn.Location = new System.Drawing.Point(19, 21);
            this.startRenderBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startRenderBtn.Name = "startRenderBtn";
            this.startRenderBtn.Size = new System.Drawing.Size(112, 41);
            this.startRenderBtn.TabIndex = 0;
            this.startRenderBtn.Text = "Start";
            this.startRenderBtn.UseVisualStyleBackColor = true;
            this.startRenderBtn.Click += new System.EventHandler(this.startRenderBtn_Click);
            // 
            // recursionCtrlsBox
            // 
            this.recursionCtrlsBox.Controls.Add(this.recursiveIndex);
            this.recursionCtrlsBox.Controls.Add(this.label3);
            this.recursionCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recursionCtrlsBox.Location = new System.Drawing.Point(323, 354);
            this.recursionCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.recursionCtrlsBox.Name = "recursionCtrlsBox";
            this.recursionCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.recursionCtrlsBox.Size = new System.Drawing.Size(150, 73);
            this.recursionCtrlsBox.TabIndex = 7;
            this.recursionCtrlsBox.TabStop = false;
            this.recursionCtrlsBox.Text = "Recursion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Depth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightEffectsCtrlsBox
            // 
            this.lightEffectsCtrlsBox.Controls.Add(this.shadowsCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.refractionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.specularReflectionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.difuseReflectionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.ambientLightCheckBox);
            this.lightEffectsCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightEffectsCtrlsBox.Location = new System.Drawing.Point(337, 432);
            this.lightEffectsCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.lightEffectsCtrlsBox.Name = "lightEffectsCtrlsBox";
            this.lightEffectsCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.lightEffectsCtrlsBox.Size = new System.Drawing.Size(170, 161);
            this.lightEffectsCtrlsBox.TabIndex = 7;
            this.lightEffectsCtrlsBox.TabStop = false;
            this.lightEffectsCtrlsBox.Text = "Light Effects";
            // 
            // shadowsCheckBox
            // 
            this.shadowsCheckBox.AutoSize = true;
            this.shadowsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.shadowsCheckBox.Location = new System.Drawing.Point(20, 76);
            this.shadowsCheckBox.Name = "shadowsCheckBox";
            this.shadowsCheckBox.Size = new System.Drawing.Size(84, 21);
            this.shadowsCheckBox.TabIndex = 10;
            this.shadowsCheckBox.Text = "Shadows";
            this.shadowsCheckBox.UseVisualStyleBackColor = true;
            // 
            // refractionCheckBox
            // 
            this.refractionCheckBox.AutoSize = true;
            this.refractionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.refractionCheckBox.Location = new System.Drawing.Point(20, 128);
            this.refractionCheckBox.Name = "refractionCheckBox";
            this.refractionCheckBox.Size = new System.Drawing.Size(92, 21);
            this.refractionCheckBox.TabIndex = 9;
            this.refractionCheckBox.Text = "Refraction";
            this.refractionCheckBox.UseVisualStyleBackColor = true;
            // 
            // specularReflectionCheckBox
            // 
            this.specularReflectionCheckBox.AutoSize = true;
            this.specularReflectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.specularReflectionCheckBox.Location = new System.Drawing.Point(20, 102);
            this.specularReflectionCheckBox.Name = "specularReflectionCheckBox";
            this.specularReflectionCheckBox.Size = new System.Drawing.Size(150, 21);
            this.specularReflectionCheckBox.TabIndex = 8;
            this.specularReflectionCheckBox.Text = "Specular Reflection";
            this.specularReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // difuseReflectionCheckBox
            // 
            this.difuseReflectionCheckBox.AutoSize = true;
            this.difuseReflectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.difuseReflectionCheckBox.Location = new System.Drawing.Point(20, 50);
            this.difuseReflectionCheckBox.Name = "difuseReflectionCheckBox";
            this.difuseReflectionCheckBox.Size = new System.Drawing.Size(134, 21);
            this.difuseReflectionCheckBox.TabIndex = 7;
            this.difuseReflectionCheckBox.Text = "Difuse Reflection";
            this.difuseReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // ambientLightCheckBox
            // 
            this.ambientLightCheckBox.AutoSize = true;
            this.ambientLightCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ambientLightCheckBox.Location = new System.Drawing.Point(20, 24);
            this.ambientLightCheckBox.Name = "ambientLightCheckBox";
            this.ambientLightCheckBox.Size = new System.Drawing.Size(113, 21);
            this.ambientLightCheckBox.TabIndex = 0;
            this.ambientLightCheckBox.Text = "Ambient Light";
            this.ambientLightCheckBox.UseVisualStyleBackColor = true;
            // 
            // backgroundCtrlsBox
            // 
            this.backgroundCtrlsBox.Controls.Add(this.selectedColorLabel);
            this.backgroundCtrlsBox.Controls.Add(this.backgroundColorLabel);
            this.backgroundCtrlsBox.Controls.Add(this.backgroundColorBtn);
            this.backgroundCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundCtrlsBox.Location = new System.Drawing.Point(169, 531);
            this.backgroundCtrlsBox.Margin = new System.Windows.Forms.Padding(2);
            this.backgroundCtrlsBox.Name = "backgroundCtrlsBox";
            this.backgroundCtrlsBox.Padding = new System.Windows.Forms.Padding(2);
            this.backgroundCtrlsBox.Size = new System.Drawing.Size(164, 102);
            this.backgroundCtrlsBox.TabIndex = 8;
            this.backgroundCtrlsBox.TabStop = false;
            this.backgroundCtrlsBox.Text = "Background";
            // 
            // selectedColorLabel
            // 
            this.selectedColorLabel.AutoSize = true;
            this.selectedColorLabel.Location = new System.Drawing.Point(4, 72);
            this.selectedColorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.selectedColorLabel.Name = "selectedColorLabel";
            this.selectedColorLabel.Size = new System.Drawing.Size(104, 17);
            this.selectedColorLabel.TabIndex = 16;
            this.selectedColorLabel.Text = "Selected Color:";
            // 
            // backgroundColorLabel
            // 
            this.backgroundColorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.backgroundColorLabel.Location = new System.Drawing.Point(113, 72);
            this.backgroundColorLabel.Name = "backgroundColorLabel";
            this.backgroundColorLabel.Size = new System.Drawing.Size(44, 20);
            this.backgroundColorLabel.TabIndex = 15;
            this.backgroundColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundColorBtn
            // 
            this.backgroundColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.backgroundColorBtn.Location = new System.Drawing.Point(19, 21);
            this.backgroundColorBtn.Margin = new System.Windows.Forms.Padding(2);
            this.backgroundColorBtn.Name = "backgroundColorBtn";
            this.backgroundColorBtn.Size = new System.Drawing.Size(131, 41);
            this.backgroundColorBtn.TabIndex = 1;
            this.backgroundColorBtn.Text = "Choose Color";
            this.backgroundColorBtn.UseVisualStyleBackColor = true;
            this.backgroundColorBtn.Click += new System.EventHandler(this.backgroundColorBtn_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 324);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(356, 19);
            this.progressBar1.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(374, 326);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(147, 17);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Waiting for renderer...";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cameraDistanceCtrl
            // 
            this.cameraDistanceCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cameraDistanceCtrl.Location = new System.Drawing.Point(101, 30);
            this.cameraDistanceCtrl.Name = "cameraDistanceCtrl";
            this.cameraDistanceCtrl.Size = new System.Drawing.Size(56, 22);
            this.cameraDistanceCtrl.TabIndex = 11;
            this.cameraDistanceCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cameraFOVCtrl
            // 
            this.cameraFOVCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.cameraFOVCtrl.Location = new System.Drawing.Point(101, 58);
            this.cameraFOVCtrl.Name = "cameraFOVCtrl";
            this.cameraFOVCtrl.Size = new System.Drawing.Size(56, 22);
            this.cameraFOVCtrl.TabIndex = 12;
            this.cameraFOVCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // recursiveIndex
            // 
            this.recursiveIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.recursiveIndex.Location = new System.Drawing.Point(78, 30);
            this.recursiveIndex.Name = "recursiveIndex";
            this.recursiveIndex.Size = new System.Drawing.Size(56, 22);
            this.recursiveIndex.TabIndex = 13;
            this.recursiveIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.antiAliasingCheckBox);
            this.groupBox1.Controls.Add(this.numSamplesWheel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 586);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(150, 90);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Anti-Aliasing";
            // 
            // numSamplesWheel
            // 
            this.numSamplesWheel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.numSamplesWheel.Location = new System.Drawing.Point(78, 54);
            this.numSamplesWheel.Name = "numSamplesWheel";
            this.numSamplesWheel.Size = new System.Drawing.Size(56, 22);
            this.numSamplesWheel.TabIndex = 13;
            this.numSamplesWheel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Samples";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // antiAliasingCheckBox
            // 
            this.antiAliasingCheckBox.AutoSize = true;
            this.antiAliasingCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.antiAliasingCheckBox.Location = new System.Drawing.Point(32, 26);
            this.antiAliasingCheckBox.Name = "antiAliasingCheckBox";
            this.antiAliasingCheckBox.Size = new System.Drawing.Size(77, 21);
            this.antiAliasingCheckBox.TabIndex = 11;
            this.antiAliasingCheckBox.Text = "Activate";
            this.antiAliasingCheckBox.UseVisualStyleBackColor = true;
            // 
            // RayTracerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 687);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.backgroundCtrlsBox);
            this.Controls.Add(this.lightEffectsCtrlsBox);
            this.Controls.Add(this.recursionCtrlsBox);
            this.Controls.Add(this.rendererCtrlsBox);
            this.Controls.Add(this.cameraCtrlsBox);
            this.Controls.Add(this.imageCtrlsBox);
            this.Controls.Add(this.sceneCtrlsBox);
            this.Controls.Add(this.rayTracerBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RayTracerForm";
            this.Text = "Ray Tracer";
            this.rayTracerBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rayTracerPictBox)).EndInit();
            this.sceneCtrlsBox.ResumeLayout(false);
            this.imageCtrlsBox.ResumeLayout(false);
            this.imageCtrlsBox.PerformLayout();
            this.cameraCtrlsBox.ResumeLayout(false);
            this.cameraCtrlsBox.PerformLayout();
            this.rendererCtrlsBox.ResumeLayout(false);
            this.recursionCtrlsBox.ResumeLayout(false);
            this.recursionCtrlsBox.PerformLayout();
            this.lightEffectsCtrlsBox.ResumeLayout(false);
            this.lightEffectsCtrlsBox.PerformLayout();
            this.backgroundCtrlsBox.ResumeLayout(false);
            this.backgroundCtrlsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDistanceCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFOVCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursiveIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSamplesWheel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox rayTracerBox;
        private System.Windows.Forms.GroupBox sceneCtrlsBox;
        private System.Windows.Forms.Button loadSceneBtn;
        private System.Windows.Forms.GroupBox imageCtrlsBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.DomainUpDown imageHeightCtrl;
        private System.Windows.Forms.DomainUpDown imageWidthCtrl;
        private System.Windows.Forms.GroupBox cameraCtrlsBox;
        private System.Windows.Forms.Label imageFOVLabel;
        private System.Windows.Forms.Label imageDistanceLabel;
        private System.Windows.Forms.GroupBox rendererCtrlsBox;
        private System.Windows.Forms.Button startRenderBtn;
        private System.Windows.Forms.GroupBox recursionCtrlsBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.GroupBox lightEffectsCtrlsBox;
        private System.Windows.Forms.CheckBox ambientLightCheckBox;
        private System.Windows.Forms.CheckBox difuseReflectionCheckBox;
        private System.Windows.Forms.CheckBox specularReflectionCheckBox;
        private System.Windows.Forms.CheckBox refractionCheckBox;
        private System.Windows.Forms.GroupBox backgroundCtrlsBox;
        private System.Windows.Forms.Button backgroundColorBtn;
        private System.Windows.Forms.PictureBox rayTracerPictBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.CheckBox shadowsCheckBox;
        private System.Windows.Forms.Label backgroundColorLabel;
        private System.Windows.Forms.Label selectedColorLabel;
        private System.Windows.Forms.NumericUpDown cameraDistanceCtrl;
        private System.Windows.Forms.NumericUpDown cameraFOVCtrl;
        private System.Windows.Forms.NumericUpDown recursiveIndex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numSamplesWheel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox antiAliasingCheckBox;
    }
}

