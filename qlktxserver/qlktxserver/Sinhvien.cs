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
    public partial class Sinhvien : UserControl
    {
        public Sinhvien()
        {
            InitializeComponent();
            // Hienthi();
        }
        SqlConnection connect;
        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.SINHVIEN";
            DataProvider load = new DataProvider();
            dataGridView1.DataSource = load.ExecuteQuery(query);
        }
        private void Sinhvien_Load(object sender, EventArgs e)
        {
            //Hienthi();
            //string connection = "Data Source=.\\SQLEXPRESS;Initial Catalog=QL;Integrated Security=True";
            //connect = new SqlConnection(connection);
            //connect.Open();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "") MessageBox.Show("MSSV, Họ Tên , SĐT Không thể Trống ", "?", MessageBoxButtons.OK);
            else
            {
                string query = "INSERT INTO dbo.SINHVIEN(MSSV,HoTenSV,GioiTinh,NgaySinh,SDT,QueQuan,MaPHG,MaCLB) VALUES( @MSSV , @HoTenSV , @GioiTinh , @NgaySinh , @SDT , @QueQuan , @MaPHG , @MaCLB )";
                DataProvider load = new DataProvider();
                load.ExecuteNonQuery(query, new object[] { textBox1.Text, textBox2.Text, comboBox3.SelectedItem.ToString(), dateTimePicker1.Text, textBox3.Text, textBox5.Text, comboBox1.Text, textBox4.Text });
                //  string queryTim = "INSERT INTO dbo.SINHVIEN(MSSV,HoTenSV,SDT,QueQuan,MaPHG,MaCLB) VALUES( @MSSV ,@HoTenSV ,@SDT ,@QueQuan ,@MaPHG ,@MaCLB )";
                //  //  string queryTim = "SELECT * FROM dbo.NHANVIEN WHERE HoTenNV=N'" + textBox2.Text +"'";
                //  SqlCommand cmd = new SqlCommand(queryTim, connect);
                //  cmd.Parameters.AddWithValue("MSSV", textBox1.Text);
                //  cmd.Parameters.AddWithValue("HoTenSV", textBox2.Text);
                ////  cmd.Parameters.AddWithValue("GioiTinh","N");
                ////  cmd.Parameters.AddWithValue("NgaySinh", "2000-03-12 00:00:00.000");
                //  cmd.Parameters.AddWithValue("SDT", textBox3.Text);
                //  cmd.Parameters.AddWithValue("QueQuan", textBox5.Text);
                //  cmd.Parameters.AddWithValue("MaPHG", comboBox1.Text);
                //  cmd.Parameters.AddWithValue("MaCLB", textBox4.Text);
                //  cmd.ExecuteNonQuery();


                Hienthi();
                Set();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Bạn Chưa Nhập MSSV", "?", MessageBoxButtons.OK);
            else
            {
                string query = "UPDATE dbo.SINHVIEN SET HoTenSV= @HoTenSV ,SDT= @SDT ,QueQuan= @QueQuan ,MaPHG= @MaPHG ,MaCLB= @MaCLB  WHERE MSSV= @MSSV ";
                DataProvider load = new DataProvider();
                load.ExecuteNonQuery(query, new object[] { textBox2.Text, textBox3.Text, textBox5.Text, comboBox1.Text, textBox4.Text, textBox1.Text });
                Hienthi();
                Set();

            }
        }
        void Set()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Bạn Chưa Nhập MSSV", "?", MessageBoxButtons.OK);
            else
            {
                string query = "DELETE FROM dbo.SINHVIEN  WHERE MSSV= @MSSV ";
                DataProvider load = new DataProvider();
                load.ExecuteNonQuery(query, new object[] { textBox1.Text });
                Hienthi();
                Set();
            }
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
