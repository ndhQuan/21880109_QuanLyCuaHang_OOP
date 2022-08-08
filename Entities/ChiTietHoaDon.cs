using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ChiTietHoaDon
    {
        public string MaMatHang { get; set; }
        public string TenMatHang { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public ChiTietHoaDon()
        {

        }
        public ChiTietHoaDon(string maMh, string tenMH, int soLuong, int donGia)
        {
            this.MaMatHang = maMh;
            this.TenMatHang = tenMH;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
        }
    }
}
