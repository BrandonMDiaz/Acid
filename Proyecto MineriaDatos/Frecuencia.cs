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
                clases_lbox.Items.Add(nombre);
            }
            chart1.Size = new Size(750, 750);

            if (nombres.Count > 0)
            {
                clases_lbox.SelectedIndex = 0;
                this.frecuencia(0);
            }
        }
        private void frecuencia(int index)
        {
            List<string> columna = this.listaStrings[index];
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

        private void clases_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.frecuencia(clases_lbox.SelectedIndex);
        }
    }
}
