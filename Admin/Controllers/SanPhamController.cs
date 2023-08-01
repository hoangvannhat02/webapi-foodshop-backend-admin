using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {

        ISanPhamBusiness db;
        public SanPhamController(ISanPhamBusiness db)
        {
            this.db = db;
        }

        [Route("Get-all-product")]
        [HttpGet]
        public List<SanPham> GetAllData()
        {
            return db.GetAllData();
        }

        [Route("New-Product/{sl}")]
        [HttpGet]
        public List<SanPham> SanPhamMoi(int sl)
        {
            return db.SanPhamMoi(sl);
        }

        [Route("selling-product")]
        [HttpGet]
        public List<SanPham> SanPhamBanChay(int sl)
        {
            return db.SanPhamBanChay(sl);
        }

        [Route("get-product-maloai")]
        [HttpGet]
        public List<SanPham> SanPhamTheoMaLoai(int id)
        {
            return db.SanPhamTheoMaLoai(id);
        }
    }
}
