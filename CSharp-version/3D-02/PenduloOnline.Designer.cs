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
            openGLControl = new SharpGL.OpenGLControl();
            btnConectar = new Button();
            lblTheta1 = new Label();
            lblTheta2 = new Label();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)openGLControl).BeginInit();
            SuspendLayout();
            // 
            // openGLControl
            // 
            openGLControl.DrawFPS = false;
            openGLControl.Location = new Point(13, 126);
            openGLControl.Margin = new Padding(4, 3, 4, 3);
            openGLControl.Name = "openGLControl";
            openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openGLControl.Size = new Size(693, 312);
            openGLControl.TabIndex = 1;
            openGLControl.OpenGLDraw += openGLControl_OpenGLDraw;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(713, 126);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(75, 23);
            btnConectar.TabIndex = 2;
            btnConectar.Text = "button1";
            btnConectar.UseVisualStyleBackColor = true;
            // 
            // lblTheta1
            // 
            lblTheta1.AutoSize = true;
            lblTheta1.Location = new Point(35, 36);
            lblTheta1.Name = "lblTheta1";
            lblTheta1.Size = new Size(55, 15);
            lblTheta1.TabIndex = 3;
            lblTheta1.Text = "lblTheta1";
            lblTheta1.Click += label1_Click;
            // 
            // lblTheta2
            // 
            lblTheta2.AutoSize = true;
            lblTheta2.Location = new Point(35, 70);
            lblTheta2.Name = "lblTheta2";
            lblTheta2.Size = new Size(55, 15);
            lblTheta2.TabIndex = 4;
            lblTheta2.Text = "lblTheta2";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(290, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(416, 96);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // PenduloOnline
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(lblTheta2);
            Controls.Add(lblTheta1);
            Controls.Add(btnConectar);
            Controls.Add(openGLControl);
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
        private RichTextBox richTextBox1;
    }
}