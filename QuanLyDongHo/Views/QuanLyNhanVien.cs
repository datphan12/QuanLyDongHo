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
    public partial class QuanLyNhanVien : Form
    {
        private NhanVienController nhanVienController;
        public QuanLyNhanVien()
        {
            nhanVienController = new NhanVienController();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            HienThiDuLieuBang(nhanVienController.GetAllNhanVien());
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void QuanLyNhanVien_Load(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                HienThiDuLieuDong(0);
            }
        }

        private bool KiemTraDuLieuHopLe()
        {
            // Kiểm tra dữ liệu của các TextBox
            if (string.IsNullOrEmpty(txtMaNV.Text) || string.IsNullOrEmpty(txtTenNV.Text) ||
                string.IsNullOrEmpty(txtSoDienThoai.Text) || string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra định dạng email
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Định dạng email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra định dạng số điện thoại
            if (!IsValidPhoneNumber(txtSoDienThoai.Text))
            {
                MessageBox.Show("Định dạng số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Hàm kiểm tra định dạng số điện thoại
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra xem chuỗi chỉ chứa các ký tự số
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\d+$");
        }

        private void HienThiDuLieuBang(DataTable nhanviens)
        {
            dgvNhanVien.DataSource = nhanviens;
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HienThiDuLieuDong(e.RowIndex);
            }
        }

        private void HienThiDuLieuDong(int rowIndex)
        {
            DataGridViewRow row = dgvNhanVien.Rows[rowIndex];
            txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
            txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value.ToString());
            txtMaNV.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            txtMaNV.Enabled = true;
            txtTenNV.Text = "";
            txtMaNV.Text = "";
            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                NhanVien nhanvien = new NhanVien(txtMaNV.Text.ToUpper(), txtTenNV.Text,dtpNgaySinh.Value,txtDiaChi.Text,txtSoDienThoai.Text,txtEmail.Text);
                nhanVienController.ThemNhanVien(nhanvien);
                HienThiDuLieuBang(nhanVienController.GetAllNhanVien());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                NhanVien nhanvien = new NhanVien(txtMaNV.Text, txtTenNV.Text, dtpNgaySinh.Value, txtDiaChi.Text, txtSoDienThoai.Text, txtEmail.Text);
                nhanVienController.SuaNhanVien(nhanvien);
                HienThiDuLieuBang(nhanVienController.GetAllNhanVien());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Chưa nhập mã nhân viên cần xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nhanVienController.XoaNhanVien(txtMaNV.Text);
                HienThiDuLieuBang(nhanVienController.GetAllNhanVien());
            }
        }
    }
}
