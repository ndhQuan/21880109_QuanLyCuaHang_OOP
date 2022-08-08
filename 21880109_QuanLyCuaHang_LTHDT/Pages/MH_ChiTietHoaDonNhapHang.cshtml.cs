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
    public class MH_ChiTietHoaDonNhapHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        public List<HoaDon> dshdn;
        public HoaDon HoaDonNhap;
        public string Chuoi;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {
            dshdn = xuLyHoaDon.DocDanhSachHoaDonNhapHang();
            foreach (HoaDon h in dshdn)
            {
                if (h.MaHoaDon == Id)
                {
                    HoaDonNhap = h;
                }
            }
        }
        public MH_ChiTietHoaDonNhapHangModel()
        {
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
