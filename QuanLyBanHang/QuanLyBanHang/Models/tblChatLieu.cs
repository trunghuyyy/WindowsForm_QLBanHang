namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChatLieu")]
    public partial class tblChatLieu
    {
        [Key]
        [StringLength(10)]
        public string MaChatLieu { get; set; }

        [StringLength(50)]
        public string TenChatLieu { get; set; }
    }
}
