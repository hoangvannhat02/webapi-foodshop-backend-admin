using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHoaDonBanBLL
    {
        List<HoaDonBan> GetAll();
        List<SanPham> GetDataId(int id);
        void Delete(int id);
        void Update(HoaDonBan hdb);
        KhachHang GetCustomerId(int id);
    }
}
