using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace _3D_01
{
    public struct Fisicas
    {
        public float GeX, GeY, GeZ, GX, GY, GZ, VX, VY, VZ, m;

        public Fisicas(float GeX, float GeY, float GeZ, float GX, float GY, float GZ, float VX, float VY, float VZ, float m)
        {
            this.GeX = GeX;
            this.GeY = GeY;
            this.GeZ = GeZ;
            this.GX = GX;
            this.GY = GY;
            this.GZ = GZ;
            this.VX = VX;
            this.VY = VY;
            this.VZ = VZ;
            this.m = m;
        }
    }

    public partial class Simulador : Form
    {
        private List<Fisicas> fisicas = new List<Fisicas>();
        private List<string> lineas_archivo = new List<string>();

        public Simulador()
        {
            InitializeComponent();
        }

        private string ruta_destino = null;
        private void cargar_datos(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Archivos de texto (*.csv)|*.csv|Todos los archivos (*.*)|*.*",
                Title = "Abrir archivo de texto"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    ruta_destino = openFileDialog1.FileName;
                    while (!sr.EndOfStream)
                    {
                        lineas_archivo.Add(sr.ReadLine());
                    }
                }

                string linea_final = lineas_archivo[lineas_archivo.Count - 1];
                string[] objetos = linea_final.Split('%');

                Fisica fis = new Fisica(objetos.Length);
                fis.FisicaEnviada += RecibirFisicas;
                fis.Show();
            }
        }

        private void RecibirFisicas(List<Fisicas> fiss)
        {
            fisicas = fiss;
        }

        private void g_afisicas_Click(object sender, EventArgs e)
        {
            if (fisicas.Count == 0 || lineas_archivo.Count == 0)
            {
                MessageBox.Show("No hay fisicas añadidas");
                return;
            }

            if (nud_Pasos.Value <= 0)
            {
                MessageBox.Show("El número de pasos debe ser mayor que cero.");
                return;
            }

            string ultima = lineas_archivo[lineas_archivo.Count - 1];

            string[] split = ultima.Split('%');

            if (fisicas.Count == split.Length)
            {
                for (int i = 0; i < (int)nud_Pasos.Value; i++)
                {
                    lineas_archivo.Add(siguiente_Linea(fisicas, ultima));
                    ultima = lineas_archivo[lineas_archivo.Count - 1];

                }

                MessageBox.Show("Fisicas añadidas correctamente");
                
                using (StreamWriter sw = new StreamWriter(ruta_destino))
                {
                    foreach (string linea in lineas_archivo)
                    {
                        sw.WriteLine(linea);
                    }
                }
            }
            else
            {
                MessageBox.Show("El número de fisicas no coincide con el número de objetos");
            }

        }

        private string siguiente_Linea(List<Fisicas> fL, string ultimaL)
        {
            string[] objetos = ultimaL.Split('%');
            Fisicas[] fisicas = fL.ToArray();
            StringBuilder lf = new StringBuilder();

            for (int i = 0; i < objetos.Length; i++)
            {
                string[] caras = objetos[i].Split('|');

                // Calcular el centro del objeto
                Vertex centro = CalcularCentro(objetos[i]);

                for (int j = 0; j < caras.Length; j++)
                {
                    string[] vertices = caras[j].Split('=');

                    for (int k = 0; k < vertices.Length; k++)
                    {
                        if (string.IsNullOrEmpty(vertices[k])) continue;

                        Vertex v = strVertex(vertices[k]);

                        // 1. Aplicar rotación global (ejes del mundo)
                        float x = v.X;
                        float y = v.Y;
                        float z = v.Z;

                        // Convertir ángulos globales a radianes
                        float thetaGeX = fisicas[i].GeX * (float)(Math.PI / 180.0);
                        float thetaGeY = fisicas[i].GeY * (float)(Math.PI / 180.0);
                        float thetaGeZ = fisicas[i].GeZ * (float)(Math.PI / 180.0);

                        // Rotación global en X
                        float y_ge = y * (float)Math.Cos(thetaGeX) - z * (float)Math.Sin(thetaGeX);
                        float z_ge = y * (float)Math.Sin(thetaGeX) + z * (float)Math.Cos(thetaGeX);
                        y = y_ge; z = z_ge;

                        // Rotación global en Y
                        float x_ge = x * (float)Math.Cos(thetaGeY) + z * (float)Math.Sin(thetaGeY);
                        z_ge = -x * (float)Math.Sin(thetaGeY) + z * (float)Math.Cos(thetaGeY);
                        x = x_ge; z = z_ge;

                        // Rotación global en Z
                        x_ge = x * (float)Math.Cos(thetaGeZ) - y * (float)Math.Sin(thetaGeZ);
                        y_ge = x * (float)Math.Sin(thetaGeZ) + y * (float)Math.Cos(thetaGeZ);
                        x = x_ge; y = y_ge;

                        // 2. Aplicar rotación local (ejes del objeto)
                        // Trasladar al centro del objeto
                        x -= centro.X;
                        y -= centro.Y;
                        z -= centro.Z;

                        // Convertir ángulos locales a radianes
                        float thetaX = fisicas[i].GX * (float)(Math.PI / 180.0);
                        float thetaY = fisicas[i].GY * (float)(Math.PI / 180.0);
                        float thetaZ = fisicas[i].GZ * (float)(Math.PI / 180.0);

                        // Rotación local en X
                        float y1 = y * (float)Math.Cos(thetaX) - z * (float)Math.Sin(thetaX);
                        float z1 = y * (float)Math.Sin(thetaX) + z * (float)Math.Cos(thetaX);

                        // Rotación local en Y
                        float x2 = x * (float)Math.Cos(thetaY) + z1 * (float)Math.Sin(thetaY);
                        float z2 = -x * (float)Math.Sin(thetaY) + z1 * (float)Math.Cos(thetaY);

                        // Rotación local en Z
                        float x3 = x2 * (float)Math.Cos(thetaZ) - y1 * (float)Math.Sin(thetaZ);
                        float y3 = x2 * (float)Math.Sin(thetaZ) + y1 * (float)Math.Cos(thetaZ);

                        // Trasladar de vuelta a la posición original
                        v.X = x3 + centro.X;
                        v.Y = y3 + centro.Y;
                        v.Z = z2 + centro.Z;

                        lf.AppendFormat(CultureInfo.InvariantCulture, "{0:F6},{1:F6},{2:F6}", v.X, v.Y, v.Z);

                        if (k < vertices.Length - 1)
                        {
                            lf.Append("=");
                        }
                    }

                    if (j < caras.Length - 1)
                    {
                        lf.Append("|");
                    }
                }

                if (i < objetos.Length - 1)
                {
                    lf.Append("%");
                }
            }

            return lf.ToString();
        }

        // Método para calcular el centro de un objeto
        private Vertex CalcularCentro(string objeto)
        {
            string[] caras = objeto.Split('|');
            float sumX = 0, sumY = 0, sumZ = 0;
            int count = 0;

            foreach (string cara in caras)
            {
                string[] vertices = cara.Split('=');
                foreach (string vertice in vertices)
                {
                    if (!string.IsNullOrEmpty(vertice))
                    {
                        Vertex v = strVertex(vertice);
                        sumX += v.X;
                        sumY += v.Y;
                        sumZ += v.Z;
                        count++;
                    }
                }
            }

            return new Vertex(sumX / count, sumY / count, sumZ / count);
        }

        private Vertex strVertex(string coords)
        {
            string[] partes = coords.Split(',');

            // Convertir las coordenadas a float, usando CultureInfo.InvariantCulture
            float x = float.Parse(partes[0], CultureInfo.InvariantCulture);
            float y = float.Parse(partes[1], CultureInfo.InvariantCulture);
            float z = float.Parse(partes[2], CultureInfo.InvariantCulture);

            return new Vertex(x, y, z);
        }
    }
}