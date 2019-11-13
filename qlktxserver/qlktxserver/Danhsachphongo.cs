using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlktxserver;
using QLKTX;

namespace qlktxserver
{
    public partial class Danhsachphongo : UserControl
    {
        public Danhsachphongo()
        {
            InitializeComponent();
        }
        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.PHONG ";
            DataProvider load = new DataProvider();
            dataGridView1.DataSource = load.ExecuteQuery(query);
        }
        private void Danhsachphongo_Load(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            string query = "SELECT *FROM dbo.PHONG WHERE MAPHG '" +textBox1+ "'";
            DataProvider load = new DataProvider();
            dataGridView1.DataSource = load.ExecuteQuery(query);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
