namespace _3D_01
{
    partial class Simulador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulador));
            nud_G = new NumericUpDown();
            label2 = new Label();
            nud_Pasos = new NumericUpDown();
            label6 = new Label();
            b_visualizar = new Button();
            g_afisicas = new Button();
            ((System.ComponentModel.ISupportInitialize)nud_G).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Pasos).BeginInit();
            SuspendLayout();
            // 
            // nud_G
            // 
            nud_G.Location = new Point(11, 50);
            nud_G.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_G.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_G.Name = "nud_G";
            nud_G.Size = new Size(120, 23);
            nud_G.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 32);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Gravedad";
            // 
            // nud_Pasos
            // 
            nud_Pasos.Location = new Point(148, 50);
            nud_Pasos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_Pasos.Name = "nud_Pasos";
            nud_Pasos.Size = new Size(120, 23);
            nud_Pasos.TabIndex = 11;
            nud_Pasos.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(148, 32);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 10;
            label6.Text = "Pasos";
            // 
            // b_visualizar
            // 
            b_visualizar.Location = new Point(67, 237);
            b_visualizar.Name = "b_visualizar";
            b_visualizar.Size = new Size(120, 45);
            b_visualizar.TabIndex = 51;
            b_visualizar.Text = "ABRIR ARCHIVO";
            b_visualizar.UseVisualStyleBackColor = true;
            b_visualizar.Click += cargar_datos;
            // 
            // g_afisicas
            // 
            g_afisicas.Location = new Point(236, 237);
            g_afisicas.Name = "g_afisicas";
            g_afisicas.Size = new Size(120, 45);
            g_afisicas.TabIndex = 52;
            g_afisicas.Text = "AÑADIR FISICAS";
            g_afisicas.UseVisualStyleBackColor = true;
            g_afisicas.Click += g_afisicas_Click;
            // 
            // Simulador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 307);
            Controls.Add(g_afisicas);
            Controls.Add(b_visualizar);
            Controls.Add(nud_Pasos);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(nud_G);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Simulador";
            Text = "Simulador";
            ((System.ComponentModel.ISupportInitialize)nud_G).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Pasos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown nud_G;
        private Label label2;
        private NumericUpDown nud_Pasos;
        private Label label6;
        private Button b_visualizar;
        private Button g_afisicas;
    }
}