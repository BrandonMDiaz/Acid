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
        List<List<double>> numericosFlotantes;
        //total de instancias que tienen las columnas
        int totalInstancias;
        //Nombre de cada columna
        List<string> nombreColumnas;

        //constructor
        public Form2(int instancias, List<List<double>> listaFlotantes,
            List<string> nombres)
        {
            InitializeComponent();
            this.numericosFlotantes = listaFlotantes;
            this.totalInstancias = instancias;
            this.nombreColumnas = nombres;
            foreach (var nombre in this.nombreColumnas)
            {
                clases_lb.Items.Add(nombre);
            }
            if (nombres.Count > 0)
            {
                clases_lb.SelectedIndex = 0;
                this.boxPlot(0);
            }
            //chart1.Series.Add;
        }

        //sacar moda 
        static public double modaFunc(List<double> numbers)
        {
            var moda = numbers.GroupBy(n => n). // ordena
            OrderByDescending(g => g.Count()). //ordena descendentes de mas repetidos
            Select(g => g.Key).FirstOrDefault(); // regresa el que mas se repitió
            return moda;
        }
        //sacar mediana (enviar lista ordenada)
        static public double medianaFunc(List<double> numbers)
        {
            int numberCount = numbers.Count();
            int halfIndex = numbers.Count() / 2;
            double median;
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
        static public double desviacionEstandarFunc(List<double> lista, double media)
        {

            double desviacionEstandar = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                desviacionEstandar = (lista.ElementAt(i) - media) * (lista.ElementAt(i) - media);
            }
            return (double)Math.Sqrt(desviacionEstandar / lista.Count);
        }
        //funcion que va a generar un boxplot
        private void boxPlot(int index)
        {
            List<double> columna = numericosFlotantes[index];
            columna.Sort();


            double media = columna.Average();
            double mediana = medianaFunc(columna);
            double moda = modaFunc(columna);
            double desviacionE = desviacionEstandarFunc(columna, media);

            double min = columna.Min();
            double max = columna.Max();
            //float max = columna[columna.Count() - 1];
            double q1;
            double q2 = mediana;
            double q3;

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

            //min = Math.Truncate(min * 100) / 100;
            //max = Math.Truncate(max * 100) / 100;
            q3 = Math.Truncate(q3 * 100) / 100;
            q1 = Math.Truncate(q1 * 100) / 100;

            mediana = Math.Truncate(mediana * 100) / 100;
            media = Math.Truncate(media * 100) / 100;
            moda = Math.Truncate(moda * 100) / 100;
            desviacionE = Math.Truncate(desviacionE * 100) / 100;

            mediana_lbl.Text = mediana.ToString();
            media_lbl.Text = media.ToString();
            moda_lbl.Text = moda.ToString();
            desviacionE_lbl.Text = desviacionE.ToString();
            q1_lbl.Text = q1.ToString();
            q3_lbl.Text = q3.ToString();
        }

        static public List<List<double>> outliers(List<double> columna)
        {
            columna.Sort();

            double q1;
            double q3;

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

            //sacar outliers
            List<List<double>> outliersLista = new List<List<double>>();
            List<double> iqr15 = new List<double>();
            List<double> iqr30 = new List<double>();

            double rangoIntercuartil = q3 - q1;

            foreach (var valor in columna)
            {
                
                if( (valor >= q3 + (rangoIntercuartil * 1.5) && valor < q3 + (rangoIntercuartil * 3)) 
                    || (valor <= q1 - (rangoIntercuartil * 1.5) && valor > q1 - (rangoIntercuartil * 3)))
                {
                    iqr15.Add(valor);
                }
                else if (valor >=  q3 + (rangoIntercuartil * 3) || valor <= q1 - (rangoIntercuartil * 3))
                {
                    iqr30.Add(valor);
                }
            }
            outliersLista.Add(iqr15);
            outliersLista.Add(iqr30);
        
            return outliersLista;

        }

        private void clases_lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (int)clases_lb.SelectedIndex;
            string nombre = (string)clases_lb.SelectedItem;
            this.boxPlot(index);
        }
    }
}
