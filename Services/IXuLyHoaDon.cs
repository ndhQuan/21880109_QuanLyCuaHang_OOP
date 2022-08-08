using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IXuLyHoaDon
    {
        List<HoaDon> TimKiemHoaDonNhapHang(string tuKhoa, string Target);
        List<HoaDon> TimKiemHoaDonBanHang(string tuKhoa, string Target);
        bool TaoHoaDonBanHang(HoaDon hoaDonBan);
        bool TaoHoaDonNhapHang(HoaDon hoaDonNhap);
        List<HoaDon> DocDanhSachHoaDonBanHang();
        List<HoaDon> DocDanhSachHoaDonNhapHang();
        bool XoaHoaDonNhap(string Id);
        bool XoaHoaDonBan(string Id);
        bool SuaHoaDonNhapHang(HoaDon h);
        bool SuaHoaDonBanHang(HoaDon h);
        int TongSoLuongNhap(string MaMatHang);
        int TongSoLuongBan(string MaMatHang);

    }
}
