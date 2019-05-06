namespace Proyecto_MineriaDatos
{
    partial class Correlacion
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
            this.atributos_lb = new System.Windows.Forms.ListBox();
            this.correlacion_lbl = new System.Windows.Forms.Label();
            this.nombre_correlacion_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Atributos fuertemente correlacionados";
            // 
            // atributos_lb
            // 
            this.atributos_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atributos_lb.FormattingEnabled = true;
            this.atributos_lb.ItemHeight = 16;
            this.atributos_lb.Location = new System.Drawing.Point(68, 59);
            this.atributos_lb.Name = "atributos_lb";
            this.atributos_lb.Size = new System.Drawing.Size(245, 100);
            this.atributos_lb.TabIndex = 1;
            this.atributos_lb.SelectedIndexChanged += new System.EventHandler(this.atributos_lb_SelectedIndexChanged);
            // 
            // correlacion_lbl
            // 
            this.correlacion_lbl.AutoSize = true;
            this.correlacion_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correlacion_lbl.Location = new System.Drawing.Point(172, 214);
            this.correlacion_lbl.Name = "correlacion_lbl";
            this.correlacion_lbl.Size = new System.Drawing.Size(51, 20);
            this.correlacion_lbl.TabIndex = 2;
            this.correlacion_lbl.Text = "label2";
            // 
            // nombre_correlacion_lbl
            // 
            this.nombre_correlacion_lbl.AutoSize = true;
            this.nombre_correlacion_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_correlacion_lbl.Location = new System.Drawing.Point(64, 214);
            this.nombre_correlacion_lbl.Name = "nombre_correlacion_lbl";
            this.nombre_correlacion_lbl.Size = new System.Drawing.Size(51, 20);
            this.nombre_correlacion_lbl.TabIndex = 3;
            this.nombre_correlacion_lbl.Text = "label2";
            // 
            // Correlacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 279);
            this.Controls.Add(this.nombre_correlacion_lbl);
            this.Controls.Add(this.correlacion_lbl);
            this.Controls.Add(this.atributos_lb);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Correlacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Correlacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox atributos_lb;
        private System.Windows.Forms.Label correlacion_lbl;
        private System.Windows.Forms.Label nombre_correlacion_lbl;
    }
}