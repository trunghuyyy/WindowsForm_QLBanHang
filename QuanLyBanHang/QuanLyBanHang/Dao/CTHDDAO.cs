using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanHang.Dao
{
    internal class CTHDDAO
    {
        private BanHangDBContext context = new BanHangDBContext();
        public List<CTHDSanPham> getListCTHDSanPhamByMaHD(string maHD)
        {
            List<CTHDSanPham> list = context.tblCTHDBans.Where(s => s.MaHDBan == maHD).Join(
                    context.tblHangs,
                    cthd => cthd.MaHang,
                    hang => hang.MaHang,
                    (cthd, hang) => new CTHDSanPham
                    {
                        MaHang = cthd.MaHang,
                        TenHang = hang.TenHang,
                        SoLuong = cthd.SoLuong,
                        DonGia = cthd.DonGia,
                        GiamGia = cthd.GiamGia,
                        ThanhTien = cthd.ThanhTien
                    }
                ).ToList();
            return list;
        }

        public void insert(tblCTHDBan cthd)
        {
            context.tblCTHDBans.Add(cthd);
            context.SaveChanges();
        }

        public bool checkKey(string maHang,string maHDBan)
        {
            List<tblCTHDBan> cthd = context.tblCTHDBans.Where(s => s.MaHDBan == maHDBan && s.MaHang == maHang).ToList();   
            if(cthd.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
