namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNhanVien")]
    public partial class tblNhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [StringLength(50)]
        public string TenNhanVien { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }

        public DateTime? NgaySinh { get; set; }
    }
}
