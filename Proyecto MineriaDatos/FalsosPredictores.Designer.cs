namespace Proyecto_MineriaDatos
{
    partial class FalsosPredictores
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
            this.valores_lb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nombre_lbl = new System.Windows.Forms.Label();
            this.coeficiente_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // valores_lb
            // 
            this.valores_lb.FormattingEnabled = true;
            this.valores_lb.Location = new System.Drawing.Point(116, 58);
            this.valores_lb.Name = "valores_lb";
            this.valores_lb.Size = new System.Drawing.Size(180, 108);
            this.valores_lb.TabIndex = 0;
            this.valores_lb.SelectedIndexChanged += new System.EventHandler(this.valores_lb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valores con una correlacion mayor a  0.5";
            // 
            // nombre_lbl
            // 
            this.nombre_lbl.AutoSize = true;
            this.nombre_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombre_lbl.Location = new System.Drawing.Point(99, 200);
            this.nombre_lbl.Name = "nombre_lbl";
            this.nombre_lbl.Size = new System.Drawing.Size(90, 20);
            this.nombre_lbl.TabIndex = 2;
            this.nombre_lbl.Text = "Tschuprow:";
            // 
            // coeficiente_lbl
            // 
            this.coeficiente_lbl.AutoSize = true;
            this.coeficiente_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coeficiente_lbl.Location = new System.Drawing.Point(224, 200);
            this.coeficiente_lbl.Name = "coeficiente_lbl";
            this.coeficiente_lbl.Size = new System.Drawing.Size(0, 20);
            this.coeficiente_lbl.TabIndex = 3;
            // 
            // FalsosPredictores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 273);
            this.Controls.Add(this.coeficiente_lbl);
            this.Controls.Add(this.nombre_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valores_lb);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FalsosPredictores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FalsosPredictores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox valores_lb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nombre_lbl;
        private System.Windows.Forms.Label coeficiente_lbl;
    }
}