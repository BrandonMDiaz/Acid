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
using System.Text.RegularExpressions;

namespace Proyecto_MineriaDatos
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        int claseObjetivo = -1;
        //guarda el nombre del archivo abierto
        string fileName;
        //guardar informacion del archivo
        string infoData = "";
        //como se representaran los valores faltantes
        string valorFaltante = "";
        //guarda el dominio 
        List<string> dominio = new List<string>();
        //guarda el tipo de dato por columna
        //(numérico, nominal, ordinal, boleano,
        //fecha).
        //nominal = categorico
        //ordinal = categorico
        List<string> tipoDeDato = new List<string>();
        //atributos
        List<string> atributos = new List<string>();


        //guarda la columna seleccionada actualmente
        int indexColumna = -1;
        int valoresFaltantes = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // funcion para leer un archivo .data
        public DataTable LeerData(string fileName)
        {
            this.fileName = fileName;
            //DataTable dt = new DataTable("Data");
            DataTable dt = new DataTable("Data");

            //informacion general
            //descripcion de la base de datos
            //base de datos
            string path = Path.GetDirectoryName(fileName);

            using (StreamReader reader = new StreamReader(fileName))
            {
                this.tipoDeDato.Clear();

                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                //parte en la que se encuentra el archivo
                // 0 = informacion general
                // 1 = descripcion de la base de datos
                // 2 = base de datos

                string info = "";
                string relation; //nombre del dataset
                List<string> attribute = new List<string>(); //datos en el dataset
                string missingValue; //valor faltante
                
                //leemos hasta llegar a donde esta la informacion
                while (!reader.EndOfStream)
                {
                    string newLine = "";
                    newLine = reader.ReadLine();
                    if (newLine.Contains("@data"))
                    {
                        break;
                    }
                    else if (newLine.Contains("%%"))
                    {
                        //newLine.Remove(newLine.First());
                        //newLine.Remove(newLine.First());
                        info += newLine;
                    }
                    else if (newLine.Contains("@relation"))
                    {
                        string[] split = newLine.Split(null);
                        relation = split[1];
                    }
                    else if (newLine.Contains("@attribute"))
                    {
                        attribute.Add(newLine);
                    }
                    else if (newLine.Contains("@missingValue"))
                    {

                        //separamos la string donde esté un espacio
                        string[] split = newLine.Split(null);
                        //guardamos el valor que se usara para indicar
                        //valores faltantes
                        missingValue = split[1];
                    }
                }

                List<string> atributos = new List<string>();
                List<string> tipoDeDato = new List<string>();
                List<string> dominio = new List<string>();

                //tomamos los atributos del dataset
                foreach (var data in attribute)
                {
                    string[] split = data.Split(null);
                    //agregamos los atributos al tipo de dato
                    atributos.Add(split[1]);
                    //agregamos dato al tipo de dato
                    tipoDeDato.Add(split[2]);
                    //sacamos el dominio y lo agregamos a la lista
                    //de dominio
                    string dominioTotal = "";
                    for (int i = 3; i < split.Count(); i++)
                    {
                        dominioTotal += split[i];
                    }
                    dominio.Add(dominioTotal);
                }

                this.tipoDeDato = tipoDeDato;
                this.dominio = dominio;
                this.atributos = atributos;
                this.infoData = info;
                //
                //
                //agregar informacion al dt

                //agregamos header al dt
                foreach (var dato in atributos)
                {
                    dt.Columns.Add(dato);
                }
                
                while (!reader.EndOfStream)
                {
                    string newLine = "";
                    newLine = reader.ReadLine();
                    List<string> row = newLine.Split(',').ToList<string>();

                    dt.Rows.Add(row.ToArray());
                }

                return dt;
                //
                //
                //

                // Escribimos toda la informacion resultante a un csv
                string pathFile = path + "aux.csv";


                //agregamos informacion a un nuevo archivo que será leido
                using (var tw = new StreamWriter(pathFile, true))
                {
                    string lineaConHeaders = "";

                    //juntamos los nombres de las columnas separados por ,
                    foreach (var dato in atributos)
                    {
                        dt.Columns.Add(dato);
                        lineaConHeaders += dato + ",";
                    }
                    //remover ultima coma :)
                    lineaConHeaders = lineaConHeaders.Remove(lineaConHeaders.Length - 1);
                    while (!reader.EndOfStream)
                    {
                        string newLine = "";
                        newLine = reader.ReadLine();
                        tw.WriteLine(newLine);
                        dt.Rows.Add(atributos.ToArray());
                    }
                }

                //leer archivo csv que cree
                using (OleDbConnection cn = new OleDbConnection("Provider= Microsoft.jet.OLEDB.4.0;Data Source=\"" +
                    Path.GetDirectoryName(pathFile) + "\";Extended Properties= 'text;HDR=yes;FMT= Delimited(,)';"))
                {
                    using (OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]", new FileInfo(pathFile).Name), cn))
                    {
                        cn.Open();
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            //agregamos header a la dt
                            for (int i = 0; i < atributos.Count; i++)
                            {
                                dt.Columns.Add(atributos[i]);
                            }
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
                File.Delete(pathFile);
            }
            return dt;
        }

        //leer csv
        public DataTable LeerCSV(string fileName)
        {
            this.tipoDeDato.Clear();
            this.fileName = fileName;
            DataTable dt = new DataTable("Data");
            using (OleDbConnection cn = new OleDbConnection("Provider= Microsoft.jet.OLEDB.4.0;Data Source=\"" +
                Path.GetDirectoryName(fileName) + "\";Extended Properties= 'text;HDR=yes;FMT= Delimited(,)';"))
            {
                using (OleDbCommand cmd = new OleDbCommand(string.Format("select * from [{0}]", new FileInfo(fileName).Name), cn))
                {
                    cn.Open();
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.FillSchema(dt, SchemaType.Source);
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            this.dominio.Add("");
                            string tipoData = dt.Columns[i].DataType.ToString();
                            string aux = "";
                            switch (tipoData)
                            {
                                case "System.String":
                                    aux = "nominal";
                                    break;
                                case "System.Int32":
                                    aux = "numeric";
                                    break;
                                case "System.Float":
                                    aux = "numeric";
                                    break;
                                case "System.Double":
                                    aux = "numeric";
                                    break;
                                case "System.DateTime":
                                    aux = "DateTime";
                                    break;
                                default:
                                    aux = "nominal";
                                    break;
                            }
                            this.tipoDeDato.Add(aux);
                          
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

        /// <summary>
        /// funcion para guardar el archivo que se esta utilizando, sobreescribe
        /// la informacion que tienes actualmente sobre la que contiene el archivo al
        /// principio
        /// </summary>
        /// <param name="fileName">el nombre del archivo que vamos a sobreescribir</param>
        public void guardarArchivo(string fileName)
        {
            //revisa si tiene datos el datagridview, si no tiene se  cancela
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No hay informacion que guardar");
            }
            else
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
            
        }

        //cargar archivo 
        private void btnCargar_Click(object sender, EventArgs e)
        {

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv|DATA|*.data", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK) {
                        //cargar datos al datagridview
                        if (Path.GetExtension(ofd.FileName) == ".data")
                        {
                            dataGridView.DataSource = LeerData(ofd.FileName);
                        }
                        else
                        {
                            dataGridView.DataSource = LeerCSV(ofd.FileName);              
                        }
                        instancias_totales_lbl.Text = (dataGridView.Rows.Count - 1).ToString();
                        //desactivar el ordenar
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        for (int column = 0; column < dataGridView.Columns.Count; column++)
                        {
                            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                            {
                                //si alguna celda esta vacia o es igual a "?" la marcamos
                                if (dataGridView[column, rows] == null
                                    || dataGridView[column, rows].Value == DBNull.Value
                                    || (string)dataGridView[column, rows].Value == ""
                                    || (string)dataGridView[column, rows].Value == "?")
                                {
                                    dataGridView[column, rows].Value = "?";
                                    dataGridView[column, rows].Style.BackColor = Color.Red;

                                }
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Cuando se presiona el boton de guardar se manda a llamar la siguiente funcion
        /// la cual llama a la funcion de guardarArchivo que se encarga de 
        /// sobreescribir los datos actuales en el archivo que estas utilizando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            guardarArchivo(this.fileName);
        }

        private void valoresFaltantesFueraDeDominio()
        {

        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Al presionar el boton guardar como se llama a esta funcion. Ella se encarga de
        /// abrir un saveFileDialog el cual contiene tus archivos del sistema, una vez que 
        /// seleccionas el archivo se crea y se guarda ahí la informacion que tenias.
        /// tambien se actualiza el archivo sobre el cual estas trabajando y empiezas
        /// a utilizar este nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_guardar_como_Click(object sender, EventArgs e)
        {
            try
            {

                using (SaveFileDialog ofd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        guardarArchivo(ofd.FileName);
                        this.fileName = ofd.FileName;
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
            string dominio = "";
            //se abre el form3 que esta diseñado para pedir estos dos valores
            using (Form3 frm = new Form3())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    columnNombre = frm.getNombre();
                    columnTipo = frm.getTipo();
                    dataGridView.Columns.Add(columnNombre, columnNombre);
                    dataGridView.Columns[dataGridView.Columns.Count - 1].ValueType = System.Type.GetType("System.String");
                    this.tipoDeDato.Add(columnTipo);
                    this.dominio.Add(dominio);

                    dataGridView.Columns[dataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
            }
            //MessageBox.Show(dataGridView.Columns[dataGridView.Columns.Count - 1].ValueType.ToString());

        }

        //editar nombre de columna
        private void dataGridView_ColumnHeaderMouseDoubleClick(object sender,
            DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string columnName = dataGridView.Columns[e.ColumnIndex].Name;
            string tipoDeDato = "";
            string dominio = "";
            if (this.dominio.Count > 0)
            {
                dominio = this.dominio[index];
            }
            if (this.tipoDeDato.Count > 0)
            {
                tipoDeDato = this.tipoDeDato[index];
            }

            using (editGridView frm = new editGridView(columnName, index,
                dominio, tipoDeDato, index == this.claseObjetivo))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //editar el nombre de la columna
                    dataGridView.Columns[frm.getColumnIndex()].HeaderText = frm.getHeaderName();
                    //editar expresion regular
                    this.dominio[index] = frm.getDominio();
                    //editar tipo de dato
                    this.tipoDeDato[index] = frm.getTipoDeDato();
                    //clase objetivo
                    if (frm.getObjetivo())
                    {
                        //la clase objetivo se señala con el index
                        //de ella
                        this.claseObjetivo = index;
                    }
                }
            }
            //edit.Show();
            //edit.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        //cuando se cierra el form de editar se llama a esta funcion para recibir los 
        //parametros que se agregaron en ese form
        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            //editGridView edit = (editGridView)sender;
            //dataGridView.Columns[edit.getColumnIndex()].HeaderText = edit.getHeaderName();
        }

        //eliminar una fila completa (eliminar instancia)
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 
                && dataGridView.SelectedRows.Count < 2 
                && e.KeyCode == Keys.Delete)
            {
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                {
                    if (oneCell.Selected && oneCell.RowIndex != 0)
                    {
                        dataGridView.Rows.RemoveAt(oneCell.RowIndex);
                    }
                }
                instancias_totales_lbl.Text = (dataGridView.Rows.Count - 1).ToString();
            }
        }


        //mostrar informacion de una columna al hacer click sobre su nombre
        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.indexColumna = e.ColumnIndex;
            string valueName = dataGridView.Columns[e.ColumnIndex].Name;
            int missingValues = 0;
            string tipoDeDato = this.tipoDeDato[e.ColumnIndex];
            string tipoDeDato2 = "";
            string data = string.Empty;
            //iteramos todas las filas de una columna para poder saber los valores
            //faltantes y mas informacion.
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {

                //revisamos que tipo de dato es la columna columna
                switch (tipoDeDato)
                {
                    case "System.Int32":
                        tipoDeDato2 = "numeric";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace((string)dataGridView[e.ColumnIndex, rows].Value)
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }
                            missingValues += 1;
                        }
                        break;
                    case "System.String":
                        tipoDeDato2 = "nominal";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || String.IsNullOrWhiteSpace((string)dataGridView[e.ColumnIndex, rows].Value)
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }
                            missingValues += 1;
                        }
                        break;
                    case "System.Float":
                        tipoDeDato2 = "numeric";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }
                            missingValues += 1;
                        }
                        break;
                    case "System.Double":
                        tipoDeDato2 = "numeric";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }
                            missingValues += 1;
                        }
                        break;
                    case "System.DateTime":
                        tipoDeDato2 = "DateTime";
                        //revisa si la celda tiene asignado un valor, si no lo tiene
                        //entonces se le asigna un ? y se sube el contador
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }
                            missingValues += 1;
                        }
                        break;
                    default:
                        tipoDeDato2 = tipoDeDato;
                        if (dataGridView[e.ColumnIndex, rows].Value == null
                     || dataGridView[e.ColumnIndex, rows].Value == DBNull.Value
                     || (string)dataGridView[e.ColumnIndex, rows].Value == "?")
                        {
                            
                            if (this.valorFaltante != "")
                            {
                                dataGridView[e.ColumnIndex, rows].Value = this.valorFaltante;
                            }
                            else
                            {
                                dataGridView[e.ColumnIndex, rows].Value = "?";
                            }

                            missingValues += 1;
                        }
                        break;
                }

            }
            //missingValues -= 1;
            this.tipoDeDato[this.indexColumna] = tipoDeDato2;
            nombre_lbl.Text = valueName;
            tipo_dato_lbl.Text = tipoDeDato2;
            valores_faltantes_lbl.Text = missingValues.ToString();
            this.valoresFaltantes = missingValues;
        }
        //llamar a form que muestra el grafico de boxplot
        private void box_plot_btn_Click(object sender, EventArgs e)
        {
            //creamos listas para los valores numericos enteros y flotantes
            //esto para poder pasarselos a la form de boxplot
            //List<List<int>> numericosEnteros = new List<List<int>>();
            List<List<double>> numericosFlotantes = new List<List<double>>();
            int totalInstancias = dataGridView.Rows.Count - 1;
            List<string> nombresColumnas = new List<string>();

            //itereamos las columnas que su tipo de dato sea entero u flotante
            //ya que con estas solamente se puede trabajar
            for (int column = 0; column < dataGridView.ColumnCount; column++)
            {
                //obtenemos el tipo de dato de la columna
                string tipoDeDato = this.tipoDeDato[column];
                //creamos una lista donde meteremos toda 1 columna
                List<double> list = new List<double>();
                //No tomamos en cuenta las columnas tipo string
                MessageBox.Show(tipoDeDato);
                if (tipoDeDato != "String" && tipoDeDato != "System.String" 
                    && tipoDeDato != "DateTime"
                    && tipoDeDato != "nominal"
                    && tipoDeDato != "bool" && tipoDeDato != "ordinal")
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
                            list.Add(double.Parse(dataGridView[column, rows].Value.ToString()));
                        }
                    }
                    //agregamos la lista que creamos anteriormente a la lista de listas
                    //que tenemos
                    numericosFlotantes.Add(list);
                    nombresColumnas.Add(dataGridView.Columns[column].Name);
                }
            }
            //abrimos la form de boxplot y le mandamos todas las columnas, sus nombres y el
            //total de instancias
            Form2 boxPlot = new Form2(totalInstancias, numericosFlotantes, nombresColumnas);
            boxPlot.Show();
            //boxPlot.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void falsos_predictores_btn_Click(object sender, EventArgs e)
        {
            //creamos listas para los valores categoricos
            //esto para poder pasarselos a la form de diagrama de barras

            List<List<string>> categoricosLista = new List<List<string>>();
            int totalInstancias = dataGridView.Rows.Count - 1;
            List<string> nombresColumnas = new List<string>();

            //itereamos las columnas que su tipo de dato sea entero u flotante
            //ya que con estas solamente se puede trabajar
            for (int column = 0; column < dataGridView.ColumnCount; column++)
            {
                //obtenemos el tipo de dato de la columna
                string tipoDeDato = this.tipoDeDato[column];
                //creamos una lista donde meteremos toda 1 columna
                List<string> list = new List<string>();
                //Solo tomamos en cuenta las columnas de string (categoricas)
                if (tipoDeDato == "String" || tipoDeDato == "System.String"
                    || tipoDeDato == "DateTime" || tipoDeDato == "nominal"
                    || tipoDeDato == "bool" || tipoDeDato == "ordinal")
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
                            list.Add(dataGridView[column, rows].Value.ToString());
                        }
                    }
                    //agregamos la lista que creamos anteriormente a la lista de listas
                    //que tenemos
                    categoricosLista.Add(list);
                    nombresColumnas.Add(dataGridView.Columns[column].Name);
                }
            }
            //abrimos la form de boxplot y le mandamos todas las columnas, sus nombres y el
            //total de instancias
            Frecuencia boxPlot = new Frecuencia(categoricosLista, nombresColumnas);
            boxPlot.Show();
        }

        //enviar a la form llenarValores los datos de una columna para darle la opcion
        //al usuario de elegir por que dato sustituir los valores faltantes
        //si sustituir por media o mediana
        private void valores_faltantes_btn_Click(object sender, EventArgs e)
        {
            if (this.valoresFaltantes > 0)
            {
                string opcion = ""; //opcion seleccionada por el usuario al cerrar form
                string tipoDeDato = this.tipoDeDato[indexColumna];
                //sacamos nombre de la columna 
                string nombreColumna = dataGridView.Columns[this.indexColumna].Name.ToString();
                //si es categorico se maneja diferente a si es numerico
                if (tipoDeDato == "String" || tipoDeDato == "System.String" || tipoDeDato == "DateTime" || tipoDeDato == "nominal"
                    || tipoDeDato == "bool" || tipoDeDato == "ordinal")
                {
                    //lista donde guardaremos toda la columna que selecciono el usuario
                    List<string> columna = obtenerListaDeColumnaCategoricos(this.indexColumna);
                    //el valor categorico es la string y el int es cuantas veces se repite
                    Dictionary<string, int> frecuencia = new Dictionary<string, int>();
                    foreach (string elemento in columna)
                    {
                        if (!frecuencia.ContainsKey(elemento))
                            frecuencia.Add(elemento, 1);
                        else
                            frecuencia[elemento]++;
                    }
                    string mayor = frecuencia.First().Key;
                    foreach (string value in frecuencia.Keys)
                    {
                        if (frecuencia[mayor] < frecuencia[value])
                        {
                            mayor = value;
                        }
                    }
                    MessageBox.Show("Los valores seran sustituidos con " + mayor);
                    sustituirValoresFaltantes(this.indexColumna, 0, mayor);
                }
                else
                {
                    //lista donde guardaremos toda la columna que selecciono el usuario
                    List<double> list = obtenerListaDeColumna(this.indexColumna);
                    //ordenamos la lista
                    list.Sort();
                    //sacamos la mediana y la moda
                    double mediana = Form2.medianaFunc(list);
                    double moda = Form2.modaFunc(list);
                    double media = list.Average();
                    //se abre el llenarValores form que esta diseñado para llenar valores de una tabla
                    //con la mediana o con la moda
                    using (LlenarValores frm = new LlenarValores(nombreColumna, media, mediana, moda))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            opcion = frm.getOpcion();
                        }
                    }

                    if (opcion == "media")
                    {
                        sustituirValoresFaltantes(this.indexColumna, media, "");

                    }
                    else if (opcion == "mediana")
                    {
                        sustituirValoresFaltantes(this.indexColumna, mediana, "");
                    }
                    else
                    {
                        MessageBox.Show("No se selecciono ninguna opcion");
                    }
                }
            }
            else
            {
                MessageBox.Show("La columna seleccionada no tiene valores faltantes");
            }
            
           

        }

        public List<double> obtenerListaDeColumna(int index)
        {
            List<double> list = new List<double>();
            //iteramos sobre toda la columna y agregamos los valores a la lista
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {
                //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                if (dataGridView[index, rows] != null
                    && dataGridView[index, rows].Value != DBNull.Value
                    && (string)dataGridView[index, rows].Value != ""
                    && (string)dataGridView[index, rows].Value != "?")  //value is not null
                {
                    //vamos agregando las celdas a la lista
                    list.Add(double.Parse(dataGridView[index, rows].Value.ToString()));
                }
            }
            return list;
        }
        public List<string> obtenerListaDeColumnaCategoricos(int index)
        {
            List<string> list = new List<string>();
            //iteramos sobre toda la columna y agregamos los valores a la lista
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {
                //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                if (dataGridView[index, rows] != null
                    && dataGridView[index, rows].Value != DBNull.Value
                    && (string)dataGridView[index, rows].Value != ""
                    && (string)dataGridView[index, rows].Value != "?")  //value is not null
                {
                    //vamos agregando las celdas a la lista
                    list.Add(dataGridView[index, rows].Value.ToString());
                }
            }
            return list;
        }

        //sustituye valores faltantes de una columna
        public void sustituirValoresFaltantes(int index, double valor, string mayorFrecuencia)
        {
            if (mayorFrecuencia != "" )
            {
                for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                {
                    //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                    if (dataGridView[index, rows] == null
                        || dataGridView[index, rows].Value == DBNull.Value
                        || (string)dataGridView[index, rows].Value == ""
                        || (string)dataGridView[index, rows].Value == "?")  //value is not null
                    {
                        dataGridView[index, rows].Value = mayorFrecuencia;
                        dataGridView[index, rows].Style.BackColor = Color.White;
                    }
                }
            }
            else
            {
                for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                {
                    //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                    if (dataGridView[index, rows] == null
                        || dataGridView[index, rows].Value == DBNull.Value
                        || (string)dataGridView[index, rows].Value == ""
                        || (string)dataGridView[index, rows].Value == "?")  //value is not null
                    {
                        dataGridView[index, rows].Value = valor.ToString();
                        dataGridView[index, rows].Style.BackColor = Color.White;
                    }
                }

            }
            //como se sustituyeron los valores faltantes entonces se lleva a 0
            this.valoresFaltantes = 0;
            valores_faltantes_lbl.Text = "0";
        }

        //sacar outliers
        private void outliers_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count > 0 && dataGridView.Rows.Count > 0 
                && this.tipoDeDato[this.indexColumna] != "String"
                && this.tipoDeDato[this.indexColumna] != "System.String"
                && this.tipoDeDato[this.indexColumna] != "nominal"
                && this.tipoDeDato[this.indexColumna] != "bool"
                && this.tipoDeDato[this.indexColumna] != "ordinal")
            {
                bool sustituir = false;
                bool sustituir_iqr5 = false;

                //obtenemos el tipo de dato de la columna
                string tipoDeDato = this.tipoDeDato[indexColumna];
                //sacamos nombre de la columna 
                string nombreColumna = dataGridView.Columns[this.indexColumna].Name.ToString();

                //lista donde guardaremos toda la columna que selecciono el usuario
                List<double> columna = obtenerListaDeColumna(this.indexColumna);

                double media, mediana, moda, valorRecomendado;
                valorRecomendado = 0;
                columna.Sort();
                media = columna.Average();
                mediana = Form2.medianaFunc(columna);
                moda = Form2.modaFunc(columna);

                if (media == mediana && mediana == moda)
                {
                    //"La distribucion no cuenta con sesgo \r\n por lo tanto se" +
                    //" recomienda usar la media";
                    valorRecomendado = media;
                }
                else if (media > mediana)
                {
                    // "La distribucion  está sesgada, por lo tanto \r\n" +
                    // "se recomienda usar la mediana";
                    valorRecomendado = mediana;

                }
                else if (media < mediana)
                {
                    // "La distribucion  está sesgada, por lo tanto \r\n" +
                    // "se recomienda usar la mediana";
                    valorRecomendado = mediana;

                }

                List<List<double>> listaDeListas = Form2.outliers(columna);
                using (Outliers frm = new Outliers(listaDeListas, nombreColumna,
                    valorRecomendado))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        sustituir = frm.getSustituir();
                        sustituir_iqr5 = frm.getSustituirIQr5();
                    }
                }
                //si se selecciono sustituir valores de iqr5 tambien en las opciones
                if (sustituir && sustituir_iqr5)
                {
                    //revisamos que las listas no esten vacias (tengan mas de 1 elemento)
                    if (listaDeListas.ElementAt(0).Count > 0 || listaDeListas.ElementAt(1).Count > 0)
                    {
                        //iteramos la columna en busca de valores que sean outliers
                        for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                        {
                            //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                            if (dataGridView[this.indexColumna, rows] != null
                                && dataGridView[this.indexColumna, rows].Value != DBNull.Value
                                && (string)dataGridView[this.indexColumna, rows].Value != ""
                                && (string)dataGridView[this.indexColumna, rows].Value != "?")
                            {
                                //si contiene el valor entonces se sustituye
                                if (listaDeListas.ElementAt(0).Contains(double.Parse(dataGridView[this.indexColumna, rows].Value.ToString()))
                                || listaDeListas.ElementAt(1).Contains(double.Parse(dataGridView[this.indexColumna, rows].Value.ToString())))  //value is not null
                                {
                                    dataGridView[this.indexColumna, rows].Value = valorRecomendado.ToString();
                                }
                            }
                        }
                    }

                }
                else if (sustituir)
                {
                    if (listaDeListas.ElementAt(1).Count > 0)
                    {
                        for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                        {
                            //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                            if (dataGridView[this.indexColumna, rows] != null
                                && dataGridView[this.indexColumna, rows].Value != DBNull.Value
                                && (string)dataGridView[this.indexColumna, rows].Value != ""
                                && (string)dataGridView[this.indexColumna, rows].Value != "?")
                            {
                                //si el elemento está en la lista de outliers se sustituye
                                if (listaDeListas.ElementAt(1).Contains(double.Parse(dataGridView[this.indexColumna, rows].Value.ToString())))  //value is not null
                                {
                                    dataGridView[this.indexColumna, rows].Value = valorRecomendado.ToString();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay outliers o el tipo de dato no puede calcularse");
            }
           

        }

        private void tipografia_btn_Click(object sender, EventArgs e)
        {
            int index = this.indexColumna;
            int indexExp = this.indexColumna;
            if((this.indexColumna > 0) && 
                (this.tipoDeDato[this.indexColumna] == "String"
                || this.tipoDeDato[this.indexColumna] == "System.String"
                || tipoDeDato[this.indexColumna] == "nominal"
                || this.tipoDeDato[this.indexColumna] == "bool"
                || this.tipoDeDato[this.indexColumna] == "ordinal"))
            {
                List<string> posibleErrorTipografico = new List<string>();
                Dictionary<string, int> frecuencia = new Dictionary<string, int>();
                List<string> datosBase = new List<string>();

                if (this.dominio.Count > -1 && this.dominio[indexExp] != "")
                {
                    string expresionRegular = this.dominio[indexExp];
                    for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    {
                        string input = dataGridView[indexExp,i].Value.ToString();
                        var match = Regex.Match(input, expresionRegular, RegexOptions.IgnoreCase);
                        if (!datosBase.Contains(input))
                        {
                            datosBase.Add(input);
                        }
                        if (!match.Success)
                        {
                            posibleErrorTipografico.Add(input);
                        }
                    }   
                }
                //sacar valores posiblemente mal escritos
                else
                {
                    List<string> columna = columnToListString(this.indexColumna);
                    //sacamos frecuencia
                    foreach (string elemento in columna)
                    {
                        if (!frecuencia.ContainsKey(elemento))
                            frecuencia.Add(elemento, 1);
                        else
                            frecuencia[elemento]++;
                    }
                    //value es el nombre y frecuencia[key] un entero de cuanto se repitio
                    foreach (string value in frecuencia.Keys)
                    {
                        datosBase.Add(value);
                        //posible palabra mal escrita
                        if (frecuencia[value] < 3)
                        {
                            posibleErrorTipografico.Add(value);
                        }
                    }
                }

               
                using (Tipografia frm = new Tipografia(posibleErrorTipografico, datosBase))
                {
                    var result = frm.ShowDialog();
                    
                    if (result == DialogResult.OK || result == DialogResult.Cancel)
                    {
                        //extraemos los datos que se van a querer modificar
                        List<List<string>> respuesta = frm.getRespuesta();
                        //si la lista esta vacia no se entra
                        if (respuesta.Count > 0)
                        {
                            //se iteran todos los elementos
                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                //se itera sobre las listas que hay que modificar
                                foreach (List<string> lista in respuesta)
                                {
                                    //si el elemento de la grid es igual a la palabra se sustituye por 
                                    //el valor recomendado
                                    if (lista[1] == (string)dataGridView[index, i].Value)
                                    {
                                        dataGridView[index, i].Value = lista[0];
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //funcion que borra una columna
        private void borrar_columna_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count > 0)
            {
                dataGridView.Columns.RemoveAt(this.indexColumna);
                this.tipoDeDato.RemoveAt(this.indexColumna);
            }
            
        }

        private void correlacion_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count > 0)
            {
                List<double> valores = new List<double>();
                List<string> nombreColumnas = new List<string>();
                List<string> tipoDato = new List<string>();
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    for (int x = i + 1; x < dataGridView.Columns.Count; x++)
                    {
                        //si los tipos de datos son iguales
                        if (this.tipoDeDato[i] == this.tipoDeDato[x] || 
                            (
                            (this.tipoDeDato[i] == "nominal" ||
                             this.tipoDeDato[i] == "ordinal" ||
                             this.tipoDeDato[i] == "bool"
                             )
                             && this.tipoDeDato[x] != "numeric"
                             && this.tipoDeDato[x] != "DateTime"
                             )
                             )
                        {
                            //se calcula pearson
                            if (this.tipoDeDato[i] == "numeric")
                            {
                                tipoDato.Add(this.tipoDeDato[i]);
                                string nombre1 = dataGridView.Columns[i].Name;
                                string nombre2 = dataGridView.Columns[x].Name;
                                double val = this.pearson(i,x);
                                valores.Add(val);

                                string nombreFinal = nombre1 + " - " + nombre2;
                                nombreColumnas.Add(nombreFinal);
                            }
                            //se calcula tschuprow
                            else
                            {
                                tipoDato.Add(this.tipoDeDato[i]);
                                string nombre1 = dataGridView.Columns[i].Name;
                                string nombre2 = dataGridView.Columns[x].Name;
                                double val = this.chiCuadrada(i, x);
                                valores.Add(val);

                                string nombreFinal = nombre1 + " - " + nombre2;
                                nombreColumnas.Add(nombreFinal);
                            }
                        }
                    }
                }

                using (Correlacion frm = new Correlacion(valores,nombreColumnas,
                    tipoDato))
                {
                    frm.ShowDialog();
                }
            }
        }
       //funcion para calcular el coeficiente de pearson
        public double pearson(int index1, int index2)
        {
            //se busca que se comparen numericos con numericos 
            if (tipoDeDato[index1] == tipoDeDato[index2] && tipoDeDato[index1] == "numeric")
            {
                List<double> columna1 = columnToListFloat(index1);
                List<double> columna2 = columnToListFloat(index2);

                //se saca el promedio de las dos listas
                double media1 = columna1.Average();
                double media2 = columna2.Average();

                //obtenemos la deviacion estandar
                double desviacionEstandar1 = Form2.desviacionEstandarFunc(columna1,media1);
                double desviacionEstandar2 = Form2.desviacionEstandarFunc(columna2, media2);

                //iteramos todas las instancias de los dos atributos, por cada lista
                // le restamos al dato la media y el resultado de cada lista se multiplica entre
                //el otro resultado de la otra lista
                double sumatoria = 0;
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    sumatoria += (columna1[i] - media1) * (columna2[i] - media2);
                }
                double abajo = desviacionEstandar1 * desviacionEstandar2 * (dataGridView.Rows.Count - 1);
                return sumatoria/abajo;
            }
            else
            {
                return -3;
            }
        }

        public double chiCuadrada(int index1, int index2)
        {
            //se trabaja con los valores categoricos
            if (this.tipoDeDato[index1] == this.tipoDeDato[index2]
                && (this.tipoDeDato[index1] == "String"
                || this.tipoDeDato[index1] == "nominal"
                || this.tipoDeDato[index1] == "System.String"))
            {
                List<string> datosBase1 = new List<string>();
                List<string> datosBase2 = new List<string>();
                List<List<int>> tablaContingencia = new List<List<int>>();
                //inicializar tablaDeContingencia
                //sacar datos base de columnas
                for (int row = 0; row < dataGridView.Rows.Count - 1; row++)
                {
                    //datos base
                    if (!datosBase1.Contains((string)dataGridView[index1, row].Value))
                    {
                        datosBase1.Add((string)dataGridView[index1, row].Value);
                    }
                    if (!datosBase2.Contains((string)dataGridView[index2, row].Value))
                    {
                        datosBase2.Add((string)dataGridView[index2, row].Value);
                    }
                }
                
                for (int i = 0; i < datosBase1.Count; i++)
                {
                    List<int> lista = new List<int>();
                    for (int x = 0; x < datosBase2.Count; x++)
                    {
                        lista.Add(0);
                    }
                    tablaContingencia.Add(lista);

                }
                //calcular tabla de contingencia
                for (int row = 0; row < dataGridView.Rows.Count - 1; row++)
                {
                    string dato1 = (string)dataGridView[index1, row].Value;
                    string dato2 = (string)dataGridView[index2, row].Value;

                    int indexOf1 = datosBase1.IndexOf(dato1);
                    int indexOf2 = datosBase2.IndexOf(dato2);
                    int i1 = indexOf1;
                    int i2 = indexOf2;

                    tablaContingencia[i1][i2]++;
                }

                //sacar total por fila y columna
                List<double> sumaFilas = new List<double>();
                List<double> sumaColumnas = new List<double>();

                //suma por filas
                for (int i = 0; i < datosBase1.Count; i++)
                {
                    sumaFilas.Add(tablaContingencia[i].Sum());
                }
                //suma por columnas      
                for (int i = 0; i < datosBase2.Count; i++)
                {
                    double temp = 0;
                    for (int x = 0; x < datosBase1.Count; x++)
                    {
                        temp += tablaContingencia[x][i];
                    }
                    sumaColumnas.Add(temp);
                }
                double totalValores = sumaFilas.Sum();

                //sacamos chi cuadrada de madrazo
  
                double chicuadrada = 0;
                for(int i = 0; i < datosBase1.Count - 1; i++)
                {
                    for (int x = 0; x < datosBase2.Count -1; x++)
                    {
                        double frecuenciaEsperada = ((sumaFilas[i] * sumaColumnas[x])
                                                    / totalValores);
                        double valor = tablaContingencia[i][x];
                        double valorCuadrado = (valor - frecuenciaEsperada) * (valor - frecuenciaEsperada);
                        chicuadrada += 
                           (valorCuadrado
                            / frecuenciaEsperada);
                    }
                }
                double tschuprow = Math.Sqrt(
                    chicuadrada/
                    (totalValores * 
                    Math.Sqrt( (datosBase1.Count - 1) * (datosBase2.Count -1)) )   );
                return tschuprow;
            }
            return -1;
        }

        /// <summary>
        /// hacer una lista con la informacion en una columna
        /// </summary>
        /// <param int="index"> index de columna que vamos a hacer lista</param>
        /// <returns></returns>
        public List<double> columnToListFloat(int index)
        {
            List<double> columna = new List<double>();
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {
                //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                if (dataGridView[index, rows] != null
                    && dataGridView[index, rows].Value != DBNull.Value
                    && (string)dataGridView[index, rows].Value != ""
                    && (string)dataGridView[index, rows].Value != "?")
                {
                    //agregamos el valor a la lista 
                    columna.Add(double.Parse(dataGridView[index, rows].Value.ToString()));
                }
            }
            return columna;
        }

        public List<string> columnToListString(int index)
        {
            List<string> columna = new List<string>();
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {
                //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                if (dataGridView[index, rows] != null
                    && dataGridView[index, rows].Value != DBNull.Value
                    && (string)dataGridView[index, rows].Value != ""
                    && (string)dataGridView[index, rows].Value != "?")
                {
                    //agregamos el valor a la lista 
                    columna.Add(dataGridView[index, rows].Value.ToString());
                }
            }
            return columna;
        }

        private void buscar_remplazar_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count > 0)
            {
                //index columna
                int column = this.indexColumna;
                //nombre columna
                string columnName = dataGridView.Columns[column].Name;
                //posicion del form
                int x, y;
                bool repetir = true;
                string buscar, remplazar;
                buscar = remplazar = "";
                x = y = 0;
                while (repetir)
                {   
                    
                    using (Buscar_remplazar frm = new Buscar_remplazar(buscar,remplazar,
                        columnName,x,y))
                    {
                        var showDialog = frm.ShowDialog();
                        if (showDialog == DialogResult.OK)
                        {
                            List<string> resultado = frm.getResult();
                            //que tenga datos la lista
                            if (resultado.Count > 0)
                            {
                                //remplazar 1
                                if (resultado[2] == "uno")
                                {
                                    buscar = resultado[0];
                                    remplazar = resultado[1];

                                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                                    {
                                        if ((string)dataGridView[column, i].Value == resultado[0])
                                        {
                                            dataGridView[column, i].Value = resultado[1];
                                            break;
                                        }
                                    }
                                }
                                //remplazar todos
                                else if(resultado[2] == "todo")
                                {
                                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                                    {
                                        if ((string)dataGridView[column, i].Value == resultado[0])
                                        {
                                            dataGridView[column, i].Value = resultado[1];
                                        }
                                    }
                                }
                                //buscar solamente
                                else if(resultado[2] == "buscar")
                                {
                                    for (int row = 0; row < dataGridView.Rows.Count; row++)
                                    {
                                        if ((string)dataGridView[column, row].Value == resultado[0])
                                        { 
                                            dataGridView.ClearSelection();
                                            dataGridView[column, row].Selected = true;
                                            dataGridView.FirstDisplayedScrollingRowIndex = row;
                                            dataGridView.Focus();
                                            break;
                                        }
                                    }
                                }
                                buscar = resultado[0];
                                remplazar = resultado[1];
                            }
                            
                            x = frm.getX();
                            y = frm.getY();
                        }
                        else if (showDialog == DialogResult.Cancel)
                        {
                            repetir = false;
                        }
                    }
                }   
            }
        }

        private void muestreo_btn_Click(object sender, EventArgs e)
        {
            int instanciasTotales = Int32.Parse(instancias_totales_lbl.Text);
            //llamamos form
            using (Muestreo frm = new Muestreo(instanciasTotales))
            {
                //si todo salio bien entonces entramos a guardar el archivo
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //guardamos el archivo
                    using (SaveFileDialog ofd = new SaveFileDialog() { Filter = "CSV|*.csv", ValidateNames = true })
                    {
                        //si el nombre del archivo se escribió
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            //hacer dt
                            DataTable dataT =  new DataTable();
                            int opc = frm.getOpc();
                            int instancias = frm.getInstancias();

                            //extraer la informacion dependiendo de la opcion seleccionada
                            //con remplazo
                            if (opc == 0)
                            {

                                //agregar headers a datatable
                                for (int i = 0; i < dataGridView.Columns.Count; i++)
                                {
                                    dataT.Columns.Add(dataGridView.Columns[i].HeaderText);
                                }

                                //crear una row para nuestro datatable

                                //agregar el numero de instancias que puso el usuario
                                //a nuestro dt

                                Random rnd = new Random();

                                for (int i = 0; i < instancias; i++)
                                {
                                    
                                    int randomIndex = rnd.Next(instanciasTotales);
                                    DataRow dr = null;
                                    dr = dataT.NewRow(); // crear una nueva row
                                    dr = ((DataRowView)(dataGridView.Rows[randomIndex].DataBoundItem)).Row;
                                    dataT.Rows.Add(dr.ItemArray);
                                    //dataT.ImportRow(dr);
                                    dr = null;
                                }
                            }
                            //sin remplazo
                            else if (opc == 1)
                            {
                                //agregar headers a datatable
                                for (int i = 0; i < dataGridView.Columns.Count; i++)
                                {
                                    dataT.Columns.Add(dataGridView.Columns[i].HeaderText);
                                }
                                //crear una row para nuestro datatable

                                //agregar el numero de instancias que puso el usuario
                                //a nuestro dt
                                Random rnd = new Random();

                                List<int> usados = new List<int>();
                                //es pesado para la compu
                                while(instancias > dataT.Rows.Count){
                                    DataRow dr = null;
                                    int randomIndex = rnd.Next(instanciasTotales);
                                    if (!usados.Contains(randomIndex))
                                    {
                                        dr = dataT.NewRow(); // crear una nueva row
                                        dr = ((DataRowView)(dataGridView.Rows[randomIndex].DataBoundItem)).Row;
                                        dataT.Rows.Add(dr.ItemArray);
                                        //dataT.ImportRow(dr);

                                        usados.Add(randomIndex);
                                    }
                                }
                            
                            }

                            //guardar archivo
                            StringBuilder sb = new StringBuilder();

                            IEnumerable<string> columnNames = dataT.Columns.Cast<DataColumn>().
                                                              Select(column => column.ColumnName);
                            sb.AppendLine(string.Join(",", columnNames));

                            foreach (DataRow row in dataT.Rows)
                            {
                                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                                sb.AppendLine(string.Join(",", fields));
                            }

                            File.WriteAllText(ofd.FileName, sb.ToString());
                        }

                    }
                }
            }    
        }

        private void normalizacion_btn_Click(object sender, EventArgs e)
        {
            if (this.indexColumna > -1 && this.tipoDeDato[this.indexColumna] == "numeric")
            {
                int opc = 0;
                int index = this.indexColumna;
                List<double> lista = columnToListFloat(index);
                double min = lista.Min();
                double max = lista.Max();
                double media = Form2.medianaFunc(lista);
                double desviacionE = Form2.desviacionEstandarFunc(lista, media);
                double desviacionM = this.desviacionMedia(lista, media);
                if (index > -1)
                {
                    using (Normalizar frm = new Normalizar())
                    {

                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            opc = frm.getOpc();
                            switch (opc)
                            {
                                case 0:
                                    minMax(min, max, frm.getMin(), frm.getMax(), index);
                                    break;
                                case 1:
                                    zScoreDesviacionEstandar(media, desviacionE, index);
                                    break;
                                case 2:
                                    zScoreDesviacionMedia(media, desviacionM, index);
                                    break;
                            }
                            MessageBox.Show("Valores Remplazados Correctamente");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un atributo(Columna)");
                }
            }
                
        }
        public void minMax(double min, double max,
            double nuevoMin, double nuevoMax, int index)
        {
            //iteramos todas las filas
            for (int i = 0; i < dataGridView.Rows.Count- 1; i++)
            {
                if (dataGridView[index, i] != null
                    && dataGridView[index, i].Value != DBNull.Value
                    && (string)dataGridView[index, i].Value != ""
                    && (string)dataGridView[index, i].Value != "?")
                {
                    //hacemos dato de grid double
                    double value = Double.Parse((string)dataGridView[index, i].Value);
                    //calculamos min max
                    double minmax = ((value - min) /
                        (max - min)) * (nuevoMax - nuevoMin) + nuevoMin;
                    //lo agregamos al datagridview
                    dataGridView[index, i].Value = minmax.ToString();
                }
            }
        }
        public void zScoreDesviacionEstandar(double media,
            double desviacionE, int index)
        {
            //se tiene que calcular media y 
            //iteramos todas las filas
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (dataGridView[index, i] != null
                    && dataGridView[index, i].Value != DBNull.Value
                    && (string)dataGridView[index, i].Value != ""
                    && (string)dataGridView[index, i].Value != "?")
                {
                    //transformamos el dato de nuestro grid a double
                    double value = Double.Parse((string)dataGridView[index, i].Value);
                    //calculamos zscore
                    double zscore = (value - media) /
                        desviacionE;
                    //lo agregamos al datagridview
                    dataGridView[index, i].Value = zscore.ToString();
                }
            }
        }
        public void zScoreDesviacionMedia(double media,
            double desviacionMedia, int index)
        {
            //iteramos todas las filas
            for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
            {
                if (dataGridView[index, i] != null
                    && dataGridView[index, i].Value != DBNull.Value
                    && (string)dataGridView[index, i].Value != ""
                    && (string)dataGridView[index, i].Value != "?")
                {
                    //transformamos el dato de nuestro grid a double
                    double value = Double.Parse((string)dataGridView[index, i].Value);
                    //calculamos zscore
                    double zscore = (value - media) /
                        desviacionMedia;
                    //lo agregamos al datagridview
                    dataGridView[index, i].Value = zscore.ToString();
                }
            }
        }

        public double desviacionMedia(List<double> lista, double media)
        {
            double acumulador = 0;
            foreach (double value in lista)
            {
                acumulador += Math.Abs(value - media);
            }
            double num = lista.Count;
            double div = (1 / num);
            double resultado = div * acumulador;
            return resultado;
        }

        private void falsos_predictores_btn_Click_1(object sender, EventArgs e)
        {
            int indexClaseObjetivo = this.claseObjetivo;
            if (indexClaseObjetivo > -1)
            {
                //revisar tipo de dato
                if (this.tipoDeDato[indexClaseObjetivo] == "numeric")
                {
                    List<int> columnasNumeric = new List<int>();
                    //obtener columnas numericas
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (this.tipoDeDato[i] == "numeric")
                        {
                            columnasNumeric.Add(i);
                        }
                    }
                    double pearson;
                    List<double> posiblesCorrelacion = new List<double>();
                    List<string> nombreColumnas = new List<string>();
                    foreach (var index in columnasNumeric)
                    {

                        pearson = this.pearson(indexClaseObjetivo, index);
                        posiblesCorrelacion.Add(pearson);
                        nombreColumnas.Add(dataGridView.Columns[index].Name);

                    }
                    using (FalsosPredictores frm = new FalsosPredictores(
                        posiblesCorrelacion, nombreColumnas, true))
                    {
                        frm.ShowDialog();

                    }
                }
                else if (this.tipoDeDato[indexClaseObjetivo] == "nominal"
                    || this.tipoDeDato[indexClaseObjetivo] == "System.String"
                    || this.tipoDeDato[indexClaseObjetivo] == "bool"
                    || this.tipoDeDato[indexClaseObjetivo] == "ordinal")
                {
                    List<int> columnasNominal = new List<int>();
                    //obtener columnas numericas
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (this.tipoDeDato[i] == "nominal"
                    || this.tipoDeDato[i] == "System.String"
                    || this.tipoDeDato[i] == "bool"
                    || this.tipoDeDato[i] == "ordinal")
                        {
                            columnasNominal.Add(i);
                        }
                    }
                    double tschuprow;
                    List<double> posiblesCorrelacion = new List<double>();
                    List<string> nombreColumnas = new List<string>();
                    bool numeric = false;

                    foreach (var index in columnasNominal)
                    {
                        tschuprow = this.chiCuadrada(indexClaseObjetivo, index);
                        posiblesCorrelacion.Add(tschuprow);
                        nombreColumnas.Add(dataGridView.Columns[index].Name);
                    }
                    using (FalsosPredictores frm = new FalsosPredictores(
                        posiblesCorrelacion, nombreColumnas, numeric))
                    {
                        frm.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("Porfavor selecciona la clase objetivo");
            }
        }
    }
}
