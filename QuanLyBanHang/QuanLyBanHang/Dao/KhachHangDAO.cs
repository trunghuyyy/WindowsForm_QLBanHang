using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Dao
{
    internal class KhachHangDAO
    {
        private BanHangDBContext context = new BanHangDBContext();
        public List<tblKhach> getListKH()
        {
            return context.tblKhaches.ToList();
        }

        public void insert(tblKhach khach)
        {
            context.tblKhaches.Add(khach);
            context.SaveChangesAsync();
        }

        public void update(tblKhach khach)
        {
            try
            {
                context.tblKhaches.Attach(khach);
                context.Entry(khach).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void delete(tblKhach khach)
        {
            context.tblKhaches.Remove(khach);
            context.SaveChanges();
        }

        public string getDiaChiKH(string maKH)
        {
            tblKhach khach = context.tblKhaches.FirstOrDefault(s => s.MaKhach == maKH);
            return khach.DiaChi;
        }
    }
}
