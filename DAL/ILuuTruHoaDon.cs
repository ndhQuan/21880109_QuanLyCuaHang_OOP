using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface ILuuTruHoaDon
    {
        List<HoaDon> TimKiemHoaDonNhap(string tuKhoa, string Target);
        List<HoaDon> TimKiemHoaDonBan(string tuKhoa, string Target);
        bool LuuHoaDonBanHang(HoaDon h);
        bool LuuHoaDonNhapHang(HoaDon h);
        List<HoaDon> DocDanhSachHoaDonBanHang();
        List<HoaDon> DocDanhSachHoaDonNhapHang();
        bool LuuDanhSachHoaDonNhapHang(List<HoaDon> h);
        bool LuuDanhSachHoaDonBanHang(List<HoaDon> h);
        bool SuaHoaDonNhap(HoaDon a);
        bool SuaHoaDonBan(HoaDon a);

    }
}
