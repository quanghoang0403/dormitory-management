using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLKTX
{
    public partial class FormDangNhap : Form
    {
        // private Panel panel1;
        // private Panel panel2;
        Timer time = new Timer();

        public FormDangNhap()
        {

            InitializeComponent();
            panel2.Left = 0;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(89, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 5);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(3, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(61, 5);
            this.panel2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(173, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 17);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Loading, Please waiting....";
            // 
            // FormDangNhap
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(551, 330);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDangNhap_FormClosed);
            this.Load += new System.EventHandler(this.FormDangNhap_Load_1);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Panel panel1;
        private Panel panel2;
        int plus = 5;
        private TextBox textBox1;
        int k = 0;
        void move(object sender, EventArgs e)
        {
            if (k == 100)
            {

                this.Close();
            }
            k++;
            panel2.Left = panel2.Left + plus;
            if (panel2.Left > 359)
            {
                plus = -5;
            }
            if (panel2.Left < 3)
            {
                plus = 5;
            }
        }
        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void FormDangNhap_Load_1(object sender, EventArgs e)
        {
            time.Tick += new EventHandler(move);
            time.Interval = 10;
            time.Start();

        }

        private void FormDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormTrangChu mi = new FormTrangChu();
            mi.Show();
        }
    }
}
