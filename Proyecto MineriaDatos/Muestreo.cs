using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MineriaDatos
{
    public partial class Muestreo : Form
    {
        int opc = -1;
        int instancias = -1;
        public Muestreo(int numeroInstancias)
        {
            InitializeComponent();
            num_instancias_lbl.Text = numeroInstancias.ToString();
        }

        public int getOpc() { return this.opc; }

        public int getInstancias() { return this.instancias; }

        private void remplazo_btn_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(tamanio_txt.Text) < Int32.Parse(num_instancias_lbl.Text))
            {
                this.opc = 0;
                this.instancias = Int32.Parse(tamanio_txt.Text);
            }
            else
            {
                MessageBox.Show("El muestreo tiene que ser menor que el total de instancias");
            }
        }

        private void sin_remplazo_btn_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(tamanio_txt.Text) < Int32.Parse(num_instancias_lbl.Text))
            {
                this.opc = 1;
                this.instancias = Int32.Parse(tamanio_txt.Text);
                
            }
            else
            {
                MessageBox.Show("El muestreo tiene que ser menor que el total de instancias");
            }
        }
    }
}
