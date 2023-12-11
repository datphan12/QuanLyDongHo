using QuanLyDongHo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongHo.Controller
{
    class ChiTietHoaDonController
    {
        private ConnectDatabase connect = new ConnectDatabase();
        public DataTable GetAllChiTietHoaDon()
        {
            return connect.DocDuLieuTuXML("ChiTietHoaDons.xml");
        }
        public DataTable GetAllCTHDByMaHD(string mahd)
        {
            return connect.TimKiem("ChiTietHoaDons.xml", "ChiTietHoaDon", "MaHD", mahd);
        }

        public void ThemChiTietHoaDon(ChiTietHoaDon chitiethoadon)
        {
            string xmlData = string.Format("<ChiTietHoaDon><MaHD>{0}</MaHD><MaSP>{1}</MaSP><SoLuong>{2}</SoLuong><DonGia>{3}</DonGia></ChiTietHoaDon>",
                                       chitiethoadon.MaHD, chitiethoadon.MaSP, chitiethoadon.SoLuong, chitiethoadon.DonGia);
            if (connect.Them("ChiTietHoaDons.xml", xmlData))
            {
                return;
            }
            else
            {
                MessageBox.Show("Thêm chi tiết hoá đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public decimal LayTongTienHoaDon(string maHD)
        {
            DataTable chiTietHoaDonTable = GetAllCTHDByMaHD(maHD);
            decimal tongTien = 0;

            foreach (DataRow row in chiTietHoaDonTable.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);
                tongTien += soLuong * donGia;
            }

            return tongTien;
        }
    }
}
