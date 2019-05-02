namespace Proyecto_MineriaDatos
{
    partial class Tipografia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.palabras_con_errores_lbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.corregir_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.valor_lbl = new System.Windows.Forms.Label();
            this.otras_opciones_lbox = new System.Windows.Forms.ListBox();
            this.otra_opcion_cb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // palabras_con_errores_lbox
            // 
            this.palabras_con_errores_lbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palabras_con_errores_lbox.FormattingEnabled = true;
            this.palabras_con_errores_lbox.ItemHeight = 24;
            this.palabras_con_errores_lbox.Location = new System.Drawing.Point(69, 63);
            this.palabras_con_errores_lbox.Name = "palabras_con_errores_lbox";
            this.palabras_con_errores_lbox.Size = new System.Drawing.Size(412, 124);
            this.palabras_con_errores_lbox.TabIndex = 1;
            this.palabras_con_errores_lbox.SelectedIndexChanged += new System.EventHandler(this.palabras_con_errores_lbox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Palabras con errores";
            // 
            // corregir_btn
            // 
            this.corregir_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.corregir_btn.Location = new System.Drawing.Point(162, 314);
            this.corregir_btn.Name = "corregir_btn";
            this.corregir_btn.Size = new System.Drawing.Size(214, 68);
            this.corregir_btn.TabIndex = 3;
            this.corregir_btn.Text = "Corregir seleccionado";
            this.corregir_btn.UseVisualStyleBackColor = true;
            this.corregir_btn.Click += new System.EventHandler(this.corregir_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Corregir seleccionado por:";
            // 
            // valor_lbl
            // 
            this.valor_lbl.AutoSize = true;
            this.valor_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valor_lbl.Location = new System.Drawing.Point(276, 218);
            this.valor_lbl.Name = "valor_lbl";
            this.valor_lbl.Size = new System.Drawing.Size(0, 26);
            this.valor_lbl.TabIndex = 7;
            // 
            // otras_opciones_lbox
            // 
            this.otras_opciones_lbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otras_opciones_lbox.FormattingEnabled = true;
            this.otras_opciones_lbox.ItemHeight = 24;
            this.otras_opciones_lbox.Location = new System.Drawing.Point(102, 302);
            this.otras_opciones_lbox.Name = "otras_opciones_lbox";
            this.otras_opciones_lbox.Size = new System.Drawing.Size(344, 124);
            this.otras_opciones_lbox.TabIndex = 9;
            this.otras_opciones_lbox.Visible = false;
            // 
            // otra_opcion_cb
            // 
            this.otra_opcion_cb.AutoSize = true;
            this.otra_opcion_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.otra_opcion_cb.Location = new System.Drawing.Point(34, 261);
            this.otra_opcion_cb.Name = "otra_opcion_cb";
            this.otra_opcion_cb.Size = new System.Drawing.Size(194, 24);
            this.otra_opcion_cb.TabIndex = 8;
            this.otra_opcion_cb.Text = "Seleccionar otra opcion";
            this.otra_opcion_cb.UseVisualStyleBackColor = true;
            this.otra_opcion_cb.CheckedChanged += new System.EventHandler(this.otra_opcion_cb_CheckedChanged);
            // 
            // Tipografia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 404);
            this.Controls.Add(this.otras_opciones_lbox);
            this.Controls.Add(this.otra_opcion_cb);
            this.Controls.Add(this.valor_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.corregir_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.palabras_con_errores_lbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tipografia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tipografia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox palabras_con_errores_lbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button corregir_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label valor_lbl;
        private System.Windows.Forms.ListBox otras_opciones_lbox;
        private System.Windows.Forms.CheckBox otra_opcion_cb;
    }
}