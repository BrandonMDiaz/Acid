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
        public editGridView(string cn, int ci)
        {
            InitializeComponent();
            this.columnName = cn;
            this.columnIndex = ci;
            name_tb.Text = columnName;
        }

        public string getHeaderName()
        {
            return this.columnName;
        }
        public int getColumnIndex()
        {
            return this.columnIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.columnName = name_tb.Text;
            this.Close();
        }
    }
}
