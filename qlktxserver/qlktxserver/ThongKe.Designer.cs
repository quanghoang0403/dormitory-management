namespace qlktxserver
{
    partial class ThongKe
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.csDien = new System.Windows.Forms.TabPage();
            this.ch_csDien = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.csNuoc = new System.Windows.Forms.TabPage();
            this.ch_csNuoc = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tong = new System.Windows.Forms.TabPage();
            this.ch_tong = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.csDien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_csDien)).BeginInit();
            this.csNuoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_csNuoc)).BeginInit();
            this.tong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_tong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(415, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 31);
            this.label1.TabIndex = 64;
            this.label1.Text = "THỐNG KÊ CHỈ SỐ";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 49);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1118, 257);
            this.flowLayoutPanel1.TabIndex = 67;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.csDien);
            this.tabControl1.Controls.Add(this.csNuoc);
            this.tabControl1.Controls.Add(this.tong);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(22, 345);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 324);
            this.tabControl1.TabIndex = 68;
            // 
            // csDien
            // 
            this.csDien.Controls.Add(this.ch_csDien);
            this.csDien.Location = new System.Drawing.Point(4, 22);
            this.csDien.Name = "csDien";
            this.csDien.Padding = new System.Windows.Forms.Padding(3);
            this.csDien.Size = new System.Drawing.Size(1058, 298);
            this.csDien.TabIndex = 0;
            this.csDien.Text = "Chỉ số điện";
            // 
            // ch_csDien
            // 
            chartArea7.Name = "ChartArea1";
            this.ch_csDien.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.ch_csDien.Legends.Add(legend7);
            this.ch_csDien.Location = new System.Drawing.Point(125, 17);
            this.ch_csDien.Name = "ch_csDien";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Chỉ số điện";
            this.ch_csDien.Series.Add(series7);
            this.ch_csDien.Size = new System.Drawing.Size(779, 275);
            this.ch_csDien.TabIndex = 0;
            this.ch_csDien.Text = "chart1";
            // 
            // csNuoc
            // 
            this.csNuoc.Controls.Add(this.ch_csNuoc);
            this.csNuoc.Location = new System.Drawing.Point(4, 22);
            this.csNuoc.Name = "csNuoc";
            this.csNuoc.Padding = new System.Windows.Forms.Padding(3);
            this.csNuoc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.csNuoc.Size = new System.Drawing.Size(1058, 298);
            this.csNuoc.TabIndex = 1;
            this.csNuoc.Text = "Chỉ số nước";
            // 
            // ch_csNuoc
            // 
            chartArea8.Name = "ChartArea1";
            this.ch_csNuoc.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.ch_csNuoc.Legends.Add(legend8);
            this.ch_csNuoc.Location = new System.Drawing.Point(140, 12);
            this.ch_csNuoc.Name = "ch_csNuoc";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Chỉ số nước";
            this.ch_csNuoc.Series.Add(series8);
            this.ch_csNuoc.Size = new System.Drawing.Size(779, 275);
            this.ch_csNuoc.TabIndex = 1;
            this.ch_csNuoc.Text = "chart1";
            // 
            // tong
            // 
            this.tong.Controls.Add(this.ch_tong);
            this.tong.Location = new System.Drawing.Point(4, 22);
            this.tong.Name = "tong";
            this.tong.Size = new System.Drawing.Size(1058, 298);
            this.tong.TabIndex = 2;
            this.tong.Text = "Tổng";
            // 
            // ch_tong
            // 
            chartArea9.Name = "ChartArea1";
            this.ch_tong.ChartAreas.Add(chartArea9);
            legend9.Name = "Legend1";
            this.ch_tong.Legends.Add(legend9);
            this.ch_tong.Location = new System.Drawing.Point(140, 12);
            this.ch_tong.Name = "ch_tong";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Tổng tiền";
            this.ch_tong.Series.Add(series9);
            this.ch_tong.Size = new System.Drawing.Size(779, 275);
            this.ch_tong.TabIndex = 1;
            this.ch_tong.Text = "chart1";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button4.Location = new System.Drawing.Point(1123, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 56);
            this.button4.TabIndex = 73;
            this.button4.Text = "Tất cả phòng";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 319);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 20);
            this.textBox1.TabIndex = 74;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checknumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(201, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 18);
            this.label2.TabIndex = 75;
            this.label2.Text = "Năm";
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Name = "ThongKe";
            this.Size = new System.Drawing.Size(1238, 684);
            this.Load += new System.EventHandler(this.ThongKe_Load);
            this.tabControl1.ResumeLayout(false);
            this.csDien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_csDien)).EndInit();
            this.csNuoc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_csNuoc)).EndInit();
            this.tong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_tong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage csDien;
        private System.Windows.Forms.TabPage csNuoc;
        private System.Windows.Forms.TabPage tong;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_csDien;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_csNuoc;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_tong;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}
