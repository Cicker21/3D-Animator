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
            tb_archivo = new TextBox();
            label1 = new Label();
            nud_G = new NumericUpDown();
            label2 = new Label();
            nud_Pasos = new NumericUpDown();
            label6 = new Label();
            b_generar = new Button();
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
            tb_v1 = new TextBox();
            label4 = new Label();
            label7 = new Label();
            tb_v5 = new TextBox();
            label8 = new Label();
            tb_v2 = new TextBox();
            label14 = new Label();
            tb_v6 = new TextBox();
            label15 = new Label();
            tb_v3 = new TextBox();
            label16 = new Label();
            tb_v7 = new TextBox();
            label17 = new Label();
            tb_v4 = new TextBox();
            label18 = new Label();
            tb_v8 = new TextBox();
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
            // tb_archivo
            // 
            tb_archivo.Location = new Point(12, 27);
            tb_archivo.Name = "tb_archivo";
            tb_archivo.Size = new Size(236, 23);
            tb_archivo.TabIndex = 0;
            tb_archivo.Text = "test";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 1;
            label1.Text = "archivo de salida:";
            // 
            // nud_G
            // 
            nud_G.Location = new Point(12, 111);
            nud_G.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_G.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_G.Name = "nud_G";
            nud_G.Size = new Size(120, 23);
            nud_G.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 93);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 3;
            label2.Text = "Caida";
            // 
            // nud_Pasos
            // 
            nud_Pasos.Location = new Point(149, 111);
            nud_Pasos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_Pasos.Name = "nud_Pasos";
            nud_Pasos.Size = new Size(120, 23);
            nud_Pasos.TabIndex = 11;
            nud_Pasos.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(149, 93);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 10;
            label6.Text = "Pasos";
            // 
            // b_generar
            // 
            b_generar.Location = new Point(316, 27);
            b_generar.Name = "b_generar";
            b_generar.Size = new Size(102, 41);
            b_generar.TabIndex = 14;
            b_generar.Text = "GENERAR";
            b_generar.UseVisualStyleBackColor = true;
            b_generar.Click += generar;
            // 
            // nud_FR
            // 
            nud_FR.Location = new Point(287, 111);
            nud_FR.Name = "nud_FR";
            nud_FR.Size = new Size(120, 23);
            nud_FR.TabIndex = 16;
            nud_FR.Value = new decimal(new int[] { 98, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(287, 93);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 15;
            label3.Text = "Rozamiento";
            // 
            // nud_GY
            // 
            nud_GY.Location = new Point(149, 183);
            nud_GY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GY.Name = "nud_GY";
            nud_GY.Size = new Size(120, 23);
            nud_GY.TabIndex = 26;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(149, 165);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 25;
            label9.Text = "Giro Y";
            // 
            // nud_GX
            // 
            nud_GX.Location = new Point(12, 183);
            nud_GX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GX.Name = "nud_GX";
            nud_GX.Size = new Size(120, 23);
            nud_GX.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 165);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 23;
            label10.Text = "Giro X";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(287, 209);
            label11.Name = "label11";
            label11.Size = new Size(23, 15);
            label11.TabIndex = 34;
            label11.Text = "F Z";
            // 
            // nud_FZ
            // 
            nud_FZ.Location = new Point(287, 227);
            nud_FZ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FZ.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FZ.Name = "nud_FZ";
            nud_FZ.Size = new Size(120, 23);
            nud_FZ.TabIndex = 33;
            // 
            // nud_FY
            // 
            nud_FY.Location = new Point(149, 227);
            nud_FY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FY.Name = "nud_FY";
            nud_FY.Size = new Size(120, 23);
            nud_FY.TabIndex = 32;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(149, 209);
            label12.Name = "label12";
            label12.Size = new Size(23, 15);
            label12.TabIndex = 31;
            label12.Text = "F Y";
            // 
            // nud_FX
            // 
            nud_FX.Location = new Point(12, 227);
            nud_FX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_FX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_FX.Name = "nud_FX";
            nud_FX.Size = new Size(120, 23);
            nud_FX.TabIndex = 30;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 209);
            label13.Name = "label13";
            label13.Size = new Size(23, 15);
            label13.TabIndex = 29;
            label13.Text = "F X";
            // 
            // tb_v1
            // 
            tb_v1.Location = new Point(12, 321);
            tb_v1.Name = "tb_v1";
            tb_v1.Size = new Size(120, 23);
            tb_v1.TabIndex = 35;
            tb_v1.Text = "-1.0, -1.0, 1.0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 303);
            label4.Name = "label4";
            label4.Size = new Size(20, 15);
            label4.TabIndex = 36;
            label4.Text = "V1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(165, 303);
            label7.Name = "label7";
            label7.Size = new Size(20, 15);
            label7.TabIndex = 38;
            label7.Text = "V5";
            // 
            // tb_v5
            // 
            tb_v5.Location = new Point(165, 321);
            tb_v5.Name = "tb_v5";
            tb_v5.Size = new Size(120, 23);
            tb_v5.TabIndex = 37;
            tb_v5.Text = "-1.0, -1.0, -1.0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 347);
            label8.Name = "label8";
            label8.Size = new Size(20, 15);
            label8.TabIndex = 40;
            label8.Text = "V2";
            // 
            // tb_v2
            // 
            tb_v2.Location = new Point(12, 365);
            tb_v2.Name = "tb_v2";
            tb_v2.Size = new Size(120, 23);
            tb_v2.TabIndex = 39;
            tb_v2.Text = "1.0, -1.0, 1.0";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(165, 347);
            label14.Name = "label14";
            label14.Size = new Size(20, 15);
            label14.TabIndex = 42;
            label14.Text = "V6";
            // 
            // tb_v6
            // 
            tb_v6.Location = new Point(165, 365);
            tb_v6.Name = "tb_v6";
            tb_v6.Size = new Size(120, 23);
            tb_v6.TabIndex = 41;
            tb_v6.Text = "1.0, -1.0, -1.0";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 391);
            label15.Name = "label15";
            label15.Size = new Size(20, 15);
            label15.TabIndex = 44;
            label15.Text = "V3";
            // 
            // tb_v3
            // 
            tb_v3.Location = new Point(12, 409);
            tb_v3.Name = "tb_v3";
            tb_v3.Size = new Size(120, 23);
            tb_v3.TabIndex = 43;
            tb_v3.Text = "1.0, 1.0, 1.0";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(163, 391);
            label16.Name = "label16";
            label16.Size = new Size(20, 15);
            label16.TabIndex = 46;
            label16.Text = "V7";
            // 
            // tb_v7
            // 
            tb_v7.Location = new Point(163, 409);
            tb_v7.Name = "tb_v7";
            tb_v7.Size = new Size(120, 23);
            tb_v7.TabIndex = 45;
            tb_v7.Text = "1.0, 1.0, -1.0";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(12, 435);
            label17.Name = "label17";
            label17.Size = new Size(20, 15);
            label17.TabIndex = 48;
            label17.Text = "V4";
            // 
            // tb_v4
            // 
            tb_v4.Location = new Point(12, 453);
            tb_v4.Name = "tb_v4";
            tb_v4.Size = new Size(120, 23);
            tb_v4.TabIndex = 47;
            tb_v4.Text = "-1.0, 1.0, 1.0";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(163, 435);
            label18.Name = "label18";
            label18.Size = new Size(20, 15);
            label18.TabIndex = 50;
            label18.Text = "V8";
            // 
            // tb_v8
            // 
            tb_v8.Location = new Point(163, 453);
            tb_v8.Name = "tb_v8";
            tb_v8.Size = new Size(120, 23);
            tb_v8.TabIndex = 49;
            tb_v8.Text = "-1.0, 1.0, -1.0";
            // 
            // b_visualizar
            // 
            b_visualizar.Location = new Point(343, 376);
            b_visualizar.Name = "b_visualizar";
            b_visualizar.Size = new Size(93, 45);
            b_visualizar.TabIndex = 51;
            b_visualizar.Text = "VISUALIZAR";
            b_visualizar.UseVisualStyleBackColor = true;
            b_visualizar.Click += visualizar;
            // 
            // Simulador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 519);
            Controls.Add(b_visualizar);
            Controls.Add(label18);
            Controls.Add(tb_v8);
            Controls.Add(label17);
            Controls.Add(tb_v4);
            Controls.Add(label16);
            Controls.Add(tb_v7);
            Controls.Add(label15);
            Controls.Add(tb_v3);
            Controls.Add(label14);
            Controls.Add(tb_v6);
            Controls.Add(label8);
            Controls.Add(tb_v2);
            Controls.Add(label7);
            Controls.Add(tb_v5);
            Controls.Add(label4);
            Controls.Add(tb_v1);
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
            Controls.Add(b_generar);
            Controls.Add(nud_Pasos);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(nud_G);
            Controls.Add(label1);
            Controls.Add(tb_archivo);
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

        private TextBox tb_archivo;
        private Label label1;
        private NumericUpDown nud_G;
        private Label label2;
        private NumericUpDown nud_Pasos;
        private Label label6;
        private Button b_generar;
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
        private TextBox tb_v1;
        private Label label4;
        private Label label7;
        private TextBox tb_v5;
        private Label label8;
        private TextBox tb_v2;
        private Label label14;
        private TextBox tb_v6;
        private Label label15;
        private TextBox tb_v3;
        private Label label16;
        private TextBox tb_v7;
        private Label label17;
        private TextBox tb_v4;
        private Label label18;
        private TextBox tb_v8;
        private Button b_visualizar;
    }
}