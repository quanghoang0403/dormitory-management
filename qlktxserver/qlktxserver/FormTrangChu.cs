using qlktxserver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QLKTX
{
    public partial class FormTrangChu : Form
    {
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "http://ktx.vnuhcm.edu.vn/";
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau FormDoiMatKhau = new frmDoiMatKhau();
            FormDoiMatKhau.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
        }

        private void hóaĐơnToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void sinhViênToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
                hoadon1.Visible = false;
                nhanvien1.Visible = false;
                sinhvien1.Visible = false;
                danhsachphongo1.Visible = true;
                tkb1.Visible = false;
            thongke1.Visible = false;
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon1.Visible = false;
            nhanvien1.Visible = true;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            tkb1.Visible = false;
            thongke1.Visible = false;
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon1.Visible = false;
            nhanvien1.Visible = false;
            sinhvien1.Visible = true;
            danhsachphongo1.Visible = false;
            tkb1.Visible = false;
            thongke1.Visible = false;
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hoadon1.Visible = true;
            nhanvien1.Visible = false;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            tkb1.Visible = false;
            thongke1.Visible = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
      public  void Thoat()
        {
            nhanvien1.Visible = false;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            hoadon1.Visible = true;
            tkb1.Visible = false;
            thongke1.Visible = false;
        }
        private void FormTrangChu_Load(object sender, EventArgs e)
        {
        }
        public byte[] ImageToByteArray1(Image image, string extension)
        {
            using (var memoryStream = new MemoryStream())
            {
                switch (extension)
                {
                    case ".jpeg":
                    case ".jpg":
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case ".png":
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case ".gif":
                        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
                return memoryStream.ToArray();
            }
        }
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            nhanvien1.Visible = false;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            hoadon1.Visible = false;
            tkb1.Visible = true;
            thongke1.Visible = false;
        }

        private void chat1_Load(object sender, EventArgs e)
        {

        }

        private void danhsachphongo1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var dlgResult = MessageBox.Show("Bạn Thực Sự Muốn Thoát Chương Trình ?", "?", MessageBoxButtons.YesNo);
            if (dlgResult == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void trợGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien1.Visible = false;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            hoadon1.Visible = false;
            tkb1.Visible = false;
            thongke1.Visible = false;
        }

        private void tkb1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            frmDangKy FormDangKy = new frmDangKy();
            FormDangKy.Show();
        }



        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nhanvien1.Visible = false;
            sinhvien1.Visible = false;
            danhsachphongo1.Visible = false;
            hoadon1.Visible = false;
            tkb1.Visible = false;
            thongke1.Visible = true;
        }
    }
}
