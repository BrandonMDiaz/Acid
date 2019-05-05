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
    public partial class Normalizar : Form
    {
        int opc;
        double min;
        double max;
        public Normalizar()
        {
            opc = -1;
            min = 0;
            max = 0;
            InitializeComponent();
        }

        public int getOpc(){ return this.opc; }
        public double getMin() { return this.min; }
        public double getMax() { return this.max; }


        private void min_max_btn_Click(object sender, EventArgs e)
        {
            this.opc = 0;
           
            this.min = Double.Parse(min_tb.Text.ToString());
            this.max = Double.Parse(max_tb.Text.ToString());
        }

        private void z_score_de_btn_Click(object sender, EventArgs e)
        {
            this.opc = 1;
        }

        private void z_score_dm_btn_Click(object sender, EventArgs e)
        {
            this.opc = 2;
        }
    }
}
