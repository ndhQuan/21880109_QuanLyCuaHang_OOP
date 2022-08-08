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
    public class MH_TimKiemLoaiHangModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        public List<LoaiHang> dsLoaiHang;
        [BindProperty]
        public string TuKhoa { get; set; }
        [BindProperty]
        public string DanhMucTimKiem { get; set; }
        public void OnGet()
        {
            dsLoaiHang = xuLyLoaiHang.TimKiem(string.Empty, string.Empty);
        }
        public void OnPost()
        {
            dsLoaiHang = xuLyLoaiHang.TimKiem(TuKhoa, DanhMucTimKiem);
        }
        public MH_TimKiemLoaiHangModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
        }
    }
}
