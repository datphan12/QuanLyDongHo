using QuanLyDongHo.Controller;
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
    public partial class DoiMatKhau : Form
    {
        private TaiKhoanController taiKhoanController;
        public string maNV = "";
        public DoiMatKhau()
        {
            InitializeComponent();
            taiKhoanController = new TaiKhoanController();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMatKhauCu.Text) || string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                taiKhoanController.DoiMatKhau(maNV, txtMatKhauCu.Text, txtMatKhauMoi.Text);
            }
        }
    }
}
