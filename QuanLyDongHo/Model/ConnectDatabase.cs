using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace QuanLyDongHo.Model
{
    class ConnectDatabase
    {
        string ConnectString = @"Data Source=DAT;Initial Catalog=QUANLYDONGHO;Integrated Security=True";

        public bool TaoXML(string tenbang)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectString))
                {
                    con.Open();
                    string sql;
                    if (tenbang.Equals("NhanVien"))
                    {
                        sql = $"SELECT MaNV, TenNV, CONVERT(varchar, NgaySinh, 23) AS NgaySinh, DiaChi, SoDienThoai, Email FROM {tenbang}";
                    }
                    else if (tenbang.Equals("HoaDon"))
                    {
                        sql = $"SELECT MaHD, CONVERT(varchar, NgayLap, 23) AS NgayLap, MaNV, TenKH, TongTien FROM { tenbang}";
                    }
                    else
                    {
                        sql = $"SELECT * FROM {tenbang}";
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sql, con))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, tenbang);
                        dataSet.DataSetName = tenbang + "s";
                        if (dataSet.Tables.Count > 0)
                        {
                            DataTable dt = dataSet.Tables[tenbang];
                            dt.WriteXml(tenbang + "s" + ".xml");
                            return true;
                        }
                        else
                        {
                            MessageBox.Show($"Không có dữ liệu để tạo tệp XML từ bảng {tenbang}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo tệp XML từ bảng {tenbang}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable DocDuLieuTuXML(string tenFileXML)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    if (dataSet.Tables.Count > 0)
                    {
                        // Lấy DataTable đầu tiên từ DataSet
                        DataTable dt = dataSet.Tables[0];
                        return dt;
                    }
                    else
                    {
                        MessageBox.Show($"Tệp XML {tenFileXML} không chứa dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc dữ liệu từ tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public Boolean Them(string tenFileXML, string xmlData)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    // Đọc dữ liệu từ tệp XML vào XDocument
                    XDocument doc = XDocument.Load(filePath);

                    // Tạo XElement từ chuỗi xmlData
                    XElement newNode = XElement.Parse(xmlData);

                    // Thêm node mới vào root của tệp XML
                    doc.Root.Add(newNode);

                    // Lưu lại tệp XML
                    doc.Save(filePath);

                    return true;
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu vào tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Boolean Sua(string tenFileXML, string id, string idData, string xmlData)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    // Đọc dữ liệu từ tệp XML vào XDocument
                    XDocument doc = XDocument.Load(filePath);

                    // Tạo XElement từ chuỗi xmlData
                    XElement newNode = XElement.Parse(xmlData);

                    var existingNode = doc.Root.Elements().FirstOrDefault(e => e.Element(id)?.Value == idData);

                    if (existingNode != null)
                    {
                        existingNode.ReplaceWith(newNode);

                        // Lưu lại tệp XML
                        doc.Save(filePath);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy node cần sửa trong tệp XML {tenFileXML}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu vào tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public Boolean Xoa(string tenFileXML, string bang, string id, string idData)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    XDocument doc = XDocument.Load(filePath);

                    // Tìm node có idData cần xóa
                    XElement nodeToRemove = doc.Descendants(bang).FirstOrDefault(node => node.Element(id)?.Value == idData);

                    if (nodeToRemove != null)
                    {
                        nodeToRemove.Remove();
                        doc.Save(filePath);
                        return true;
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy dữ liệu với {id} = {idData}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dữ liệu trong tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable TimKiem(string tenFileXML, string tenBang, string tenCot, string giaTriTimKiem)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(filePath);

                    if (dataSet.Tables.Contains(tenBang))
                    {
                        DataTable dt = dataSet.Tables[tenBang];

                        // Lọc các dòng bắt đầu bằng giá trị nhập vào
                        var rows = dt.AsEnumerable().Where(row => row.Field<string>(tenCot).StartsWith(giaTriTimKiem)).CopyToDataTable();

                        if (rows.Rows.Count > 0)
                        {
                            return rows;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Bảng {tenBang} không tồn tại trong tệp XML {tenFileXML}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string LayGiaTri(string tenFileXML, string bang, string truongTraVe, string truongNhapVao, string giaTriTruongNhapVao)
        {
            try
            {
                string filePath = Path.Combine(Application.StartupPath, tenFileXML);
                if (File.Exists(filePath))
                {
                    XDocument doc = XDocument.Load(filePath);

                    // Tìm các node ChiTietHoaDon có trường truongNhapVao bằng giaTriTruongNhapVao
                    var nodes = doc.Descendants(bang)
                        .Where(node => node.Element(truongNhapVao)?.Value == giaTriTruongNhapVao);

                    if (nodes.Any())
                    {
                        // Lấy giá trị từ trường truongTraVe của node đầu tiên
                        return nodes.First().Element(truongTraVe)?.Value;
                    }
                    else
                    {
                        MessageBox.Show($"Không tìm thấy dữ liệu với {truongNhapVao} = {giaTriTruongNhapVao}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                else
                {
                    MessageBox.Show($"Tệp XML {tenFileXML} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy giá trị từ tệp XML: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public bool CapNhapDuLieuTuXMLVaoSQL(string tenBang)
        {
            try
            {
                DataTable dataTable = DocDuLieuTuXML(tenBang + "s.xml");

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    using (SqlConnection con = new SqlConnection(ConnectString))
                    {
                        con.Open();
                        string deleteSql = $"DELETE FROM {tenBang}";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteSql, con))
                        {
                            deleteCommand.ExecuteNonQuery();
                        }
                        // Tạo một đối tượng SqlBulkCopy để chuyển dữ liệu từ DataTable vào SQL Server
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
                        {
                            bulkCopy.DestinationTableName = tenBang;
                            // Mapping cột từ DataTable sang cột trong SQL Server (theo tên cột)
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                            }
                            // Thực hiện chuyển dữ liệu
                            bulkCopy.WriteToServer(dataTable);
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật dữ liệu từ XML vào SQL: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



    }
}
