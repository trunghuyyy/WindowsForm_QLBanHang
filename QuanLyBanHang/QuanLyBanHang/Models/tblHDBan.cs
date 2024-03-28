namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHDBan")]
    public partial class tblHDBan
    {
        [Key]
        [StringLength(50)]
        public string MaHDBan { get; set; }

        [StringLength(10)]
        public string MaNhanVien { get; set; }

        public DateTime? NgayBan { get; set; }

        [StringLength(10)]
        public string MaKhach { get; set; }

        public double? TongTien { get; set; }
    }
}
