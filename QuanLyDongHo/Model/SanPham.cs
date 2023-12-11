using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongHo.Model
{
    class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string MoTa { get; set; }
        public int SoLuong { get; set; }
        public int GiaTien { get; set; }

        public SanPham()
        {
        }

        public SanPham(string maSP, string tenSP, string moTa, int soLuong, int giaTien)
        {
            MaSP = maSP;
            TenSP = tenSP;
            MoTa = moTa;
            SoLuong = soLuong;
            GiaTien = giaTien;
        }
    }
}
