using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongHo.Model
{
    class NhanVien
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public NhanVien(string maNV, string tenNV, DateTime ngaySinh, string diaChi, string soDienThoai, string email)
        {
            MaNV = maNV;
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }

        public NhanVien(string tenNV, DateTime ngaySinh, string diaChi, string soDienThoai, string email)
        {
            TenNV = tenNV;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }

        public NhanVien()
        {
        }
    }
}
