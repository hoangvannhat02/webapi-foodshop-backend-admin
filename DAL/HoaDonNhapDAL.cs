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
    public class HoaDonNhapDAL:IHoaDonNhapDAL
    {
        public IDataHelper db;
        public HoaDonNhapDAL(IDataHelper db)
        {
            this.db = db;
        }


        public HoaDonNhap GetDataId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetInputBillId", "@Id", id);
                return sp.ConvertTo<HoaDonNhap>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HoaDonNhap> GetAll()
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("getallinputbill");
                return sp.ConvertTo<HoaDonNhap>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(HoaDonNhap hdn)
        {
            DateTime dt = DateTime.Now;
            try
            {
                db.ExecuteProcedure("AddInputBill", "@mancc",hdn.MaNhaCungCap,"@manguoidung",hdn.MaNguoiDung,
                                    "@ngaynhap",hdn.NgayNhap = dt);
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
                db.ExecuteProcedure("xoahoadonnhap", "@Id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(HoaDonNhap hdn)
        {
            try
            {
                db.ExecuteProcedure("suahoadonnhap", "@Ma", hdn.MaHoaDonNhap,
                                    "@mancc", hdn.MaNhaCungCap, "@manguoidung", hdn.MaNguoiDung,
                                    "@ngaynhap", hdn.NgayNhap);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
