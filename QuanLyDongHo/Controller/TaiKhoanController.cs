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
    class TaiKhoanController
    {
        private static ConnectDatabase connect = new ConnectDatabase();

        public DataTable GetAllTaiKhoan()
        {
            return connect.DocDuLieuTuXML("TaiKhoanNhanViens.xml");
        }
        public Boolean kiemtraTaiKhoan(TaiKhoanNhanVien taikhoan)
        {
            if(GetAllTaiKhoan() != null && GetAllTaiKhoan().Rows.Count > 0)
            {
                //chuyển DataTable sang Enum<DataRow>
                var query = from row in GetAllTaiKhoan().AsEnumerable()
                            where row.Field<string>("TenTK") == taikhoan.TenTK && row.Field<string>("MatKhau") == taikhoan.MatKhau
                            select row;
                //kiểm tra query có dữ liệu được truy vấn
                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string GetMaNVByTenDangNhap(string tenDN)
        {
            return connect.LayGiaTri("TaiKhoanNhanViens.xml", "TaiKhoanNhanVien", "MaNV", "TenTK", tenDN);
        }

        public void ThemTaiKhoan(TaiKhoanNhanVien taikhoan)
        {
            DataRow[] rows = GetAllTaiKhoan().Select($"MaTK = '{taikhoan.MaTK}'");
            if (rows.Length > 0)
            {
                MessageBox.Show("Mã tài khoản đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string xmlData = string.Format("<TaiKhoanNhanVien><MaTK>{0}</MaTK><TenTK>{1}</TenTK><MatKhau>{2}</MatKhau><MaNV>{3}</MaNV></TaiKhoanNhanVien>",
                                            taikhoan.MaTK, taikhoan.TenTK, taikhoan.MatKhau, taikhoan.MaNV);

                if (connect.Them("TaiKhoanNhanViens.xml", xmlData))
                {
                    MessageBox.Show("Thêm tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SuaTaiKhoan(TaiKhoanNhanVien taikhoan)
        {
            DataRow[] rows = GetAllTaiKhoan().Select($"MaTK = '{taikhoan.MaTK}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xmlData = string.Format("<TaiKhoanNhanVien><MaTK>{0}</MaTK><TenTK>{1}</TenTK><MatKhau>{2}</MatKhau><MaNV>{3}</MaNV></TaiKhoanNhanVien>",
                                            taikhoan.MaTK, taikhoan.TenTK, taikhoan.MatKhau, taikhoan.MaNV);

                if (connect.Sua("TaiKhoanNhanViens.xml", "MaTK", taikhoan.MaTK, xmlData))
                {
                    MessageBox.Show("Sửa tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void XoaTaiKhoan(string matk)
        {
            DataRow[] rows = GetAllTaiKhoan().Select($"MaTK = '{matk}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.Xoa("TaiKhoanNhanViens.xml", "TaiKhoanNhanVien", "MaTK", matk))
                {
                    MessageBox.Show("Xoá tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoá tài khoản thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DoiMatKhau(string maNV, string matKhauCu, string matKhauMoi)
        {
            DataRow[] rows = GetAllTaiKhoan().Select($"MaNV = '{maNV}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Tài khoản không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!CheckMatKhau(maNV, matKhauCu)){
                MessageBox.Show("Mật khẩu cũ sai.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xmlData = string.Format("<TaiKhoanNhanVien><MaTK>{0}</MaTK><TenTK>{1}</TenTK><MatKhau>{2}</MatKhau><MaNV>{3}</MaNV></TaiKhoanNhanVien>",
                                            rows[0]["MaTK"], rows[0]["TenTK"], matKhauMoi, rows[0]["MaNV"]);

                if (connect.Sua("TaiKhoanNhanViens.xml", "MaNV", maNV, xmlData))
                {
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool CheckMatKhau(string maNV, string matkhau)
        {
            DataRow[] rows = GetAllTaiKhoan().Select($"MaNV = '{maNV}'");
            if (rows[0]["MatKhau"].Equals(matkhau))
            {
                return true;
            }
            return false;
        }

    }
}
