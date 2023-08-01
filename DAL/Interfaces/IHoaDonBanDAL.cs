using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IHoaDonBanDAL
    {
        List<HoaDonBan> GetAll();
        List<SanPham> GetDataId(int id);
        void Delete(int id);
        void Update(HoaDonBan hdb);
        KhachHang GetCustomerId(int id);    
    }
}
