using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qlktxserver
{
    public partial class Form2 : Form
    {
        public DateTime date;

        public Form2(DateTime t)
        {
            InitializeComponent();
            this.date = t;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Thông báo Không thể Trống ", "?", MessageBoxButtons.OK);
            else
            {
                try
                {
                    string query = "INSERT INTO dbo.TKB(ThongBao,Ngay,MoTa,MSSV) VALUES( @ThongBao , @Ngay , @MoTa , @MSSV )";
                    DataProvider load = new DataProvider();
                    load.ExecuteNonQuery(query, new object[] { textBox1.Text, date, textBox2.Text, textBox3.Text });
                    DialogResult m = MessageBox.Show("Thêm Thành Công ", "?", MessageBoxButtons.OK);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
