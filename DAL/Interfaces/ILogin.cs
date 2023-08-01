using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ILogin
    {
       NguoiDung Authenticate(NguoiDung nd);
        List<NguoiDung> GetAll();
        NguoiDung GetDataId(int id);
        void create(NguoiDung nd);
        void update(NguoiDung nd);
        void delete(int id);
        List<NguoiDung> Search(int page, int pagesize, string ten, string sdt, string email);
    }
}
