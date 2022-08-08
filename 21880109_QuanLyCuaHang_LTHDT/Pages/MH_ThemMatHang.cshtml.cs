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
    public class MH_ThemMatHangModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        private IXuLyMatHang xuLyMatHang;
        public List<LoaiHang> dsLoaiHang;
        public string Chuoi { get; set; }
        [BindProperty]
        public string MaMatHang { get; set; }
        [BindProperty]
        public string TenMatHang { get; set; }
        [BindProperty]
        public string HanDung { get; set; }
        [BindProperty]
        public string CtySX { get; set; }
        [BindProperty]
        public string NgaySX { get; set; }
        [BindProperty]
        public string LoaiHang { get; set; }
        [BindProperty]
        public int Gia { get; set; }

        public void OnGet()
        {
            Chuoi = string.Empty;
            dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
        }
        public void OnPost()
        {
            dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
            MatHang mhMoi = new MatHang(MaMatHang, TenMatHang, LoaiHang, HanDung, CtySX, NgaySX, Gia);
            bool kq = xuLyMatHang.ThemMatHang(mhMoi);
            if (kq)
            {
                Chuoi = "Mat Hang moi da duoc them";
            }
            else Chuoi = "Mat Hang khong hop le";
        }
        public MH_ThemMatHangModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
            xuLyMatHang = new XuLyMatHang();
        }
    }
}
