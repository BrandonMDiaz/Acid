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
    public partial class Correlacion : Form
    {
        List<double> val;
        List<string> tipo;
        public Correlacion(List<double> valores,
            List<string> nombresColumnas, List<string> tipoData)
        {
            InitializeComponent();
            val = valores;
            tipo = tipoData;
            foreach (var nombre in nombresColumnas)
            {
                atributos_lb.Items.Add(nombre);
            }
        }

        private void atributos_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = atributos_lb.SelectedIndex;
            if (tipo[index] == "numeric")
            {
                nombre_correlacion_lbl.Text = "Pearson:";
            }
            else
            {
                nombre_correlacion_lbl.Text = "Tschuprow:";
            }
            correlacion_lbl.Text = val[index].ToString();
        }
    }
}
