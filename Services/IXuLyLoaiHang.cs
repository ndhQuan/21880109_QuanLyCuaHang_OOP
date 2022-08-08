using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IXuLyLoaiHang
    {
        List<LoaiHang> TimKiem(string tuKhoa, string theLoai);
        List<LoaiHang> DocDanhSachLoaiHang();
        bool SuaLoaiHang(string id, string tenLoaiHang);
        bool XoaLoaiHang(string Id);
        bool ThemLoaiHang(LoaiHang lhMoi);
    }
}
