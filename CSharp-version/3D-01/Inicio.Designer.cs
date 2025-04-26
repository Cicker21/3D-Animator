namespace _3D_01
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            b_init = new Button();
            b_create = new Button();
            b_fisicas = new Button();
            SuspendLayout();
            // 
            // b_init
            // 
            b_init.Location = new Point(12, 35);
            b_init.Name = "b_init";
            b_init.Size = new Size(390, 55);
            b_init.TabIndex = 0;
            b_init.Text = "INICIAR SIMULACION";
            b_init.UseVisualStyleBackColor = true;
            b_init.Click += iniciar;
            // 
            // b_create
            // 
            b_create.Location = new Point(12, 119);
            b_create.Name = "b_create";
            b_create.Size = new Size(390, 58);
            b_create.TabIndex = 2;
            b_create.Text = "CREAR SIMULACION";
            b_create.UseVisualStyleBackColor = true;
            b_create.Click += crear;
            // 
            // b_fisicas
            // 
            b_fisicas.Location = new Point(12, 200);
            b_fisicas.Name = "b_fisicas";
            b_fisicas.Size = new Size(390, 58);
            b_fisicas.TabIndex = 3;
            b_fisicas.Text = "AÑADIR FÍSICAS";
            b_fisicas.UseVisualStyleBackColor = true;
            b_fisicas.Click += b_fisicas_Click;
            // 
            // Inicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 285);
            Controls.Add(b_fisicas);
            Controls.Add(b_create);
            Controls.Add(b_init);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Inicio";
            Text = "Inicio";
            ResumeLayout(false);
        }

        #endregion

        private Button b_init;
        private Button b_create;
        private Button b_fisicas;
    }
}