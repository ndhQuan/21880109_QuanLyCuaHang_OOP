using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities;
using Services;

namespace _21880109_QuanLyCuaHang_LTHDT.Pages
{
    public class MH_SuaHoaDonBanHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        private IXuLyMatHang xuLyMatHang;
        public string Chuoi;
        public List<MatHang> dsmh;
        public HoaDon HoaDonBan;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        [BindProperty]
        public string NgayTao { get; set; }

        [BindProperty]
        public string MaMatHang1 { get; set; }
        [BindProperty]
        public int SoLuong1 { get; set; }
        [BindProperty]
        public int DonGia1 { get; set; }

        [BindProperty]
        public string MaMatHang2 { get; set; }
        [BindProperty]
        public int SoLuong2 { get; set; }
        [BindProperty]
        public int DonGia2 { get; set; }

        [BindProperty]
        public string MaMatHang3 { get; set; }
        [BindProperty]
        public int SoLuong3 { get; set; }
        [BindProperty]
        public int DonGia3 { get; set; }

        [BindProperty]
        public string MaMatHang4 { get; set; }
        [BindProperty]
        public int SoLuong4 { get; set; }
        [BindProperty]
        public int DonGia4 { get; set; }

        [BindProperty]
        public string MaMatHang5 { get; set; }
        [BindProperty]
        public int SoLuong5 { get; set; }
        [BindProperty]
        public int DonGia5 { get; set; }

        public void OnGet()
        {
            dsmh = xuLyMatHang.DocDanhSachMatHang();
        }
        public void OnPost()
        {
            string[] MaMatHang = { MaMatHang1, MaMatHang2, MaMatHang3, MaMatHang4, MaMatHang5 };
            int[] SoLuong = { SoLuong1, SoLuong2, SoLuong3, SoLuong4, SoLuong5 };
            int[] DonGia = { DonGia1, DonGia2, DonGia3, DonGia4, DonGia5 };
            List<ChiTietHoaDon> a = new List<ChiTietHoaDon>();
            for (int i = 0; i < 5; i++)
            {
                a[i].MaMatHang = MaMatHang[i];
                a[i].TenMatHang = xuLyMatHang.ThemTenMatHang(a[i].MaMatHang);
                a[i].SoLuong = SoLuong[i];
                a[i].DonGia = xuLyMatHang.ThemDonGiaMatHang(a[i].MaMatHang);
            }
            HoaDonBan.MaHoaDon = Id;
            HoaDonBan.NgayTaoHoaDon = NgayTao;
            HoaDonBan.ChiTiet = a.ToList();
            bool kq = xuLyHoaDon.SuaHoaDonBanHang(HoaDonBan);
            Chuoi = $"Ket qua la {kq}";
        }
    }
}
