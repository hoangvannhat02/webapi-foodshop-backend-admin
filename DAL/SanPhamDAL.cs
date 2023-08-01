using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Model;
using System.Drawing;
using DAL.Helper;
using System.Data;
using DAL.Helper.Interfaces;
using DAL.Interfaces;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using System.Xml.Linq;

namespace DAL
{
    
    public class SanPhamDAL:ISanPhamDAL
    {

        public IDataHelper db;
        public SanPhamDAL(IDataHelper dbhp)
        {
            db = dbhp;
        }
      
        public SanPham GetProductId(int id)
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetSanPhamById", "@Id", id);
                return sp.ConvertTo<SanPham>().FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPham> GetAllData()
        {
            try
            {
                var sp = db.ExcuteProcedureReturnDatatable("GetAllProduct");
                return sp.ConvertTo<SanPham>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(SanPham sp)
        {
            try
            {
                db.ExecuteProcedure("ThemMoi", "@name", sp.TenSanPham, "@maloai", sp.MaLoai, "@mota", sp.MoTa, "@anh", sp.Anh, "@motachitiet", sp.ChiTietSanPham,"@gia",sp.GiaBan,"@soluong",sp.SoLuong);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                db.ExecuteProcedure("xoasanpham", "@Id", id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void EditProduct(SanPham sp)
        {
            try
            {
                db.ExecuteProcedure("suasanpham", "@Ma", sp.MaSanPham,
                                     "@name", sp.TenSanPham,
                                     "@maloai", sp.MaLoai,
                                     "@mota", sp.MoTa,
                                     "@gia",sp.GiaBan,
                                     "@soluong",sp.SoLuong,
                                     "@anh", sp.Anh,
                                     "@motachitiet", sp.ChiTietSanPham);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<SanPham> SanPhamMoi(int sl)
        {
            return db.ExcuteProcedureReturnDatatable("SanPhamMoi", "@sl", sl).ConvertTo<SanPham>().ToList();
        }
        public List<SanPham> SanPhamBanChay(int sl)
        {
            return db.ExcuteProcedureReturnDatatable("SanPhamBanChay", "@sl", sl).ConvertTo<SanPham>().ToList();
        }
        public List<SanPham> SanPhamTheoMaLoai(int id)
        {
            return db.ExcuteProcedureReturnDatatable("get_product_categoryid", "@id", id).ConvertTo<SanPham>().ToList();
        }

        public List<SanPham> Search(int page,int pagesize,string nd)
        {
            try
            {
                return db.ExcuteProcedureReturnDatatable("timkiem", "@Page", page,
                                                  "@Pagesize", pagesize,
                                                  "@Search", nd).ConvertTo<SanPham>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
