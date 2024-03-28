namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKhach")]
    public partial class tblKhach
    {
        [Key]
        [StringLength(10)]
        public string MaKhach { get; set; }

        [StringLength(50)]
        public string TenKhach { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        public string DienThoai { get; set; }
    }
}
