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
        string button;
        public Nhanvien()
        {
            InitializeComponent();
            ID.Visible = false;
            butt_back.Visible = false;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Unable();
            if (e.RowIndex>=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox3.Text = row.Cells["TENNV"].Value.ToString();
                textBox4.Text = row.Cells["SDTNV"].Value.ToString();
                textBox5.Text = row.Cells["QUEQUAN"].Value.ToString();
                ID.Text = row.Cells["MANV"].Value.ToString();
                comboBox3.Text = row.Cells["GIOITINH"].Value.ToString();
                dateTimePicker1.Text = row.Cells["NGAYSINH"].Value.ToString();
                dateTimePicker2.Text = row.Cells["NGAYVAOLAM"].Value.ToString();
                comboBox1.Text = row.Cells["CHUCVU"].Value.ToString();
               
            }
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
            if (checkper("DELET") == true)
            {
                //MessageBox.Show("Bạn có quyền xóa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (textBox7.Text != "")
                {
                    DialogResult DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AAGVBOR\\SQLEXPRESS;Initial Catalog=QuanLyKTX;Integrated Security=True");
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
                }
                else
                    MessageBox.Show("Vui lòng điền mã nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void butt_save_Click(object sender, EventArgs e)
        {
            
            
            if (textBox3.Text == "" || comboBox3.Text == "" || dateTimePicker2.Text == "" || dateTimePicker1.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            { 
                MessageBox.Show("Vui lòng điền đầy đủ thông tin"); }
            else
            {
                string query;
                switch (button)
                { 
                    case "add":
                        int soluong = 0;
                        query = "INSERT into NHANVIEN(TENNV, GIOITINH, NGAYSINH, SDTNV, QUEQUAN, NGAYVAOLAM, CHUCVU, SLPHONGQL)  VALUES ('" + textBox3.Text + "', '" + comboBox3.Text + "', '" + dateTimePicker1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + dateTimePicker2.Text + "', '" + comboBox1.Text + "', '" + soluong + "')";
                        dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                        MessageBox.Show("Thêm thành công");
                        Hienthi();
                        Unable();
                        dataGridView1.Enabled = true;
                        butt_update.Enabled = true;

                        break;
                    case "edit":
                        query = "UPDATE NHANVIEN SET TENNV='"+textBox3.Text +"', GIOITINH='"+comboBox3.Text + "' , NGAYSINH='" + dateTimePicker1.Text + "', SDTNV='" + textBox4.Text + "' , QUEQUAN='" + textBox5.Text + "' , NGAYVAOLAM='" + dateTimePicker2.Text + "', CHUCVU='" + comboBox1.Text + "' WHERE MANV="+ ID.Text;
                        dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                        dataGridView1.Enabled = true;
                        Hienthi();
                        Unable();
                        butt_update.Enabled = true;
                        butt_back.Visible = false;
                        break;

                }
                button6.BringToFront();
            }
            
            

        }
        private void button6_Them(object sender, EventArgs e)
        {
            if (checkper("AD") == true)
            {
                //MessageBox.Show("Bạn có quyền thêm nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Enabled = false;
                Enable();
                ClearData();
                butt_save.BringToFront();
                button = "add";
                butt_update.Enabled = false;
                butt_back.Visible = true;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
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
        private void checknumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
        public void ClearData()
        {
            textBox3.Text = textBox4.Text = textBox5.Text ="";
            
            dateTimePicker1.Value = dateTimePicker1.MaxDate;
            dateTimePicker2.Value = DateTime.Now;
            ID.Text = "";

        }
        private void butt_sua_Click(object sender, EventArgs e)
        {
            if (checkper("EDI") == true || ID.Text != "")
            {
                //MessageBox.Show("Bạn có quyền sửa nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Enabled = false;
                Enable();
                button = "edit";
                butt_save.BringToFront();
                butt_update.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sửa nhân viên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
            }




        }
        public void Unable()
        {
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Enabled = false;
            comboBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
        }
        public void Enable()
        {
       
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            comboBox1.Enabled = true;
            comboBox3.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
        }
        private void butt_back_Click(object sender, EventArgs e)
        {
            button6.BringToFront();
            dataGridView1.Enabled = true;
            butt_update.Enabled = true;
            butt_back.Visible = false;
            Unable();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butt_back_Click_1(object sender, EventArgs e)
        {

        }

        private void butt_update_Click(object sender, EventArgs e)
        {

        }

        private void butt_save_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            if (button6.Enabled == true && butt_update.Enabled == true)
            {
                Unable();
            }

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                errorProviderNV.SetError(textBox3, "Vui lòng nhập họ tên");
            }
            else
            {
                errorProviderNV.SetError(textBox3, "");
            }

        }

        private void ComboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProviderNV.SetError(comboBox1, "Vui lòng chọn chức vụ");
            }
            else
            {
                errorProviderNV.SetError(comboBox1, "");
            }

        }

        private void TextBox5_Validating(object sender, CancelEventArgs e)
        {
            if (textBox5.Text == string.Empty)
            {
                errorProviderNV.SetError(textBox5, "Vui lòng nhập quê quán");
            }
            else
            {
                errorProviderNV.SetError(textBox5, "");
            }

        }

        private void ComboBox3_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox3.Text == string.Empty)
            {
                errorProviderNV.SetError(comboBox3, "Vui lòng chọn giới tính");
            }
            else
            {
                errorProviderNV.SetError(comboBox3, "");
            }

        }

        private void TextBox4_Validating(object sender, CancelEventArgs e)
        {
            int num4;
            if (!int.TryParse(textBox4.Text, out num4) && num4 <= 10)
            {
                errorProviderNV.SetError(textBox4, "Vui lòng nhập số điện thoại");
            }
            else
            {
                errorProviderNV.SetError(textBox4, "");
            }

        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            int num11;
            if (!int.TryParse(textBox1.Text, out num11) && num11 <= 10)
            {
                errorProviderNV.SetError(textBox1, "Vui lòng nhập mã nhân viên cần tìm");
            }
            else
            {
                errorProviderNV.SetError(textBox1, "");
            }

        }

        private void TextBox7_Validating(object sender, CancelEventArgs e)
        {
            int num7;
            if (!int.TryParse(textBox7.Text, out num7) && num7 <= 10)
            {
                errorProviderNV.SetError(textBox7, "Vui lòng nhập mã nhân viên cần xóa");
            }
            else
            {
                errorProviderNV.SetError(textBox7, "");
            }

        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                errorProviderNV.SetError(textBox2, "Vui lòng nhập tên nhân viên cần tìm");
            }
            else
            {
                errorProviderNV.SetError(textBox2, "");
            }

        }
    }
}
