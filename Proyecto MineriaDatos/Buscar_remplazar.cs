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
    public partial class Buscar_remplazar : Form
    {
        List<string> result;

        public Buscar_remplazar(string buscar, string remplazar)
        {
            InitializeComponent();
            this.result = new List<string>();
            buscar_tb.Text = buscar;
            remplazar_tb.Text = remplazar;
        }

        private void remplazar_uno_btn_Click(object sender, EventArgs e)
        {
            result.Add(buscar_tb.Text); // palabra que sera remplazada
            result.Add(remplazar_tb.Text); // palabra que usaremos para remplazar
            result.Add("uno"); // boton presionado

        }
        public List<string> getResult()
        {
            return result;
        }

        private void remplazar_todo_btn_Click(object sender, EventArgs e)
        {
            result.Add(buscar_tb.Text); // palabra que sera remplazada
            result.Add(remplazar_tb.Text); // palabra que usaremos para remplazar
            result.Add("todo"); // boton presionado
        }

        private void buscar_btn_Click(object sender, EventArgs e)
        {
            result.Add(buscar_tb.Text); // palabra que sera remplazada
            result.Add(remplazar_tb.Text); // palabra que usaremos para remplazar
            result.Add("buscar"); // boton presionado
        }
    }
}
