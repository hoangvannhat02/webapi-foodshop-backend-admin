using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        ILoaiSanPhamBLL db;
        public LoaiSanPhamController(ILoaiSanPhamBLL db)
        {
            this.db = db;
        }
        [Route("get-all-cate")]
        [HttpGet]
        public List<LoaiSanPham> getall()
        {
            return db.getalldata();
        }

        [Route("Get-Category-Id")]
        [HttpGet]
        public LoaiSanPham GetCateId(int id)
        {
            return db.GetCategoryId(id);
        }

        [Route("Add-Category")]
        [HttpPost]
        public IActionResult Create([FromBody] LoaiSanPham lsp)
        {
            try
            {
                db.Create(lsp);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("Update-Category")]
        [HttpPut]
        public IActionResult Update([FromBody] LoaiSanPham lsp)
        {
            try
            {
                db.Update(lsp);
                return Ok("Sửa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-category")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Delete(id);
                return Ok("Xóa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Tim-Kiem")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formdata)
        {
            SearchModel s = new SearchModel();
            try
            {
                var page = int.Parse(formdata["page"].ToString());
                var pagesize = int.Parse(formdata["pagesize"].ToString());
                string search = "";
                if (formdata.Keys.Contains("search") && !string.IsNullOrEmpty(formdata["search"].ToString()))
                {
                    search = Convert.ToString(formdata["search"]);
                }
                var data = db.Search(page, pagesize, search);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
