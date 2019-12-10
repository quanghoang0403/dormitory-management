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
using System.Diagnostics;
using System.Security.Cryptography;


namespace qlktxserver
{
    public partial class frmDoiMatKhau : Form
    {

        public frmDoiMatKhau()
        {
            InitializeComponent();

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-KDA1585N\\DONSQL;Initial Catalog=QuanLyKTX;Integrated Security=True");
            con2.Open();
            string tk = txtTaikhoan.Text;
            string mk = txtMKcu.Text;
            string newMk = txtMKmoi.Text;
            string reNewmk = txtConfimMk.Text;

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(mk);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            string sql2 = "SELECT *FROM ACCOUNT WHERE USERNAME='" + tk + "' and PASS='" + hasPass+ "'";

            byte[] temp2 = ASCIIEncoding.ASCII.GetBytes(newMk);
            byte[] hasData2 = new MD5CryptoServiceProvider().ComputeHash(temp2);

            string hasPass2 = "";
            foreach (byte item in hasData2)
            {
                hasPass2 += item;
            }


            SqlCommand cmd2 = new SqlCommand(sql2, con2);
            SqlDataReader dta2 = cmd2.ExecuteReader();

            if (dta2.Read() == true && newMk == reNewmk)
            {
                    con2.Close();
                    SqlConnection con3 = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                    con3.Open();
                    string RegisterUser = "Update ACCOUNT SET PASS = '" + hasPass2 + "' WHERE USERNAME='" + tk + "'";
                    SqlCommand querySaveStaff = new SqlCommand(RegisterUser, con3);
                    querySaveStaff.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con3.Close();
            }
            else
            {
                MessageBox.Show("Nhập không đúng, vui lòng nhập lại");
                this.Show();
            }

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTaikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTaikhoan_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void TxtTaikhoan_Validating(object sender, CancelEventArgs e)
        {
            if (txtTaikhoan.Text == string.Empty)
            {
                errorProviderTK.SetError(txtTaikhoan, "Vui lòng nhập tên tài khoản");
            }
            else
            {
                errorProviderTK.SetError(txtTaikhoan, "");
            }

        }

        private void TxtMKcu_Validating(object sender, CancelEventArgs e)
        {
            if (txtMKcu.Text == string.Empty)
            {
                errorProviderTK.SetError(txtMKcu, "Vui lòng nhập mật khẩu cũ");
            }
            else
            {
                errorProviderTK.SetError(txtMKcu, "");
            }

        }

        private void TxtMKmoi_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (txtMKmoi.Text == string.Empty)
            {
                errorProviderTK.SetError(txtMKmoi, "Vui lòng nhập mật khẩu mới");
            }
            else
            {
                errorProviderTK.SetError(txtMKmoi, "");
            }

        }

        private void TxtConfimMk_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfimMk.Text == txtMKmoi.Text)
            {
                errorProviderTK.SetError(txtConfimMk, "");
            }
            else if (txtConfimMk.Text == string.Empty)
            {
                errorProviderTK.SetError(txtConfimMk, "Vui lòng xác nhận mật khẩu");
            }
            else if (txtConfimMk.Text != txtMKmoi.Text)
            {
                errorProviderTK.SetError(txtConfimMk, "Xác nhận mật khẩu không đúng");
            }

        }
    }
}
