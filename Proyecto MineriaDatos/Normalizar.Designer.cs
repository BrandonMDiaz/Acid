namespace Proyecto_MineriaDatos
{
    partial class Normalizar
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
            this.label3 = new System.Windows.Forms.Label();
            this.min_tb = new System.Windows.Forms.TextBox();
            this.max_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.z_score_de_btn = new System.Windows.Forms.Button();
            this.z_score_dm_btn = new System.Windows.Forms.Button();
            this.min_max_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min - Max";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valores entre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "y";
            // 
            // min_tb
            // 
            this.min_tb.Location = new System.Drawing.Point(120, 75);
            this.min_tb.MaxLength = 100;
            this.min_tb.Name = "min_tb";
            this.min_tb.Size = new System.Drawing.Size(63, 20);
            this.min_tb.TabIndex = 3;
            // 
            // max_tb
            // 
            this.max_tb.Location = new System.Drawing.Point(227, 75);
            this.max_tb.Name = "max_tb";
            this.max_tb.Size = new System.Drawing.Size(64, 20);
            this.max_tb.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Z-Score (Desviacion estandar)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Z-Score (Desviacion media)";
            // 
            // z_score_de_btn
            // 
            this.z_score_de_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.z_score_de_btn.Location = new System.Drawing.Point(339, 125);
            this.z_score_de_btn.Name = "z_score_de_btn";
            this.z_score_de_btn.Size = new System.Drawing.Size(110, 41);
            this.z_score_de_btn.TabIndex = 7;
            this.z_score_de_btn.Text = "Z-Score desviacion estandar";
            this.z_score_de_btn.UseVisualStyleBackColor = true;
            this.z_score_de_btn.Click += new System.EventHandler(this.z_score_de_btn_Click);
            // 
            // z_score_dm_btn
            // 
            this.z_score_dm_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.z_score_dm_btn.Location = new System.Drawing.Point(339, 199);
            this.z_score_dm_btn.Name = "z_score_dm_btn";
            this.z_score_dm_btn.Size = new System.Drawing.Size(110, 41);
            this.z_score_dm_btn.TabIndex = 8;
            this.z_score_dm_btn.Text = "Z-Score desviacion media";
            this.z_score_dm_btn.UseVisualStyleBackColor = true;
            this.z_score_dm_btn.Click += new System.EventHandler(this.z_score_dm_btn_Click);
            // 
            // min_max_btn
            // 
            this.min_max_btn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.min_max_btn.Location = new System.Drawing.Point(339, 64);
            this.min_max_btn.Name = "min_max_btn";
            this.min_max_btn.Size = new System.Drawing.Size(110, 41);
            this.min_max_btn.TabIndex = 9;
            this.min_max_btn.Text = "Min-Max";
            this.min_max_btn.UseVisualStyleBackColor = true;
            this.min_max_btn.Click += new System.EventHandler(this.min_max_btn_Click);
            // 
            // Normalizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 260);
            this.Controls.Add(this.min_max_btn);
            this.Controls.Add(this.z_score_dm_btn);
            this.Controls.Add(this.z_score_de_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.max_tb);
            this.Controls.Add(this.min_tb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Normalizar";
            this.Text = "Normalizar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox min_tb;
        private System.Windows.Forms.TextBox max_tb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button z_score_de_btn;
        private System.Windows.Forms.Button z_score_dm_btn;
        private System.Windows.Forms.Button min_max_btn;
    }
}