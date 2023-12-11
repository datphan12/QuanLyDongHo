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
    public partial class QuanLyHoaDon : Form
    {

        private HoaDonControlller hoaDonControlller;
        private ChiTietHoaDonController chiTietHoaDonController;
        public QuanLyHoaDon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            hoaDonControlller = new HoaDonControlller();
            chiTietHoaDonController = new ChiTietHoaDonController();
            HienThiDuLieuBang(hoaDonControlller.GetAllHoaDon());
            dgvHoaDon.CellClick += dgvHoaDon_CellClick;
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count > 0)
            {
                dgvChiTietHoaDon.DataSource = chiTietHoaDonController.GetAllCTHDByMaHD(dgvHoaDon.Rows[0].Cells[0].Value.ToString());
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemHoaDon themHoaDon = new ThemHoaDon();
            themHoaDon.Show();
        }

        private void HienThiDuLieuBang(DataTable hoadons)
        {
            dgvHoaDon.DataSource = hoadons;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string mahd = dgvHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                dgvChiTietHoaDon.DataSource = chiTietHoaDonController.GetAllCTHDByMaHD(mahd);
            }
        }

        private void txtTimKiemMaHD_TextChanged(object sender, EventArgs e)
        {
            dgvHoaDon.DataSource = hoaDonControlller.TimKiemMaHD(txtTimKiemMaHD.Text.ToUpper());
            dgvChiTietHoaDon.DataSource = chiTietHoaDonController.GetAllCTHDByMaHD(dgvHoaDon.Rows[0].Cells[0].Value.ToString());
        }

        private void btnLamMoiHD_Click(object sender, EventArgs e)
        {
            txtTimKiemMaHD.Text = "";
            HienThiDuLieuBang(hoaDonControlller.GetAllHoaDon());
        }
    }
}
