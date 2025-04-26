namespace _3D_01
{
    partial class Bases
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bases));
            label1 = new Label();
            nud_tmñ = new NumericUpDown();
            nud_dx = new NumericUpDown();
            label2 = new Label();
            nud_dy = new NumericUpDown();
            label3 = new Label();
            nud_dz = new NumericUpDown();
            label4 = new Label();
            nud_v1Z = new NumericUpDown();
            label5 = new Label();
            nud_v1Y = new NumericUpDown();
            label6 = new Label();
            nud_v1X = new NumericUpDown();
            label7 = new Label();
            nud_rZ = new NumericUpDown();
            label8 = new Label();
            nud_rY = new NumericUpDown();
            label9 = new Label();
            nud_rX = new NumericUpDown();
            label10 = new Label();
            b_generar = new Button();
            label11 = new Label();
            tb_archivo = new TextBox();
            b_nobjeto = new Button();
            b_terminar = new Button();
            l_obj_ct = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_tmñ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_dx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_dy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_dz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1Z).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1Y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1X).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_rZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_rY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_rX).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 84);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 11;
            label1.Text = "Tamaño";
            // 
            // nud_tmñ
            // 
            nud_tmñ.DecimalPlaces = 2;
            nud_tmñ.Location = new Point(18, 113);
            nud_tmñ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_tmñ.Name = "nud_tmñ";
            nud_tmñ.Size = new Size(120, 23);
            nud_tmñ.TabIndex = 12;
            nud_tmñ.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nud_dx
            // 
            nud_dx.DecimalPlaces = 2;
            nud_dx.Location = new Point(18, 188);
            nud_dx.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_dx.Name = "nud_dx";
            nud_dx.Size = new Size(120, 23);
            nud_dx.TabIndex = 14;
            nud_dx.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 159);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 13;
            label2.Text = "Deformar X";
            // 
            // nud_dy
            // 
            nud_dy.DecimalPlaces = 2;
            nud_dy.Location = new Point(167, 188);
            nud_dy.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_dy.Name = "nud_dy";
            nud_dy.Size = new Size(120, 23);
            nud_dy.TabIndex = 16;
            nud_dy.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(167, 159);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 15;
            label3.Text = "Deformar Y";
            // 
            // nud_dz
            // 
            nud_dz.DecimalPlaces = 2;
            nud_dz.Location = new Point(322, 188);
            nud_dz.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_dz.Name = "nud_dz";
            nud_dz.Size = new Size(120, 23);
            nud_dz.TabIndex = 18;
            nud_dz.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(322, 159);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 17;
            label4.Text = "Deformar Z";
            // 
            // nud_v1Z
            // 
            nud_v1Z.DecimalPlaces = 2;
            nud_v1Z.Location = new Point(322, 334);
            nud_v1Z.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_v1Z.Name = "nud_v1Z";
            nud_v1Z.Size = new Size(120, 23);
            nud_v1Z.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 305);
            label5.Name = "label5";
            label5.Size = new Size(29, 15);
            label5.TabIndex = 23;
            label5.Text = "v1.Z";
            // 
            // nud_v1Y
            // 
            nud_v1Y.DecimalPlaces = 2;
            nud_v1Y.Location = new Point(167, 334);
            nud_v1Y.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_v1Y.Name = "nud_v1Y";
            nud_v1Y.Size = new Size(120, 23);
            nud_v1Y.TabIndex = 22;
            nud_v1Y.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(167, 305);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 21;
            label6.Text = "v1.Y";
            // 
            // nud_v1X
            // 
            nud_v1X.DecimalPlaces = 2;
            nud_v1X.Location = new Point(18, 334);
            nud_v1X.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nud_v1X.Name = "nud_v1X";
            nud_v1X.Size = new Size(120, 23);
            nud_v1X.TabIndex = 20;
            nud_v1X.Value = new decimal(new int[] { 1, 0, 0, int.MinValue });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 305);
            label7.Name = "label7";
            label7.Size = new Size(29, 15);
            label7.TabIndex = 19;
            label7.Text = "v1.X";
            // 
            // nud_rZ
            // 
            nud_rZ.DecimalPlaces = 2;
            nud_rZ.Location = new Point(322, 262);
            nud_rZ.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            nud_rZ.Name = "nud_rZ";
            nud_rZ.Size = new Size(120, 23);
            nud_rZ.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(322, 233);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 29;
            label8.Text = "Rotar Z";
            // 
            // nud_rY
            // 
            nud_rY.DecimalPlaces = 2;
            nud_rY.Location = new Point(167, 262);
            nud_rY.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            nud_rY.Name = "nud_rY";
            nud_rY.Size = new Size(120, 23);
            nud_rY.TabIndex = 28;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(167, 233);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 27;
            label9.Text = "Rotar Y";
            // 
            // nud_rX
            // 
            nud_rX.DecimalPlaces = 2;
            nud_rX.Location = new Point(18, 262);
            nud_rX.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            nud_rX.Name = "nud_rX";
            nud_rX.Size = new Size(120, 23);
            nud_rX.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(18, 233);
            label10.Name = "label10";
            label10.Size = new Size(45, 15);
            label10.TabIndex = 25;
            label10.Text = "Rotar X";
            // 
            // b_generar
            // 
            b_generar.Location = new Point(270, 25);
            b_generar.Name = "b_generar";
            b_generar.Size = new Size(162, 41);
            b_generar.TabIndex = 34;
            b_generar.Text = "GENERAR BASE";
            b_generar.UseVisualStyleBackColor = true;
            b_generar.Click += b_generar_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, -17);
            label11.Name = "label11";
            label11.Size = new Size(98, 15);
            label11.TabIndex = 33;
            label11.Text = "archivo de salida:";
            // 
            // tb_archivo
            // 
            tb_archivo.Location = new Point(17, 35);
            tb_archivo.Name = "tb_archivo";
            tb_archivo.Size = new Size(236, 23);
            tb_archivo.TabIndex = 32;
            tb_archivo.Text = "test";
            // 
            // b_nobjeto
            // 
            b_nobjeto.Enabled = false;
            b_nobjeto.Location = new Point(18, 400);
            b_nobjeto.Name = "b_nobjeto";
            b_nobjeto.Size = new Size(120, 43);
            b_nobjeto.TabIndex = 35;
            b_nobjeto.Text = "NUEVO OBJETO";
            b_nobjeto.UseVisualStyleBackColor = true;
            b_nobjeto.Click += n_objeto;
            // 
            // b_terminar
            // 
            b_terminar.Enabled = false;
            b_terminar.Location = new Point(322, 400);
            b_terminar.Name = "b_terminar";
            b_terminar.Size = new Size(120, 43);
            b_terminar.TabIndex = 36;
            b_terminar.Text = "TERMINAR";
            b_terminar.UseVisualStyleBackColor = true;
            b_terminar.Click += b_terminar_Click;
            // 
            // l_obj_ct
            // 
            l_obj_ct.AutoSize = true;
            l_obj_ct.Location = new Point(322, 382);
            l_obj_ct.Name = "l_obj_ct";
            l_obj_ct.Size = new Size(60, 15);
            l_obj_ct.TabIndex = 37;
            l_obj_ct.Text = "Objetos: 0";
            // 
            // Bases
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 473);
            Controls.Add(l_obj_ct);
            Controls.Add(b_terminar);
            Controls.Add(b_nobjeto);
            Controls.Add(b_generar);
            Controls.Add(label11);
            Controls.Add(tb_archivo);
            Controls.Add(nud_rZ);
            Controls.Add(label8);
            Controls.Add(nud_rY);
            Controls.Add(label9);
            Controls.Add(nud_rX);
            Controls.Add(label10);
            Controls.Add(nud_v1Z);
            Controls.Add(label5);
            Controls.Add(nud_v1Y);
            Controls.Add(label6);
            Controls.Add(nud_v1X);
            Controls.Add(label7);
            Controls.Add(nud_dz);
            Controls.Add(label4);
            Controls.Add(nud_dy);
            Controls.Add(label3);
            Controls.Add(nud_dx);
            Controls.Add(label2);
            Controls.Add(nud_tmñ);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Bases";
            Text = "Crear Bases";
            ((System.ComponentModel.ISupportInitialize)nud_tmñ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_dx).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_dy).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_dz).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1Z).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1Y).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_v1X).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_rZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_rY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_rX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown nud_tmñ;
        private NumericUpDown nud_dx;
        private Label label2;
        private NumericUpDown nud_dy;
        private Label label3;
        private NumericUpDown nud_dz;
        private Label label4;
        private NumericUpDown nud_v1Z;
        private Label label5;
        private NumericUpDown nud_v1Y;
        private Label label6;
        private NumericUpDown nud_v1X;
        private Label label7;
        private NumericUpDown nud_rZ;
        private Label label8;
        private NumericUpDown nud_rY;
        private Label label9;
        private NumericUpDown nud_rX;
        private Label label10;
        private Button b_generar;
        private Label label11;
        private TextBox tb_archivo;
        private Button b_nobjeto;
        private Button b_terminar;
        private Label l_obj_ct;
    }
}