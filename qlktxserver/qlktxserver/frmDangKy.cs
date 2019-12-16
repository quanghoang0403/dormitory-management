using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace qlktxserver
{
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
        string UID = frmDangNhap.ID_User;
        private string id_per()
        {
            string id = "";

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_per_relationship WHERE id_user_rel = '" + UID + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["suspended"].ToString() == "False")
                        {
                            id = dr["id_per_rel"].ToString();
                        }
                        if (dr["id_user_rel"].ToString() == "3")
                        {
                            Unable();

                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return id;
        }

        private List<string> List_per()
        {
            string idper = id_per();
            List<string> termlist = new List<string>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_permision_detail WHERE id_per = '" + idper + "' ", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termlist.Add(dr["code_action"].ToString());
                        if (dr["id_per"].ToString() == "2" )
                        {
                            Unable();

                        }
 

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi xảy ra ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            finally
            {
                conn.Close();
            }


            return termlist;
        }

        List<string> listper = null;
        public void Unable()
        {
            textBox1.Enabled = false;
            txtUserRegis.Enabled = false;
            txtPassRegis.Enabled = false;
            txtRepassRegis.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkper("AD") == true)
            {
                this.Hide();
                SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                con2.Open();
                string ten = textBox1.Text;
                string tkRegis = txtUserRegis.Text;
                string mkRegis = txtPassRegis.Text;
                string remkRegis = txtRepassRegis.Text;
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(mkRegis);
                byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

                string hasPass = "";
                foreach (byte item in hasData)
                {
                    hasPass += item;
                }
                string sql2 = "SELECT *FROM ACCOUNT WHERE USERNAME= '" + tkRegis + "'";
                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                SqlDataReader dta2 = cmd2.ExecuteReader();

                if (dta2.Read() != true && tkRegis != "" && mkRegis == remkRegis && mkRegis != "")
                {
                    SqlConnection con3 = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
                    con3.Open();
                    string RegisterUser = "INSERT into ACCOUNT VALUES ('" + ten + "','" + tkRegis + "', '" + hasPass + "');";
                    SqlCommand querySaveStaff = new SqlCommand(RegisterUser, con3);
                    querySaveStaff.ExecuteNonQuery();
                    MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con3.Close();

                }
                else
                {
                    MessageBox.Show("Tạo tài khoản thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Show();
                }
            }
            else
            {
                
                MessageBox.Show("Bạn không có quyền đăng kí ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPassRegis_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserRegis_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtRepassRegis_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmDangKy_Load(object sender, EventArgs e)
        {
            listper = List_per();
        }
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in listper)
            {
                if (item == code)
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }
            return check;
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProviderDK.SetError(textBox1, "Vui lòng nhập tên");
            }
            else
            {
                errorProviderDK.SetError(textBox1, "");
            }
        }

        private void TxtUserRegis_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserRegis.Text == string.Empty)
            {
                errorProviderDK.SetError(txtUserRegis, "Vui lòng nhập tài khoản");
            }
            else
            {
                errorProviderDK.SetError(txtUserRegis, "");
            }
        }

        private void TxtPassRegis_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassRegis.Text == string.Empty)
            {
                errorProviderDK.SetError(txtPassRegis, "Vui lòng nhập mật khẩu");
            }
            else
            {
                errorProviderDK.SetError(txtPassRegis, "");
            }
        }

        private void TxtRepassRegis_Validating(object sender, CancelEventArgs e)
        {
            if (txtRepassRegis.Text == txtPassRegis.Text)
            {
                errorProviderDK.SetError(txtRepassRegis, "");
            }
            else if (txtRepassRegis.Text == string.Empty)
            {
                errorProviderDK.SetError(txtRepassRegis, "Vui lòng xác nhận mật khẩu");
            }
            else if (txtRepassRegis.Text != txtPassRegis.Text)
            {
                errorProviderDK.SetError(txtRepassRegis, "Xác nhận mật khẩu không đúng");
            }
        }
    }
}
