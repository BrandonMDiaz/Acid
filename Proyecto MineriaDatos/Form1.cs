using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace Proyecto_MineriaDatos
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        //guarda el nombre del archivo abierto
        string fileName;
        //guarda los valores faltantes 
        Dictionary<string, string> faltantes =
          new Dictionary<string, string>();
        //guarda el dominio por columna
        Dictionary<string, string> dominio =
          new Dictionary<string, string>();

        List<string> tipoDeDato = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        // funcion para leer un archivo .data (aun no está terminada)
        public DataTable LeerData(string fileName)
        {
            this.fileName = fileName;
            DataTable dt = new DataTable("Data");
            using (OleDbConnection cn = new OleDbConnection("Provider= Microsoft.jet.OLEDB.4.0;Data Source=\"" +
               Path.GetDirectoryName(fileName) + "\";Extended Properties= 'text;HDR=yes;FMT= Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select *from [{0}]", new FileInfo(fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                this.tipoDeDato.Add(dt.Columns[i].DataType.ToString());

            }
            return dt;
        }

        //leer csv
        public DataTable LeerCSV(string fileName)
        {
            this.fileName = fileName;
            DataTable dt = new DataTable("Data");
            using (OleDbConnection cn = new OleDbConnection("Provider= Microsoft.jet.OLEDB.4.0;Data Source=\""+
                Path.GetDirectoryName(fileName) + "\";Extended Properties= 'text;HDR=yes;FMT= Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]", new FileInfo (fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.FillSchema(dt, SchemaType.Source);
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            this.tipoDeDato.Add(dt.Columns[i].DataType.ToString());
                            if (dt.Columns[i].DataType != typeof(string))
                                dt.Columns[i].DataType = typeof(string);
                        }
                        adapter.Fill(dt);
                    }
                }
            }
            
            // DataGridView1.Columns(4).ValueType = System.Type.GetType("System.Decimal")
            return dt;
        }

        //function para guardar archivo
        public void guardarArchivo(string fileName)
        {
         
            DataTable dt = (DataTable)(dataGridView.DataSource); //extraer la informacion del data grid view
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(fileName, sb.ToString());
        }

        //cargar archivo 
        private void btnCargar_Click(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK) {
                        dataGridView.DataSource = LeerCSV(ofd.FileName);
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }


                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        
        //guardar
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            guardarArchivo(this.fileName);
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //guardar como
        private void btn_guardar_como_Click(object sender, EventArgs e)
        {
            try
            {
                
                using (SaveFileDialog ofd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true})
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        guardarArchivo(ofd.FileName);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //salir de la aplicacion
        private void salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //agregar columna
        private void button1_Click(object sender, EventArgs e)
        {
            string columnNombre = ""; //nombre de la columna
            string columnTipo = ""; //tipo de dato de la columna

            //se abre el form3 que esta diseñado para pedir estos dos valores
            using (Form3 frm = new Form3())
            { 
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    columnNombre = frm.getNombre();
                    columnTipo = frm.getTipo();
                    dataGridView.Columns.Add(columnNombre,"column");
                    dataGridView.Columns[dataGridView.Columns.Count - 1].ValueType = System.Type.GetType("System." + columnTipo);
                    tipoDeDato.Add("System." + columnTipo);
                }
            }
            //MessageBox.Show(dataGridView.Columns[dataGridView.Columns.Count - 1].ValueType.ToString());

        }

        //editar nombre de columna
        private void dataGridView_ColumnHeaderMouseDoubleClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            string columnName = dataGridView.Columns[e.ColumnIndex].Name;
            editGridView edit = new editGridView(columnName, e.ColumnIndex);
            edit.Show();
            edit.FormClosed += new FormClosedEventHandler(Form_Closed);
            
        }

        //cuando se cierra el form de editar se llama a esta funcion para recibir los 
        //parametros que se agregaron en ese form
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            editGridView edit = (editGridView)sender;
            dataGridView.Columns[edit.getColumnIndex()].HeaderText = edit.getHeaderName();
        }

        //eliminar una fila completa (eliminar instancia)
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows.Count < 2  && e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                {
                    if (oneCell.Selected)
                        dataGridView.Rows.RemoveAt(oneCell.RowIndex);
                }
            }
        }

        //mostrar informacion de una columna al hacer click sobre su nombre
        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string valueName = dataGridView.Columns[e.ColumnIndex].Name;
            int missingValues = 0;
            // string tipoDeDato = this.tipoDeDato[e.ColumnIndex.ToString()];
            string tipoDeDato = this.tipoDeDato[e.ColumnIndex];
            MessageBox.Show(tipoDeDato);
            string tipoDeDato2 = "";
            string data = string.Empty;
            //iteramos todas las filas de una columna para poder saber los valores
            //faltantes y mas informacion.
            for (int rows = 0; rows < dataGridView.Rows.Count-1; rows++)
            {
                MessageBox.Show("adentro");
                //revisamos que tipo de dato es la columna columna
                switch (tipoDeDato)
                {
                    case "System.Int32":
                        tipoDeDato2 = "Int";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace((string)dataGridView[e.ColumnIndex, rows].Value)
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            dataGridView[e.ColumnIndex, rows].Value = "?";
                            missingValues += 1;
                        }
                        break;
                    case "System.String":
                        tipoDeDato2 = "String";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace((string)dataGridView[e.ColumnIndex, rows].Value)
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            dataGridView[e.ColumnIndex, rows].Value = "?";
                            missingValues += 1;
                        }
                        break;
                    case "System.Float":
                        tipoDeDato2 = "Float";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            dataGridView[e.ColumnIndex, rows].Value = "?";
                            missingValues += 1;
                        }
                        break;
                }
                
            }
            //missingValues -= 1;
            nombre_lbl.Text = valueName;
            tipo_dato_lbl.Text = tipoDeDato2;
            valores_faltantes_lbl.Text = missingValues.ToString();
   
        }
        //llamar a form que muestra el grafico de boxplot
        private void box_plot_btn_Click(object sender, EventArgs e)
        {
            //creamos listas para los valores numericos enteros y flotantes
            //esto para poder pasarselos a la form de boxplot
            //List<List<int>> numericosEnteros = new List<List<int>>();
            List<List<float>> numericosFlotantes = new List<List<float>>();
            int totalInstancias = dataGridView.Rows.Count;
            List<string> nombresColumnas = new List<string>();

            //itereamos las columnas que su tipo de dato sea entero u flotante
            //ya que con estas solamente se puede trabajar
            for (int column = 0; column < dataGridView.ColumnCount; column++)
            {
                //obtenemos el tipo de dato de la columna
                string tipoDeDato = this.tipoDeDato[column];
                //creamos una lista donde meteremos toda 1 columna
                List<float> list = new List<float>();
                //No tomamos en cuenta las columnas tipo string
                if (tipoDeDato != "System.String")
                {
                    //iteramos sobre toda 1 columna
                    for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                    {
                        //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                        if (dataGridView[column, rows] != null
                            && dataGridView[column, rows].Value != DBNull.Value
                            && (string)dataGridView[column, rows].Value != ""
                            && (string)dataGridView[column, rows].Value != "?")  //value is not null
                        {
                            //vamos agregando las celdas a la lista
                            //MessageBox.Show((string)dataGridView[column, rows].Value);
                            list.Add(float.Parse(dataGridView[column, rows].Value.ToString()));
                        }
                    }
                    //agregamos la lista que creamos anteriormente a la lista de listas
                    //que tenemos
                    numericosFlotantes.Add(list);
                }
            }
            //abrimos la form de boxplot y le mandamos todas las columnas, sus nombres y el
            //total de instancias
            Form2 boxPlot = new Form2(totalInstancias,numericosFlotantes,nombresColumnas);
            boxPlot.Show();
            //boxPlot.FormClosed += new FormClosedEventHandler(Form_Closed);
        }
    }
}
