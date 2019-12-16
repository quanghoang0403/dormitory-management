using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using qlktxserver;
using System.Data.SqlClient;
using QLKTX;
using System.Configuration;

namespace qlktxserver
{
    public partial class Danhsachphongo : UserControl
    {
        private string button;
        public Danhsachphongo()
        {
            InitializeComponent();
            butt_back.Visible = false;
            ID.Visible = false;

        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
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

        public void Hienthi()
        {
            string query = "SELECT * FROM dbo.PHONG ";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        private void Danhsachphongo_Load(object sender, EventArgs e)
        {
            listper = List_per();
            Hienthi();
            if (checkper("AD") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                butt_add.BackColor = Color.Silver;
            }
            if (checkper("DELET") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                button2.BackColor = Color.Silver;

            }
            if (checkper("EDI") == false)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
                butt_update.BackColor = Color.Silver;
            }
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


        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM PHONG";
            string dk = "";
            //Tim theo MANV khac rong
            if (textBox1.Text.Trim() != "")
            {
                dk += " MAPHG like '%" + textBox1.Text + "%'";
            }
            //kiem tra TenSP va MaSP khac rong
            if (textBox1.Text.Trim() != "" && dk != "")
            {
                dk += " AND LOAIPHG like N'%" + textBox6.Text + "%'";
            }
            //Tim kiem theo TenSP khi MaSP la rong
            if (textBox6.Text.Trim() != "" && dk == "")
            {
                dk += " LOAIPHG like N'%" + textBox6.Text + "%'";
            }
            //Ket hoi dk
            if (dk != "")
            {
                query += " WHERE" + dk;
            }


            //string query = "SELECT *FROM dbo.NHANVIEN WHERE MANV like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Unable();
            if (comboBox1.Text == "" || comboBox2.Text == "" || comboBox4.Text == "" || textBox2.Text == "" || comboBox5.Text == "")
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            else
            {
                string query;
                switch (button)
                {
                    case "add":
                        int soluong = 0;
                        query = "INSERT into PHONG VALUES ('" + comboBox1.Text + "', '" + comboBox5.Text + "','" + soluong + "', '" + comboBox2.Text + "', '" + comboBox4.Text + "', '" + textBox2.Text + "')";
                        dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                        MessageBox.Show("Thêm thành công");
                        Hienthi();
                        butt_add.BringToFront();
                        butt_back.Visible = false;
                        Unable();
                        break;
                    case "edit":
                        query = "UPDATE PHONG SET LOAIPHG='" + comboBox1.Text + "', SLMAX='" + comboBox5.Text + "' , TINHTRANG='" + comboBox2.Text + "', TOA='" + textBox2.Text + "' , MANV=" + textBox2.Text + " WHERE MAPHG=" + ID.Text;
                        dataGridView1.DataSource = DataProvider.Instance.ExecuteQuery(query);
                        dataGridView1.Enabled = true;
                        Hienthi();
                        Unable();
                        butt_update.Enabled = true;
                        butt_back.Visible = false;
                        butt_add.BringToFront();
                        break;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (checkper("DELET") == true)
            {
                //MessageBox.Show("Bạn có quyền xóa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (textBox7.Text != "")
                {
                    DialogResult DialogResult = MessageBox.Show("Bạn có chắc muốn xóa!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (DialogResult == DialogResult.OK)
                    {
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString);
                            conn.Open();
                            string kiemtra1 = string.Format("SELECT *FROM PHONG WHERE (MAPHG = {0} AND TONGSV =0)", textBox7.Text);
                            //string kiemtra2 = string.Format("SELECT *FROM PHONG WHERE MAPHG = {0}", textBox7.Text);
                            SqlCommand cmd1 = new SqlCommand(kiemtra1, conn);
                            SqlDataReader dta = cmd1.ExecuteReader();
                            //SqlCommand cmd2 = new SqlCommand(kiemtra2, conn);
                            //SqlDataReader dta2 = cmd2.ExecuteReader();
                            if (dta.Read() == true)
                            {
                                conn.Close();
                                string query = string.Format("DELETE PHONG WHERE MAPHG = {0}", textBox7.Text);
                                int result = DataProvider.Instance.ExecuteNonQuery(query);
                                MessageBox.Show("Xóa thành công");
                                Hienthi();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy mã phòng cần xóa hoặc phòng cần xóa đang có sinh viên, vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conn.Close();
                            }

                    }
                }
                else
                    MessageBox.Show("Vui lòng điền mã sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            else
            {
                MessageBox.Show("Bạn không có quyền xóa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Hienthi();
            ClearData();
        }

        private void butt_add_Click(object sender, EventArgs e)
        {
            if (checkper("AD") == true)
            {
                //MessageBox.Show("Bạn có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Enabled = false;
                Enable();
                ClearData();
                button = "add";
                button6.BringToFront();
                butt_back.Visible = true;
                butt_update.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn không có quyền thêm phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
            }


        }
        private void butt_back_Click(object sender, EventArgs e)
        {
            butt_add.BringToFront();
            dataGridView1.Enabled = true;
            butt_update.Enabled = true;
            butt_back.Visible = false;
            Unable();
        }
        private void butt_sua_Click(object sender, EventArgs e)
        {
            if (checkper("EDI") == true )
            {
                if (ID.Text != "")
                {
                    //MessageBox.Show("Bạn có quyền sửa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Enabled = false;
                    Enable();
                    button = "edit";
                    button6.BringToFront();
                    butt_update.Enabled = false;
                    butt_back.Visible = true;
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn phòng để sửa ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Unable();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sửa phòng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Unable();
            }


        }
        public void ClearData()
        {
            comboBox4.Text = comboBox1.Text = comboBox2.Text = comboBox5.Text= textBox2.Text= ID.Text="";
        }
        public void Unable()
        {
            butt_add.Enabled = true;
            butt_update.Enabled = true;


            comboBox4.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox5.Enabled = false;
            textBox2.Enabled = false;
        }
        public void Enable()
        {
            button6.Enabled = true;
            comboBox4.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox5.Enabled = true;
            textBox2.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Unable();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["LOAIPHG"].Value.ToString();
                comboBox2.Text = row.Cells["TINHTRANG"].Value.ToString();
                comboBox4.Text = row.Cells["TOA"].Value.ToString();
                comboBox5.Text = row.Cells["SLMAX"].Value.ToString();
                textBox2.Text = row.Cells["MANV"].Value.ToString();
                ID.Text = row.Cells["MAPHG"].Value.ToString();

            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel1_Paint_1(object sender, PaintEventArgs e)
        {
            if (butt_update.Enabled == true && butt_add.Enabled == true)
            {
                Unable();
            }

        }

        private void ComboBox4_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox4.Text == string.Empty)
            {
                errorProviderPhong.SetError(comboBox4, "Vui lòng chọn tòa");
            }
            else
            {
                errorProviderPhong.SetError(comboBox4, "");
            }

        }

        private void ComboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.Text == string.Empty)
            {
                errorProviderPhong.SetError(comboBox1, "Vui lòng chọn loại phòng");
            }
            else
            {
                errorProviderPhong.SetError(comboBox1, "");
            }

        }

        private void ComboBox2_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox2.Text == string.Empty)
            {
                errorProviderPhong.SetError(comboBox2, "Vui lòng chọn tình trạng");
            }
            else
            {
                errorProviderPhong.SetError(comboBox2, "");
            }

        }

        private void ComboBox5_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox5.Text == string.Empty)
            {
                errorProviderPhong.SetError(comboBox5, "Vui lòng chọn số lượng sinh viên");
            }
            else
            {
                errorProviderPhong.SetError(comboBox5, "");
            }

        }
         
        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox2.Text, out num))
            {
                errorProviderPhong.SetError(textBox2, "Vui lòng nhập mã trưởng phòng");
            }
            else
            {
                errorProviderPhong.SetError(textBox2, "");
            }

        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox1.Text, out num))
            {
                errorProviderPhong.SetError(textBox1, "Vui lòng nhập mã phòng cần tìm");
            }
            else
            {
                errorProviderPhong.SetError(textBox1, "");
            }

        }

        private void TextBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text == string.Empty)
            {
                errorProviderPhong.SetError(textBox6, "Vui lòng nhập tên phòng cần tìm");
            }
            else
            {
                errorProviderPhong.SetError(textBox6, "");
            }

        }

        private void TextBox7_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (!int.TryParse(textBox7.Text, out num))
            {
                errorProviderPhong.SetError(textBox7, "Vui lòng nhập mã phòng cần xóa");
            }
            else
            {
                errorProviderPhong.SetError(textBox7, "");
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
