using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface INhaCungCapDAL
    {
        List<NhaCungCap> GetAll();
        NhaCungCap GetSupId(int id);
        void Create(NhaCungCap ncc);
        void Delete(int id);
        void Update(NhaCungCap sp);
        List<NhaCungCap> Search(int page, int pagesize, string nd);
    }
}
