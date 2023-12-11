using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongHo.Model
{
    class HoaDon
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNV { get; set; }
        public string TenKH { get; set; }
        public decimal TongTien { get; set; }

        public HoaDon()
        {
        }

        public HoaDon(string maHD, DateTime ngayLap, string maNV, string tenKH, decimal tongTien)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            MaNV = maNV;
            TenKH = tenKH;
            TongTien = tongTien;
        }
    }
}
