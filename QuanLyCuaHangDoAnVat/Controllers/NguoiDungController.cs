using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
    
namespace QuanLyCuaHangDoAnVat.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        public INguoiDungBLL db;
        public AppSettings _appSettings;
        public NguoiDungController(INguoiDungBLL db, IOptions<AppSettings> appSettings)
        {
            this.db = db;
            _appSettings = appSettings.Value;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody] NguoiDung nd)
        {
            var dt = db.Authenticate(nd);
            if (dt == null)
            {
                return Ok(new { message = "Tài khoản hoặc mật khẩu không đúng" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, dt.HoTen),
                    //new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.DenyOnlyWindowsDeviceGroup, dt.PassWord)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tmp = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(tmp);
            return Ok(new { MaNguoiDung = dt.MaNguoiDung, HoTen = dt.HoTen, TaiKhoan = dt.UserName, Token = token });
        }

        [Route("get-all-users")]
        [HttpGet]
        public List<NguoiDung> getall()
        {
            return db.GetAll();
        }
        [Route("user-id")]
        [HttpGet]
        public NguoiDung getbyid(int id)
        {
            return db.GetDataId(id);
        }
        [Route("add-user")]
        [HttpPost]
        public IActionResult add([FromBody] NguoiDung nd)
        {
            try
            {
                db.create(nd);
                return Ok("Thêm thành công");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("edit-user")]
        [HttpPut]
        public IActionResult update([FromBody] NguoiDung nd)
        {
            try
            {
                db.update(nd);
                return Ok("Sửa thông tin người dùng thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("delete-user")]
        [HttpDelete]
        public IActionResult destroy(int id)
        {
            try
            {
                db.delete(id);
                return Ok("Đã xóa thông tin người dùng có mã "+id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
