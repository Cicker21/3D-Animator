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
            nud_G = new NumericUpDown();
            label2 = new Label();
            nud_Pasos = new NumericUpDown();
            label6 = new Label();
            nud_FR = new NumericUpDown();
            label3 = new Label();
            nud_GY = new NumericUpDown();
            label9 = new Label();
            nud_GX = new NumericUpDown();
            label10 = new Label();
            label11 = new Label();
            nud_FZ = new NumericUpDown();
            nud_FY = new NumericUpDown();
            label12 = new Label();
            nud_FX = new NumericUpDown();
            label13 = new Label();
            b_visualizar = new Button();
            ((System.ComponentModel.ISupportInitialize)nud_G).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_Pasos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_FR).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_FZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_FY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_FX).BeginInit();
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
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Caida";
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
            // nud_FR
            // 
            nud_FR.Location = new Point(286, 50);
            nud_FR.Name = "nud_FR";
            nud_FR.Size = new Size(120, 23);
            nud_FR.TabIndex = 16;
            nud_FR.Value = new decimal(new int[] { 98, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(286, 32);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 15;
            label3.Text = "Rozamiento";
            // 
            // nud_GY
            // 
            nud_GY.Location = new Point(148, 122);
            nud_GY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GY.Name = "nud_GY";
            nud_GY.Size = new Size(120, 23);
            nud_GY.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(148, 104);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 25;
            label9.Text = "Giro Y";
            // 
            // nud_GX
            // 
            nud_GX.Location = new Point(11, 122);
            nud_GX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GX.Name = "nud_GX";
            nud_GX.Size = new Size(120, 23);
            nud_GX.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 104);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 23;
            label10.Text = "Giro X";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(286, 148);
            label11.Name = "label11";
            label11.Size = new Size(23, 15);
            label11.TabIndex = 34;
            label11.Text = "F Z";
            // 
            // nud_FZ
            // 
            nud_FZ.Location = new Point(286, 166);
            nud_FZ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FZ.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FZ.Name = "nud_FZ";
            nud_FZ.Size = new Size(120, 23);
            nud_FZ.TabIndex = 33;
            // 
            // nud_FY
            // 
            nud_FY.Location = new Point(148, 166);
            nud_FY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FY.Name = "nud_FY";
            nud_FY.Size = new Size(120, 23);
            nud_FY.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(148, 148);
            label12.Name = "label12";
            label12.Size = new Size(23, 15);
            label12.TabIndex = 31;
            label12.Text = "F Y";
            // 
            // nud_FX
            // 
            nud_FX.Location = new Point(11, 166);
            nud_FX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FX.Name = "nud_FX";
            nud_FX.Size = new Size(120, 23);
            nud_FX.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(11, 148);
            label13.Name = "label13";
            label13.Size = new Size(23, 15);
            label13.TabIndex = 29;
            label13.Text = "F X";
            // 
            // b_visualizar
            // 
            b_visualizar.Location = new Point(148, 232);
            b_visualizar.Name = "b_visualizar";
            b_visualizar.Size = new Size(120, 45);
            b_visualizar.TabIndex = 51;
            b_visualizar.Text = "VISUALIZAR";
            b_visualizar.UseVisualStyleBackColor = true;
            b_visualizar.Click += visualizar;
            // 
            // Simulador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 307);
            Controls.Add(b_visualizar);
            Controls.Add(label11);
            Controls.Add(nud_FZ);
            Controls.Add(nud_FY);
            Controls.Add(label12);
            Controls.Add(nud_FX);
            Controls.Add(label13);
            Controls.Add(nud_GY);
            Controls.Add(label9);
            Controls.Add(nud_GX);
            Controls.Add(label10);
            Controls.Add(nud_FR);
            Controls.Add(label3);
            Controls.Add(nud_Pasos);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(nud_G);
            Name = "Simulador";
            Text = "Simulador";
            ((System.ComponentModel.ISupportInitialize)nud_G).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_Pasos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_FR).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GX).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_FZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_FY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_FX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown nud_G;
        private Label label2;
        private NumericUpDown nud_Pasos;
        private Label label6;
        private NumericUpDown nud_FR;
        private Label label3;
        private NumericUpDown nud_GY;
        private Label label9;
        private NumericUpDown nud_GX;
        private Label label10;
        private Label label11;
        private NumericUpDown nud_FZ;
        private NumericUpDown nud_FY;
        private Label label12;
        private NumericUpDown nud_FX;
        private Label label13;
        private Button b_visualizar;
    }
}