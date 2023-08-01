using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ChiTietHoaDonBan
    {
        public int MaSanPham { get; set; }
        public int MaHoaDon { get; set; }
        public int SoLuong { get; set; }
        public float TamTinh { get; set; }
        public List<SanPham> sanPhams { get; set; }
    }
}
