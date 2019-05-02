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
        List<string> errores;
        List<List<string>> respuesta = new List<List<string>>();

        public Tipografia(List<string> erroresTipograficos, List<string> db)
        {
            InitializeComponent();
            this.datosBase = db;
            foreach(string error in erroresTipograficos)
            {
                palabras_con_errores_lbox.Items.Add(error);
            }
            this.errores = erroresTipograficos;
        }
        public List<List<string>> getRespuesta()
        {
            return respuesta;
        }
        private void corregir_btn_Click(object sender, EventArgs e)
        {
            List<string> respuestas = new List<string>();
            //se usa el dato seleccionado en la segunda parte
            if (otra_opcion_cb.Checked)
            {
                if (otras_opciones_lbox.SelectedItem != null 
                    && otras_opciones_lbox.SelectedItem != DBNull.Value
                    && otras_opciones_lbox.SelectedItem.ToString() != "")
                {

                    string palabra = otras_opciones_lbox.SelectedItem.ToString();
                    respuestas.Add(palabra);//palabra seleccionada que va a corregir
                    //palabra que queremos corregir
                    respuestas.Add(palabras_con_errores_lbox.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("No se seleccionó ninguna opcion");
                }
            }
            //se usa por el dato recomendado
            else
            {
                respuestas.Add(valor_lbl.Text); //palabra recomendada
                respuestas.Add(palabras_con_errores_lbox.SelectedItem.ToString());//palabra a corregir  
            }
            respuesta.Add(respuestas);
            valor_lbl.Text = "";
            palabras_con_errores_lbox.Items.Remove(palabras_con_errores_lbox.SelectedItem);
            if (palabras_con_errores_lbox.Items.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            MessageBox.Show("Valor agregado a la lista para corregir");
        }

        private void palabras_con_errores_lbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(palabras_con_errores_lbox.SelectedIndex > -1)
            {
                int min = 10;
                string palabraMenor = "";
                string palabraSeleccionada = palabras_con_errores_lbox.SelectedItem.ToString();
                foreach (string palabra in this.datosBase)
                {
                    if (!errores.Contains(palabra))
                    {
                        int valor = levenshtain(palabraSeleccionada, palabra);
                        if (min > valor)
                        {
                            //MessageBox.Show(palabraMenor + " " + min.ToString());
                            min = valor;
                            palabraMenor = palabra;
                            //MessageBox.Show(palabraMenor + " " + min.ToString());

                        }
                    }

                }
                valor_lbl.Text = palabraMenor;
            }
            
        }

        static public int levenshtain(string palabra, string palabra2)
        {
            List<List<int>> tabla = new List<List<int>>();
            List<int> numeroMenor = new List<int>();
            palabra = " " + palabra;
            palabra2 = " " + palabra2;
            //hacemos una lista vacia con el largo de las palabras 
            //para poder trabajar sobre ella de un manera mas sencilla
            for (int i = 0; i < palabra.Length; i++)
            {
                List<int> lista = new List<int>();
                for (int j = 0; j < palabra2.Length; j++)
                {
                    lista.Add(0);
                }
                tabla.Add(lista);
            }
            //aqui se aplica levenshtain
            for(int i = 0; i < palabra.Length; i++)
            {
                for(int j = 0; j < palabra2.Length; j++)
                {
                    numeroMenor.Clear();
                    //vemos si se trata de la primera fila
                    //si es la primera fila entonces agregamos los valores del 0 hasta el
                    //largo de la palabra
                    if (i == 0)
                    {
                        tabla[i][j] = j;
                        //tabla[i].Add(j);
                    }
                    else if(j == 0) // si j es 0 significa que agregamos el indice de la columna i
                    {
                        tabla[i][j] = i;
                        //tabla[i].Add(i);
                    }
                    else
                    {
                        numeroMenor.Add(tabla[i-1][j] + 1);
                        numeroMenor.Add(tabla[i][j-1] + 1);
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

        private void otra_opcion_cb_CheckedChanged(object sender, EventArgs e)
        {
            if (otra_opcion_cb.Checked)
            {
                otras_opciones_lbox.Visible = true;
                corregir_btn.Location = new Point(162,455);
                Tipografia.ActiveForm.Size = new Size(560, 574);
                otras_opciones_lbox.Items.Clear();
                foreach (string palabra in this.datosBase)
                {
                    if (!this.errores.Contains(palabra))
                    {
                        otras_opciones_lbox.Items.Add(palabra);
                    }
                }
            }
            else
            {
                otras_opciones_lbox.Visible = false;
                corregir_btn.Location = new Point(162, 314);
                Tipografia.ActiveForm.Size = new Size(560, 443);
            }
        }
    }
}
