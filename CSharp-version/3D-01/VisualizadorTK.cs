using System;
using System.IO;
using System.Globalization;
using System.Windows.Forms;  // Para OpenFileDialog
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace _3D_01
{
    public struct Vertex
    {
        public float X, Y, Z;
        public Vertex(float x, float y, float z) { X = x; Y = y; Z = z; }
    }

    public class VisualizadorTK : GameWindow
    {
        private string[] lines;
        private int indice = 0;

        private int frameCount = 0;
        private double lastTime = 0;
        private float fps = 0;

        private float updateInterval = 1.0f / 30f; //30Hz
        private double updateAccumulator = 0;

        // Colores base
        private float[][] colores = new float[][]
        {
            new float[] { 1f, 0f, 0f },
            new float[] { 0f, 1f, 0f },
            new float[] { 0f, 0f, 1f },
            new float[] { 1f, 1f, 0f },
            new float[] { 1f, 0f, 1f },
            new float[] { 0f, 1f, 1f }
        };

        // Colores precalculados para cada cara de cada objeto en cada línea
        private float[][][][] coloresPorLinea;

        public VisualizadorTK() : base(800, 600, GraphicsMode.Default, "Visualizador OpenTK 3D")
        {
            VSync = VSyncMode.Off;
            lines = null;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            dlg.Title = "Seleccione archivo CSV";
            dlg.ShowDialog();

            if (!string.IsNullOrEmpty(dlg.FileName) && File.Exists(dlg.FileName))
            {
                lines = File.ReadAllLines(dlg.FileName);
                CalcularColores();
            }
        }

        // Calcula colores una vez para cada cara de cada objeto en cada línea
        private void CalcularColores()
        {
            if (lines == null) return;

            coloresPorLinea = new float[lines.Length][][][];

            for (int i = 0; i < lines.Length; i++)
            {
                var objetos = lines[i].Split('%');
                coloresPorLinea[i] = new float[objetos.Length][][];

                for (int j = 0; j < objetos.Length; j++)
                {
                    var caras = objetos[j].Split('|');
                    coloresPorLinea[i][j] = new float[caras.Length][];

                    for (int k = 0; k < caras.Length; k++)
                    {
                        // Asigna un color del arreglo colores en ciclo
                        coloresPorLinea[i][j][k] = colores[(k) % colores.Length];
                    }
                }
            }
        }

        private string[] SiguientesObjetos()
        {
            if (lines == null || indice >= lines.Length)
                return null;

            string objs = lines[indice];
            if (string.IsNullOrWhiteSpace(objs))
                return null;

            return objs.Split('%');
        }

        private Vertex StrVertex(string coords)
        {
            string[] partes = coords.Split(',');

            float x = float.Parse(partes[0], CultureInfo.InvariantCulture);
            float y = float.Parse(partes[1], CultureInfo.InvariantCulture);
            float z = float.Parse(partes[2], CultureInfo.InvariantCulture);

            return new Vertex(x, y, z);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0f, 0f, 0f, 1f);
            GL.Enable(EnableCap.DepthTest);
            lastTime = 0;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.DegreesToRadians(45f),
                Width / (float)Height,
                0.1f, 100f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            updateAccumulator += e.Time;
            while (updateAccumulator >= updateInterval)
            {
                updateAccumulator -= updateInterval;

                var keyboard = Keyboard.GetState();
                if (keyboard.IsKeyDown(Key.Escape))
                    Exit();

                if (lines != null)
                    indice = (indice + 1) % lines.Length;

                this.Title = $"FPS: {fps:F2} - Línea actual: {indice}";

                // Guardar metricas
                if (fps >= 1) //esperar a que inicie para contar FPS
                {
                    MetricCT++;
                    if (fps > FPS_MAX) FPS_MAX = fps;
                    if (fps < FPS_MIN) FPS_MIN = fps;
                    FPS_TotalReg += fps;
                }
                

            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            frameCount++;
            double now = DateTime.Now.TimeOfDay.TotalSeconds;
            double elapsed = now - lastTime;
            if (elapsed >= 1.0)
            {
                fps = (float)(frameCount / elapsed);
                frameCount = 0;
                lastTime = now;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (lines == null)
            {
                SwapBuffers();
                return;
            }

            var objetos = SiguientesObjetos();
            if (objetos == null || objetos.Length == 0)
            {
                SwapBuffers();
                return;
            }

            GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 model = Matrix4.CreateTranslation(0, 0, -15f);
            GL.LoadMatrix(ref model);

            for (int i = 0; i < objetos.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(objetos[i]))
                    continue;

                DibujarObjeto(objetos[i], i);
            }

            SwapBuffers();
        }

        // Ahora recibe el índice para usar el color precalculado
        private void DibujarObjeto(string objeto, int indiceObjeto)
        {
            string[] caras = objeto.Split('|');
            for (int i = 0; i < caras.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(caras[i]))
                    continue;

                // Obtener color precalculado para esta línea, objeto y cara
                float[] color = coloresPorLinea[indice][indiceObjeto][i];

                GL.Color3(color[0], color[1], color[2]);

                GL.Begin(PrimitiveType.Polygon);
                string[] vertices = caras[i].Split('=');
                foreach (var vertice in vertices)
                {
                    if (string.IsNullOrWhiteSpace(vertice))
                        continue;

                    Vertex v = StrVertex(vertice);
                    GL.Vertex3(v.X, v.Y, v.Z);
                }
                GL.End();
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            string tiempo_ejecucion = (DateTime.Now - start).TotalSeconds.ToString("F2");
            string metricas = $"FPS MAX: {FPS_MAX:F2}\nFPS MIN: {FPS_MIN:F2}\nFPS AVG: {FPS_TotalReg / MetricCT:F2}\nTotal Registros: {MetricCT}\n Tiempo total de ejecución: {tiempo_ejecucion} segundos";
            MessageBox.Show(metricas, "Cerrar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private float FPS_MAX = 0, FPS_MIN = int.MaxValue, FPS_TotalReg = 0, MetricCT = 0;
        private DateTime start = DateTime.Now;
        
    }
}
