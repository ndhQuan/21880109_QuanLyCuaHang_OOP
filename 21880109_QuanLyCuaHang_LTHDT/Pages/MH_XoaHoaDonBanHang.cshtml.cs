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
    public class MH_XoaHoaDonBanHangModel : PageModel
    {
        private IXuLyHoaDon xuLyHoaDon;
        public string Chuoi;
        [BindProperty(SupportsGet = true)]
        public string Id { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            bool kq = xuLyHoaDon.XoaHoaDonBan(Id);
            Chuoi = $"Ket qua la {kq}";
        }
        public MH_XoaHoaDonBanHangModel()
        {
            xuLyHoaDon = new XuLyHoaDon();
        }
    }
}
