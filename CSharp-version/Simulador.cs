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

        //Función que genera el archivo .csv y le añade los datos de los vértices
        private void generar(object sender, EventArgs e)
        {
            //Deshabilitar el botón para evitar errores
            b_generar.Enabled = false;
            string name = tb_archivo.Text;

            //Comprobar si el archivo existe
            if (System.IO.File.Exists(name + ".csv")){
                
                int ct = 0;
                while (System.IO.File.Exists(name + ct + ".csv") && ct <= 100)
                {
                    ct++;
                }
                if (ct > 100) //Si hay más de 100 archivos iguales, no se crea el archivo
                {
                    MessageBox.Show("No se pudo crear el archivo, demasiados archivos iguales");
                    return;
                }
                name = name + ct;
            }

            //Crear nuevo documento
            System.IO.StreamWriter sw = new System.IO.StreamWriter(name + ".csv");
            try
            {
                vectores = new float[][] { v1, v2, v3, v4, v5, v6, v7, v8 };
                string[] valores = { tb_v1.Text, tb_v2.Text, tb_v3.Text, tb_v4.Text, tb_v5.Text, tb_v6.Text, tb_v7.Text, tb_v8.Text };

                //Asignar los valores iniciales a los vértices dados por el formulario
                for (int i = 0; i < valores.Length; i++)
                {
                    string v = valores[i].Replace(" ", "");
                    float[] result = Array.ConvertAll(v.Split(','), s => float.Parse(s.Trim(), CultureInfo.InvariantCulture));
                    vectores[i] = result;

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error en los valores de entrada\n" + ex.Message);
                b_generar.Enabled = true;
                return;
            }

            //Asignar los valores iniciales del resto de datos
            FX = (float)nud_FX.Value;
            FY = (float)nud_FY.Value;
            FZ = (float)nud_FZ.Value;

            GX = (float)nud_GX.Value;
            GY = (float)nud_GY.Value;

            Pasos = (float)nud_Pasos.Value;
            G = (float)nud_G.Value;
            FR = (float)nud_FR.Value;

            //Escribir una linea por cada paso
            for (int i = 0; i < Pasos; i++)
            {
                sw.WriteLine(siguiente_Linea());
            }

            sw.Close();
            //Preguntar al usuario si quiere abrir el archivo
            if (MessageBox.Show("Archivo creado con éxito, ¿Desea abrirlo?", "Archivo creado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string ruta_archivo = System.IO.Path.GetFullPath(name + ".csv");
                Process.Start("notepad.exe", ruta_archivo);
            }
            
            //Rehbilitar el botón de generar
            b_generar.Enabled = true;

        }

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
            VIsualizador viz = new VIsualizador();
            viz.Show();
        }
    }
}
