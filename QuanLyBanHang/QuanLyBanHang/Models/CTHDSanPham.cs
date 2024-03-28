using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.Models
{
    internal class CTHDSanPham
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }

        public double? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public double? GiamGia { get; set; }

        public double? ThanhTien { get; set; }
    }
}
