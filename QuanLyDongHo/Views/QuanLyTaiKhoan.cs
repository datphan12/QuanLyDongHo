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
    public partial class QuanLyTaiKhoan : Form
    {
        TaiKhoanController taiKhoanController;
        NhanVienController nhanVienController;
        public QuanLyTaiKhoan()
        {
            taiKhoanController = new TaiKhoanController();
            nhanVienController = new NhanVienController();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            HienThiDuLieuBang(taiKhoanController.GetAllTaiKhoan());
            dgvTaiKhoan.CellClick += dgvTaiKhoan_CellClick;
            dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //đưa mã nhân viên vào combobox
            cbbMaNV.DataSource = nhanVienController.GetAllMaNV();
        }

        private void QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.Rows.Count > 0)
            {
                HienThiDuLieuDong(0);
            }
        }

        private void HienThiDuLieuBang(DataTable taikhoans)
        {
            dgvTaiKhoan.DataSource = taikhoans;
        }

        private void dgvTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HienThiDuLieuDong(e.RowIndex);
            }
        }

        private void HienThiDuLieuDong(int rowIndex)
        {
            DataGridViewRow row = dgvTaiKhoan.Rows[rowIndex];
            txtMaTK.Text = row.Cells["MaTK"].Value.ToString();
            txtTenTK.Text = row.Cells["TenTK"].Value.ToString();
            txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
            cbbMaNV.SelectedItem = row.Cells["MaNV"].Value.ToString();
            txtMaTK.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLamMoiTK_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            txtMaTK.Enabled = true;
            txtMaTK.Text = "";
            txtTenTK.Text = "";
            txtMatKhau.Text = "";
            cbbMaNV.Text = "";
        }

        private bool KiemTraDuLieuHopLe()
        {
            if(string.IsNullOrEmpty(txtMaTK.Text) || string.IsNullOrEmpty(txtTenTK.Text) || string.IsNullOrEmpty(txtMatKhau.Text) ||
                cbbMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                TaiKhoanNhanVien taikhoan = new TaiKhoanNhanVien(txtMaTK.Text.ToUpper(), txtTenTK.Text, txtMatKhau.Text, cbbMaNV.Text);
                taiKhoanController.ThemTaiKhoan(taikhoan);
                HienThiDuLieuBang(taiKhoanController.GetAllTaiKhoan());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                TaiKhoanNhanVien taikhoan = new TaiKhoanNhanVien(txtMaTK.Text.ToUpper(), txtTenTK.Text, txtMatKhau.Text, cbbMaNV.Text);
                taiKhoanController.SuaTaiKhoan(taikhoan);
                HienThiDuLieuBang(taiKhoanController.GetAllTaiKhoan());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MessageBox.Show("Chưa nhập mã tài khoản cần xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                taiKhoanController.XoaTaiKhoan(txtMaTK.Text);
                HienThiDuLieuBang(taiKhoanController.GetAllTaiKhoan());
            }
        }
    }

}
