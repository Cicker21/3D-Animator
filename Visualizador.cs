using System;
using System.Globalization;
using System.Numerics;
using System.Windows.Forms;
using SharpGL;

namespace _3D_01
{
    // Estructura para representar un vértice
    public struct Vertex
    {
        public float X, Y, Z;

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public partial class VIsualizador : Form
    {
        // Definir un arreglo de vértices (para el cubo)
        private Vertex[] vertices = new Vertex[]
        {
            new Vertex(-1.0f, -1.0f, 1.0f),  // Vértice 1
            new Vertex(1.0f, -1.0f, 1.0f),   // Vértice 2
            new Vertex(1.0f, 1.0f, 1.0f),    // Vértice 3
            new Vertex(-1.0f, 1.0f, 1.0f),   // Vértice 4
            new Vertex(-1.0f, -1.0f, -1.0f), // Vértice 5
            new Vertex(1.0f, -1.0f, -1.0f),  // Vértice 6
            new Vertex(1.0f, 1.0f, -1.0f),   // Vértice 7
            new Vertex(-1.0f, 1.0f, -1.0f)   // Vértice 8
        };


        public VIsualizador()
        {
            InitializeComponent();
            lines = abrir_Documento(); //Pedir archivo al cargar el formulario
        }

        private string[] lines = null;
        private string[] abrir_Documento()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Archivos de texto (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            openFileDialog1.Title = "Abrir archivo de texto";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);

                string[] lineas = sr.ReadToEnd().Split('\n');

                sr.Close();

                return lineas;
            }

            // Si no se seleccionó ningún archivo, retornar null
            return null;
        }

        private int indice = 0;

        //Función que lee las lineas del archivo y modifica los valores de los vertices acorde a la linea
        private void valores_Vertices()
        {
            
            string linea = lines[indice];
            string[] Lvectores = linea.Split('|');

            for (int i = 1; i < Lvectores.Length; i++)
            {
                string[] valores = Lvectores[i].Split(',');

                float x = float.Parse(valores[0], CultureInfo.InvariantCulture);
                float y = float.Parse(valores[1], CultureInfo.InvariantCulture);
                float z = float.Parse(valores[2], CultureInfo.InvariantCulture);


                vertices[i - 1].X = x;
                vertices[i - 1].Y = y;
                vertices[i - 1].Z = z;
            }

            if (indice<lines.Length-1) indice++;


        }

        //Función que dibuja los gráficos en el formulario
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {

            OpenGL gl = openglControl1.OpenGL;

            //Limpiar la pantalla y el buffer de profundidad
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            //Alejar el cubo de la cámara
            gl.Translate(0.0f, 0.0f, -5.0f);

            //Dibujar el cubo con colores en cada cara

            gl.Begin(OpenGL.GL_QUADS);

            // Cara frontal (roja)
            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(vertices[0].X, vertices[0].Y, vertices[0].Z); // Vértice 1
            gl.Vertex(vertices[1].X, vertices[1].Y, vertices[1].Z); // Vértice 2
            gl.Vertex(vertices[2].X, vertices[2].Y, vertices[2].Z); // Vértice 3
            gl.Vertex(vertices[3].X, vertices[3].Y, vertices[3].Z); // Vértice 4

            // Cara trasera (verde)
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(vertices[4].X, vertices[4].Y, vertices[4].Z); // Vértice 5
            gl.Vertex(vertices[7].X, vertices[7].Y, vertices[7].Z); // Vértice 8
            gl.Vertex(vertices[6].X, vertices[6].Y, vertices[6].Z); // Vértice 7
            gl.Vertex(vertices[5].X, vertices[5].Y, vertices[5].Z); // Vértice 6

            // Cara izquierda (azul)
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(vertices[4].X, vertices[4].Y, vertices[4].Z); // Vértice 5
            gl.Vertex(vertices[0].X, vertices[0].Y, vertices[0].Z); // Vértice 1
            gl.Vertex(vertices[3].X, vertices[3].Y, vertices[3].Z); // Vértice 4
            gl.Vertex(vertices[7].X, vertices[7].Y, vertices[7].Z); // Vértice 8

            // Cara derecha (amarillo)
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(vertices[1].X, vertices[1].Y, vertices[1].Z); // Vértice 2
            gl.Vertex(vertices[5].X, vertices[5].Y, vertices[5].Z); // Vértice 6
            gl.Vertex(vertices[6].X, vertices[6].Y, vertices[6].Z); // Vértice 7
            gl.Vertex(vertices[2].X, vertices[2].Y, vertices[2].Z); // Vértice 3

            // Cara superior (cyan)
            gl.Color(0.0f, 1.0f, 1.0f);
            gl.Vertex(vertices[3].X, vertices[3].Y, vertices[3].Z); // Vértice 4
            gl.Vertex(vertices[2].X, vertices[2].Y, vertices[2].Z); // Vértice 3
            gl.Vertex(vertices[6].X, vertices[6].Y, vertices[6].Z); // Vértice 7
            gl.Vertex(vertices[7].X, vertices[7].Y, vertices[7].Z); // Vértice 8

            // Cara inferior (magenta)
            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(vertices[0].X, vertices[0].Y, vertices[0].Z); // Vértice 1
            gl.Vertex(vertices[4].X, vertices[4].Y, vertices[4].Z); // Vértice 5
            gl.Vertex(vertices[5].X, vertices[5].Y, vertices[5].Z); // Vértice 6
            gl.Vertex(vertices[1].X, vertices[1].Y, vertices[1].Z); // Vértice 2

            gl.End();
            gl.Flush();

            imprimir_Datos();
            valores_Vertices();
        }

        //Calcula la distancia entre dos vértices (no implementado)
        public float CalcularDistancia(Vertex punto1, Vertex punto2)
        {
            return (float)Math.Sqrt(
                Math.Pow(punto2.X - punto1.X, 2) +
                Math.Pow(punto2.Y - punto1.Y, 2) +
                Math.Pow(punto2.Z - punto1.Z, 2)
            );
        }

        
        //Definir un punto de referencia (no implementado)
        Vertex puntoReferencia = new Vertex(0.0f, 0.0f, 0.0f); // Origen (0, 0, 0)

        private int frames_ct = 0; //Contador de frames
        private void imprimir_Datos()
        {
            frames_ct++;  
            v_txt.Text = frames_ct.ToString();

            //Actualizar los datos de los vectores que se muestran en el formulario
            v1_txt.Text = "(" + vertices[0].X + ", " + vertices[0].Y + ", " + vertices[0].Z + ")";
            v2_txt.Text = "(" + vertices[1].X + ", " + vertices[1].Y + ", " + vertices[1].Z + ")";
            v3_txt.Text = "(" + vertices[2].X + ", " + vertices[2].Y + ", " + vertices[2].Z + ")";
            v4_txt.Text = "(" + vertices[3].X + ", " + vertices[3].Y + ", " + vertices[3].Z + ")";
            v5_txt.Text = "(" + vertices[4].X + ", " + vertices[4].Y + ", " + vertices[4].Z + ")";
            v6_txt.Text = "(" + vertices[5].X + ", " + vertices[5].Y + ", " + vertices[5].Z + ")";
            v7_txt.Text = "(" + vertices[6].X + ", " + vertices[6].Y + ", " + vertices[6].Z + ")";
            v8_txt.Text = "(" + vertices[7].X + ", " + vertices[7].Y + ", " + vertices[7].Z + ")";

        }


    }
}
