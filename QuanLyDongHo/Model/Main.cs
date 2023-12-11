using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDongHo.Model
{
    class Main
    {
        ConnectDatabase con = new ConnectDatabase();
        public void TaoXMLFile()
        {
            if (con.TaoXML("NhanVien") && con.TaoXML("TaiKhoanNhanVien")&& con.TaoXML("SanPham") && con.TaoXML("HoaDon")&& con.TaoXML("ChiTietHoaDon"))
            {
                MessageBox.Show("Cập nhập XML thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhập XML thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CapNhapXMLVaoSQL()
        {
            if (con.CapNhapDuLieuTuXMLVaoSQL("NhanVien")&& con.CapNhapDuLieuTuXMLVaoSQL("TaiKhoanNhanVien") &&
            con.CapNhapDuLieuTuXMLVaoSQL("SanPham") && con.CapNhapDuLieuTuXMLVaoSQL("HoaDon") &&con.CapNhapDuLieuTuXMLVaoSQL("ChiTietHoaDon"))
            {
                MessageBox.Show("Cập nhập SQL thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhập SQl thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
