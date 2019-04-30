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

        //guarda el dominio por columna
        Dictionary<string, string> dominio =
          new Dictionary<string, string>();

        //guarda el tipo de dato por columna
        List<string> tipoDeDato = new List<string>();

        //guarda la columna seleccionada actualmente
        int indexColumna = 0;
        int valoresFaltantes = 0;

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

        /// <summary>
        /// funcion para guardar el archivo que se esta utilizando, sobreescribe
        /// la informacion que tienes actualmente sobre la que contiene el archivo al
        /// principio
        /// </summary>
        /// <param name="fileName">el nombre del archivo que vamos a sobreescribir</param>
        public void guardarArchivo(string fileName)
        {
            //revisa si tiene datos el datagridview, si no tiene se 
            if (dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No hay informacion que guardar");
            }
            else
            {
                DataTable dt = (DataTable)(dataGridView.DataSource); //extraer la informacion del data grid view
                StringBuilder sb = new StringBuilder();
                //al guardar como hay error


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
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {
                    if (ofd.ShowDialog() == DialogResult.OK) {
                        //cargar datos al datagridview
                        dataGridView.DataSource = LeerCSV(ofd.FileName);
                        //desactivar el ordenar
                        foreach (DataGridViewColumn column in dataGridView.Columns)
                        {
                            column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                        for (int column = 0; column < dataGridView.ColumnCount; column++)
                        {
                            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
                            {
                                //si alguna celda esta vacia o es igual a "?" la marcamos
                                if (dataGridView[this.indexColumna, rows] == null
                                    && dataGridView[this.indexColumna, rows].Value == DBNull.Value
                                    && (string)dataGridView[this.indexColumna, rows].Value == ""
                                    && (string)dataGridView[this.indexColumna, rows].Value == "?")
                                {
                                    dataGridView.Rows[rows].Cells[column].Style.BackColor = Color.Red;
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

            //se abre el form3 que esta diseñado para pedir estos dos valores
            using (Form3 frm = new Form3())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    columnNombre = frm.getNombre();
                    columnTipo = frm.getTipo();
                    dataGridView.Columns.Add(columnNombre, columnNombre);
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
            if (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows.Count < 2 && e.KeyCode == Keys.Delete)
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
                    case "System.Double":
                        tipoDeDato2 = "Double";
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
            this.valoresFaltantes = missingValues;
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
                            list.Add(float.Parse(dataGridView[column, rows].Value.ToString()));
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
            int totalInstancias = dataGridView.Rows.Count;
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
                if (tipoDeDato == "System.String")
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
                if (tipoDeDato == "System.String")
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
                    sustituirValores(this.indexColumna, 0, mayor);
                }
                else
                {
                    //lista donde guardaremos toda la columna que selecciono el usuario
                    List<float> list = obtenerListaDeColumna(this.indexColumna);
                    //ordenamos la lista
                    list.Sort();
                    //sacamos la mediana y la moda
                    float mediana = Form2.medianaFunc(list);
                    float moda = Form2.modaFunc(list);
                    float media = list.Average();
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
                        sustituirValores(this.indexColumna, media, "");

                    }
                    else if (opcion == "mediana")
                    {
                        sustituirValores(this.indexColumna, mediana, "");
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

        public List<float> obtenerListaDeColumna(int index)
        {
            List<float> list = new List<float>();
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
                    list.Add(float.Parse(dataGridView[index, rows].Value.ToString()));
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

        public void sustituirValores(int index, float valor, string mayorFrecuencia)
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
            bool sustituir = false;
            bool sustituir_iqr5 = false;
            
            //obtenemos el tipo de dato de la columna
            string tipoDeDato = this.tipoDeDato[indexColumna];
            //sacamos nombre de la columna 
            string nombreColumna = dataGridView.Columns[this.indexColumna].Name.ToString();

            //lista donde guardaremos toda la columna que selecciono el usuario
            List<float> columna = obtenerListaDeColumna(this.indexColumna);

            float media, mediana, moda, valorRecomendado;
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

            List<List<float>> listaDeListas = Form2.outliers(columna);
            using (Outliers frm = new Outliers( listaDeListas, nombreColumna,
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
                            if (listaDeListas.ElementAt(0).Contains(float.Parse(dataGridView[this.indexColumna, rows].Value.ToString()))
                            || listaDeListas.ElementAt(1).Contains(float.Parse(dataGridView[this.indexColumna, rows].Value.ToString())))  //value is not null
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
                            if (listaDeListas.ElementAt(1).Contains(float.Parse(dataGridView[this.indexColumna, rows].Value.ToString())))  //value is not null
                            {
                                dataGridView[this.indexColumna, rows].Value = valorRecomendado.ToString();
                            }
                        }
                    }
                }
            }

        }

        private void tipografia_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
