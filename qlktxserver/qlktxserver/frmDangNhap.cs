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

        public static bool a = false;
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDN.Text;
            string password = txtMatKhau.Text;
            if (true)
            {

                // FormTrangChu mi = new FormTrangChu();
                //  mi.Show();
                FormDangNhap mi = new FormDangNhap();
                mi.Show();

            }
            else
            {
                MessageBox.Show("sai ten hoac pass!");
            }


        }
        public bool check()
        {
            return a;
        }
        public bool Login(string username, string password)
        {
            return true;
            // return Acount.Instance.Login(username, password);

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
    }
}
