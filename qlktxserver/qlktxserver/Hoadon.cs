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
    public partial class Hoadon : UserControl
    {
        public Hoadon()
        {
            InitializeComponent();
        }
        SqlConnection connect;
        DataTable data = new DataTable();
        public void Hienthi()
        {
            try
            {
                string query = "SELECT ThanhTien,ChiSoNuoc,TongSP FROM dbo.HOADON WHERE MaPHG='" + textBox1.Text + "' AND Thang=" + comboBox4.Text;
                SqlCommand cmd = new SqlCommand(query, connect);
                //  cmd.Parameters.AddWithValue("MaNV", textBox1.Text);
                //  cmd.Parameters.AddWithValue("HoTenNV", textBox2.Text);
                // cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);



                adapter.Fill(data);



                //dataGridView1.DataSource = data;
                connect.Close();
            }
            catch(Exception ex)
            { 

            connect.Close();
            }
        }
            private void Hoadon_Load(object sender, EventArgs e)
        {
           // string connection = "Data Source=.\\SQLEXPRESS;Initial Catalog=QL;Integrated Security=True";
            connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\hoc\test project\Test-master\Database\ACCOUNT.mdf;Integrated Security=True;Connect Timeout=30");
            connect.Open();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || comboBox4.Text == "") MessageBox.Show("Mã Phòng, Tháng Không Thể Trống", "?", MessageBoxButtons.OK);
                else
                {
                    Hienthi();
                    DataRow dr = data.Rows[0];
                    string num = dr["ThanhTien"].ToString();
                    textBox2.Text = dr["ChiSoNuoc"].ToString();
                    textBox5.Text = dr["TongSP"].ToString();
                    textBox6.Text = num;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
    }
}
