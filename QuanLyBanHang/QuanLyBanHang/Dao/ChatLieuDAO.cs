using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Models;


namespace QuanLyBanHang.Dao
{
    internal class ChatLieuDAO
    {
        private BanHangDBContext context = new BanHangDBContext();
        public List<tblChatLieu> getList()
        {
            List<tblChatLieu> list = context.tblChatLieus.ToList();
            return list;
        }

        public void insert(tblChatLieu chatlieu)
        {
            context.tblChatLieus.Add(chatlieu);
            context.SaveChanges();
        }

        public void update(tblChatLieu chatlieu)
        {
            string maChatLieu = chatlieu.MaChatLieu;
            tblChatLieu chatLieuUpdate = context.tblChatLieus.FirstOrDefault(s => s.MaChatLieu == maChatLieu);
            if (chatLieuUpdate != null)
            {
                chatLieuUpdate.TenChatLieu = chatlieu.TenChatLieu;
                context.SaveChanges();
            }
        }

        public void delete(string machatlieu)
        {
            tblChatLieu chatLieuDelete = context.tblChatLieus.FirstOrDefault(s => s.MaChatLieu == machatlieu);
            if (chatLieuDelete != null)
            {
                context.tblChatLieus.Remove(chatLieuDelete);
                context.SaveChanges();
            }
        }

        public string getTenChatLieu(string ma)
        {
            tblChatLieu chatlieu = context.tblChatLieus.FirstOrDefault(s => s.MaChatLieu == ma);
            return chatlieu.TenChatLieu;
        }
    }
}
