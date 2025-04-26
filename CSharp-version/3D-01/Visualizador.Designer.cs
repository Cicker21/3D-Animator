namespace _3D_01
{
    partial class Visualizador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Visualizador));
            openglControl1 = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            SuspendLayout();
            // 
            // openglControl1
            // 
            openglControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openglControl1.DrawFPS = true;
            openglControl1.FrameRate = 30;
            openglControl1.Location = new Point(13, 12);
            openglControl1.Margin = new Padding(4, 3, 4, 3);
            openglControl1.Name = "openglControl1";
            openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
            openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openglControl1.Size = new Size(803, 426);
            openglControl1.TabIndex = 0;
            openglControl1.OpenGLDraw += openGLControl1_OpenGLDraw;
            // 
            // Visualizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 450);
            Controls.Add(openglControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Visualizador";
            Text = "Visualizador";
            ((System.ComponentModel.ISupportInitialize)openglControl1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
    }
}
