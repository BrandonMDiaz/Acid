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
            this.label9 = new System.Windows.Forms.Label();
            this.q3_lbl = new System.Windows.Forms.Label();
            this.q1_lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.clases_lb = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(265, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.BoxPlot;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(663, 560);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Media";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mediana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Moda";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Desviacion Estandar";
            // 
            // media_lbl
            // 
            this.media_lbl.AutoSize = true;
            this.media_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.media_lbl.Location = new System.Drawing.Point(182, 216);
            this.media_lbl.Name = "media_lbl";
            this.media_lbl.Size = new System.Drawing.Size(46, 17);
            this.media_lbl.TabIndex = 5;
            this.media_lbl.Text = "label5";
            // 
            // mediana_lbl
            // 
            this.mediana_lbl.AutoSize = true;
            this.mediana_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediana_lbl.Location = new System.Drawing.Point(182, 272);
            this.mediana_lbl.Name = "mediana_lbl";
            this.mediana_lbl.Size = new System.Drawing.Size(46, 17);
            this.mediana_lbl.TabIndex = 6;
            this.mediana_lbl.Text = "label6";
            // 
            // moda_lbl
            // 
            this.moda_lbl.AutoSize = true;
            this.moda_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moda_lbl.Location = new System.Drawing.Point(182, 322);
            this.moda_lbl.Name = "moda_lbl";
            this.moda_lbl.Size = new System.Drawing.Size(46, 17);
            this.moda_lbl.TabIndex = 7;
            this.moda_lbl.Text = "label7";
            // 
            // desviacionE_lbl
            // 
            this.desviacionE_lbl.AutoSize = true;
            this.desviacionE_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desviacionE_lbl.Location = new System.Drawing.Point(182, 369);
            this.desviacionE_lbl.Name = "desviacionE_lbl";
            this.desviacionE_lbl.Size = new System.Drawing.Size(46, 17);
            this.desviacionE_lbl.TabIndex = 8;
            this.desviacionE_lbl.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(135, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Selecciona la clase";
            // 
            // q3_lbl
            // 
            this.q3_lbl.AutoSize = true;
            this.q3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.q3_lbl.Location = new System.Drawing.Point(182, 475);
            this.q3_lbl.Name = "q3_lbl";
            this.q3_lbl.Size = new System.Drawing.Size(46, 17);
            this.q3_lbl.TabIndex = 16;
            this.q3_lbl.Text = "label8";
            // 
            // q1_lbl
            // 
            this.q1_lbl.AutoSize = true;
            this.q1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.q1_lbl.Location = new System.Drawing.Point(182, 423);
            this.q1_lbl.Name = "q1_lbl";
            this.q1_lbl.Size = new System.Drawing.Size(46, 17);
            this.q1_lbl.TabIndex = 14;
            this.q1_lbl.Text = "label6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Q3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 406);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 423);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Q1";
            // 
            // clases_lb
            // 
            this.clases_lb.FormattingEnabled = true;
            this.clases_lb.Location = new System.Drawing.Point(18, 61);
            this.clases_lb.Name = "clases_lb";
            this.clases_lb.Size = new System.Drawing.Size(210, 134);
            this.clases_lb.TabIndex = 17;
            this.clases_lb.SelectedIndexChanged += new System.EventHandler(this.clases_lb_SelectedIndexChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 570);
            this.Controls.Add(this.clases_lb);
            this.Controls.Add(this.q3_lbl);
            this.Controls.Add(this.q1_lbl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label q3_lbl;
        private System.Windows.Forms.Label q1_lbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox clases_lb;
    }
}