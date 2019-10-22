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
        SqlConnection connect;

        private void label3_Click(object sender, EventArgs e)
        {

        }
        DataTable data1;
        public void Hienthi()
        {
            data1 = new DataTable();
            string query = "SELECT * FROM dbo.NHANVIEN WHERE MaNV=" + textBox1.Text+"OR HoTenNV LIKE '%"+textBox2.Text+"%'";
          //  DataProvider load = new DataProvider();
            // string queryTim = "INSERT INTO dbo.SINHVIEN(MSSV,HoTenSV,SDT,QueQuan,MaPHG,MaCLB) VALUES( @MSSV ,@HoTenSV ,@SDT ,@QueQuan ,@MaPHG ,@MaCLB )";
            //  //  string queryTim = "SELECT * FROM dbo.NHANVIEN WHERE HoTenNV=N'" + textBox2.Text +"'";
              SqlCommand cmd = new SqlCommand(query, connect);
            //  cmd.Parameters.AddWithValue("MaNV", textBox1.Text);
            //  cmd.Parameters.AddWithValue("HoTenNV", textBox2.Text);
           // cmd.ExecuteNonQuery();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);



            adapter.Fill(data1);


           // dataGridView1.DataSource = null;
            dataGridView1.DataSource = data1;
            connect.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {
            //string connection = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\hoc\test project\Test - master\Database\ACCOUNT.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\hoc\test project\Test-master\Database\ACCOUNT.mdf;Integrated Security=True;Connect Timeout=30");
            connect.Open();
            textBox2.Text = "0";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
