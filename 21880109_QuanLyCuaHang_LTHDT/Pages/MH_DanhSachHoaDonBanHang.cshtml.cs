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
    public class MH_DanhSachHoaDonBanHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        public List<HoaDon> dshdb;

        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string Target { get; set; }
        public void OnGet()
        {
            dshdb = xuLyHoaDon.TimKiemHoaDonBanHang(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            dshdb = xuLyHoaDon.TimKiemHoaDonBanHang(TuKhoa, Target);
        }
        public MH_DanhSachHoaDonBanHangModel()
        {
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
