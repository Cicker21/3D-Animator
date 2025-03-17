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
        public float FX, FY, FZ, GX, GY, GZ, VX, VY, VZ, m;

        public Fisicas(float FX, float FY, float FZ, float GX, float GY, float GZ, float VX, float VY, float VZ, float m)
        {
            this.FX = FX;
            this.FY = FY;
            this.FZ = FZ;
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

                for (int j = 0; j < caras.Length; j++)
                {
                    string[] vertices = caras[j].Split('=');

                    for (int k = 0; k < vertices.Length; k++)
                    {
                        if (string.IsNullOrEmpty(vertices[k])) continue; // Ignorar cadenas vacías

                        Vertex v = strVertex(vertices[k]);

                        // Obtener las coordenadas originales del vértice
                        float x = v.X;
                        float y = v.Y;
                        float z = v.Z;

                        // Convertir ángulos de grados a radianes
                        float thetaX = fisicas[i].GX * (float)(Math.PI / 180.0);
                        float thetaY = fisicas[i].GY * (float)(Math.PI / 180.0);
                        float thetaZ = fisicas[i].GZ * (float)(Math.PI / 180.0);

                        // Aplicar rotación en el eje X
                        float y1 = y * (float)Math.Cos(thetaX) - z * (float)Math.Sin(thetaX);
                        float z1 = y * (float)Math.Sin(thetaX) + z * (float)Math.Cos(thetaX);

                        // Aplicar rotación en el eje Y
                        float x2 = x * (float)Math.Cos(thetaY) + z1 * (float)Math.Sin(thetaY);
                        float z2 = -x * (float)Math.Sin(thetaY) + z1 * (float)Math.Cos(thetaY);

                        // Aplicar rotación en el eje Z
                        float x3 = x2 * (float)Math.Cos(thetaZ) - y1 * (float)Math.Sin(thetaZ);
                        float y3 = x2 * (float)Math.Sin(thetaZ) + y1 * (float)Math.Cos(thetaZ);

                        // Asignar los nuevos valores al vértice
                        v.X = x3;
                        v.Y = y3;
                        v.Z = z2;

                        // Agregar el vértice transformado al StringBuilder
                        lf.AppendFormat(CultureInfo.InvariantCulture, "{0:F6},{1:F6},{2:F6}", v.X, v.Y, v.Z);

                        // Agregar "=" solo si no es el último vértice
                        if (k < vertices.Length - 1)
                        {
                            lf.Append("=");
                        }
                    }

                    // Agregar "|" solo si no es la última cara
                    if (j < caras.Length - 1)
                    {
                        lf.Append("|");
                    }
                }

                // Agregar "%" solo si no es el último objeto
                if (i < objetos.Length - 1)
                {
                    lf.Append("%");
                }
            }

            return lf.ToString();
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