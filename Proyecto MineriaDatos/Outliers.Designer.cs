namespace Proyecto_MineriaDatos
{
    partial class Outliers
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
            this.iqr15_lbox = new System.Windows.Forms.ListBox();
            this.iqr3_lbox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.atributo_lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sustituyendo_lbl = new System.Windows.Forms.Label();
            this.sustituir_btn = new System.Windows.Forms.Button();
            this.sustituir_cb = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // iqr15_lbox
            // 
            this.iqr15_lbox.FormattingEnabled = true;
            this.iqr15_lbox.Location = new System.Drawing.Point(30, 88);
            this.iqr15_lbox.Name = "iqr15_lbox";
            this.iqr15_lbox.Size = new System.Drawing.Size(168, 95);
            this.iqr15_lbox.TabIndex = 0;
            this.iqr15_lbox.SelectedIndexChanged += new System.EventHandler(this.iqr15_lbox_SelectedIndexChanged);
            // 
            // iqr3_lbox
            // 
            this.iqr3_lbox.FormattingEnabled = true;
            this.iqr3_lbox.Location = new System.Drawing.Point(294, 88);
            this.iqr3_lbox.Name = "iqr3_lbox";
            this.iqr3_lbox.Size = new System.Drawing.Size(168, 95);
            this.iqr3_lbox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "1.5 IQR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "3 IQR";
            // 
            // atributo_lbl
            // 
            this.atributo_lbl.AutoSize = true;
            this.atributo_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atributo_lbl.Location = new System.Drawing.Point(203, 9);
            this.atributo_lbl.Name = "atributo_lbl";
            this.atributo_lbl.Size = new System.Drawing.Size(71, 20);
            this.atributo_lbl.TabIndex = 4;
            this.atributo_lbl.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sustituir por:";
            // 
            // sustituyendo_lbl
            // 
            this.sustituyendo_lbl.AutoSize = true;
            this.sustituyendo_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sustituyendo_lbl.Location = new System.Drawing.Point(151, 246);
            this.sustituyendo_lbl.Name = "sustituyendo_lbl";
            this.sustituyendo_lbl.Size = new System.Drawing.Size(47, 20);
            this.sustituyendo_lbl.TabIndex = 6;
            this.sustituyendo_lbl.Text = "valor";
            // 
            // sustituir_btn
            // 
            this.sustituir_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sustituir_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sustituir_btn.Location = new System.Drawing.Point(194, 295);
            this.sustituir_btn.Name = "sustituir_btn";
            this.sustituir_btn.Size = new System.Drawing.Size(100, 38);
            this.sustituir_btn.TabIndex = 7;
            this.sustituir_btn.Text = "Sustituir";
            this.sustituir_btn.UseVisualStyleBackColor = true;
            this.sustituir_btn.Click += new System.EventHandler(this.sustituir_btn_Click);
            // 
            // sustituir_cb
            // 
            this.sustituir_cb.AutoSize = true;
            this.sustituir_cb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sustituir_cb.Location = new System.Drawing.Point(30, 209);
            this.sustituir_cb.Name = "sustituir_cb";
            this.sustituir_cb.Size = new System.Drawing.Size(184, 21);
            this.sustituir_cb.TabIndex = 9;
            this.sustituir_cb.Text = "Sustituir 1.5 IQR tambien";
            this.sustituir_cb.UseVisualStyleBackColor = true;
            this.sustituir_cb.CheckedChanged += new System.EventHandler(this.sustituir_cb_CheckedChanged);
            // 
            // Outliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 360);
            this.Controls.Add(this.sustituir_cb);
            this.Controls.Add(this.sustituir_btn);
            this.Controls.Add(this.sustituyendo_lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.atributo_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iqr3_lbox);
            this.Controls.Add(this.iqr15_lbox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Outliers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Outliers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox iqr15_lbox;
        private System.Windows.Forms.ListBox iqr3_lbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label atributo_lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sustituyendo_lbl;
        private System.Windows.Forms.Button sustituir_btn;
        private System.Windows.Forms.CheckBox sustituir_cb;
    }
}