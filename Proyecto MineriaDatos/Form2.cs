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

        float mediana;

        //constructor
        public Form2(int instancias, List<List<float>> listaFlotantes,
            List<string> nombres)
        {
            InitializeComponent();
            this.numericosFlotantes = listaFlotantes;
            this.totalInstancias = instancias;
            this.nombreColumnas = nombres;
            foreach (var nombre in this.nombreColumnas)
            {
                clases_cb.Items.Add(nombre);
            }
            //chart1.Series.Add;
        }

        //sacar moda
        public float modaFunc(List<float> numbers)
        {
            var moda = numbers.GroupBy(n => n). // ordena
            OrderByDescending(g => g.Count()). //ordena descendentes de mas repetidos
            Select(g => g.Key).FirstOrDefault(); // regresa el que mas se repitió
            return moda;
        }
        //sacar mediana
        public float medianaFunc(List<float> numbers)
        {
            int numberCount = numbers.Count();
            int halfIndex = numbers.Count() / 2;
            float median;
            if ((numberCount % 2) == 0)
            {
                median = ( (numbers.ElementAt(halfIndex) +
                    numbers.ElementAt(halfIndex-1)) / 2);
            }
            else
            {
                median = numbers.ElementAt(halfIndex);
            }
            return median;
        }

        //funcion para calcular desviacion estandar
        public float desviacionEstandarFunc(List<float> lista, float media)
        {

            float desviacionEstandar = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                desviacionEstandar = (lista.ElementAt(i) - media) * (lista.ElementAt(i) - media);
            }
            return (float)Math.Sqrt(desviacionEstandar / lista.Count);
        }
        //funcion que va a generar un boxplot
        private void boxPlot(int index)
        {
            List<float> columna = numericosFlotantes[index];
            columna.Sort();


            float media = columna.Average();
            mediana_lbl.Text = medianaFunc(columna).ToString();
            media_lbl.Text = media.ToString();
            moda_lbl.Text = modaFunc(columna).ToString();
            desviacionE_lbl.Text = desviacionEstandarFunc(columna,media).ToString();

            float min = columna.Min();
            float max = columna.Max();
            //float max = columna[columna.Count() - 1];
            float q1;
            float q2 = mediana;
            float q3;

            //sacar q1
            int mid25 = (columna.Count() / 2) / 2;
            //vemos si la mitad es un numero par o impar
            //si es par sacamos el promedio de los dos numeros para obtener la madiana
            if ((mid25 % 2) == 0)
            {
                //
                q1 = ((columna.ElementAt(mid25) + columna.ElementAt(mid25 - 1)) / 2);
            }
            else
            {
                q1 = columna.ElementAt(mid25);

            }
            //sacar q3
            int mid75 = (columna.Count() / 2) + ((columna.Count() / 2) / 2);
            if ((mid75 % 2) == 0)
            {
                q3 = ((columna.ElementAt(mid75) + columna.ElementAt(mid75 - 1)) / 2);
            }
            else
            {
                q3 = columna.ElementAt(mid75);
            }

            chart1.Series.Clear();
            chart1.Series.Add(nombreColumnas[index]).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;

            chart1.Series[nombreColumnas[index]].Points.AddXY(0,min,max, q1, q3);
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        //se seleccione otra clase en el combo box
        private void clases_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)clases_cb.SelectedIndex;  
            string nombre = (string)clases_cb.SelectedItem;
            this.boxPlot(index);
        }
    }
}
