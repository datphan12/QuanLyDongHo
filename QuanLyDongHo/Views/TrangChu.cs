using QuanLyDongHo.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongHo.Views
{
    public partial class TrangChu : Form
    {
        public static string tenDangNhap = "";
        public static string maNV = "";
        private Main main;
        public TrangChu()
        {
            InitializeComponent();
            main = new Main();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_quanlysanpham_Click(object sender, EventArgs e)
        {
            QuanLySanPham form = new QuanLySanPham();
            form.Show();
        }

        private void btn_quanlynhanvien_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien form = new QuanLyNhanVien();
            form.Show();
        }

        private void btn_quanlyhoadon_Click(object sender, EventArgs e)
        {
            QuanLyHoaDon form = new QuanLyHoaDon();
            form.Show();
        }

        private void btn_quanlytaikhoan_Click(object sender, EventArgs e)
        {
            QuanLyTaiKhoan form = new QuanLyTaiKhoan();
            form.Show();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lblTenDN.Text = "Xin chào, " + tenDangNhap;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tenDangNhap = "";
            maNV = "";
            DangNhap form = new DangNhap();
            form.Show();
            this.Close();
        }

        private void đổiMậtKhâuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau form = new DoiMatKhau();
            form.maNV = maNV;
            form.Show();
        }

        private void sQLSangXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.TaoXMLFile();
        }

        private void chuyểnĐổiXMLSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.CapNhapXMLVaoSQL();
        }
    }
}
