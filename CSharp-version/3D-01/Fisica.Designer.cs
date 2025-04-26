namespace _3D_01
{
    partial class Fisica
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
            nud_m = new NumericUpDown();
            label1 = new Label();
            b_visualizar = new Button();
            label11 = new Label();
            nud_GeZ = new NumericUpDown();
            nud_GeY = new NumericUpDown();
            label12 = new Label();
            nud_GeX = new NumericUpDown();
            label13 = new Label();
            nud_GY = new NumericUpDown();
            label9 = new Label();
            nud_GX = new NumericUpDown();
            label10 = new Label();
            nud_GZ = new NumericUpDown();
            label4 = new Label();
            label2 = new Label();
            nud_VZ = new NumericUpDown();
            nud_VY = new NumericUpDown();
            label3 = new Label();
            nud_VX = new NumericUpDown();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_m).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_GZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_VZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_VY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_VX).BeginInit();
            SuspendLayout();
            // 
            // nud_m
            // 
            nud_m.DecimalPlaces = 2;
            nud_m.Location = new Point(12, 44);
            nud_m.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_m.Name = "nud_m";
            nud_m.Size = new Size(120, 23);
            nud_m.TabIndex = 37;
            nud_m.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 36;
            label1.Text = "Masa";
            // 
            // b_visualizar
            // 
            b_visualizar.Location = new Point(134, 266);
            b_visualizar.Name = "b_visualizar";
            b_visualizar.Size = new Size(154, 45);
            b_visualizar.TabIndex = 68;
            b_visualizar.Text = "AÑADIR FISICA A OBJETO";
            b_visualizar.UseVisualStyleBackColor = true;
            b_visualizar.Click += añadir;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(287, 139);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 67;
            label11.Text = "Giro- Z";
            // 
            // nud_GeZ
            // 
            nud_GeZ.Location = new Point(287, 157);
            nud_GeZ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GeZ.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GeZ.Name = "nud_GeZ";
            nud_GeZ.Size = new Size(120, 23);
            nud_GeZ.TabIndex = 66;
            // 
            // nud_GeY
            // 
            nud_GeY.Location = new Point(149, 157);
            nud_GeY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GeY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GeY.Name = "nud_GeY";
            nud_GeY.Size = new Size(120, 23);
            nud_GeY.TabIndex = 65;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(149, 139);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 64;
            label12.Text = "Giro- Y";
            // 
            // nud_GeX
            // 
            nud_GeX.Location = new Point(12, 157);
            nud_GeX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GeX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GeX.Name = "nud_GeX";
            nud_GeX.Size = new Size(120, 23);
            nud_GeX.TabIndex = 63;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 139);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 62;
            label13.Text = "Giro- X";
            // 
            // nud_GY
            // 
            nud_GY.Location = new Point(149, 113);
            nud_GY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GY.Name = "nud_GY";
            nud_GY.Size = new Size(120, 23);
            nud_GY.TabIndex = 61;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(149, 95);
            label9.Name = "label9";
            label9.Size = new Size(39, 15);
            label9.TabIndex = 60;
            label9.Text = "Giro Y";
            // 
            // nud_GX
            // 
            nud_GX.Location = new Point(12, 113);
            nud_GX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GX.Name = "nud_GX";
            nud_GX.Size = new Size(120, 23);
            nud_GX.TabIndex = 59;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 95);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 58;
            label10.Text = "Giro X";
            // 
            // nud_GZ
            // 
            nud_GZ.Location = new Point(287, 113);
            nud_GZ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_GZ.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_GZ.Name = "nud_GZ";
            nud_GZ.Size = new Size(120, 23);
            nud_GZ.TabIndex = 70;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(287, 95);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 69;
            label4.Text = "Giro Z";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(287, 183);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 76;
            label2.Text = "V Z";
            // 
            // nud_VZ
            // 
            nud_VZ.Location = new Point(287, 201);
            nud_VZ.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_VZ.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_VZ.Name = "nud_VZ";
            nud_VZ.Size = new Size(120, 23);
            nud_VZ.TabIndex = 75;
            // 
            // nud_VY
            // 
            nud_VY.Location = new Point(149, 201);
            nud_VY.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_VY.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_VY.Name = "nud_VY";
            nud_VY.Size = new Size(120, 23);
            nud_VY.TabIndex = 74;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(149, 183);
            label3.Name = "label3";
            label3.Size = new Size(24, 15);
            label3.TabIndex = 73;
            label3.Text = "V Y";
            // 
            // nud_VX
            // 
            nud_VX.Location = new Point(12, 201);
            nud_VX.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_VX.Minimum = new decimal(new int[] { 10, 0, 0, int.MinValue });
            nud_VX.Name = "nud_VX";
            nud_VX.Size = new Size(120, 23);
            nud_VX.TabIndex = 72;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 183);
            label5.Name = "label5";
            label5.Size = new Size(24, 15);
            label5.TabIndex = 71;
            label5.Text = "V X";
            // 
            // Fisica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 345);
            Controls.Add(label2);
            Controls.Add(nud_VZ);
            Controls.Add(nud_VY);
            Controls.Add(label3);
            Controls.Add(nud_VX);
            Controls.Add(label5);
            Controls.Add(nud_GZ);
            Controls.Add(label4);
            Controls.Add(b_visualizar);
            Controls.Add(label11);
            Controls.Add(nud_GeZ);
            Controls.Add(nud_GeY);
            Controls.Add(label12);
            Controls.Add(nud_GeX);
            Controls.Add(label13);
            Controls.Add(nud_GY);
            Controls.Add(label9);
            Controls.Add(nud_GX);
            Controls.Add(label10);
            Controls.Add(nud_m);
            Controls.Add(label1);
            Name = "Fisica";
            Text = "Fisica";
            ((System.ComponentModel.ISupportInitialize)nud_m).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GeX).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GX).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_GZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_VZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_VY).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_VX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown nud_m;
        private Label label1;
        private Button b_visualizar;
        private Label label11;
        private NumericUpDown nud_GeZ;
        private NumericUpDown nud_GeY;
        private Label label12;
        private NumericUpDown nud_GeX;
        private Label label13;
        private NumericUpDown nud_GY;
        private Label label9;
        private NumericUpDown nud_GX;
        private Label label10;
        private NumericUpDown nud_GZ;
        private Label label4;
        private Label label2;
        private NumericUpDown nud_VZ;
        private NumericUpDown nud_VY;
        private Label label3;
        private NumericUpDown nud_VX;
        private Label label5;
    }
}