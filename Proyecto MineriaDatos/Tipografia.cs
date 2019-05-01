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
    public partial class Tipografia : Form
    {
        List<string> datosBase;

        public Tipografia(List<string> erroresTipograficos, List<string> db)
        {
            InitializeComponent();
            this.datosBase = db;
            foreach(string error in erroresTipograficos)
            {
                palabras_con_errores_lbox.Items.Add(error);
            }
        }

        private void corregir_btn_Click(object sender, EventArgs e)
        {

        }

        private void palabras_con_errores_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            foreach (string palabra in this.datosBase)
            {
                levenshtain(e.ToString(),palabra);
            }
        }

        static public int levenshtain(string palabra, string palabra2)
        {
            List<List<int>> tabla = new List<List<int>>();
            List<int> numeroMenor = new List<int>();
            palabra = " " + palabra;
            palabra2 = " " + palabra2;
            for(int i = 0; i < palabra.Length - 1; i++)
            {
                for(int j = 0; j < palabra2.Length - 1; j++)
                {
                    numeroMenor.Clear();
                    //vemos si se trata de la primera fila
                    //si es la primera fila entonces agregamos los valores del 0 hasta el
                    //largo de la palabra
                    if (i == 0)
                    {
                        tabla[i][j] = j;
                        //tabla[i].Add(i);
                    }
                    else if(j == 0) // si j es 0 significa que agregamos el indice de la columna i
                    {
                        tabla[i][j] = i;
                        //tabla[i].Add(i);
                    }
                    else
                    {
                        numeroMenor.Add(tabla[i-1][j]);
                        numeroMenor.Add(tabla[i][j-1]);
                        if (palabra[i] == palabra2[j])
                        {
                            numeroMenor.Add(tabla[i-1][j-1] + 0);
                        }
                        else
                        {
                            numeroMenor.Add(tabla[i - 1][j - 1] + 1);
                        }
                        tabla[i][j] = numeroMenor.Min();
                    }
                }
            }
            return tabla.Last().Last();
        }
    }
}
