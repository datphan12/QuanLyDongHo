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
    class NhanVienController
    {
        private static ConnectDatabase connect = new ConnectDatabase();

        public DataTable GetAllNhanVien()
        {
            return connect.DocDuLieuTuXML("NhanViens.xml");
        }

        public void ThemNhanVien(NhanVien nhanvien)
        {
            DataRow[] rows = GetAllNhanVien().Select($"MaNV = '{nhanvien.MaNV}'");
            if (rows.Length > 0)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string xmlData = string.Format("<NhanVien><MaNV>{0}</MaNV><TenNV>{1}</TenNV><NgaySinh>{2}</NgaySinh><DiaChi>{3}</DiaChi><SoDienThoai>{4}</SoDienThoai><Email>{5}</Email></NhanVien>",
                                            nhanvien.MaNV, nhanvien.TenNV, nhanvien.NgaySinh.ToString(), nhanvien.DiaChi, nhanvien.SoDienThoai, nhanvien.Email);

                if (connect.Them("NhanViens.xml", xmlData))
                {
                    MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SuaNhanVien(NhanVien nhanvien)
        {
            DataRow[] rows = GetAllNhanVien().Select($"MaNV = '{nhanvien.MaNV}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Nhân viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xmlData = string.Format("<NhanVien><MaNV>{0}</MaNV><TenNV>{1}</TenNV><NgaySinh>{2}</NgaySinh><DiaChi>{3}</DiaChi><SoDienThoai>{4}</SoDienThoai><Email>{5}</Email></NhanVien>",
                                            nhanvien.MaNV, nhanvien.TenNV, nhanvien.NgaySinh, nhanvien.DiaChi, nhanvien.SoDienThoai, nhanvien.Email);

                if (connect.Sua("NhanViens.xml", "MaNV", nhanvien.MaNV, xmlData))
                {
                    MessageBox.Show("Sửa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void XoaNhanVien(string manv)
        {
            DataRow[] rows = GetAllNhanVien().Select($"MaNV = '{manv}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Nhân viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.Xoa("NhanViens.xml", "NhanVien", "MaNV", manv))
                {
                    MessageBox.Show("Xoá nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoá nhân viên thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public List<string> GetAllMaNV()
        {
            DataTable dataTable = GetAllNhanVien();
                List<string> maNVList = new List<string>();
                foreach (DataRow row in dataTable.Rows)
                {
                    maNVList.Add(row["MaNV"].ToString());
                }
                return maNVList;
        }
    }
}
