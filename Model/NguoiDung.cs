using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NguoiDung
    {
        public int MaNguoiDung { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? Anh { get; set; }    
        public string HoTen { get; set; }
        public string? DienThoai { get; set; }
        public string? DiaChi { get; set; }
        public bool? TrangThai { get; set; }
    }
}
