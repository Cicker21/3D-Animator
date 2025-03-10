namespace _3D_01
{
    partial class VIsualizador
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
            openglControl1 = new SharpGL.OpenGLControl();
            tableLayoutPanel1 = new TableLayoutPanel();
            v8_txt = new Label();
            label17 = new Label();
            v7_txt = new Label();
            label15 = new Label();
            v6_txt = new Label();
            label13 = new Label();
            v5_txt = new Label();
            label11 = new Label();
            v4_txt = new Label();
            label9 = new Label();
            v3_txt = new Label();
            label7 = new Label();
            v2_txt = new Label();
            label5 = new Label();
            v1_txt = new Label();
            label3 = new Label();
            v_txt = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)openglControl1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // openglControl1
            // 
            openglControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            openglControl1.DrawFPS = false;
            openglControl1.Location = new Point(13, 12);
            openglControl1.Margin = new Padding(4, 3, 4, 3);
            openglControl1.Name = "openglControl1";
            openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            openglControl1.Size = new Size(597, 426);
            openglControl1.TabIndex = 0;
            openglControl1.OpenGLDraw += openGLControl1_OpenGLDraw;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(v8_txt, 1, 8);
            tableLayoutPanel1.Controls.Add(label17, 0, 8);
            tableLayoutPanel1.Controls.Add(v7_txt, 1, 7);
            tableLayoutPanel1.Controls.Add(label15, 0, 7);
            tableLayoutPanel1.Controls.Add(v6_txt, 1, 6);
            tableLayoutPanel1.Controls.Add(label13, 0, 6);
            tableLayoutPanel1.Controls.Add(v5_txt, 1, 5);
            tableLayoutPanel1.Controls.Add(label11, 0, 5);
            tableLayoutPanel1.Controls.Add(v4_txt, 1, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(v3_txt, 1, 3);
            tableLayoutPanel1.Controls.Add(label7, 0, 3);
            tableLayoutPanel1.Controls.Add(v2_txt, 1, 2);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(v1_txt, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(v_txt, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(617, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.Size = new Size(200, 426);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // v8_txt
            // 
            v8_txt.AutoSize = true;
            v8_txt.Location = new Point(103, 376);
            v8_txt.Name = "v8_txt";
            v8_txt.Size = new Size(39, 15);
            v8_txt.TabIndex = 17;
            v8_txt.Text = "(0,0,0)";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(3, 376);
            label17.Name = "label17";
            label17.Size = new Size(51, 15);
            label17.TabIndex = 16;
            label17.Text = "Vertice 8";
            // 
            // v7_txt
            // 
            v7_txt.AutoSize = true;
            v7_txt.Location = new Point(103, 329);
            v7_txt.Name = "v7_txt";
            v7_txt.Size = new Size(39, 15);
            v7_txt.TabIndex = 15;
            v7_txt.Text = "(0,0,0)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(3, 329);
            label15.Name = "label15";
            label15.Size = new Size(51, 15);
            label15.TabIndex = 14;
            label15.Text = "Vertice 7";
            // 
            // v6_txt
            // 
            v6_txt.AutoSize = true;
            v6_txt.Location = new Point(103, 282);
            v6_txt.Name = "v6_txt";
            v6_txt.Size = new Size(39, 15);
            v6_txt.TabIndex = 13;
            v6_txt.Text = "(0,0,0)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(3, 282);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 12;
            label13.Text = "Vertice 6";
            // 
            // v5_txt
            // 
            v5_txt.AutoSize = true;
            v5_txt.Location = new Point(103, 235);
            v5_txt.Name = "v5_txt";
            v5_txt.Size = new Size(39, 15);
            v5_txt.TabIndex = 11;
            v5_txt.Text = "(0,0,0)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 235);
            label11.Name = "label11";
            label11.Size = new Size(51, 15);
            label11.TabIndex = 10;
            label11.Text = "Vertice 5";
            // 
            // v4_txt
            // 
            v4_txt.AutoSize = true;
            v4_txt.Location = new Point(103, 188);
            v4_txt.Name = "v4_txt";
            v4_txt.Size = new Size(39, 15);
            v4_txt.TabIndex = 9;
            v4_txt.Text = "(0,0,0)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(3, 188);
            label9.Name = "label9";
            label9.Size = new Size(51, 15);
            label9.TabIndex = 8;
            label9.Text = "Vertice 4";
            // 
            // v3_txt
            // 
            v3_txt.AutoSize = true;
            v3_txt.Location = new Point(103, 141);
            v3_txt.Name = "v3_txt";
            v3_txt.Size = new Size(39, 15);
            v3_txt.TabIndex = 7;
            v3_txt.Text = "(0,0,0)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(3, 141);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 6;
            label7.Text = "Vertice 3";
            // 
            // v2_txt
            // 
            v2_txt.AutoSize = true;
            v2_txt.Location = new Point(103, 94);
            v2_txt.Name = "v2_txt";
            v2_txt.Size = new Size(39, 15);
            v2_txt.TabIndex = 5;
            v2_txt.Text = "(0,0,0)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 94);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 4;
            label5.Text = "Vertice 2";
            // 
            // v1_txt
            // 
            v1_txt.AutoSize = true;
            v1_txt.Location = new Point(103, 47);
            v1_txt.Name = "v1_txt";
            v1_txt.Size = new Size(39, 15);
            v1_txt.TabIndex = 3;
            v1_txt.Text = "(0,0,0)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 47);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "Vertice 1";
            // 
            // v_txt
            // 
            v_txt.AutoSize = true;
            v_txt.Location = new Point(103, 0);
            v_txt.Name = "v_txt";
            v_txt.Size = new Size(13, 15);
            v_txt.TabIndex = 1;
            v_txt.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Frames";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 450);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(openglControl1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)openglControl1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label v8_txt;
        private Label label17;
        private Label v7_txt;
        private Label label15;
        private Label v6_txt;
        private Label label13;
        private Label v5_txt;
        private Label label11;
        private Label v4_txt;
        private Label label9;
        private Label v3_txt;
        private Label label7;
        private Label v2_txt;
        private Label label5;
        private Label v1_txt;
        private Label label3;
        private Label v_txt;
        private Label label1;
    }
}
