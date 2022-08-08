using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DAL;

namespace Services
{
    public class XuLyHoaDon : IXuLyHoaDon
    {
        private ILuuTruHoaDon luuTruHoaDon;
        public XuLyHoaDon()
        {
            luuTruHoaDon = new LuuTruHoaDon();
        }
        public List<HoaDon> TimKiemHoaDonNhapHang(string tuKhoa, string Target)
        {
            try
            {
                if (tuKhoa == null)
                {
                    tuKhoa = string.Empty;
                }
                return luuTruHoaDon.TimKiemHoaDonNhap(tuKhoa, Target);
            }
            catch
            {
                return new List<HoaDon>();
            }
        }

        public List<HoaDon> TimKiemHoaDonBanHang(string tuKhoa, string Target)
        {
            try
            {
                if (tuKhoa == null)
                {
                    tuKhoa = string.Empty;
                }
                return luuTruHoaDon.TimKiemHoaDonBan(tuKhoa, Target);
            }
            catch
            {
                return new List<HoaDon>();
            }

        }
        public bool TaoHoaDonBanHang(HoaDon hoaDonBan)
        {
            if (string.IsNullOrWhiteSpace(hoaDonBan.MaHoaDon) ||
                string.IsNullOrWhiteSpace(hoaDonBan.NgayTaoHoaDon)
                )
            {
                return false;
            }
            return luuTruHoaDon.LuuHoaDonBanHang(hoaDonBan);
        }
        public bool TaoHoaDonNhapHang(HoaDon hoaDonNhap)
        {
            if (string.IsNullOrWhiteSpace(hoaDonNhap.MaHoaDon) ||
               string.IsNullOrWhiteSpace(hoaDonNhap.NgayTaoHoaDon)
               )
            {
                return false;
            }
            luuTruHoaDon.LuuHoaDonNhapHang(hoaDonNhap);
            return true;

        }
        public List<HoaDon> DocDanhSachHoaDonBanHang()
        {
            return luuTruHoaDon.DocDanhSachHoaDonBanHang();
        }
        public List<HoaDon> DocDanhSachHoaDonNhapHang()
        {
            return luuTruHoaDon.DocDanhSachHoaDonNhapHang();
        }
        public bool XoaHoaDonNhap(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return false;
            List<HoaDon> dshdn = luuTruHoaDon.DocDanhSachHoaDonNhapHang();
            for (int i = 0; i < dshdn.Count; i++)
            {
                if (dshdn[i].MaHoaDon == Id)
                {
                    dshdn.RemoveAt(i);
                    luuTruHoaDon.LuuDanhSachHoaDonNhapHang(dshdn);
                    return true;
                }
            }
            return false;
        }
        public bool XoaHoaDonBan(string Id)
        {
            if (string.IsNullOrEmpty(Id)) return false;
            List<HoaDon> dshdb = luuTruHoaDon.DocDanhSachHoaDonBanHang();
            for (int i = 0; i < dshdb.Count; i++)
            {
                if (dshdb[i].MaHoaDon == Id)
                {
                    dshdb.RemoveAt(i);
                    luuTruHoaDon.LuuDanhSachHoaDonBanHang(dshdb);
                    return true;
                }
            }
            return false;

        }

        public bool SuaHoaDonNhapHang(HoaDon h)
        {
            List<HoaDon> dshdn = luuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach (HoaDon a in dshdn)
            {
                if (a.MaHoaDon == h.MaHoaDon)
                {
                    for (int i = 0; i < a.ChiTiet.Count; i++)
                    {
                        a.ChiTiet[i] = h.ChiTiet[i];
                    }
                    return luuTruHoaDon.SuaHoaDonNhap(a);
                }
            }
            return false;
        }
        public bool SuaHoaDonBanHang(HoaDon h)
        {
            List<HoaDon> dshdb = luuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon a in dshdb)
            {
                if (a.MaHoaDon == h.MaHoaDon)
                {
                    for (int i = 0; i < a.ChiTiet.Count; i++)
                    {
                        a.ChiTiet[i] = h.ChiTiet[i];
                    }
                    return luuTruHoaDon.SuaHoaDonBan(a);
                }
            }
            return false;

        }
        public int TongSoLuongNhap(string maMatHang)
        {
            int tongSoLuongNhap = 0;
            List<HoaDon> dshdNhap = luuTruHoaDon.DocDanhSachHoaDonNhapHang();
            foreach (HoaDon h in dshdNhap)
            {
                foreach (ChiTietHoaDon ct in h.ChiTiet)
                {
                    if (ct.MaMatHang == maMatHang)
                    {
                        tongSoLuongNhap += ct.SoLuong;
                    }
                }
            }
            return tongSoLuongNhap;
        }
        public int TongSoLuongBan(string maMatHang)
        {
            int tongSoLuongBan = 0;
            List<HoaDon> dshdBan = luuTruHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon h in dshdBan)
            {
                foreach (ChiTietHoaDon ct in h.ChiTiet)
                {
                    if (ct.MaMatHang == maMatHang)
                    {
                        tongSoLuongBan += ct.SoLuong;
                    }
                }
            }
            return tongSoLuongBan;
        }

    }
}
