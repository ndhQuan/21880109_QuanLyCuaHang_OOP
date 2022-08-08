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
    public class MH_DanhSachHoaDonNhapHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        public List<HoaDon> dshdn;

        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string Target { get; set; }
        public void OnGet()
        {
            dshdn = xuLyHoaDon.TimKiemHoaDonNhapHang(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            dshdn = xuLyHoaDon.TimKiemHoaDonNhapHang(TuKhoa, Target);
        }
        public MH_DanhSachHoaDonNhapHangModel()
        {
            xuLyHoaDon = new XuLyHoaDon(); 
        }
    }
}
