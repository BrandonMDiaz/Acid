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
    public partial class Form2 : Form
    {
        //lista de listas que contiene las columnas
        List<List<float>> numericosFlotantes;
        //total de instancias que tienen las columnas
        int totalInstancias;
        //Nombre de cada columna
        List<string> nombreColumnas;

        float media;
        float mediana;
        float moda;
        float desviacionEstandar;

        //constructor
        public Form2(int instancias, List<List<float>> listaFlotantes,
            List<string> nombres)
        {
            InitializeComponent();
            this.numericosFlotantes = listaFlotantes;
            this.totalInstancias = instancias;
            this.nombreColumnas = nombres;
            foreach(var nombre in this.nombreColumnas)
            {
                clases_cb.Items.Add(nombre);
            }
            //chart1.Series.Add;
        }

        //funcion que va a generar un boxplot
        private void boxPlot ()
        {

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        //se seleccione otra clase en el combo box
        private void clases_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)clases_cb.SelectedIndex;
            MessageBox.Show(index.ToString());
            string nombre = (string)clases_cb.SelectedItem;
            MessageBox.Show(nombre);
            this.boxPlot();
        }
    }
}
