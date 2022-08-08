using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string NgayTaoHoaDon { get; set; }
        public List<ChiTietHoaDon> ChiTiet { get; set; }
        public HoaDon()
        {

        }
        public HoaDon(string maHoaDon, string ngayTaoHoaDon, List<ChiTietHoaDon> chiTiet)
        {
            var myDir = Environment.CurrentDirectory;
            this.MaHoaDon = maHoaDon;
            this.NgayTaoHoaDon = NgayTaoHoaDon;
            this.ChiTiet = chiTiet;
        }
    }
}
