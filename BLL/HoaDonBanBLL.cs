using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HoaDonBanBLL:IHoaDonBanBLL
    {
        public IHoaDonBanDAL db;
        public HoaDonBanBLL(IHoaDonBanDAL db)
        {
            this.db = db;
        }
        public List<HoaDonBan> GetAll()
        {
            return db.GetAll();
        }
        public List<SanPham> GetDataId(int id)
        {
            return db.GetDataId(id);
        }
       
        public void Delete(int id)
        {
            db.Delete(id);
        }
        public void Update(HoaDonBan hd)
        {
            db.Update(hd);
        }
        public KhachHang GetCustomerId(int id)
        {
            return db.GetCustomerId(id);
        }
    }
}
