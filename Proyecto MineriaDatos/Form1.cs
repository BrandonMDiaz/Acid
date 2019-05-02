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

            //informacion general
            //descripcion de la base de datos
            //base de datos
            using (var reader = new StreamReader(Path.GetDirectoryName(fileName)))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                //parte en la que se encuentra el archivo
                // 0 = informacion general
                // 1 = descripcion de la base de datos
                // 2 = base de datos
                int partes = 0;
                string linea = "";
                string letra = "";
                string palabra = "";
                //leemos el primer caracter
                letra = reader.Read().ToString();
                //si el primer caracter es el de la parte uno entonces se especifica
                if (letra == "%" && reader.Peek().ToString() == "%" || letra == "%")
                {
                    partes = 0;
                }
                //si el primer caracter es el de la parte dos se especifica
                else if (letra == "@")
                {
                    partes = 1;
                }
                //si el primer caracter no es ninguno de los anteriores se especifica
                else
                {
                    partes = 2;
                }
                //para poder entrar aqui tenemos que estar en etapa 0 o 1
                if(partes < 2) {
                    while (!reader.EndOfStream)
                    {
                        //leemos letra por letra
                        letra = reader.Read().ToString();
                        if (letra != "")
                        {
                            palabra += letra;
                        }
                        else
                        {
                            palabra = "";
                        }

                        if (letra == "@")
                        {
                            partes = 2;
                        }
                        else if (palabra == "@data")
                        {

                        }
                        linea += letra;

                        if (partes == 0)
                        {
                            
                        }
                        else if (partes == 1)
                        {

                        }
                        else if (partes == 2)
                        {

                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
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

            //se abre el form3 que esta diseñado para pedir estos dos valores
            using (Form3 frm = new Form3())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    columnNombre = frm.getNombre();
                    columnTipo = frm.getTipo();
                    dataGridView.Columns.Add(columnNombre, columnNombre);
                    dataGridView.Columns[dataGridView.Columns.Count - 1].ValueType = System.Type.GetType("System." + columnTipo);
                    this.tipoDeDato.Add("System." + columnTipo);
                    dataGridView.Columns[dataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

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
            int totalInstancias = dataGridView.Rows.Count - 1;
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
                    sustituirValoresFaltantes(this.indexColumna, 0, mayor);
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

        //sustituye valores faltantes de una columna
        public void sustituirValoresFaltantes(int index, float valor, string mayorFrecuencia)
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
            if (dataGridView.Columns.Count > 0 && dataGridView.Rows.Count > 0)
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
            else
            {
                MessageBox.Show("No hay datos");
            }
           

        }

        private void tipografia_btn_Click(object sender, EventArgs e)
        {
            if(this.indexColumna > 0 && this.tipoDeDato[this.indexColumna] == "System.String")
            {
                int index = this.indexColumna;
                List<string> columna = columnToListString(this.indexColumna);
                Dictionary<string, int> frecuencia = new Dictionary<string, int>();
                foreach (string elemento in columna)
                {
                    if (!frecuencia.ContainsKey(elemento))
                        frecuencia.Add(elemento, 1);
                    else
                        frecuencia[elemento]++;
                }

                List<string> posibleErrorTipografico = new List<string>();
                List<string> datosBase = new List<string>();

                //value es el nombre y frecuencia[key] un entero de cuanto se repitio
                foreach (string value in frecuencia.Keys)
                {
                    datosBase.Add(value);
                    //posible palabra mal escrita
                    if (frecuencia[value] < 3) {
                        posibleErrorTipografico.Add(value);
                    }
                }
                //falta buscar valores fuera del rango
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

        private void borrar_columna_btn_Click(object sender, EventArgs e)
        {
            dataGridView.Columns.RemoveAt(this.indexColumna);
            this.tipoDeDato.RemoveAt(this.indexColumna);
        }

        private void correlacion_btn_Click(object sender, EventArgs e)
        {

        }
       
        public void pearson(int index1, int index2)
        {
            //se busca que se comparen numericos con numericos 
            if (tipoDeDato[index1] == tipoDeDato[index2] 
                || (tipoDeDato[index1] == "float" && tipoDeDato[index2] == "int")
                || (tipoDeDato[index1] == "int" && tipoDeDato[index2] == "float") )
            {
                List<float> columna1 = columnToListFloat(index1);
                List<float> columna2 = columnToListFloat(index2);
                
                //se saca el promedio de las dos listas
                float media1 = columna1.Average();
                float media2 = columna2.Average();

                //obtenemos la deviacion estandar
                float desviacionEstandar1 = Form2.desviacionEstandarFunc(columna1,media1);
                float desviacionEstandar2 = Form2.desviacionEstandarFunc(columna2, media2);

                //iteramos todas las instancias de los dos atributos, por cada lista
                // le restamos al dato la media y el resultado de cada lista se multiplica entre
                //el otro resultado de la otra lista
                float sumatoria = 0;
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    sumatoria += (columna1[i] - media1) * (columna2[i] - media2);
                }
                float abajo = desviacionEstandar1 * desviacionEstandar2 * (dataGridView.Rows.Count - 1);
         
            }
        }

        public void chiCuadrada(int index1,int index2)
        {
            //se trabaja con los valores categoricos
            if (this.tipoDeDato[index1] == this.tipoDeDato[index2]
                && this.tipoDeDato[index1] == "string") 
            {
                //sacar frecuencia de 1 columna
                //List<string> columna = listaStrings[index];
                Dictionary<string, int> frecuencia = new Dictionary<string, int>();
                //foreach (string elemento in columna)
                //{
                    //if (!frecuencia.ContainsKey(elemento))
                        //frecuencia.Add(elemento, 1);
                    //else
                        //frecuencia[elemento]++;
                //}
            }
        }

        /// <summary>
        /// hacer una lista con la informacion en una columna
        /// </summary>
        /// <param int="index"> index de columna que vamos a hacer lista</param>
        /// <returns></returns>
        public List<float> columnToListFloat(int index)
        {
            List<float> columna = new List<float>();
            for (int rows = 0; rows < dataGridView.Rows.Count - 1; rows++)
            {
                //si alguna celda esta vacia o es igual a "?" no la tomamos en cuenta
                if (dataGridView[index, rows] != null
                    && dataGridView[index, rows].Value != DBNull.Value
                    && (string)dataGridView[index, rows].Value != ""
                    && (string)dataGridView[index, rows].Value != "?")
                {
                    //agregamos el valor a la lista 
                    columna.Add(float.Parse(dataGridView[this.indexColumna, rows].Value.ToString()));
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
                    columna.Add(dataGridView[this.indexColumna, rows].Value.ToString());
                }
            }
            return columna;
        }

        private void buscar_remplazar_btn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count > 0)
            {
                bool repetir = true;
                string buscar, remplazar;
                while (repetir)
                {   
                    
                    using (Buscar_remplazar frm = new Buscar_remplazar(buscar,remplazar))
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
                                    
                                }
                                //remplazar todos
                                else if(resultado[2] == "todo")
                                {

                                }
                                //buscar solamente
                                else if(resultado[2] == "buscar")
                                {

                                }
                            }
                        }
                        else if (showDialog == DialogResult.Cancel)
                        {
                            repetir = false;
                        }
                    }
                }   
            }
        }
    }
}
