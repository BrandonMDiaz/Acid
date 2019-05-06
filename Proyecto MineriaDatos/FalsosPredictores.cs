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
        List<string> categoricos = new List<string>();
        List<double> numericos = new List<double>();

        public FalsosPredictores(List<string> valores,
            List<double> val, List<string> nombreColumnas)
        {
            InitializeComponent();
            foreach (var i in nombreColumnas)
            {
                valores_lb.Items.Add(i);
            }
            if (valores.Count > 0)
            {
                categoricos = valores;
                nombre_lbl.Text = "Tschuprow";
            }
            else
            {
                numericos = val;
                nombre_lbl.Text = "Chi-Cuadrada";
            }
        }

        private void valores_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (nombre_lbl.Text == "Tschuprow")
            {
                coeficiente_lbl.Text = categoricos[valores_lb.SelectedIndex];
            }
            else 
            {
                coeficiente_lbl.Text = numericos[valores_lb.SelectedIndex].ToString();

            }
        }
    }
}
