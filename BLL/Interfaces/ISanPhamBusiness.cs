using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISanPhamBusiness
    {
        SanPham GetProductId(int id);
        List<SanPham> GetAllData();
        void Create(SanPham sp);
        void Update(SanPham sp);
        void Delete(int id);
        List<SanPham> SanPhamMoi(int sl);
        List<SanPham> SanPhamBanChay(int sl);
        List<SanPham> SanPhamTheoMaLoai(int id);
        List<SanPham> Search(int page, int pagesize, string nd);
       
    }
}
