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
    public partial class QuanLySanPham : Form
    {
        SanPhamController sanPhamController;
        private void QuanLySanPham_Load(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count > 0)
            {
                HienThiDuLieuDong(0);
            }
        }
        public QuanLySanPham()
        {
            sanPhamController = new SanPhamController();
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            HienThiDuLieuBang(sanPhamController.GetAllSanPham());
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                SanPham sanpham = new SanPham(txtMaSP.Text.ToUpper(), txtTenSP.Text, txtMota.Text, int.Parse(txtSoLuong.Text), int.Parse(txtGiaTien.Text));
                sanPhamController.ThemSanPham(sanpham);
                HienThiDuLieuBang(sanPhamController.GetAllSanPham());
            }
        }
        private bool KiemTraDuLieuHopLe()
        {
            // Kiểm tra dữ liệu của các TextBox
            if (string.IsNullOrEmpty(txtMaSP.Text) || string.IsNullOrEmpty(txtTenSP.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtGiaTien.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số lượng và giá tiền là số
            int soLuong, giaTien;
            if (!int.TryParse(txtSoLuong.Text, out soLuong) || !int.TryParse(txtGiaTien.Text, out giaTien))
            {
                MessageBox.Show("Số lượng và giá tiền phải là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra số lượng và giá tiền là số dương
            if (soLuong <= 0 || giaTien <= 0)
            {
                MessageBox.Show("Số lượng và giá tiền phải là số dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuHopLe())
            {
                SanPham sanpham = new SanPham(txtMaSP.Text.ToUpper(), txtTenSP.Text, txtMota.Text, int.Parse(txtSoLuong.Text), int.Parse(txtGiaTien.Text));
                sanPhamController.SuaSanPham(sanpham);
                HienThiDuLieuBang(sanPhamController.GetAllSanPham());
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaSP.Text))
            {
                MessageBox.Show("Chưa nhập mã sản phẩm cần xoá.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sanPhamController.XoaSanPham(txtMaSP.Text);
                HienThiDuLieuBang(sanPhamController.GetAllSanPham());
            }
        }

        private void HienThiDuLieuBang(DataTable sanphams)
        {
            dgvSanPham.DataSource = sanphams;
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                HienThiDuLieuDong(e.RowIndex);
            }
        }

        private void HienThiDuLieuDong(int rowIndex)
        {
            DataGridViewRow row = dgvSanPham.Rows[rowIndex];
            txtMaSP.Text = row.Cells["maSP"].Value.ToString();
            txtTenSP.Text = row.Cells["tenSP"].Value.ToString();
            txtMota.Text = row.Cells["mota"].Value.ToString();
            txtSoLuong.Text = row.Cells["soLuong"].Value.ToString();
            txtGiaTien.Text = row.Cells["giaTien"].Value.ToString();
            txtMaSP.Enabled = false;
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }


        private void btnLamMoiSP_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            txtMaSP.Enabled = true;
            txtTenSP.Text = "";
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaTien.Text = "";
            txtMota.Text = "";
        }

        private void txtTimKiemMaSP_TextChanged(object sender, EventArgs e)
        {
            string masp = txtTimKiemMaSP.Text.ToUpper();
            DataTable dt = sanPhamController.TimKiemMaSP(masp);
            HienThiDuLieuBang(dt);
        }

        private void btnLamMoiTK_Click(object sender, EventArgs e)
        {
            txtTimKiemMaSP.Text = "";
            HienThiDuLieuBang(sanPhamController.GetAllSanPham());
        }
    }
}
