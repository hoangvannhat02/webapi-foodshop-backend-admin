using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class HoaDonBan
    {
        public int MaHoaDon { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayTao { get; set; }
        public string DiaChiNhan { get; set; }
        public int TrangThai { get; set; }
        public string MoTa { get; set; }
        public float TongTien { get; set; }      
    }
   
}
