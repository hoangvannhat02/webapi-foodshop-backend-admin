using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaCungCapController : ControllerBase
    {
        INhaCungCapBLL db;
        public NhaCungCapController(INhaCungCapBLL db)
        {
            this.db = db;
        }
        [Route("get-all-sup")]
        [HttpGet]
        public List<NhaCungCap> getall()
        {
            return db.GetAll();
        }

        [Route("Get-Sup-Id")]
        [HttpGet]
        public NhaCungCap GetSupId(int id)
        {
            return db.GetSupId(id);
        }

        [Route("Add-Supplier")]
        [HttpPost]
        public IActionResult Create([FromBody] NhaCungCap ncc)
        {
            try
            {
                db.Create(ncc);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("Update-Supplier")]
        [HttpPut]
        public IActionResult Update([FromBody] NhaCungCap ncc)
        {
            try
            {
                db.Update(ncc);
                return Ok("Sửa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-supplier")]
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
