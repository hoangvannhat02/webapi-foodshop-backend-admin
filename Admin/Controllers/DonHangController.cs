using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        public IDonHangBLL db;
        public DonHangController(IDonHangBLL db)
        {
            this.db = db;
        }
        [Route("AddToCart")]
        [HttpPost]
        public IActionResult ThemVaoGioHang([FromBody] DonHangModel dh)
        {
            try
            {
                db.ThemVaoGioHang(dh);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
