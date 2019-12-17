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
using System.Configuration;

namespace qlktxserver
{
    public partial class Sinhvien : UserControl
    {
        private string button;
        public Sinhvien()
        {
            InitializeComponent();
            ID.Visible = false;
            butt_back.Visible = false;
        }
        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.SINHVIEN";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);

            if (checkper("ADD") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                butt_add.BackColor = Color.Silver;
            }
            if (checkper("DELETE") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                button3.BackColor = Color.Silver;

            }
            if (checkper("EDIT") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                butt_update.BackColor = Color.Silver;
            }
        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
        string UID = frmDangNhap.ID_User;
        private string id_per()
        {
            string id = "";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
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
          //  SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
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
                        if (dr["id_per"].ToString() == "2")
                        {
                            textBox7.Enabled = false;

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

        private void Sinhvien_Load(object sender, EventArgs e)
        {
            listper = List_per();
            Hienthi();
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

        private void butt_add_Click(object sender, EventArgs e)
        {
            if (checkper("ADD") == true)
            {
                //MessageBox.Show("Bạn có quyền thêm sinh viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Enabled = false;
                Enable();
                ClearData();
                button = "add";
                butt_save.BringToFront();
                butt_back.Visible = true;
                butt_update.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thêm sinh viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
            }

        }

        private void butt_save_Click(object sender, EventArgs e)
        {
            Unable();
            if (textBox2.Text == "" || comboBox3.Text == "" || textBox1.Text == "" || dateTimePicker1.Text == "" || textBox8.Text == "" || textBox5.Text == "" || textBox3.Text == "")
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            else
            {
                string query;
                switch (button)
                {
                    
                    case "add":
                        SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
                        conn2.Open();
                        string kiemtra2 = string.Format("SELECT *FROM PHONG WHERE (MAPHG = {0} AND TONGSV < SLMAX) ", textBox3.Text);
                        SqlCommand cmd2 = new SqlCommand(kiemtra2, conn2);
                        SqlDataReader dta2 = cmd2.ExecuteReader();
                        if (dta2.Read() == true)
                        {
                            conn2.Close();
                            query = "INSERT into SINHVIEN VALUES ('" + textBox1.Text + "', '" + comboBox3.Text + "', '" + dateTimePicker1.Text + "', '" + textBox2.Text + "', '" + textBox5.Text + "', '" + textBox8.Text + "', '" + textBox3.Text + "')";
                            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                            MessageBox.Show("Thêm thành công");
                            Hienthi();

                        }
                        else
                        {
                            MessageBox.Show("Phòng đã full, vui lòng nhập phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn2.Close();
                        }
                        Unable();
                        dataGridView1.Enabled = true;
                        butt_back.Visible = false;
                        butt_update.Enabled = true;

                        break;
                    case "edit":
                        try
                        {
                            query = "UPDATE SINHVIEN SET TENSV='" + textBox1.Text + "', GIOITINH='" + comboBox3.Text + "' , NGAYSINH='" + dateTimePicker1.Text + "', SDTSV='" + textBox2.Text + "' , QUEQUAN='" + textBox5.Text + "' , TRUONG='" + textBox8.Text + "', MAPHG='" + textBox3.Text + "' WHERE MASV=" + ID.Text;
                            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                            dataGridView1.Enabled = true;
                            Hienthi();
                            Unable();
                            butt_update.Enabled = true;
                            butt_back.Visible = false;
                            
                        }
                        catch(System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("Phòng đã full, vui lòng nhập phòng khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        break;

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
            if (checkper("DELETE") == true )
            {
                //MessageBox.Show("Bạn có quyền xóa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (textBox7.Text != "")
                {
                    DialogResult DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
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
                            MessageBox.Show("Lỗi kết nối ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("Bạn không có quyền xóa sinh viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox7.Enabled = false;
            }




        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Unable();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["TENSV"].Value.ToString();
                textBox2.Text = row.Cells["SDTSV"].Value.ToString();
                textBox5.Text = row.Cells["QUEQUAN"].Value.ToString();
                textBox8.Text = row.Cells["TRUONG"].Value.ToString();
                textBox3.Text = row.Cells["MAPHG"].Value.ToString();
                ID.Text = row.Cells["MASV"].Value.ToString();
                comboBox3.Text = row.Cells["GIOITINH"].Value.ToString();
                dateTimePicker1.Text = row.Cells["NGAYSINH"].Value.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void butt_back_Click(object sender, EventArgs e)
        {
            butt_add.BringToFront();
            dataGridView1.Enabled = true;
            butt_update.Enabled = true;
            butt_back.Visible = false;
            Unable();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        private void butt_sua_Click(object sender, EventArgs e)
        {
            if (checkper("EDIT") == true )
            {
                if (!string.IsNullOrEmpty(ID.Text))
                {//MessageBox.Show("Bạn có quyền sửa sinh viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Enabled = false;
                    Enable();
                    button = "edit";
                    butt_save.BringToFront();
                    butt_update.Enabled = false;
                    butt_back.Visible = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Unable();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sửa sinh viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Hienthi();
        }
        private void checknumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        public void Unable()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox8.Enabled = false;
            comboBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
        }
        public void Enable()
        {
            textBox1.Enabled=true;
            textBox2.Enabled=true;
            textBox3.Enabled=true;
            textBox5.Enabled=true;
            textBox8.Enabled=true;
            comboBox3.Enabled=true;
            dateTimePicker1.Enabled=true;
        }
        public void ClearData()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox5.Text = textBox8.Text = comboBox3.Text = "";
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            ID.Text = "";
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorProvider3.SetError(textBox1, "Vui lòng nhập họ tên");
            }
            else
            {
                errorProvider3.SetError(textBox1, "");
            }

        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            int num2;
            if (!int.TryParse(textBox2.Text, out num2) && num2 <= 10)
            {
                errorProvider3.SetError(textBox2, "Vui lòng nhập số điện thoại");
            }
            else
            {
                errorProvider3.SetError(textBox2, "");
            }

        }

        private void TextBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text == string.Empty)
            {
                errorProvider3.SetError(textBox8, "Vui lòng nhập trường");
            }
            else
            {
                errorProvider3.SetError(textBox8, "");
            }

        }

        private void ComboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Text == string.Empty)
            {
                errorProvider3.SetError(comboBox3, "Vui lòng chọn giới tính");
            }
            else
            {
                errorProvider3.SetError(comboBox3, "");
            }

        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProvider3.SetError(textBox3, "Vui lòng nhập phòng ở");
            }
            else
            {
                errorProvider3.SetError(textBox3, "");
            }

        }

        private void TextBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProvider3.SetError(textBox5, "Vui lòng nhập quê quán");
            }
            else
            {
                errorProvider3.SetError(textBox5, "");
            }

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (butt_add.Enabled == true && butt_update.Enabled == true)
            {
                Unable();
            }

        }

        private void TextBox4_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox4.Text, out num))
            {
                errorProvider3.SetError(textBox4, "Vui lòng nhập mã sv cần tìm");
            }
            else
            {
                errorProvider3.SetError(textBox4, "");
            }

        }

        private void TextBox7_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox7.Text, out num))
            {
                errorProvider3.SetError(textBox7, "Vui lòng nhập mã sv cần xóa");
            }
            else
            {
                errorProvider3.SetError(textBox7, "");
            }

        }

        private void TextBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProvider3.SetError(textBox6, "Vui lòng nhập họ tên sv cần tìm");
            }
            else
            {
                errorProvider3.SetError(textBox6, "");
            }

        }
    }
}
