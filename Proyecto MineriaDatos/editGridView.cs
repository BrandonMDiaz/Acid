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
    public partial class editGridView : Form
    {
        private string columnName;
        private int columnIndex;
        private string dominio;
        private string tipoDeDato;
        private bool claseObjetivo = false;


        public editGridView(string cn, int ci, string dominio,
            string tipoDeDato, bool objetivo)
        {
            InitializeComponent();
            this.columnName = cn;
            this.columnIndex = ci;
            this.dominio = dominio;
            this.tipoDeDato = tipoDeDato;

            name_tb.Text = columnName;
            dominio_tb.Text = dominio;
            tipo_cb.SelectedItem = tipoDeDato;
            if (objetivo)
            {
                checkBox1.Checked = true;
            }
        }

        public string getHeaderName(){ return this.columnName; }
        public int getColumnIndex(){ return this.columnIndex; }
        public string getDominio() { return this.dominio; }
        public string getTipoDeDato() { return this.tipoDeDato; }
        public bool getObjetivo() { return this.claseObjetivo; }


        private void button1_Click(object sender, EventArgs e)
        {
            this.columnName = name_tb.Text;
            this.dominio = dominio_tb.Text;
            this.tipoDeDato = tipo_cb.SelectedItem.ToString();
            //this.Close();
        }

        private void editGridView_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.claseObjetivo = true;
            }
            else
            {
                this.claseObjetivo = false;
            }
        }
    }
}
