using QuanLyDongHo.Controller;
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
    public partial class DangNhap : Form
    {
        Main main = new Main();
        TaiKhoanController taiKhoanController = new TaiKhoanController();
        public DangNhap()
        {
            InitializeComponent();
            //main.TaoXMLFile();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDN = txtTenDN.Text;
            string matkhau = txtMatKhau.Text;
            if(tenDN.Equals("") || matkhau.Equals(""))
            {
                MessageBox.Show("Nhập chưa đủ thông tin!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtTenDN.Focus();
            }
            else
            {
                TaiKhoanNhanVien taikhoan = new TaiKhoanNhanVien(tenDN, matkhau);
                if (taiKhoanController.kiemtraTaiKhoan(taikhoan))
                {
                    TrangChu trangChu = new TrangChu();
                    TrangChu.tenDangNhap = txtTenDN.Text;
                    TrangChu.maNV = taiKhoanController.GetMaNVByTenDangNhap(txtTenDN.Text);
                    trangChu.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Tài hoản hoặc mật khẩu sai!", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtTenDN.Focus();
                }
            }
        }


        private void ckbHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienThiMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

    }
}
