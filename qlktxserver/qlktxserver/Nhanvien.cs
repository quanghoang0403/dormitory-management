using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace qlktxserver
{
    public partial class Nhanvien : UserControl
    {
        public Nhanvien()
        {
            InitializeComponent();
        }

        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.NHANVIEN";
            DataProvider load = new DataProvider();
            dataGridView1.DataSource = load.ExecuteQuery(query);

        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
