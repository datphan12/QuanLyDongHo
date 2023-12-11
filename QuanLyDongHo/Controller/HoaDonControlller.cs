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
    class HoaDonControlller
    {
        private static ConnectDatabase connect = new ConnectDatabase();
        private ChiTietHoaDonController chiTietHoaDonController = new ChiTietHoaDonController();
        public DataTable GetAllHoaDon()
        {
            return connect.DocDuLieuTuXML("HoaDons.xml");
        }

        public DataTable TimKiemMaHD(string mahd)
        {
            return connect.TimKiem("HoaDons.xml", "HoaDon", "MaHD", mahd);
        }

        public bool ThemHoaDon(HoaDon hoadon)
        {
            DataRow[] checkHD = GetAllHoaDon().Select($"MaHD = '{hoadon.MaHD}'");
            if (checkHD.Length > 0)
            {
                MessageBox.Show("Mã hoá đơn đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                string xmlData = string.Format("<HoaDon><MaHD>{0}</MaHD><NgayLap>{1}</NgayLap><MaNV>{2}</MaNV><TenKH>{3}</TenKH><TongTien>{4}</TongTien></HoaDon>",
                                       hoadon.MaHD, hoadon.NgayLap,hoadon.MaNV, hoadon.TenKH, hoadon.TongTien);
                if (connect.Them("HoaDons.xml", xmlData))
                {
                    MessageBox.Show("Thêm hoá đơn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Thêm hoá đơn thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool SuaHoaDon(HoaDon hoadon)
        {
            string xmlData = string.Format("<HoaDon><MaHD>{0}</MaHD><NgayLap>{1}</NgayLap><MaNV>{2}</MaNV><TenKH>{3}</TenKH><TongTien>{4}</TongTien></HoaDon>",
                                       hoadon.MaHD, hoadon.NgayLap, hoadon.MaNV, hoadon.TenKH, hoadon.TongTien);
            if (connect.Sua("HoaDons.xml", "MaHD", hoadon.MaHD,xmlData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
