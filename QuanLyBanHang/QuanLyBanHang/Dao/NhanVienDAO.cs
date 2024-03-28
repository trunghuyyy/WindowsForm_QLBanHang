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
    internal class NhanVienDAO
    {
        private BanHangDBContext context = new BanHangDBContext();

        public List<tblNhanVien> getListNV()
        {
            return context.tblNhanViens.ToList();
        }

        public void insert(tblNhanVien nhanvien)
        {
            context.tblNhanViens.Add(nhanvien);
            context.SaveChanges();
        }

        public void update(tblNhanVien nhanvien)
        {
            if (nhanvien != null)
            {
                try
                {
                    context.tblNhanViens.Attach(nhanvien);
                    context.Entry(nhanvien).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Thông báo");
                }
            }
        }

        public void delete(tblNhanVien nhanVien)
        {
            context.tblNhanViens.Remove(nhanVien);
            context.SaveChanges();
        }
    }
}
