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
        }
        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.SINHVIEN";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        private void Sinhvien_Load(object sender, EventArgs e)
        {
            Hienthi();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "" || dateTimePicker1.Text == "" || textBox8.Text == "" || textBox5.Text == "" || textBox3.Text == "")
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            else
            {
                SqlConnection conn2 = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                conn2.Open();
                string kiemtra2 = string.Format("SELECT *FROM PHONG WHERE (MAPHG = {0} AND TONGSV < SLMAX) ", textBox3.Text);
                SqlCommand cmd2 = new SqlCommand(kiemtra2, conn2);
                SqlDataReader dta2 = cmd2.ExecuteReader();
                if (dta2.Read() == true)
                {
                    conn2.Close();
                    string query = "INSERT into SINHVIEN VALUES ('" + textBox2.Text + "', '" + comboBox3.Text + "', '" + dateTimePicker1.Text + "', '" + textBox1.Text + "', '" + textBox5.Text + "', '" + textBox8.Text + "', '" + textBox3.Text + "')";
                    dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                    MessageBox.Show("Thêm thành công");
                    Hienthi();
                }
                else
                {
                    MessageBox.Show("Phòng đã full, vui lòng nhập phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn2.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM SINHVIEN";
            string dk = "";
            //Tim theo MANV khac rong
            if (textBox4.Text.Trim() != "")
            {
                dk += " MASV like '%" + textBox4.Text + "%'";
            }
            //kiem tra TenSP va MaSP khac rong
            if (textBox4.Text.Trim() != "" && dk != "")
            {
                dk += " AND TENSV like N'%" + textBox6.Text + "%'";
            }
            //Tim kiem theo TenSP khi MaSP la rong
            if (textBox6.Text.Trim() != "" && dk == "")
            {
                dk += " TENSV like N'%" + textBox6.Text + "%'";
            }
            //Ket hoi dk
            if (dk != "")
            {
                query += " WHERE" + dk;
            }


            //string query = "SELECT *FROM dbo.NHANVIEN WHERE MANV like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void button3_Click(object sender, EventArgs e)
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
                        string kiemtra = string.Format("SELECT *FROM SINHVIEN WHERE MASV = {0}", textBox7.Text);
                        SqlCommand cmd = new SqlCommand(kiemtra, conn);
                        SqlDataReader dta = cmd.ExecuteReader();
                        if (dta.Read() == true)
                        {
                            conn.Close();
                            string query = string.Format("DELETE SINHVIEN WHERE MASV = {0}", textBox7.Text);
                            int result = DataProvider.Instance.ExecuteNonQuery(query);
                            MessageBox.Show("Xóa thành công");
                            Hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy mã sinh viên cần xóa, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
     
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hienthi();
        }
    }
}
