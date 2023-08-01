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
    public class LoaiSanPhamBLL:ILoaiSanPhamBLL
    {
        public ILoaiSanPhamDAL db;
        public LoaiSanPhamBLL(ILoaiSanPhamDAL db)
        {
            this.db = db;
        }
        public List<LoaiSanPham> getalldata()
        {
            return db.getalldata();
        }
        public LoaiSanPham GetCategoryId(int id)
        {
            return db.GetCategoryId(id);
        }
        public void Create(LoaiSanPham sp)
        {
            db.Create(sp);
        }
        public void Delete(int id)
        {
            db.Delete(id);
        }
        public void Update(LoaiSanPham sp)
        {
            db.Update(sp);
        }
        public List<LoaiSanPham> Search(int page, int pagesize, string nd)
        {
            return db.Search(page, pagesize, nd);
        }

    }
}
