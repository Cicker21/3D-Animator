using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace _3D_01
{
    public partial class Bases : Form
    {
        public Bases()
        {
            InitializeComponent();
        }

        private string ruta_csv = null;
        private string ProcessOBJFile(string filePath)
        {

            if (filePath == null)
            {
                MessageBox.Show("Por favor seleccione un archivo .obj");
                return null;
            }

            // Listas para almacenar vértices y caras
            List<string> vertices = new List<string>();
            List<string> faces = new List<string>();

            // Leer el archivo .obj
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Procesar vértices
                    if (line.StartsWith("v "))
                    {
                        vertices.Add(line);
                    }
                    // Procesar caras
                    else if (line.StartsWith("f "))
                    {
                        faces.Add(line);
                    }
                }
            }

            // Procesar las caras para obtener las coordenadas de los vértices
            List<string> outputFaces = new List<string>();
            foreach (string face in faces)
            {
                // Obtener los índices de los vértices de la cara
                string[] faceData = face.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string faceVertices = "";

                // Ignorar el primer elemento ("f")
                for (int i = 1; i < faceData.Length; i++)
                {
                    // Extraer el índice del vértice (el primer número en el formato v/vt/vn)
                    int vertexIndex = int.Parse(faceData[i].Split('/')[0]) - 1;

                    // Obtener las coordenadas del vértice
                    string vertexLine = vertices[vertexIndex];
                    string[] vertexCoords = vertexLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    // Formatear las coordenadas
                    string[] v_fix = ubicar(vertexCoords[1], vertexCoords[2], vertexCoords[3], i);
                    string x = v_fix[0];
                    string y = v_fix[1];
                    string z = v_fix[2];

                    faceVertices += $"{x},{y},{z}=";
                }

                faceVertices += "|";
                outputFaces.Add(faceVertices);
            }



            // Guardar el resultado en un archivo de salida


            return string.Join("", outputFaces);

        }

        decimal diff_x = 0, diff_y = 0, diff_z = 0;
        private string[] ubicar(string x, string y, string z, int i)
        {
            // Parse input values
            decimal x_ = decimal.Parse(x.Replace(".", ","));
            decimal y_ = decimal.Parse(y.Replace(".", ","));
            decimal z_ = decimal.Parse(z.Replace(".", ","));

            decimal v1x = nud_v1X.Value;
            decimal v1y = nud_v1Y.Value;
            decimal v1z = nud_v1Z.Value;

            decimal tamaño = nud_tmñ.Value;

            decimal dx = nud_dx.Value;
            decimal dy = nud_dy.Value;
            decimal dz = nud_dz.Value;

            x_ *= tamaño;
            y_ *= tamaño;
            z_ *= tamaño;

            x_ *= dx;
            y_ *= dy;
            z_ *= dz;


            //Origen v1
            if (i == 0)
            {
                diff_x = x_ - v1x;
                diff_y = y_ - v1y;
                diff_z = z_ - v1z;

                x_ = v1x;
                y_ = v1y;
                z_ = v1z;
            }
            else
            {
                x = x + diff_x;
                y = y + diff_y;
                z = z + diff_z;
            }

            x = x_.ToString().Replace(",", ".");
            y = y_.ToString().Replace(",", ".");
            z = z_.ToString().Replace(",", ".");


            return new string[] { x, y, z };
        }
        private void b_generar_Click(object sender, EventArgs e)
        {

            string ruta_actual = Directory.GetCurrentDirectory();

            // Combinar la ruta actual con el nombre del archivo usando Path.Combine
            string ruta = Path.Combine(ruta_actual, tb_archivo.Text);

            int ct = 0;
            if (File.Exists(ruta + ".csv"))
            {
                while (File.Exists(ruta + ct.ToString() + ".csv") && ct < 100)
                {
                    ct++;
                }
                if (ct == 100)
                {
                    MessageBox.Show("Se han generado demasiados archivos, por favor elimine algunos.");
                    return;
                }
                ruta = ruta + ct.ToString() + ".csv";
            }
            else
            {
                ruta = ruta + ".csv";
            }
            ruta_csv = ruta;
            b_generar.Enabled = false;
            tb_archivo.Enabled = false;
            tb_archivo.Text = ruta;
            this.Text = ruta;
            b_nobjeto.Enabled = true;
        }

        private List<string> objetos = new List<string>();

        private void n_objeto(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Filter = "Archivos de texto (*.obj)|*.obj|Todos los archivos (*.*)|*.*";
            openFileDialog1.Title = "Abrir archivo de texto";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ruta_obj = openFileDialog1.FileName;
                string objeto = ProcessOBJFile(ruta_obj);
                if (objeto != null)
                {
                    objetos.Add(objeto);
                    MessageBox.Show("Archivo procesado correctamente\n" + objeto);
                    l_obj_ct.Text = "Objetos: " + objetos.Count.ToString();
                }
            }

            if (objetos.Count > 0)
            {
                b_terminar.Enabled = true;
            }

        }

        private void b_terminar_Click(object sender, EventArgs e)
        {
            b_nobjeto.Enabled = false;
            this.Text = "Crear Bases";
            tb_archivo.Text = "test";
            tb_archivo.Enabled = true;
            b_generar.Enabled = true;
            b_nobjeto.Enabled = false;

            b_terminar.Enabled = false;

            File.WriteAllText(ruta_csv, string.Join("%", objetos));

            DialogResult rs = MessageBox.Show("Archivo guardado correctamente\n¿Desea Abrirlo?", "Archivo guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("notepad.exe", ruta_csv);
            }
        }
    }
}