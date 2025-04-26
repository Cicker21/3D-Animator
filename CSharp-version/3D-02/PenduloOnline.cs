using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using SharpGL;

namespace _3D_02
{
    public partial class PenduloOnline : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;
        private bool connected = false;
        private float theta1=0, theta2=0, omega1=0, omega2=0;
        private int frame = 0;
        private float L1 = 1.0f, L2 = 2.0f;

        public PenduloOnline()
        {
            InitializeComponent();
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            btnConectar.Click += (s, e) => ConnectToServer();
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Inicialización de OpenGL
            OpenGL gl = openGLControl.OpenGL;
            gl.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.LookAt(0, -5, 5, 0, 0, 0, 0, 0, 1);

            // Dibujar ejes
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1.0f, 0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 0.0f); // Eje X
            gl.Color(0.0f, 1.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 0.0f); // Eje Y
            gl.Color(0.0f, 0.0f, 1.0f); gl.Vertex(0.0f, 0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 2.0f); // Eje Z
            gl.End();

            // Convertir ángulos a coordenadas
            float x1 = L1 * (float)Math.Sin(theta1);
            float y1 = -L1 * (float)Math.Cos(theta1);
            float x2 = x1 + L2 * (float)Math.Sin(theta2);
            float y2 = y1 - L2 * (float)Math.Cos(theta2);

            // Dibujar péndulo
            gl.LineWidth(3.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Color(1.0f, 1.0f, 1.0f);
            gl.Vertex(0.0f, 0.0f, 0.0f); gl.Vertex(x1, y1, 0.0f); // Primera barra
            gl.Vertex(x1, y1, 0.0f); gl.Vertex(x2, y2, 0.0f);     // Segunda barra
            gl.End();

            // Dibujar masas
            DrawSphere(gl, x1, y1, 0, 0.1f, Color.Red);
            DrawSphere(gl, x2, y2, 0, 0.15f, Color.Blue);

            // Visualizar velocidades angulares (líneas que indican dirección y magnitud)
            float omegaScale = 0.5f; // Factor de escala para visualización
            gl.LineWidth(2.0f);
            gl.Begin(OpenGL.GL_LINES);
            // Velocidad primera masa
            gl.Color(1.0f, 0.5f, 0.5f);
            gl.Vertex(x1, y1, 0);
            gl.Vertex(x1 + omega1 * omegaScale * (float)Math.Cos(theta1),
                      y1 + omega1 * omegaScale * (float)Math.Sin(theta1), 0);
            // Velocidad segunda masa
            gl.Color(0.5f, 0.5f, 1.0f);
            gl.Vertex(x2, y2, 0);
            gl.Vertex(x2 + omega2 * omegaScale * (float)Math.Cos(theta2),
                      y2 + omega2 * omegaScale * (float)Math.Sin(theta2), 0);
            gl.End();
        }

        private void DrawSphere(OpenGL gl, float x, float y, float z, float radius, Color color)
        {
            gl.PushMatrix();
            gl.Translate(x, y, z);
            gl.Color(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);

            var quadric = gl.NewQuadric();
            gl.Sphere(quadric, radius, 16, 16);
            gl.DeleteQuadric(quadric);

            gl.PopMatrix();
        }

        private void ConnectToServer()
        {
            if (connected) return;

            try
            {
                client = new TcpClient();
                client.Connect("127.0.0.1", 12345);
                stream = client.GetStream();
                connected = true;

                receiveThread = new Thread(ReceiveData);
                receiveThread.IsBackground = true;
                receiveThread.Start();

                UpdateStatus("Conectado al servidor Python");
            }
            catch (Exception ex)
            {
                UpdateStatus($"Error de conexión: {ex.Message}");
            }
        }

        private void ReceiveData()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while (connected && (bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string jsonData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    ProcessPendulumData(jsonData);
                }
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateStatus($"Error en recepción: {ex.Message}");
                });
            }
            finally
            {
                Disconnect();
            }
        }
        private void ProcessPendulumData(string Data)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    // Limpiar y mostrar datos crudos
                    richTextBox1.Text = Data;

                    // Parsear datos (formato esperado: "frame,theta1,omega1,theta2,omega2")
                    string[] dSplit = Data.Split(',');

                    if (dSplit.Length >= 5) // Verificar que tenemos todos los datos
                    {
                        frame = int.Parse(dSplit[0]);
                        theta1 = float.Parse(dSplit[1].Replace(".",","));
                        omega1 = float.Parse(dSplit[2].Replace(".", ","));
                        theta2 = float.Parse(dSplit[3].Replace(".", ","));
                        omega2 = float.Parse(dSplit[4].Replace(".", ",")); // Corregido: estaba omega1 otra vez

                        // Actualizar interfaz
                        lblTheta1.Text = $"Θ1: {theta1:F2} rad";
                        //lblOmega1.Text = $"ω1: {omega1:F2} rad/s";
                        lblTheta2.Text = $"Θ2: {theta2:F2} rad";
                        //lblOmega2.Text = $"ω2: {omega2:F2} rad/s";
                        //lblFrame.Text = $"Frame: {frame}";

                        // Forzar redibujado
                        openGLControl.Invalidate();
                    }
                    else
                    {
                        UpdateStatus($"Datos incompletos. Recibidos: {dSplit.Length}/5 elementos");
                    }
                });
            }
            catch (Exception ex)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    UpdateStatus($"Error procesando datos: {ex.Message}");
                });
            }
        }
        private void Disconnect()
        {
            if (connected)
            {
                connected = false;
                stream?.Close();
                client?.Close();
                UpdateStatus("Desconectado del servidor");
            }
        }

        private void UpdateStatus(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { UpdateStatus(message); });
                return;
            }
            this.Text = $"Estado: {message}";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Disconnect();
            base.OnFormClosing(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}