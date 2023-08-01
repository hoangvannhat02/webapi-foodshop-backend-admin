using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IHoaDonNhapBLL
    {
        List<HoaDonNhap> GetAll();
        HoaDonNhap GetDataId(int id);
        void Create(HoaDonNhap hdn);
        void Delete(int id);
        void Update(HoaDonNhap hdn);
    }
}
