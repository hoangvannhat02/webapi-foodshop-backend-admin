using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILoaiSanPhamBLL
    {
        List<LoaiSanPham> getalldata();
        LoaiSanPham GetCategoryId(int id);
        void Create(LoaiSanPham sp);
        void Delete(int id);
        void Update(LoaiSanPham sp);
        List<LoaiSanPham> Search(int page, int pagesize, string nd);
    }
}
