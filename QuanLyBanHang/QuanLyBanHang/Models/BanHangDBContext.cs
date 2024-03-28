using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyBanHang.Models
{
    public partial class BanHangDBContext : DbContext
    {
        public BanHangDBContext()
            : base("name=BanHangDBContext")
        {
        }

        public virtual DbSet<tblChatLieu> tblChatLieus { get; set; }
        public virtual DbSet<tblCTHDBan> tblCTHDBans { get; set; }
        public virtual DbSet<tblHang> tblHangs { get; set; }
        public virtual DbSet<tblHDBan> tblHDBans { get; set; }
        public virtual DbSet<tblKhach> tblKhaches { get; set; }
        public virtual DbSet<tblNhanVien> tblNhanViens { get; set; }
    }
}
