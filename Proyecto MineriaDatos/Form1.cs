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
        string fileName;
        Dictionary<string, string> faltantes =
          new Dictionary<string, string>();

        Dictionary<string, string> dominio =
          new Dictionary<string, string>();

        Dictionary<string, string> tipoDeDato =
          new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
        }

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
                this.tipoDeDato.Add(i.ToString(), dt.Columns[i].DataType.ToString());

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
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select *from [{0}]",new FileInfo (fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            for(int i = 0; i < dt.Columns.Count; i++)
            {
                this.tipoDeDato.Add(i.ToString(), dt.Columns[i].DataType.ToString());

            }
            return dt;
        }

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

        //agregar
        private void button1_Click(object sender, EventArgs e)
        {  
            dataGridView.Columns.Add("Column", "Test");
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

        //mostrar informacion de una columna
        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string valueName = dataGridView.Columns[e.ColumnIndex].Name;
            int missingValues = 0;
            string tipoDeDato = this.tipoDeDato[e.ColumnIndex.ToString()];
            string tipoDeDato2 = "";
            string data = string.Empty;
            for (int rows = 0; rows < dataGridView.Rows.Count; rows++)
            {
                switch (tipoDeDato)
                {
                    case "System.Int32":
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value)
                        {
                            tipoDeDato2 = "Int";
                            missingValues += 1;
                        }
                        break;
                    case "System.String":
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace((string)dataGridView[e.ColumnIndex, rows].Value))
                        {
                            tipoDeDato2 = "String";
                            missingValues += 1;
                        }
                        break;
                    case "System.Float":
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value)
                        {
                            tipoDeDato2 = "Float";
                            missingValues += 1;
                        }
                        break;
                }
                
            }
            missingValues -= 1;
            nombre_lbl.Text = valueName;
            tipo_dato_lbl.Text = tipoDeDato2;
            valores_faltantes_lbl.Text = missingValues.ToString();
   
        }
    }
}
