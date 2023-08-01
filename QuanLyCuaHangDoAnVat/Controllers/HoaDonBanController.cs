using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonBanController : ControllerBase
    {
        IHoaDonBanBLL db;
        ISanPhamBusiness sp;
        public HoaDonBanController(IHoaDonBanBLL db,ISanPhamBusiness sp)
        {
            this.db = db;
            this.sp = sp;
        }
        [Route("get-all-output-bill")]
        [HttpGet]
        public List<HoaDonBan> getall()
        {
            return db.GetAll();
        }

        [Route("Get-Output-Bill-Id")]
        [HttpGet]
        public List<SanPham> GetId(int id)
        {
            return db.GetDataId(id);
        }
        [Route("Get-Customer-Id")]
        [HttpGet]
        public KhachHang GetCustomerId(int id)
        {
            return db.GetCustomerId(id);
        }

        [Route("Update-Output-Bill")]
        [HttpPut]
        public IActionResult Update([FromBody] HoaDonBan hd)
        {
            try
            {
                db.Update(hd);
                return Ok("Sửa thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("delete-output-bill")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                db.Delete(id);
                return Ok("Xóa thành công hóa đơn có mã id = " + id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
