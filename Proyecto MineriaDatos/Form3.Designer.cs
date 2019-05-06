namespace Proyecto_MineriaDatos
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nombre_txt = new System.Windows.Forms.TextBox();
            this.tipo_cb = new System.Windows.Forms.ComboBox();
            this.ok_btn = new System.Windows.Forms.Button();
            this.dominio_tb = new System.Windows.Forms.TextBox();
            this.dominio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de dato";
            // 
            // nombre_txt
            // 
            this.nombre_txt.Location = new System.Drawing.Point(130, 33);
            this.nombre_txt.Name = "nombre_txt";
            this.nombre_txt.Size = new System.Drawing.Size(186, 20);
            this.nombre_txt.TabIndex = 2;
            // 
            // tipo_cb
            // 
            this.tipo_cb.FormattingEnabled = true;
            this.tipo_cb.Items.AddRange(new object[] {
            "numeric",
            "nominal",
            "ordinal",
            "bool",
            "DateTime"});
            this.tipo_cb.Location = new System.Drawing.Point(130, 120);
            this.tipo_cb.Name = "tipo_cb";
            this.tipo_cb.Size = new System.Drawing.Size(186, 21);
            this.tipo_cb.TabIndex = 3;
            this.tipo_cb.SelectedIndexChanged += new System.EventHandler(this.tipo_cb_SelectedIndexChanged);
            // 
            // ok_btn
            // 
            this.ok_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_btn.Location = new System.Drawing.Point(121, 160);
            this.ok_btn.Name = "ok_btn";
            this.ok_btn.Size = new System.Drawing.Size(97, 23);
            this.ok_btn.TabIndex = 4;
            this.ok_btn.Text = "Ok";
            this.ok_btn.UseVisualStyleBackColor = true;
            this.ok_btn.Click += new System.EventHandler(this.ok_btn_Click);
            // 
            // dominio_tb
            // 
            this.dominio_tb.Location = new System.Drawing.Point(130, 74);
            this.dominio_tb.Name = "dominio_tb";
            this.dominio_tb.Size = new System.Drawing.Size(186, 20);
            this.dominio_tb.TabIndex = 6;
            // 
            // dominio
            // 
            this.dominio.AutoSize = true;
            this.dominio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dominio.Location = new System.Drawing.Point(13, 75);
            this.dominio.Name = "dominio";
            this.dominio.Size = new System.Drawing.Size(59, 17);
            this.dominio.TabIndex = 5;
            this.dominio.Text = "Dominio";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 195);
            this.Controls.Add(this.dominio_tb);
            this.Controls.Add(this.dominio);
            this.Controls.Add(this.ok_btn);
            this.Controls.Add(this.tipo_cb);
            this.Controls.Add(this.nombre_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Agregar columna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombre_txt;
        private System.Windows.Forms.ComboBox tipo_cb;
        private System.Windows.Forms.Button ok_btn;
        private System.Windows.Forms.TextBox dominio_tb;
        private System.Windows.Forms.Label dominio;
    }
}