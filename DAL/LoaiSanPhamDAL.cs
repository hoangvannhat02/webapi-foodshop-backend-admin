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
    public class LoaiSanPhamDAL:ILoaiSanPhamDAL
    {
        public IDataHelper db;
        public LoaiSanPhamDAL(IDataHelper db)
        {
            this.db = db;
        }
        public List<LoaiSanPham> getalldata()
        {
            return db.ExcuteProcedureReturnDatatable("get_all_data_category").ConvertTo<LoaiSanPham>().ToList();
        }
        public LoaiSanPham GetCategoryId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetCateById", "@Id", id);
                return sp.ConvertTo<LoaiSanPham>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public void Create(LoaiSanPham sp)
        {
            try
            {
                db.ExecuteProcedure("AddCategory", "@tenloai",sp.TenLoai,"@mota",sp.MoTa);
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
                db.ExecuteProcedure("xoaloaisanpham", "@Id", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(LoaiSanPham sp)
        {
            try
            {
                db.ExecuteProcedure("sualoaisanpham", "@Ma",sp.MaLoai,
                                    "@tenloai",sp.TenLoai,
                                    "@mota",sp.MoTa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LoaiSanPham> Search(int page, int pagesize, string nd)
        {
            try
            {
                return db.ExcuteProcedureReturnDatatable("timkiem", "@Page", page,
                                                  "@Pagesize", pagesize,
                                                  "@Search", nd).ConvertTo<LoaiSanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
