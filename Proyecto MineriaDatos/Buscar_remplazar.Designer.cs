namespace Proyecto_MineriaDatos
{
    partial class Buscar_remplazar
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
            this.buscar_tb = new System.Windows.Forms.TextBox();
            this.remplazar_tb = new System.Windows.Forms.TextBox();
            this.remplazar_uno_btn = new System.Windows.Forms.Button();
            this.remplazar_todo_btn = new System.Windows.Forms.Button();
            this.buscar_btn = new System.Windows.Forms.Button();
            this.atributo_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Remplazar";
            // 
            // buscar_tb
            // 
            this.buscar_tb.Location = new System.Drawing.Point(183, 55);
            this.buscar_tb.Name = "buscar_tb";
            this.buscar_tb.Size = new System.Drawing.Size(183, 20);
            this.buscar_tb.TabIndex = 2;
            // 
            // remplazar_tb
            // 
            this.remplazar_tb.Location = new System.Drawing.Point(183, 105);
            this.remplazar_tb.Name = "remplazar_tb";
            this.remplazar_tb.Size = new System.Drawing.Size(183, 20);
            this.remplazar_tb.TabIndex = 3;
            // 
            // remplazar_uno_btn
            // 
            this.remplazar_uno_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remplazar_uno_btn.Location = new System.Drawing.Point(12, 156);
            this.remplazar_uno_btn.Name = "remplazar_uno_btn";
            this.remplazar_uno_btn.Size = new System.Drawing.Size(121, 32);
            this.remplazar_uno_btn.TabIndex = 4;
            this.remplazar_uno_btn.Text = "Remplazar uno";
            this.remplazar_uno_btn.UseVisualStyleBackColor = true;
            this.remplazar_uno_btn.Click += new System.EventHandler(this.remplazar_uno_btn_Click);
            // 
            // remplazar_todo_btn
            // 
            this.remplazar_todo_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remplazar_todo_btn.Location = new System.Drawing.Point(139, 156);
            this.remplazar_todo_btn.Name = "remplazar_todo_btn";
            this.remplazar_todo_btn.Size = new System.Drawing.Size(122, 32);
            this.remplazar_todo_btn.TabIndex = 5;
            this.remplazar_todo_btn.Text = "Remplazar todo";
            this.remplazar_todo_btn.UseVisualStyleBackColor = true;
            this.remplazar_todo_btn.Click += new System.EventHandler(this.remplazar_todo_btn_Click);
            // 
            // buscar_btn
            // 
            this.buscar_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar_btn.Location = new System.Drawing.Point(267, 156);
            this.buscar_btn.Name = "buscar_btn";
            this.buscar_btn.Size = new System.Drawing.Size(122, 32);
            this.buscar_btn.TabIndex = 6;
            this.buscar_btn.Text = "Buscar";
            this.buscar_btn.UseVisualStyleBackColor = true;
            this.buscar_btn.Click += new System.EventHandler(this.buscar_btn_Click);
            // 
            // atributo_lbl
            // 
            this.atributo_lbl.AutoSize = true;
            this.atributo_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atributo_lbl.Location = new System.Drawing.Point(165, 9);
            this.atributo_lbl.Name = "atributo_lbl";
            this.atributo_lbl.Size = new System.Drawing.Size(65, 20);
            this.atributo_lbl.TabIndex = 7;
            this.atributo_lbl.Text = "Atributo";
            // 
            // Buscar_remplazar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 209);
            this.Controls.Add(this.atributo_lbl);
            this.Controls.Add(this.buscar_btn);
            this.Controls.Add(this.remplazar_todo_btn);
            this.Controls.Add(this.remplazar_uno_btn);
            this.Controls.Add(this.remplazar_tb);
            this.Controls.Add(this.buscar_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Buscar_remplazar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar_remplazar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox buscar_tb;
        private System.Windows.Forms.TextBox remplazar_tb;
        private System.Windows.Forms.Button remplazar_uno_btn;
        private System.Windows.Forms.Button remplazar_todo_btn;
        private System.Windows.Forms.Button buscar_btn;
        private System.Windows.Forms.Label atributo_lbl;
    }
}