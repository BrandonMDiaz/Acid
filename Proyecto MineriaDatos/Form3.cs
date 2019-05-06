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
    public partial class Form3 : Form
    {
        private string nombre;
        private string tipo;
        private string dom;


        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Form3()
        {
            nombre = "";
            tipo = "";
            InitializeComponent();
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public string getTipo()
        {
            return this.tipo;
        }
        public string getDominio()
        {
            return this.dom;
        }
        private void ok_btn_Click(object sender, EventArgs e)
        {
            this.dom = dominio_tb.Text;
            if (nombre_txt.Text != null || nombre_txt.Text != ""
                && tipo_cb.Text != null || tipo_cb.Text != "")
            {
                Nombre = nombre_txt.Text;
                if (tipo_cb.Text == "System.Int" || tipo_cb.Text == "System.String"
                    || tipo_cb.Text == "System.Float")
                {
                    if (tipo_cb.Text == "Int")
                    {
                        Tipo = tipo_cb.Text + "32";
                    }
                    else
                    {
                        Tipo = tipo_cb.Text;
                    }

                }
                else
                {
                    MessageBox.Show("Tipo de dato no valido");
                    this.DialogResult = DialogResult.None;
                }
            }
            else
            {
                MessageBox.Show("Dejaste un campo vacio");
                this.DialogResult = DialogResult.None;

            }
        }

        private void tipo_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
