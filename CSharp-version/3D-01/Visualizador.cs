using System;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using SharpGL;

namespace _3D_01
{
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

    public partial class Visualizador : Form
    {
        public Visualizador()
        {
            InitializeComponent();
            lines = abrir_Documento(); // Pedir archivo al cargar el formulario
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
                return File.ReadAllLines(openFileDialog1.FileName);
            }

            return null;
        }

        private int indice = 0;

        private string[] siguientes_objetos()
        {
            if (lines == null || indice >= lines.Length)
                return null;

            string objs = lines[indice];
            if (string.IsNullOrWhiteSpace(objs))
                return null;
            if (lines.Length > indice + 1)
            {
                indice++;
            }
            else { indice = 0; }


            return objs.Split('%');
        }

        private float[][] colores = new float[][]
        {
            new float[] { 1.0f, 0.0f, 0.0f },
            new float[] { 0.0f, 1.0f, 0.0f },
            new float[] { 0.0f, 0.0f, 1.0f },
            new float[] { 1.0f, 1.0f, 0.0f },
            new float[] { 1.0f, 0.0f, 1.0f },
            new float[] { 0.0f, 1.0f, 1.0f }
        };

        private int ct = 0;
        private float[] obtenerColor()
        {
            float[] color = colores[ct];
            ct = (ct + 1) % colores.Length;
            return color;
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            OpenGL gl = openglControl1.OpenGL;

            // Limpiar la pantalla y el buffer de profundidad
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            // Configurar la cámara
            gl.Translate(0.0f, 0.0f, -15.0f); // Alejar la cámara

            if (lines == null)
            {
                this.Text = "No hay datos";
                return; // Si no hay datos, salir del método
            }

            // Obtener los objetos a dibujar
            string[] objetos = siguientes_objetos();
            if (objetos == null || objetos.Length == 0)
            {
                this.Text = "No hay objetos";
                return; // Si no hay objetos, salir del método
            }

            this.Text = $"linea {indice}";
            // Dibujar cada objeto
            for (int k = 0; k < objetos.Length; k++)
            {
                if (string.IsNullOrWhiteSpace(objetos[k]))
                    continue;

                gl.PushMatrix(); // Guardar la matriz actual

                // Dibujar el objeto
                DibujarObjeto(gl, objetos[k]);

                gl.PopMatrix(); // Restaurar la matriz anterior
            }

        }

        private void DibujarObjeto(OpenGL gl, string objeto)
        {
            string[] caras = objeto.Split('|');

            foreach (string cara in caras)
            {
                if (string.IsNullOrWhiteSpace(cara))
                {
                    continue; // Si la cara está vacía, continuar con la siguiente
                }

                // Obtener el color para la cara actual
                float[] color = obtenerColor();
                gl.Color(color[0], color[1], color[2]);

                // Dibujar la cara
                gl.Begin(OpenGL.GL_QUADS);
                string[] vertices = cara.Split('=');
                foreach (string vertice in vertices)
                {
                    if (string.IsNullOrWhiteSpace(vertice))
                    {
                        continue; // Si el vértice está vacío, continuar con el siguiente
                    }
                    Vertex v = strVertex(vertice);
                    gl.Vertex(v.X, v.Y, v.Z);
                }
                gl.End();
            }
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