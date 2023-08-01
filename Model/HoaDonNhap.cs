using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HoaDonNhap
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNhaCungCap { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime NgayNhap { get; set; }
        public List<ChiTietHoaDonNhap> listcthdn { get; set; }
        public NguoiDung nguoidung { get; set; }
        public NhaCungCap nhacungcap { get; set; }
    }
    public class ChiTietHoaDonNhap
    {
        public int MaHoaDonNhap { get; set; }
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public float GiaNhap { get; set; }
    }   
}
