namespace Proyecto_MineriaDatos
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCargar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_guardar_como = new System.Windows.Forms.Button();
            this.salir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.falsos_predictores_btn = new System.Windows.Forms.Button();
            this.box_plot_btn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.atributos_data = new System.Windows.Forms.Panel();
            this.nombre_lbl = new System.Windows.Forms.Label();
            this.tipo_dato_lbl = new System.Windows.Forms.Label();
            this.proporcion_lbl = new System.Windows.Forms.Label();
            this.valores_faltantes_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.atributos_data.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.White;
            this.btnCargar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCargar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.btnCargar.FlatAppearance.BorderSize = 3;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.Image = ((System.Drawing.Image)(resources.GetObject("btnCargar.Image")));
            this.btnCargar.Location = new System.Drawing.Point(6, 6);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCargar.Size = new System.Drawing.Size(169, 77);
            this.btnCargar.TabIndex = 1;
            this.btnCargar.Text = "Cargar Archivo";
            this.btnCargar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.tabControl2);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 125);
            this.panel1.TabIndex = 5;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl2.Location = new System.Drawing.Point(5, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1085, 122);
            this.tabControl2.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))));
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.btn_guardar_como);
            this.tabPage1.Controls.Add(this.salir);
            this.tabPage1.Controls.Add(this.btnCargar);
            this.tabPage1.Controls.Add(this.btnGuardar);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1077, 89);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Archivo";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.button3.FlatAppearance.BorderSize = 3;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(529, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(169, 77);
            this.button3.TabIndex = 6;
            this.button3.Text = "Editar";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btn_guardar_como
            // 
            this.btn_guardar_como.BackColor = System.Drawing.Color.White;
            this.btn_guardar_como.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.btn_guardar_como.FlatAppearance.BorderSize = 3;
            this.btn_guardar_como.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_guardar_como.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_guardar_como.Image = ((System.Drawing.Image)(resources.GetObject("btn_guardar_como.Image")));
            this.btn_guardar_como.Location = new System.Drawing.Point(354, 5);
            this.btn_guardar_como.Name = "btn_guardar_como";
            this.btn_guardar_como.Size = new System.Drawing.Size(169, 77);
            this.btn_guardar_como.TabIndex = 5;
            this.btn_guardar_como.Text = "Guardar como";
            this.btn_guardar_como.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_guardar_como.UseVisualStyleBackColor = false;
            this.btn_guardar_como.Click += new System.EventHandler(this.btn_guardar_como_Click);
            // 
            // salir
            // 
            this.salir.BackColor = System.Drawing.Color.White;
            this.salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.salir.FlatAppearance.BorderSize = 3;
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir.Location = new System.Drawing.Point(885, 6);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(169, 77);
            this.salir.TabIndex = 4;
            this.salir.Text = "Salir";
            this.salir.UseVisualStyleBackColor = false;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.btnGuardar.FlatAppearance.BorderSize = 3;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(181, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(167, 77);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Archivo";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))));
            this.tabPage2.Controls.Add(this.falsos_predictores_btn);
            this.tabPage2.Controls.Add(this.box_plot_btn);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1077, 89);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Analisis estadistico";
            // 
            // falsos_predictores_btn
            // 
            this.falsos_predictores_btn.BackColor = System.Drawing.Color.White;
            this.falsos_predictores_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.falsos_predictores_btn.FlatAppearance.BorderSize = 3;
            this.falsos_predictores_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.falsos_predictores_btn.Image = ((System.Drawing.Image)(resources.GetObject("falsos_predictores_btn.Image")));
            this.falsos_predictores_btn.Location = new System.Drawing.Point(181, 3);
            this.falsos_predictores_btn.Name = "falsos_predictores_btn";
            this.falsos_predictores_btn.Size = new System.Drawing.Size(167, 77);
            this.falsos_predictores_btn.TabIndex = 3;
            this.falsos_predictores_btn.Text = "Frecuencia";
            this.falsos_predictores_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.falsos_predictores_btn.UseVisualStyleBackColor = false;
            // 
            // box_plot_btn
            // 
            this.box_plot_btn.BackColor = System.Drawing.Color.White;
            this.box_plot_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.box_plot_btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(83)))), ((int)(((byte)(85)))));
            this.box_plot_btn.FlatAppearance.BorderSize = 3;
            this.box_plot_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.box_plot_btn.Image = ((System.Drawing.Image)(resources.GetObject("box_plot_btn.Image")));
            this.box_plot_btn.Location = new System.Drawing.Point(6, 3);
            this.box_plot_btn.Name = "box_plot_btn";
            this.box_plot_btn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.box_plot_btn.Size = new System.Drawing.Size(169, 77);
            this.box_plot_btn.TabIndex = 2;
            this.box_plot_btn.Text = "Box plot";
            this.box_plot_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.box_plot_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.box_plot_btn.UseVisualStyleBackColor = false;
            this.box_plot_btn.Click += new System.EventHandler(this.box_plot_btn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(240)))), ((int)(((byte)(246)))));
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1077, 89);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Limpieza de datos";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(206, 178);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(884, 382);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
            this.dataGridView.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseDoubleClick);
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(57)))));
            this.label1.Font = new System.Drawing.Font("Ink Free", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 49);
            this.label1.TabIndex = 8;
            this.label1.Text = "Acid";
            // 
            // atributos_data
            // 
            this.atributos_data.BackColor = System.Drawing.Color.White;
            this.atributos_data.Controls.Add(this.nombre_lbl);
            this.atributos_data.Controls.Add(this.tipo_dato_lbl);
            this.atributos_data.Controls.Add(this.proporcion_lbl);
            this.atributos_data.Controls.Add(this.valores_faltantes_lbl);
            this.atributos_data.Controls.Add(this.button1);
            this.atributos_data.Controls.Add(this.label5);
            this.atributos_data.Controls.Add(this.label4);
            this.atributos_data.Controls.Add(this.label3);
            this.atributos_data.Controls.Add(this.label2);
            this.atributos_data.Location = new System.Drawing.Point(0, 178);
            this.atributos_data.Name = "atributos_data";
            this.atributos_data.Size = new System.Drawing.Size(206, 382);
            this.atributos_data.TabIndex = 9;
            // 
            // nombre_lbl
            // 
            this.nombre_lbl.AutoSize = true;
            this.nombre_lbl.Location = new System.Drawing.Point(123, 38);
            this.nombre_lbl.Name = "nombre_lbl";
            this.nombre_lbl.Size = new System.Drawing.Size(35, 13);
            this.nombre_lbl.TabIndex = 11;
            this.nombre_lbl.Text = "label9";
            // 
            // tipo_dato_lbl
            // 
            this.tipo_dato_lbl.AutoSize = true;
            this.tipo_dato_lbl.Location = new System.Drawing.Point(123, 72);
            this.tipo_dato_lbl.Name = "tipo_dato_lbl";
            this.tipo_dato_lbl.Size = new System.Drawing.Size(35, 13);
            this.tipo_dato_lbl.TabIndex = 10;
            this.tipo_dato_lbl.Text = "label8";
            // 
            // proporcion_lbl
            // 
            this.proporcion_lbl.AutoSize = true;
            this.proporcion_lbl.Location = new System.Drawing.Point(123, 141);
            this.proporcion_lbl.Name = "proporcion_lbl";
            this.proporcion_lbl.Size = new System.Drawing.Size(35, 13);
            this.proporcion_lbl.TabIndex = 9;
            this.proporcion_lbl.Text = "label7";
            // 
            // valores_faltantes_lbl
            // 
            this.valores_faltantes_lbl.AutoSize = true;
            this.valores_faltantes_lbl.Location = new System.Drawing.Point(123, 109);
            this.valores_faltantes_lbl.Name = "valores_faltantes_lbl";
            this.valores_faltantes_lbl.Size = new System.Drawing.Size(35, 13);
            this.valores_faltantes_lbl.TabIndex = 8;
            this.valores_faltantes_lbl.Text = "label6";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Agregar columna";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Proporción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Valores faltantes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo de dato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(0, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1094, 51);
            this.panel3.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(34)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(1092, 562);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.atributos_data);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proyecto Mineria de Datos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.atributos_data.ResumeLayout(false);
            this.atributos_data.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button btn_guardar_como;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel atributos_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button falsos_predictores_btn;
        private System.Windows.Forms.Button box_plot_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label nombre_lbl;
        private System.Windows.Forms.Label tipo_dato_lbl;
        private System.Windows.Forms.Label proporcion_lbl;
        private System.Windows.Forms.Label valores_faltantes_lbl;
    }
}

