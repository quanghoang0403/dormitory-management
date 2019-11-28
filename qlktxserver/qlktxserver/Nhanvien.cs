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
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NHANVIEN";
            string dk = "";
            //Tim theo MANV khac rong
            if (textBox1.Text.Trim() != "")
            {
                dk += " MANV like '%" + textBox1.Text + "%'";
            }
            //kiem tra TenSP va MaSP khac rong
            if (textBox1.Text.Trim() != "" && dk != "")
            {
                dk += " AND TENNV like N'%" + textBox2.Text + "%'";
            }
            //Tim kiem theo TenSP khi MaSP la rong
            if (textBox2.Text.Trim() != "" && dk == "")
            {
                dk += " TENNV like N'%" + textBox2.Text + "%'";
            }
            //Ket hoi dk
            if (dk != "")
            {
                query += " WHERE" + dk;
            }
  
             
            //string query = "SELECT *FROM dbo.NHANVIEN WHERE MANV like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                        string kiemtra = string.Format("SELECT *FROM NHANVIEN WHERE (MANV = {0} AND SLPHONGQL = 0)", textBox7.Text);
                        SqlCommand cmd = new SqlCommand(kiemtra, conn);
                        SqlDataReader dta = cmd.ExecuteReader();
                        if (dta.Read() == true)
                        {
                            conn.Close();
                            string query = string.Format("DELETE NHANVIEN WHERE MANV = {0}", textBox7.Text);
                            int result = DataProvider.Instance.ExecuteNonQuery(query);
                            MessageBox.Show("Xóa thành công");
                            Hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã nhân viên cần xóa hoặc nhân viên đang quản lý phòng, không thể xóa, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || comboBox3.Text == "" || dateTimePicker2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            else
            {
                int soluong = 0;
                string query = "INSERT into NHANVIEN VALUES ('" + textBox3.Text + "', '" + comboBox3.Text + "', '" + dateTimePicker1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + dateTimePicker2.Text + "', '" + comboBox1.Text + "', '" + soluong + "')";
                dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                MessageBox.Show("Thêm thành công");
                Hienthi();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hienthi();
        }
    }
}
