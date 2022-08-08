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
    public class MH_ThemLoaiHangModel : PageModel
    {
        private IXuLyLoaiHang xuLyLoaiHang;
        public List<LoaiHang> dsLoaiHang;
        public string Chuoi { get; set; }
        [BindProperty]
        public string MaLoaiHang { get; set; }
        [BindProperty]
        public string TenLoaiHang { get; set; }

        public void OnGet()
        {
            Chuoi = string.Empty;
        }
        public void OnPost()
        {
            dsLoaiHang = xuLyLoaiHang.DocDanhSachLoaiHang();
            LoaiHang lhMoi = new LoaiHang(MaLoaiHang,TenLoaiHang);
            bool kq = xuLyLoaiHang.ThemLoaiHang(lhMoi);
            if (kq)
            {
                Chuoi = "Mat Hang moi da duoc them";
            }
            else Chuoi = "Mat Hang khong hop le";
        }
        public MH_ThemLoaiHangModel()
        {
            xuLyLoaiHang = new XuLyLoaiHang();
        }
    }
}
