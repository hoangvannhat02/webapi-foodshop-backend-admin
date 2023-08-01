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
    public class NguoiDungDAL:ILogin
    {
        public IDataHelper db;
        public NguoiDungDAL(IDataHelper db)
        {
            this.db = db;
        }

        public NguoiDung Authenticate(NguoiDung nd)
        {
            return db.ExcuteProcedureReturnDatatable("Check_Login","@tk",nd.UserName,
                                                        "@mk",nd.PassWord).ConvertTo<NguoiDung>().FirstOrDefault();
        }
        public NguoiDung GetDataId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetUserById", "@Id", id);
                return sp.ConvertTo<NguoiDung>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NguoiDung> GetAll()
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetAllUsers");
                return sp.ConvertTo<NguoiDung>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void create(NguoiDung nd)
        {
            DateTime dt = DateTime.Now;
            try
            {
                db.ExecuteProcedure("AddUser", "@name", nd.HoTen, "@username", nd.UserName, 
                    "@password", nd.PassWord, "@ngaytao", nd.NgayTao = dt, "@dienthoai", nd.DienThoai, 
                    "@anh", nd.Anh, "@diachi", nd.DiaChi, "@trangthai",nd.TrangThai = true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(int id)
        {
            try
            {
                db.ExecuteProcedure("xoanguoidung", "@Id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(NguoiDung nd)
        {
            try
            {
                db.ExecuteProcedure("suanguoidung", "@Ma", nd.MaNguoiDung,
                                     "@name", nd.HoTen, "@username", nd.UserName, "@password", nd.PassWord, "@ngaytao", nd.NgayTao, "@dienthoai", nd.DienThoai, "@anh", nd.Anh, "@diachi", nd.DiaChi, "@trangthai", nd.TrangThai);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<NguoiDung> Search(int page, int pagesize, string ten, string sdt, string email)
        {
            try
            {
                return db.ExcuteProcedureReturnDatatable("timkiem", "@Page", page,
                                                  "@Pagesize", pagesize,
                                                  "@Search", ten).ConvertTo<NguoiDung>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
