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
    public class MH_TimKiemMatHangModel : PageModel
    {
        private IXuLyMatHang xuLyMatHang;
        public List<MatHang> danhSachMatHang;
        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string DanhMucTimKiem { get; set; }
        public void OnGet()
        {
            danhSachMatHang = xuLyMatHang.TimKiem(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            danhSachMatHang = xuLyMatHang.TimKiem(TuKhoa, DanhMucTimKiem);
        }
        public MH_TimKiemMatHangModel()
        {
            xuLyMatHang = new XuLyMatHang();
        }
    }
}
