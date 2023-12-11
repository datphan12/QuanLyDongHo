using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDongHo.Model
{
    class TaiKhoanNhanVien
    {
        public string MaTK { get; set; }
        public string TenTK { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }


        public TaiKhoanNhanVien(string tenTK, string matKhau, string maNV)
        {
            TenTK = tenTK;
            MatKhau = matKhau;
            MaNV = maNV;
        }

        public TaiKhoanNhanVien(string maTK, string tenTK, string matKhau, string maNV)
        {
            MaTK = maTK;
            TenTK = tenTK;
            MatKhau = matKhau;
            MaNV = maNV;
        }

        public TaiKhoanNhanVien(string tenTK, string matKhau)
        {
            TenTK = tenTK;
            MatKhau = matKhau;
        }

        public TaiKhoanNhanVien()
        {
        }
    }
}
