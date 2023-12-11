using QuanLyDongHo.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace QuanLyDongHo.Controller
{
    class SanPhamController
    {
        private static ConnectDatabase connect = new ConnectDatabase();
        public DataTable GetAllSanPham()
        {
            return connect.DocDuLieuTuXML("SanPhams.xml");
        }
        public void ThemSanPham(SanPham sanpham)
        {
            DataRow[] rows = GetAllSanPham().Select($"MaSP = '{sanpham.MaSP}'");
            if (rows.Length > 0)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string xmlData = string.Format("<SanPham><MaSP>{0}</MaSP><TenSP>{1}</TenSP><MoTa>{2}</MoTa><SoLuong>{3}</SoLuong><GiaTien>{4}</GiaTien></SanPham>",
                                            sanpham.MaSP, sanpham.TenSP, sanpham.MoTa, sanpham.SoLuong, sanpham.GiaTien);

                if (connect.Them("SanPhams.xml", xmlData))
                {
                    MessageBox.Show("Thêm sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SuaSanPham(SanPham sanpham)
        {
            DataRow[] rows = GetAllSanPham().Select($"MaSP = '{sanpham.MaSP}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Sản phẩm không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string xmlData = string.Format("<SanPham><MaSP>{0}</MaSP><TenSP>{1}</TenSP><MoTa>{2}</MoTa><SoLuong>{3}</SoLuong><GiaTien>{4}</GiaTien></SanPham>",
                                            sanpham.MaSP, sanpham.TenSP, sanpham.MoTa, sanpham.SoLuong, sanpham.GiaTien);

                if (connect.Sua("SanPhams.xml", "MaSP", sanpham.MaSP, xmlData))
                {
                    MessageBox.Show("Sửa sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void XoaSanPham(string masp)
        {
            DataRow[] rows = GetAllSanPham().Select($"MaSP = '{masp}'");
            if (rows.Length == 0)
            {
                MessageBox.Show("Sản phẩm không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.Xoa("SanPhams.xml", "SanPham", "MaSP", masp))
                {
                    MessageBox.Show("Xoá sản phẩm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoá sản phẩm thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public DataTable TimKiemMaSP(string masp)
        {
            return connect.TimKiem("SanPhams.xml", "SanPham", "MaSP", masp);
        }

        public List<string> GetAllTenSP()
        {
            DataTable dataTable = GetAllSanPham();
            List<string> tenSPList = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                tenSPList.Add(row["TenSP"].ToString());
            }
            return tenSPList;
        }

        public decimal GetDonGiaByTenSP(string tenSP)
        {
            return Convert.ToDecimal(connect.LayGiaTri("SanPhams.xml", "SanPham", "GiaTien", "TenSP", tenSP));
        }

        public string GetMaSPByTenSP(string tensp)
        {
            return connect.LayGiaTri("SanPhams.xml", "SanPham", "MaSP", "TenSP", tensp);
        }
    }
}
