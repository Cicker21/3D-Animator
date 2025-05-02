namespace _3D_02
{
    partial class PenduloOnline
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenduloOnline));
            openGLControl = new SharpGL.OpenGLControl();
            btnConectar = new Button();
            lblTheta1 = new Label();
            lblTheta2 = new Label();
            raw = new Label();
            ((System.ComponentModel.ISupportInitialize)openGLControl).BeginInit();
            SuspendLayout();
            // 
            // openGLControl
            // 
            openGLControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openGLControl.DrawFPS = false;
            openGLControl.Location = new Point(12, 74);
            openGLControl.Margin = new Padding(4, 3, 4, 3);
            openGLControl.Name = "openGLControl";
            openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openGLControl.Size = new Size(793, 364);
            openGLControl.TabIndex = 1;
            openGLControl.OpenGLDraw += openGLControl_OpenGLDraw;
            // 
            // btnConectar
            // 
            btnConectar.BackColor = Color.FromArgb(128, 255, 128);
            btnConectar.ForeColor = SystemColors.Desktop;
            btnConectar.Location = new Point(13, 45);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(184, 23);
            btnConectar.TabIndex = 2;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = false;
            // 
            // lblTheta1
            // 
            lblTheta1.AutoSize = true;
            lblTheta1.Location = new Point(13, 9);
            lblTheta1.Name = "lblTheta1";
            lblTheta1.Size = new Size(55, 15);
            lblTheta1.TabIndex = 3;
            lblTheta1.Text = "lblTheta1";
            lblTheta1.Click += label1_Click;
            // 
            // lblTheta2
            // 
            lblTheta2.AutoSize = true;
            lblTheta2.Location = new Point(12, 27);
            lblTheta2.Name = "lblTheta2";
            lblTheta2.Size = new Size(55, 15);
            lblTheta2.TabIndex = 4;
            lblTheta2.Text = "lblTheta2";
            // 
            // raw
            // 
            raw.AutoSize = true;
            raw.Location = new Point(282, 12);
            raw.Name = "raw";
            raw.Size = new Size(26, 15);
            raw.TabIndex = 5;
            raw.Text = "raw";
            // 
            // PenduloOnline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 450);
            Controls.Add(raw);
            Controls.Add(lblTheta2);
            Controls.Add(lblTheta1);
            Controls.Add(btnConectar);
            Controls.Add(openGLControl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PenduloOnline";
            Text = "PenduloOnline";
            ((System.ComponentModel.ISupportInitialize)openGLControl).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private SharpGL.OpenGLControl openGLControl;
        private Button btnConectar;
        private Label lblTheta1;
        private Label lblTheta2;
        private Label raw;
    }
}