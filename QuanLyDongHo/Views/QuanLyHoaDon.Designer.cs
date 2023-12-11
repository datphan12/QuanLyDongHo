
namespace QuanLyDongHo.Views
{
    partial class QuanLyHoaDon
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamMoiHD = new System.Windows.Forms.Button();
            this.txtTimKiemMaHD = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách hoá đơn";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 104);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(918, 188);
            this.dgvHoaDon.TabIndex = 4;
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 424);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 51;
            this.dgvChiTietHoaDon.RowTemplate.Height = 24;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(918, 188);
            this.dgvChiTietHoaDon.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(341, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Chi tiết hoá đơn";
            // 
            // btnLamMoiHD
            // 
            this.btnLamMoiHD.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLamMoiHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiHD.Location = new System.Drawing.Point(358, 61);
            this.btnLamMoiHD.Name = "btnLamMoiHD";
            this.btnLamMoiHD.Size = new System.Drawing.Size(113, 35);
            this.btnLamMoiHD.TabIndex = 16;
            this.btnLamMoiHD.Text = "Làm mới";
            this.btnLamMoiHD.UseVisualStyleBackColor = false;
            this.btnLamMoiHD.Click += new System.EventHandler(this.btnLamMoiHD_Click);
            // 
            // txtTimKiemMaHD
            // 
            this.txtTimKiemMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemMaHD.Location = new System.Drawing.Point(113, 63);
            this.txtTimKiemMaHD.Name = "txtTimKiemMaHD";
            this.txtTimKiemMaHD.Size = new System.Drawing.Size(224, 28);
            this.txtTimKiemMaHD.TabIndex = 15;
            this.txtTimKiemMaHD.TextChanged += new System.EventHandler(this.txtTimKiemMaHD_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tìm kiếm";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(738, 298);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(191, 44);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "Thêm hoá đơn";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // QuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(941, 625);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnLamMoiHD);
            this.Controls.Add(this.txtTimKiemMaHD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.label1);
            this.Name = "QuanLyHoaDon";
            this.Text = "QuanLyHoaDon";
            this.Load += new System.EventHandler(this.QuanLyHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLamMoiHD;
        private System.Windows.Forms.TextBox txtTimKiemMaHD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnThem;
    }
}