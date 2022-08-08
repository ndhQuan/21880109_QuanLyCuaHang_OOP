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
    public class MH_ChiTietHoaDonBanHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        public List<HoaDon> dshdb;
        public HoaDon HoaDonBan;
        public string Chuoi;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }

        public void OnGet()
        {
            dshdb = xuLyHoaDon.DocDanhSachHoaDonBanHang();
            foreach (HoaDon h in dshdb)
            {
                if (h.MaHoaDon == Id)
                {
                    HoaDonBan = h;
                }
            }
        }
        public MH_ChiTietHoaDonBanHangModel()
        {
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
