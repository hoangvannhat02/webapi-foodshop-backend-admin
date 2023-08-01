using BLL;
using BLL.Interfaces;
using DAL;
using DAL.Helper;
using DAL.Helper.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {

        
        public ISanPhamBusiness db;
        private readonly IWebHostEnvironment _env;
        public SanPhamController(ISanPhamBusiness _db, IWebHostEnvironment env)
        {
            db = _db;
            _env = env;
        }
       

        [Route("Get-Product-Id/{id}")]
        [HttpGet]
        public SanPham GetProductId(int id)
        {         
                return db.GetProductId(id);
        }

        [Route("Get-all-product")]
        [HttpGet]
        public List<SanPham> GetAllProduct()
        {
            return db.GetAllData();
        }

        [Route("Upload-file")]
        [HttpPost]  
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File không tồn tại");

            var webRootPath = _env.WebRootPath;
            var uploadsFolder = Path.Combine(webRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"/uploads/{fileName}";

            return Ok(imageUrl);
        }
        
        [Route("Them-SanPham")]
        [HttpPost]
        public IActionResult Create([FromBody] SanPham sp)
        {
            try
            {
                db.Create(sp);
                return Ok("Thêm thành công");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
                
        }
        [Route("Sua-SanPham")]
        [HttpPut]
        public IActionResult EditProduct([FromBody] SanPham sp)
        {
            try
            {
                db.Update(sp);
                return Ok("Sửa thành công");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Xoa-SanPham")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                db.Delete(id);
                return Ok("Xóa thành công");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [Route("Tim-Kiem")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string,object> formdata) {
            SearchModel s = new SearchModel();
            try
            {
                var page = int.Parse(formdata["page"].ToString());
                var pagesize = int.Parse(formdata["pagesize"].ToString());
                string search = "";
                if(formdata.Keys.Contains("search") && !string.IsNullOrEmpty(formdata["search"].ToString()))
                {
                    search = Convert.ToString(formdata["search"]);
                }
                var data = db.Search(page, pagesize, search);
                var lt = data.Count();
                return Ok( new { results = data , totalCount = lt});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }      
    }
}
