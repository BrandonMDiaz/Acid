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
    public partial class LlenarValores : Form
    {
        string opcion;
        public LlenarValores(string nombreAtributo, float media,
            float mediana, float moda)
        {
            InitializeComponent();
            mediana_lbl.Text = mediana.ToString();
            media_lbl.Text = media.ToString();
            moda_lbl.Text = moda.ToString();
            atributo_lbl.Text = nombreAtributo;

            if ( media == mediana && mediana == moda)
            {
                sesgo_lbl.Text = "N/A";
                distribucion_lbl.Text = "Simétrica";
                recomendacion_lbl.Text = "La distribucion no cuenta con sesgo \r\n por lo tanto se" +
                    " recomienda usar la media";
            }
            else if ( media > mediana)
            {
                sesgo_lbl.Text = "A la derecha";
                distribucion_lbl.Text = "Asimétrica";
                recomendacion_lbl.Text = "La distribucion está sesgada, por lo tanto \r\n" +
                    " se recomienda usar la mediana";

            }
            else if (media < mediana)
            {
                sesgo_lbl.Text = "A la izquierda";
                distribucion_lbl.Text = "Asimétrica";
                recomendacion_lbl.Text = "La distribucion  está sesgada, por lo tanto \r\n" +
                    "se recomienda usar la mediana";
            }
        }

        public string getOpcion()
        {
            return this.opcion;
        }
        private void mediana_btn_Click(object sender, EventArgs e)
        {
            opcion = "mediana";
        }

        private void media_btn_Click(object sender, EventArgs e)
        {
            opcion = "media";
        }
    }
}
