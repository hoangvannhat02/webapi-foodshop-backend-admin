using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        public ILoaiSanPhamBLL db;
        public LoaiSanPhamController(ILoaiSanPhamBLL db)
        {
            this.db = db;
        }
        [Route("get-all-category")]
        [HttpGet]
        public IActionResult GetAll() {
            try
            {
               var data = db.getalldata();
                return Ok(data);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
