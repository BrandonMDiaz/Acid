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
    public partial class FalsosPredictores : Form
    {
        List<double> numericos = new List<double>();
        bool numeric;
        public FalsosPredictores(List<double> valores,
            List<string> nombreColumnas, bool numerico)
        {
            InitializeComponent();
            numeric = numerico;
            foreach (var i in nombreColumnas)
            {
                valores_lb.Items.Add(i);
            }
            if (!numerico)
            {
                numericos = valores;
                nombre_lbl.Text = "Tschuprow";
            }
            else
            {
                numericos = valores;
                nombre_lbl.Text = "Pearson";
            }
        }

        private void valores_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            double coeficiente = numericos[valores_lb.SelectedIndex];
            coeficiente_lbl.Text = coeficiente.ToString();
            if (coeficiente > 0.5 && !numeric)
            {
                posible_lbl.Text = "** Valor con alta correlacion";
            }
            else if (coeficiente > 0.5 && coeficiente < -0.5 
                && numeric)
            {
                posible_lbl.Text = "** Valor con alta correlacion";
            }
            else
            {
                posible_lbl.Text = "";
            }
        }
    }
}
