using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Dao
{
    internal class HoaDonDAO
    {
        private BanHangDBContext context = new BanHangDBContext();  
        public List<tblHDBan> getListHDBan()
        {
            return context.tblHDBans.ToList();  
        }

        public void insert(tblHDBan hdban)
        {
            context.tblHDBans.Add(hdban);
            context.SaveChanges();
        }

        public void update(tblHDBan hdban)
        {
            try
            {
                context.tblHDBans.Attach(hdban);
                context.Entry(hdban).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public tblHDBan getInfoHDbyMaHD(string maHD)
        {
            return context.tblHDBans.FirstOrDefault(s => s.MaHDBan == maHD);
        }

        public double getTongTienHDBan(string maHD)
        {
            tblHDBan hdBan = context.tblHDBans.FirstOrDefault(s => s.MaHDBan == maHD);
            if(hdBan != null)
            {
                return (double)hdBan.TongTien;
            }
            return 0;
        }

        public bool checkKey(string maHD)
        {
            List<tblHDBan> hd = context.tblHDBans.Where(s => s.MaHDBan == maHD).ToList();
            if(hd.Count > 0)
                return true;
            return false;
        }
    }
}
