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
    public partial class Outliers : Form
    {
        bool sustituir = false;
        bool sustituir_iqr5 = false;

        public Outliers(List<List<float>> listas,
            string nombreAtributo, float valorSustituir)
        {
            InitializeComponent();
            foreach (var data in listas[0])
            {
                iqr15_lbox.Items.Add(data.ToString());
            }
            foreach (var data in listas[1])
            {
                iqr3_lbox.Items.Add(data.ToString());
            }

            atributo_lbl.Text = nombreAtributo.ToString();
            sustituyendo_lbl.Text = valorSustituir.ToString();
        }

        public bool getSustituir() { return sustituir; }
        public bool getSustituirIQr5() { return sustituir_iqr5; }

        private void sustituir_cb_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void sustituir_btn_Click(object sender, EventArgs e)
        {
            if (sustituir_cb.Checked == true)
            {
                this.sustituir_iqr5 = true;
            }
            this.sustituir = true; 
        }
    }
}
