
namespace QuanLyDongHo.Views
{
    partial class TrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chuyểnĐổiXMLSQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLSangXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhâuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_quanlytaikhoan = new System.Windows.Forms.Panel();
            this.btn_quanlyhoadon = new System.Windows.Forms.Panel();
            this.btn_quanlynhanvien = new System.Windows.Forms.Panel();
            this.btn_quanlysanpham = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTenDN = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dữLiệuToolStripMenuItem,
            this.tàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(816, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dữLiệuToolStripMenuItem
            // 
            this.dữLiệuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chuyểnĐổiXMLSQLToolStripMenuItem,
            this.sQLSangXMLToolStripMenuItem});
            this.dữLiệuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dữLiệuToolStripMenuItem.Name = "dữLiệuToolStripMenuItem";
            this.dữLiệuToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.dữLiệuToolStripMenuItem.Text = "Dữ liệu";
            // 
            // chuyểnĐổiXMLSQLToolStripMenuItem
            // 
            this.chuyểnĐổiXMLSQLToolStripMenuItem.Name = "chuyểnĐổiXMLSQLToolStripMenuItem";
            this.chuyểnĐổiXMLSQLToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chuyểnĐổiXMLSQLToolStripMenuItem.Text = "XML sang SQL";
            this.chuyểnĐổiXMLSQLToolStripMenuItem.Click += new System.EventHandler(this.chuyểnĐổiXMLSQLToolStripMenuItem_Click);
            // 
            // sQLSangXMLToolStripMenuItem
            // 
            this.sQLSangXMLToolStripMenuItem.Name = "sQLSangXMLToolStripMenuItem";
            this.sQLSangXMLToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sQLSangXMLToolStripMenuItem.Text = "SQL sang XML";
            this.sQLSangXMLToolStripMenuItem.Click += new System.EventHandler(this.sQLSangXMLToolStripMenuItem_Click);
            // 
            // tàiKhoảnToolStripMenuItem
            // 
            this.tàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đổiMậtKhâuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.tàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tàiKhoảnToolStripMenuItem.Name = "tàiKhoảnToolStripMenuItem";
            this.tàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.tàiKhoảnToolStripMenuItem.Text = "Tài khoản";
            // 
            // đổiMậtKhâuToolStripMenuItem
            // 
            this.đổiMậtKhâuToolStripMenuItem.Name = "đổiMậtKhâuToolStripMenuItem";
            this.đổiMậtKhâuToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.đổiMậtKhâuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhâuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhâuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // btn_quanlytaikhoan
            // 
            this.btn_quanlytaikhoan.BackColor = System.Drawing.SystemColors.Control;
            this.btn_quanlytaikhoan.BackgroundImage = global::QuanLyDongHo.Properties.Resources.taikhoan;
            this.btn_quanlytaikhoan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_quanlytaikhoan.Location = new System.Drawing.Point(466, 311);
            this.btn_quanlytaikhoan.Name = "btn_quanlytaikhoan";
            this.btn_quanlytaikhoan.Size = new System.Drawing.Size(263, 140);
            this.btn_quanlytaikhoan.TabIndex = 3;
            this.btn_quanlytaikhoan.Click += new System.EventHandler(this.btn_quanlytaikhoan_Click);
            // 
            // btn_quanlyhoadon
            // 
            this.btn_quanlyhoadon.BackColor = System.Drawing.SystemColors.Control;
            this.btn_quanlyhoadon.BackgroundImage = global::QuanLyDongHo.Properties.Resources.hoadon;
            this.btn_quanlyhoadon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_quanlyhoadon.Location = new System.Drawing.Point(87, 311);
            this.btn_quanlyhoadon.Name = "btn_quanlyhoadon";
            this.btn_quanlyhoadon.Size = new System.Drawing.Size(263, 140);
            this.btn_quanlyhoadon.TabIndex = 2;
            this.btn_quanlyhoadon.Click += new System.EventHandler(this.btn_quanlyhoadon_Click);
            // 
            // btn_quanlynhanvien
            // 
            this.btn_quanlynhanvien.BackColor = System.Drawing.SystemColors.Control;
            this.btn_quanlynhanvien.BackgroundImage = global::QuanLyDongHo.Properties.Resources.nhanvien;
            this.btn_quanlynhanvien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_quanlynhanvien.Location = new System.Drawing.Point(466, 97);
            this.btn_quanlynhanvien.Name = "btn_quanlynhanvien";
            this.btn_quanlynhanvien.Size = new System.Drawing.Size(263, 140);
            this.btn_quanlynhanvien.TabIndex = 2;
            this.btn_quanlynhanvien.Click += new System.EventHandler(this.btn_quanlynhanvien_Click);
            // 
            // btn_quanlysanpham
            // 
            this.btn_quanlysanpham.BackColor = System.Drawing.SystemColors.Control;
            this.btn_quanlysanpham.BackgroundImage = global::QuanLyDongHo.Properties.Resources.sanpham;
            this.btn_quanlysanpham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_quanlysanpham.Location = new System.Drawing.Point(87, 97);
            this.btn_quanlysanpham.Name = "btn_quanlysanpham";
            this.btn_quanlysanpham.Size = new System.Drawing.Size(263, 140);
            this.btn_quanlysanpham.TabIndex = 1;
            this.btn_quanlysanpham.Click += new System.EventHandler(this.btn_quanlysanpham_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(118, 250);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quản lý sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Quản lý hoá đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quản lý nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(511, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quản lý tài khoản";
            // 
            // lblTenDN
            // 
            this.lblTenDN.AutoSize = true;
            this.lblTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDN.Location = new System.Drawing.Point(12, 37);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(106, 24);
            this.lblTenDN.TabIndex = 8;
            this.lblTenDN.Text = "Xin chào, ";
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(816, 531);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_quanlytaikhoan);
            this.Controls.Add(this.btn_quanlyhoadon);
            this.Controls.Add(this.btn_quanlynhanvien);
            this.Controls.Add(this.btn_quanlysanpham);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrangChu";
            this.Text = "TrangChu";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chuyểnĐổiXMLSQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sQLSangXMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhâuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel btn_quanlysanpham;
        private System.Windows.Forms.Panel btn_quanlynhanvien;
        private System.Windows.Forms.Panel btn_quanlyhoadon;
        private System.Windows.Forms.Panel btn_quanlytaikhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTenDN;
    }
}