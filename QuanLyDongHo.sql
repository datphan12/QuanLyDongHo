DROP DATABASE QUANLYDONGHO
GO
CREATE DATABASE QUANLYDONGHO
GO
USE QUANLYDONGHO
GO
-- Tạo bảng Nhân viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) PRIMARY KEY,
    TenNV NVARCHAR(50) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(100),
    SoDienThoai VARCHAR(10),
    Email VARCHAR(50) CHECK (Email LIKE '%_@__%.__%')
);

-- Tạo bảng Tài khoản Nhân viên
CREATE TABLE TaiKhoanNhanVien (
    MaTK VARCHAR(10) PRIMARY KEY,
    TenTK VARCHAR(50) NOT NULL,
    MatKhau VARCHAR(50) NOT NULL,
    MaNV VARCHAR(10),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

-- Tạo bảng Sản phẩm
CREATE TABLE SanPham (
    MaSP VARCHAR(10) PRIMARY KEY,
    TenSP NVARCHAR(100) NOT NULL,
	MoTa NVARCHAR(100),
	SoLuong INT,
    GiaTien BIGINT NOT NULL
);

-- Tạo bảng Hoá đơn
CREATE TABLE HoaDon (
    MaHD VARCHAR(10) PRIMARY KEY,
    NgayLap DATE NOT NULL CHECK (NgayLap <= GETDATE()),
    MaNV VARCHAR(10),
	TenKH NVARCHAR(50),
	TongTien DECIMAL(18, 2) CHECK (TongTien>=0),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
	ON UPDATE CASCADE
	ON DELETE CASCADE
);

-- Tạo bảng Chi tiết Hoá đơn
CREATE TABLE ChiTietHoaDon (
    MaHD VARCHAR(10),
    MaSP VARCHAR(10),
    SoLuong INT
		CONSTRAINT check_soluong CHECK (SoLuong>=0),
    DonGia BIGINT
		CONSTRAINT check_dongia CHECK (DonGia>=0),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
	ON UPDATE CASCADE
	ON DELETE CASCADE,
	PRIMARY KEY(MaHD, MaSP)
);

-- Thêm dữ liệu vào bảng Nhân viên
INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, DiaChi, SoDienThoai, Email)
VALUES ('NV001', N'Phan Minh Đạt', '2003-09-24', N'Quảng Nam', '0123456789', 'phanminhdat@gmail.com'),
	('NV002', N'Nguyễn Văn A', '2003-09-30', N'Đà Nẵng', '0123456789', 'phanminhdata@gmail.com');
GO
-- Thêm dữ liệu vào bảng Tài khoản Nhân viên
INSERT INTO TaiKhoanNhanVien (MaTK, TenTK, MatKhau, MaNV)
VALUES ('TK001','nhanvien1', 'nhanvien1', 'NV001'),
	('TK002','nhanvien2', 'nhanvien2', 'NV002');
GO
INSERT INTO SanPham (MaSP, TenSP, MoTa, SoLuong, GiaTien)
VALUES
    ('SP001', N'Đồng hồ thông minh', N'Mô tả sản phẩm 1', 10, 3000000),
    ('SP002', N'Đồng hồ cơ', N'Mô tả sản phẩm 2', 15, 2000000),
    ('SP003', N'Đồng hồ đeo tay', N'Mô tả sản phẩm 3', 20, 1500000),
    ('SP004', N'Đồng hồ thể thao', N'Mô tả sản phẩm 4', 8, 4000000),
    ('SP005', N'Đồng hồ nữ', N'Mô tả sản phẩm 5', 12, 2500000);

GO
-- Thêm dữ liệu vào bảng Hoá đơn
INSERT INTO HoaDon (MaHD, NgayLap, MaNV, TenKH, TongTien)
VALUES
    ('HD001', '2023-11-27', 'NV001', N'Nguyễn Văn B', 8000000),
    ('HD002', '2023-11-26', 'NV001', N'Nguyễn Văn C', 13500000);

-- Thêm dữ liệu vào bảng Chi tiết Hoá đơn
INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia)
VALUES
    ('HD001', 'SP001', 2, 3000000),
    ('HD001', 'SP002', 1, 2000000),
    ('HD002', 'SP003', 3, 1500000),
    ('HD002', 'SP004', 1, 4000000),
    ('HD002', 'SP005', 2, 2500000);