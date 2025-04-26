using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_01
{
    public partial class Fisica : Form
    {
        public event Action<List<Fisicas>> FisicaEnviada;

        public Fisica(int c)
        {
            InitializeComponent();
            this.Text = $"Fisica (0/{c})";
            cantidad = c;
        }
        private int cantidad;
        private List<Fisicas> fisicas = new List<Fisicas>();
        private void añadir(object sender, EventArgs e)
        {
            int fc = fisicas.Count;
            if (fc < cantidad)
            {
                fisicas.Add(new Fisicas((float)nud_GeX.Value, (float)nud_GeY.Value, (float)nud_GeZ.Value, (float)nud_GX.Value, (float)nud_GY.Value, (float)nud_GZ.Value, (float)nud_VX.Value, (float)nud_VY.Value, (float)nud_VZ.Value, (float)nud_m.Value));
                this.Text = $"Fisica ({fc + 1}/{cantidad})";

            }
            else
            {
                MessageBox.Show("Ya no se pueden añadir más objetos");
            }
            fc = fisicas.Count;
            if (fc == cantidad)
            {
                devolver(fisicas);
                this.Close();
            }
        }

        private void devolver(List<Fisicas> fiss)
        {
            FisicaEnviada?.Invoke(fiss);
        }
    }

}
