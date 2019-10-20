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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
