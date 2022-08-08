using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Services
{
    public interface IXuLyMatHang
    {
        List<MatHang> TimKiem(string TuKhoa, string theLoai);
        bool ThemMatHang(MatHang mh);
        List<MatHang> DocDanhSachMatHang();
        bool XoaMatHang(string Id);
        bool SuaMatHang(string Id, string TenMatHang, string HanDung, string CtySX, string NgaySX, string LoaiHang, int Gia);
        string ThemTenMatHang(string MaMatHang);
        int ThemDonGiaMatHang(string MaMatHang);
        List<MatHang> TimKiemHangTonTheoLoai(string LoaiHang);
        List<MatHang> ThongKeHetHan();
    }
}
