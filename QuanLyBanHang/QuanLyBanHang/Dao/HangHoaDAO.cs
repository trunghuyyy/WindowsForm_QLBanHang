using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.Dao
{
    internal class HangHoaDAO
    {
        private BanHangDBContext context = new BanHangDBContext();
        public List<tblHang> getListHang()
        {
            return context.tblHangs.ToList();
        }

        public void insert(tblHang hang)
        {
            context.tblHangs.Add(hang);
            context.SaveChanges();
        }

        public void update(tblHang hang)
        {
            try
            {
                context.tblHangs.Attach(hang);
                context.Entry(hang).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void delete(tblHang hang)
        {
            context.tblHangs.Remove(hang);
            context.SaveChanges();
        }

        public List<tblHang> search(string ma, string ten, string maCL)
        {
            List<tblHang> list = context.tblHangs.Where(s => s.MaHang.Contains(ma) || s.TenHang.Contains(ten) || s.MaChatLieu.Contains(maCL)).ToList();
            if(list.Count == 0)
            {
                return null;
            }
            else
            {
                return list;
            }
        }
        public string getAnh(string ma)
        {
            tblHang hang = context.tblHangs.FirstOrDefault(s => s.MaHang == ma);
            return hang.Anh;
        }

        public string getGhiChu(string ma)
        {
            tblHang hang = context.tblHangs.FirstOrDefault(s => s.MaHang == ma);
            return hang.GhiChu;
        }

        public bool CheckKey(string ma)
        {
            tblHang hang = context.tblHangs.FirstOrDefault(s => s.MaHang == ma);
            if (hang != null)
                return true;
            return false;
        }

        public double getSLTon(string maHang)
        {
            tblHang hang = context.tblHangs.FirstOrDefault(s => s.MaHang == maHang);
            if (hang != null)
                return Convert.ToDouble(hang.SoLuong);
            return 0;
        }
    }
}
