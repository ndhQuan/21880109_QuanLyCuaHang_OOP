using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    public interface ILuuTruMatHang
    {
        List<MatHang> TimKiem(string tuKhoa, string theLoai);
        bool LuuMatHang(MatHang mh);
        List<MatHang> DocDanhSachMatHang();
        bool XoaMatHang(string Id);
        bool SuaMatHang(MatHang mh);

    }
}
