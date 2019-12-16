using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace qlktxserver
{
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        string UID = frmDangNhap.ID_User;
        
        
        void Hienthi()
        {
            List<Phong> phongList = PhongDAO.Instance.LoadPhongList();

            foreach (Phong item in phongList)
            {
                Button btn = new Button()
                {
                    Width = PhongDAO.PhongWidth,
                    Height = PhongDAO.PhongHeight
                };
                btn.Text = item.ID + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Dang su dung":
                        btn.BackColor = Color.Aqua;
                        break;
                    case "Trong":
                        btn.BackColor = Color.Yellow;
                        break;
                    default:
                        btn.BackColor = Color.Silver;
                        break;
                }

                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            int phongID = ((sender as Button).Tag as Phong).ID;
            var connectionString = ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "SELECT MAPHG,THANG, SUM(TONGTIEN) AS TONG, SUM(CHISONUOC) AS NUOC,SUM(CHISODIEN) AS DIEN FROM HOADON WHERE NAM='" + textBox1.Text + "'AND MAPHG='" + phongID + "' GROUP BY MAPHG, THANG";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable db = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(db);

                //ch_csDien
                ch_csDien.DataSource = db;
                ch_csDien.Series["Chỉ số điện"].XValueMember = "THANG";
                ch_csDien.Series["Chỉ số điện"].YValueMembers = "DIEN";
                ch_csDien.DataBind();
                //ch_csNuoc
                ch_csNuoc.DataSource = db;
                ch_csNuoc.Series["Chỉ số nước"].XValueMember = "THANG";
                ch_csNuoc.Series["Chỉ số nước"].YValueMembers = "NUOC";
                ch_csNuoc.DataBind();
                //ch_tong
                ch_tong.DataSource = db;

                ch_tong.Series["Tổng tiền"].XValueMember = "THANG";
                ch_tong.Series["Tổng tiền"].YValueMembers = "TONG";
                ch_tong.DataBind();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập năm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            // ClearData();
        }

        private void ThongKe_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["QuanLyKTX"].ConnectionString;

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                SqlConnection conn = new SqlConnection(connectionString);
                string query = "SELECT THANG, SUM(TONGTIEN) AS TONG, SUM(CHISONUOC) AS NUOC,SUM(CHISODIEN) AS DIEN FROM HOADON WHERE NAM='" + textBox1.Text + "' GROUP BY THANG";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable db = new DataTable();
                adapter.SelectCommand = cmd;
                adapter.Fill(db);
                //ch_csDien
                ch_csDien.DataSource = db;
                ch_csDien.Series["Chỉ số điện"].XValueMember = "THANG";
                ch_csDien.Series["Chỉ số điện"].YValueMembers = "DIEN";
                ch_csDien.DataBind();
                //ch_csNuoc
                ch_csNuoc.DataSource = db;
                ch_csNuoc.Series["Chỉ số nước"].XValueMember = "THANG";
                ch_csNuoc.Series["Chỉ số nước"].YValueMembers = "NUOC";
                ch_csNuoc.DataBind();
                //ch_tong
                ch_tong.DataSource = db;

                ch_tong.Series["Tổng tiền"].XValueMember = "THANG";
                ch_tong.Series["Tổng tiền"].YValueMembers = "TONG";
                ch_tong.DataBind();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập năm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
