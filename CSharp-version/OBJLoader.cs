using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using SharpGL;
using Assimp;
using Assimp.Configs;

namespace _3D_01
{
    public partial class OBJLoader : Form
    {
        private Scene modelScene;
        private OpenGL gl;
        private Dictionary<string, uint> textureIds = new Dictionary<string, uint>();

        public OBJLoader()
        {
            InitializeComponent();
        }

        private void OBJLoader_Load(object sender, EventArgs e)
        {
            // Inicializa OpenGL
            gl = openglControl1.OpenGL;
            gl.Enable(OpenGL.GL_DEPTH_TEST);

            // Configura la iluminación y materiales
            SetupLighting();

            // Carga el modelo .fbx
            LoadModel("Pelota/soccer_ball.fbx");
        }

        private void LoadModel(string path)
        {
            // Configura el contexto de Assimp
            var importer = new AssimpContext();
            importer.SetConfig(new NormalSmoothingAngleConfig(66.0f));

            // Carga el modelo
            modelScene = importer.ImportFile(path, PostProcessSteps.Triangulate | PostProcessSteps.FlipUVs);

            if (modelScene == null)
            {
                MessageBox.Show("Error al cargar el modelo.");
                return;
            }

            // Procesa los materiales y texturas del modelo
            ProcessMaterials();
        }

        private void ProcessMaterials()
        {
            foreach (var material in modelScene.Materials)
            {
                if (material.HasTextureDiffuse)
                {
                    // Obtén la ruta de la textura difusa
                    var texturePath = material.TextureDiffuse.FilePath;

                    // Depura la ruta de la textura
                    Console.WriteLine($"Cargando textura: {texturePath}");

                    // Carga la textura y obtén su ID en OpenGL
                    uint textureId = LoadTexture(texturePath);
                    if (textureId != 0)
                    {
                        textureIds[material.Name] = textureId;
                    }
                }
                else
                {
                    // Depura los colores del material si no hay textura
                    Console.WriteLine($"Material sin textura: {material.Name}");
                    Console.WriteLine($"Color difuso: R={material.ColorDiffuse.R}, G={material.ColorDiffuse.G}, B={material.ColorDiffuse.B}");
                }
            }
        }

        private uint LoadTexture(string path)
        {
            // Asegúrate de que la ruta de la textura sea correcta
            if (!File.Exists(path))
            {
                MessageBox.Show($"Textura no encontrada: {path}");
                return 0;
            }

            // Carga la textura usando System.Drawing
            using (var bitmap = new System.Drawing.Bitmap(path))
            {
                // Genera un ID de textura
                uint[] textureIds = new uint[1];
                gl.GenTextures(1, textureIds);
                uint textureId = textureIds[0];

                // Vincula la textura
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, textureId);

                // Configura los parámetros de la textura
                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);

                // Convierte el bitmap a datos de textura
                var data = bitmap.LockBits(
                    new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    System.Drawing.Imaging.ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, (int)OpenGL.GL_RGBA, bitmap.Width, bitmap.Height, 0,
                              OpenGL.GL_BGRA, OpenGL.GL_UNSIGNED_BYTE, data.Scan0);

                bitmap.UnlockBits(data);

                return textureId;
            }
        }

        private void SetupLighting()
        {
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.ColorMaterial(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_AMBIENT_AND_DIFFUSE);

            float[] lightPosition = { 1.0f, 1.0f, 1.0f, 0.0f }; // Posición de la luz
            float[] lightDiffuse = { 1.0f, 1.0f, 1.0f, 1.0f }; // Color de la luz
            float[] lightAmbient = { 0.2f, 0.2f, 0.2f, 1.0f }; // Color ambiental

            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, lightPosition);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, lightDiffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, lightAmbient);
        }
        private float angle = 1;
        private float dist = 0;
        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            angle += 10f;
            //dist -= 0.02f;

            // Configura el color de fondo (en este caso, azul claro)
            gl.ClearColor(0.53f, 0.81f, 0.92f, 1.0f); // R, G, B, Alpha

            // Configura la vista de OpenGL
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(0, 0, -0.5);
            gl.Rotate(angle, 1, 1, 0);

            // Renderiza el modelo
            RenderModel();
        }

        private void RenderModel()
        {
            if (modelScene == null) return;

            foreach (var mesh in modelScene.Meshes)
            {
                // Obtén el material de la malla
                var material = modelScene.Materials[mesh.MaterialIndex];

                // Aplica el color difuso del material
                var diffuseColor = material.ColorDiffuse;
                gl.Color(diffuseColor.R, diffuseColor.G, diffuseColor.B, diffuseColor.A);

                // Aplica la textura difusa si existe
                if (textureIds.ContainsKey(material.Name))
                {
                    gl.Enable(OpenGL.GL_TEXTURE_2D);
                    gl.BindTexture(OpenGL.GL_TEXTURE_2D, textureIds[material.Name]);
                }
                else
                {
                    gl.Disable(OpenGL.GL_TEXTURE_2D);
                }

                // Renderiza la malla
                gl.Begin(OpenGL.GL_TRIANGLES);

                foreach (var face in mesh.Faces)
                {
                    foreach (var index in face.Indices)
                    {
                        var vertex = mesh.Vertices[index];
                        var normal = mesh.Normals[index];
                        var uv = mesh.TextureCoordinateChannels[0][index];

                        gl.Normal(normal.X, normal.Y, normal.Z);
                        gl.TexCoord(uv.X, uv.Y);
                        gl.Vertex(vertex.X, vertex.Y, vertex.Z);
                    }
                }

                gl.End();
            }
        }
    }
}