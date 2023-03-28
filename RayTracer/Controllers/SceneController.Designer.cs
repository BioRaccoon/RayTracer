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
            this.cameraFOVCtrl = new System.Windows.Forms.DomainUpDown();
            this.cameraDistanceCtrl = new System.Windows.Forms.DomainUpDown();
            this.imageFOVLabel = new System.Windows.Forms.Label();
            this.imageDistanceLabel = new System.Windows.Forms.Label();
            this.rendererCtrlsBox = new System.Windows.Forms.GroupBox();
            this.startRenderBtn = new System.Windows.Forms.Button();
            this.recursionCtrlsBox = new System.Windows.Forms.GroupBox();
            this.recursiveIndex = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.lightEffectsCtrlsBox = new System.Windows.Forms.GroupBox();
            this.refractionCheckBox = new System.Windows.Forms.CheckBox();
            this.specularReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.difuseReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.ambientReflectionCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundCtrlsBox = new System.Windows.Forms.GroupBox();
            this.backgroundColorBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.rayTracerBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rayTracerPictBox)).BeginInit();
            this.sceneCtrlsBox.SuspendLayout();
            this.imageCtrlsBox.SuspendLayout();
            this.cameraCtrlsBox.SuspendLayout();
            this.rendererCtrlsBox.SuspendLayout();
            this.recursionCtrlsBox.SuspendLayout();
            this.lightEffectsCtrlsBox.SuspendLayout();
            this.backgroundCtrlsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // rayTracerBox
            // 
            this.rayTracerBox.Controls.Add(this.rayTracerPictBox);
            this.rayTracerBox.Location = new System.Drawing.Point(12, 12);
            this.rayTracerBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rayTracerBox.Name = "rayTracerBox";
            this.rayTracerBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rayTracerBox.Size = new System.Drawing.Size(664, 382);
            this.rayTracerBox.TabIndex = 0;
            this.rayTracerBox.TabStop = false;
            // 
            // rayTracerPictBox
            // 
            this.rayTracerPictBox.Location = new System.Drawing.Point(6, 20);
            this.rayTracerPictBox.Name = "rayTracerPictBox";
            this.rayTracerPictBox.Size = new System.Drawing.Size(652, 357);
            this.rayTracerPictBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rayTracerPictBox.TabIndex = 0;
            this.rayTracerPictBox.TabStop = false;
            // 
            // sceneCtrlsBox
            // 
            this.sceneCtrlsBox.Controls.Add(this.loadSceneBtn);
            this.sceneCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sceneCtrlsBox.Location = new System.Drawing.Point(12, 436);
            this.sceneCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sceneCtrlsBox.Name = "sceneCtrlsBox";
            this.sceneCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sceneCtrlsBox.Size = new System.Drawing.Size(200, 90);
            this.sceneCtrlsBox.TabIndex = 1;
            this.sceneCtrlsBox.TabStop = false;
            this.sceneCtrlsBox.Text = "Scene";
            // 
            // loadSceneBtn
            // 
            this.loadSceneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.loadSceneBtn.Location = new System.Drawing.Point(25, 26);
            this.loadSceneBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadSceneBtn.Name = "loadSceneBtn";
            this.loadSceneBtn.Size = new System.Drawing.Size(149, 50);
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
            this.imageCtrlsBox.Location = new System.Drawing.Point(12, 532);
            this.imageCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageCtrlsBox.Name = "imageCtrlsBox";
            this.imageCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageCtrlsBox.Size = new System.Drawing.Size(200, 185);
            this.imageCtrlsBox.TabIndex = 2;
            this.imageCtrlsBox.TabStop = false;
            this.imageCtrlsBox.Text = "Image";
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.saveImageBtn.Location = new System.Drawing.Point(25, 117);
            this.saveImageBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(149, 50);
            this.saveImageBtn.TabIndex = 0;
            this.saveImageBtn.Text = "Save Image";
            this.saveImageBtn.UseVisualStyleBackColor = true;
            this.saveImageBtn.Click += new System.EventHandler(this.saveImageBtn_Click);
            // 
            // imageHeightCtrl
            // 
            this.imageHeightCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageHeightCtrl.Location = new System.Drawing.Point(96, 71);
            this.imageHeightCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageHeightCtrl.Name = "imageHeightCtrl";
            this.imageHeightCtrl.Size = new System.Drawing.Size(98, 26);
            this.imageHeightCtrl.TabIndex = 4;
            this.imageHeightCtrl.Text = "0px";
            this.imageHeightCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageWidthCtrl
            // 
            this.imageWidthCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageWidthCtrl.Location = new System.Drawing.Point(96, 37);
            this.imageWidthCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageWidthCtrl.Name = "imageWidthCtrl";
            this.imageWidthCtrl.Size = new System.Drawing.Size(98, 26);
            this.imageWidthCtrl.TabIndex = 3;
            this.imageWidthCtrl.Text = "0px";
            this.imageWidthCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(20, 74);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(58, 20);
            this.HeightLabel.TabIndex = 1;
            this.HeightLabel.Text = "Height";
            this.HeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(23, 39);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(52, 20);
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
            this.cameraCtrlsBox.Location = new System.Drawing.Point(217, 532);
            this.cameraCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraCtrlsBox.Name = "cameraCtrlsBox";
            this.cameraCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraCtrlsBox.Size = new System.Drawing.Size(227, 117);
            this.cameraCtrlsBox.TabIndex = 6;
            this.cameraCtrlsBox.TabStop = false;
            this.cameraCtrlsBox.Text = "Camera";
            // 
            // cameraFOVCtrl
            // 
            this.cameraFOVCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraFOVCtrl.Location = new System.Drawing.Point(135, 71);
            this.cameraFOVCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraFOVCtrl.Name = "cameraFOVCtrl";
            this.cameraFOVCtrl.Size = new System.Drawing.Size(75, 26);
            this.cameraFOVCtrl.TabIndex = 4;
            this.cameraFOVCtrl.Text = "0";
            this.cameraFOVCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cameraDistanceCtrl
            // 
            this.cameraDistanceCtrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraDistanceCtrl.Location = new System.Drawing.Point(135, 37);
            this.cameraDistanceCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraDistanceCtrl.Name = "cameraDistanceCtrl";
            this.cameraDistanceCtrl.Size = new System.Drawing.Size(75, 26);
            this.cameraDistanceCtrl.TabIndex = 3;
            this.cameraDistanceCtrl.Text = "0";
            this.cameraDistanceCtrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageFOVLabel
            // 
            this.imageFOVLabel.AutoSize = true;
            this.imageFOVLabel.Location = new System.Drawing.Point(13, 74);
            this.imageFOVLabel.Name = "imageFOVLabel";
            this.imageFOVLabel.Size = new System.Drawing.Size(105, 20);
            this.imageFOVLabel.TabIndex = 1;
            this.imageFOVLabel.Text = "Field of View";
            this.imageFOVLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageDistanceLabel
            // 
            this.imageDistanceLabel.AutoSize = true;
            this.imageDistanceLabel.Location = new System.Drawing.Point(27, 39);
            this.imageDistanceLabel.Name = "imageDistanceLabel";
            this.imageDistanceLabel.Size = new System.Drawing.Size(76, 20);
            this.imageDistanceLabel.TabIndex = 0;
            this.imageDistanceLabel.Text = "Distance";
            this.imageDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rendererCtrlsBox
            // 
            this.rendererCtrlsBox.Controls.Add(this.startRenderBtn);
            this.rendererCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rendererCtrlsBox.Location = new System.Drawing.Point(225, 436);
            this.rendererCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rendererCtrlsBox.Name = "rendererCtrlsBox";
            this.rendererCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rendererCtrlsBox.Size = new System.Drawing.Size(200, 90);
            this.rendererCtrlsBox.TabIndex = 2;
            this.rendererCtrlsBox.TabStop = false;
            this.rendererCtrlsBox.Text = "Renderer";
            // 
            // startRenderBtn
            // 
            this.startRenderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.startRenderBtn.Location = new System.Drawing.Point(25, 26);
            this.startRenderBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startRenderBtn.Name = "startRenderBtn";
            this.startRenderBtn.Size = new System.Drawing.Size(149, 50);
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
            this.recursionCtrlsBox.Location = new System.Drawing.Point(431, 436);
            this.recursionCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recursionCtrlsBox.Name = "recursionCtrlsBox";
            this.recursionCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recursionCtrlsBox.Size = new System.Drawing.Size(200, 90);
            this.recursionCtrlsBox.TabIndex = 7;
            this.recursionCtrlsBox.TabStop = false;
            this.recursionCtrlsBox.Text = "Recursion";
            // 
            // recursiveIndex
            // 
            this.recursiveIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recursiveIndex.Location = new System.Drawing.Point(104, 37);
            this.recursiveIndex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recursiveIndex.Name = "recursiveIndex";
            this.recursiveIndex.Size = new System.Drawing.Size(75, 26);
            this.recursiveIndex.TabIndex = 3;
            this.recursiveIndex.Text = "0";
            this.recursiveIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Depth";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lightEffectsCtrlsBox
            // 
            this.lightEffectsCtrlsBox.Controls.Add(this.refractionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.specularReflectionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.difuseReflectionCheckBox);
            this.lightEffectsCtrlsBox.Controls.Add(this.ambientReflectionCheckBox);
            this.lightEffectsCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lightEffectsCtrlsBox.Location = new System.Drawing.Point(449, 532);
            this.lightEffectsCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lightEffectsCtrlsBox.Name = "lightEffectsCtrlsBox";
            this.lightEffectsCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lightEffectsCtrlsBox.Size = new System.Drawing.Size(227, 160);
            this.lightEffectsCtrlsBox.TabIndex = 7;
            this.lightEffectsCtrlsBox.TabStop = false;
            this.lightEffectsCtrlsBox.Text = "Light Effects";
            // 
            // refractionCheckBox
            // 
            this.refractionCheckBox.AutoSize = true;
            this.refractionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.refractionCheckBox.Location = new System.Drawing.Point(27, 123);
            this.refractionCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.refractionCheckBox.Name = "refractionCheckBox";
            this.refractionCheckBox.Size = new System.Drawing.Size(108, 24);
            this.refractionCheckBox.TabIndex = 9;
            this.refractionCheckBox.Text = "Refraction";
            this.refractionCheckBox.UseVisualStyleBackColor = true;
            // 
            // specularReflectionCheckBox
            // 
            this.specularReflectionCheckBox.AutoSize = true;
            this.specularReflectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.specularReflectionCheckBox.Location = new System.Drawing.Point(27, 92);
            this.specularReflectionCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.specularReflectionCheckBox.Name = "specularReflectionCheckBox";
            this.specularReflectionCheckBox.Size = new System.Drawing.Size(177, 24);
            this.specularReflectionCheckBox.TabIndex = 8;
            this.specularReflectionCheckBox.Text = "Specular Reflection";
            this.specularReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // difuseReflectionCheckBox
            // 
            this.difuseReflectionCheckBox.AutoSize = true;
            this.difuseReflectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.difuseReflectionCheckBox.Location = new System.Drawing.Point(27, 62);
            this.difuseReflectionCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.difuseReflectionCheckBox.Name = "difuseReflectionCheckBox";
            this.difuseReflectionCheckBox.Size = new System.Drawing.Size(160, 24);
            this.difuseReflectionCheckBox.TabIndex = 7;
            this.difuseReflectionCheckBox.Text = "Difuse Reflection";
            this.difuseReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // ambientReflectionCheckBox
            // 
            this.ambientReflectionCheckBox.AutoSize = true;
            this.ambientReflectionCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.ambientReflectionCheckBox.Location = new System.Drawing.Point(27, 31);
            this.ambientReflectionCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ambientReflectionCheckBox.Name = "ambientReflectionCheckBox";
            this.ambientReflectionCheckBox.Size = new System.Drawing.Size(172, 24);
            this.ambientReflectionCheckBox.TabIndex = 0;
            this.ambientReflectionCheckBox.Text = "Ambient Reflection";
            this.ambientReflectionCheckBox.UseVisualStyleBackColor = true;
            // 
            // backgroundCtrlsBox
            // 
            this.backgroundCtrlsBox.Controls.Add(this.backgroundColorBtn);
            this.backgroundCtrlsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundCtrlsBox.Location = new System.Drawing.Point(225, 654);
            this.backgroundCtrlsBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backgroundCtrlsBox.Name = "backgroundCtrlsBox";
            this.backgroundCtrlsBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backgroundCtrlsBox.Size = new System.Drawing.Size(200, 90);
            this.backgroundCtrlsBox.TabIndex = 8;
            this.backgroundCtrlsBox.TabStop = false;
            this.backgroundCtrlsBox.Text = "Background";
            // 
            // backgroundColorBtn
            // 
            this.backgroundColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.backgroundColorBtn.Location = new System.Drawing.Point(25, 26);
            this.backgroundColorBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backgroundColorBtn.Name = "backgroundColorBtn";
            this.backgroundColorBtn.Size = new System.Drawing.Size(149, 50);
            this.backgroundColorBtn.TabIndex = 1;
            this.backgroundColorBtn.Text = "Choose Color";
            this.backgroundColorBtn.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 399);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(474, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(498, 401);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(170, 20);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "Waiting for renderer...";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RayTracerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 755);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.DomainUpDown cameraFOVCtrl;
        private System.Windows.Forms.DomainUpDown cameraDistanceCtrl;
        private System.Windows.Forms.Label imageFOVLabel;
        private System.Windows.Forms.Label imageDistanceLabel;
        private System.Windows.Forms.GroupBox rendererCtrlsBox;
        private System.Windows.Forms.Button startRenderBtn;
        private System.Windows.Forms.GroupBox recursionCtrlsBox;
        private System.Windows.Forms.DomainUpDown recursiveIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.GroupBox lightEffectsCtrlsBox;
        private System.Windows.Forms.CheckBox ambientReflectionCheckBox;
        private System.Windows.Forms.CheckBox difuseReflectionCheckBox;
        private System.Windows.Forms.CheckBox specularReflectionCheckBox;
        private System.Windows.Forms.CheckBox refractionCheckBox;
        private System.Windows.Forms.GroupBox backgroundCtrlsBox;
        private System.Windows.Forms.Button backgroundColorBtn;
        private System.Windows.Forms.PictureBox rayTracerPictBox;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
    }
}

