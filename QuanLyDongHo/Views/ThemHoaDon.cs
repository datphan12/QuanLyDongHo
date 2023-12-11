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
    public partial class ThemHoaDon : Form
    {
        private SanPhamController sanPhamController;
        private static HoaDonControlller hoaDonControlller = new HoaDonControlller();
        private static ChiTietHoaDonController chiTietHoaDonController = new ChiTietHoaDonController();
        public ThemHoaDon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            sanPhamController = new SanPhamController();
        }

        private void ThemHoaDon_Load(object sender, EventArgs e)
        {
            dgvDsSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtMaNV.Text = TrangChu.maNV;
            cbbTenSP.DataSource = sanPhamController.GetAllTenSP();
        }

        private void cbbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDonGia.Text = sanPhamController.GetDonGiaByTenSP(cbbTenSP.Text).ToString();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ ComboBox và TextBox
            string tenSanPham = cbbTenSP.Text;
            int soLuong;
            decimal dongia = Convert.ToDecimal(txtDonGia.Text);
            if (!int.TryParse(txtSoLuong.Text, out soLuong))
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool sanPhamDaCo = false;
            foreach (DataGridViewRow row in dgvDsSanPham.Rows)
            {
                if (row.Cells["SanPham"].Value != null && row.Cells["SanPham"].Value.ToString() == tenSanPham)
                {
                    // Sản phẩm đã có, cập nhật số lượng
                    //int soLuongHienTai = int.Parse(row.Cells["SoLuong"].Value.ToString());
                    row.Cells["SoLuong"].Value = soLuong;
                    sanPhamDaCo = true;
                    break;
                }
            }

            // Nếu sản phẩm chưa có, thêm mới vào DataGridView
            if (!sanPhamDaCo)
            {
                dgvDsSanPham.Rows.Add(tenSanPham,dongia, soLuong);
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHD.Text) || string.IsNullOrEmpty(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                HoaDon newHoaDon = new HoaDon(txtMaHD.Text.ToUpper(), dtpNgayLap.Value, txtMaNV.Text, txtTenKhachHang.Text, 0);

                bool success = hoaDonControlller.ThemHoaDon(newHoaDon);

                if (success)
                {
                    for (int i = 0; i < dgvDsSanPham.Rows.Count; i++)
                    {
                        if (dgvDsSanPham.Rows[i].Cells["SanPham"].Value != null)
                        {
                            string maSP = sanPhamController.GetMaSPByTenSP(dgvDsSanPham.Rows[i].Cells["SanPham"].Value.ToString());
                            int soLuong = Convert.ToInt32(dgvDsSanPham.Rows[i].Cells["SoLuong"].Value);
                            decimal dongia = Convert.ToDecimal(dgvDsSanPham.Rows[i].Cells["DonGia"].Value);
                            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon(txtMaHD.Text.ToUpper(), maSP, soLuong, dongia);
                            chiTietHoaDonController.ThemChiTietHoaDon(chiTietHoaDon);
                        }
                    }
                    newHoaDon.TongTien =chiTietHoaDonController.LayTongTienHoaDon(newHoaDon.MaHD);
                    hoaDonControlller.SuaHoaDon(newHoaDon);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
