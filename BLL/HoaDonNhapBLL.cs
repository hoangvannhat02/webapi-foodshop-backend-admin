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
    public class HoaDonNhapBLL:IHoaDonNhapBLL
    {
        public IHoaDonNhapDAL db;
        public HoaDonNhapBLL(IHoaDonNhapDAL db)
        {
            this.db = db;
        }
        public List<HoaDonNhap> GetAll()
        {
            return db.GetAll();
        }
        public HoaDonNhap GetDataId(int id)
        {
            return db.GetDataId(id);
        }
        public void Create(HoaDonNhap ncc)
        {
            db.Create(ncc);
        }
        public void Delete(int id)
        {
            db.Delete(id);
        }
        public void Update(HoaDonNhap ncc)
        {
            db.Update(ncc);
        }
    }
}
