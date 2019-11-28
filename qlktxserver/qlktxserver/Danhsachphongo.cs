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
using System.Data.SqlClient;
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
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        private void Danhsachphongo_Load(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM PHONG";
            string dk = "";
            //Tim theo MANV khac rong
            if (textBox1.Text.Trim() != "")
            {
                dk += " MAPHG like '%" + textBox1.Text + "%'";
            }
            //kiem tra TenSP va MaSP khac rong
            if (textBox1.Text.Trim() != "" && dk != "")
            {
                dk += " AND LOAIPHG like N'%" + textBox6.Text + "%'";
            }
            //Tim kiem theo TenSP khi MaSP la rong
            if (textBox6.Text.Trim() != "" && dk == "")
            {
                dk += " LOAIPHG like N'%" + textBox6.Text + "%'";
            }
            //Ket hoi dk
            if (dk != "")
            {
                query += " WHERE" + dk;
            }


            //string query = "SELECT *FROM dbo.NHANVIEN WHERE MANV like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" ||  comboBox2.Text == "" || comboBox4.Text == "" || textBox2.Text == "" || comboBox5.Text == "")
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            else
            {
                int soluong = 0;
                string query = "INSERT into PHONG VALUES ('" + comboBox1.Text + "', '" + comboBox5.Text + "','" + soluong + "', '" + comboBox2.Text + "', '" + comboBox4.Text + "', '" + textBox2.Text + "')";
                dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                MessageBox.Show("Thêm thành công");
                Hienthi();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                DialogResult DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                    try
                    {
                        conn.Open();
                        string kiemtra1 = string.Format("SELECT *FROM PHONG WHERE (MAPHG = {0} AND TONGSV =0)", textBox7.Text);
                        //string kiemtra2 = string.Format("SELECT *FROM PHONG WHERE MAPHG = {0}", textBox7.Text);
                        SqlCommand cmd1 = new SqlCommand(kiemtra1, conn);
                        SqlDataReader dta = cmd1.ExecuteReader();
                        //SqlCommand cmd2 = new SqlCommand(kiemtra2, conn);
                        //SqlDataReader dta2 = cmd2.ExecuteReader();
                        if (dta.Read() == true)
                        {
                            conn.Close();
                            string query = string.Format("DELETE PHONG WHERE MAPHG = {0}", textBox7.Text);
                            int result = DataProvider.Instance.ExecuteNonQuery(query);
                            MessageBox.Show("Xóa thành công");
                            Hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã phòng cần xóa hoặc phòng cần xóa đang có sinh viên, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi kết nối");
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng điền mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hienthi();
        }
    }
}
