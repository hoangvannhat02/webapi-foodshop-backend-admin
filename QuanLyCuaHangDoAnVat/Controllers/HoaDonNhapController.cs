using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        IHoaDonNhapBLL db;
        public HoaDonNhapController(IHoaDonNhapBLL db)
        {
            this.db = db;
        }
        [Route("get-all-input-bill")]
        [HttpGet]
        public List<HoaDonNhap> getall()
        {
            return db.GetAll();
        }

        [Route("Get-Input-Bill-Id")]
        [HttpGet]
        public HoaDonNhap GetSupId(int id)
        {
            return db.GetDataId(id);
        }

        [Route("Add-Input-Bill")]
        [HttpPost]
        public IActionResult Create([FromBody] HoaDonNhap hdn)
        {
            try
            {
                db.Create(hdn);
                return Ok("Thêm thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("Update-Input-Bill")]
        [HttpPut]
        public IActionResult Update([FromBody] HoaDonNhap hdn)
        {
            try
            {
                db.Update(hdn);
                return Ok("Sửa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-input-bill")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Delete(id);
                return Ok("Xóa thành công hóa đơn có mã id = "+id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
