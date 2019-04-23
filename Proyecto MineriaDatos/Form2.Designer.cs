namespace Proyecto_MineriaDatos
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.media_lbl = new System.Windows.Forms.Label();
            this.mediana_lbl = new System.Windows.Forms.Label();
            this.moda_lbl = new System.Windows.Forms.Label();
            this.desviacionE_lbl = new System.Windows.Forms.Label();
            this.clases_cb = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(249, 14);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(547, 436);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Media";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mediana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Moda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Desviacion Estandar";
            // 
            // media_lbl
            // 
            this.media_lbl.AutoSize = true;
            this.media_lbl.Location = new System.Drawing.Point(146, 156);
            this.media_lbl.Name = "media_lbl";
            this.media_lbl.Size = new System.Drawing.Size(35, 13);
            this.media_lbl.TabIndex = 5;
            this.media_lbl.Text = "label5";
            // 
            // mediana_lbl
            // 
            this.mediana_lbl.AutoSize = true;
            this.mediana_lbl.Location = new System.Drawing.Point(146, 197);
            this.mediana_lbl.Name = "mediana_lbl";
            this.mediana_lbl.Size = new System.Drawing.Size(35, 13);
            this.mediana_lbl.TabIndex = 6;
            this.mediana_lbl.Text = "label6";
            // 
            // moda_lbl
            // 
            this.moda_lbl.AutoSize = true;
            this.moda_lbl.Location = new System.Drawing.Point(146, 238);
            this.moda_lbl.Name = "moda_lbl";
            this.moda_lbl.Size = new System.Drawing.Size(35, 13);
            this.moda_lbl.TabIndex = 7;
            this.moda_lbl.Text = "label7";
            // 
            // desviacionE_lbl
            // 
            this.desviacionE_lbl.AutoSize = true;
            this.desviacionE_lbl.Location = new System.Drawing.Point(146, 275);
            this.desviacionE_lbl.Name = "desviacionE_lbl";
            this.desviacionE_lbl.Size = new System.Drawing.Size(35, 13);
            this.desviacionE_lbl.TabIndex = 8;
            this.desviacionE_lbl.Text = "label8";
            this.desviacionE_lbl.Click += new System.EventHandler(this.label8_Click);
            // 
            // clases_cb
            // 
            this.clases_cb.FormattingEnabled = true;
            this.clases_cb.Location = new System.Drawing.Point(15, 51);
            this.clases_cb.Name = "clases_cb";
            this.clases_cb.Size = new System.Drawing.Size(121, 21);
            this.clases_cb.TabIndex = 9;
            this.clases_cb.SelectedIndexChanged += new System.EventHandler(this.clases_cb_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Selecciona la clase";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 463);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.clases_cb);
            this.Controls.Add(this.desviacionE_lbl);
            this.Controls.Add(this.moda_lbl);
            this.Controls.Add(this.mediana_lbl);
            this.Controls.Add(this.media_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.Name = "Form2";
            this.Text = "Box plot";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label media_lbl;
        private System.Windows.Forms.Label mediana_lbl;
        private System.Windows.Forms.Label moda_lbl;
        private System.Windows.Forms.Label desviacionE_lbl;
        private System.Windows.Forms.ComboBox clases_cb;
        private System.Windows.Forms.Label label9;
    }
}