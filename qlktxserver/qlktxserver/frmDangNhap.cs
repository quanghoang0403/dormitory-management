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
using System.Security.Cryptography;

namespace qlktxserver
{
    public partial class frmDangNhap : Form
    {

        public frmDangNhap()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-KDA1585N\\DONSQL;Initial Catalog=QuanLyKTX;Integrated Security=True");

        private string getID()
        {
                string id = "";
                conn.Open();
                string tk = txtTenDN.Text;
                string mk = txtMatKhau.Text;

                byte[] temp = ASCIIEncoding.ASCII.GetBytes(mk);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hasPass = "";
                foreach (byte item in hasData)
                {
                    hasPass += item;
                } 
                SqlCommand sql1 = new SqlCommand("SELECT *FROM ACCOUNT WHERE USERNAME='" + tk + "' and PASS='" + hasPass + "'", conn);
                string sql = "SELECT *FROM ACCOUNT WHERE USERNAME='" + tk + "' and PASS='" +hasPass + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql1);
                SqlCommand cmd = new SqlCommand(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dt != null && dta.Read() == true)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();
                    }
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormDangNhap mi = new FormDangNhap();
                    mi.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Show();
                }
                conn.Close();
                return id;
        }

        public static string ID_User = "";


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ID_User = getID();
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

        private void TxtTenDN_Validating(object sender, CancelEventArgs e)
        {
            if (txtTenDN.Text == string.Empty)
            {
                errorProvider1.SetError(txtTenDN, "Vui lòng nhập tên đăng nhập");
            }
            else
            {
                errorProvider1.SetError(txtTenDN, "");
            }
        }

        private void TxtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtMatKhau_Validating(object sender, CancelEventArgs e)
        {
            if (txtMatKhau.Text == string.Empty)
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
            }

        }

        private void TxtMatKhau_Validated(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == string.Empty)
            {
                errorProvider1.SetError(txtMatKhau, "Vui lòng nhập mật khẩu");
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
            }
        }
    }
}
