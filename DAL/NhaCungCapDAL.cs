using DAL.Helper;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL:INhaCungCapDAL
    {
        public IDataHelper db;
        public NhaCungCapDAL(IDataHelper db)
        {
            this.db = db;
        }

      
        public NhaCungCap GetSupId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetSupById", "@Id", id);
                return sp.ConvertTo<NhaCungCap>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhaCungCap> GetAll()
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("getallsup");
                return sp.ConvertTo<NhaCungCap>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(NhaCungCap ncc)
        {
            DateTime dt = DateTime.Now;
            try
            {
                db.ExecuteProcedure("AddSup", "@hoten", ncc.HoTen,"@diachi",ncc.DiaChi,
                                    "@dienthoai",ncc.DienThoai,"@email",ncc.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(int id)
        {
            try
            {
                db.ExecuteProcedure("xoanhacungcap", "@Id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(NhaCungCap ncc)
        {
            try
            {
                db.ExecuteProcedure("suanhacungcap", "@Ma", ncc.MaNhaCungCap,
                                     "@hoten", ncc.HoTen, "@diachi", ncc.DiaChi,
                                    "@dienthoai", ncc.DienThoai, "@email", ncc.Email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NhaCungCap> Search(int page, int pagesize, string nd)
        {
            try
            {
                return db.ExcuteProcedureReturnDatatable("timkiem", "@Page", page,
                                                  "@Pagesize", pagesize,
                                                  "@Search", nd).ConvertTo<NhaCungCap>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
