using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Services
{
    public class XuLyLoaiHang : IXuLyLoaiHang
    {
        public ILuuTruLoaiHang luuTruLoaiHang;
        public XuLyLoaiHang()
        {
            luuTruLoaiHang = new LuuTruLoaiHang();
        }
        public List<LoaiHang> TimKiem(string tuKhoa, string theLoai)
        {
            try
            {
                if (tuKhoa == null)
                {
                    tuKhoa = string.Empty;
                }
                return luuTruLoaiHang.TimKiem(tuKhoa, theLoai);
            }
            catch
            {
                return new List<LoaiHang>();
            }
        }
        public List<LoaiHang> DocDanhSachLoaiHang()
        {
            return luuTruLoaiHang.DocDanhSachLoaiHang();
        }
        public bool SuaLoaiHang(string id, string tenLoaiHang)
        {
            if(string.IsNullOrWhiteSpace(id)||
                string.IsNullOrWhiteSpace(tenLoaiHang))
            {
                return false;
            }
            return luuTruLoaiHang.SuaLoaiHang(id, tenLoaiHang);
        }
        public bool XoaLoaiHang(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }
            return luuTruLoaiHang.XoaLoaiHang(id);
        }
        public bool ThemLoaiHang(LoaiHang lhMoi)
        {
            if (string.IsNullOrWhiteSpace(lhMoi.MaLoaiHang) ||
                string.IsNullOrWhiteSpace(lhMoi.TenLoaiHang))
            {
                return false;
            }
            return luuTruLoaiHang.ThemLoaiHang(lhMoi);
        }

    }
}
