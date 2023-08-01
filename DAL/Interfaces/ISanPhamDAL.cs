using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Interfaces
{
    public interface ISanPhamDAL
    {
        SanPham GetProductId(int id);
        List<SanPham> GetAllData();
        void Create(SanPham sp);
        void DeleteProduct(int id);
        void EditProduct(SanPham sp);
        List<SanPham> SanPhamMoi(int sl);
        List<SanPham> SanPhamBanChay(int sl);
        List<SanPham> SanPhamTheoMaLoai(int id);
        List<SanPham> Search(int page, int pagesize, string nd);      
    }
}
