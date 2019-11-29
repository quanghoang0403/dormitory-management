using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using QLKTX;

namespace qlktxserver
{
    public partial class frmDangNhap : Form
    {

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtTenDN.Text;
                string mk = txtMatKhau.Text;
                string sql = "SELECT *FROM ACCOUNT WHERE USERNAME='" + tk + "' and PASS='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormDangNhap mi = new FormDangNhap();
                    mi.Show();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTenDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenDN_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
