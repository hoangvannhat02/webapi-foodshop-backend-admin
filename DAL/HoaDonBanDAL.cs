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
    public class HoaDonBanDAL:IHoaDonBanDAL
    {
        public IDataHelper db;
        public HoaDonBanDAL(IDataHelper db)
        {
            this.db = db;
        }


        public List<SanPham> GetDataId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("get_all_detail_output_bill_id", "@id", id);
                return sp.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<HoaDonBan> GetAll()
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("getallbill");
                return sp.ConvertTo<HoaDonBan>().ToList();
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

        public KhachHang GetCustomerId(int id)
        {
            try
            {
                return db.ExcuteProcedureReturnDatatable("getdatacusid", "@Id", id).ConvertTo<KhachHang>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(HoaDonBan hdb)
        {
            try
            {
                db.ExecuteProcedure("suahoadonnhap", "@Ma");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
