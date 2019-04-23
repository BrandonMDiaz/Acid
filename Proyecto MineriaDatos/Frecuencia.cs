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
    public partial class Frecuencia : Form
    {
        //lista de listas que contiene las columnas
        List<List<string>> listaStrings;

        //Nombre de cada columna
        List<string> nombreColumnas;
        public Frecuencia(List<List<string>> listaS,
            List<string> nombres)
        {
            InitializeComponent();
            this.listaStrings = listaS;
            this.nombreColumnas = nombres;
            foreach (var nombre in this.nombreColumnas)
            {
                clases_cb.Items.Add(nombre);
            }
        }
        private void frecuencia(int index)
        {
            List<string> columna = listaStrings[index];
            Dictionary<string, int> frecuencia = new Dictionary<string, int>();
            foreach(string elemento in columna)
            {
                if (!frecuencia.ContainsKey(elemento))
                    frecuencia.Add(elemento, 1);
                else
                    frecuencia[elemento]++;
            }

            chart1.Series.Clear();
            chart1.Series.Add(nombreColumnas[index]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (string value in frecuencia.Keys)
            {
                this.chart1.Series[nombreColumnas[index]].Points.AddXY(value,frecuencia[value]);
            }

        }
        private void clases_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)clases_cb.SelectedIndex;
            this.frecuencia(index);
        }
    }
}
