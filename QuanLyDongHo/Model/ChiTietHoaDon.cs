using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongHo.Model
{
    class ChiTietHoaDon
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }

        public ChiTietHoaDon()
        {
        }

        public ChiTietHoaDon(string maHD, string maSP, int soLuong, decimal donGia)
        {
            MaHD = maHD;
            MaSP = maSP;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}
