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
    public class NguoiDungBLL:INguoiDungBLL
    {
        public ILogin db;
        public NguoiDungBLL(ILogin db)
        {
            this.db = db;
        }
        public NguoiDung Authenticate(NguoiDung nd)
        {
            return db.Authenticate(nd);
        }
        public List<NguoiDung> GetAll()
        {
            return db.GetAll();
        }
        public NguoiDung GetDataId(int id)
        {
            return db.GetDataId(id);
        }

        public void create(NguoiDung nd)
        {
            db.create(nd);
        }
        public void update(NguoiDung nd)
        {
            db.update(nd);
        }
        public void delete(int id)
        {
            db.delete(id);
        }
        public List<NguoiDung> Search(int page, int pagesize, string ten, string sdt, string email)
        {
            return db.Search(page, pagesize, ten,sdt,email);
        }
    }
}
