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
            SqlConnection con2 = new SqlConnection(@"Data Source=DESKTOP-AAGVBOR\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
            con2.Open();
            string tk = txtTaikhoan.Text;
            string mk = txtMKcu.Text;
            string newMk = txtMKmoi.Text;
            string reNewmk = txtConfimMk.Text;
            string sql2 = "SELECT *FROM ACCOUNT WHERE USERNAME='" + tk + "' and PASS='" + mk + "'";
            SqlCommand cmd2 = new SqlCommand(sql2, con2);
            SqlDataReader dta2 = cmd2.ExecuteReader();

            if (dta2.Read() == true && newMk == reNewmk)
            {
                try
                {
                    con2.Close();
                    SqlConnection con3 = new SqlConnection(@"Data Source=DESKTOP-AAGVBOR\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                    con3.Open();
                    string RegisterUser = "Update ACCOUNT SET PASS = '" + newMk + "' WHERE USERNAME='" + tk + "'";
                    SqlCommand querySaveStaff = new SqlCommand(RegisterUser, con3);
                    querySaveStaff.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con3.Close();
                }
                catch
                {
                    //Error when save data
                    MessageBox.Show("Error to save on database");
                    this.Close();
                }


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
    }
}
