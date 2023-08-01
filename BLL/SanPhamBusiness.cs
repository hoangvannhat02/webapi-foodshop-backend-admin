using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        public ISanPhamDAL dbsp;
        public SanPhamBusiness(ISanPhamDAL _dbsp)
        {
            dbsp = _dbsp;
        }
        public SanPham GetProductId(int id)
        {
            return dbsp.GetProductId(id);
        }
        public List<SanPham> GetAllData()
        {
            return dbsp.GetAllData();
        }
        public void Create(SanPham sp)
        {
            dbsp.Create(sp);
        }
        public void Delete(int id)
        {
            dbsp.DeleteProduct(id);
        }
        public void Update(SanPham sp)
        {
            dbsp.EditProduct(sp);
        }
        public List<SanPham> SanPhamMoi(int sl)
        {
            return dbsp.SanPhamMoi(sl);
        }
        public List<SanPham> SanPhamBanChay(int sl)
        {
            return dbsp.SanPhamBanChay(sl);
        }
        public List<SanPham> SanPhamTheoMaLoai(int id)
        {
            return dbsp.SanPhamTheoMaLoai(id);
        }
        public List<SanPham> Search(int page, int pagesize, string nd)
        {
            return dbsp.Search(page, pagesize, nd);
        }
       
    }
}