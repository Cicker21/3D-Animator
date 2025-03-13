using System.Diagnostics;
using System.Globalization;

namespace _3D_01
{
    public partial class Simulador : Form
    {
        public Simulador()
        {
            InitializeComponent();
        }
        public struct Fisica
        {
            public float FX, FY, FZ, GX, GY, GZ, VX, VY, VZ, m;

            public Fisica(float FX, float FY, float FZ, float GX, float GY, float GZ, float VX, float VY, float VZ, float m)
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
        private List<Fisica> fisicas = new List<Fisica>();
        
        private void abrir_Documento(object sender, EventArgs e) //Función que abre el archivo .csv y lee los datos de los vértices
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Archivos de texto (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            openFileDialog1.Title = "Abrir archivo de texto";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                string[] lineas = sr.ReadToEnd().Split('\n');
                string linea_final = lineas[lineas.Length - 1];

                string[] valores = linea_final.Split('|');



                sr.Close();
            }
        }








        //Función que genera el archivo .csv y le añade los datos de los vértices


        private float FX, FY, FZ, GX, GY, Pasos, G, FR;
        private float[] v1, v2, v3, v4, v5, v6, v7, v8;
        private float[][] vectores;


        private string siguiente_Linea() //Función que genera las lineas mediantes fisicas sin fundamentos
        {

            //string l = "(FX: " + FX + ", FY: " + FY + ", FZ: " + FZ + ", G: " + G + ", FR: " + FR + ")";
            string l = "";

            foreach (float[] v in vectores)
            {

                //Aplicar fuerzas
                v[0] += FX / 100;
                v[1] += FY / 100;
                v[2] += FZ / 100;

                //Aplicar gravedad
                v[1] -= G / 10;

                //Aplicar fricción
                FX = FX * FR / 100;
                FY = FY * FR / 100;
                FZ = FZ * FR / 100;


                //Aplicar giros
                float x, y, z;
                float cX, cY;

                //Rotar en el eje Y

                cY = GY / 100;

                x = v[0] * (float)Math.Cos(cY) - v[2] * (float)Math.Sin(cY);
                z = v[0] * (float)Math.Sin(cY) + v[2] * (float)Math.Cos(cY);
                v[0] = x;
                v[2] = z;

                // Rotar en el eje X

                cX = GX / 100;

                y = v[1] * (float)Math.Cos(cX) - v[2] * (float)Math.Sin(cX);
                z = v[1] * (float)Math.Sin(cX) + v[2] * (float)Math.Cos(cX);
                v[1] = y;
                v[2] = z;

                //Pone a la linea de salida en el formato esperado |v1.X,v1.Y,v1.Z|...|v8.X,v8.Y,v8.Z
                l = l + "|" + v[0].ToString().Replace(",", ".") + "," + v[1].ToString().Replace(",", ".") + "," + v[2].ToString().Replace(",", ".");
            }

            return l;
        }

        //Función que llama al otro formulario
        private void visualizar(object sender, EventArgs e)
        {
            Visualizador viz = new Visualizador();
            viz.Show();
        }


    }
}
