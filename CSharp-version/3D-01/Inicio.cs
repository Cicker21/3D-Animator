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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void iniciar(object sender, EventArgs e)
        {
            this.Hide();

            Visualizador vis = new Visualizador();
            vis.FormClosed += (s, args) => this.Show();
            vis.Show();


        }

        private void crear(object sender, EventArgs e)
        {
            this.Hide();

            Bases bass = new Bases();
            bass.FormClosed += (s, args) => this.Show();
            bass.Show();

        }
    }
}
