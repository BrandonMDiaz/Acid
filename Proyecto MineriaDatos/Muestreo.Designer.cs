namespace Proyecto_MineriaDatos
{
    partial class Muestreo
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
            this.remplazo_btn = new System.Windows.Forms.Button();
            this.sin_remplazo_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tamanio_txt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.num_instancias_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // remplazo_btn
            // 
            this.remplazo_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.remplazo_btn.Location = new System.Drawing.Point(317, 182);
            this.remplazo_btn.Name = "remplazo_btn";
            this.remplazo_btn.Size = new System.Drawing.Size(96, 28);
            this.remplazo_btn.TabIndex = 0;
            this.remplazo_btn.Text = "Remplazo";
            this.remplazo_btn.UseVisualStyleBackColor = true;
            this.remplazo_btn.Click += new System.EventHandler(this.remplazo_btn_Click);
            // 
            // sin_remplazo_btn
            // 
            this.sin_remplazo_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sin_remplazo_btn.Location = new System.Drawing.Point(317, 233);
            this.sin_remplazo_btn.Name = "sin_remplazo_btn";
            this.sin_remplazo_btn.Size = new System.Drawing.Size(96, 28);
            this.sin_remplazo_btn.TabIndex = 1;
            this.sin_remplazo_btn.Text = "Sin remplazo";
            this.sin_remplazo_btn.UseVisualStyleBackColor = true;
            this.sin_remplazo_btn.Click += new System.EventHandler(this.sin_remplazo_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Muestreo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Muestreo simple con remplazo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Muestreo simple sin remplazo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tamaño de muestra:";
            // 
            // tamanio_txt
            // 
            this.tamanio_txt.Location = new System.Drawing.Point(313, 131);
            this.tamanio_txt.Name = "tamanio_txt";
            this.tamanio_txt.Size = new System.Drawing.Size(100, 20);
            this.tamanio_txt.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "Total de instancias:";
            // 
            // num_instancias_lbl
            // 
            this.num_instancias_lbl.AutoSize = true;
            this.num_instancias_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_instancias_lbl.Location = new System.Drawing.Point(353, 81);
            this.num_instancias_lbl.Name = "num_instancias_lbl";
            this.num_instancias_lbl.Size = new System.Drawing.Size(20, 22);
            this.num_instancias_lbl.TabIndex = 8;
            this.num_instancias_lbl.Text = "0";
            // 
            // Muestreo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 283);
            this.Controls.Add(this.num_instancias_lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tamanio_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sin_remplazo_btn);
            this.Controls.Add(this.remplazo_btn);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Muestreo";
            this.Text = "Muestreo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button remplazo_btn;
        private System.Windows.Forms.Button sin_remplazo_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tamanio_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label num_instancias_lbl;
    }
}